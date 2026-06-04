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
            btnCancelPass = new Button();
            btnSavePass = new Button();
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
            lblUpload.Location = new Point(345, 415);
            lblUpload.Name = "lblUpload";
            lblUpload.Size = new Size(55, 65);
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
            pnlMain.Margin = new Padding(4);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20, 20, 20, 128);
            pnlMain.Size = new Size(2100, 1700);
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
            pnlSecurity.Location = new Point(20, 782);
            pnlSecurity.Margin = new Padding(0, 0, 0, 38);
            pnlSecurity.Name = "pnlSecurity";
            pnlSecurity.Size = new Size(2060, 607);
            pnlSecurity.TabIndex = 2;
            pnlSecurity.Paint += SectionPanel_Paint;
            // 
            // pnlChangePassword
            // 
            pnlChangePassword.Controls.Add(pnlPassActions);
            pnlChangePassword.Controls.Add(pnlCurrentPassBorder);
            pnlChangePassword.Controls.Add(pnlNewPassBorder);
            pnlChangePassword.Controls.Add(pnlConfirmPassBorder);
            pnlChangePassword.Controls.Add(lblConfirmPass);
            pnlChangePassword.Controls.Add(lblNewPass);
            pnlChangePassword.Controls.Add(lblCurrentPass);
            pnlChangePassword.Location = new Point(38, 90);
            pnlChangePassword.Margin = new Padding(4);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Size = new Size(2018, 498);
            pnlChangePassword.TabIndex = 3;
            pnlChangePassword.Visible = false;
            // 
            // pnlPassActions
            // 
            pnlPassActions.Controls.Add(btnCancelPass);
            pnlPassActions.Controls.Add(btnSavePass);
            pnlPassActions.Location = new Point(52, 405);
            pnlPassActions.Margin = new Padding(4);
            pnlPassActions.Name = "pnlPassActions";
            pnlPassActions.Size = new Size(594, 89);
            pnlPassActions.TabIndex = 35;
            // 
            // pnlCurrentPassBorder
            // 
            pnlCurrentPassBorder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCurrentPassBorder.BackColor = Color.White;
            pnlCurrentPassBorder.Controls.Add(txtCurrentPass);
            pnlCurrentPassBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlCurrentPassBorder.Location = new Point(38, 61);
            pnlCurrentPassBorder.MaximumSize = new Size(1340, 63);
            pnlCurrentPassBorder.Name = "pnlCurrentPassBorder";
            pnlCurrentPassBorder.Padding = new Padding(10);
            pnlCurrentPassBorder.Size = new Size(1324, 63);
            pnlCurrentPassBorder.TabIndex = 36;
            // 
            // txtCurrentPass
            // 
            txtCurrentPass.BorderStyle = BorderStyle.None;
            txtCurrentPass.Dock = DockStyle.Fill;
            txtCurrentPass.Font = new Font("Segoe UI", 12F);
            txtCurrentPass.Location = new Point(10, 10);
            txtCurrentPass.Margin = new Padding(4);
            txtCurrentPass.MaximumSize = new Size(1320, 45);
            txtCurrentPass.Name = "txtCurrentPass";
            txtCurrentPass.PlaceholderText = "Nhập mật khẩu hiện tại";
            txtCurrentPass.Size = new Size(1304, 43);
            txtCurrentPass.TabIndex = 27;
            txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // pnlNewPassBorder
            // 
            pnlNewPassBorder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlNewPassBorder.BackColor = Color.White;
            pnlNewPassBorder.Controls.Add(txtNewPass);
            pnlNewPassBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlNewPassBorder.Location = new Point(38, 190);
            pnlNewPassBorder.MaximumSize = new Size(1340, 63);
            pnlNewPassBorder.Name = "pnlNewPassBorder";
            pnlNewPassBorder.Padding = new Padding(10);
            pnlNewPassBorder.Size = new Size(1324, 63);
            pnlNewPassBorder.TabIndex = 37;
            // 
            // txtNewPass
            // 
            txtNewPass.BorderStyle = BorderStyle.None;
            txtNewPass.Dock = DockStyle.Fill;
            txtNewPass.Font = new Font("Segoe UI", 12F);
            txtNewPass.Location = new Point(10, 10);
            txtNewPass.Margin = new Padding(4);
            txtNewPass.MaximumSize = new Size(1320, 45);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PlaceholderText = "Nhập mật khẩu mới (tối thiểu 6 kí tự)";
            txtNewPass.Size = new Size(1304, 43);
            txtNewPass.TabIndex = 30;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // pnlConfirmPassBorder
            // 
            pnlConfirmPassBorder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlConfirmPassBorder.BackColor = Color.White;
            pnlConfirmPassBorder.Controls.Add(txtConfirmPass);
            pnlConfirmPassBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlConfirmPassBorder.Location = new Point(38, 319);
            pnlConfirmPassBorder.MaximumSize = new Size(1340, 63);
            pnlConfirmPassBorder.Name = "pnlConfirmPassBorder";
            pnlConfirmPassBorder.Padding = new Padding(10);
            pnlConfirmPassBorder.Size = new Size(1324, 63);
            pnlConfirmPassBorder.TabIndex = 38;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BorderStyle = BorderStyle.None;
            txtConfirmPass.Dock = DockStyle.Fill;
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.Location = new Point(10, 10);
            txtConfirmPass.Margin = new Padding(4);
            txtConfirmPass.MaximumSize = new Size(1320, 45);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderText = "Nhập lại mật khẩu mới ";
            txtConfirmPass.Size = new Size(1304, 43);
            txtConfirmPass.TabIndex = 33;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPass.Location = new Point(48, 271);
            lblConfirmPass.Margin = new Padding(4, 0, 4, 0);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(444, 45);
            lblConfirmPass.TabIndex = 32;
            lblConfirmPass.Text = "✅ Xác nhận mật khẩu mới *";
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblNewPass.Location = new Point(52, 142);
            lblNewPass.Margin = new Padding(4, 0, 4, 0);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(302, 45);
            lblNewPass.TabIndex = 29;
            lblNewPass.Text = "🆕 Mật khẩu mới *";
            // 
            // lblCurrentPass
            // 
            lblCurrentPass.AutoSize = true;
            lblCurrentPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCurrentPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblCurrentPass.Location = new Point(52, 13);
            lblCurrentPass.Margin = new Padding(4, 0, 4, 0);
            lblCurrentPass.Name = "lblCurrentPass";
            lblCurrentPass.Size = new Size(355, 45);
            lblCurrentPass.TabIndex = 26;
            lblCurrentPass.Text = "🔑 Mật khẩu hiện tại *";
            // 
            // lblSecurityHint
            // 
            lblSecurityHint.AutoSize = true;
            lblSecurityHint.Font = new Font("Segoe UI", 10F);
            lblSecurityHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblSecurityHint.Location = new Point(39, 109);
            lblSecurityHint.Margin = new Padding(4, 0, 4, 0);
            lblSecurityHint.Name = "lblSecurityHint";
            lblSecurityHint.Size = new Size(632, 37);
            lblSecurityHint.TabIndex = 2;
            lblSecurityHint.Text = "Nhấn \"Đổi mật khẩu\" để cập nhật mật khẩu của bạn";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.FromArgb(37, 99, 235);
            btnChangePassword.Location = new Point(1700, 11);
            btnChangePassword.Margin = new Padding(4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(310, 74);
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
            lblSecurityTitle.Location = new Point(26, 26);
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
            pnlBasicInfo.Location = new Point(20, 20);
            pnlBasicInfo.Margin = new Padding(4);
            pnlBasicInfo.Name = "pnlBasicInfo";
            pnlBasicInfo.Size = new Size(2060, 762);
            pnlBasicInfo.TabIndex = 0;
            pnlBasicInfo.Paint += SectionPanel_Paint;
            // 
            // pnlBasicInfoActions
            // 
            pnlBasicInfoActions.Controls.Add(btnCancelBasicInfo);
            pnlBasicInfoActions.Controls.Add(btnSaveBasicInfo);
            pnlBasicInfoActions.Location = new Point(50, 650);
            pnlBasicInfoActions.Margin = new Padding(4);
            pnlBasicInfoActions.Name = "pnlBasicInfoActions";
            pnlBasicInfoActions.Size = new Size(621, 90);
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
            btnCancelBasicInfo.Location = new Point(419, 9);
            btnCancelBasicInfo.Margin = new Padding(4);
            btnCancelBasicInfo.Name = "btnCancelBasicInfo";
            btnCancelBasicInfo.Size = new Size(195, 77);
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
            btnSaveBasicInfo.Location = new Point(7, 9);
            btnSaveBasicInfo.Margin = new Padding(4);
            btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            btnSaveBasicInfo.Size = new Size(404, 77);
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
            pnlFullNameBorder.Location = new Point(440, 150);
            pnlFullNameBorder.Name = "pnlFullNameBorder";
            pnlFullNameBorder.Padding = new Padding(10);
            pnlFullNameBorder.Size = new Size(770, 63);
            pnlFullNameBorder.TabIndex = 27;
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Dock = DockStyle.Fill;
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(10, 10);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(750, 43);
            txtFullName.TabIndex = 5;
            // 
            // pnlPhoneBorder
            // 
            pnlPhoneBorder.BackColor = Color.White;
            pnlPhoneBorder.Controls.Add(txtPhone);
            pnlPhoneBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlPhoneBorder.Location = new Point(1240, 150);
            pnlPhoneBorder.Name = "pnlPhoneBorder";
            pnlPhoneBorder.Padding = new Padding(10);
            pnlPhoneBorder.Size = new Size(770, 63);
            pnlPhoneBorder.TabIndex = 28;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = SystemColors.Window;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(10, 10);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(750, 43);
            txtPhone.TabIndex = 7;
            // 
            // pnlRoleBorder
            // 
            pnlRoleBorder.BackColor = Color.White;
            pnlRoleBorder.Controls.Add(txtRole);
            pnlRoleBorder.Font = new Font("Segoe UI", 12F);
            pnlRoleBorder.Location = new Point(440, 290);
            pnlRoleBorder.Name = "pnlRoleBorder";
            pnlRoleBorder.Padding = new Padding(10);
            pnlRoleBorder.Size = new Size(770, 63);
            pnlRoleBorder.TabIndex = 29;
            // 
            // txtRole
            // 
            txtRole.BorderStyle = BorderStyle.None;
            txtRole.Dock = DockStyle.Fill;
            txtRole.Font = new Font("Segoe UI", 12F);
            txtRole.Location = new Point(10, 10);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(750, 43);
            txtRole.TabIndex = 17;
            // 
            // pnlGenderBorder
            // 
            pnlGenderBorder.BackColor = Color.White;
            pnlGenderBorder.Controls.Add(txtGender);
            pnlGenderBorder.Font = new Font("Segoe UI", 12F);
            pnlGenderBorder.Location = new Point(440, 430);
            pnlGenderBorder.Name = "pnlGenderBorder";
            pnlGenderBorder.Padding = new Padding(10);
            pnlGenderBorder.Size = new Size(770, 63);
            pnlGenderBorder.TabIndex = 30;
            // 
            // txtGender
            // 
            txtGender.BorderStyle = BorderStyle.None;
            txtGender.Dock = DockStyle.Fill;
            txtGender.Font = new Font("Segoe UI", 12F);
            txtGender.Location = new Point(10, 10);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(750, 43);
            txtGender.TabIndex = 13;
            // 
            // pnlBirthdayBorder
            // 
            pnlBirthdayBorder.BackColor = Color.White;
            pnlBirthdayBorder.Controls.Add(dtpBirthday);
            pnlBirthdayBorder.Font = new Font("Segoe UI", 12F);
            pnlBirthdayBorder.Location = new Point(1240, 290);
            pnlBirthdayBorder.Name = "pnlBirthdayBorder";
            pnlBirthdayBorder.Padding = new Padding(10, 5, 10, 5);
            pnlBirthdayBorder.Size = new Size(770, 60);
            pnlBirthdayBorder.TabIndex = 31;
            // 
            // dtpBirthday
            // 
            dtpBirthday.CustomFormat = "dd / MM / yyyy";
            dtpBirthday.Dock = DockStyle.Fill;
            dtpBirthday.Font = new Font("Segoe UI", 12F);
            dtpBirthday.Format = DateTimePickerFormat.Custom;
            dtpBirthday.Location = new Point(10, 5);
            dtpBirthday.Margin = new Padding(4);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(750, 50);
            dtpBirthday.TabIndex = 11;
            // 
            // pnlCCCDBorder
            // 
            pnlCCCDBorder.BackColor = Color.White;
            pnlCCCDBorder.Controls.Add(txtCCCD);
            pnlCCCDBorder.Font = new Font("Segoe UI", 12F);
            pnlCCCDBorder.Location = new Point(1240, 430);
            pnlCCCDBorder.Name = "pnlCCCDBorder";
            pnlCCCDBorder.Padding = new Padding(10);
            pnlCCCDBorder.Size = new Size(770, 63);
            pnlCCCDBorder.TabIndex = 32;
            // 
            // txtCCCD
            // 
            txtCCCD.BorderStyle = BorderStyle.None;
            txtCCCD.Dock = DockStyle.Fill;
            txtCCCD.Font = new Font("Segoe UI", 12F);
            txtCCCD.Location = new Point(10, 10);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(750, 43);
            txtCCCD.TabIndex = 15;
            // 
            // pnlAddressBorder
            // 
            pnlAddressBorder.BackColor = Color.White;
            pnlAddressBorder.Controls.Add(txtAddress);
            pnlAddressBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlAddressBorder.Location = new Point(440, 570);
            pnlAddressBorder.Name = "pnlAddressBorder";
            pnlAddressBorder.Padding = new Padding(10);
            pnlAddressBorder.Size = new Size(1570, 63);
            pnlAddressBorder.TabIndex = 33;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(10, 10);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(1550, 43);
            txtAddress.TabIndex = 9;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCCCD.ForeColor = Color.FromArgb(73, 80, 87);
            lblCCCD.Location = new Point(1250, 380);
            lblCCCD.Margin = new Padding(4, 0, 4, 0);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(146, 45);
            lblCCCD.TabIndex = 14;
            lblCCCD.Text = "Số CCCD";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(73, 80, 87);
            lblGender.Location = new Point(450, 380);
            lblGender.Margin = new Padding(4, 0, 4, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(145, 45);
            lblGender.TabIndex = 12;
            lblGender.Text = "Giới tính";
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBirthday.ForeColor = Color.FromArgb(73, 80, 87);
            lblBirthday.Location = new Point(1250, 240);
            lblBirthday.Margin = new Padding(4, 0, 4, 0);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(166, 45);
            lblBirthday.TabIndex = 10;
            lblBirthday.Text = "Ngày sinh";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(73, 80, 87);
            lblAddress.Location = new Point(450, 520);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(119, 45);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Địa chỉ";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblPhone.Location = new Point(1250, 100);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(212, 45);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(73, 80, 87);
            lblFullName.Location = new Point(450, 100);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(161, 45);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(73, 80, 87);
            lblRole.Location = new Point(450, 240);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(125, 45);
            lblRole.TabIndex = 16;
            lblRole.Text = "Vai trò ";
            // 
            // lblAdminName
            // 
            lblAdminName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblAdminName.Location = new Point(50, 480);
            lblAdminName.Margin = new Padding(4, 0, 4, 0);
            lblAdminName.Name = "lblAdminName";
            lblAdminName.Size = new Size(350, 40);
            lblAdminName.TabIndex = 3;
            lblAdminName.Text = "Admin";
            lblAdminName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(241, 243, 245);
            picAvatar.Location = new Point(50, 120);
            picAvatar.Margin = new Padding(4);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(350, 360);
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
            btnEditBasicInfo.Location = new Point(1760, 31);
            btnEditBasicInfo.Margin = new Padding(4);
            btnEditBasicInfo.Name = "btnEditBasicInfo";
            btnEditBasicInfo.Size = new Size(250, 60);
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
            lblBasicInfoTitle.Location = new Point(32, 32);
            lblBasicInfoTitle.Margin = new Padding(4, 0, 4, 0);
            lblBasicInfoTitle.Name = "lblBasicInfoTitle";
            lblBasicInfoTitle.Size = new Size(442, 59);
            lblBasicInfoTitle.TabIndex = 0;
            lblBasicInfoTitle.Text = "👤 Thông tin cơ bản";
            // 
            // btnCancelPass
            // 
            btnCancelPass.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelPass.FlatAppearance.BorderSize = 0;
            btnCancelPass.FlatStyle = FlatStyle.Flat;
            btnCancelPass.Font = new Font("Segoe UI", 16F);
            btnCancelPass.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelPass.Location = new Point(379, 6);
            btnCancelPass.Margin = new Padding(4);
            btnCancelPass.Name = "btnCancelPass";
            btnCancelPass.Size = new Size(195, 79);
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
            btnSavePass.Location = new Point(6, 6);
            btnSavePass.Margin = new Padding(4);
            btnSavePass.Name = "btnSavePass";
            btnSavePass.Size = new Size(365, 79);
            btnSavePass.TabIndex = 0;
            btnSavePass.Text = "💾  Lưu thay đổi";
            btnSavePass.UseVisualStyleBackColor = false;
            btnSavePass.Click += btnSavePass_Click;
            btnSavePass.Paint += Button_Paint;
            // 
            // ucAdmin_Profile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Margin = new Padding(4);
            Name = "ucAdmin_Profile";
            Size = new Size(2100, 1700);
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
    }
}