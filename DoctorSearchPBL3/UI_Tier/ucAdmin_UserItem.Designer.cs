namespace UI_Tier
{
    partial class ucAdmin_UserItem
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
            flpHeader = new FlowLayoutPanel();
            pnlRoleBadge = new Panel();
            lblRole = new Label();
            lblFullName = new Label();
            pnlApprovalBadge = new Panel();
            lblApproval = new Label();
            pnlStatusBadge = new Panel();
            lblStatus = new Label();
            pnlCard = new Panel();
            flpActions = new FlowLayoutPanel();
            btnRemove = new Button();
            btnEdit = new Button();
            btnToggleStatus = new Button();
            btnReject = new Button();
            btnApprove = new Button();
            btnDetail = new Button();
            lblExp = new Label();
            lblDepartment = new Label();
            lblPhone = new Label();
            lblLicenseOrBHYT = new Label();
            lblDeptOrCode = new Label();
            lblDob = new Label();
            flpHeader.SuspendLayout();
            pnlRoleBadge.SuspendLayout();
            pnlApprovalBadge.SuspendLayout();
            pnlStatusBadge.SuspendLayout();
            pnlCard.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // flpHeader
            // 
            flpHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpHeader.Controls.Add(pnlRoleBadge);
            flpHeader.Controls.Add(lblFullName);
            flpHeader.Controls.Add(pnlApprovalBadge);
            flpHeader.Controls.Add(pnlStatusBadge);
            flpHeader.Location = new Point(32, 44);
            flpHeader.Name = "flpHeader";
            flpHeader.Size = new Size(1236, 60);
            flpHeader.TabIndex = 13;
            flpHeader.WrapContents = false;
            // 
            // pnlRoleBadge
            // 
            pnlRoleBadge.Controls.Add(lblRole);
            pnlRoleBadge.Location = new Point(0, 5);
            pnlRoleBadge.Margin = new Padding(0, 5, 10, 0);
            pnlRoleBadge.Name = "pnlRoleBadge";
            pnlRoleBadge.Size = new Size(200, 45);
            pnlRoleBadge.TabIndex = 0;
            // 
            // lblRole
            // 
            lblRole.Dock = DockStyle.Fill;
            lblRole.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.Location = new Point(0, 0);
            lblRole.Margin = new Padding(5, 0, 5, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(200, 45);
            lblRole.TabIndex = 0;
            lblRole.Text = "BỆNH NHÂN";
            lblRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFullName.ForeColor = Color.FromArgb(31, 41, 55);
            lblFullName.Location = new Point(170, 5);
            lblFullName.Margin = new Padding(0, 5, 10, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(313, 50);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Lê Hoàng Cường";
            // 
            // pnlApprovalBadge
            // 
            pnlApprovalBadge.Controls.Add(lblApproval);
            pnlApprovalBadge.Location = new Point(503, 0);
            pnlApprovalBadge.Margin = new Padding(10, 0, 10, 0);
            pnlApprovalBadge.Name = "pnlApprovalBadge";
            pnlApprovalBadge.Size = new Size(220, 60);
            pnlApprovalBadge.TabIndex = 2;
            // 
            // lblApproval
            // 
            lblApproval.Dock = DockStyle.Fill;
            lblApproval.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApproval.Location = new Point(0, 0);
            lblApproval.Name = "lblApproval";
            lblApproval.Size = new Size(220, 60);
            lblApproval.TabIndex = 0;
            lblApproval.Text = "Chờ duyệt";
            lblApproval.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStatusBadge
            // 
            pnlStatusBadge.Controls.Add(lblStatus);
            pnlStatusBadge.Location = new Point(743, 0);
            pnlStatusBadge.Margin = new Padding(10, 0, 10, 0);
            pnlStatusBadge.Name = "pnlStatusBadge";
            pnlStatusBadge.Size = new Size(220, 60);
            pnlStatusBadge.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(220, 60);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Hoạt động";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard
            // 
            pnlCard.Controls.Add(flpActions);
            pnlCard.Controls.Add(flpHeader);
            pnlCard.Controls.Add(lblExp);
            pnlCard.Controls.Add(lblDepartment);
            pnlCard.Controls.Add(lblPhone);
            pnlCard.Controls.Add(lblLicenseOrBHYT);
            pnlCard.Controls.Add(lblDeptOrCode);
            pnlCard.Controls.Add(lblDob);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(16, 20);
            pnlCard.Margin = new Padding(5, 6, 5, 6);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(32, 40, 10, 40);
            pnlCard.Size = new Size(1757, 226);
            pnlCard.TabIndex = 0;
            // 
            // flpActions
            // 
            flpActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpActions.AutoSize = true;
            flpActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpActions.Controls.Add(btnRemove);
            flpActions.Controls.Add(btnEdit);
            flpActions.Controls.Add(btnToggleStatus);
            flpActions.Controls.Add(btnReject);
            flpActions.Controls.Add(btnApprove);
            flpActions.Controls.Add(btnDetail);
            flpActions.FlowDirection = FlowDirection.RightToLeft;
            flpActions.Location = new Point(782, 53);
            flpActions.Margin = new Padding(0);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(955, 95);
            flpActions.TabIndex = 21;
            flpActions.WrapContents = false;
            // 
            // btnRemove
            // 
            btnRemove.AccessibleDescription = "C";
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.BackColor = Color.FromArgb(255, 252, 235);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 20F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(870, 5);
            btnRemove.Margin = new Padding(15, 5, 0, 5);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(85, 85);
            btnRemove.TabIndex = 23;
            btnRemove.Text = "";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEdit
            // 
            btnEdit.AccessibleDescription = "C";
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.FromArgb(239, 250, 255);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 20F);
            btnEdit.ForeColor = Color.FromArgb(37, 99, 235);
            btnEdit.Location = new Point(770, 7);
            btnEdit.Margin = new Padding(8, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 21;
            btnEdit.Text = "";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnToggleStatus
            // 
            btnToggleStatus.BackColor = Color.FromArgb(255, 87, 34);
            btnToggleStatus.FlatAppearance.BorderSize = 0;
            btnToggleStatus.FlatStyle = FlatStyle.Flat;
            btnToggleStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnToggleStatus.ForeColor = Color.White;
            btnToggleStatus.Location = new Point(567, 5);
            btnToggleStatus.Margin = new Padding(15, 5, 0, 5);
            btnToggleStatus.Name = "btnToggleStatus";
            btnToggleStatus.Size = new Size(195, 80);
            btnToggleStatus.TabIndex = 7;
            btnToggleStatus.Text = "🔒 Chặn";
            btnToggleStatus.UseVisualStyleBackColor = false;
            btnToggleStatus.Click += btnToggleStatus_Click;
            // 
            // btnReject
            // 
            btnReject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReject.BackColor = Color.FromArgb(220, 38, 38);
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(357, 5);
            btnReject.Margin = new Padding(15, 5, 0, 5);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(195, 80);
            btnReject.TabIndex = 6;
            btnReject.Text = "✖ Từ chối";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnApprove
            // 
            btnApprove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApprove.BackColor = Color.FromArgb(16, 185, 129);
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(103, 5);
            btnApprove.Margin = new Padding(15, 5, 0, 5);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(239, 80);
            btnApprove.TabIndex = 5;
            btnApprove.Text = "✔ Phê duyệt";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnDetail
            // 
            btnDetail.Anchor = AnchorStyles.None;
            btnDetail.BackColor = Color.Azure;
            btnDetail.FlatAppearance.BorderSize = 0;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.Font = new Font("Segoe MDL2 Assets", 18F);
            btnDetail.ForeColor = Color.DodgerBlue;
            btnDetail.Location = new Point(8, 10);
            btnDetail.Margin = new Padding(8, 10, 0, 5);
            btnDetail.Name = "btnDetail";
            btnDetail.Size = new Size(80, 80);
            btnDetail.TabIndex = 20;
            btnDetail.Text = "";
            btnDetail.TextAlign = ContentAlignment.MiddleRight;
            btnDetail.UseVisualStyleBackColor = false;
            btnDetail.Click += btnDetail_Click;
            // 
            // lblExp
            // 
            lblExp.AutoSize = true;
            lblExp.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExp.ForeColor = Color.FromArgb(64, 64, 64);
            lblExp.Location = new Point(450, 170);
            lblExp.Margin = new Padding(5, 0, 5, 0);
            lblExp.Name = "lblExp";
            lblExp.Size = new Size(254, 37);
            lblExp.TabIndex = 12;
            lblExp.Text = "Kinh nghiệm: 5 năm";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDepartment.ForeColor = Color.FromArgb(64, 64, 64);
            lblDepartment.Location = new Point(63, 130);
            lblDepartment.Margin = new Padding(5, 0, 5, 0);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(292, 37);
            lblDepartment.TabIndex = 11;
            lblDepartment.Text = "Chuyên khoa: Nội khoa";
            lblDepartment.Visible = false;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = Color.FromArgb(64, 64, 64);
            lblPhone.Location = new Point(450, 115);
            lblPhone.Margin = new Padding(5, 0, 5, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(307, 37);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Số điện thoại: 09345678";
            // 
            // lblLicenseOrBHYT
            // 
            lblLicenseOrBHYT.AutoSize = true;
            lblLicenseOrBHYT.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLicenseOrBHYT.ForeColor = Color.FromArgb(64, 64, 64);
            lblLicenseOrBHYT.Location = new Point(32, 167);
            lblLicenseOrBHYT.Margin = new Padding(5, 0, 5, 0);
            lblLicenseOrBHYT.Name = "lblLicenseOrBHYT";
            lblLicenseOrBHYT.Size = new Size(261, 40);
            lblLicenseOrBHYT.TabIndex = 9;
            lblLicenseOrBHYT.Text = "Số CCHN: BS12345";
            // 
            // lblDeptOrCode
            // 
            lblDeptOrCode.AutoSize = true;
            lblDeptOrCode.Font = new Font("Segoe UI", 10.125F);
            lblDeptOrCode.ForeColor = Color.FromArgb(64, 64, 64);
            lblDeptOrCode.Location = new Point(32, 115);
            lblDeptOrCode.Name = "lblDeptOrCode";
            lblDeptOrCode.Size = new Size(202, 37);
            lblDeptOrCode.TabIndex = 22;
            lblDeptOrCode.Text = "Chuyên khoa: ...";
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDob.ForeColor = Color.FromArgb(64, 64, 64);
            lblDob.Location = new Point(450, 169);
            lblDob.Margin = new Padding(5, 0, 5, 0);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(275, 37);
            lblDob.TabIndex = 11;
            lblDob.Text = "Ngày sinh: 15/3/1990";
            lblDob.Visible = false;
            // 
            // ucAdmin_UserItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 251, 253);
            Controls.Add(pnlCard);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ucAdmin_UserItem";
            Padding = new Padding(16, 20, 16, 20);
            Size = new Size(1789, 266);
            flpHeader.ResumeLayout(false);
            flpHeader.PerformLayout();
            pnlRoleBadge.ResumeLayout(false);
            pnlApprovalBadge.ResumeLayout(false);
            pnlStatusBadge.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            flpActions.ResumeLayout(false);
            ResumeLayout(false);

        }
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.FlowLayoutPanel flpHeader;
        private System.Windows.Forms.Panel pnlRoleBadge;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Panel pnlApprovalBadge;
        private System.Windows.Forms.Label lblApproval;
        private System.Windows.Forms.Panel pnlStatusBadge;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnToggleStatus;
        private System.Windows.Forms.Label lblDeptOrCode;
        private System.Windows.Forms.Label lblLicenseOrBHYT;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label lblExp;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
    }
}
