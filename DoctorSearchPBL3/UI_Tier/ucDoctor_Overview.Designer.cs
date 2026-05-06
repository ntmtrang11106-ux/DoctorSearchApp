namespace UI_Tier
{
    partial class ucDoctor_Overview
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
            pnlHeader = new Panel();
            lblDept = new Label();
            lblWelcome = new Label();
            pnlStats = new FlowLayoutPanel();
            pnlTodayApp = new Panel();
            lblIconTodayApp = new Label();
            lblTodayAppCount = new Label();
            lblTodayAppTitle = new Label();
            pnlTotalPatients = new Panel();
            lblIconTotalPatients = new Label();
            lblTotalPatientsCount = new Label();
            lblTotalPatientsTitle = new Label();
            pnlPending = new Panel();
            lblIconPending = new Label();
            lblPendingCount = new Label();
            lblPendingTitle = new Label();
            pnlRating = new Panel();
            lblIconRating = new Label();
            lblAvgRating = new Label();
            lblRatingTitle = new Label();
            tlpMain = new TableLayoutPanel();
            pnlReviews = new Panel();
            flpRecentReviews = new FlowLayoutPanel();
            lblRecentReviewsTitle = new Label();
            pnlAppointments = new Panel();
            flpTodayApp = new FlowLayoutPanel();
            lblTodayDate = new Label();
            lblTodayTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlStats.SuspendLayout();
            pnlTodayApp.SuspendLayout();
            pnlTotalPatients.SuspendLayout();
            pnlPending.SuspendLayout();
            pnlRating.SuspendLayout();
            tlpMain.SuspendLayout();
            pnlReviews.SuspendLayout();
            pnlAppointments.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblDept);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(40, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1939, 160);
            pnlHeader.TabIndex = 0;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Font = new Font("Segoe UI", 11F);
            lblDept.ForeColor = Color.Gray;
            lblDept.Location = new Point(3, 86);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(305, 41);
            lblDept.TabIndex = 1;
            lblDept.Text = "Chuyên khoa: Nội tiết";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(17, 34, 71);
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(1592, 86);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng. Bác sĩ chuyên khoa BS. Nguyễn Văn An";
            // 
            // pnlStats
            // 
            pnlStats.Controls.Add(pnlTodayApp);
            pnlStats.Controls.Add(pnlTotalPatients);
            pnlStats.Controls.Add(pnlPending);
            pnlStats.Controls.Add(pnlRating);
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(40, 180);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(1939, 210);
            pnlStats.TabIndex = 1;
            // 
            // pnlTodayApp
            // 
            pnlTodayApp.BackColor = Color.White;
            pnlTodayApp.Controls.Add(lblIconTodayApp);
            pnlTodayApp.Controls.Add(lblTodayAppCount);
            pnlTodayApp.Controls.Add(lblTodayAppTitle);
            pnlTodayApp.Location = new Point(3, 3);
            pnlTodayApp.Name = "pnlTodayApp";
            pnlTodayApp.Size = new Size(460, 180);
            pnlTodayApp.TabIndex = 0;
            // 
            // lblIconTodayApp
            // 
            lblIconTodayApp.BackColor = Color.FromArgb(242, 247, 255);
            lblIconTodayApp.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIconTodayApp.ForeColor = Color.FromArgb(24, 112, 255);
            lblIconTodayApp.Location = new Point(340, 45);
            lblIconTodayApp.Name = "lblIconTodayApp";
            lblIconTodayApp.Size = new Size(90, 90);
            lblIconTodayApp.TabIndex = 2;
            lblIconTodayApp.Text = "";
            lblIconTodayApp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTodayAppCount
            // 
            lblTodayAppCount.AutoSize = true;
            lblTodayAppCount.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTodayAppCount.ForeColor = Color.FromArgb(17, 34, 71);
            lblTodayAppCount.Location = new Point(25, 65);
            lblTodayAppCount.Name = "lblTodayAppCount";
            lblTodayAppCount.Size = new Size(97, 114);
            lblTodayAppCount.TabIndex = 1;
            lblTodayAppCount.Text = "8";
            // 
            // lblTodayAppTitle
            // 
            lblTodayAppTitle.AutoSize = true;
            lblTodayAppTitle.Font = new Font("Segoe UI", 10F);
            lblTodayAppTitle.ForeColor = Color.Gray;
            lblTodayAppTitle.Location = new Point(30, 30);
            lblTodayAppTitle.Name = "lblTodayAppTitle";
            lblTodayAppTitle.Size = new Size(225, 37);
            lblTodayAppTitle.TabIndex = 0;
            lblTodayAppTitle.Text = "Lịch hẹn hôm nay";
            // 
            // pnlTotalPatients
            // 
            pnlTotalPatients.BackColor = Color.White;
            pnlTotalPatients.Controls.Add(lblIconTotalPatients);
            pnlTotalPatients.Controls.Add(lblTotalPatientsCount);
            pnlTotalPatients.Controls.Add(lblTotalPatientsTitle);
            pnlTotalPatients.Location = new Point(469, 3);
            pnlTotalPatients.Name = "pnlTotalPatients";
            pnlTotalPatients.Size = new Size(460, 180);
            pnlTotalPatients.TabIndex = 1;
            // 
            // lblIconTotalPatients
            // 
            lblIconTotalPatients.BackColor = Color.FromArgb(235, 252, 245);
            lblIconTotalPatients.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIconTotalPatients.ForeColor = Color.FromArgb(40, 199, 111);
            lblIconTotalPatients.Location = new Point(340, 45);
            lblIconTotalPatients.Name = "lblIconTotalPatients";
            lblIconTotalPatients.Size = new Size(90, 90);
            lblIconTotalPatients.TabIndex = 2;
            lblIconTotalPatients.Text = "";
            lblIconTotalPatients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalPatientsCount
            // 
            lblTotalPatientsCount.AutoSize = true;
            lblTotalPatientsCount.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalPatientsCount.ForeColor = Color.FromArgb(17, 34, 71);
            lblTotalPatientsCount.Location = new Point(25, 65);
            lblTotalPatientsCount.Name = "lblTotalPatientsCount";
            lblTotalPatientsCount.Size = new Size(195, 114);
            lblTotalPatientsCount.TabIndex = 1;
            lblTotalPatientsCount.Text = "247";
            // 
            // lblTotalPatientsTitle
            // 
            lblTotalPatientsTitle.AutoSize = true;
            lblTotalPatientsTitle.Font = new Font("Segoe UI", 10F);
            lblTotalPatientsTitle.ForeColor = Color.Gray;
            lblTotalPatientsTitle.Location = new Point(30, 30);
            lblTotalPatientsTitle.Name = "lblTotalPatientsTitle";
            lblTotalPatientsTitle.Size = new Size(211, 37);
            lblTotalPatientsTitle.TabIndex = 0;
            lblTotalPatientsTitle.Text = "Tổng bệnh nhân";
            // 
            // pnlPending
            // 
            pnlPending.BackColor = Color.White;
            pnlPending.Controls.Add(lblIconPending);
            pnlPending.Controls.Add(lblPendingCount);
            pnlPending.Controls.Add(lblPendingTitle);
            pnlPending.Location = new Point(935, 3);
            pnlPending.Name = "pnlPending";
            pnlPending.Size = new Size(460, 180);
            pnlPending.TabIndex = 2;
            // 
            // lblIconPending
            // 
            lblIconPending.BackColor = Color.FromArgb(255, 248, 235);
            lblIconPending.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIconPending.ForeColor = Color.FromArgb(255, 159, 67);
            lblIconPending.Location = new Point(340, 45);
            lblIconPending.Name = "lblIconPending";
            lblIconPending.Size = new Size(90, 90);
            lblIconPending.TabIndex = 2;
            lblIconPending.Text = "";
            lblIconPending.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPendingCount
            // 
            lblPendingCount.AutoSize = true;
            lblPendingCount.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblPendingCount.ForeColor = Color.FromArgb(17, 34, 71);
            lblPendingCount.Location = new Point(25, 65);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(97, 114);
            lblPendingCount.TabIndex = 1;
            lblPendingCount.Text = "3";
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Segoe UI", 10F);
            lblPendingTitle.ForeColor = Color.Gray;
            lblPendingTitle.Location = new Point(30, 30);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(176, 37);
            lblPendingTitle.TabIndex = 0;
            lblPendingTitle.Text = "Chờ xác nhận";
            // 
            // pnlRating
            // 
            pnlRating.BackColor = Color.White;
            pnlRating.Controls.Add(lblIconRating);
            pnlRating.Controls.Add(lblAvgRating);
            pnlRating.Controls.Add(lblRatingTitle);
            pnlRating.Location = new Point(1401, 3);
            pnlRating.Name = "pnlRating";
            pnlRating.Size = new Size(460, 180);
            pnlRating.TabIndex = 3;
            // 
            // lblIconRating
            // 
            lblIconRating.BackColor = Color.FromArgb(255, 253, 235);
            lblIconRating.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIconRating.ForeColor = Color.FromArgb(255, 199, 0);
            lblIconRating.Location = new Point(340, 45);
            lblIconRating.Name = "lblIconRating";
            lblIconRating.Size = new Size(90, 90);
            lblIconRating.TabIndex = 2;
            lblIconRating.Text = "";
            lblIconRating.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvgRating
            // 
            lblAvgRating.AutoSize = true;
            lblAvgRating.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblAvgRating.ForeColor = Color.FromArgb(17, 34, 71);
            lblAvgRating.Location = new Point(25, 65);
            lblAvgRating.Name = "lblAvgRating";
            lblAvgRating.Size = new Size(169, 114);
            lblAvgRating.TabIndex = 1;
            lblAvgRating.Text = "4.8";
            // 
            // lblRatingTitle
            // 
            lblRatingTitle.AutoSize = true;
            lblRatingTitle.Font = new Font("Segoe UI", 10F);
            lblRatingTitle.ForeColor = Color.Gray;
            lblRatingTitle.Location = new Point(30, 30);
            lblRatingTitle.Name = "lblRatingTitle";
            lblRatingTitle.Size = new Size(160, 37);
            lblRatingTitle.TabIndex = 0;
            lblRatingTitle.Text = "Đánh giá TB";
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.Controls.Add(pnlReviews, 0, 0);
            tlpMain.Controls.Add(pnlAppointments, 1, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(40, 390);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1939, 961);
            tlpMain.TabIndex = 2;
            // 
            // pnlReviews
            // 
            pnlReviews.BackColor = Color.White;
            pnlReviews.Controls.Add(flpRecentReviews);
            pnlReviews.Controls.Add(lblRecentReviewsTitle);
            pnlReviews.Dock = DockStyle.Fill;
            pnlReviews.Location = new Point(0, 20);
            pnlReviews.Margin = new Padding(0, 20, 0, 0);
            pnlReviews.Name = "pnlReviews";
            pnlReviews.Size = new Size(969, 941);
            pnlReviews.TabIndex = 1;
            // 
            // flpRecentReviews
            // 
            flpRecentReviews.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpRecentReviews.AutoScroll = true;
            flpRecentReviews.Location = new Point(20, 100);
            flpRecentReviews.Name = "flpRecentReviews";
            flpRecentReviews.Size = new Size(929, 811);
            flpRecentReviews.TabIndex = 2;
            // 
            // lblRecentReviewsTitle
            // 
            lblRecentReviewsTitle.AutoSize = true;
            lblRecentReviewsTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblRecentReviewsTitle.ForeColor = Color.FromArgb(17, 34, 71);
            lblRecentReviewsTitle.Location = new Point(30, 25);
            lblRecentReviewsTitle.Name = "lblRecentReviewsTitle";
            lblRecentReviewsTitle.Size = new Size(423, 65);
            lblRecentReviewsTitle.TabIndex = 0;
            lblRecentReviewsTitle.Text = "Đánh giá gần đây";
            // 
            // pnlAppointments
            // 
            pnlAppointments.BackColor = Color.White;
            pnlAppointments.Controls.Add(flpTodayApp);
            pnlAppointments.Controls.Add(lblTodayDate);
            pnlAppointments.Controls.Add(lblTodayTitle);
            pnlAppointments.Dock = DockStyle.Fill;
            pnlAppointments.Location = new Point(969, 20);
            pnlAppointments.Margin = new Padding(0, 20, 0, 0);
            pnlAppointments.Name = "pnlAppointments";
            pnlAppointments.Size = new Size(970, 941);
            pnlAppointments.TabIndex = 0;
            // 
            // flpTodayApp
            // 
            flpTodayApp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpTodayApp.AutoScroll = true;
            flpTodayApp.Location = new Point(30, 100);
            flpTodayApp.Name = "flpTodayApp";
            flpTodayApp.Size = new Size(910, 811);
            flpTodayApp.TabIndex = 2;
            // 
            // lblTodayDate
            // 
            lblTodayDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTodayDate.AutoSize = true;
            lblTodayDate.Font = new Font("Segoe UI", 10F);
            lblTodayDate.ForeColor = Color.Gray;
            lblTodayDate.Location = new Point(701, 35);
            lblTodayDate.Name = "lblTodayDate";
            lblTodayDate.Size = new Size(239, 37);
            lblTodayDate.TabIndex = 1;
            lblTodayDate.Text = "Thứ 6, 17/04/2026";
            // 
            // lblTodayTitle
            // 
            lblTodayTitle.AutoSize = true;
            lblTodayTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTodayTitle.ForeColor = Color.FromArgb(17, 34, 71);
            lblTodayTitle.Location = new Point(30, 25);
            lblTodayTitle.Name = "lblTodayTitle";
            lblTodayTitle.Size = new Size(425, 65);
            lblTodayTitle.TabIndex = 0;
            lblTodayTitle.Text = "Lịch hẹn hôm nay";
            // 
            // ucDoctor_Overview
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 252, 255);
            Controls.Add(tlpMain);
            Controls.Add(pnlStats);
            Controls.Add(pnlHeader);
            Name = "ucDoctor_Overview";
            Padding = new Padding(40, 20, 40, 20);
            Size = new Size(2019, 1371);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlStats.ResumeLayout(false);
            pnlTodayApp.ResumeLayout(false);
            pnlTodayApp.PerformLayout();
            pnlTotalPatients.ResumeLayout(false);
            pnlTotalPatients.PerformLayout();
            pnlPending.ResumeLayout(false);
            pnlPending.PerformLayout();
            pnlRating.ResumeLayout(false);
            pnlRating.PerformLayout();
            tlpMain.ResumeLayout(false);
            pnlReviews.ResumeLayout(false);
            pnlReviews.PerformLayout();
            pnlAppointments.ResumeLayout(false);
            pnlAppointments.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblDept;
        private Label lblWelcome;
        private FlowLayoutPanel pnlStats;
        private Panel pnlTodayApp;
        private Label lblIconTodayApp;
        private Label lblTodayAppCount;
        private Label lblTodayAppTitle;
        private Panel pnlTotalPatients;
        private Label lblIconTotalPatients;
        private Label lblTotalPatientsCount;
        private Label lblTotalPatientsTitle;
        private Panel pnlPending;
        private Label lblIconPending;
        private Label lblPendingCount;
        private Label lblPendingTitle;
        private Panel pnlRating;
        private Label lblIconRating;
        private Label lblAvgRating;
        private Label lblRatingTitle;
        private TableLayoutPanel tlpMain;
        private Panel pnlAppointments;
        private FlowLayoutPanel flpTodayApp;
        private Label lblTodayDate;
        private Label lblTodayTitle;
        private Panel pnlReviews;
        private FlowLayoutPanel flpRecentReviews;
        private Label lblRecentReviewsTitle;
    }
}
