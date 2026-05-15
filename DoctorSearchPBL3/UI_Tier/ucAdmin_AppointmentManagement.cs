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

        public ucAdmin_AppointmentManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpAppItem);
            
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
                    ctrl.Width = flpAppItem.ClientSize.Width - 20;
                }
            };

            // Đảm bảo lblNoData nằm trên cùng và không bị FlowLayout quản lý
            this.Controls.Add(lblNoData);
            lblNoData.BringToFront();
        }

        private void ucAdmin_AppointmentManagement_Load(object sender, EventArgs e)
        {
            UIHelper.SetupSearchTextBox(txtSearch, "Tìm kiếm theo bác sĩ, khoa, phòng...");
            UIHelper.SetupComboBox(cbDept);
            UIHelper.SetupComboBox(cbStatusFilter);
            LoadDepartments();
            LoadStatusFilter();
            InitData();
        }

        private void LoadDepartments()
        {
            try
            {
                var depts = _deptBus.GetAllDepartments();
                depts.Insert(0, new DepartmentDTO { Id = 0, DepartmentName = "Tất cả chuyên khoa" });
                cbDept.DataSource = depts;
                cbDept.DisplayMember = "DepartmentName";
                cbDept.ValueMember = "Id";
            }
            catch { }
        }

        private void LoadStatusFilter()
        {
            cbStatusFilter.Items.Clear();
            cbStatusFilter.Items.Add("Tất cả trạng thái");
            cbStatusFilter.Items.Add("Chờ duyệt");
            cbStatusFilter.Items.Add("Đã duyệt");
            cbStatusFilter.Items.Add("Đã hủy");
            cbStatusFilter.Items.Add("Còn trống");
            cbStatusFilter.Items.Add("Đầy");
            cbStatusFilter.Items.Add("Đã ẩn");
            cbStatusFilter.Items.Add("Đã xóa");
            cbStatusFilter.SelectedIndex = 0;
        }

        public void InitData()
        {
            try
            {
                _allApps = _tsBus.GetAllTimeSlots();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (keyword == "tìm kiếm theo bác sĩ, khoa, phòng...") keyword = "";
            
            int deptId = (cbDept.SelectedValue is int id) ? id : 0;
            string statusFilter = cbStatusFilter.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            _filteredApps = _allApps.Where(a => 
                (string.IsNullOrEmpty(keyword) || 
                 (a.Doctor?.User?.FullName?.ToLower().Contains(keyword) ?? false) ||
                 (a.Doctor?.Department?.DepartmentName?.ToLower().Contains(keyword) ?? false) ||
                 (a.Room?.RoomCode?.ToLower().Contains(keyword) ?? false)) &&
                (deptId == 0 || a.Doctor?.DepartmentId == deptId) &&
                (statusFilter == "Tất cả trạng thái" || CheckStatusFilter(a, statusFilter))
            ).ToList();

            _currentPage = 1;
            DisplayPage(_currentPage);
        }

        public void DisplayPage(int pageNumber)
        {
            flpAppItem.SuspendLayout();
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
                return;
            }

            int startIndex = (pageNumber - 1) * _pageSize;
            var pageItems = _filteredApps.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var slot in pageItems)
            {
                ucAppItem card = new ucAppItem();
                card.SetupCard(slot, ucAppItem.AppCardMode.AdminView);
                card.Width = flpAppItem.ClientSize.Width - 20;
                card.Height = 252;
                card.Margin = new Padding(-10, 10, 10, 10);
                
                card.RefreshData = () => InitData();
                card.AdminTimeSlotEdited += (s, slotId) => {
                    var editDialog = new ucTimeSlotDialog();
                    var slotData = _allApps.FirstOrDefault(ts => ts.Id == slotId);
                    if (slotData != null)
                    {
                        editDialog.SetupEditMode(slotData);
                        ShowOverlay(editDialog);
                    }
                };
                
                flpAppItem.Controls.Add(card);
            }

            int totalPages = (int)Math.Ceiling((double)_filteredApps.Count / _pageSize);
            lblReviewPageStatus.Text = $"Trang {_currentPage} / {totalPages} ";
            flpAppItem.ResumeLayout();
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
                    InitData();
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

        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
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
            if (filter == "Còn trống") return slot.BookedCount < slot.MaxAppointments;
            if (filter == "Đầy") return slot.BookedCount >= slot.MaxAppointments;
            
            return true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}
