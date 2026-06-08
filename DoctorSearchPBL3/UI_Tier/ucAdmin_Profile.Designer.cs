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
            lblUpload = new Label();
            pnlMain = new Panel();
            pnlSecurity = new Panel();
            pnlChangePassword = new Panel();
            pnlPassActions = new Panel();
            btnCancelPass = new Button();
            btnSavePass = new Button();
            lblPasswordRuleHint = new Label();
            pnlCurrentPassBorder = new Panel();
            txtCurrentPass = new TextBox();
            pnlNewPassBorder = new Panel();
            txtNewPass = new TextBox();
            pnlConfirmPassBorder = new Panel();
            txtConfirmPass = new TextBox();
            lblConfirmPass = new Label();
            lblNewPass = new Label();
            lblCurrentPass = new Label();
            lblSecurityHint = new Label();
            btnChangePassword = new Button();
            lblSecurityTitle = new Label();
            pnlBasicInfo = new Panel();
            lblAddressRuleHint = new Label();
            lblCccdRuleHint = new Label();
            lblGenderRuleHint = new Label();
            lblBirthdayRuleHint = new Label();
            lblPhoneRuleHint = new Label();
            lblFullNameRuleHint = new Label();
            pnlBasicInfoActions = new Panel();
            btnCancelBasicInfo = new Button();
            btnSaveBasicInfo = new Button();
            pnlFullNameBorder = new Panel();
            txtFullName = new TextBox();
            pnlPhoneBorder = new Panel();
            txtPhone = new TextBox();
            pnlRoleBorder = new Panel();
            txtRole = new TextBox();
            pnlGenderBorder = new Panel();
            txtGender = new TextBox();
            pnlBirthdayBorder = new Panel();
            dtpBirthday = new DateTimePicker();
            pnlCCCDBorder = new Panel();
            txtCCCD = new TextBox();
            pnlAddressBorder = new Panel();
            txtAddress = new TextBox();
            lblCCCD = new Label();
            lblGender = new Label();
            lblBirthday = new Label();
            lblAddress = new Label();
            lblPhone = new Label();
            lblFullName = new Label();
            lblRole = new Label();
            lblAdminName = new Label();
            picAvatar = new PictureBox();
            btnEditBasicInfo = new Button();
            lblBasicInfoTitle = new Label();
            pnlMain.SuspendLayout();
            pnlSecurity.SuspendLayout();
            pnlChangePassword.SuspendLayout();
            pnlPassActions.SuspendLayout();
            pnlCurrentPassBorder.SuspendLayout();
            pnlNewPassBorder.SuspendLayout();
            pnlConfirmPassBorder.SuspendLayout();
            pnlBasicInfo.SuspendLayout();
            pnlBasicInfoActions.SuspendLayout();
            pnlFullNameBorder.SuspendLayout();
            pnlPhoneBorder.SuspendLayout();
            pnlRoleBorder.SuspendLayout();
            pnlGenderBorder.SuspendLayout();
            pnlBirthdayBorder.SuspendLayout();
            pnlCCCDBorder.SuspendLayout();
            pnlAddressBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // lblUpload
            // 
            lblUpload.BackColor = Color.FromArgb(200, 37, 99, 235);
            lblUpload.Cursor = Cursors.Hand;
            lblUpload.Font = new Font("Segoe MDL2 Assets", 18F);
            lblUpload.ForeColor = Color.White;
            lblUpload.Location = new Point(265, 324);
            lblUpload.Margin = new Padding(2, 0, 2, 0);
            lblUpload.Name = "lblUpload";
            lblUpload.Size = new Size(42, 51);
            lblUpload.TabIndex = 27;
            lblUpload.Text = "îœ¢";
            lblUpload.TextAlign = ContentAlignment.MiddleCenter;
            lblUpload.Visible = false;
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlSecurity);
            pnlMain.Controls.Add(pnlBasicInfo);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(15, 16, 15, 100);
            pnlMain.Size = new Size(1615, 1328);
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
            pnlSecurity.Location = new Point(15, 641);
            pnlSecurity.Margin = new Padding(0, 0, 0, 30);
            pnlSecurity.Name = "pnlSecurity";
            pnlSecurity.Size = new Size(1585, 474);
            pnlSecurity.TabIndex = 2;
            pnlSecurity.Paint += SectionPanel_Paint;
            // 
            // pnlChangePassword
            // 
            pnlChangePassword.Controls.Add(pnlPassActions);
            pnlChangePassword.Controls.Add(lblPasswordRuleHint);
            pnlChangePassword.Controls.Add(pnlCurrentPassBorder);
            pnlChangePassword.Controls.Add(pnlNewPassBorder);
            pnlChangePassword.Controls.Add(pnlConfirmPassBorder);
            pnlChangePassword.Controls.Add(lblConfirmPass);
            pnlChangePassword.Controls.Add(lblNewPass);
            pnlChangePassword.Controls.Add(lblCurrentPass);
            pnlChangePassword.Location = new Point(29, 70);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Size = new Size(1552, 414);
            pnlChangePassword.TabIndex = 3;
            pnlChangePassword.Visible = false;
            // 
            // pnlPassActions
            // 
            pnlPassActions.Controls.Add(btnCancelPass);
            pnlPassActions.Controls.Add(btnSavePass);
            pnlPassActions.Location = new Point(40, 336);
            pnlPassActions.Name = "pnlPassActions";
            pnlPassActions.Size = new Size(457, 70);
            pnlPassActions.TabIndex = 35;
            // 
            // btnCancelPass
            // 
            btnCancelPass.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelPass.FlatAppearance.BorderSize = 0;
            btnCancelPass.FlatStyle = FlatStyle.Flat;
            btnCancelPass.Font = new Font("Segoe UI", 16F);
            btnCancelPass.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelPass.Location = new Point(292, 5);
            btnCancelPass.Name = "btnCancelPass";
            btnCancelPass.Size = new Size(150, 62);
            btnCancelPass.TabIndex = 1;
            btnCancelPass.Text = "✕  Hủy";
            btnCancelPass.UseVisualStyleBackColor = false;
            btnCancelPass.Click += btnCancelPass_Click;
            btnCancelPass.Paint += Button_Paint;
            // 
            // btnSavePass
            // 
            btnSavePass.BackColor = Color.FromArgb(37, 99, 235);
            btnSavePass.FlatAppearance.BorderSize = 0;
            btnSavePass.FlatStyle = FlatStyle.Flat;
            btnSavePass.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnSavePass.ForeColor = Color.White;
            btnSavePass.Location = new Point(5, 5);
            btnSavePass.Name = "btnSavePass";
            btnSavePass.Size = new Size(281, 62);
            btnSavePass.TabIndex = 0;
            btnSavePass.Text = "💾  Lưu thay đổi";
            btnSavePass.UseVisualStyleBackColor = false;
            btnSavePass.Click += btnSavePass_Click;
            btnSavePass.Paint += Button_Paint;
            // 
            // lblPasswordRuleHint
            // 
            lblPasswordRuleHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblPasswordRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPasswordRuleHint.Location = new Point(40, 301);
            lblPasswordRuleHint.Margin = new Padding(2, 0, 2, 0);
            lblPasswordRuleHint.Name = "lblPasswordRuleHint";
            lblPasswordRuleHint.Size = new Size(1015, 33);
            lblPasswordRuleHint.TabIndex = 39;
            lblPasswordRuleHint.Text = "Mật khẩu: 8-64 ký tự, có chữ hoa/thường, số, ký tự đặc biệt; không chứa khoảng trắng, SĐT hoặc họ tên.";
            // 
            // pnlCurrentPassBorder
            // 
            pnlCurrentPassBorder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCurrentPassBorder.BackColor = Color.White;
            pnlCurrentPassBorder.Controls.Add(txtCurrentPass);
            pnlCurrentPassBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlCurrentPassBorder.Location = new Point(29, 48);
            pnlCurrentPassBorder.Margin = new Padding(2);
            pnlCurrentPassBorder.MaximumSize = new Size(1031, 49);
            pnlCurrentPassBorder.Name = "pnlCurrentPassBorder";
            pnlCurrentPassBorder.Padding = new Padding(8);
            pnlCurrentPassBorder.Size = new Size(1018, 49);
            pnlCurrentPassBorder.TabIndex = 36;
            // 
            // txtCurrentPass
            // 
            txtCurrentPass.BorderStyle = BorderStyle.None;
            txtCurrentPass.Dock = DockStyle.Fill;
            txtCurrentPass.Font = new Font("Segoe UI", 12F);
            txtCurrentPass.Location = new Point(8, 8);
            txtCurrentPass.MaximumSize = new Size(1015, 45);
            txtCurrentPass.Name = "txtCurrentPass";
            txtCurrentPass.PlaceholderText = "Nhập mật khẩu hiện tại";
            txtCurrentPass.Size = new Size(1002, 32);
            txtCurrentPass.TabIndex = 27;
            txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // pnlNewPassBorder
            // 
            pnlNewPassBorder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlNewPassBorder.BackColor = Color.White;
            pnlNewPassBorder.Controls.Add(txtNewPass);
            pnlNewPassBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlNewPassBorder.Location = new Point(29, 148);
            pnlNewPassBorder.Margin = new Padding(2);
            pnlNewPassBorder.MaximumSize = new Size(1031, 49);
            pnlNewPassBorder.Name = "pnlNewPassBorder";
            pnlNewPassBorder.Padding = new Padding(8);
            pnlNewPassBorder.Size = new Size(1018, 49);
            pnlNewPassBorder.TabIndex = 37;
            // 
            // txtNewPass
            // 
            txtNewPass.BorderStyle = BorderStyle.None;
            txtNewPass.Dock = DockStyle.Fill;
            txtNewPass.Font = new Font("Segoe UI", 12F);
            txtNewPass.Location = new Point(8, 8);
            txtNewPass.MaximumSize = new Size(1015, 45);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PlaceholderText = "Mật khẩu mới theo đúng quy định bảo mật";
            txtNewPass.Size = new Size(1002, 32);
            txtNewPass.TabIndex = 30;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // pnlConfirmPassBorder
            // 
            pnlConfirmPassBorder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlConfirmPassBorder.BackColor = Color.White;
            pnlConfirmPassBorder.Controls.Add(txtConfirmPass);
            pnlConfirmPassBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlConfirmPassBorder.Location = new Point(29, 249);
            pnlConfirmPassBorder.Margin = new Padding(2);
            pnlConfirmPassBorder.MaximumSize = new Size(1031, 49);
            pnlConfirmPassBorder.Name = "pnlConfirmPassBorder";
            pnlConfirmPassBorder.Padding = new Padding(8);
            pnlConfirmPassBorder.Size = new Size(1018, 49);
            pnlConfirmPassBorder.TabIndex = 38;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BorderStyle = BorderStyle.None;
            txtConfirmPass.Dock = DockStyle.Fill;
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.Location = new Point(8, 8);
            txtConfirmPass.MaximumSize = new Size(1015, 45);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderText = "Nhập lại đúng mật khẩu mới";
            txtConfirmPass.Size = new Size(1002, 32);
            txtConfirmPass.TabIndex = 33;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPass.Location = new Point(37, 212);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(333, 32);
            lblConfirmPass.TabIndex = 32;
            lblConfirmPass.Text = "✅ Xác nhận mật khẩu mới *";
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblNewPass.Location = new Point(40, 111);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(226, 32);
            lblNewPass.TabIndex = 29;
            lblNewPass.Text = "🆕 Mật khẩu mới *";
            // 
            // lblCurrentPass
            // 
            lblCurrentPass.AutoSize = true;
            lblCurrentPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCurrentPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblCurrentPass.Location = new Point(40, 10);
            lblCurrentPass.Name = "lblCurrentPass";
            lblCurrentPass.Size = new Size(266, 32);
            lblCurrentPass.TabIndex = 26;
            lblCurrentPass.Text = "🔑 Mật khẩu hiện tại *";
            // 
            // lblSecurityHint
            // 
            lblSecurityHint.AutoSize = true;
            lblSecurityHint.Font = new Font("Segoe UI", 10F);
            lblSecurityHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblSecurityHint.Location = new Point(30, 85);
            lblSecurityHint.Name = "lblSecurityHint";
            lblSecurityHint.Size = new Size(623, 28);
            lblSecurityHint.TabIndex = 2;
            lblSecurityHint.Text = "Mật khẩu mới cần 8-64 ký tự, có chữ hoa/thường, số và ký tự đặc biệt.";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.FromArgb(37, 99, 235);
            btnChangePassword.Location = new Point(1308, 9);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(238, 58);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Text = "Đổi mật khẩu";
            btnChangePassword.TextAlign = ContentAlignment.MiddleRight;
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // lblSecurityTitle
            // 
            lblSecurityTitle.AutoSize = true;
            lblSecurityTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSecurityTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblSecurityTitle.Location = new Point(20, 20);
            lblSecurityTitle.Name = "lblSecurityTitle";
            lblSecurityTitle.Size = new Size(199, 45);
            lblSecurityTitle.TabIndex = 0;
            lblSecurityTitle.Text = "🔒 Bảo mật";
            // 
            // pnlBasicInfo
            // 
            pnlBasicInfo.BackColor = Color.White;
            pnlBasicInfo.Controls.Add(lblAddressRuleHint);
            pnlBasicInfo.Controls.Add(lblCccdRuleHint);
            pnlBasicInfo.Controls.Add(lblGenderRuleHint);
            pnlBasicInfo.Controls.Add(lblBirthdayRuleHint);
            pnlBasicInfo.Controls.Add(lblPhoneRuleHint);
            pnlBasicInfo.Controls.Add(lblFullNameRuleHint);
            pnlBasicInfo.Controls.Add(pnlBasicInfoActions);
            pnlBasicInfo.Controls.Add(pnlFullNameBorder);
            pnlBasicInfo.Controls.Add(pnlPhoneBorder);
            pnlBasicInfo.Controls.Add(pnlRoleBorder);
            pnlBasicInfo.Controls.Add(pnlGenderBorder);
            pnlBasicInfo.Controls.Add(pnlBirthdayBorder);
            pnlBasicInfo.Controls.Add(pnlCCCDBorder);
            pnlBasicInfo.Controls.Add(pnlAddressBorder);
            pnlBasicInfo.Controls.Add(lblCCCD);
            pnlBasicInfo.Controls.Add(lblGender);
            pnlBasicInfo.Controls.Add(lblBirthday);
            pnlBasicInfo.Controls.Add(lblAddress);
            pnlBasicInfo.Controls.Add(lblPhone);
            pnlBasicInfo.Controls.Add(lblFullName);
            pnlBasicInfo.Controls.Add(lblRole);
            pnlBasicInfo.Controls.Add(lblAdminName);
            pnlBasicInfo.Controls.Add(picAvatar);
            pnlBasicInfo.Controls.Add(lblUpload);
            pnlBasicInfo.Controls.Add(btnEditBasicInfo);
            pnlBasicInfo.Controls.Add(lblBasicInfoTitle);
            pnlBasicInfo.Dock = DockStyle.Top;
            pnlBasicInfo.Location = new Point(15, 16);
            pnlBasicInfo.Name = "pnlBasicInfo";
            pnlBasicInfo.Size = new Size(1585, 625);
            pnlBasicInfo.TabIndex = 0;
            pnlBasicInfo.Paint += SectionPanel_Paint;
            // 
            // lblAddressRuleHint
            // 
            lblAddressRuleHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblAddressRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblAddressRuleHint.Location = new Point(338, 502);
            lblAddressRuleHint.Margin = new Padding(2, 0, 2, 0);
            lblAddressRuleHint.Name = "lblAddressRuleHint";
            lblAddressRuleHint.Size = new Size(1208, 28);
            lblAddressRuleHint.TabIndex = 40;
            lblAddressRuleHint.Text = "Địa chỉ: 5-255 ký tự, không chứa ký tự điều khiển.";
            // 
            // lblCccdRuleHint
            // 
            lblCccdRuleHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblCccdRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblCccdRuleHint.Location = new Point(954, 392);
            lblCccdRuleHint.Margin = new Padding(2, 0, 2, 0);
            lblCccdRuleHint.Name = "lblCccdRuleHint";
            lblCccdRuleHint.Size = new Size(592, 28);
            lblCccdRuleHint.TabIndex = 41;
            lblCccdRuleHint.Text = "CCCD: bắt buộc đúng 12 chữ số.";
            // 
            // lblGenderRuleHint
            // 
            lblGenderRuleHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblGenderRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblGenderRuleHint.Location = new Point(338, 392);
            lblGenderRuleHint.Margin = new Padding(2, 0, 2, 0);
            lblGenderRuleHint.Name = "lblGenderRuleHint";
            lblGenderRuleHint.Size = new Size(592, 28);
            lblGenderRuleHint.TabIndex = 42;
            lblGenderRuleHint.Text = "Giới tính: chỉ nhập Nam hoặc Nữ.";
            // 
            // lblBirthdayRuleHint
            // 
            lblBirthdayRuleHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblBirthdayRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblBirthdayRuleHint.Location = new Point(954, 283);
            lblBirthdayRuleHint.Margin = new Padding(2, 0, 2, 0);
            lblBirthdayRuleHint.Name = "lblBirthdayRuleHint";
            lblBirthdayRuleHint.Size = new Size(592, 28);
            lblBirthdayRuleHint.TabIndex = 43;
            lblBirthdayRuleHint.Text = "Ngày sinh: quản trị viên phải từ 18 tuổi trở lên.";
            // 
            // lblPhoneRuleHint
            // 
            lblPhoneRuleHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblPhoneRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPhoneRuleHint.Location = new Point(954, 173);
            lblPhoneRuleHint.Margin = new Padding(2, 0, 2, 0);
            lblPhoneRuleHint.Name = "lblPhoneRuleHint";
            lblPhoneRuleHint.Size = new Size(592, 33);
            lblPhoneRuleHint.TabIndex = 44;
            lblPhoneRuleHint.Text = "SĐT: đúng 10 chữ số, bắt đầu bằng 0 và không trùng tài khoản khác.";
            // 
            // lblFullNameRuleHint
            // 
            lblFullNameRuleHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblFullNameRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblFullNameRuleHint.Location = new Point(338, 173);
            lblFullNameRuleHint.Margin = new Padding(2, 0, 2, 0);
            lblFullNameRuleHint.Name = "lblFullNameRuleHint";
            lblFullNameRuleHint.Size = new Size(592, 28);
            lblFullNameRuleHint.TabIndex = 45;
            lblFullNameRuleHint.Text = "Họ tên: 2-100 ký tự, chỉ dùng chữ cái và khoảng trắng.";
            // 
            // pnlBasicInfoActions
            // 
            pnlBasicInfoActions.Controls.Add(btnCancelBasicInfo);
            pnlBasicInfoActions.Controls.Add(btnSaveBasicInfo);
            pnlBasicInfoActions.Location = new Point(38, 539);
            pnlBasicInfoActions.Name = "pnlBasicInfoActions";
            pnlBasicInfoActions.Size = new Size(478, 70);
            pnlBasicInfoActions.TabIndex = 26;
            pnlBasicInfoActions.Visible = false;
            // 
            // btnCancelBasicInfo
            // 
            btnCancelBasicInfo.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelBasicInfo.FlatAppearance.BorderSize = 0;
            btnCancelBasicInfo.FlatStyle = FlatStyle.Flat;
            btnCancelBasicInfo.Font = new Font("Segoe UI", 16F);
            btnCancelBasicInfo.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelBasicInfo.Location = new Point(322, 7);
            btnCancelBasicInfo.Name = "btnCancelBasicInfo";
            btnCancelBasicInfo.Size = new Size(150, 60);
            btnCancelBasicInfo.TabIndex = 1;
            btnCancelBasicInfo.Text = "✕  Hủy";
            btnCancelBasicInfo.UseVisualStyleBackColor = false;
            btnCancelBasicInfo.Click += btnCancelBasicInfo_Click;
            btnCancelBasicInfo.Paint += Button_Paint;
            // 
            // btnSaveBasicInfo
            // 
            btnSaveBasicInfo.BackColor = Color.FromArgb(37, 99, 235);
            btnSaveBasicInfo.FlatAppearance.BorderSize = 0;
            btnSaveBasicInfo.FlatStyle = FlatStyle.Flat;
            btnSaveBasicInfo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnSaveBasicInfo.ForeColor = Color.White;
            btnSaveBasicInfo.Location = new Point(5, 7);
            btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            btnSaveBasicInfo.Size = new Size(311, 60);
            btnSaveBasicInfo.TabIndex = 0;
            btnSaveBasicInfo.Text = "💾  Lưu thay đổi";
            btnSaveBasicInfo.UseVisualStyleBackColor = false;
            btnSaveBasicInfo.Click += btnSaveBasicInfo_Click;
            btnSaveBasicInfo.Paint += Button_Paint;
            // 
            // pnlFullNameBorder
            // 
            pnlFullNameBorder.BackColor = Color.White;
            pnlFullNameBorder.Controls.Add(txtFullName);
            pnlFullNameBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlFullNameBorder.Location = new Point(338, 117);
            pnlFullNameBorder.Margin = new Padding(2);
            pnlFullNameBorder.Name = "pnlFullNameBorder";
            pnlFullNameBorder.Padding = new Padding(8);
            pnlFullNameBorder.Size = new Size(592, 49);
            pnlFullNameBorder.TabIndex = 27;
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Dock = DockStyle.Fill;
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(8, 8);
            txtFullName.Margin = new Padding(2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(576, 32);
            txtFullName.TabIndex = 5;
            // 
            // pnlPhoneBorder
            // 
            pnlPhoneBorder.BackColor = Color.White;
            pnlPhoneBorder.Controls.Add(txtPhone);
            pnlPhoneBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlPhoneBorder.Location = new Point(954, 117);
            pnlPhoneBorder.Margin = new Padding(2);
            pnlPhoneBorder.Name = "pnlPhoneBorder";
            pnlPhoneBorder.Padding = new Padding(8);
            pnlPhoneBorder.Size = new Size(592, 49);
            pnlPhoneBorder.TabIndex = 28;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = SystemColors.Window;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(8, 8);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(576, 32);
            txtPhone.TabIndex = 7;
            // 
            // pnlRoleBorder
            // 
            pnlRoleBorder.BackColor = Color.White;
            pnlRoleBorder.Controls.Add(txtRole);
            pnlRoleBorder.Font = new Font("Segoe UI", 12F);
            pnlRoleBorder.Location = new Point(338, 227);
            pnlRoleBorder.Margin = new Padding(2);
            pnlRoleBorder.Name = "pnlRoleBorder";
            pnlRoleBorder.Padding = new Padding(8);
            pnlRoleBorder.Size = new Size(592, 49);
            pnlRoleBorder.TabIndex = 29;
            // 
            // txtRole
            // 
            txtRole.BorderStyle = BorderStyle.None;
            txtRole.Dock = DockStyle.Fill;
            txtRole.Font = new Font("Segoe UI", 12F);
            txtRole.Location = new Point(8, 8);
            txtRole.Margin = new Padding(2);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(576, 32);
            txtRole.TabIndex = 17;
            // 
            // pnlGenderBorder
            // 
            pnlGenderBorder.BackColor = Color.White;
            pnlGenderBorder.Controls.Add(txtGender);
            pnlGenderBorder.Font = new Font("Segoe UI", 12F);
            pnlGenderBorder.Location = new Point(338, 336);
            pnlGenderBorder.Margin = new Padding(2);
            pnlGenderBorder.Name = "pnlGenderBorder";
            pnlGenderBorder.Padding = new Padding(8);
            pnlGenderBorder.Size = new Size(592, 49);
            pnlGenderBorder.TabIndex = 30;
            // 
            // txtGender
            // 
            txtGender.BorderStyle = BorderStyle.None;
            txtGender.Dock = DockStyle.Fill;
            txtGender.Font = new Font("Segoe UI", 12F);
            txtGender.Location = new Point(8, 8);
            txtGender.Margin = new Padding(2);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(576, 32);
            txtGender.TabIndex = 13;
            // 
            // pnlBirthdayBorder
            // 
            pnlBirthdayBorder.BackColor = Color.White;
            pnlBirthdayBorder.Controls.Add(dtpBirthday);
            pnlBirthdayBorder.Font = new Font("Segoe UI", 12F);
            pnlBirthdayBorder.Location = new Point(954, 227);
            pnlBirthdayBorder.Margin = new Padding(2);
            pnlBirthdayBorder.Name = "pnlBirthdayBorder";
            pnlBirthdayBorder.Padding = new Padding(8, 4, 8, 4);
            pnlBirthdayBorder.Size = new Size(592, 47);
            pnlBirthdayBorder.TabIndex = 31;
            // 
            // dtpBirthday
            // 
            dtpBirthday.CustomFormat = "dd / MM / yyyy";
            dtpBirthday.Dock = DockStyle.Fill;
            dtpBirthday.Font = new Font("Segoe UI", 12F);
            dtpBirthday.Format = DateTimePickerFormat.Custom;
            dtpBirthday.Location = new Point(8, 4);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(576, 39);
            dtpBirthday.TabIndex = 11;
            // 
            // pnlCCCDBorder
            // 
            pnlCCCDBorder.BackColor = Color.White;
            pnlCCCDBorder.Controls.Add(txtCCCD);
            pnlCCCDBorder.Font = new Font("Segoe UI", 12F);
            pnlCCCDBorder.Location = new Point(954, 336);
            pnlCCCDBorder.Margin = new Padding(2);
            pnlCCCDBorder.Name = "pnlCCCDBorder";
            pnlCCCDBorder.Padding = new Padding(8);
            pnlCCCDBorder.Size = new Size(592, 49);
            pnlCCCDBorder.TabIndex = 32;
            // 
            // txtCCCD
            // 
            txtCCCD.BorderStyle = BorderStyle.None;
            txtCCCD.Dock = DockStyle.Fill;
            txtCCCD.Font = new Font("Segoe UI", 12F);
            txtCCCD.Location = new Point(8, 8);
            txtCCCD.Margin = new Padding(2);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(576, 32);
            txtCCCD.TabIndex = 15;
            // 
            // pnlAddressBorder
            // 
            pnlAddressBorder.BackColor = Color.White;
            pnlAddressBorder.Controls.Add(txtAddress);
            pnlAddressBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlAddressBorder.Location = new Point(338, 445);
            pnlAddressBorder.Margin = new Padding(2);
            pnlAddressBorder.Name = "pnlAddressBorder";
            pnlAddressBorder.Padding = new Padding(8);
            pnlAddressBorder.Size = new Size(1208, 49);
            pnlAddressBorder.TabIndex = 33;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(8, 8);
            txtAddress.Margin = new Padding(2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(1192, 32);
            txtAddress.TabIndex = 9;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCCCD.ForeColor = Color.FromArgb(73, 80, 87);
            lblCCCD.Location = new Point(962, 297);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(108, 32);
            lblCCCD.TabIndex = 14;
            lblCCCD.Text = "Số CCCD";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(73, 80, 87);
            lblGender.Location = new Point(346, 297);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(108, 32);
            lblGender.TabIndex = 12;
            lblGender.Text = "Giới tính";
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBirthday.ForeColor = Color.FromArgb(73, 80, 87);
            lblBirthday.Location = new Point(962, 188);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(122, 32);
            lblBirthday.TabIndex = 10;
            lblBirthday.Text = "Ngày sinh";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(73, 80, 87);
            lblAddress.Location = new Point(346, 406);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(88, 32);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Địa chỉ";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblPhone.Location = new Point(962, 78);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(159, 32);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(73, 80, 87);
            lblFullName.Location = new Point(346, 78);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(121, 32);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(73, 80, 87);
            lblRole.Location = new Point(346, 188);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(92, 32);
            lblRole.TabIndex = 16;
            lblRole.Text = "Vai trò ";
            // 
            // lblAdminName
            // 
            lblAdminName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblAdminName.Location = new Point(38, 375);
            lblAdminName.Name = "lblAdminName";
            lblAdminName.Size = new Size(269, 31);
            lblAdminName.TabIndex = 3;
            lblAdminName.Text = "Admin";
            lblAdminName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(241, 243, 245);
            picAvatar.Location = new Point(38, 94);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(269, 281);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 2;
            picAvatar.TabStop = false;
            // 
            // btnEditBasicInfo
            // 
            btnEditBasicInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditBasicInfo.FlatAppearance.BorderSize = 0;
            btnEditBasicInfo.FlatStyle = FlatStyle.Flat;
            btnEditBasicInfo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnEditBasicInfo.ForeColor = Color.FromArgb(37, 99, 235);
            btnEditBasicInfo.Location = new Point(1354, 24);
            btnEditBasicInfo.Name = "btnEditBasicInfo";
            btnEditBasicInfo.Size = new Size(192, 47);
            btnEditBasicInfo.TabIndex = 1;
            btnEditBasicInfo.Text = "Chỉnh sửa ";
            btnEditBasicInfo.TextAlign = ContentAlignment.MiddleRight;
            btnEditBasicInfo.UseVisualStyleBackColor = true;
            btnEditBasicInfo.Click += btnEditBasicInfo_Click;
            // 
            // lblBasicInfoTitle
            // 
            lblBasicInfoTitle.AutoSize = true;
            lblBasicInfoTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBasicInfoTitle.Location = new Point(25, 25);
            lblBasicInfoTitle.Name = "lblBasicInfoTitle";
            lblBasicInfoTitle.Size = new Size(329, 45);
            lblBasicInfoTitle.TabIndex = 0;
            lblBasicInfoTitle.Text = "👤 Thông tin cơ bản";
            // 
            // ucAdmin_Profile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucAdmin_Profile";
            Size = new Size(1615, 1328);
            pnlMain.ResumeLayout(false);
            pnlSecurity.ResumeLayout(false);
            pnlSecurity.PerformLayout();
            pnlChangePassword.ResumeLayout(false);
            pnlChangePassword.PerformLayout();
            pnlPassActions.ResumeLayout(false);
            pnlCurrentPassBorder.ResumeLayout(false);
            pnlCurrentPassBorder.PerformLayout();
            pnlNewPassBorder.ResumeLayout(false);
            pnlNewPassBorder.PerformLayout();
            pnlConfirmPassBorder.ResumeLayout(false);
            pnlConfirmPassBorder.PerformLayout();
            pnlBasicInfo.ResumeLayout(false);
            pnlBasicInfo.PerformLayout();
            pnlBasicInfoActions.ResumeLayout(false);
            pnlFullNameBorder.ResumeLayout(false);
            pnlFullNameBorder.PerformLayout();
            pnlPhoneBorder.ResumeLayout(false);
            pnlPhoneBorder.PerformLayout();
            pnlRoleBorder.ResumeLayout(false);
            pnlRoleBorder.PerformLayout();
            pnlGenderBorder.ResumeLayout(false);
            pnlGenderBorder.PerformLayout();
            pnlBirthdayBorder.ResumeLayout(false);
            pnlCCCDBorder.ResumeLayout(false);
            pnlCCCDBorder.PerformLayout();
            pnlAddressBorder.ResumeLayout(false);
            pnlAddressBorder.PerformLayout();
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
        private Label lblUpload;
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
        private Panel pnlFullNameBorder;
        private Panel pnlPhoneBorder;
        private Panel pnlRoleBorder;
        private Panel pnlGenderBorder;
        private Panel pnlBirthdayBorder;
        private Panel pnlCCCDBorder;
        private Panel pnlAddressBorder;
        private Panel pnlCurrentPassBorder;
        private Panel pnlNewPassBorder;
        private Panel pnlConfirmPassBorder;
        private Label lblPasswordRuleHint;
        private Label lblFullNameRuleHint;
        private Label lblPhoneRuleHint;
        private Label lblBirthdayRuleHint;
        private Label lblGenderRuleHint;
        private Label lblCccdRuleHint;
        private Label lblAddressRuleHint;
    }
}
