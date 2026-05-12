namespace UI_Tier
{
    partial class ucAdmin_UserManagement
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
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlTabs = new Panel();
            pnlTabIndicator = new Panel();
            btnDoctors = new Button();
            btnPatients = new Button();
            btnAllUsers = new Button();
            pnlFilters = new Panel();
            cboStatusFilter = new ComboBox();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            pnlListHeader = new Panel();
            lblHeaderJoined = new Label();
            lblHeaderStatus = new Label();
            lblHeaderType = new Label();
            lblHeaderPhone = new Label();
            lblHeaderEmail = new Label();
            lblHeaderName = new Label();
            flpUserList = new FlowLayoutPanel();
            pnlPagination = new Panel();
            lblNext = new Label();
            lblPrev = new Label();
            lblPageStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlListHeader.SuspendLayout();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(32, 40);
            pnlHeader.Margin = new Padding(5, 6, 5, 6);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1561, 140);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(249, 115, 22);
            lblSubtitle.Location = new Point(0, 75);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(434, 37);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "⚠️ Có 0 bác sĩ đang chờ phê duyệt";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(480, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý người dùng";
            // 
            // pnlTabs
            // 
            pnlTabs.Controls.Add(pnlTabIndicator);
            pnlTabs.Controls.Add(btnDoctors);
            pnlTabs.Controls.Add(btnPatients);
            pnlTabs.Controls.Add(btnAllUsers);
            pnlTabs.Dock = DockStyle.Top;
            pnlTabs.Location = new Point(32, 180);
            pnlTabs.Margin = new Padding(5, 6, 5, 6);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Size = new Size(1561, 80);
            pnlTabs.TabIndex = 1;
            // 
            // pnlTabIndicator
            // 
            pnlTabIndicator.BackColor = Color.FromArgb(59, 130, 246);
            pnlTabIndicator.Location = new Point(0, 75);
            pnlTabIndicator.Name = "pnlTabIndicator";
            pnlTabIndicator.Size = new Size(150, 5);
            pnlTabIndicator.TabIndex = 4;
            // 
            // btnDoctors
            // 
            btnDoctors.BackColor = Color.Transparent;
            btnDoctors.FlatAppearance.BorderSize = 0;
            btnDoctors.FlatStyle = FlatStyle.Flat;
            btnDoctors.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDoctors.ForeColor = Color.FromArgb(75, 85, 99);
            btnDoctors.Location = new Point(435, 1);
            btnDoctors.Name = "btnDoctors";
            btnDoctors.Size = new Size(228, 70);
            btnDoctors.TabIndex = 3;
            btnDoctors.Text = "Bác sĩ (0)";
            btnDoctors.UseVisualStyleBackColor = false;
            btnDoctors.Click += btnDoctors_Click;
            // 
            // btnPatients
            // 
            btnPatients.BackColor = Color.Transparent;
            btnPatients.FlatAppearance.BorderSize = 0;
            btnPatients.FlatStyle = FlatStyle.Flat;
            btnPatients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPatients.ForeColor = Color.FromArgb(75, 85, 99);
            btnPatients.Location = new Point(201, 0);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(228, 70);
            btnPatients.TabIndex = 2;
            btnPatients.Text = "Bệnh nhân (0)";
            btnPatients.UseVisualStyleBackColor = false;
            btnPatients.Click += btnPatients_Click;
            // 
            // btnAllUsers
            // 
            btnAllUsers.BackColor = Color.Transparent;
            btnAllUsers.FlatAppearance.BorderSize = 0;
            btnAllUsers.FlatStyle = FlatStyle.Flat;
            btnAllUsers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAllUsers.ForeColor = Color.FromArgb(59, 130, 246);
            btnAllUsers.Location = new Point(0, 0);
            btnAllUsers.Name = "btnAllUsers";
            btnAllUsers.Size = new Size(195, 70);
            btnAllUsers.TabIndex = 0;
            btnAllUsers.Text = "Tất cả (0)";
            btnAllUsers.UseVisualStyleBackColor = false;
            btnAllUsers.Click += btnAllUsers_Click;
            // 
            // pnlFilters
            // 
            pnlFilters.Controls.Add(cboStatusFilter);
            pnlFilters.Controls.Add(pnlSearch);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(32, 260);
            pnlFilters.Margin = new Padding(5, 6, 5, 6);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1561, 120);
            pnlFilters.TabIndex = 2;
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusFilter.Font = new Font("Segoe UI", 13.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Items.AddRange(new object[] { "Tất cả trạng thái", "Hoạt động", "Chờ duyệt", "Bị khóa" });
            cboStatusFilter.Location = new Point(1221, 20);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(340, 55);
            cboStatusFilter.TabIndex = 1;
            cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(243, 244, 246);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Location = new Point(0, 10);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(24, 20, 24, 20);
            pnlSearch.Size = new Size(1191, 80);
            pnlSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(243, 244, 246);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(24, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1143, 40);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // pnlListHeader
            // 
            pnlListHeader.BackColor = Color.White;
            pnlListHeader.Controls.Add(lblHeaderJoined);
            pnlListHeader.Controls.Add(lblHeaderStatus);
            pnlListHeader.Controls.Add(lblHeaderType);
            pnlListHeader.Controls.Add(lblHeaderPhone);
            pnlListHeader.Controls.Add(lblHeaderEmail);
            pnlListHeader.Controls.Add(lblHeaderName);
            pnlListHeader.Dock = DockStyle.Top;
            pnlListHeader.Location = new Point(32, 380);
            pnlListHeader.Name = "pnlListHeader";
            pnlListHeader.Size = new Size(1561, 80);
            pnlListHeader.TabIndex = 4;
            // 
            // lblHeaderJoined
            // 
            lblHeaderJoined.AutoSize = true;
            lblHeaderJoined.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderJoined.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeaderJoined.Location = new Point(1320, 20);
            lblHeaderJoined.Name = "lblHeaderJoined";
            lblHeaderJoined.Size = new Size(206, 37);
            lblHeaderJoined.TabIndex = 5;
            lblHeaderJoined.Text = "Ngày tham gia";
            // 
            // lblHeaderStatus
            // 
            lblHeaderStatus.AutoSize = true;
            lblHeaderStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderStatus.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeaderStatus.Location = new Point(1100, 20);
            lblHeaderStatus.Name = "lblHeaderStatus";
            lblHeaderStatus.Size = new Size(147, 37);
            lblHeaderStatus.TabIndex = 4;
            lblHeaderStatus.Text = "Trạng thái";
            // 
            // lblHeaderType
            // 
            lblHeaderType.AutoSize = true;
            lblHeaderType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderType.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeaderType.Location = new Point(950, 20);
            lblHeaderType.Name = "lblHeaderType";
            lblHeaderType.Size = new Size(71, 37);
            lblHeaderType.TabIndex = 3;
            lblHeaderType.Text = "Loại";
            // 
            // lblHeaderPhone
            // 
            lblHeaderPhone.AutoSize = true;
            lblHeaderPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderPhone.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeaderPhone.Location = new Point(700, 20);
            lblHeaderPhone.Name = "lblHeaderPhone";
            lblHeaderPhone.Size = new Size(186, 37);
            lblHeaderPhone.TabIndex = 2;
            lblHeaderPhone.Text = "Số điện thoại";
            // 
            // lblHeaderEmail
            // 
            lblHeaderEmail.AutoSize = true;
            lblHeaderEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderEmail.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeaderEmail.Location = new Point(400, 20);
            lblHeaderEmail.Name = "lblHeaderEmail";
            lblHeaderEmail.Size = new Size(87, 37);
            lblHeaderEmail.TabIndex = 1;
            lblHeaderEmail.Text = "Email";
            // 
            // lblHeaderName
            // 
            lblHeaderName.AutoSize = true;
            lblHeaderName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderName.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeaderName.Location = new Point(20, 20);
            lblHeaderName.Name = "lblHeaderName";
            lblHeaderName.Size = new Size(171, 37);
            lblHeaderName.TabIndex = 0;
            lblHeaderName.Text = "Người dùng";
            // 
            // flpUserList
            // 
            flpUserList.AutoScroll = true;
            flpUserList.Dock = DockStyle.Fill;
            flpUserList.FlowDirection = FlowDirection.TopDown;
            flpUserList.Location = new Point(32, 380);
            flpUserList.Name = "flpUserList";
            flpUserList.Padding = new Padding(0, 10, 0, 10);
            flpUserList.Size = new Size(1561, 1100);
            flpUserList.TabIndex = 3;
            flpUserList.WrapContents = false;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(242, 246, 250);
            pnlPagination.Controls.Add(lblNext);
            pnlPagination.Controls.Add(lblPrev);
            pnlPagination.Controls.Add(lblPageStatus);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(32, 1480);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1561, 80);
            pnlPagination.TabIndex = 4;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Cursor = Cursors.Hand;
            lblNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.Location = new Point(1350, 24);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(185, 37);
            lblNext.TabIndex = 0;
            lblNext.Text = "Trang sau >>";
            lblNext.Click += lblNext_Click;
            // 
            // lblPrev
            // 
            lblPrev.AutoSize = true;
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblPrev.Location = new Point(24, 24);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(212, 37);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "<< Trang trước";
            lblPrev.Click += lblPrev_Click;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.None;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 10F);
            lblPageStatus.Location = new Point(708, 24);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.Size = new Size(145, 37);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "Trang 1 / 1";
            lblPageStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucAdmin_UserManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpUserList);
            Controls.Add(pnlPagination);
            Controls.Add(pnlFilters);
            Controls.Add(pnlTabs);
            Controls.Add(pnlHeader);
            Name = "ucAdmin_UserManagement";
            Padding = new Padding(32, 40, 32, 40);
            Size = new Size(1625, 1600);
            Load += ucAdmin_UserManagement_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTabs.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlListHeader.ResumeLayout(false);
            pnlListHeader.PerformLayout();
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Panel pnlTabIndicator;
        private System.Windows.Forms.Button btnPendingDoctors;
        private System.Windows.Forms.Button btnAllUsers;
        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.Button btnDoctors;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.Panel pnlListHeader;
        private System.Windows.Forms.Label lblHeaderName;
        private System.Windows.Forms.Label lblHeaderEmail;
        private System.Windows.Forms.Label lblHeaderPhone;
        private System.Windows.Forms.Label lblHeaderType;
        private System.Windows.Forms.Label lblHeaderStatus;
        private System.Windows.Forms.Label lblHeaderJoined;
        private System.Windows.Forms.FlowLayoutPanel flpUserList;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblPrev;
        private System.Windows.Forms.Label lblPageStatus;
    }
}
