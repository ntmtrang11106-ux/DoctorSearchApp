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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnPendingDoctors = new System.Windows.Forms.Button();
            this.btnAllUsers = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.cboRoleFilter = new System.Windows.Forms.ComboBox();
            this.lblFilterRole = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flpUserList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(960, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý người dùng";
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.btnPendingDoctors);
            this.pnlTabs.Controls.Add(this.btnAllUsers);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(20, 80);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(960, 50);
            this.pnlTabs.TabIndex = 1;
            // 
            // btnPendingDoctors
            // 
            this.btnPendingDoctors.BackColor = System.Drawing.Color.White;
            this.btnPendingDoctors.FlatAppearance.BorderSize = 0;
            this.btnPendingDoctors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendingDoctors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPendingDoctors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPendingDoctors.Location = new System.Drawing.Point(180, 0);
            this.btnPendingDoctors.Name = "btnPendingDoctors";
            this.btnPendingDoctors.Size = new System.Drawing.Size(180, 40);
            this.btnPendingDoctors.TabIndex = 1;
            this.btnPendingDoctors.Text = "Duyệt bác sĩ";
            this.btnPendingDoctors.UseVisualStyleBackColor = false;
            this.btnPendingDoctors.Click += new System.EventHandler(this.btnPendingDoctors_Click);
            // 
            // btnAllUsers
            // 
            this.btnAllUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnAllUsers.FlatAppearance.BorderSize = 0;
            this.btnAllUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAllUsers.ForeColor = System.Drawing.Color.White;
            this.btnAllUsers.Location = new System.Drawing.Point(0, 0);
            this.btnAllUsers.Name = "btnAllUsers";
            this.btnAllUsers.Size = new System.Drawing.Size(170, 40);
            this.btnAllUsers.TabIndex = 0;
            this.btnAllUsers.Text = "Tất cả người dùng";
            this.btnAllUsers.UseVisualStyleBackColor = false;
            this.btnAllUsers.Click += new System.EventHandler(this.btnAllUsers_Click);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.cboRoleFilter);
            this.pnlFilters.Controls.Add(this.lblFilterRole);
            this.pnlFilters.Controls.Add(this.pnlSearch);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(20, 130);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(960, 60);
            this.pnlFilters.TabIndex = 2;
            // 
            // cboRoleFilter
            // 
            this.cboRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRoleFilter.FormattingEnabled = true;
            this.cboRoleFilter.Items.AddRange(new object[] {
            "Tất cả",
            "Admin",
            "Doctor",
            "Patient"});
            this.cboRoleFilter.Location = new System.Drawing.Point(400, 15);
            this.cboRoleFilter.Name = "cboRoleFilter";
            this.cboRoleFilter.Size = new System.Drawing.Size(150, 31);
            this.cboRoleFilter.TabIndex = 2;
            this.cboRoleFilter.SelectedIndexChanged += new System.EventHandler(this.cboRoleFilter_SelectedIndexChanged);
            // 
            // lblFilterRole
            // 
            this.lblFilterRole.AutoSize = true;
            this.lblFilterRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterRole.ForeColor = System.Drawing.Color.Gray;
            this.lblFilterRole.Location = new System.Drawing.Point(340, 20);
            this.lblFilterRole.Name = "lblFilterRole";
            this.lblFilterRole.Size = new System.Drawing.Size(55, 20);
            this.lblFilterRole.TabIndex = 1;
            this.lblFilterRole.Text = "Vai trò:";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(0, 10);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.pnlSearch.Size = new System.Drawing.Size(320, 40);
            this.pnlSearch.TabIndex = 0;
            this.pnlSearch.Paint += new System.Windows.Forms.PaintEventHandler((s, e) => UIHelper.DrawControlBorder(s, e, 20, System.Drawing.Color.FromArgb(230, 230, 230), 1));
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(15, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm tên, số điện thoại...";
            this.txtSearch.Size = new System.Drawing.Size(290, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // flpUserList
            // 
            this.flpUserList.AutoScroll = true;
            this.flpUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpUserList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpUserList.Location = new System.Drawing.Point(20, 190);
            this.flpUserList.Name = "flpUserList";
            this.flpUserList.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flpUserList.Size = new System.Drawing.Size(960, 590);
            this.flpUserList.TabIndex = 3;
            this.flpUserList.WrapContents = false;
            // 
            // ucAdmin_UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.flpUserList);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucAdmin_UserManagement";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1000, 800);
            this.Load += new System.EventHandler(this.ucAdmin_UserManagement_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnPendingDoctors;
        private System.Windows.Forms.Button btnAllUsers;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterRole;
        private System.Windows.Forms.ComboBox cboRoleFilter;
        private System.Windows.Forms.FlowLayoutPanel flpUserList;
    }
}
