using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucAdmin_Overview : UserControl
    {
        private readonly DashboardBUS _dashboardBUS;
        private List<ReviewsDTO> _allReviews = new List<ReviewsDTO>();
        private int _currentPage = 1;
        private int _pageSize = 4;

        public ucAdmin_Overview()
        {
            InitializeComponent();
            _dashboardBUS = new DashboardBUS();
            UIHelper.SetDoubleBuffered(this);
            this.Load += ucAdmin_Overview_Load;
        }

        private void ucAdmin_Overview_Load(object sender, EventArgs e)
        {
            // Set up Filter ComboBox items
            cboFilter.Items.Clear();
            for (int i = 0; i < 12; i++)
            {
                DateTime dt = DateTime.Now.AddMonths(-i);
                cboFilter.Items.Add(new { Text = $"Tháng {dt.ToString("MM/yyyy")}", Value = dt });
            }
            cboFilter.DisplayMember = "Text";
            cboFilter.ValueMember = "Value";
            cboFilter.SelectedIndex = 0;

            cboFilter.SelectedIndexChanged -= CboFilter_SelectedIndexChanged;
            cboFilter.SelectedIndexChanged += CboFilter_SelectedIndexChanged;

            LoadRealData(DateTime.Now);
            UpdateUI();
            
            // Xử lý resize để review item luôn full width và không bị mất viền
            flpRecentReviews.Resize += (s, ev) => {
                foreach (Control ctrl in flpRecentReviews.Controls) {
                    if (ctrl is ucReviewItem item) {
                        item.Width = flpRecentReviews.ClientSize.Width - 40;
                    }
                }
            };

            lblReviewPrevBtn.Click += (s, ev) => { if (_currentPage > 1) { _currentPage--; DisplayRecentReviews(); } };
            lblReviewNext.Click += (s, ev) => { 
                int totalPages = (int)Math.Ceiling((double)_allReviews.Count / _pageSize);
                if (_currentPage < totalPages) { _currentPage++; DisplayRecentReviews(); } 
            };

            // Hiệu ứng "nhảy" và đổi màu khi di chuột sử dụng Helper
            UIHelper.SetupHoverEffect(lblReviewPrevBtn, Color.FromArgb(0, 102, 180), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblReviewNext, Color.FromArgb(0, 102, 180), Color.FromArgb(0, 120, 212));
        }




        private void CboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (dynamic)cboFilter.SelectedItem;
            DateTime targetDate = selected.Value;
            
            lblHeaderTitle.Text = $"Thống kê {targetDate.ToString("MM/yyyy")}";
            LoadRealData(targetDate);
        }

        private void UpdateUI()
        {
            UIHelper.ApplyRoundedRegion(pnlHeader, 15);
            UIHelper.ApplyRoundedRegion(pnlRecentReviews, 25);
            pnlRecentReviews.Resize += (s, e) => UIHelper.ApplyRoundedRegion(pnlRecentReviews, 25);

            Panel[] cards = { pnlCard1, pnlCard2, pnlCard3, pnlCard4 };
            Panel[] icons = { pnlIcon1, pnlIcon2, pnlIcon3, pnlIcon4 };

            foreach (var card in cards)
            {
                if (card != null)
                {
                    UIHelper.SetDoubleBuffered(card);
                    UIHelper.ApplyRoundedRegion(card, 25);
                    card.Paint += StatPanel_Paint;
                    card.Resize += (s, e) => UIHelper.ApplyRoundedRegion(card, 25);
                }
            }

            foreach (var icon in icons)
            {
                if (icon != null)
                {
                    UIHelper.ApplyRoundedRegion(icon, 20);
                    icon.Resize += (s, e) => UIHelper.ApplyRoundedRegion(icon, 20);
                }
            }

            // Viền cho 2 biểu đồ chính
            Control[] charts = { chartApp, chartUserGrowth };
            foreach (var c in charts)
            {
                if (c != null)
                {
                    UIHelper.SetDoubleBuffered(c);
                    UIHelper.ApplyRoundedRegion(c, 25);
                    c.Paint += ChartPanel_Paint;
                    c.Resize += (s, e) => UIHelper.ApplyRoundedRegion(c, 25);
                }
            }
        }

        private void ChartPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Control ctrl)
            {
                UIHelper.DrawControlBorder(ctrl, e, 25, Color.Black, 1);
            }
        }

        private void StatPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                UIHelper.DrawControlBorder(pnl, e, 25, Color.Black, 2);
            }
        }

        private void LoadRealData(DateTime targetDate)
        {
            try
            {
                // 1. Load Summary Stats
                var summary = _dashboardBUS.GetDashboardSummary(targetDate);
                
                UpdateStatCard(lblValue1, lblTrend1, summary["Patients"]);
                UpdateStatCard(lblValue2, lblTrend2, summary["Doctors"]);
                UpdateStatCard(lblValue3, lblTrend3, summary["Reviews"]);
                UpdateStatCard(lblValue4, lblTrend4, summary["Appointments"]);
                
                lblTitle4.Text = $"Lịch hẹn tháng {targetDate.ToString("MM")}";

                // 2. Charts (Dữ liệu thật từ SQL)
                var monthlyStats = _dashboardBUS.GetYearlyAppointmentStats(targetDate.Year);
                var months = new List<string>();
                var dataPoints = new List<double>();

                for (int m = 1; m <= 12; m++)
                {
                    months.Add("T" + m);
                    // Lấy dữ liệu thật từ SQL, nếu tháng đó chưa có dữ liệu thì để là 0
                    dataPoints.Add(monthlyStats.ContainsKey(m) ? monthlyStats[m] : 0);
                }

                chartApp.SetData(dataPoints, months);
                
                // 2b. User Growth Chart (Dữ liệu thật 2 đường: Bác sĩ & Bệnh nhân)
                var userStats = _dashboardBUS.GetYearlyUserGrowthStats(targetDate.Year);
                chartUserGrowth.SetMultiData(
                    new List<List<double>> { userStats.doctors, userStats.patients },
                    months,
                    new List<string> { "Bác sĩ", "Bệnh nhân" },
                    new List<Color> { Color.FromArgb(40, 199, 111), Color.FromArgb(24, 112, 255) } // Xanh lá & Xanh dương
                );

                // 3. Load Department Stats
                var deptData = _dashboardBUS.GetDepartmentStats();
                var deptCounts = new List<double>();
                var deptNames = new List<string>();
                var colors = new List<Color> { 
                    Color.FromArgb(40, 199, 111), Color.FromArgb(255, 159, 67), 
                    Color.FromArgb(234, 84, 85), Color.FromArgb(24, 112, 255), 
                    Color.FromArgb(127, 85, 240) 
                };

                foreach (var kvp in deptData)
                {
                    deptCounts.Add((double)kvp.Value);
                    deptNames.Add(kvp.Key);
                }
                
                if (deptCounts.Count > 0)
                {
                    chartDept.SetData(deptCounts, deptNames, colors.Take(deptCounts.Count).ToList());
                }

                // 4. Load Recent Reviews
                LoadRecentReviews();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Dashboard: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatCard(Label lblValue, Label lblTrend, (int current, double growth) data)
        {
            lblValue.Text = data.current.ToString("N0");
            
            string symbol = data.growth >= 0 ? "↑" : "↓";
            lblTrend.Text = $"{symbol} {Math.Abs(data.growth)}% so với tháng trước";
            
            if (data.growth > 0) lblTrend.ForeColor = Color.FromArgb(40, 199, 111);
            else if (data.growth < 0) lblTrend.ForeColor = Color.FromArgb(234, 84, 85);
            else lblTrend.ForeColor = Color.Gray;
        }

        private void LoadRecentReviews()
        {
            _allReviews = _dashboardBUS.GetRecentReviews(20); // Lấy 20 cái mới nhất để phân trang
            _currentPage = 1;
            DisplayRecentReviews();
        }

        private void DisplayRecentReviews()
        {
            flpRecentReviews.SuspendLayout();
            flpRecentReviews.Controls.Clear();
            
            int startIndex = (_currentPage - 1) * _pageSize;
            var pageItems = _allReviews.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var rev in pageItems)
            {
                ucReviewItem item = new ucReviewItem();
                item.SetAdminReviewData(rev, true); 
                item.Width = flpRecentReviews.ClientSize.Width - 40;
                flpRecentReviews.Controls.Add(item);
            }

            int totalPages = (int)Math.Ceiling((double)_allReviews.Count / _pageSize);
            lblReviewPageStatus.Text = $"Trang {_currentPage} / {Math.Max(1, totalPages)}";
            
            lblNoReviews.Visible = _allReviews.Count == 0;
            if (lblNoReviews.Visible)
            {
                lblNoReviews.Left = (pnlRecentReviews.Width - lblNoReviews.Width) / 2;
                lblNoReviews.Top = (pnlRecentReviews.Height - lblNoReviews.Height) / 2;
                lblNoReviews.BringToFront();
            }

            flpRecentReviews.ResumeLayout();
        }
    }
}
