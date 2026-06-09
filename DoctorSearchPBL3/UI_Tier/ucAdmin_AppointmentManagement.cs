using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucAdmin_AppointmentManagement : UserControl
    {
        private readonly AppointmentBUS _bus = new AppointmentBUS();
        private readonly TimeSlotBUS _tsBus = new TimeSlotBUS();
        private readonly DepartmentBUS _deptBus = new DepartmentBUS();
        private List<TimeSlotsDTO> _allApps = new List<TimeSlotsDTO>();
        private List<TimeSlotsDTO> _filteredApps = new List<TimeSlotsDTO>();
        
        private int _pageSize = 6;
        private int _currentPage = 1;
        private string _lastKeyword = "";
        private System.Windows.Forms.Timer _searchTimer;

        public ucAdmin_AppointmentManagement()
        {
            InitializeComponent();
            
            _searchTimer = new System.Windows.Forms.Timer();
            _searchTimer.Interval = 300;
            _searchTimer.Tick += (s, e) => 
            {
                _searchTimer.Stop();
                ApplyFilter();
            };
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetupScrollableContainer(flpAppItem);
            
            // Custom styling for search area
            UIHelper.ApplyRoundedRegion(pnlSearchArea, 15);
            UIHelper.ApplyRoundedRegion(btnCreateSchedule, 8);
            


            // Pagination styling and events
            UIHelper.SetupPaginationLabels(lblReviewPrevBtn, lblReviewNext);
            lblReviewPrevBtn.Click += lblPrev_Click;
            lblReviewNext.Click += lblNext_Click;

            // Unfocus logic: clicking anywhere else exits search
            UIHelper.RegisterClickToUnfocus(this, lblTitle);

            // Focus effect for search bar (Bottom line highlight)
            UIHelper.SetupInputFocusEffect(txtSearch, pnlSearchArea, Color.White, Color.White, Color.FromArgb(24, 112, 255));

            flpAppItem.Resize += (s, e) => {
                foreach (Control ctrl in flpAppItem.Controls)
                {
                    ctrl.Width = flpAppItem.ClientSize.Width - (ctrl.Margin.Left + ctrl.Margin.Right) - 20;
                }
            };

            // Đảm bảo lblNoData nằm trên cùng và không bị FlowLayout quản lý
            this.Controls.Add(lblNoData);
            lblNoData.BringToFront();
        }

        private void ucAdmin_AppointmentManagement_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyBorderPanelStyle(pnlSearchArea);

            UIHelper.SetupSearchTextBox(txtSearch, _searchPlaceholder);
            
            LoadCapacityFilter();
            SetupFilterButtons();
            InitData();
        }

        private void LoadCapacityFilter()
        {
            cbCapacity.Items.Add("Tất cả sức chứa");
            cbCapacity.Items.Add("Còn trống");
            cbCapacity.Items.Add("Đầy");
            cbCapacity.SelectedIndex = 0;
            UIHelper.SetupComboBox(cbCapacity);
        }

        private void cbCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }



        private int _currentDeptFilterId = 0; // 0 means "Tất cả chuyên khoa"
        private readonly string _searchPlaceholder = "Tìm kiếm theo tên bác sĩ, theo khoa, tên phòng...";

        private void SetupFilterButtons()
        {
            flpFilter.Controls.Clear();
            var depts = new List<DepartmentDTO>(_deptBus.GetAllDepartments());
            depts.Insert(0, new DepartmentDTO { Id = 0, DepartmentName = "Tất cả chuyên khoa" });

            foreach (var dept in depts)
            {
                Button btn = new Button
                {
                    Text = dept.DepartmentName,
                    Tag = dept.Id,
                    AutoSize = true,
                    Height = 55,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 12),
                    Margin = new Padding(3, 3, 10, 3)
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += DeptFilter_Click;
                flpFilter.Controls.Add(btn);
            }

            if (flpFilter.Controls.Count > 0)
                UpdateFilterButtonStyles((Button)flpFilter.Controls[0]);
        }

        private void DeptFilter_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                UpdateFilterButtonStyles(btn);
                _currentDeptFilterId = (int)btn.Tag;
                ApplyFilter();
            }
        }

        private void UpdateFilterButtonStyles(Button activeBtn)
        {
            foreach (Control ctrl in flpFilter.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (btn == activeBtn)
                    {
                        btn.BackColor = Color.FromArgb(24, 112, 255);
                        btn.ForeColor = Color.White;
                        UIHelper.ApplyRoundedRegion(btn, 25);
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(242, 246, 250);
                        btn.ForeColor = Color.Black;
                        UIHelper.ApplyRoundedRegion(btn, 25);
                    }
                }
            }
        }

        public void InitData(bool keepPage = false)
        {
            try
            {
                _allApps = _tsBus.GetAllTimeSlots();
                ApplyFilter(keepPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void ApplyFilter(bool keepPage = false)
        {
            string rawKeyword = txtSearch.Text.Trim();
            if (rawKeyword.Equals(_searchPlaceholder, StringComparison.OrdinalIgnoreCase)) rawKeyword = "";
            string keyword = DAL_Tier.DBHelper.RemoveDiacritics(rawKeyword).ToLower();
            
            int deptId = _currentDeptFilterId;
            string capacityFilter = cbCapacity.SelectedItem?.ToString() ?? "Tất cả sức chứa";

            _filteredApps = _allApps.Where(a => 
            {
                string docName = DAL_Tier.DBHelper.RemoveDiacritics(a.Doctor?.User?.FullName ?? "").ToLower();
                string deptName = DAL_Tier.DBHelper.RemoveDiacritics(a.Doctor?.Department?.DepartmentName ?? "").ToLower();
                string roomCode = DAL_Tier.DBHelper.RemoveDiacritics(a.Room?.RoomCode ?? "").ToLower();
                bool matchPatient = a.Appointments != null && a.Appointments.Any(app => DAL_Tier.DBHelper.RemoveDiacritics(app.Patient?.User?.FullName ?? "").ToLower().Contains(keyword));

                return (string.IsNullOrEmpty(keyword) || 
                        docName.Contains(keyword) || 
                        deptName.Contains(keyword) || 
                        roomCode.Contains(keyword) || 
                        matchPatient) &&
                       (deptId == 0 || a.Doctor?.DepartmentId == deptId) &&
                       (capacityFilter == "Tất cả sức chứa" || 
                        (capacityFilter == "Còn trống" && a.BookedCount < a.MaxAppointments) || 
                        (capacityFilter == "Đầy" && a.BookedCount >= a.MaxAppointments));
            }).ToList();

            if (!keepPage) _currentPage = 1;
            
            // Validate current page
            int totalPages = Math.Max(1, (int)Math.Ceiling((double)_filteredApps.Count / _pageSize));
            if (_currentPage > totalPages) _currentPage = totalPages;

            DisplayPage(_currentPage);
        }

        public void DisplayPage(int pageNumber)
        {
            UIHelper.SuspendDrawing(this);
            flpAppItem.SuspendLayout();
            foreach (Control ctrl in flpAppItem.Controls)
            {
                ctrl.Dispose();
            }
            flpAppItem.Controls.Clear();

            // Hiển thị thông báo khi không có dữ liệu (Căn giữa giống Review Management)
            lblNoData.Visible = (_filteredApps.Count == 0);
            if (lblNoData.Visible)
            {
                lblNoData.Text = "Không tìm thấy lịch hẹn phù hợp.";
                lblNoData.Left = (this.Width - lblNoData.Width) / 2;
                lblNoData.Top = 350; 
                lblNoData.BringToFront();
                
                lblReviewPageStatus.Text = ""; // Xóa text phân trang
                flpAppItem.ResumeLayout();
                UIHelper.ResumeDrawing(this);
                return;
            }

            int startIndex = (pageNumber - 1) * _pageSize;
            var pageItems = _filteredApps.Skip(startIndex).Take(_pageSize).ToList();

            var cards = new List<Control>();
            foreach (var slot in pageItems)
            {
                ucAppItem card = new ucAppItem();
                card.SetupCard(slot, ucAppItem.AppCardMode.AdminView);
                
                string currentRawKeyword = txtSearch.Text.Trim();
                if (currentRawKeyword != _searchPlaceholder)
                {
                    card.SearchKeyword = currentRawKeyword;
                }

                card.Margin = new Padding(3, 10, 3, 10);
                card.Width = flpAppItem.ClientSize.Width - (card.Margin.Left + card.Margin.Right) - 20;
                card.Height = 252;
                
                card.RefreshData = () => InitData(true);
                card.AdminTimeSlotEdited += (s, slotId) => {
                    var slotData = _allApps.FirstOrDefault(ts => ts.Id == slotId);
                    if (slotData != null)
                    {
                        int pendingApps = slotData.Appointments?.Count(a => a.Status == "Pending") ?? 0;
                        int confirmedApps = slotData.Appointments?.Count(a => a.Status == "Confirmed" || a.Status == "Completed") ?? 0;

                        if (confirmedApps > 0)
                        {
                            MessageBox.Show("Không thể chỉnh sửa ca khám này vì đã có lịch hẹn được duyệt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (pendingApps > 0)
                        {
                            if (MessageBox.Show($"Ca khám này đang có {pendingApps} bệnh nhân chờ duyệt.\nBạn có chắc chắn muốn tiếp tục chỉnh sửa không?", "Xác nhận chỉnh sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            {
                                return;
                            }
                        }

                        var editDialog = new ucTimeSlotDialog();
                        editDialog.SetupEditMode(slotData);
                        ShowOverlay(editDialog);
                    }
                };

                card.OnViewPatientsClicked += (s, slotId) => {
                    var detailsDialog = new ucAdmin_TimeSlotDetailsDialog();
                    var slotData = _allApps.FirstOrDefault(ts => ts.Id == slotId);
                    if (slotData != null)
                    {
                        detailsDialog.SetupData(slotData);
                        ShowOverlay(detailsDialog);
                    }
                };
                
                cards.Add(card);
            }

            if (cards.Count > 0)
            {
                flpAppItem.Controls.AddRange(cards.ToArray());
            }

            int totalPages = (int)Math.Ceiling((double)_filteredApps.Count / _pageSize);
            flpAppItem.ResumeLayout();
            lblReviewPageStatus.Text = $"Trang {_currentPage} / {totalPages}";
            UIHelper.ResumeDrawing(this);

            pnlReviewPagination.Visible = _filteredApps.Count > 0;
        }

        private void lblPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_filteredApps.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            var dialog = new ucTimeSlotDialog();
            ShowOverlay(dialog);
        }

        private void ShowOverlay(UserControl uc)
        {
            // Thêm trực tiếp form vào control thay vì dùng Panel nền xám
            uc.Location = new Point((this.Width - uc.Width) / 2, (this.Height - uc.Height) / 2);
            
            if (uc is ucTimeSlotDialog dialog)
            {
                dialog.OnCloseModal += (s, e) => {
                    this.Controls.Remove(dialog);
                    dialog.Dispose();
                    InitData(true);
                };
            }

            if (uc is ucAdmin_TimeSlotDetailsDialog detailsDialog)
            {
                detailsDialog.OnCloseModal += (s, e) => {
                    this.Controls.Remove(detailsDialog);
                    detailsDialog.Dispose();
                };
            }

            this.Controls.Add(uc);
            uc.BringToFront();
        }

        private void pnlSearchArea_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(203, 213, 225), 2);
        }

        private void pnlTableHead_Paint(object sender, PaintEventArgs e)
        {
            // Bottom border for header
            using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 2))
            {
                e.Graphics.DrawLine(pen, 0, pnlTableHead.Height - 1, pnlTableHead.Width, pnlTableHead.Height - 1);
            }
        }
        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }



        private bool CheckStatusFilter(TimeSlotsDTO slot, string filter)
        {
            if (filter == "Tất cả trạng thái") return true;

            if (filter == "Đã ẩn") return slot.Status == "Hidden" && !slot.IsDeleted;
            if (filter == "Đã xóa") return slot.IsDeleted;
            
            // Nếu lọc theo các trạng thái khác thì không hiện những cái Đã xóa
            if (slot.IsDeleted) return false;

            // Nếu lọc theo Trống/Đầy thì không hiện những cái Đã ẩn
            if (slot.Status == "Hidden") return false;

            if (filter == "Chờ duyệt") return slot.Appointments != null && slot.Appointments.Any(a => a.Status == "Pending");
            if (filter == "Đã duyệt") return slot.Appointments != null && slot.Appointments.Any(a => a.Status == "Confirmed");
            if (filter == "Đã hủy") return slot.Appointments != null && slot.Appointments.Any(a => a.Status == "Cancelled");
            if (filter == "Thành công") return slot.Appointments != null && slot.Appointments.Any(a => a.Status == "Completed");
            if (filter == "Còn trống") return slot.BookedCount < slot.MaxAppointments;
            if (filter == "Đầy") return slot.BookedCount >= slot.MaxAppointments;
            
            return true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string currentKeyword = txtSearch.Text.Trim().ToLower();
            if (currentKeyword == _searchPlaceholder.ToLower()) currentKeyword = "";

            if (_lastKeyword == currentKeyword) return;
            _lastKeyword = currentKeyword;

            _searchTimer.Stop();
            _searchTimer.Start();
        }
    }
}
