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
            lblStatus = new Label();
            cboStatus = new ComboBox();
            label4 = new Label();
            cboSort = new ComboBox();
            label3 = new Label();
            cboContentType = new ComboBox();
            flpDepartments = new FlowLayoutPanel();
            lblDeptTitle = new Label();
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
            pnlHeader.Margin = new Padding(5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1950, 494);
            pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(33, 33, 33);
            label1.Location = new Point(65, 40);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(644, 65);
            label1.TabIndex = 0;
            label1.Text = "Khám phá kiến thức y khoa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(73, 120);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(941, 41);
            label2.TabIndex = 1;
            label2.Text = "Cập nhật những thông tin mới nhất về sức khỏe và quy trình bệnh viện";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(245, 245, 245);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearchBar);
            pnlSearch.Controls.Add(picSearchIcon);
            pnlSearch.Location = new Point(81, 176);
            pnlSearch.Margin = new Padding(5);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1323, 96);
            pnlSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(0, 112, 243);
            btnSearch.FlatAppearance.BorderColor = Color.White;
            btnSearch.FlatAppearance.BorderSize = 2;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1031, 0);
            btnSearch.Margin = new Padding(5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(287, 96);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Visible = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchBar
            // 
            txtSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchBar.BackColor = Color.FromArgb(245, 245, 245);
            txtSearchBar.BorderStyle = BorderStyle.None;
            txtSearchBar.Font = new Font("Segoe UI", 12F);
            txtSearchBar.Location = new Point(114, 24);
            txtSearchBar.Margin = new Padding(5);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Tìm kiếm bài viết...";
            txtSearchBar.Size = new Size(393, 43);
            txtSearchBar.TabIndex = 1;
            txtSearchBar.TextChanged += txtSearchBar_TextChanged;
            // 
            // picSearchIcon
            // 
            picSearchIcon.Image = Properties.Resources.search;
            picSearchIcon.Location = new Point(24, 19);
            picSearchIcon.Margin = new Padding(5);
            picSearchIcon.Name = "picSearchIcon";
            picSearchIcon.Size = new Size(57, 56);
            picSearchIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picSearchIcon.TabIndex = 0;
            picSearchIcon.TabStop = false;
            // 
            // pnlFilters
            // 
            pnlFilters.Controls.Add(lblStatus);
            pnlFilters.Controls.Add(cboStatus);
            pnlFilters.Controls.Add(label4);
            pnlFilters.Controls.Add(cboSort);
            pnlFilters.Controls.Add(label3);
            pnlFilters.Controls.Add(cboContentType);
            pnlFilters.Controls.Add(flpDepartments);
            pnlFilters.Location = new Point(81, 282);
            pnlFilters.Margin = new Padding(5);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1864, 189);
            pnlFilters.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(1350, 116);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(181, 45);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Trạng thái:";
            lblStatus.Visible = false;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(1550, 113);
            cboStatus.Margin = new Padding(5);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(300, 53);
            cboStatus.TabIndex = 6;
            cboStatus.Visible = false;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(773, 121);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(148, 45);
            label4.TabIndex = 5;
            label4.Text = "Sắp xếp:";
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboSort.FormattingEnabled = true;
            cboSort.Location = new Point(943, 113);
            cboSort.Margin = new Padding(5);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(355, 53);
            cboSort.TabIndex = 4;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 116);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(235, 45);
            label3.TabIndex = 3;
            label3.Text = "Loại nội dung:";
            // 
            // cboContentType
            // 
            cboContentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContentType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboContentType.FormattingEnabled = true;
            cboContentType.Location = new Point(289, 113);
            cboContentType.Margin = new Padding(5);
            cboContentType.Name = "cboContentType";
            cboContentType.Size = new Size(404, 53);
            cboContentType.TabIndex = 2;
            cboContentType.SelectedIndexChanged += cboContentType_SelectedIndexChanged;
            // 
            // flpDepartments
            // 
            flpDepartments.AutoScroll = true;
            flpDepartments.Location = new Point(24, 26);
            flpDepartments.Margin = new Padding(5);
            flpDepartments.Name = "flpDepartments";
            flpDepartments.Size = new Size(1755, 64);
            flpDepartments.TabIndex = 0;
            // 
            // lblDeptTitle
            // 
            lblDeptTitle.AutoSize = true;
            lblDeptTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDeptTitle.Location = new Point(10, 10);
            lblDeptTitle.Name = "lblDeptTitle";
            lblDeptTitle.Size = new Size(116, 23);
            lblDeptTitle.TabIndex = 1;
            lblDeptTitle.Text = "Chuyên khoa:";
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(240, 245, 250);
            pnlPagination.Controls.Add(lblPageStatus);
            pnlPagination.Controls.Add(lblPrev);
            pnlPagination.Controls.Add(lblNext);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(0, 1280);
            pnlPagination.Margin = new Padding(5);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1950, 80);
            pnlPagination.TabIndex = 1;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 11F);
            lblPageStatus.Location = new Point(894, 24);
            lblPageStatus.Margin = new Padding(5, 0, 5, 0);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.Size = new Size(159, 41);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "Trang 1 / 1";
            // 
            // lblPrev
            // 
            lblPrev.AutoSize = true;
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblPrev.Location = new Point(65, 24);
            lblPrev.Margin = new Padding(5, 0, 5, 0);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(234, 41);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "<< Trang trước";
            lblPrev.Click += lblPrev_Click;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Cursor = Cursors.Hand;
            lblNext.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.Location = new Point(1674, 24);
            lblNext.Margin = new Padding(5, 0, 5, 0);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(204, 41);
            lblNext.TabIndex = 0;
            lblNext.Text = "Trang sau >>";
            lblNext.Click += lblNext_Click;
            // 
            // flpResults
            // 
            flpResults.AutoScroll = true;
            flpResults.Dock = DockStyle.Fill;
            flpResults.Location = new Point(0, 494);
            flpResults.Margin = new Padding(5);
            flpResults.Name = "flpResults";
            flpResults.Padding = new Padding(49, 16, 49, 16);
            flpResults.Size = new Size(1950, 786);
            flpResults.TabIndex = 2;
            // 
            // ucPatient_SearchArticle
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpResults);
            Controls.Add(pnlPagination);
            Controls.Add(pnlHeader);
            Margin = new Padding(5);
            Name = "ucPatient_SearchArticle";
            Size = new Size(1950, 1360);
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
        private Label lblStatus;
        private ComboBox cboStatus;
        private Panel pnlPagination;
        private Label lblPageStatus;
        private Label lblPrev;
        private Label lblNext;
        private FlowLayoutPanel flpResults;
    }
}
