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
            //UpdateUI();
            UIHelper.ApplyRoundedRegion(pnlHeader, 15);
            
            // Xử lý resize để review item luôn full width và không bị mất viền
            flpRecentReviews.Resize += (s, ev) => {
                foreach (Control ctrl in flpRecentReviews.Controls) {
                    if (ctrl is ucReviewItem item) {
                        item.Width = flpRecentReviews.ClientSize.Width - 15;
                    }
                }
            };
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
            UIHelper.ApplyRoundedRegion(pnlRecentReviews, 25);
            pnlRecentReviews.Resize += (s, e) => UIHelper.ApplyRoundedRegion(pnlRecentReviews, 25);

            Panel[] cards = { pnlCard1, pnlCard2, pnlCard3, pnlCard4 };
            Panel[] icons = { pnlIcon1, pnlIcon2, pnlIcon3, pnlIcon4 };

            foreach (var card in cards)
            {
                UIHelper.ApplyRoundedRegion(card, 25);
                card.Resize += (s, e) => UIHelper.ApplyRoundedRegion(card, 25);
            }

            foreach (var icon in icons)
            {
                UIHelper.ApplyRoundedRegion(icon, 20);
                icon.Resize += (s, e) => UIHelper.ApplyRoundedRegion(icon, 20);
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
            flpRecentReviews.SuspendLayout();
            flpRecentReviews.Controls.Clear();
            
            var realReviews = _dashboardBUS.GetRecentReviews(6);

            foreach (var rev in realReviews)
            {
                ucReviewItem item = new ucReviewItem();
                item.SetAdminReviewData(rev);
                item.Width = flpRecentReviews.ClientSize.Width - 20;

                // --- BẮT ĐẦU VẼ LẠI VỊ TRÍ CHO ADMIN ---
                // 1. Tìm nút Xóa và đẩy nó sát mép phải hơn
                var lblDelete = item.Controls.Find("lblDelete", true).FirstOrDefault();
                if (lblDelete != null) {
                    lblDelete.Location = new Point(item.Width - 100, 20); // Dịch chuyển tùy ý
                }

                // 2. Tìm số sao và đưa lên hàng trên cùng chẳng hạn
                var lblRating = item.Controls.Find("lblRating", true).FirstOrDefault();
                if (lblRating != null) {
                    lblRating.Location = new Point(100, 75); // Dịch chuyển vị trí mới
                }
                // ---------------------------------------

                flpRecentReviews.Controls.Add(item);
            }

            flpRecentReviews.ResumeLayout();
        }
    }
}
