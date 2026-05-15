using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace UI_Tier
{
    public partial class ucDoctor_Appointment : UserControl
    {
        public ucDoctor_Appointment()
        {
            InitializeComponent();

            UIHelper.ApplyRoundedRegion(btnAddTimeSlot, 10);
            UIHelper.SetupHoverEffect(lblReviewPrevBtn, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212), 3);
            UIHelper.SetupHoverEffect(lblReviewNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212), 3);

            lblReviewPrevBtn.Click += lblReviewPrevBtn_Click;
            lblReviewNext.Click += lblReviewNext_Click;

            // Tự động co giãn các card khi resize form
            flpAppItem.Resize += (s, e) =>
            {
                foreach (Control ctrl in flpAppItem.Controls)
                {
                    if (ctrl is ucAppItem card)
                    {
                        card.Width = flpAppItem.ClientSize.Width - 40;
                    }
                }
                //UpdateListLayout();
            };

            // Đăng ký sự kiện lọc
            dtpBegin.ValueChanged += (s, ev) => InitData();
            dtpEnd.ValueChanged += (s, ev) => InitData();

            foreach (Control ctrl in flpFilter.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Click += StatusButton_Click;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    UIHelper.ApplyRoundedRegion(btn, 25);
                }
            }
            UpdateButtonStyles();
        }

        #region Xử lý phân trang (Pagination)
        private AppointmentBUS _bus = new AppointmentBUS();
        private List<AppointmentsDTO> _allApps = new List<AppointmentsDTO>();
        private int _pageSize = 6;     // Số lượng 1 trang
        private int _currentPage = 1;  // Trang hiện tại
        private int _doctorId = 0;
        private string _selectedStatus = "Tất cả";

        public void SetDoctorId(int id)
        {
            _doctorId = id;
            InitData();
        }

        public void InitData()
        {
            try
            {
                string status = _selectedStatus.Trim();

                // 1. Lấy dữ liệu thô
                var rawApps = _doctorId > 0 ? _bus.GetAppointmentsByDoctorId(_doctorId) : _bus.GetAll();
                TimeSlotBUS tsBus = new TimeSlotBUS();
                var rawSlots = _doctorId > 0 ? tsBus.GetTimeSlotsByDoctor(_doctorId) : tsBus.GetAllTimeSlots();

                DateTime startDate = dtpBegin.Value.Date;
                DateTime endDate = dtpEnd.Value.Date;

                // 2. Lọc Appointments theo ngày và trạng thái
                var filteredApps = (rawApps ?? new List<AppointmentsDTO>()).Where(a =>
                {
                    DateTime appDate = (a.TimeSlot != null) ? a.TimeSlot.WorkDate.Date : a.CreatedAt.Date;
                    bool isInDateRange = appDate >= startDate && appDate <= endDate;
                    if (!isInDateRange) return false;

                    if (status == "Tất cả") return true;
                    if (status == "Trống") return false;

                    return MapStatusToDatabase(a.Status) == status;
                }).ToList();

                List<AppointmentsDTO> finalItems = new List<AppointmentsDTO>(filteredApps);

                // 3. Xử lý hiển thị các Slot trống (Chỉ khi chọn "Tất cả" hoặc "Trống")
                if (status == "Tất cả" || status == "Trống")
                {
                    var slotsInDateRange = (rawSlots ?? new List<TimeSlotsDTO>()).Where(s =>
                        s.WorkDate.Date >= startDate && s.WorkDate.Date <= endDate && !s.IsDeleted
                    ).ToList();

                    foreach (var slot in slotsInDateRange)
                    {
                        // Kiểm tra xem khung giờ này còn chỗ hay không (BookedCount < MaxAppointments)
                        // Bất kể đã có lịch Pending/Confirmed hay chưa, nếu còn chỗ thì vẫn hiện thẻ "Trống"
                        if (slot.BookedCount < slot.MaxAppointments)
                        {
                            finalItems.Add(CreateEmptyAppointment(slot));
                        }
                    }
                }

                // 4. Sắp xếp: Ngày -> Giờ (Tăng dần để giống lịch trình)
                _allApps = finalItems
                    .OrderBy(a => (a.TimeSlot != null) ? a.TimeSlot.WorkDate : a.CreatedAt.Date)
                    .ThenBy(a => (a.TimeSlot != null) ? a.TimeSlot.StartTime : TimeSpan.Zero)
                    .ToList();

                _currentPage = 1;
                DisplayPage(_currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi InitData: " + ex.Message);
            }
        }

        private AppointmentsDTO CreateEmptyAppointment(TimeSlotsDTO slot)
        {
            return new AppointmentsDTO
            {
                TimeSlotId = slot.Id,
                TimeSlot = slot,
                Status = "Open",
                Doctor = slot.Doctor,
                CreatedAt = slot.CreatedAt
            };
        }

        public void DisplayPage(int pageNumber)
        {
            flpAppItem.SuspendLayout();
            try
            {
                while (flpAppItem.Controls.Count > 0)
                {
                    var control = flpAppItem.Controls[0];
                    flpAppItem.Controls.RemoveAt(0);
                    control.Dispose();
                }

                int totalPages = (int)Math.Ceiling((double)_allApps.Count / _pageSize);
                if (totalPages == 0) totalPages = 1;
                lblReviewPageStatus.Text = $"Trang {_currentPage} / {totalPages}";

                if (_allApps == null || _allApps.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Không có lịch trình nào trong khoảng thời gian này.";
                    lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                    lblEmpty.AutoSize = false;
                    lblEmpty.Size = new Size(flpAppItem.ClientSize.Width - 40, 100);
                    lblEmpty.ForeColor = Color.Gray;
                    lblEmpty.Font = new Font("Segoe UI", 11, FontStyle.Italic);
                    flpAppItem.Controls.Add(lblEmpty);
                    return;
                }

                int startIndex = (pageNumber - 1) * _pageSize;
                var pageItems = _allApps.Skip(startIndex).Take(_pageSize).ToList();

                foreach (var ap in pageItems)
                {
                    ucAppItem card = new ucAppItem();
                    card.SetupCard(ap, ucAppItem.AppCardMode.DoctorView);
                    card.Margin = new Padding(20, 10, 20, 10);
                    card.Width = flpAppItem.ClientSize.Width - 40;
                    card.Height = 252;

                    card.RefreshData = () => InitData();
                    card.AppointmentDeleted += (s, ev) => InitData();
                    card.AppointmentEdited += (s, appData) =>
                    {
                        if (appData.Doctor == null) return;
                        ucBookingDialog editUc = new ucBookingDialog(appData.Doctor);
                        editUc.SetEditData(appData);
                        editUc.Location = new Point((this.Width - editUc.Width) / 2, (this.Height - editUc.Height) / 2);
                        editUc.AppointmentBooked += (s2, ev2) => InitData();
                        editUc.CloseRequested += (s2, ev2) =>
                        {
                            this.Controls.Remove(editUc);
                            editUc.Dispose();
                        };
                        this.Controls.Add(editUc);
                        editUc.BringToFront();
                    };

                    flpAppItem.Controls.Add(card);
                }

                pnlReviewPagination.Visible = _allApps.Count > 0;
                //UpdateListLayout();
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DisplayPage: " + ex.Message); }
            finally
            {
                flpAppItem.ResumeLayout();
            }
        }

        private void ucDoctor_Appointment_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void lblReviewPrevBtn_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void lblReviewNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_allApps.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }
        private void StatusButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                _selectedStatus = btn.Text.Trim();
                UpdateButtonStyles();
                InitData();
            }
        }

        private void UpdateButtonStyles()
        {
            foreach (Control ctrl in flpFilter.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (btn.Text == _selectedStatus)
                    {
                        btn.BackColor = Color.FromArgb(0, 120, 212);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(243, 244, 246);
                        btn.ForeColor = Color.FromArgb(107, 114, 128);
                        btn.Font = new Font("Segoe UI", 12f, FontStyle.Regular);
                    }
                }
            }
        }

        private string MapStatusToDatabase(string statusInDb)
        {
            switch (statusInDb)
            {
                case "Open": return "Trống";
                case "Pending": return "Chờ duyệt";
                case "Confirmed": return "Đã duyệt";
                case "Cancelled": return "Đã hủy";
                case "Completed": return "Thành công";
                default: return statusInDb;
            }
        }
        #region Xử lý phân trang (Pagination)
        private void UpdateListLayout()
        {
            flpAppItem.Padding = new Padding(flpAppItem.Padding.Left, flpAppItem.Padding.Top, flpAppItem.Padding.Right, 0);
            int totalItemsHeight = flpAppItem.Padding.Top + flpAppItem.Padding.Bottom;
            foreach (Control ctrl in flpAppItem.Controls)
            {
                if (ctrl.Visible && ctrl != pnlReviewPagination && ctrl.Name != "pnlBuffer")
                    totalItemsHeight += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom;
            }

            int availableHeight = pnlResultContainer.Height - pnlResultContainer.Padding.Top - pnlResultContainer.Padding.Bottom;

            // Xóa buffer cũ
            Control oldBuffer = flpAppItem.Controls.Find("pnlBuffer", false).FirstOrDefault();
            if (oldBuffer != null) flpAppItem.Controls.Remove(oldBuffer);

            if (totalItemsHeight + pnlReviewPagination.Height < availableHeight)
            {
                // Danh sách ngắn: Bám sát nội dung
                pnlReviewPagination.Dock = DockStyle.Top;
                pnlReviewPagination.Margin = new Padding(0, 10, 0, 0);
                flpAppItem.Dock = DockStyle.Top;
                flpAppItem.Height = totalItemsHeight;
                flpAppItem.AutoScroll = false;
            }
            else
            {
                // Danh sách dài: Đứng yên ở đáy - Sát khít đáy hoàn toàn
                pnlReviewPagination.Dock = DockStyle.Bottom;
                pnlReviewPagination.Margin = new Padding(0);
                flpAppItem.Dock = DockStyle.Fill;
                flpAppItem.AutoScroll = true;

                // Thêm đệm vật lý 20px để card cuối không bị che viền
                Panel pnlBuffer = new Panel { Height = 20, Width = flpAppItem.Width - 25, Name = "pnlBuffer" };
                flpAppItem.Controls.Add(pnlBuffer);
            }

            // Đảm bảo Z-Order đúng trong Container - Kiểm tra an toàn
            if (!pnlResultContainer.Controls.Contains(pnlReviewPagination))
            {
                pnlResultContainer.Controls.Add(pnlReviewPagination);
            }
            pnlResultContainer.Controls.SetChildIndex(pnlReviewPagination, 0);
        }
        #endregion

        private void btnAddTimeSlot_Click(object sender, EventArgs e)
        {
            var myDialog = new ucTimeSlotDialog();
            var mainForm = this.FindForm() as frmDoctor;
            if (mainForm != null)
            {
                mainForm.ShowOverlay(myDialog);
            }
        }
    }
        #endregion
}