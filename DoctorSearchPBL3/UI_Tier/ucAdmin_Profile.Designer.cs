namespace UI_Tier
{
    partial class ucAdmin_Profile
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
            pnlMain = new Panel();
            pnlSecurity = new Panel();
            pnlChangePassword = new Panel();
            pnlPassActions = new Panel();
            btnCancelPass = new Button();
            btnSavePass = new Button();
            txtConfirmPass = new TextBox();
            lblConfirmPass = new Label();
            txtNewPass = new TextBox();
            lblNewPass = new Label();
            txtCurrentPass = new TextBox();
            lblCurrentPass = new Label();
            lblSecurityHint = new Label();
            btnChangePassword = new Button();
            lblSecurityTitle = new Label();
            pnlBasicInfo = new Panel();
            pnlBasicInfoActions = new Panel();
            btnCancelBasicInfo = new Button();
            btnSaveBasicInfo = new Button();
            txtCCCD = new TextBox();
            lblCCCD = new Label();
            txtGender = new TextBox();
            lblGender = new Label();
            dtpBirthday = new DateTimePicker();
            lblBirthday = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtRole = new TextBox();
            lblRole = new Label();
            lblAdminName = new Label();
            picAvatar = new PictureBox();
            btnEditBasicInfo = new Button();
            lblBasicInfoTitle = new Label();
            pnlMain.SuspendLayout();
            pnlSecurity.SuspendLayout();
            pnlChangePassword.SuspendLayout();
            pnlPassActions.SuspendLayout();
            pnlBasicInfo.SuspendLayout();
            pnlBasicInfoActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlSecurity);
            pnlMain.Controls.Add(pnlBasicInfo);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(4);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(65, 51, 65, 128);
            pnlMain.Size = new Size(1560, 1200);
            pnlMain.TabIndex = 0;
            // 
            // pnlSecurity
            // 
            pnlSecurity.BackColor = Color.White;
            pnlSecurity.Controls.Add(pnlChangePassword);
            pnlSecurity.Controls.Add(lblSecurityHint);
            pnlSecurity.Controls.Add(btnChangePassword);
            pnlSecurity.Controls.Add(lblSecurityTitle);
            pnlSecurity.Dock = DockStyle.Top;
            pnlSecurity.Location = new Point(65, 852);
            pnlSecurity.Margin = new Padding(4);
            pnlSecurity.Name = "pnlSecurity";
            pnlSecurity.Size = new Size(1396, 635);
            pnlSecurity.TabIndex = 1;
            pnlSecurity.Paint += SectionPanel_Paint;
            // 
            // pnlChangePassword
            // 
            pnlChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlChangePassword.Controls.Add(pnlPassActions);
            pnlChangePassword.Controls.Add(txtConfirmPass);
            pnlChangePassword.Controls.Add(lblConfirmPass);
            pnlChangePassword.Controls.Add(txtNewPass);
            pnlChangePassword.Controls.Add(lblNewPass);
            pnlChangePassword.Controls.Add(txtCurrentPass);
            pnlChangePassword.Controls.Add(lblCurrentPass);
            pnlChangePassword.Location = new Point(39, 115);
            pnlChangePassword.Margin = new Padding(4);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Size = new Size(1318, 505);
            pnlChangePassword.TabIndex = 3;
            // 
            // pnlPassActions
            // 
            pnlPassActions.Controls.Add(btnCancelPass);
            pnlPassActions.Controls.Add(btnSavePass);
            pnlPassActions.Location = new Point(52, 384);
            pnlPassActions.Margin = new Padding(4);
            pnlPassActions.Name = "pnlPassActions";
            pnlPassActions.Size = new Size(650, 77);
            pnlPassActions.TabIndex = 35;
            // 
            // btnCancelPass
            // 
            btnCancelPass.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelPass.FlatAppearance.BorderSize = 0;
            btnCancelPass.FlatStyle = FlatStyle.Flat;
            btnCancelPass.Font = new Font("Segoe UI", 11F);
            btnCancelPass.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelPass.Location = new Point(364, 6);
            btnCancelPass.Margin = new Padding(4);
            btnCancelPass.Name = "btnCancelPass";
            btnCancelPass.Size = new Size(195, 64);
            btnCancelPass.TabIndex = 1;
            btnCancelPass.Text = "✕ Hủy";
            btnCancelPass.UseVisualStyleBackColor = false;
            btnCancelPass.Click += btnCancelPass_Click;
            btnCancelPass.Paint += Button_Paint;
            // 
            // btnSavePass
            // 
            btnSavePass.BackColor = Color.FromArgb(37, 99, 235);
            btnSavePass.FlatAppearance.BorderSize = 0;
            btnSavePass.FlatStyle = FlatStyle.Flat;
            btnSavePass.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSavePass.ForeColor = Color.White;
            btnSavePass.Location = new Point(6, 6);
            btnSavePass.Margin = new Padding(4);
            btnSavePass.Name = "btnSavePass";
            btnSavePass.Size = new Size(325, 64);
            btnSavePass.TabIndex = 0;
            btnSavePass.Text = "💾 Lưu mật khẩu mới";
            btnSavePass.UseVisualStyleBackColor = false;
            btnSavePass.Click += btnSavePass_Click;
            btnSavePass.Paint += Button_Paint;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.Location = new Point(52, 307);
            txtConfirmPass.Margin = new Padding(4);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderText = "Nhập lại mật khẩu mới";
            txtConfirmPass.Size = new Size(1234, 50);
            txtConfirmPass.TabIndex = 33;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPass.Location = new Point(52, 262);
            lblConfirmPass.Margin = new Padding(4, 0, 4, 0);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(307, 37);
            lblConfirmPass.TabIndex = 32;
            lblConfirmPass.Text = "Xác nhận mật khẩu mới";
            // 
            // txtNewPass
            // 
            txtNewPass.BorderStyle = BorderStyle.FixedSingle;
            txtNewPass.Font = new Font("Segoe UI", 12F);
            txtNewPass.Location = new Point(52, 192);
            txtNewPass.Margin = new Padding(4);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PlaceholderText = "Nhập mật khẩu mới";
            txtNewPass.Size = new Size(1234, 50);
            txtNewPass.TabIndex = 30;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblNewPass.Location = new Point(52, 147);
            lblNewPass.Margin = new Padding(4, 0, 4, 0);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(188, 37);
            lblNewPass.TabIndex = 29;
            lblNewPass.Text = "Mật khẩu mới";
            // 
            // txtCurrentPass
            // 
            txtCurrentPass.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPass.Font = new Font("Segoe UI", 12F);
            txtCurrentPass.Location = new Point(52, 77);
            txtCurrentPass.Margin = new Padding(4);
            txtCurrentPass.Name = "txtCurrentPass";
            txtCurrentPass.PlaceholderText = "Nhập mật khẩu hiện tại";
            txtCurrentPass.Size = new Size(1234, 50);
            txtCurrentPass.TabIndex = 27;
            txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // lblCurrentPass
            // 
            lblCurrentPass.AutoSize = true;
            lblCurrentPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCurrentPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblCurrentPass.Location = new Point(52, 32);
            lblCurrentPass.Margin = new Padding(4, 0, 4, 0);
            lblCurrentPass.Name = "lblCurrentPass";
            lblCurrentPass.Size = new Size(231, 37);
            lblCurrentPass.TabIndex = 26;
            lblCurrentPass.Text = "Mật khẩu hiện tại";
            // 
            // lblSecurityHint
            // 
            lblSecurityHint.AutoSize = true;
            lblSecurityHint.Font = new Font("Segoe UI", 10F);
            lblSecurityHint.ForeColor = Color.Gray;
            lblSecurityHint.Location = new Point(39, 128);
            lblSecurityHint.Margin = new Padding(4, 0, 4, 0);
            lblSecurityHint.Name = "lblSecurityHint";
            lblSecurityHint.Size = new Size(632, 37);
            lblSecurityHint.TabIndex = 2;
            lblSecurityHint.Text = "Nhấn \"Đổi mật khẩu\" để cập nhật mật khẩu của bạn";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.FromArgb(37, 99, 235);
            btnChangePassword.Location = new Point(1045, 32);
            btnChangePassword.Margin = new Padding(4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(325, 58);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Text = "✎  Đổi mật khẩu";
            btnChangePassword.TextAlign = ContentAlignment.MiddleRight;
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // lblSecurityTitle
            // 
            lblSecurityTitle.AutoSize = true;
            lblSecurityTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSecurityTitle.Location = new Point(32, 32);
            lblSecurityTitle.Margin = new Padding(4, 0, 4, 0);
            lblSecurityTitle.Name = "lblSecurityTitle";
            lblSecurityTitle.Size = new Size(265, 59);
            lblSecurityTitle.TabIndex = 0;
            lblSecurityTitle.Text = "🔒 Bảo mật";
            // 
            // pnlBasicInfo
            // 
            pnlBasicInfo.BackColor = Color.White;
            pnlBasicInfo.Controls.Add(pnlBasicInfoActions);
            pnlBasicInfo.Controls.Add(txtCCCD);
            pnlBasicInfo.Controls.Add(lblCCCD);
            pnlBasicInfo.Controls.Add(txtGender);
            pnlBasicInfo.Controls.Add(lblGender);
            pnlBasicInfo.Controls.Add(dtpBirthday);
            pnlBasicInfo.Controls.Add(lblBirthday);
            pnlBasicInfo.Controls.Add(txtAddress);
            pnlBasicInfo.Controls.Add(lblAddress);
            pnlBasicInfo.Controls.Add(txtPhone);
            pnlBasicInfo.Controls.Add(lblPhone);
            pnlBasicInfo.Controls.Add(txtFullName);
            pnlBasicInfo.Controls.Add(lblFullName);
            pnlBasicInfo.Controls.Add(txtRole);
            pnlBasicInfo.Controls.Add(lblRole);
            pnlBasicInfo.Controls.Add(lblAdminName);
            pnlBasicInfo.Controls.Add(picAvatar);
            pnlBasicInfo.Controls.Add(btnEditBasicInfo);
            pnlBasicInfo.Controls.Add(lblBasicInfoTitle);
            pnlBasicInfo.Dock = DockStyle.Top;
            pnlBasicInfo.Location = new Point(65, 51);
            pnlBasicInfo.Margin = new Padding(4);
            pnlBasicInfo.Name = "pnlBasicInfo";
            pnlBasicInfo.Size = new Size(1396, 801);
            pnlBasicInfo.TabIndex = 0;
            pnlBasicInfo.Paint += SectionPanel_Paint;
            // 
            // pnlBasicInfoActions
            // 
            pnlBasicInfoActions.Controls.Add(btnCancelBasicInfo);
            pnlBasicInfoActions.Controls.Add(btnSaveBasicInfo);
            pnlBasicInfoActions.Location = new Point(32, 694);
            pnlBasicInfoActions.Margin = new Padding(4);
            pnlBasicInfoActions.Name = "pnlBasicInfoActions";
            pnlBasicInfoActions.Size = new Size(546, 90);
            pnlBasicInfoActions.TabIndex = 26;
            pnlBasicInfoActions.Visible = false;
            // 
            // btnCancelBasicInfo
            // 
            btnCancelBasicInfo.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelBasicInfo.FlatAppearance.BorderSize = 0;
            btnCancelBasicInfo.FlatStyle = FlatStyle.Flat;
            btnCancelBasicInfo.Font = new Font("Segoe UI", 11F);
            btnCancelBasicInfo.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelBasicInfo.Location = new Point(312, 6);
            btnCancelBasicInfo.Margin = new Padding(4);
            btnCancelBasicInfo.Name = "btnCancelBasicInfo";
            btnCancelBasicInfo.Size = new Size(195, 77);
            btnCancelBasicInfo.TabIndex = 1;
            btnCancelBasicInfo.Text = "✕ Hủy";
            btnCancelBasicInfo.UseVisualStyleBackColor = false;
            btnCancelBasicInfo.Click += btnCancelBasicInfo_Click;
            btnCancelBasicInfo.Paint += Button_Paint;
            // 
            // btnSaveBasicInfo
            // 
            btnSaveBasicInfo.BackColor = Color.FromArgb(37, 99, 235);
            btnSaveBasicInfo.FlatAppearance.BorderSize = 0;
            btnSaveBasicInfo.FlatStyle = FlatStyle.Flat;
            btnSaveBasicInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSaveBasicInfo.ForeColor = Color.White;
            btnSaveBasicInfo.Location = new Point(-9, 9);
            btnSaveBasicInfo.Margin = new Padding(4);
            btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            btnSaveBasicInfo.Size = new Size(286, 77);
            btnSaveBasicInfo.TabIndex = 0;
            btnSaveBasicInfo.Text = "💾 Lưu thay đổi";
            btnSaveBasicInfo.UseVisualStyleBackColor = false;
            btnSaveBasicInfo.Click += btnSaveBasicInfo_Click;
            btnSaveBasicInfo.Paint += Button_Paint;
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Segoe UI", 12F);
            txtCCCD.Location = new Point(1000, 486);
            txtCCCD.Margin = new Padding(4);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.ReadOnly = true;
            txtCCCD.Size = new Size(428, 50);
            txtCCCD.TabIndex = 15;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCCCD.ForeColor = Color.FromArgb(73, 80, 87);
            lblCCCD.Location = new Point(1000, 442);
            lblCCCD.Margin = new Padding(4, 0, 4, 0);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(123, 37);
            lblCCCD.TabIndex = 14;
            lblCCCD.Text = "Số CCCD";
            // 
            // txtGender
            // 
            txtGender.Font = new Font("Segoe UI", 12F);
            txtGender.Location = new Point(455, 486);
            txtGender.Margin = new Padding(4);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(428, 50);
            txtGender.TabIndex = 13;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(73, 80, 87);
            lblGender.Location = new Point(455, 442);
            lblGender.Margin = new Padding(4, 0, 4, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(123, 37);
            lblGender.TabIndex = 12;
            lblGender.Text = "Giới tính";
            // 
            // dtpBirthday
            // 
            dtpBirthday.CustomFormat = "dd / MM / yyyy";
            dtpBirthday.Font = new Font("Segoe UI", 12F);
            dtpBirthday.Format = DateTimePickerFormat.Custom;
            dtpBirthday.Location = new Point(1000, 358);
            dtpBirthday.Margin = new Padding(4);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(428, 50);
            dtpBirthday.TabIndex = 11;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBirthday.ForeColor = Color.FromArgb(73, 80, 87);
            lblBirthday.Location = new Point(1000, 314);
            lblBirthday.Margin = new Padding(4, 0, 4, 0);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(140, 37);
            lblBirthday.TabIndex = 10;
            lblBirthday.Text = "Ngày sinh";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(455, 615);
            txtAddress.Margin = new Padding(4);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(941, 50);
            txtAddress.TabIndex = 9;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(73, 80, 87);
            lblAddress.Location = new Point(455, 574);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 37);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(1000, 230);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(500, 50);
            txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblPhone.Location = new Point(1000, 186);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(178, 37);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(455, 230);
            txtFullName.Margin = new Padding(4);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(428, 50);
            txtFullName.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(73, 80, 87);
            lblFullName.Location = new Point(455, 186);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(135, 37);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên";
            // 
            // txtRole
            // 
            txtRole.Font = new Font("Segoe UI", 12F);
            txtRole.Location = new Point(455, 358);
            txtRole.Margin = new Padding(4);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(428, 50);
            txtRole.TabIndex = 17;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(73, 80, 87);
            lblRole.Location = new Point(455, 314);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(96, 37);
            lblRole.TabIndex = 16;
            lblRole.Text = "Vai trò";
            // 
            // lblAdminName
            // 
            lblAdminName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblAdminName.Location = new Point(32, 538);
            lblAdminName.Margin = new Padding(4, 0, 4, 0);
            lblAdminName.Name = "lblAdminName";
            lblAdminName.Size = new Size(325, 64);
            lblAdminName.TabIndex = 3;
            lblAdminName.Text = "Admin";
            lblAdminName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(241, 243, 245);
            picAvatar.Location = new Point(32, 154);
            picAvatar.Margin = new Padding(4);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(325, 320);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 2;
            picAvatar.TabStop = false;
            // 
            // btnEditBasicInfo
            // 
            btnEditBasicInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditBasicInfo.FlatAppearance.BorderSize = 0;
            btnEditBasicInfo.FlatStyle = FlatStyle.Flat;
            btnEditBasicInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEditBasicInfo.ForeColor = Color.FromArgb(37, 99, 235);
            btnEditBasicInfo.Location = new Point(1045, 32);
            btnEditBasicInfo.Margin = new Padding(4);
            btnEditBasicInfo.Name = "btnEditBasicInfo";
            btnEditBasicInfo.Size = new Size(325, 58);
            btnEditBasicInfo.TabIndex = 1;
            btnEditBasicInfo.Text = "✎  Chỉnh sửa";
            btnEditBasicInfo.TextAlign = ContentAlignment.MiddleRight;
            btnEditBasicInfo.UseVisualStyleBackColor = true;
            btnEditBasicInfo.Click += btnEditBasicInfo_Click;
            // 
            // lblBasicInfoTitle
            // 
            lblBasicInfoTitle.AutoSize = true;
            lblBasicInfoTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBasicInfoTitle.Location = new Point(32, 32);
            lblBasicInfoTitle.Margin = new Padding(4, 0, 4, 0);
            lblBasicInfoTitle.Name = "lblBasicInfoTitle";
            lblBasicInfoTitle.Size = new Size(463, 59);
            lblBasicInfoTitle.TabIndex = 0;
            lblBasicInfoTitle.Text = "👤 Thông tin cá nhân";
            // 
            // ucAdmin_Profile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Margin = new Padding(4);
            Name = "ucAdmin_Profile";
            Size = new Size(1560, 1200);
            pnlMain.ResumeLayout(false);
            pnlSecurity.ResumeLayout(false);
            pnlSecurity.PerformLayout();
            pnlChangePassword.ResumeLayout(false);
            pnlChangePassword.PerformLayout();
            pnlPassActions.ResumeLayout(false);
            pnlBasicInfo.ResumeLayout(false);
            pnlBasicInfo.PerformLayout();
            pnlBasicInfoActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlMain;
        private Panel pnlSecurity;
        private Label lblSecurityTitle;
        private Button btnChangePassword;
        private Label lblSecurityHint;
        private Panel pnlChangePassword;
        private Label lblCurrentPass;
        private TextBox txtCurrentPass;
        private Label lblNewPass;
        private TextBox txtNewPass;
        private Label lblConfirmPass;
        private TextBox txtConfirmPass;
        private Panel pnlPassActions;
        private Button btnSavePass;
        private Button btnCancelPass;
        private Panel pnlBasicInfo;
        private Label lblBasicInfoTitle;
        private Button btnEditBasicInfo;
        private PictureBox picAvatar;
        private Label lblAdminName;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblBirthday;
        private DateTimePicker dtpBirthday;
        private Label lblGender;
        private TextBox txtGender;
        private Label lblCCCD;
        private TextBox txtCCCD;
        private Label lblRole;
        private TextBox txtRole;
        private Panel pnlBasicInfoActions;
        private Button btnSaveBasicInfo;
        private Button btnCancelBasicInfo;
    }
}
