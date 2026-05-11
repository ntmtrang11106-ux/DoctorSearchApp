namespace UI_Tier
{
    partial class ucAdmin_Overview
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlStats = new TableLayoutPanel();
            pnlCard1 = new Panel();
            lblTitle1 = new Label();
            lblValue1 = new Label();
            lblTrend1 = new Label();
            pnlIcon1 = new Panel();
            lblIcon1 = new Label();
            pnlCard2 = new Panel();
            lblTitle2 = new Label();
            lblValue2 = new Label();
            lblTrend2 = new Label();
            pnlIcon2 = new Panel();
            lblIcon2 = new Label();
            pnlCard3 = new Panel();
            lblTitle3 = new Label();
            lblValue3 = new Label();
            lblTrend3 = new Label();
            pnlIcon3 = new Panel();
            lblIcon3 = new Label();
            pnlCard4 = new Panel();
            lblTitle4 = new Label();
            lblValue4 = new Label();
            lblTrend4 = new Label();
            pnlIcon4 = new Panel();
            lblIcon4 = new Label();
            tlpCharts = new TableLayoutPanel();
            chartApp = new ucSimpleChart();
            chartUserGrowth = new ucSimpleChart();
            tlpBottom = new TableLayoutPanel();
            chartDept = new ucPieChart();
            pnlRecentReviews = new Panel();
            flpRecentReviews = new FlowLayoutPanel();
            lblRecentReviewsTitle = new Label();
            pnlHeader = new Panel();
            flpHeaderInternal = new FlowLayoutPanel();
            lblHeaderTitle = new Label();
            cboFilter = new ComboBox();
            pnlStats.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlIcon1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlIcon2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlIcon3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlIcon4.SuspendLayout();
            tlpCharts.SuspendLayout();
            tlpBottom.SuspendLayout();
            pnlRecentReviews.SuspendLayout();
            pnlHeader.SuspendLayout();
            flpHeaderInternal.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStats
            // 
            pnlStats.ColumnCount = 4;
            pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.Controls.Add(pnlCard1, 0, 0);
            pnlStats.Controls.Add(pnlCard2, 1, 0);
            pnlStats.Controls.Add(pnlCard3, 2, 0);
            pnlStats.Controls.Add(pnlCard4, 3, 0);
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(40, 90);
            pnlStats.Margin = new Padding(0);
            pnlStats.Name = "pnlStats";
            pnlStats.RowCount = 1;
            pnlStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStats.Size = new Size(1800, 205);
            pnlStats.TabIndex = 0;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.Controls.Add(lblTitle1);
            pnlCard1.Controls.Add(lblValue1);
            pnlCard1.Controls.Add(lblTrend1);
            pnlCard1.Controls.Add(pnlIcon1);
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.Location = new Point(5, 5);
            pnlCard1.Margin = new Padding(5);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(440, 195);
            pnlCard1.TabIndex = 0;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Segoe UI", 10F);
            lblTitle1.ForeColor = Color.Gray;
            lblTitle1.Location = new Point(25, 25);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(195, 37);
            lblTitle1.TabIndex = 0;
            lblTitle1.Text = "Bệnh nhân mới";
            // 
            // lblValue1
            // 
            lblValue1.AutoSize = true;
            lblValue1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue1.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue1.Location = new Point(20, 65);
            lblValue1.Name = "lblValue1";
            lblValue1.Size = new Size(74, 86);
            lblValue1.TabIndex = 1;
            lblValue1.Text = "0";
            // 
            // lblTrend1
            // 
            lblTrend1.AutoSize = true;
            lblTrend1.Font = new Font("Segoe UI", 9F);
            lblTrend1.Location = new Point(25, 150);
            lblTrend1.Name = "lblTrend1";
            lblTrend1.Size = new Size(0, 32);
            lblTrend1.TabIndex = 2;
            // 
            // pnlIcon1
            // 
            pnlIcon1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon1.BackColor = Color.FromArgb(242, 247, 255);
            pnlIcon1.Controls.Add(lblIcon1);
            pnlIcon1.Location = new Point(330, 35);
            pnlIcon1.Name = "pnlIcon1";
            pnlIcon1.Size = new Size(90, 90);
            pnlIcon1.TabIndex = 3;
            // 
            // lblIcon1
            // 
            lblIcon1.Dock = DockStyle.Fill;
            lblIcon1.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIcon1.ForeColor = Color.FromArgb(24, 112, 255);
            lblIcon1.Location = new Point(0, 0);
            lblIcon1.Name = "lblIcon1";
            lblIcon1.Size = new Size(90, 90);
            lblIcon1.TabIndex = 0;
            lblIcon1.Text = "";
            lblIcon1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.Controls.Add(lblTitle2);
            pnlCard2.Controls.Add(lblValue2);
            pnlCard2.Controls.Add(lblTrend2);
            pnlCard2.Controls.Add(pnlIcon2);
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.Location = new Point(455, 5);
            pnlCard2.Margin = new Padding(5);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(440, 195);
            pnlCard2.TabIndex = 1;
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Segoe UI", 10F);
            lblTitle2.ForeColor = Color.Gray;
            lblTitle2.Location = new Point(25, 25);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(136, 37);
            lblTitle2.TabIndex = 0;
            lblTitle2.Text = "Bác sĩ mới";
            // 
            // lblValue2
            // 
            lblValue2.AutoSize = true;
            lblValue2.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue2.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue2.Location = new Point(20, 65);
            lblValue2.Name = "lblValue2";
            lblValue2.Size = new Size(74, 86);
            lblValue2.TabIndex = 1;
            lblValue2.Text = "0";
            // 
            // lblTrend2
            // 
            lblTrend2.AutoSize = true;
            lblTrend2.Font = new Font("Segoe UI", 9F);
            lblTrend2.Location = new Point(25, 150);
            lblTrend2.Name = "lblTrend2";
            lblTrend2.Size = new Size(0, 32);
            lblTrend2.TabIndex = 2;
            // 
            // pnlIcon2
            // 
            pnlIcon2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon2.BackColor = Color.FromArgb(231, 255, 243);
            pnlIcon2.Controls.Add(lblIcon2);
            pnlIcon2.Location = new Point(330, 35);
            pnlIcon2.Name = "pnlIcon2";
            pnlIcon2.Size = new Size(90, 90);
            pnlIcon2.TabIndex = 3;
            // 
            // lblIcon2
            // 
            lblIcon2.Dock = DockStyle.Fill;
            lblIcon2.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIcon2.ForeColor = Color.FromArgb(40, 199, 111);
            lblIcon2.Location = new Point(0, 0);
            lblIcon2.Name = "lblIcon2";
            lblIcon2.Size = new Size(90, 90);
            lblIcon2.TabIndex = 0;
            lblIcon2.Text = "";
            lblIcon2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.Controls.Add(lblTitle3);
            pnlCard3.Controls.Add(lblValue3);
            pnlCard3.Controls.Add(lblTrend3);
            pnlCard3.Controls.Add(pnlIcon3);
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.Location = new Point(905, 5);
            pnlCard3.Margin = new Padding(5);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(440, 195);
            pnlCard3.TabIndex = 2;
            // 
            // lblTitle3
            // 
            lblTitle3.AutoSize = true;
            lblTitle3.Font = new Font("Segoe UI", 10F);
            lblTitle3.ForeColor = Color.Gray;
            lblTitle3.Location = new Point(25, 25);
            lblTitle3.Name = "lblTitle3";
            lblTitle3.Size = new Size(182, 37);
            lblTitle3.TabIndex = 0;
            lblTitle3.Text = "Lượt đánh giá";
            // 
            // lblValue3
            // 
            lblValue3.AutoSize = true;
            lblValue3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue3.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue3.Location = new Point(20, 65);
            lblValue3.Name = "lblValue3";
            lblValue3.Size = new Size(74, 86);
            lblValue3.TabIndex = 1;
            lblValue3.Text = "0";
            // 
            // lblTrend3
            // 
            lblTrend3.AutoSize = true;
            lblTrend3.Font = new Font("Segoe UI", 9F);
            lblTrend3.Location = new Point(25, 150);
            lblTrend3.Name = "lblTrend3";
            lblTrend3.Size = new Size(0, 32);
            lblTrend3.TabIndex = 2;
            // 
            // pnlIcon3
            // 
            pnlIcon3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon3.BackColor = Color.FromArgb(255, 248, 235);
            pnlIcon3.Controls.Add(lblIcon3);
            pnlIcon3.Location = new Point(330, 35);
            pnlIcon3.Name = "pnlIcon3";
            pnlIcon3.Size = new Size(90, 90);
            pnlIcon3.TabIndex = 3;
            // 
            // lblIcon3
            // 
            lblIcon3.Dock = DockStyle.Fill;
            lblIcon3.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIcon3.ForeColor = Color.FromArgb(255, 159, 67);
            lblIcon3.Location = new Point(0, 0);
            lblIcon3.Name = "lblIcon3";
            lblIcon3.Size = new Size(90, 90);
            lblIcon3.TabIndex = 0;
            lblIcon3.Text = "";
            lblIcon3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.Controls.Add(lblTitle4);
            pnlCard4.Controls.Add(lblValue4);
            pnlCard4.Controls.Add(lblTrend4);
            pnlCard4.Controls.Add(pnlIcon4);
            pnlCard4.Dock = DockStyle.Fill;
            pnlCard4.Location = new Point(1355, 5);
            pnlCard4.Margin = new Padding(5);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(440, 195);
            pnlCard4.TabIndex = 3;
            // 
            // lblTitle4
            // 
            lblTitle4.AutoSize = true;
            lblTitle4.Font = new Font("Segoe UI", 10F);
            lblTitle4.ForeColor = Color.Gray;
            lblTitle4.Location = new Point(25, 25);
            lblTitle4.Name = "lblTitle4";
            lblTitle4.Size = new Size(240, 37);
            lblTitle4.TabIndex = 0;
            lblTitle4.Text = "Lịch hẹn tháng này";
            // 
            // lblValue4
            // 
            lblValue4.AutoSize = true;
            lblValue4.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue4.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue4.Location = new Point(20, 65);
            lblValue4.Name = "lblValue4";
            lblValue4.Size = new Size(74, 86);
            lblValue4.TabIndex = 1;
            lblValue4.Text = "0";
            // 
            // lblTrend4
            // 
            lblTrend4.AutoSize = true;
            lblTrend4.Font = new Font("Segoe UI", 9F);
            lblTrend4.Location = new Point(25, 150);
            lblTrend4.Name = "lblTrend4";
            lblTrend4.Size = new Size(0, 32);
            lblTrend4.TabIndex = 2;
            // 
            // pnlIcon4
            // 
            pnlIcon4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon4.BackColor = Color.FromArgb(242, 240, 255);
            pnlIcon4.Controls.Add(lblIcon4);
            pnlIcon4.Location = new Point(330, 35);
            pnlIcon4.Name = "pnlIcon4";
            pnlIcon4.Size = new Size(90, 90);
            pnlIcon4.TabIndex = 3;
            // 
            // lblIcon4
            // 
            lblIcon4.Dock = DockStyle.Fill;
            lblIcon4.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIcon4.ForeColor = Color.FromArgb(127, 85, 240);
            lblIcon4.Location = new Point(0, 0);
            lblIcon4.Name = "lblIcon4";
            lblIcon4.Size = new Size(90, 90);
            lblIcon4.TabIndex = 0;
            lblIcon4.Text = "";
            lblIcon4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpCharts
            // 
            tlpCharts.ColumnCount = 2;
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCharts.Controls.Add(chartApp, 0, 0);
            tlpCharts.Controls.Add(chartUserGrowth, 1, 0);
            tlpCharts.Dock = DockStyle.Top;
            tlpCharts.Location = new Point(40, 295);
            tlpCharts.Name = "tlpCharts";
            tlpCharts.RowCount = 1;
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Absolute, 550F));
            tlpCharts.Size = new Size(1800, 550);
            tlpCharts.TabIndex = 1;
            // 
            // chartApp
            // 
            chartApp.BackColor = Color.White;
            chartApp.Dock = DockStyle.Fill;
            chartApp.Location = new Point(10, 10);
            chartApp.Margin = new Padding(10);
            chartApp.Name = "chartApp";
            chartApp.Padding = new Padding(30, 15, 20, 20);
            chartApp.Size = new Size(880, 530);
            chartApp.TabIndex = 0;
            chartApp.ThemeColor = Color.FromArgb(127, 85, 240);
            chartApp.Title = "Lịch hẹn theo tháng";
            // 
            // chartUserGrowth
            // 
            chartUserGrowth.BackColor = Color.White;
            chartUserGrowth.Dock = DockStyle.Fill;
            chartUserGrowth.Location = new Point(910, 10);
            chartUserGrowth.Margin = new Padding(10);
            chartUserGrowth.Mode = ucSimpleChart.ChartType.Line;
            chartUserGrowth.Name = "chartUserGrowth";
            chartUserGrowth.Padding = new Padding(30, 15, 20, 20);
            chartUserGrowth.Size = new Size(880, 530);
            chartUserGrowth.TabIndex = 1;
            chartUserGrowth.ThemeColor = Color.FromArgb(24, 112, 255);
            chartUserGrowth.Title = "Tăng trưởng người dùng";
            // 
            // tlpBottom
            // 
            tlpBottom.ColumnCount = 2;
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.27778F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.72222F));
            tlpBottom.Controls.Add(chartDept, 0, 0);
            tlpBottom.Controls.Add(pnlRecentReviews, 1, 0);
            tlpBottom.Dock = DockStyle.Fill;
            tlpBottom.Location = new Point(40, 845);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBottom.Size = new Size(1800, 365);
            tlpBottom.TabIndex = 2;
            // 
            // chartDept
            // 
            chartDept.BackColor = Color.White;
            chartDept.Dock = DockStyle.Fill;
            chartDept.Location = new Point(10, 10);
            chartDept.Margin = new Padding(10);
            chartDept.Name = "chartDept";
            chartDept.Size = new Size(777, 345);
            chartDept.TabIndex = 0;
            // 
            // pnlRecentReviews
            // 
            pnlRecentReviews.BackColor = Color.White;
            pnlRecentReviews.Controls.Add(flpRecentReviews);
            pnlRecentReviews.Controls.Add(lblRecentReviewsTitle);
            pnlRecentReviews.Dock = DockStyle.Fill;
            pnlRecentReviews.Location = new Point(807, 10);
            pnlRecentReviews.Margin = new Padding(10);
            pnlRecentReviews.Name = "pnlRecentReviews";
            pnlRecentReviews.Size = new Size(983, 345);
            pnlRecentReviews.TabIndex = 1;
            // 
            // flpRecentReviews
            // 
            flpRecentReviews.AutoScroll = true;
            flpRecentReviews.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpRecentReviews.FlowDirection = FlowDirection.TopDown;
            flpRecentReviews.Location = new Point(0, 80);
            flpRecentReviews.Margin = new Padding(0);
            flpRecentReviews.Name = "flpRecentReviews";
            // flpRecentReviews.Padding = new Padding(15, 10, 15, 10);
            flpRecentReviews.Size = new Size(983, 265);
            flpRecentReviews.TabIndex = 0;
            flpRecentReviews.WrapContents = false;
            // 
            // lblRecentReviewsTitle
            // 
            lblRecentReviewsTitle.AutoSize = true;
            lblRecentReviewsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRecentReviewsTitle.ForeColor = Color.FromArgb(17, 34, 71);
            lblRecentReviewsTitle.Location = new Point(25, 20);
            lblRecentReviewsTitle.Name = "lblRecentReviewsTitle";
            lblRecentReviewsTitle.Size = new Size(332, 51);
            lblRecentReviewsTitle.TabIndex = 1;
            lblRecentReviewsTitle.Text = "Đánh giá gần đây";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(252, 253, 255);
            pnlHeader.Controls.Add(flpHeaderInternal);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(40, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1800, 90);
            pnlHeader.TabIndex = 3;
            // 
            // flpHeaderInternal
            // 
            flpHeaderInternal.Controls.Add(lblHeaderTitle);
            flpHeaderInternal.Controls.Add(cboFilter);
            flpHeaderInternal.Dock = DockStyle.Fill;
            flpHeaderInternal.Location = new Point(0, 0);
            flpHeaderInternal.Name = "flpHeaderInternal";
            flpHeaderInternal.Padding = new Padding(30, 20, 0, 0);
            flpHeaderInternal.Size = new Size(1800, 90);
            flpHeaderInternal.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(17, 34, 71);
            lblHeaderTitle.Location = new Point(30, 20);
            lblHeaderTitle.Margin = new Padding(0, 0, 20, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(435, 59);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Thống kê tổng quan";
            // 
            // cboFilter
            // 
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.Font = new Font("Segoe UI", 14F);
            cboFilter.Location = new Point(485, 20);
            cboFilter.Margin = new Padding(0);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(350, 58);
            cboFilter.TabIndex = 100;
            // 
            // ucAdmin_Overview
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(tlpBottom);
            Controls.Add(tlpCharts);
            Controls.Add(pnlStats);
            Controls.Add(pnlHeader);
            Name = "ucAdmin_Overview";
            Padding = new Padding(40, 0, 40, 20);
            Size = new Size(1880, 1230);
            pnlStats.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlIcon1.ResumeLayout(false);
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlIcon2.ResumeLayout(false);
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlIcon3.ResumeLayout(false);
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            pnlIcon4.ResumeLayout(false);
            tlpCharts.ResumeLayout(false);
            tlpBottom.ResumeLayout(false);
            pnlRecentReviews.ResumeLayout(false);
            pnlRecentReviews.PerformLayout();
            pnlHeader.ResumeLayout(false);
            flpHeaderInternal.ResumeLayout(false);
            flpHeaderInternal.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.Label lblTrend1;
        private System.Windows.Forms.Panel pnlIcon1;
        private System.Windows.Forms.Label lblIcon1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.Label lblTrend2;
        private System.Windows.Forms.Panel pnlIcon2;
        private System.Windows.Forms.Label lblIcon2;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.Label lblTrend3;
        private System.Windows.Forms.Panel pnlIcon3;
        private System.Windows.Forms.Label lblIcon3;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblTitle4;
        private System.Windows.Forms.Label lblValue4;
        private System.Windows.Forms.Label lblTrend4;
        private System.Windows.Forms.Panel pnlIcon4;
        private System.Windows.Forms.Label lblIcon4;
        private System.Windows.Forms.TableLayoutPanel tlpCharts;
        private ucSimpleChart chartApp;
        private ucSimpleChart chartUserGrowth;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private ucPieChart chartDept;
        private System.Windows.Forms.Panel pnlRecentReviews;
        private System.Windows.Forms.FlowLayoutPanel flpRecentReviews;
        private System.Windows.Forms.Label lblRecentReviewsTitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.FlowLayoutPanel flpHeaderInternal;
    }
}
