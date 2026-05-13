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
            lblTitle = new Label();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            lblSearchIcon = new Label();
            cboRatingFilter = new ComboBox();
            cboStatusFilter = new ComboBox();
            flpList = new FlowLayoutPanel();
            pnlPagination = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
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
            pnlSearch.SuspendLayout();
            pnlPagination.SuspendLayout();
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
            pnlStats.Location = new Point(20, 20);
            pnlStats.Name = "pnlStats";
            pnlStats.RowCount = 1;
            pnlStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStats.Size = new Size(1260, 200);
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
            pnlCard1.Size = new Size(295, 180);
            pnlCard1.TabIndex = 0;
            // 
            // lblStatTitle1
            // 
            lblStatTitle1.AutoSize = true;
            lblStatTitle1.Font = new Font("Segoe UI", 10F);
            lblStatTitle1.ForeColor = Color.Gray;
            lblStatTitle1.Location = new Point(20, 20);
            lblStatTitle1.Name = "lblStatTitle1";
            lblStatTitle1.Size = new Size(195, 37);
            lblStatTitle1.TabIndex = 0;
            lblStatTitle1.Text = "Tổng đánh giá";
            // 
            // lblStatValue1
            // 
            lblStatValue1.AutoSize = true;
            lblStatValue1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblStatValue1.ForeColor = Color.Black;
            lblStatValue1.Location = new Point(15, 70);
            lblStatValue1.Name = "lblStatValue1";
            lblStatValue1.Size = new Size(74, 86);
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
            lblStatIcon1.Text = "";
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
            pnlCard2.Size = new Size(295, 180);
            pnlCard2.TabIndex = 1;
            // 
            // lblStatTitle2
            // 
            lblStatTitle2.AutoSize = true;
            lblStatTitle2.Font = new Font("Segoe UI", 10F);
            lblStatTitle2.ForeColor = Color.Gray;
            lblStatTitle2.Location = new Point(20, 20);
            lblStatTitle2.Name = "lblStatTitle2";
            lblStatTitle2.Size = new Size(136, 37);
            lblStatTitle2.TabIndex = 0;
            lblStatTitle2.Text = "Trung bình";
            // 
            // lblStatValue2
            // 
            lblStatValue2.AutoSize = true;
            lblStatValue2.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblStatValue2.ForeColor = Color.Black;
            lblStatValue2.Location = new Point(15, 70);
            lblStatValue2.Name = "lblStatValue2";
            lblStatValue2.Size = new Size(74, 86);
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
            lblStatIcon2.Text = "";
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
            pnlCard3.Size = new Size(295, 180);
            pnlCard3.TabIndex = 2;
            // 
            // lblStatTitle3
            // 
            lblStatTitle3.AutoSize = true;
            lblStatTitle3.Font = new Font("Segoe UI", 10F);
            lblStatTitle3.ForeColor = Color.Gray;
            lblStatTitle3.Location = new Point(20, 20);
            lblStatTitle3.Name = "lblStatTitle3";
            lblStatTitle3.Size = new Size(182, 37);
            lblStatTitle3.TabIndex = 0;
            lblStatTitle3.Text = "Đang hiển thị";
            // 
            // lblStatValue3
            // 
            lblStatValue3.AutoSize = true;
            lblStatValue3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblStatValue3.ForeColor = Color.FromArgb(40, 199, 111);
            lblStatValue3.Location = new Point(15, 70);
            lblStatValue3.Name = "lblStatValue3";
            lblStatValue3.Size = new Size(74, 86);
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
            lblStatIcon3.Text = "";
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
            pnlCard4.Size = new Size(295, 180);
            pnlCard4.TabIndex = 3;
            // 
            // lblStatTitle4
            // 
            lblStatTitle4.AutoSize = true;
            lblStatTitle4.Font = new Font("Segoe UI", 10F);
            lblStatTitle4.ForeColor = Color.Gray;
            lblStatTitle4.Location = new Point(20, 20);
            lblStatTitle4.Name = "lblStatTitle4";
            lblStatTitle4.Size = new Size(110, 37);
            lblStatTitle4.TabIndex = 0;
            lblStatTitle4.Text = "Đang ẩn";
            // 
            // lblStatValue4
            // 
            lblStatValue4.AutoSize = true;
            lblStatValue4.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblStatValue4.ForeColor = Color.FromArgb(234, 84, 85);
            lblStatValue4.Location = new Point(15, 70);
            lblStatValue4.Name = "lblStatValue4";
            lblStatValue4.Size = new Size(74, 86);
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
            lblStatIcon4.Text = "";
            lblStatIcon4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.BackColor = Color.White;
            pnlMainContainer.Controls.Add(flpList);
            pnlMainContainer.Controls.Add(cboStatusFilter);
            pnlMainContainer.Controls.Add(cboRatingFilter);
            pnlMainContainer.Controls.Add(pnlSearch);
            pnlMainContainer.Controls.Add(lblTitle);
            pnlMainContainer.Controls.Add(pnlPagination);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Location = new Point(20, 240);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Padding = new Padding(30);
            pnlMainContainer.Size = new Size(1260, 740);
            pnlMainContainer.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(30, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(328, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý đánh giá";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(243, 244, 246);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearchIcon);
            pnlSearch.Location = new Point(30, 100);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(550, 60);
            pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(243, 244, 246);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(60, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo bệnh nhân, bác sĩ, nội dung...";
            txtSearch.Size = new Size(470, 43);
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
            lblSearchIcon.Size = new Size(50, 40);
            lblSearchIcon.TabIndex = 0;
            lblSearchIcon.Text = "";
            // 
            // cboRatingFilter
            // 
            cboRatingFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboRatingFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRatingFilter.Font = new Font("Segoe UI", 12F);
            cboRatingFilter.FormattingEnabled = true;
            cboRatingFilter.Items.AddRange(new object[] { "Tất cả đánh giá", "5 sao", "4 sao", "3 sao", "2 sao", "1 sao" });
            cboRatingFilter.Location = new Point(600, 100);
            cboRatingFilter.Name = "cboRatingFilter";
            cboRatingFilter.Size = new Size(300, 53);
            cboRatingFilter.TabIndex = 2;
            cboRatingFilter.SelectedIndexChanged += Filter_Changed;
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusFilter.Font = new Font("Segoe UI", 12F);
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Items.AddRange(new object[] { "Tất cả trạng thái", "Đang hiển thị", "Đang ẩn" });
            cboStatusFilter.Location = new Point(920, 100);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(310, 53);
            cboStatusFilter.TabIndex = 3;
            cboStatusFilter.SelectedIndexChanged += Filter_Changed;
            // 
            // flpList
            // 
            flpList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpList.AutoScroll = true;
            flpList.Location = new Point(30, 190);
            flpList.Name = "flpList";
            flpList.Size = new Size(1200, 440);
            flpList.TabIndex = 4;
            flpList.Resize += flpList_Resize;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(243, 248, 255);
            pnlPagination.Controls.Add(lblPageInfo);
            pnlPagination.Controls.Add(btnNext);
            pnlPagination.Controls.Add(btnPrev);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(30, 630);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1200, 80);
            pnlPagination.TabIndex = 5;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Dock = DockStyle.Fill;
            lblPageInfo.Font = new Font("Segoe UI", 11F);
            lblPageInfo.ForeColor = Color.FromArgb(17, 24, 39);
            lblPageInfo.Location = new Point(250, 0);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(700, 80);
            lblPageInfo.TabIndex = 2;
            lblPageInfo.Text = "Trang 1 / 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.AutoSize = true;
            btnNext.Dock = DockStyle.Right;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(37, 99, 235);
            btnNext.Location = new Point(950, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(250, 80);
            btnNext.TabIndex = 1;
            btnNext.Text = "Trang sau >>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.AutoSize = true;
            btnPrev.Dock = DockStyle.Left;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrev.ForeColor = Color.FromArgb(37, 99, 235);
            btnPrev.Location = new Point(0, 0);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(250, 80);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "<< Trang trước";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
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
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
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
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.FlowLayoutPanel flpList;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
    }
}
