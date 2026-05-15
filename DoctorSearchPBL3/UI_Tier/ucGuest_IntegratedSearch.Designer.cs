namespace UI_Tier
{
    partial class ucGuest_IntegratedSearch
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
            pnlSearchBox = new Panel();
            lstSuggestions = new ListBox();
            txtSearchBar = new TextBox();
            btnSearch = new Button();
            pnlFilters = new Panel();
            labelGender = new Label();
            lblAdminStatus = new Label();
            cboAdminStatus = new ComboBox();
            labelSort = new Label();
            cboSort = new ComboBox();
            cboContentType = new ComboBox();
            labelContentType = new Label();
            cboGender = new ComboBox();
            flpDepts = new FlowLayoutPanel();
            pnlTabHeader = new Panel();
            tabDoc = new Panel();
            lblDocText = new Label();
            lblDocIcon = new Label();
            tabArt = new Panel();
            lblArtText = new Label();
            lblArtIcon = new Label();
            pnlResultContainer = new Panel();
            flpDoctors = new FlowLayoutPanel();
            flpArticles = new FlowLayoutPanel();
            pnlPagination = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            pnlHeader.SuspendLayout();
            pnlSearchBox.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlTabHeader.SuspendLayout();
            tabDoc.SuspendLayout();
            tabArt.SuspendLayout();
            pnlResultContainer.SuspendLayout();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 120, 212);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(pnlSearchBox);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1950, 185);
            pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(65, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(1820, 80);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSearchBox
            // 
            pnlSearchBox.BackColor = Color.White;
            pnlSearchBox.Controls.Add(lstSuggestions);
            pnlSearchBox.Controls.Add(txtSearchBar);
            pnlSearchBox.Controls.Add(btnSearch);
            pnlSearchBox.Location = new Point(65, 76);
            pnlSearchBox.Margin = new Padding(5);
            pnlSearchBox.Name = "pnlSearchBox";
            pnlSearchBox.Size = new Size(1820, 96);
            pnlSearchBox.TabIndex = 1;
            // 
            // lstSuggestions
            // 
            lstSuggestions.BorderStyle = BorderStyle.FixedSingle;
            lstSuggestions.Font = new Font("Segoe UI", 11F);
            lstSuggestions.FormattingEnabled = true;
            lstSuggestions.Location = new Point(-41, 80);
            lstSuggestions.Margin = new Padding(5);
            lstSuggestions.Name = "lstSuggestions";
            lstSuggestions.Size = new Size(1902, 242);
            lstSuggestions.TabIndex = 2;
            lstSuggestions.Visible = false;
            lstSuggestions.Click += lstSuggestions_Click;
            // 
            // txtSearchBar
            // 
            txtSearchBar.BorderStyle = BorderStyle.None;
            txtSearchBar.Font = new Font("Segoe UI", 15F);
            txtSearchBar.Location = new Point(32, 21);
            txtSearchBar.Margin = new Padding(5);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Nhập tên bác sĩ hoặc tiêu đề bài viết...";
            txtSearchBar.Size = new Size(1544, 54);
            txtSearchBar.TabIndex = 0;
            txtSearchBar.TextChanged += txtSearchBar_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 120, 212);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1592, 8);
            btnSearch.Margin = new Padding(5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(211, 80);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(labelGender);
            pnlFilters.Controls.Add(lblAdminStatus);
            pnlFilters.Controls.Add(cboAdminStatus);
            pnlFilters.Controls.Add(labelSort);
            pnlFilters.Controls.Add(cboSort);
            pnlFilters.Controls.Add(cboContentType);
            pnlFilters.Controls.Add(labelContentType);
            pnlFilters.Controls.Add(cboGender);
            pnlFilters.Controls.Add(flpDepts);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 185);
            pnlFilters.Margin = new Padding(5);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1950, 240);
            pnlFilters.TabIndex = 1;
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelGender.Location = new Point(65, 147);
            labelGender.Margin = new Padding(5, 0, 5, 0);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(187, 51);
            labelGender.TabIndex = 4;
            labelGender.Text = "Giới tính:";
            // 
            // lblAdminStatus
            // 
            lblAdminStatus.AutoSize = true;
            lblAdminStatus.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAdminStatus.Location = new Point(1489, 158);
            lblAdminStatus.Name = "lblAdminStatus";
            lblAdminStatus.Size = new Size(212, 51);
            lblAdminStatus.TabIndex = 7;
            lblAdminStatus.Text = "Trạng thái:";
            lblAdminStatus.Visible = false;
            // 
            // cboAdminStatus
            // 
            cboAdminStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAdminStatus.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboAdminStatus.Location = new Point(1709, 158);
            cboAdminStatus.Name = "cboAdminStatus";
            cboAdminStatus.Size = new Size(334, 58);
            cboAdminStatus.TabIndex = 6;
            // 
            // labelSort
            // 
            labelSort.AutoSize = true;
            labelSort.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelSort.Location = new Point(771, 155);
            labelSort.Margin = new Padding(5, 0, 5, 0);
            labelSort.Name = "labelSort";
            labelSort.Size = new Size(173, 51);
            labelSort.TabIndex = 6;
            labelSort.Text = "Sắp xếp:";
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.Font = new Font("Segoe UI", 14F);
            cboSort.FormattingEnabled = true;
            cboSort.Location = new Point(954, 155);
            cboSort.Margin = new Padding(5);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(485, 58);
            cboSort.TabIndex = 3;
            cboSort.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // 
            // cboContentType
            // 
            cboContentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContentType.Font = new Font("Segoe UI", 14F);
            cboContentType.FormattingEnabled = true;
            cboContentType.Location = new Point(351, 155);
            cboContentType.Margin = new Padding(5);
            cboContentType.Name = "cboContentType";
            cboContentType.Size = new Size(388, 58);
            cboContentType.TabIndex = 2;
            cboContentType.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // 
            // labelContentType
            // 
            labelContentType.AutoSize = true;
            labelContentType.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelContentType.Location = new Point(65, 152);
            labelContentType.Margin = new Padding(5, 0, 5, 0);
            labelContentType.Name = "labelContentType";
            labelContentType.Size = new Size(276, 51);
            labelContentType.TabIndex = 5;
            labelContentType.Text = "Loại nội dung:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 14F);
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(296, 155);
            cboGender.Margin = new Padding(5);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(420, 58);
            cboGender.TabIndex = 1;
            cboGender.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // 
            // flpDepts
            // 
            flpDepts.AutoScroll = true;
            flpDepts.BackColor = Color.White;
            flpDepts.Location = new Point(65, 24);
            flpDepts.Margin = new Padding(5);
            flpDepts.Name = "flpDepts";
            flpDepts.Size = new Size(1820, 104);
            flpDepts.TabIndex = 0;
            // 
            // pnlTabHeader
            // 
            pnlTabHeader.BackColor = Color.White;
            pnlTabHeader.Controls.Add(tabDoc);
            pnlTabHeader.Controls.Add(tabArt);
            pnlTabHeader.Dock = DockStyle.Top;
            pnlTabHeader.Location = new Point(0, 425);
            pnlTabHeader.Margin = new Padding(5);
            pnlTabHeader.Name = "pnlTabHeader";
            pnlTabHeader.Size = new Size(1950, 112);
            pnlTabHeader.TabIndex = 2;
            // 
            // tabDoc
            // 
            tabDoc.Controls.Add(lblDocText);
            tabDoc.Controls.Add(lblDocIcon);
            tabDoc.Location = new Point(65, 8);
            tabDoc.Margin = new Padding(5);
            tabDoc.Name = "tabDoc";
            tabDoc.Size = new Size(358, 96);
            tabDoc.TabIndex = 0;
            // 
            // lblDocText
            // 
            lblDocText.AutoSize = true;
            lblDocText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDocText.Location = new Point(130, 24);
            lblDocText.Margin = new Padding(5, 0, 5, 0);
            lblDocText.Name = "lblDocText";
            lblDocText.Size = new Size(105, 45);
            lblDocText.TabIndex = 1;
            lblDocText.Text = "Bác sĩ";
            // 
            // lblDocIcon
            // 
            lblDocIcon.Font = new Font("Segoe MDL2 Assets", 18F);
            lblDocIcon.Location = new Point(32, 19);
            lblDocIcon.Margin = new Padding(5, 0, 5, 0);
            lblDocIcon.Name = "lblDocIcon";
            lblDocIcon.Size = new Size(65, 64);
            lblDocIcon.TabIndex = 0;
            lblDocIcon.Text = "";
            // 
            // tabArt
            // 
            tabArt.Controls.Add(lblArtText);
            tabArt.Controls.Add(lblArtIcon);
            tabArt.Location = new Point(455, 8);
            tabArt.Margin = new Padding(5);
            tabArt.Name = "tabArt";
            tabArt.Size = new Size(358, 96);
            tabArt.TabIndex = 1;
            // 
            // lblArtText
            // 
            lblArtText.AutoSize = true;
            lblArtText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblArtText.Location = new Point(130, 24);
            lblArtText.Margin = new Padding(5, 0, 5, 0);
            lblArtText.Name = "lblArtText";
            lblArtText.Size = new Size(131, 45);
            lblArtText.TabIndex = 1;
            lblArtText.Text = "Bài viết";
            // 
            // lblArtIcon
            // 
            lblArtIcon.Font = new Font("Segoe MDL2 Assets", 18F);
            lblArtIcon.Location = new Point(32, 19);
            lblArtIcon.Margin = new Padding(5, 0, 5, 0);
            lblArtIcon.Name = "lblArtIcon";
            lblArtIcon.Size = new Size(65, 64);
            lblArtIcon.TabIndex = 0;
            lblArtIcon.Text = "";
            // 
            // pnlResultContainer
            // 
            pnlResultContainer.BackColor = Color.FromArgb(252, 253, 255);
            pnlResultContainer.Controls.Add(flpDoctors);
            pnlResultContainer.Controls.Add(flpArticles);
            pnlResultContainer.Dock = DockStyle.Fill;
            pnlResultContainer.Location = new Point(0, 537);
            pnlResultContainer.Margin = new Padding(10);
            pnlResultContainer.Name = "pnlResultContainer";
            pnlResultContainer.Padding = new Padding(5, 5, 5, 10);
            pnlResultContainer.Size = new Size(1950, 795);
            pnlResultContainer.TabIndex = 3;
            // 
            // flpDoctors
            // 
            flpDoctors.AutoScroll = true;
            flpDoctors.Dock = DockStyle.Fill;
            flpDoctors.Location = new Point(5, 5);
            flpDoctors.Margin = new Padding(5);
            flpDoctors.Name = "flpDoctors";
            flpDoctors.Padding = new Padding(32, 10, 32, 150);
            flpDoctors.Size = new Size(1940, 780);
            flpDoctors.TabIndex = 0;
            // 
            // flpArticles
            // 
            flpArticles.AutoScroll = true;
            flpArticles.Dock = DockStyle.Fill;
            flpArticles.Location = new Point(5, 5);
            flpArticles.Margin = new Padding(5);
            flpArticles.Name = "flpArticles";
            flpArticles.Padding = new Padding(32, 10, 32, 150);
            flpArticles.Size = new Size(1940, 780);
            flpArticles.TabIndex = 1;
            flpArticles.Visible = false;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(242, 246, 250);
            pnlPagination.Controls.Add(lblPageStatus);
            pnlPagination.Controls.Add(lblPrev);
            pnlPagination.Controls.Add(lblNext);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(0, 1332);
            pnlPagination.Margin = new Padding(5, 50, 5, 5);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1950, 80);
            pnlPagination.TabIndex = 4;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 10F);
            lblPageStatus.Location = new Point(894, 24);
            lblPageStatus.Margin = new Padding(5, 0, 5, 0);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.Size = new Size(145, 37);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "Trang 1 / 1";
            // 
            // lblPrev
            // 
            lblPrev.AutoSize = true;
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblPrev.Location = new Point(65, 24);
            lblPrev.Margin = new Padding(5, 0, 5, 0);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(212, 37);
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
            lblNext.Location = new Point(1674, 24);
            lblNext.Margin = new Padding(5, 0, 5, 0);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(185, 37);
            lblNext.TabIndex = 0;
            lblNext.Text = "Trang sau >>";
            lblNext.Click += lblNext_Click;
            // 
            // ucGuest_IntegratedSearch
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlResultContainer);
            Controls.Add(pnlTabHeader);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Controls.Add(pnlPagination);
            Margin = new Padding(5);
            Name = "ucGuest_IntegratedSearch";
            Size = new Size(1950, 1412);
            pnlHeader.ResumeLayout(false);
            pnlSearchBox.ResumeLayout(false);
            pnlSearchBox.PerformLayout();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlTabHeader.ResumeLayout(false);
            tabDoc.ResumeLayout(false);
            tabDoc.PerformLayout();
            tabArt.ResumeLayout(false);
            tabArt.PerformLayout();
            pnlResultContainer.ResumeLayout(false);
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label label1;
        private Panel pnlSearchBox;
        private ListBox lstSuggestions;
        private Label labelGender;
        private Label labelContentType;
        private Label labelSort;
        private TextBox txtSearchBar;
        private Button btnSearch;
        private Panel pnlFilters;
        private FlowLayoutPanel flpDepts;
        private ComboBox cboGender;
        private ComboBox cboContentType;
        private ComboBox cboSort;
        private Panel pnlResultContainer;
        private FlowLayoutPanel flpDoctors;
        private FlowLayoutPanel flpArticles;
        private Panel pnlTabHeader;
        private Panel tabDoc;
        private Label lblDocText;
        private Label lblDocIcon;
        private Panel tabArt;
        private Label lblArtText;
        private Label lblArtIcon;
        private Panel pnlPagination;
        private Label lblPageStatus;
        private Label lblPrev;
        private Label lblNext;
        private Label lblAdminStatus;
        private ComboBox cboAdminStatus;
    }
}
