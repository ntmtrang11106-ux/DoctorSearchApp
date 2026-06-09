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
            lblApproval = new Label();
            lblStatus = new Label();
            pnlCard = new Panel();
            flpActions = new FlowLayoutPanel();
            btnApprove = new Button();
            btnReject = new Button();
            btnToggleStatus = new Button();
            btnDetail = new Button();
            btnRemove = new Button();
            btnEdit = new Button();
            lblExp = new Label();
            lblDepartment = new Label();
            lblPhone = new Label();
            lblLicenseOrBHYT = new Label();
            lblDeptOrCode = new Label();
            lblDob = new Label();
            flpHeader.SuspendLayout();
            pnlRoleBadge.SuspendLayout();
            pnlCard.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // flpHeader
            // 
            flpHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpHeader.Controls.Add(pnlRoleBadge);
            flpHeader.Controls.Add(lblFullName);
            flpHeader.Controls.Add(lblApproval);
            flpHeader.Controls.Add(lblStatus);
            flpHeader.Location = new Point(34, 31);
            flpHeader.Name = "flpHeader";
            flpHeader.Size = new Size(1643, 60);
            flpHeader.TabIndex = 13;
            flpHeader.WrapContents = false;
            // 
            // pnlRoleBadge
            // 
            pnlRoleBadge.Controls.Add(lblRole);
            pnlRoleBadge.Location = new Point(0, 5);
            pnlRoleBadge.Margin = new Padding(0, 5, 10, 0);
            pnlRoleBadge.Name = "pnlRoleBadge";
            pnlRoleBadge.Size = new Size(220, 45);
            pnlRoleBadge.TabIndex = 0;
            // 
            // lblRole
            // 
            lblRole.Dock = DockStyle.Fill;
            lblRole.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.Location = new Point(0, 0);
            lblRole.Margin = new Padding(5, 0, 20, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(220, 45);
            lblRole.TabIndex = 0;
            lblRole.Text = "BỆNH NHÂN";
            lblRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFullName.ForeColor = Color.FromArgb(31, 41, 55);
            lblFullName.Location = new Point(250, 5);
            lblFullName.Margin = new Padding(20, 5, 50, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(313, 50);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Lê Hoàng Cường";
            // 
            // lblApproval
            // 
            lblApproval.Font = new Font("Segoe UI Semibold", 13.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApproval.Location = new Point(663, 0);
            lblApproval.Margin = new Padding(50, 0, 50, 0);
            lblApproval.Name = "lblApproval";
            lblApproval.Size = new Size(264, 55);
            lblApproval.TabIndex = 0;
            lblApproval.Text = "Chờ duyệt";
            lblApproval.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI Semibold", 13.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(987, 0);
            lblStatus.Margin = new Padding(10, 0, 50, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(260, 55);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Hoạt động";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
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
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(3);
            pnlCard.Size = new Size(1757, 246);
            pnlCard.TabIndex = 0;
            // 
            // flpActions
            // 
            flpActions.AutoSize = true;
            flpActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpActions.BackColor = Color.Transparent;
            flpActions.Controls.Add(btnApprove);
            flpActions.Controls.Add(btnReject);
            flpActions.Controls.Add(btnToggleStatus);
            flpActions.Controls.Add(btnDetail);
            flpActions.Controls.Add(btnRemove);
            flpActions.Controls.Add(btnEdit);
            flpActions.Dock = DockStyle.Right;
            flpActions.Location = new Point(726, 3);
            flpActions.Margin = new Padding(0);
            flpActions.Name = "flpActions";
            flpActions.Padding = new Padding(0, 100, 16, 0);
            flpActions.Size = new Size(1028, 240);
            flpActions.TabIndex = 21;
            flpActions.WrapContents = false;
            // 
            // btnApprove
            // 
            btnApprove.Anchor = AnchorStyles.Right;
            btnApprove.BackColor = Color.LimeGreen;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(15, 110);
            btnApprove.Margin = new Padding(15, 5, 0, 5);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(239, 75);
            btnApprove.TabIndex = 5;
            btnApprove.Text = "✔ Phê duyệt";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.Anchor = AnchorStyles.Right;
            btnReject.BackColor = Color.Red;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(269, 110);
            btnReject.Margin = new Padding(15, 5, 0, 5);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(195, 75);
            btnReject.TabIndex = 6;
            btnReject.Text = "✖ Từ chối";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnToggleStatus
            // 
            btnToggleStatus.Anchor = AnchorStyles.Right;
            btnToggleStatus.BackColor = Color.FromArgb(255, 128, 0);
            btnToggleStatus.FlatAppearance.BorderSize = 0;
            btnToggleStatus.FlatStyle = FlatStyle.Flat;
            btnToggleStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnToggleStatus.ForeColor = Color.White;
            btnToggleStatus.Location = new Point(479, 110);
            btnToggleStatus.Margin = new Padding(15, 5, 0, 5);
            btnToggleStatus.Name = "btnToggleStatus";
            btnToggleStatus.Size = new Size(195, 75);
            btnToggleStatus.TabIndex = 7;
            btnToggleStatus.Text = "🔒 Chặn";
            btnToggleStatus.UseVisualStyleBackColor = false;
            btnToggleStatus.Click += btnToggleStatus_Click;
            // 
            // btnDetail
            // 
            btnDetail.Anchor = AnchorStyles.Right;
            btnDetail.BackColor = Color.Azure;
            btnDetail.FlatAppearance.BorderSize = 0;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.Font = new Font("Segoe MDL2 Assets", 18F);
            btnDetail.ForeColor = Color.DodgerBlue;
            btnDetail.Location = new Point(724, 110);
            btnDetail.Margin = new Padding(50, 10, 0, 5);
            btnDetail.Name = "btnDetail";
            btnDetail.Size = new Size(80, 80);
            btnDetail.TabIndex = 20;
            btnDetail.Text = "";
            btnDetail.TextAlign = ContentAlignment.MiddleRight;
            btnDetail.UseVisualStyleBackColor = false;
            btnDetail.Click += btnDetail_Click;
            // 
            // btnRemove
            // 
            btnRemove.AccessibleDescription = "C";
            btnRemove.Anchor = AnchorStyles.Right;
            btnRemove.BackColor = Color.FromArgb(255, 252, 235);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 20F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(819, 105);
            btnRemove.Margin = new Padding(15, 5, 15, 5);
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
            btnEdit.Anchor = AnchorStyles.Right;
            btnEdit.BackColor = Color.FromArgb(239, 250, 255);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 20F);
            btnEdit.ForeColor = Color.FromArgb(37, 99, 235);
            btnEdit.Location = new Point(927, 107);
            btnEdit.Margin = new Padding(8, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 21;
            btnEdit.Text = "";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblExp
            // 
            lblExp.AutoSize = true;
            lblExp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExp.ForeColor = Color.FromArgb(64, 64, 64);
            lblExp.Location = new Point(566, 184);
            lblExp.Margin = new Padding(5, 0, 5, 0);
            lblExp.Name = "lblExp";
            lblExp.Size = new Size(304, 45);
            lblExp.TabIndex = 12;
            lblExp.Text = "Kinh nghiệm: 5 năm";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDepartment.ForeColor = Color.FromArgb(64, 64, 64);
            lblDepartment.Location = new Point(29, 114);
            lblDepartment.Margin = new Padding(5, 0, 5, 0);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(349, 45);
            lblDepartment.TabIndex = 11;
            lblDepartment.Text = "Chuyên khoa: Nội khoa";
            lblDepartment.Visible = false;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = Color.FromArgb(64, 64, 64);
            lblPhone.Location = new Point(566, 114);
            lblPhone.Margin = new Padding(5, 0, 5, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(360, 45);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Số điện thoại: 09345678";
            // 
            // lblLicenseOrBHYT
            // 
            lblLicenseOrBHYT.AutoSize = true;
            lblLicenseOrBHYT.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLicenseOrBHYT.ForeColor = Color.FromArgb(64, 64, 64);
            lblLicenseOrBHYT.Location = new Point(29, 184);
            lblLicenseOrBHYT.Margin = new Padding(5, 0, 5, 0);
            lblLicenseOrBHYT.Name = "lblLicenseOrBHYT";
            lblLicenseOrBHYT.Size = new Size(287, 45);
            lblLicenseOrBHYT.TabIndex = 9;
            lblLicenseOrBHYT.Text = "Số CCHN: BS12345";
            // 
            // lblDeptOrCode
            // 
            lblDeptOrCode.AutoSize = true;
            lblDeptOrCode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeptOrCode.ForeColor = Color.FromArgb(64, 64, 64);
            lblDeptOrCode.Location = new Point(29, 119);
            lblDeptOrCode.Name = "lblDeptOrCode";
            lblDeptOrCode.Size = new Size(241, 45);
            lblDeptOrCode.TabIndex = 22;
            lblDeptOrCode.Text = "Chuyên khoa: ...";
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Font = new Font("Segoe UI", 12F);
            lblDob.ForeColor = Color.FromArgb(64, 64, 64);
            lblDob.Location = new Point(566, 184);
            lblDob.Margin = new Padding(5, 0, 5, 0);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(320, 45);
            lblDob.TabIndex = 11;
            lblDob.Text = "Ngày sinh: 15/3/1990";
            lblDob.Visible = false;
            // 
            // ucAdmin_UserItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlCard);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ucAdmin_UserItem";
            Padding = new Padding(16, 20, 16, 20);
            Size = new Size(1789, 286);
            flpHeader.ResumeLayout(false);
            flpHeader.PerformLayout();
            pnlRoleBadge.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblApproval;
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
