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
            tlpMain = new TableLayoutPanel();
            pnlReviews = new Panel();
            pnlReviewPagination = new Panel();
            lblReviewPageStatus = new Label();
            lblReviewPrev = new Label();
            lblReviewNext = new Label();
            flpRecentReviews = new FlowLayoutPanel();
            lblNoReviews = new Label();
            lblRecentReviewsTitle = new Label();
            pnlAppointments = new Panel();
            pnlAppPagination = new Panel();
            lblAppPageStatus = new Label();
            lblAppPrev = new Label();
            lblAppNext = new Label();
            flpTodayApp = new FlowLayoutPanel();
            lblNoApp = new Label();
            lblTodayDate = new Label();
            lblTodayTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlCard1 = new Panel();
            label1 = new Label();
            lblTitle1 = new Label();
            lblValue1 = new Label();
            lblTrend1 = new Label();
            pnlCard2 = new Panel();
            label2 = new Label();
            lblTitle2 = new Label();
            lblValue2 = new Label();
            lblTrend2 = new Label();
            pnlCard3 = new Panel();
            label3 = new Label();
            lblTitle3 = new Label();
            lblValue3 = new Label();
            lblTrend3 = new Label();
            pnlCard4 = new Panel();
            label4 = new Label();
            lblTitle4 = new Label();
            lblValue4 = new Label();
            lblTrend4 = new Label();
            pnlIcon1 = new Panel();
            lblIcon1 = new Label();
            pnlIcon2 = new Panel();
            lblIcon2 = new Label();
            pnlIcon3 = new Panel();
            lblIcon3 = new Label();
            pnlIcon4 = new Panel();
            lblIcon4 = new Label();
            label5 = new Label();
            pnlHeader.SuspendLayout();
            tlpMain.SuspendLayout();
            pnlReviews.SuspendLayout();
            pnlReviewPagination.SuspendLayout();
            pnlAppointments.SuspendLayout();
            pnlAppPagination.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlIcon1.SuspendLayout();
            pnlIcon2.SuspendLayout();
            pnlIcon3.SuspendLayout();
            pnlIcon4.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblDept);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(50, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1919, 120);
            pnlHeader.TabIndex = 0;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDept.ForeColor = Color.Gray;
            lblDept.Location = new Point(3, 71);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(327, 45);
            lblDept.TabIndex = 1;
            lblDept.Text = "Chuyên khoa: Nội tiết";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(17, 34, 71);
            lblWelcome.Location = new Point(3, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(1317, 71);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng. Bác sĩ chuyên khoa BS. Nguyễn Văn An";
            // 
            // tlpMain
            // 
            tlpMain.BackColor = Color.White;
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.Controls.Add(pnlReviews, 0, 0);
            tlpMain.Controls.Add(pnlAppointments, 1, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(50, 375);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1919, 986);
            tlpMain.TabIndex = 2;
            // 
            // pnlReviews
            // 
            pnlReviews.BackColor = Color.White;
            pnlReviews.Controls.Add(lblNoReviews);
            pnlReviews.Controls.Add(pnlReviewPagination);
            pnlReviews.Controls.Add(flpRecentReviews);
            pnlReviews.Controls.Add(lblRecentReviewsTitle);
            pnlReviews.Dock = DockStyle.Fill;
            pnlReviews.Location = new Point(0, 15);
            pnlReviews.Margin = new Padding(0, 15, 7, 0);
            pnlReviews.Name = "pnlReviews";
            pnlReviews.Size = new Size(952, 971);
            pnlReviews.TabIndex = 1;
            // 
            // pnlReviewPagination
            // 
            pnlReviewPagination.BackColor = Color.FromArgb(242, 246, 250);
            pnlReviewPagination.Controls.Add(lblReviewPageStatus);
            pnlReviewPagination.Controls.Add(lblReviewPrev);
            pnlReviewPagination.Controls.Add(lblReviewNext);
            pnlReviewPagination.Dock = DockStyle.Top;
            pnlReviewPagination.Location = new Point(0, 116);
            pnlReviewPagination.Name = "pnlReviewPagination";
            pnlReviewPagination.Size = new Size(952, 80);
            pnlReviewPagination.TabIndex = 3;
            // 
            // lblReviewPageStatus
            // 
            lblReviewPageStatus.Anchor = AnchorStyles.Top;
            lblReviewPageStatus.AutoSize = true;
            lblReviewPageStatus.Font = new Font("Segoe UI", 10.5F);
            lblReviewPageStatus.Location = new Point(402, 20);
            lblReviewPageStatus.Name = "lblReviewPageStatus";
            lblReviewPageStatus.Size = new Size(151, 38);
            lblReviewPageStatus.TabIndex = 2;
            lblReviewPageStatus.Text = "Trang 1 / 1";
            // 
            // lblReviewPrev
            // 
            lblReviewPrev.AutoSize = true;
            lblReviewPrev.Cursor = Cursors.Hand;
            lblReviewPrev.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblReviewPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblReviewPrev.Location = new Point(30, 20);
            lblReviewPrev.Name = "lblReviewPrev";
            lblReviewPrev.Size = new Size(219, 38);
            lblReviewPrev.TabIndex = 1;
            lblReviewPrev.Text = "<< Trang trước";
            // 
            // lblReviewNext
            // 
            lblReviewNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblReviewNext.AutoSize = true;
            lblReviewNext.Cursor = Cursors.Hand;
            lblReviewNext.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblReviewNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblReviewNext.Location = new Point(710, 20);
            lblReviewNext.Name = "lblReviewNext";
            lblReviewNext.Size = new Size(191, 38);
            lblReviewNext.TabIndex = 0;
            lblReviewNext.Text = "Trang sau >>";
            // 
            // flpRecentReviews
            // 
            flpRecentReviews.AutoSize = true;
            flpRecentReviews.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpRecentReviews.Dock = DockStyle.Top;
            flpRecentReviews.FlowDirection = FlowDirection.TopDown;
            flpRecentReviews.Location = new Point(0, 116);
            flpRecentReviews.Margin = new Padding(0);
            flpRecentReviews.Name = "flpRecentReviews";
            flpRecentReviews.Size = new Size(952, 0);
            flpRecentReviews.TabIndex = 1;
            flpRecentReviews.WrapContents = false;
            // 
            // lblNoReviews
            // 
            lblNoReviews.Font = new Font("Segoe UI", 11F);
            lblNoReviews.ForeColor = Color.Gray;
            lblNoReviews.Location = new Point(0, 199);
            lblNoReviews.Margin = new Padding(0);
            lblNoReviews.Name = "lblNoReviews";
            lblNoReviews.Padding = new Padding(0, 30, 0, 0);
            lblNoReviews.Size = new Size(952, 93);
            lblNoReviews.TabIndex = 6;
            lblNoReviews.Text = "Không có đánh giá nào gần đây";
            lblNoReviews.TextAlign = ContentAlignment.TopCenter;
            lblNoReviews.Visible = false;
            // 
            // lblRecentReviewsTitle
            // 
            lblRecentReviewsTitle.Dock = DockStyle.Top;
            lblRecentReviewsTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblRecentReviewsTitle.ForeColor = Color.FromArgb(17, 34, 71);
            lblRecentReviewsTitle.Location = new Point(0, 0);
            lblRecentReviewsTitle.Name = "lblRecentReviewsTitle";
            lblRecentReviewsTitle.Padding = new Padding(30, 20, 0, 10);
            lblRecentReviewsTitle.Size = new Size(952, 116);
            lblRecentReviewsTitle.TabIndex = 0;
            lblRecentReviewsTitle.Text = "Đánh giá gần đây";
            // 
            // pnlAppointments
            // 
            pnlAppointments.BackColor = Color.White;
            pnlAppointments.Controls.Add(label5);
            pnlAppointments.Controls.Add(pnlAppPagination);
            pnlAppointments.Controls.Add(flpTodayApp);
            pnlAppointments.Controls.Add(lblTodayDate);
            pnlAppointments.Controls.Add(lblTodayTitle);
            pnlAppointments.Controls.Add(lblNoApp);
            pnlAppointments.Dock = DockStyle.Fill;
            pnlAppointments.Location = new Point(966, 15);
            pnlAppointments.Margin = new Padding(7, 15, 0, 0);
            pnlAppointments.Name = "pnlAppointments";
            pnlAppointments.Size = new Size(953, 971);
            pnlAppointments.TabIndex = 0;
            // 
            // pnlAppPagination
            // 
            pnlAppPagination.BackColor = Color.FromArgb(242, 246, 250);
            pnlAppPagination.Controls.Add(lblAppPageStatus);
            pnlAppPagination.Controls.Add(lblAppPrev);
            pnlAppPagination.Controls.Add(lblAppNext);
            pnlAppPagination.Dock = DockStyle.Top;
            pnlAppPagination.Location = new Point(0, 116);
            pnlAppPagination.Name = "pnlAppPagination";
            pnlAppPagination.Size = new Size(953, 80);
            pnlAppPagination.TabIndex = 3;
            // 
            // lblAppPageStatus
            // 
            lblAppPageStatus.Anchor = AnchorStyles.Top;
            lblAppPageStatus.AutoSize = true;
            lblAppPageStatus.Font = new Font("Segoe UI", 10.5F);
            lblAppPageStatus.Location = new Point(401, 20);
            lblAppPageStatus.Name = "lblAppPageStatus";
            lblAppPageStatus.Size = new Size(151, 38);
            lblAppPageStatus.TabIndex = 2;
            lblAppPageStatus.Text = "Trang 1 / 1";
            // 
            // lblAppPrev
            // 
            lblAppPrev.AutoSize = true;
            lblAppPrev.Cursor = Cursors.Hand;
            lblAppPrev.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblAppPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblAppPrev.Location = new Point(30, 20);
            lblAppPrev.Name = "lblAppPrev";
            lblAppPrev.Size = new Size(219, 38);
            lblAppPrev.TabIndex = 1;
            lblAppPrev.Text = "<< Trang trước";
            // 
            // lblAppNext
            // 
            lblAppNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAppNext.AutoSize = true;
            lblAppNext.Cursor = Cursors.Hand;
            lblAppNext.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblAppNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblAppNext.Location = new Point(711, 20);
            lblAppNext.Name = "lblAppNext";
            lblAppNext.Size = new Size(191, 38);
            lblAppNext.TabIndex = 0;
            lblAppNext.Text = "Trang sau >>";
            // 
            // flpTodayApp
            // 
            flpTodayApp.AutoSize = true;
            flpTodayApp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpTodayApp.Dock = DockStyle.Top;
            flpTodayApp.FlowDirection = FlowDirection.TopDown;
            flpTodayApp.Location = new Point(0, 116);
            flpTodayApp.Name = "flpTodayApp";
            flpTodayApp.Size = new Size(953, 0);
            flpTodayApp.TabIndex = 2;
            flpTodayApp.WrapContents = false;
            // 
            // lblNoApp
            // 
            lblNoApp.Font = new Font("Segoe UI", 11F);
            lblNoApp.ForeColor = Color.Gray;
            lblNoApp.Location = new Point(0, 0);
            lblNoApp.Margin = new Padding(0);
            lblNoApp.Name = "lblNoApp";
            lblNoApp.Padding = new Padding(0, 30, 0, 0);
            lblNoApp.Size = new Size(953, 100);
            lblNoApp.TabIndex = 6;
            lblNoApp.Text = "Không có lịch hẹn nào hôm nay";
            lblNoApp.TextAlign = ContentAlignment.TopCenter;
            lblNoApp.Visible = false;
            // 
            // lblTodayDate
            // 
            lblTodayDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTodayDate.AutoSize = true;
            lblTodayDate.Font = new Font("Segoe UI", 12F);
            lblTodayDate.ForeColor = Color.Gray;
            lblTodayDate.Location = new Point(634, 25);
            lblTodayDate.Name = "lblTodayDate";
            lblTodayDate.Size = new Size(276, 45);
            lblTodayDate.TabIndex = 1;
            lblTodayDate.Text = "Thứ 6, 17/04/2026";
            // 
            // lblTodayTitle
            // 
            lblTodayTitle.Dock = DockStyle.Top;
            lblTodayTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTodayTitle.ForeColor = Color.FromArgb(17, 34, 71);
            lblTodayTitle.Location = new Point(0, 0);
            lblTodayTitle.Name = "lblTodayTitle";
            lblTodayTitle.Padding = new Padding(30, 20, 0, 10);
            lblTodayTitle.Size = new Size(953, 116);
            lblTodayTitle.TabIndex = 0;
            lblTodayTitle.Text = "Lịch hẹn hôm nay";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(pnlCard1, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlCard2, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlCard3, 2, 0);
            tableLayoutPanel1.Controls.Add(pnlCard4, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(50, 130);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1919, 245);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.Controls.Add(label1);
            pnlCard1.Controls.Add(lblTitle1);
            pnlCard1.Controls.Add(lblValue1);
            pnlCard1.Controls.Add(lblTrend1);
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.Location = new Point(5, 5);
            pnlCard1.Margin = new Padding(5);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(469, 235);
            pnlCard1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.BackColor = Color.FromArgb(242, 247, 255);
            label1.Font = new Font("Segoe MDL2 Assets", 22F);
            label1.ForeColor = Color.FromArgb(24, 112, 255);
            label1.Location = new Point(309, 35);
            label1.Name = "label1";
            label1.Padding = new Padding(5);
            label1.Size = new Size(90, 90);
            label1.TabIndex = 4;
            label1.Text = "";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Segoe UI", 12F);
            lblTitle1.ForeColor = Color.Gray;
            lblTitle1.Location = new Point(25, 25);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(279, 45);
            lblTitle1.TabIndex = 0;
            lblTitle1.Text = "Lịch hẹn hôm nay ";
            // 
            // lblValue1
            // 
            lblValue1.AutoSize = true;
            lblValue1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblValue1.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue1.Location = new Point(25, 103);
            lblValue1.Name = "lblValue1";
            lblValue1.Size = new Size(91, 106);
            lblValue1.TabIndex = 1;
            lblValue1.Text = "8";
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
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.Controls.Add(label2);
            pnlCard2.Controls.Add(lblTitle2);
            pnlCard2.Controls.Add(lblValue2);
            pnlCard2.Controls.Add(lblTrend2);
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.Location = new Point(484, 5);
            pnlCard2.Margin = new Padding(5);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(469, 235);
            pnlCard2.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.BackColor = Color.FromArgb(235, 252, 245);
            label2.Font = new Font("Segoe MDL2 Assets", 22F);
            label2.ForeColor = Color.FromArgb(40, 199, 111);
            label2.Location = new Point(309, 35);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(90, 90);
            label2.TabIndex = 4;
            label2.Text = "";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Segoe UI", 12F);
            lblTitle2.ForeColor = Color.Gray;
            lblTitle2.Location = new Point(25, 25);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(253, 45);
            lblTitle2.TabIndex = 0;
            lblTitle2.Text = "Tổng bệnh nhân";
            // 
            // lblValue2
            // 
            lblValue2.AutoSize = true;
            lblValue2.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblValue2.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue2.Location = new Point(25, 103);
            lblValue2.Name = "lblValue2";
            lblValue2.Size = new Size(183, 106);
            lblValue2.TabIndex = 1;
            lblValue2.Text = "247";
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
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.Controls.Add(label3);
            pnlCard3.Controls.Add(lblTitle3);
            pnlCard3.Controls.Add(lblValue3);
            pnlCard3.Controls.Add(lblTrend3);
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.Location = new Point(963, 5);
            pnlCard3.Margin = new Padding(5);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(469, 235);
            pnlCard3.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.BackColor = Color.FromArgb(255, 248, 235);
            label3.Font = new Font("Segoe MDL2 Assets", 22F);
            label3.ForeColor = Color.FromArgb(255, 159, 67);
            label3.Location = new Point(309, 35);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(90, 90);
            label3.TabIndex = 4;
            label3.Text = "";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle3
            // 
            lblTitle3.AutoSize = true;
            lblTitle3.Font = new Font("Segoe UI", 12F);
            lblTitle3.ForeColor = Color.Gray;
            lblTitle3.Location = new Point(25, 25);
            lblTitle3.Name = "lblTitle3";
            lblTitle3.Size = new Size(211, 45);
            lblTitle3.TabIndex = 0;
            lblTitle3.Text = "Chờ xác nhận";
            // 
            // lblValue3
            // 
            lblValue3.AutoSize = true;
            lblValue3.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblValue3.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue3.Location = new Point(25, 103);
            lblValue3.Name = "lblValue3";
            lblValue3.Size = new Size(91, 106);
            lblValue3.TabIndex = 3;
            lblValue3.Tag = "0";
            lblValue3.Text = "3";
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
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.Controls.Add(label4);
            pnlCard4.Controls.Add(lblTitle4);
            pnlCard4.Controls.Add(lblValue4);
            pnlCard4.Controls.Add(lblTrend4);
            pnlCard4.Dock = DockStyle.Fill;
            pnlCard4.Location = new Point(1442, 5);
            pnlCard4.Margin = new Padding(5);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(472, 235);
            pnlCard4.TabIndex = 3;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.BackColor = Color.FromArgb(255, 253, 235);
            label4.Font = new Font("Segoe MDL2 Assets", 22F);
            label4.ForeColor = Color.FromArgb(255, 199, 0);
            label4.Location = new Point(312, 35);
            label4.Name = "label4";
            label4.Padding = new Padding(5);
            label4.Size = new Size(90, 90);
            label4.TabIndex = 4;
            label4.Text = "";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle4
            // 
            lblTitle4.AutoSize = true;
            lblTitle4.Font = new Font("Segoe UI", 12F);
            lblTitle4.ForeColor = Color.Gray;
            lblTitle4.Location = new Point(25, 25);
            lblTitle4.Name = "lblTitle4";
            lblTitle4.Size = new Size(190, 45);
            lblTitle4.TabIndex = 0;
            lblTitle4.Text = "Đánh giá TB";
            // 
            // lblValue4
            // 
            lblValue4.AutoSize = true;
            lblValue4.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblValue4.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue4.Location = new Point(25, 103);
            lblValue4.Name = "lblValue4";
            lblValue4.Size = new Size(159, 106);
            lblValue4.TabIndex = 1;
            lblValue4.Text = "4.8";
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
            // pnlIcon1
            // 
            pnlIcon1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon1.BackColor = Color.FromArgb(242, 247, 255);
            pnlIcon1.Controls.Add(lblIcon1);
            pnlIcon1.Location = new Point(619, 35);
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
            // pnlIcon2
            // 
            pnlIcon2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon2.BackColor = Color.FromArgb(231, 255, 243);
            pnlIcon2.Controls.Add(lblIcon2);
            pnlIcon2.Location = new Point(619, 35);
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
            // pnlIcon3
            // 
            pnlIcon3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon3.BackColor = Color.FromArgb(255, 248, 235);
            pnlIcon3.Controls.Add(lblIcon3);
            pnlIcon3.Location = new Point(619, 35);
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
            // pnlIcon4
            // 
            pnlIcon4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon4.BackColor = Color.FromArgb(242, 240, 255);
            pnlIcon4.Controls.Add(lblIcon4);
            pnlIcon4.Location = new Point(622, 35);
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
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI", 11F);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(0, 196);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 30, 0, 0);
            label5.Size = new Size(953, 93);
            label5.TabIndex = 7;
            label5.Text = "Không có lịch hẹn nào hôm nay";
            label5.TextAlign = ContentAlignment.TopCenter;
            label5.Visible = false;
            // 
            // ucDoctor_Overview
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tlpMain);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlHeader);
            Name = "ucDoctor_Overview";
            Padding = new Padding(50, 10, 50, 10);
            Size = new Size(2019, 1371);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMain.ResumeLayout(false);
            pnlReviews.ResumeLayout(false);
            pnlReviews.PerformLayout();
            pnlReviewPagination.ResumeLayout(false);
            pnlReviewPagination.PerformLayout();
            pnlAppointments.ResumeLayout(false);
            pnlAppointments.PerformLayout();
            pnlAppPagination.ResumeLayout(false);
            pnlAppPagination.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            pnlIcon1.ResumeLayout(false);
            pnlIcon2.ResumeLayout(false);
            pnlIcon3.ResumeLayout(false);
            pnlIcon4.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblDept;
        private Label lblWelcome;
        private Panel pnlStats;
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
        private TableLayoutPanel tlpStats;
        private TableLayoutPanel tlpMain;
        private Panel pnlAppointments;
        private FlowLayoutPanel flpTodayApp;
        private Label lblTodayDate;
        private Label lblTodayTitle;
        private Panel pnlReviews;
        private Label lblRecentReviewsTitle;
        private Panel pnlReviewPagination;
        private Label lblReviewPageStatus;
        private Label lblReviewPrev;
        private Label lblReviewNext;
        private Panel pnlAppPagination;
        private Label lblAppPageStatus;
        private Label lblAppPrev;
        private Label lblAppNext;
        private Label lblNoReviews;
        private Label lblNoApp;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlCard1;
        private Label lblTitle1;
        private Label lblValue1;
        private Label lblTrend1;
        private Panel pnlIcon1;
        private Label lblIcon1;
        private Panel pnlCard2;
        private Label lblTitle2;
        private Label lblValue2;
        private Label lblTrend2;
        private Panel pnlIcon2;
        private Label lblIcon2;
        private Panel pnlCard3;
        private Label lblTitle3;
        private Label lblValue3;
        private Label lblTrend3;
        private Panel pnlIcon3;
        private Label lblIcon3;
        private Panel pnlCard4;
        private Label lblTitle4;
        private Label lblValue4;
        private Label lblTrend4;
        private Panel pnlIcon4;
        private Label lblIcon4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private FlowLayoutPanel flpRecentReviews;
        private Label label5;
    }
}
