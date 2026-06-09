using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucDoctor_Overview : UserControl
    {
        private DoctorDTO _currentDoctor;
        private int _doctorId;

        private int _reviewPageSize = 5;
        private int _reviewCurrentPage = 1;
        private List<ReviewsDTO> _allReviews = new List<ReviewsDTO>();

        private int _appPageSize = 10;
        private int _appCurrentPage = 1;
        private List<AppointmentsDTO> _allTodayApps = new List<AppointmentsDTO>();

        public ucDoctor_Overview()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetupScrollableContainer(flpRecentReviews);
            UIHelper.SetupScrollableContainer(flpTodayApp);

            UIHelper.SetupHoverEffect(lblReviewPrev, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblReviewNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblAppPrev, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblAppNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));

            lblReviewPrev.Click += lblReviewPrev_Click;
            lblReviewNext.Click += lblReviewNext_Click;
            lblAppPrev.Click += lblAppPrev_Click;
            lblAppNext.Click += lblAppNext_Click;

            this.Load += ucDoctor_Overview_Load;
            this.Resize += (s, e) => {
                UpdateUI();
                UpdateListLayout(flpRecentReviews, pnlReviewPagination, pnlReviews, lblRecentReviewsTitle.Height + 20);
                UpdateListLayout(flpTodayApp, pnlAppPagination, pnlAppointments, lblTodayTitle.Height + 20);
            };
        }

        private void ucDoctor_Overview_Load(object sender, EventArgs e)
        {
            UpdateUI();

            flpRecentReviews.Resize += (s, ev) => {
                foreach (Control ctrl in flpRecentReviews.Controls)
                {
                    if (ctrl is ucReviewItem item)
                    {
                        // Trừ đi 25 thay vì 15 để dự phòng khoảng trống cho thanh cuộn (scrollbar) dọc
                        item.Width = flpRecentReviews.ClientSize.Width - 25;
                    }
                }
            };

            flpTodayApp.Resize += (s, ev) => {
                foreach (Control ctrl in flpTodayApp.Controls)
                {
                    // SỬA LỖI 2: Đổi từ ucAppItem thành ucAppointmentRow cho đúng kiểu dữ liệu
                    if (ctrl is ucAppointmentRow item)
                    {
                        item.Width = flpTodayApp.ClientSize.Width - 25;
                    }
                }
            };
        }

        private void UpdateUI()
        {
            UIHelper.ApplyRoundedRegion(pnlHeader, 15);
            UIHelper.ApplyRoundedRegion(pnlReviews, 25);
            UIHelper.ApplyRoundedRegion(pnlAppointments, 25);

            Panel[] cards = { pnlCard1, pnlCard2, pnlCard3, pnlCard4 };
            Panel[] icons = { pnlIcon1, pnlIcon2, pnlIcon3, pnlIcon4 };

            foreach (var card in cards)
            {
                if (card != null)
                {
                    UIHelper.ApplyRoundedRegion(card, 25);
                    // Bỏ đăng ký sự kiện cũ để tránh lặp bộ nhớ (Memory Leak) khi UpdateUI gọi nhiều lần
                    card.Paint -= StatPanel_Paint;
                    card.Paint += StatPanel_Paint;
                }
            }

            foreach (var icon in icons)
            {
                if (icon != null) UIHelper.ApplyRoundedRegion(icon, 20);
            }
        }

        // SỬA LỖI 1: Tự vẽ lại đường viền ôm khít và lùi 1 pixel vào trong góc để không bị khuất góc Region
        private void StatPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int radius = 25; // Khớp chuẩn xác bán kính bo tròn góc 25 của Region
                int borderThickness = 2;

                using (Pen pen = new Pen(Color.Black, borderThickness))
                {
                    // Thu nhỏ nhẹ hình chữ nhật vẽ viền (inset) vào trong để viền không chạm mép cắt Region
                    Rectangle rect = new Rectangle(
                        borderThickness / 2,
                        borderThickness / 2,
                        pnl.Width - borderThickness,
                        pnl.Height - borderThickness
                    );

                    using (GraphicsPath path = GetRoundedRectPath(rect, radius - borderThickness))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        // Hàm helper vẽ hình chữ nhật bo góc mượt mà
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            if (diameter <= 0) { path.AddRectangle(rect); return path; }

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        public void SetDoctorData(DoctorDTO doctor)
        {
            _currentDoctor = doctor;
            _doctorId = doctor.Id;

            lblWelcome.Text = $@"Chào mừng, {doctor.Position} {doctor.User?.FullName}";
            lblDept.Text = $@"Chuyên khoa: {doctor.Department?.DepartmentName ?? "Chưa cập nhật"}";

            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            DoctorBUS bus = new DoctorBUS();

            lblValue1.Text = bus.GetTodayAppointments(_doctorId).Count.ToString();
            lblValue2.Text = bus.GetTotalPatientsCount(_doctorId).ToString();
            lblValue3.Text = bus.GetPendingAppointmentsCount(_doctorId).ToString();

            bus.CalculateDoctorStats(_currentDoctor);
            lblValue4.Text = _currentDoctor.AverageRating.ToString("F1");

            if (_currentDoctor.Reviews != null && _currentDoctor.Reviews.Any())
            {
                double avg = _currentDoctor.Reviews.Average(r => r.Rating);
                lblValue4.Text = avg.ToString("0.0");
            }
            else
            {
                lblValue4.Text = "0.0";
            }

            _appCurrentPage = 1;
            LoadTodayAppointments();

            _reviewCurrentPage = 1;
            LoadRecentReviews();

            lblTodayDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy", new System.Globalization.CultureInfo("vi-VN"));
        }

        private void LoadTodayAppointments()
        {
            DoctorBUS bus = new DoctorBUS();
            _allTodayApps = bus.GetTodayAppointments(_doctorId);
            DisplayAppointments(_appCurrentPage);
        }

        private void DisplayAppointments(int page)
        {
            flpTodayApp.SuspendLayout();
            flpTodayApp.Controls.Clear();

            if (_allTodayApps.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không có lịch trình nào trong ngày hôm nay.",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 14, FontStyle.Italic),
                    Height = 150,
                    Width = flpTodayApp.Width - 10
                };
                flpTodayApp.Controls.Add(lblEmpty);
                pnlAppPagination.Visible = false;
            }
            else
            {
                int startIndex = (page - 1) * _appPageSize;
                var pageItems = _allTodayApps.Skip(startIndex).Take(_appPageSize).ToList();

                foreach (var app in pageItems)
                {
                    AddAppointmentRow(app);
                }

                int totalPages = Math.Max(1, (int)Math.Ceiling((double)_allTodayApps.Count / _appPageSize));
                lblAppPageStatus.Text = $@"Trang {page} / {totalPages}";

                lblAppPrev.Enabled = true;
                lblAppNext.Enabled = true;
                lblAppPrev.ForeColor = Color.FromArgb(0, 120, 212);
                lblAppNext.ForeColor = Color.FromArgb(0, 120, 212);

                pnlAppPagination.Visible = _allTodayApps.Count > _appPageSize;
            }

            UpdateListLayout(flpTodayApp, pnlAppPagination, pnlAppointments, lblTodayTitle.Height + 20);
            flpTodayApp.ResumeLayout();
        }

        private void lblAppPrev_Click(object sender, EventArgs e)
        {
            if (_appCurrentPage > 1)
            {
                _appCurrentPage--;
                DisplayAppointments(_appCurrentPage);
            }
        }

        private void lblAppNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_allTodayApps.Count / _appPageSize);
            if (_appCurrentPage < totalPages)
            {
                _appCurrentPage++;
                DisplayAppointments(_appCurrentPage);
            }
        }

        private void AddAppointmentRow(AppointmentsDTO app)
        {
            ucAppointmentRow row = new ucAppointmentRow();
            row.SetData(app);
            // SỬA LỖI 3: Tăng margin top/bottom từ 5 lên 10 để các hàng lịch hẹn thoáng hơn
            row.Margin = new Padding(12, 10, 12, 10);
            // Cập nhật kích thước ngay khi khởi tạo giúp giao diện mượt, không đợi resize
            row.Width = flpTodayApp.ClientSize.Width - 25;
            flpTodayApp.Controls.Add(row);
        }

        private void LoadRecentReviews()
        {
            DoctorBUS bus = new DoctorBUS();
            _allReviews = bus.GetDoctorReviews(_doctorId);
            DisplayReviews(_reviewCurrentPage);
        }

        private void DisplayReviews(int page)
        {
            flpRecentReviews.SuspendLayout();
            flpRecentReviews.Controls.Clear();

            if (_allReviews.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không có đánh giá nào từ bệnh nhân.",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 14, FontStyle.Italic),
                    Height = 150,
                    Width = flpRecentReviews.Width - 10
                };
                flpRecentReviews.Controls.Add(lblEmpty);
                pnlReviewPagination.Visible = false;
            }
            else
            {
                int startIndex = (page - 1) * _reviewPageSize;
                var pageItems = _allReviews.Skip(startIndex).Take(_reviewPageSize).ToList();

                foreach (var rev in pageItems)
                {
                    ucReviewItem item = new ucReviewItem();
                    item.SetReviewData(rev, _currentDoctor, -1);
                    // SỬA LỖI 3: Tăng margin top/bottom lên 12 giúp các item đánh giá giãn rộng vừa mắt
                    item.Margin = new Padding(12, 12, 12, 12);
                    // Cập nhật kích thước ngay lập tức tránh lệch khung khi load lần đầu
                    item.Width = flpRecentReviews.ClientSize.Width - 25;
                    flpRecentReviews.Controls.Add(item);
                }

                int totalPages = Math.Max(1, (int)Math.Ceiling((double)_allReviews.Count / _reviewPageSize));
                lblReviewPageStatus.Text = $@"Trang {page} / {totalPages}";

                lblReviewPrev.Enabled = true;
                lblReviewNext.Enabled = true;
                lblReviewPrev.ForeColor = Color.FromArgb(0, 120, 212);
                lblReviewNext.ForeColor = Color.FromArgb(0, 120, 212);

                pnlReviewPagination.Visible = _allReviews.Count > _reviewPageSize;
            }

            UpdateListLayout(flpRecentReviews, pnlReviewPagination, pnlReviews, lblRecentReviewsTitle.Height + 20);
            flpRecentReviews.ResumeLayout();
        }

        private void lblReviewPrev_Click(object sender, EventArgs e)
        {
            if (_reviewCurrentPage > 1)
            {
                _reviewCurrentPage--;
                DisplayReviews(_reviewCurrentPage);
            }
        }

        private void lblReviewNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_allReviews.Count / _reviewPageSize);
            if (_reviewCurrentPage < totalPages)
            {
                _reviewCurrentPage++;
                DisplayReviews(_reviewCurrentPage);
            }
        }

        private void UpdateListLayout(FlowLayoutPanel flp, Panel pnlPagination, Panel container, int reservedHeight)
        {
            flp.Padding = new Padding(flp.Padding.Left, flp.Padding.Top, flp.Padding.Right, 0);
            int totalItemsHeight = flp.Padding.Top + flp.Padding.Bottom;
            foreach (Control ctrl in flp.Controls)
            {
                if (ctrl.Visible && ctrl != pnlPagination && ctrl.Name != "pnlBuffer")
                    totalItemsHeight += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom;
            }

            int availableHeight = container.Height - reservedHeight;

            Control oldBuffer = flp.Controls.Find("pnlBuffer", false).FirstOrDefault();
            if (oldBuffer != null) flp.Controls.Remove(oldBuffer);

            if (totalItemsHeight + pnlPagination.Height < availableHeight)
            {
                pnlPagination.Dock = DockStyle.Top;
                pnlPagination.Margin = new Padding(0, 10, 0, 0);
                flp.Dock = DockStyle.Top;
                flp.Height = totalItemsHeight;
                flp.AutoScroll = false;

                if (flp.Controls.Count == 1 && flp.Controls[0] is Label lbl)
                {
                    lbl.Width = flp.Width - 10;
                    lbl.Height = Math.Max(150, availableHeight - 20);
                    flp.Height = lbl.Height + 10;
                }
            }
            else
            {
                pnlPagination.Dock = DockStyle.Bottom;
                pnlPagination.Margin = new Padding(0);
                flp.Dock = DockStyle.Fill;
                flp.AutoScroll = true;

                Panel pnlBuffer = new Panel { Height = 15, Width = flp.Width, Name = "pnlBuffer" };
                flp.Controls.Add(pnlBuffer);
            }

            container.Controls.SetChildIndex(pnlPagination, 0);
        }
    }
}