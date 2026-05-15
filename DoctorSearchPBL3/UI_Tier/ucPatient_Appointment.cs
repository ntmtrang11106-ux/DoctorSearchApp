using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL_Tier;

namespace UI_Tier
{
    public partial class ucPatient_Appointment : UserControl
    {
        public ucPatient_Appointment()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpAppItem);

            // Hiệu ứng hover cho các nút phân trang sử dụng Helper
            UIHelper.SetupHoverEffect(lblPrev, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            
            lblPrev.Click += lblPrev_Click;
            lblNext.Click += lblNext_Click;
        }
        // Khai báo một lần ở cấp độ class để tái sử dụng
        private AppointmentBUS _bus = new AppointmentBUS();

        private List<AppointmentsDTO> _allApps = new List<AppointmentsDTO>();
        private int _pageSize = 6;     // Số lượng 1 trang
        private int _currentPage = 1;  // Trang hiện tại

        private int _patientId = 0;
        private string _selectedStatus = "Tất cả"; // Trạng thái đang chọn mặc định

        public void SetPatientId(int id)
        {
            _patientId = id;
            InitData();
        }

        public void InitData()
        {
            try
            {
                string status = _selectedStatus.Trim();
                int currentId = _patientId > 0 ? _patientId : GlobalAccount.GetProfileId();
                
                var rawApps = _bus.GetAppointmentsByPatientId(currentId) ?? new List<AppointmentsDTO>();

                DateTime startDate = dtpBegin.Value.Date;
                DateTime endDate = dtpEnd.Value.Date;

                _allApps = rawApps.Where(a =>
                {
                    DateTime appDate = (a.TimeSlot != null) ? a.TimeSlot.WorkDate.Date : a.CreatedAt.Date;
                    bool isInDateRange = appDate >= startDate && appDate <= endDate;
                    if (!isInDateRange) return false;

                    if (status == "Tất cả") return true;

                    return MapStatusToDatabase(a.Status) == status;
                }).ToList();

                _currentPage = 1; 
                DisplayPage(_currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi InitData: " + ex.Message);
            }
        }

        // Chuyển đổi từ text trên nút sang giá trị Status trong DB (Tiếng Anh)
        private string MapStatusToDatabase(string statusInDb)
        {
            switch (statusInDb)
            {
                case "Pending": return "Chờ duyệt";
                case "Confirmed": return "Đã duyệt";
                case "Cancelled": return "Đã hủy";
                case "Completed": return "Hoàn thành";
                default: return statusInDb;
            }
        }

        // Hàm này dùng để vẽ 10 appointmet lên FlowLayoutPanel dựa vào số trang
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

                int totalItems = _allApps?.Count ?? 0;
                int totalPages = (int)Math.Ceiling((double)totalItems / _pageSize);
                if (totalPages == 0) totalPages = 1;
                lblPageStatus.Text = $"Trang {_currentPage} / {totalPages}";
                pnlPagination.Visible = (totalItems > 0);

                if (totalItems == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Bạn chưa có lịch hẹn nào trong khoảng thời gian này.";
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
                    card.SetupCard(ap, ucAppItem.AppCardMode.PatientView);
                    card.Margin = new Padding(20, 10, 20, 10);
                    card.Width = flpAppItem.ClientSize.Width - 40;
                    card.Height = 252;
                    
                    card.AppointmentDeleted += (s, ev) => InitData();
                    card.AppointmentEdited += (s, appData) => {
                        if (appData.Doctor == null) return;
                        ucBookingDialog editUc = new ucBookingDialog(appData.Doctor);
                        editUc.SetEditData(appData);
                        editUc.Location = new Point((this.Width - editUc.Width) / 2, (this.Height - editUc.Height) / 2);
                        editUc.AppointmentBooked += (s2, ev2) => InitData();
                        editUc.CloseRequested += (s2, ev2) => { this.Controls.Remove(editUc); editUc.Dispose(); };
                        this.Controls.Add(editUc);
                        editUc.BringToFront();
                    };

                    flpAppItem.Controls.Add(card);
                }
            }
            finally
            {
                flpAppItem.ResumeLayout(); 
            }
        }

        private void ucPatient_Appointment_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định (tháng hiện tại)
            dtpBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;

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
                    
                    // Thiết lập màu sắc khi di chuột và nhấn chuột
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 242, 254); // Màu xanh nhạt khi di chuột
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(186, 230, 253); // Màu xanh đậm hơn chút khi nhấn
                    
                    UIHelper.ApplyRoundedRegion(btn, 25); // Bo tròn sâu tạo hình viên thuốc
                }
            }

            UpdateButtonStyles();
            InitData();

            this.Resize += (s, ev) =>
            {
                foreach (Control ctrl in flpAppItem.Controls)
                {
                    if (ctrl is ucAppItem card)
                    {
                        card.Width = flpAppItem.ClientSize.Width - 40;
                    }
                }
            };
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
                        btn.BackColor = Color.FromArgb(0, 120, 212); // Màu xanh Hình 1
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(243, 244, 246); // Màu xám nhạt thanh thoát
                        btn.ForeColor = Color.FromArgb(107, 114, 128);
                        btn.Font = new Font("Segoe UI", 14f, FontStyle.Regular);
                    }
                }
            }
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
            int totalPages = (int)Math.Ceiling((double)_allApps.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }

    }
}
