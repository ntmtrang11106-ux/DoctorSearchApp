namespace UI_Tier
{
    partial class ucAdmin_ReviewManagement
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
            pnlReviewHeader = new Panel();
            lblTitle = new Label();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            lblSearchIcon = new Label();
            cboRatingFilter = new ComboBox();
            cboStatusFilter = new ComboBox();
            lblNoData = new Label();
            pnlStats = new TableLayoutPanel();
            pnlCard1 = new Panel();
            lblStatTitle1 = new Label();
            lblStatValue1 = new Label();
            pnlIcon1 = new Panel();
            lblStatIcon1 = new Label();
            pnlCard2 = new Panel();
            lblStatTitle2 = new Label();
            lblStatValue2 = new Label();
            pnlIcon2 = new Panel();
            lblStatIcon2 = new Label();
            pnlCard3 = new Panel();
            lblStatTitle3 = new Label();
            lblStatValue3 = new Label();
            pnlIcon3 = new Panel();
            lblStatIcon3 = new Label();
            pnlCard4 = new Panel();
            lblStatTitle4 = new Label();
            lblStatValue4 = new Label();
            pnlIcon4 = new Panel();
            lblStatIcon4 = new Label();
            pnlMainContainer = new Panel();
            flpList = new FlowLayoutPanel();
            pnlPagination = new Panel();
            lblPageInfo = new Label();
            lblNext = new Label();
            lblPrev = new Label();
            pnlReviewHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlStats.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlIcon1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlIcon2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlIcon3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlIcon4.SuspendLayout();
            pnlMainContainer.SuspendLayout();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // pnlReviewHeader
            // 
            pnlReviewHeader.BackColor = Color.White;
            pnlReviewHeader.Controls.Add(lblTitle);
            pnlReviewHeader.Controls.Add(pnlSearch);
            pnlReviewHeader.Controls.Add(cboRatingFilter);
            pnlReviewHeader.Controls.Add(cboStatusFilter);
            pnlReviewHeader.Dock = DockStyle.Top;
            pnlReviewHeader.Location = new Point(0, 0);
            pnlReviewHeader.Name = "pnlReviewHeader";
            pnlReviewHeader.Padding = new Padding(30, 20, 30, 0);
            pnlReviewHeader.Size = new Size(1260, 180);
            pnlReviewHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(30, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(323, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý đánh giá";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearchIcon);
            pnlSearch.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlSearch.Location = new Point(30, 100);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1200, 65);
            pnlSearch.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(48, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo bệnh nhân, bác sĩ, nội dung...";
            txtSearch.Size = new Size(1124, 43);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.AutoSize = true;
            lblSearchIcon.Font = new Font("Segoe MDL2 Assets", 15F);
            lblSearchIcon.ForeColor = Color.FromArgb(156, 163, 175);
            lblSearchIcon.Location = new Point(15, 12);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(57, 40);
            lblSearchIcon.TabIndex = 0;
            lblSearchIcon.Text = "";
            // 
            // cboRatingFilter
            // 
            cboRatingFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboRatingFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRatingFilter.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboRatingFilter.FormattingEnabled = true;
            cboRatingFilter.Items.AddRange(new object[] { "Tất cả đánh giá", "5 sao", "4 sao", "3 sao", "2 sao", "1 sao" });
            cboRatingFilter.Location = new Point(600, 100);
            cboRatingFilter.Name = "cboRatingFilter";
            cboRatingFilter.Size = new Size(300, 58);
            cboRatingFilter.TabIndex = 2;
            cboRatingFilter.SelectedIndexChanged += Filter_Changed;
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusFilter.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Items.AddRange(new object[] { "Tất cả trạng thái", "Đang hiển thị", "Đang ẩn", "Đã xóa" });
            cboStatusFilter.Location = new Point(920, 100);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(310, 58);
            cboStatusFilter.TabIndex = 3;
            cboStatusFilter.SelectedIndexChanged += Filter_Changed;
            // 
            // lblNoData
            // 
            lblNoData.AutoSize = true;
            lblNoData.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            lblNoData.ForeColor = Color.Gray;
            lblNoData.Location = new Point(450, 400);
            lblNoData.Name = "lblNoData";
            lblNoData.Size = new Size(544, 51);
            lblNoData.TabIndex = 6;
            lblNoData.Text = "Không tìm thấy dữ liệu phù hợp";
            lblNoData.Visible = false;
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
            pnlStats.Location = new Point(20, 20);
            pnlStats.Name = "pnlStats";
            pnlStats.RowCount = 1;
            pnlStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStats.Size = new Size(1260, 247);
            pnlStats.TabIndex = 0;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.Controls.Add(lblStatTitle1);
            pnlCard1.Controls.Add(lblStatValue1);
            pnlCard1.Controls.Add(pnlIcon1);
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.Location = new Point(10, 10);
            pnlCard1.Margin = new Padding(10);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(295, 227);
            pnlCard1.TabIndex = 0;
            // 
            // lblStatTitle1
            // 
            lblStatTitle1.AutoSize = true;
            lblStatTitle1.Font = new Font("Segoe UI", 12F);
            lblStatTitle1.ForeColor = Color.Gray;
            lblStatTitle1.Location = new Point(20, 20);
            lblStatTitle1.Name = "lblStatTitle1";
            lblStatTitle1.Size = new Size(225, 45);
            lblStatTitle1.TabIndex = 0;
            lblStatTitle1.Text = "Tổng đánh giá";
            // 
            // lblStatValue1
            // 
            lblStatValue1.AutoSize = true;
            lblStatValue1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblStatValue1.ForeColor = Color.Black;
            lblStatValue1.Location = new Point(20, 112);
            lblStatValue1.Name = "lblStatValue1";
            lblStatValue1.Size = new Size(91, 106);
            lblStatValue1.TabIndex = 1;
            lblStatValue1.Text = "0";
            // 
            // pnlIcon1
            // 
            pnlIcon1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon1.BackColor = Color.Transparent;
            pnlIcon1.Controls.Add(lblStatIcon1);
            pnlIcon1.Location = new Point(185, 45);
            pnlIcon1.Name = "pnlIcon1";
            pnlIcon1.Size = new Size(90, 90);
            pnlIcon1.TabIndex = 2;
            // 
            // lblStatIcon1
            // 
            lblStatIcon1.Dock = DockStyle.Fill;
            lblStatIcon1.Font = new Font("Segoe MDL2 Assets", 24F);
            lblStatIcon1.ForeColor = Color.FromArgb(255, 193, 7);
            lblStatIcon1.Location = new Point(0, 0);
            lblStatIcon1.Name = "lblStatIcon1";
            lblStatIcon1.Size = new Size(90, 90);
            lblStatIcon1.TabIndex = 0;
            lblStatIcon1.Text = "";
            lblStatIcon1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.Controls.Add(lblStatTitle2);
            pnlCard2.Controls.Add(lblStatValue2);
            pnlCard2.Controls.Add(pnlIcon2);
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.Location = new Point(325, 10);
            pnlCard2.Margin = new Padding(10);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(295, 227);
            pnlCard2.TabIndex = 1;
            // 
            // lblStatTitle2
            // 
            lblStatTitle2.AutoSize = true;
            lblStatTitle2.Font = new Font("Segoe UI", 12F);
            lblStatTitle2.ForeColor = Color.Gray;
            lblStatTitle2.Location = new Point(20, 20);
            lblStatTitle2.Name = "lblStatTitle2";
            lblStatTitle2.Size = new Size(172, 45);
            lblStatTitle2.TabIndex = 0;
            lblStatTitle2.Text = "Trung bình";
            // 
            // lblStatValue2
            // 
            lblStatValue2.AutoSize = true;
            lblStatValue2.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblStatValue2.ForeColor = Color.Black;
            lblStatValue2.Location = new Point(20, 112);
            lblStatValue2.Name = "lblStatValue2";
            lblStatValue2.Size = new Size(91, 106);
            lblStatValue2.TabIndex = 1;
            lblStatValue2.Text = "0";
            // 
            // pnlIcon2
            // 
            pnlIcon2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon2.BackColor = Color.Transparent;
            pnlIcon2.Controls.Add(lblStatIcon2);
            pnlIcon2.Location = new Point(185, 45);
            pnlIcon2.Name = "pnlIcon2";
            pnlIcon2.Size = new Size(90, 90);
            pnlIcon2.TabIndex = 2;
            // 
            // lblStatIcon2
            // 
            lblStatIcon2.Dock = DockStyle.Fill;
            lblStatIcon2.Font = new Font("Segoe MDL2 Assets", 24F);
            lblStatIcon2.ForeColor = Color.FromArgb(255, 193, 7);
            lblStatIcon2.Location = new Point(0, 0);
            lblStatIcon2.Name = "lblStatIcon2";
            lblStatIcon2.Size = new Size(90, 90);
            lblStatIcon2.TabIndex = 0;
            lblStatIcon2.Text = "";
            lblStatIcon2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.Controls.Add(lblStatTitle3);
            pnlCard3.Controls.Add(lblStatValue3);
            pnlCard3.Controls.Add(pnlIcon3);
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.Location = new Point(640, 10);
            pnlCard3.Margin = new Padding(10);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(295, 227);
            pnlCard3.TabIndex = 2;
            // 
            // lblStatTitle3
            // 
            lblStatTitle3.AutoSize = true;
            lblStatTitle3.Font = new Font("Segoe UI", 12F);
            lblStatTitle3.ForeColor = Color.Gray;
            lblStatTitle3.Location = new Point(20, 20);
            lblStatTitle3.Name = "lblStatTitle3";
            lblStatTitle3.Size = new Size(211, 45);
            lblStatTitle3.TabIndex = 0;
            lblStatTitle3.Text = "Đang hiển thị";
            // 
            // lblStatValue3
            // 
            lblStatValue3.AutoSize = true;
            lblStatValue3.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblStatValue3.ForeColor = Color.FromArgb(40, 199, 111);
            lblStatValue3.Location = new Point(20, 112);
            lblStatValue3.Name = "lblStatValue3";
            lblStatValue3.Size = new Size(91, 106);
            lblStatValue3.TabIndex = 1;
            lblStatValue3.Text = "0";
            // 
            // pnlIcon3
            // 
            pnlIcon3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon3.BackColor = Color.Transparent;
            pnlIcon3.Controls.Add(lblStatIcon3);
            pnlIcon3.Location = new Point(185, 45);
            pnlIcon3.Name = "pnlIcon3";
            pnlIcon3.Size = new Size(90, 90);
            pnlIcon3.TabIndex = 2;
            // 
            // lblStatIcon3
            // 
            lblStatIcon3.Dock = DockStyle.Fill;
            lblStatIcon3.Font = new Font("Segoe MDL2 Assets", 24F);
            lblStatIcon3.ForeColor = Color.FromArgb(40, 199, 111);
            lblStatIcon3.Location = new Point(0, 0);
            lblStatIcon3.Name = "lblStatIcon3";
            lblStatIcon3.Size = new Size(90, 90);
            lblStatIcon3.TabIndex = 0;
            lblStatIcon3.Text = "";
            lblStatIcon3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.Controls.Add(lblStatTitle4);
            pnlCard4.Controls.Add(lblStatValue4);
            pnlCard4.Controls.Add(pnlIcon4);
            pnlCard4.Dock = DockStyle.Fill;
            pnlCard4.Location = new Point(955, 10);
            pnlCard4.Margin = new Padding(10);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(295, 227);
            pnlCard4.TabIndex = 3;
            // 
            // lblStatTitle4
            // 
            lblStatTitle4.AutoSize = true;
            lblStatTitle4.Font = new Font("Segoe UI", 12F);
            lblStatTitle4.ForeColor = Color.Gray;
            lblStatTitle4.Location = new Point(20, 20);
            lblStatTitle4.Name = "lblStatTitle4";
            lblStatTitle4.Size = new Size(138, 45);
            lblStatTitle4.TabIndex = 0;
            lblStatTitle4.Text = "Đang ẩn";
            // 
            // lblStatValue4
            // 
            lblStatValue4.AutoSize = true;
            lblStatValue4.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblStatValue4.ForeColor = Color.FromArgb(234, 84, 85);
            lblStatValue4.Location = new Point(20, 112);
            lblStatValue4.Name = "lblStatValue4";
            lblStatValue4.Size = new Size(91, 106);
            lblStatValue4.TabIndex = 1;
            lblStatValue4.Text = "0";
            // 
            // pnlIcon4
            // 
            pnlIcon4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon4.BackColor = Color.Transparent;
            pnlIcon4.Controls.Add(lblStatIcon4);
            pnlIcon4.Location = new Point(185, 45);
            pnlIcon4.Name = "pnlIcon4";
            pnlIcon4.Size = new Size(90, 90);
            pnlIcon4.TabIndex = 2;
            // 
            // lblStatIcon4
            // 
            lblStatIcon4.Dock = DockStyle.Fill;
            lblStatIcon4.Font = new Font("Segoe MDL2 Assets", 24F);
            lblStatIcon4.ForeColor = Color.FromArgb(234, 84, 85);
            lblStatIcon4.Location = new Point(0, 0);
            lblStatIcon4.Name = "lblStatIcon4";
            lblStatIcon4.Size = new Size(90, 90);
            lblStatIcon4.TabIndex = 0;
            lblStatIcon4.Text = "";
            lblStatIcon4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.BackColor = Color.White;
            pnlMainContainer.Controls.Add(lblNoData);
            pnlMainContainer.Controls.Add(flpList);
            pnlMainContainer.Controls.Add(pnlReviewHeader);
            pnlMainContainer.Controls.Add(pnlPagination);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Location = new Point(20, 267);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Size = new Size(1260, 713);
            pnlMainContainer.TabIndex = 1;
            // 
            // flpList
            // 
            flpList.AutoScroll = true;
            flpList.Dock = DockStyle.Fill;
            flpList.FlowDirection = FlowDirection.TopDown;
            flpList.Location = new Point(0, 180);
            flpList.Name = "flpList";
            flpList.Size = new Size(1260, 453);
            flpList.TabIndex = 4;
            flpList.WrapContents = false;
            flpList.Resize += flpList_Resize;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(240, 245, 250);
            pnlPagination.Controls.Add(lblPageInfo);
            pnlPagination.Controls.Add(lblNext);
            pnlPagination.Controls.Add(lblPrev);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(0, 633);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1260, 80);
            pnlPagination.TabIndex = 5;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Anchor = AnchorStyles.Top;
            lblPageInfo.AutoSize = true;
            lblPageInfo.Font = new Font("Segoe UI", 10.5F);
            lblPageInfo.ForeColor = Color.FromArgb(17, 24, 39);
            lblPageInfo.Location = new Point(555, 20);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(151, 38);
            lblPageInfo.TabIndex = 2;
            lblPageInfo.Text = "Trang 1 / 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Cursor = Cursors.Hand;
            lblNext.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.Location = new Point(1010, 20);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(191, 38);
            lblNext.TabIndex = 1;
            lblNext.Text = "Trang sau >>";
            // 
            // lblPrev
            // 
            lblPrev.AutoSize = true;
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblPrev.Location = new Point(30, 20);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(219, 38);
            lblPrev.TabIndex = 0;
            lblPrev.Text = "<< Trang trước";
            // 
            // ucAdmin_ReviewManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            Controls.Add(pnlMainContainer);
            Controls.Add(pnlStats);
            Name = "ucAdmin_ReviewManagement";
            Padding = new Padding(20);
            Size = new Size(1300, 1000);
            Load += ucAdmin_ReviewManagement_Load;
            pnlReviewHeader.ResumeLayout(false);
            pnlReviewHeader.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
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
            pnlMainContainer.ResumeLayout(false);
            pnlMainContainer.PerformLayout();
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblStatTitle1;
        private System.Windows.Forms.Label lblStatValue1;
        private System.Windows.Forms.Panel pnlIcon1;
        private System.Windows.Forms.Label lblStatIcon1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblStatTitle2;
        private System.Windows.Forms.Label lblStatValue2;
        private System.Windows.Forms.Panel pnlIcon2;
        private System.Windows.Forms.Label lblStatIcon2;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblStatTitle3;
        private System.Windows.Forms.Label lblStatValue3;
        private System.Windows.Forms.Panel pnlIcon3;
        private System.Windows.Forms.Label lblStatIcon3;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblStatTitle4;
        private System.Windows.Forms.Label lblStatValue4;
        private System.Windows.Forms.Panel pnlIcon4;
        private System.Windows.Forms.Label lblStatIcon4;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.ComboBox cboRatingFilter;
        private System.Windows.Forms.Panel pnlReviewHeader;
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.FlowLayoutPanel flpList;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblNoData;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblPrev;
    }
}
