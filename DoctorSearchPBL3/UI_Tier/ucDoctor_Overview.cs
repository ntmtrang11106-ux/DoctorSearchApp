using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            
            // Hiệu ứng hover sử dụng Helper
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
            
            // Xử lý resize để items luôn full width
            flpRecentReviews.Resize += (s, ev) => {
                foreach (Control ctrl in flpRecentReviews.Controls) {
                    if (ctrl is ucReviewItem item) {
                        item.Width = flpRecentReviews.ClientSize.Width - 15;
                    }
                }
            };
            
            flpTodayApp.Resize += (s, ev) => {
                foreach (Control ctrl in flpTodayApp.Controls) {
                    if (ctrl is ucAppItem item) {
                        item.Width = flpTodayApp.ClientSize.Width - 15;
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
                    card.Paint += StatPanel_Paint;
                }
            }

            foreach (var icon in icons)
            {
                if (icon != null) UIHelper.ApplyRoundedRegion(icon, 20);
            }
        }

        private void StatPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                UIHelper.DrawControlBorder(pnl, e, 20, Color.Black, 2);
            }
        }



        public void SetDoctorData(DoctorDTO doctor)
        {
            _currentDoctor = doctor;
            _doctorId = doctor.Id;

            lblWelcome.Text = $"Chào mừng, {doctor.Position} {doctor.User?.FullName}";
            lblDept.Text = $"Chuyên khoa: {doctor.Department?.DepartmentName ?? "Chưa cập nhật"}";

            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            DoctorBUS bus = new DoctorBUS();
            
            // 1. Stats
            lblValue1.Text = bus.GetTodayAppointments(_doctorId).Count.ToString();
            lblValue2.Text = bus.GetTotalPatientsCount(_doctorId).ToString();
            lblValue3.Text = bus.GetPendingAppointmentsCount(_doctorId).ToString();
            
            // Tính toán rating
            bus.CalculateDoctorStats(_currentDoctor);
            lblValue4.Text = _currentDoctor.AverageRating.ToString("F1");
            
            if (_currentDoctor.Reviews != null && _currentDoctor.Reviews.Any())
            {
                double avg = _currentDoctor.Reviews.Average(r => r.Rating);
                lblValue4.Text = avg.ToString("0.0");
            }
            else
            {
                lblAvgRating.Text = "0.0";
            }

            // 2. Today's Appointments
            _appCurrentPage = 1;
            LoadTodayAppointments();

            // 3. Recent Reviews
            _reviewCurrentPage = 1;
            LoadRecentReviews();

            // 4. Update Date
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

            int startIndex = (page - 1) * _appPageSize;
            var pageItems = _allTodayApps.Skip(startIndex).Take(_appPageSize).ToList();

            foreach (var app in pageItems)
            {
                AddAppointmentRow(app);
            }

            int totalPages = Math.Max(1, (int)Math.Ceiling((double)_allTodayApps.Count / _appPageSize));
            lblAppPageStatus.Text = $"Trang {page} / {totalPages}";
            
            // Luôn xanh và bắt hover
            lblAppPrev.Enabled = true;
            lblAppNext.Enabled = true;
            lblAppPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblAppNext.ForeColor = Color.FromArgb(0, 120, 212);

            pnlAppPagination.Visible = _allTodayApps.Count > 0;
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
            row.Margin = new Padding(10, 5, 10, 5); // Thêm khoảng cách
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

            int startIndex = (page - 1) * _reviewPageSize;
            var pageItems = _allReviews.Skip(startIndex).Take(_reviewPageSize).ToList();

            foreach (var rev in pageItems)
            {
                ucReviewItem item = new ucReviewItem();
                item.SetReviewData(rev, _currentDoctor, -1);
                item.Margin = new Padding(10, 5, 10, 5); // Thêm khoảng cách
                flpRecentReviews.Controls.Add(item);
            }

            int totalPages = Math.Max(1, (int)Math.Ceiling((double)_allReviews.Count / _reviewPageSize));
            lblReviewPageStatus.Text = $"Trang {page} / {totalPages}";
            
            // Luôn xanh và bắt hover
            lblReviewPrev.Enabled = true;
            lblReviewNext.Enabled = true;
            lblReviewPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblReviewNext.ForeColor = Color.FromArgb(0, 120, 212);

            pnlReviewPagination.Visible = _allReviews.Count > 0;
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

            // Xóa buffer cũ nếu có
            Control oldBuffer = flp.Controls.Find("pnlBuffer", false).FirstOrDefault();
            if (oldBuffer != null) flp.Controls.Remove(oldBuffer);

            if (totalItemsHeight + pnlPagination.Height < availableHeight)
            {
                pnlPagination.Dock = DockStyle.Top;
                pnlPagination.Margin = new Padding(0, 10, 0, 0); // Thêm khoảng cách 10px
                flp.Dock = DockStyle.Top;
                flp.Height = totalItemsHeight;
                flp.AutoScroll = false;
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
