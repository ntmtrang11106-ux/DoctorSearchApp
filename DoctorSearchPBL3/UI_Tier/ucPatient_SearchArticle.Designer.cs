namespace UI_Tier
{
    partial class ucPatient_SearchArticle
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
            label1 = new Label();
            label2 = new Label();
            pnlSearch = new Panel();
            btnSearch = new Button();
            txtSearchBar = new TextBox();
            picSearchIcon = new PictureBox();
            pnlFilters = new Panel();
            label4 = new Label();
            cboSort = new ComboBox();
            label3 = new Label();
            cboContentType = new ComboBox();
            lblDeptTitle = new Label();
            flpDepartments = new FlowLayoutPanel();
            pnlPagination = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            flpResults = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearchIcon).BeginInit();
            pnlFilters.SuspendLayout();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(label2);
            pnlHeader.Controls.Add(pnlSearch);
            pnlHeader.Controls.Add(pnlFilters);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1200, 350);
            pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(33, 33, 33);
            label1.Location = new Point(40, 25);
            label1.Name = "label1";
            label1.Size = new Size(411, 41);
            label1.TabIndex = 0;
            label1.Text = "Khám phá kiến thức y khoa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(45, 75);
            label2.Name = "label2";
            label2.Size = new Size(582, 25);
            label2.TabIndex = 1;
            label2.Text = "Cập nhật những thông tin mới nhất về sức khỏe và quy trình bệnh viện";
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.BackColor = Color.White;
            pnlSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearchBar);
            pnlSearch.Controls.Add(picSearchIcon);
            pnlSearch.Location = new Point(50, 120);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1100, 60);
            pnlSearch.TabIndex = 2;
            //pnlSearch.Paint += (s, e) => UIHelper.DrawControlBorder(s, e, 30, Color.FromArgb(0, 120, 212), 2);
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(0, 120, 212);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(950, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(140, 48);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchBar
            // 
            txtSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchBar.BorderStyle = BorderStyle.None;
            txtSearchBar.Font = new Font("Segoe UI", 13F);
            txtSearchBar.Location = new Point(60, 15);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Nhập tiêu đề bài viết cần tìm...";
            txtSearchBar.Size = new Size(880, 29);
            txtSearchBar.TabIndex = 1;
            txtSearchBar.TextChanged += txtSearchBar_TextChanged;
            // 
            // picSearchIcon
            // 
            picSearchIcon.Image = Properties.Resources.search;
            picSearchIcon.Location = new Point(15, 12);
            picSearchIcon.Name = "picSearchIcon";
            picSearchIcon.Size = new Size(35, 35);
            picSearchIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picSearchIcon.TabIndex = 0;
            picSearchIcon.TabStop = false;
            // 
            // pnlFilters
            // 
            pnlFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilters.Controls.Add(label4);
            pnlFilters.Controls.Add(cboSort);
            pnlFilters.Controls.Add(label3);
            pnlFilters.Controls.Add(cboContentType);
            pnlFilters.Controls.Add(lblDeptTitle);
            pnlFilters.Controls.Add(flpDepartments);
            pnlFilters.Location = new Point(50, 190);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1100, 150);
            pnlFilters.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(650, 80);
            label4.Name = "label4";
            label4.Size = new Size(78, 23);
            label4.TabIndex = 5;
            label4.Text = "Sắp xếp:";
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.Font = new Font("Segoe UI", 10F);
            cboSort.FormattingEnabled = true;
            cboSort.Location = new Point(650, 110);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(200, 31);
            cboSort.TabIndex = 4;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(400, 80);
            label3.Name = "label3";
            label3.Size = new Size(119, 23);
            label3.TabIndex = 3;
            label3.Text = "Loại nội dung:";
            // 
            // cboContentType
            // 
            cboContentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContentType.Font = new Font("Segoe UI", 10F);
            cboContentType.FormattingEnabled = true;
            cboContentType.Location = new Point(400, 110);
            cboContentType.Name = "cboContentType";
            cboContentType.Size = new Size(220, 31);
            cboContentType.TabIndex = 2;
            cboContentType.SelectedIndexChanged += cboContentType_SelectedIndexChanged;
            // 
            // lblDeptTitle
            // 
            lblDeptTitle.AutoSize = true;
            lblDeptTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDeptTitle.Location = new Point(10, 10);
            lblDeptTitle.Name = "lblDeptTitle";
            lblDeptTitle.Size = new Size(116, 23);
            lblDeptTitle.TabIndex = 1;
            lblDeptTitle.Text = "Chuyên khoa:";
            // 
            // flpDepartments
            // 
            flpDepartments.AutoScroll = true;
            flpDepartments.Location = new Point(10, 40);
            flpDepartments.Name = "flpDepartments";
            flpDepartments.Size = new Size(1080, 40);
            flpDepartments.TabIndex = 0;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(245, 245, 245);
            pnlPagination.Controls.Add(lblPageStatus);
            pnlPagination.Controls.Add(lblPrev);
            pnlPagination.Controls.Add(lblNext);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(0, 800);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1200, 50);
            pnlPagination.TabIndex = 1;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 10F);
            lblPageStatus.Location = new Point(550, 15);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.Size = new Size(100, 23);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "Trang 1 / 1";
            // 
            // lblPrev
            // 
            lblPrev.AutoSize = true;
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblPrev.Location = new Point(40, 15);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(134, 23);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "<< Trang trước";
            lblPrev.Click += lblPrev_Click;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Cursor = Cursors.Hand;
            lblNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.Location = new Point(1030, 15);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(126, 23);
            lblNext.TabIndex = 0;
            lblNext.Text = "Trang sau >>";
            lblNext.Click += lblNext_Click;
            // 
            // flpResults
            // 
            flpResults.AutoScroll = true;
            flpResults.Dock = DockStyle.Fill;
            flpResults.Location = new Point(0, 350);
            flpResults.Name = "flpResults";
            flpResults.Padding = new Padding(30, 10, 30, 10);
            flpResults.Size = new Size(1200, 450);
            flpResults.TabIndex = 2;
            // 
            // ucPatient_SearchArticle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpResults);
            Controls.Add(pnlPagination);
            Controls.Add(pnlHeader);
            Name = "ucPatient_SearchArticle";
            Size = new Size(1200, 850);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearchIcon).EndInit();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label label1;
        private Label label2;
        private Panel pnlSearch;
        private TextBox txtSearchBar;
        private PictureBox picSearchIcon;
        private Button btnSearch;
        private Panel pnlFilters;
        private Label lblDeptTitle;
        private FlowLayoutPanel flpDepartments;
        private Label label3;
        private ComboBox cboContentType;
        private Label label4;
        private ComboBox cboSort;
        private Panel pnlPagination;
        private Label lblPageStatus;
        private Label lblPrev;
        private Label lblNext;
        private FlowLayoutPanel flpResults;
    }
}
