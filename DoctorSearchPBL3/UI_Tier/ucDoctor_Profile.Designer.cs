namespace UI_Tier
{
    partial class ucDoctor_Profile
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            txtConsultationFee = new TextBox();
            lblConsultationFee = new Label();
            txtExperienceYears = new TextBox();
            lblExperienceYears = new Label();
            txtBiography = new TextBox();
            lblBiography = new Label();
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
            txtPosition = new TextBox();
            lblPosition = new Label();
            txtSpecialty = new TextBox();
            lblSpecialty = new Label();
            txtLicense = new TextBox();
            lblLicense = new Label();
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
            lblDoctorName = new Label();
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
            // txtConsultationFee
            // 
            txtConsultationFee.Font = new Font("Segoe UI", 12F);
            txtConsultationFee.Location = new Point(1290, 780);
            txtConsultationFee.Name = "txtConsultationFee";
            txtConsultationFee.ReadOnly = true;
            txtConsultationFee.Size = new Size(735, 50);
            txtConsultationFee.TabIndex = 27;
            // 
            // lblConsultationFee
            // 
            lblConsultationFee.AutoSize = true;
            lblConsultationFee.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblConsultationFee.ForeColor = Color.FromArgb(71, 85, 105);
            lblConsultationFee.Location = new Point(1290, 735);
            lblConsultationFee.Name = "lblConsultationFee";
            lblConsultationFee.Size = new Size(132, 37);
            lblConsultationFee.TabIndex = 28;
            lblConsultationFee.Text = "Giá khám";
            // 
            // txtExperienceYears
            // 
            txtExperienceYears.Font = new Font("Segoe UI", 12F);
            txtExperienceYears.Location = new Point(455, 780);
            txtExperienceYears.Name = "txtExperienceYears";
            txtExperienceYears.ReadOnly = true;
            txtExperienceYears.Size = new Size(735, 50);
            txtExperienceYears.TabIndex = 29;
            // 
            // lblExperienceYears
            // 
            lblExperienceYears.AutoSize = true;
            lblExperienceYears.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblExperienceYears.ForeColor = Color.FromArgb(71, 85, 105);
            lblExperienceYears.Location = new Point(455, 735);
            lblExperienceYears.Name = "lblExperienceYears";
            lblExperienceYears.Size = new Size(252, 37);
            lblExperienceYears.TabIndex = 30;
            lblExperienceYears.Text = "Kinh nghiệm (năm)";
            // 
            // txtBiography
            // 
            txtBiography.Font = new Font("Segoe UI", 12F);
            txtBiography.Location = new Point(455, 911);
            txtBiography.Multiline = true;
            txtBiography.Name = "txtBiography";
            txtBiography.ReadOnly = true;
            txtBiography.Size = new Size(1551, 218);
            txtBiography.TabIndex = 31;
            // 
            // lblBiography
            // 
            lblBiography.AutoSize = true;
            lblBiography.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBiography.ForeColor = Color.FromArgb(71, 85, 105);
            lblBiography.Location = new Point(455, 866);
            lblBiography.Name = "lblBiography";
            lblBiography.Size = new Size(105, 37);
            lblBiography.TabIndex = 32;
            lblBiography.Text = "Tiểu sử";
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
            pnlMain.Padding = new Padding(52, 38, 52, 128);
            pnlMain.Size = new Size(2197, 2500);
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
            pnlSecurity.Location = new Point(52, 1288);
            pnlSecurity.Margin = new Padding(0, 0, 0, 38);
            pnlSecurity.Name = "pnlSecurity";
            pnlSecurity.Size = new Size(2093, 579);
            pnlSecurity.TabIndex = 2;
            pnlSecurity.Paint += SectionPanel_Paint;
            // 
            // pnlChangePassword
            // 
            pnlChangePassword.Controls.Add(pnlPassActions);
            pnlChangePassword.Controls.Add(txtConfirmPass);
            pnlChangePassword.Controls.Add(lblConfirmPass);
            pnlChangePassword.Controls.Add(txtNewPass);
            pnlChangePassword.Controls.Add(lblNewPass);
            pnlChangePassword.Controls.Add(txtCurrentPass);
            pnlChangePassword.Controls.Add(lblCurrentPass);
            pnlChangePassword.Location = new Point(38, 90);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Size = new Size(1373, 462);
            pnlChangePassword.TabIndex = 0;
            pnlChangePassword.Visible = false;
            // 
            // pnlPassActions
            // 
            pnlPassActions.Controls.Add(btnCancelPass);
            pnlPassActions.Controls.Add(btnSavePass);
            pnlPassActions.Location = new Point(52, 373);
            pnlPassActions.Name = "pnlPassActions";
            pnlPassActions.Size = new Size(585, 77);
            pnlPassActions.TabIndex = 35;
            // 
            // btnCancelPass
            // 
            btnCancelPass.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelPass.FlatAppearance.BorderSize = 0;
            btnCancelPass.FlatStyle = FlatStyle.Flat;
            btnCancelPass.Font = new Font("Segoe UI", 11F);
            btnCancelPass.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelPass.Location = new Point(312, 6);
            btnCancelPass.Name = "btnCancelPass";
            btnCancelPass.Size = new Size(156, 64);
            btnCancelPass.TabIndex = 1;
            btnCancelPass.Text = "✕ Hủy";
            btnCancelPass.UseVisualStyleBackColor = false;
            btnCancelPass.Click += btnCancel_Click;
            // 
            // btnSavePass
            // 
            btnSavePass.BackColor = Color.FromArgb(37, 99, 235);
            btnSavePass.FlatAppearance.BorderSize = 0;
            btnSavePass.FlatStyle = FlatStyle.Flat;
            btnSavePass.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSavePass.ForeColor = Color.White;
            btnSavePass.Location = new Point(5, 5);
            btnSavePass.Name = "btnSavePass";
            btnSavePass.Size = new Size(286, 64);
            btnSavePass.TabIndex = 0;
            btnSavePass.Text = "💾 Lưu mật khẩu";
            btnSavePass.UseVisualStyleBackColor = false;
            btnSavePass.Click += btnSave_Click;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.Location = new Point(52, 288);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(1320, 50);
            txtConfirmPass.TabIndex = 36;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(71, 85, 105);
            lblConfirmPass.Location = new Point(52, 247);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(307, 37);
            lblConfirmPass.TabIndex = 32;
            lblConfirmPass.Text = "Xác nhận mật khẩu mới";
            // 
            // txtNewPass
            // 
            txtNewPass.Font = new Font("Segoe UI", 12F);
            txtNewPass.Location = new Point(52, 174);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(1320, 50);
            txtNewPass.TabIndex = 37;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(71, 85, 105);
            lblNewPass.Location = new Point(52, 123);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(188, 37);
            lblNewPass.TabIndex = 29;
            lblNewPass.Text = "Mật khẩu mới";
            // 
            // txtCurrentPass
            // 
            txtCurrentPass.Font = new Font("Segoe UI", 12F);
            txtCurrentPass.Location = new Point(52, 57);
            txtCurrentPass.Name = "txtCurrentPass";
            txtCurrentPass.Size = new Size(1320, 50);
            txtCurrentPass.TabIndex = 38;
            txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // lblCurrentPass
            // 
            lblCurrentPass.AutoSize = true;
            lblCurrentPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCurrentPass.ForeColor = Color.FromArgb(71, 85, 105);
            lblCurrentPass.Location = new Point(52, 13);
            lblCurrentPass.Name = "lblCurrentPass";
            lblCurrentPass.Size = new Size(231, 37);
            lblCurrentPass.TabIndex = 26;
            lblCurrentPass.Text = "Mật khẩu hiện tại";
            // 
            // lblSecurityHint
            // 
            lblSecurityHint.AutoSize = true;
            lblSecurityHint.Font = new Font("Segoe UI", 10F);
            lblSecurityHint.ForeColor = Color.FromArgb(100, 116, 139);
            lblSecurityHint.Location = new Point(39, 109);
            lblSecurityHint.Name = "lblSecurityHint";
            lblSecurityHint.Size = new Size(638, 37);
            lblSecurityHint.TabIndex = 2;
            lblSecurityHint.Text = "Nhấn \"Đổi mật khẩu\" để cập nhật bảo mật tài khoản";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.FromArgb(37, 99, 235);
            btnChangePassword.Location = new Point(1746, 26);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(321, 51);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Text = "✎ Đổi mật khẩu";
            btnChangePassword.TextAlign = ContentAlignment.MiddleRight;
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnEdit_Click;
            // 
            // lblSecurityTitle
            // 
            lblSecurityTitle.AutoSize = true;
            lblSecurityTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSecurityTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblSecurityTitle.Location = new Point(26, 26);
            lblSecurityTitle.Name = "lblSecurityTitle";
            lblSecurityTitle.Size = new Size(265, 59);
            lblSecurityTitle.TabIndex = 0;
            lblSecurityTitle.Text = "🔒 Bảo mật";
            // 
            // pnlBasicInfo
            // 
            pnlBasicInfo.BackColor = Color.White;
            pnlBasicInfo.Controls.Add(txtBiography);
            pnlBasicInfo.Controls.Add(lblBiography);
            pnlBasicInfo.Controls.Add(txtExperienceYears);
            pnlBasicInfo.Controls.Add(lblExperienceYears);
            pnlBasicInfo.Controls.Add(txtConsultationFee);
            pnlBasicInfo.Controls.Add(lblConsultationFee);
            pnlBasicInfo.Controls.Add(pnlBasicInfoActions);
            pnlBasicInfo.Controls.Add(txtPosition);
            pnlBasicInfo.Controls.Add(lblPosition);
            pnlBasicInfo.Controls.Add(txtSpecialty);
            pnlBasicInfo.Controls.Add(lblSpecialty);
            pnlBasicInfo.Controls.Add(txtLicense);
            pnlBasicInfo.Controls.Add(lblLicense);
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
            pnlBasicInfo.Controls.Add(lblDoctorName);
            pnlBasicInfo.Controls.Add(picAvatar);
            pnlBasicInfo.Controls.Add(btnEditBasicInfo);
            pnlBasicInfo.Controls.Add(lblBasicInfoTitle);
            pnlBasicInfo.Dock = DockStyle.Top;
            pnlBasicInfo.Location = new Point(52, 38);
            pnlBasicInfo.Margin = new Padding(0, 0, 0, 38);
            pnlBasicInfo.Name = "pnlBasicInfo";
            pnlBasicInfo.Size = new Size(2093, 1250);
            pnlBasicInfo.TabIndex = 0;
            pnlBasicInfo.Paint += SectionPanel_Paint;
            // 
            // pnlBasicInfoActions
            // 
            pnlBasicInfoActions.Controls.Add(btnCancelBasicInfo);
            pnlBasicInfoActions.Controls.Add(btnSaveBasicInfo);
            pnlBasicInfoActions.Location = new Point(44, 1150);
            pnlBasicInfoActions.Margin = new Padding(4);
            pnlBasicInfoActions.Name = "pnlBasicInfoActions";
            pnlBasicInfoActions.Size = new Size(475, 77);
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
            btnCancelBasicInfo.Location = new Point(304, 9);
            btnCancelBasicInfo.Name = "btnCancelBasicInfo";
            btnCancelBasicInfo.Size = new Size(156, 64);
            btnCancelBasicInfo.TabIndex = 1;
            btnCancelBasicInfo.Text = "✕ Hủy";
            btnCancelBasicInfo.UseVisualStyleBackColor = false;
            btnCancelBasicInfo.Click += btnCancel_Click;
            // 
            // btnSaveBasicInfo
            // 
            btnSaveBasicInfo.BackColor = Color.FromArgb(37, 99, 235);
            btnSaveBasicInfo.FlatAppearance.BorderSize = 0;
            btnSaveBasicInfo.FlatStyle = FlatStyle.Flat;
            btnSaveBasicInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSaveBasicInfo.ForeColor = Color.White;
            btnSaveBasicInfo.Location = new Point(6, 6);
            btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            btnSaveBasicInfo.Size = new Size(277, 64);
            btnSaveBasicInfo.TabIndex = 0;
            btnSaveBasicInfo.Text = "💾 Lưu thay đổi";
            btnSaveBasicInfo.UseVisualStyleBackColor = false;
            btnSaveBasicInfo.Click += btnSave_Click;
            // 
            // txtPosition
            // 
            txtPosition.Font = new Font("Segoe UI", 12F);
            txtPosition.Location = new Point(455, 173);
            txtPosition.Name = "txtPosition";
            txtPosition.ReadOnly = true;
            txtPosition.Size = new Size(735, 50);
            txtPosition.TabIndex = 23;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPosition.ForeColor = Color.FromArgb(71, 85, 105);
            lblPosition.Location = new Point(455, 128);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(117, 37);
            lblPosition.TabIndex = 22;
            lblPosition.Text = "Chức vụ";
            // 
            // txtSpecialty
            // 
            txtSpecialty.Font = new Font("Segoe UI", 12F);
            txtSpecialty.Location = new Point(455, 296);
            txtSpecialty.Name = "txtSpecialty";
            txtSpecialty.ReadOnly = true;
            txtSpecialty.Size = new Size(735, 50);
            txtSpecialty.TabIndex = 21;
            // 
            // lblSpecialty
            // 
            lblSpecialty.AutoSize = true;
            lblSpecialty.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSpecialty.ForeColor = Color.FromArgb(71, 85, 105);
            lblSpecialty.Location = new Point(455, 250);
            lblSpecialty.Name = "lblSpecialty";
            lblSpecialty.Size = new Size(177, 37);
            lblSpecialty.TabIndex = 20;
            lblSpecialty.Text = "Chuyên khoa";
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(1290, 538);
            txtLicense.Name = "txtLicense";
            txtLicense.ReadOnly = true;
            txtLicense.Size = new Size(735, 50);
            txtLicense.TabIndex = 19;
            // 
            // lblLicense
            // 
            lblLicense.AutoSize = true;
            lblLicense.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLicense.ForeColor = Color.FromArgb(71, 85, 105);
            lblLicense.Location = new Point(1290, 493);
            lblLicense.Name = "lblLicense";
            lblLicense.Size = new Size(322, 37);
            lblLicense.TabIndex = 18;
            lblLicense.Text = "Mã chứng chỉ hành nghề";
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(1290, 416);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.ReadOnly = true;
            txtCCCD.Size = new Size(735, 50);
            txtCCCD.TabIndex = 15;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCCCD.ForeColor = Color.FromArgb(71, 85, 105);
            lblCCCD.Location = new Point(1290, 366);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(257, 37);
            lblCCCD.TabIndex = 14;
            lblCCCD.Text = "Số CCCD / Hộ chiếu";
            // 
            // txtGender
            // 
            txtGender.Font = new Font("Segoe UI", 12F);
            txtGender.Location = new Point(455, 416);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(735, 50);
            txtGender.TabIndex = 13;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(71, 85, 105);
            lblGender.Location = new Point(455, 371);
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
            dtpBirthday.Location = new Point(1290, 294);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(735, 50);
            dtpBirthday.TabIndex = 11;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBirthday.ForeColor = Color.FromArgb(71, 85, 105);
            lblBirthday.Location = new Point(1290, 250);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(140, 37);
            lblBirthday.TabIndex = 10;
            lblBirthday.Text = "Ngày sinh";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(455, 659);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(1551, 50);
            txtAddress.TabIndex = 9;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(71, 85, 105);
            lblAddress.Location = new Point(455, 609);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 37);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(1290, 173);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(735, 50);
            txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(71, 85, 105);
            lblPhone.Location = new Point(1290, 128);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(178, 37);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(455, 538);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(735, 50);
            txtFullName.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(71, 85, 105);
            lblFullName.Location = new Point(455, 493);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(135, 37);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên";
            // 
            // lblDoctorName
            // 
            lblDoctorName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblDoctorName.ForeColor = Color.FromArgb(15, 23, 42);
            lblDoctorName.Location = new Point(32, 499);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(390, 102);
            lblDoctorName.TabIndex = 3;
            lblDoctorName.Text = "BS. Nguyễn Văn A";
            lblDoctorName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(241, 245, 249);
            picAvatar.Location = new Point(32, 102);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(390, 393);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 2;
            picAvatar.TabStop = false;
            // 
            // btnEditBasicInfo
            // 
            btnEditBasicInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditBasicInfo.Cursor = Cursors.Hand;
            btnEditBasicInfo.FlatAppearance.BorderSize = 0;
            btnEditBasicInfo.FlatStyle = FlatStyle.Flat;
            btnEditBasicInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEditBasicInfo.ForeColor = Color.FromArgb(37, 99, 235);
            btnEditBasicInfo.Location = new Point(1770, 26);
            btnEditBasicInfo.Name = "btnEditBasicInfo";
            btnEditBasicInfo.Size = new Size(297, 100);
            btnEditBasicInfo.TabIndex = 1;
            btnEditBasicInfo.Text = "✎ Chỉnh sửa";
            btnEditBasicInfo.TextAlign = ContentAlignment.MiddleRight;
            btnEditBasicInfo.UseVisualStyleBackColor = true;
            btnEditBasicInfo.Click += btnEdit_Click;
            // 
            // lblBasicInfoTitle
            // 
            lblBasicInfoTitle.AutoSize = true;
            lblBasicInfoTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBasicInfoTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblBasicInfoTitle.Location = new Point(26, 26);
            lblBasicInfoTitle.Name = "lblBasicInfoTitle";
            lblBasicInfoTitle.Size = new Size(383, 59);
            lblBasicInfoTitle.TabIndex = 0;
            lblBasicInfoTitle.Text = "👤 Hồ sơ cá nhân";
            // 
            // ucDoctor_Profile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucDoctor_Profile";
            Size = new Size(2197, 2500);
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

        #endregion

        private Panel pnlMain;
        private Panel pnlSecurity;
        private Panel pnlPassActions;
        private Button btnCancelPass;
        private Button btnSavePass;
        private Panel pnlChangePassword;
        private TextBox txtConfirmPass;
        private Label lblConfirmPass;
        private TextBox txtNewPass;
        private Label lblNewPass;
        private TextBox txtCurrentPass;
        private Label lblCurrentPass;
        private Label lblSecurityHint;
        private Button btnChangePassword;
        private Label lblSecurityTitle;
        private Panel pnlBasicInfo;
        private Panel pnlBasicInfoActions;
        private Button btnCancelBasicInfo;
        private Button btnSaveBasicInfo;
        private TextBox txtPosition;
        private Label lblPosition;
        private TextBox txtSpecialty;
        private Label lblSpecialty;
        private TextBox txtLicense;
        private Label lblLicense;
        private TextBox txtCCCD;
        private Label lblCCCD;
        private TextBox txtGender;
        private Label lblGender;
        private DateTimePicker dtpBirthday;
        private Label lblBirthday;
        private TextBox txtAddress;
        private Label lblAddress;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtFullName;
        private Label lblFullName;
        private Label lblDoctorName;
        private PictureBox picAvatar;
        private Button btnEditBasicInfo;
        private Label lblBasicInfoTitle;
        private TextBox txtConsultationFee;
        private Label lblConsultationFee;
        private TextBox txtExperienceYears;
        private Label lblExperienceYears;
        private TextBox txtBiography;
        private Label lblBiography;
    }
}
