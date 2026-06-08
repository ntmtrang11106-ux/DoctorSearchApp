namespace UI_Tier
{
    partial class ucPatient_Profile
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
            lblUpload = new Label();
            pnlMain = new Panel();
            pnlSecurity = new Panel();
            pnlChangePassword = new Panel();
            pnlPassActions = new Panel();
            btnCancelPass = new Button();
            btnSavePass = new Button();
            lblPasswordRuleHint = new Label();
            pnlConfirmPassBorder = new Panel();
            txtConfirmPass = new TextBox();
            lblConfirmPass = new Label();
            pnlNewPassBorder = new Panel();
            txtNewPass = new TextBox();
            lblNewPass = new Label();
            pnlCurrentPassBorder = new Panel();
            txtCurrentPass = new TextBox();
            lblCurrentPass = new Label();
            lblSecurityHint = new Label();
            btnChangePassword = new Button();
            lblSecurityTitle = new Label();
            pnlMedicalProfile = new Panel();
            pnlMedicalActions = new Panel();
            btnCancelMedical = new Button();
            btnSaveMedical = new Button();
            lblMedicalHistoryRuleHint = new Label();
            pnlMedicalHistoryBorder = new Panel();
            txtMedicalHistory = new TextBox();
            lblMedicalHistory = new Label();
            lblBloodTypeRuleHint = new Label();
            pnlBloodTypeBorder = new Panel();
            txtBloodType = new TextBox();
            lblBloodType = new Label();
            btnEditMedical = new Button();
            lblBHYT = new Label();
            pnlBHYTBorder = new Panel();
            txtBHYT = new TextBox();
            lblMedicalTitle = new Label();
            pnlBasicInfo = new Panel();
            pnlBasicInfoActions = new Panel();
            btnCancelBasicInfo = new Button();
            btnSaveBasicInfo = new Button();
            lblAddressRuleHint = new Label();
            lblEmergencyPhoneRuleHint = new Label();
            pnlEmergencyPhoneBorder = new Panel();
            txtEmergencyPhone = new TextBox();
            lblEmergencyPhone = new Label();
            lblEmergencyContactRuleHint = new Label();
            pnlEmergencyContactBorder = new Panel();
            txtEmergencyContact = new TextBox();
            lblEmergencyContact = new Label();
            pnlPatientIDBorder = new Panel();
            txtPatientID = new TextBox();
            lblPatientID = new Label();
            lblPatientIDRuleHint = new Label();
            lblCccdRuleHint = new Label();
            pnlCCCDBorder = new Panel();
            txtCCCD = new TextBox();
            lblCCCD = new Label();
            lblGenderRuleHint = new Label();
            pnlGenderBorder = new Panel();
            txtGender = new TextBox();
            lblGender = new Label();
            lblBirthdayRuleHint = new Label();
            pnlBirthdayBorder = new Panel();
            lblBirthdayValue = new Label();
            dtpBirthday = new DateTimePicker();
            lblBirthday = new Label();
            pnlAddressBorder = new Panel();
            txtAddress = new TextBox();
            lblAddress = new Label();
            lblPhoneRuleHint = new Label();
            pnlPhoneBorder = new Panel();
            txtPhone = new TextBox();
            lblPhone = new Label();
            lblFullNameRuleHint = new Label();
            pnlFullNameBorder = new Panel();
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblPatientName = new Label();
            picAvatar = new PictureBox();
            btnEditBasicInfo = new Button();
            lblBasicInfoTitle = new Label();
            pnlMain.SuspendLayout();
            pnlSecurity.SuspendLayout();
            pnlChangePassword.SuspendLayout();
            pnlPassActions.SuspendLayout();
            pnlConfirmPassBorder.SuspendLayout();
            pnlNewPassBorder.SuspendLayout();
            pnlCurrentPassBorder.SuspendLayout();
            pnlMedicalProfile.SuspendLayout();
            pnlMedicalActions.SuspendLayout();
            pnlMedicalHistoryBorder.SuspendLayout();
            pnlBloodTypeBorder.SuspendLayout();
            pnlBHYTBorder.SuspendLayout();
            pnlBasicInfo.SuspendLayout();
            pnlBasicInfoActions.SuspendLayout();
            pnlEmergencyPhoneBorder.SuspendLayout();
            pnlEmergencyContactBorder.SuspendLayout();
            pnlPatientIDBorder.SuspendLayout();
            pnlCCCDBorder.SuspendLayout();
            pnlGenderBorder.SuspendLayout();
            pnlBirthdayBorder.SuspendLayout();
            pnlAddressBorder.SuspendLayout();
            pnlPhoneBorder.SuspendLayout();
            pnlFullNameBorder.SuspendLayout();
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
            pnlMain.Controls.Add(pnlMedicalProfile);
            pnlMain.Controls.Add(pnlBasicInfo);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(40, 30, 40, 100);
            pnlMain.Size = new Size(1690, 1953);
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
            pnlSecurity.Location = new Point(40, 1310);
            pnlSecurity.Margin = new Padding(0, 0, 0, 30);
            pnlSecurity.Name = "pnlSecurity";
            pnlSecurity.Size = new Size(1610, 500);
            pnlSecurity.TabIndex = 2;
            pnlSecurity.Paint += SectionPanel_Paint;
            // 
            // pnlChangePassword
            // 
            pnlChangePassword.Controls.Add(pnlPassActions);
            pnlChangePassword.Controls.Add(lblPasswordRuleHint);
            pnlChangePassword.Controls.Add(pnlConfirmPassBorder);
            pnlChangePassword.Controls.Add(lblConfirmPass);
            pnlChangePassword.Controls.Add(pnlNewPassBorder);
            pnlChangePassword.Controls.Add(lblNewPass);
            pnlChangePassword.Controls.Add(pnlCurrentPassBorder);
            pnlChangePassword.Controls.Add(lblCurrentPass);
            pnlChangePassword.Location = new Point(29, 70);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Size = new Size(1056, 400);
            pnlChangePassword.TabIndex = 3;
            pnlChangePassword.Visible = false;
            // 
            // pnlPassActions
            // 
            pnlPassActions.Controls.Add(btnCancelPass);
            pnlPassActions.Controls.Add(btnSavePass);
            pnlPassActions.Location = new Point(40, 330);
            pnlPassActions.Name = "pnlPassActions";
            pnlPassActions.Size = new Size(475, 70);
            pnlPassActions.TabIndex = 35;
            // 
            // btnCancelPass
            // 
            btnCancelPass.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelPass.FlatAppearance.BorderSize = 0;
            btnCancelPass.FlatStyle = FlatStyle.Flat;
            btnCancelPass.Font = new Font("Segoe UI", 16F);
            btnCancelPass.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelPass.Location = new Point(312, 5);
            btnCancelPass.Name = "btnCancelPass";
            btnCancelPass.Size = new Size(150, 62);
            btnCancelPass.TabIndex = 1;
            btnCancelPass.Text = "✕  Hủy";
            btnCancelPass.UseVisualStyleBackColor = false;
            btnCancelPass.Click += btnCancel_Click;
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
            btnSavePass.Size = new Size(302, 62);
            btnSavePass.TabIndex = 0;
            btnSavePass.Text = "💾  Lưu mật khẩu mới";
            btnSavePass.UseVisualStyleBackColor = false;
            btnSavePass.Click += btnSave_Click;
            btnSavePass.Paint += Button_Paint;
            // 
            // lblPasswordRuleHint
            // 
            lblPasswordRuleHint.BackColor = Color.Transparent;
            lblPasswordRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblPasswordRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPasswordRuleHint.Location = new Point(40, 281);
            lblPasswordRuleHint.Name = "lblPasswordRuleHint";
            lblPasswordRuleHint.Size = new Size(1015, 42);
            lblPasswordRuleHint.TabIndex = 39;
            lblPasswordRuleHint.Text = "Mật khẩu: 8-64 ký tự, có chữ hoa/thường, số, ký tự đặc biệt; không chứa khoảng trắng, SĐT hoặc họ tên.";
            lblPasswordRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlConfirmPassBorder
            // 
            pnlConfirmPassBorder.BackColor = Color.White;
            pnlConfirmPassBorder.Controls.Add(txtConfirmPass);
            pnlConfirmPassBorder.Location = new Point(40, 225);
            pnlConfirmPassBorder.Margin = new Padding(2);
            pnlConfirmPassBorder.Name = "pnlConfirmPassBorder";
            pnlConfirmPassBorder.Padding = new Padding(8);
            pnlConfirmPassBorder.Size = new Size(1015, 49);
            pnlConfirmPassBorder.TabIndex = 38;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BackColor = Color.White;
            txtConfirmPass.BorderStyle = BorderStyle.None;
            txtConfirmPass.Dock = DockStyle.Fill;
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.Location = new Point(8, 8);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderText = "Nhập lại đúng mật khẩu mới";
            txtConfirmPass.Size = new Size(999, 32);
            txtConfirmPass.TabIndex = 33;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPass.Location = new Point(40, 188);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(333, 32);
            lblConfirmPass.TabIndex = 32;
            lblConfirmPass.Text = "✅ Xác nhận mật khẩu mới *";
            // 
            // pnlNewPassBorder
            // 
            pnlNewPassBorder.BackColor = Color.White;
            pnlNewPassBorder.Controls.Add(txtNewPass);
            pnlNewPassBorder.Location = new Point(40, 136);
            pnlNewPassBorder.Margin = new Padding(2);
            pnlNewPassBorder.Name = "pnlNewPassBorder";
            pnlNewPassBorder.Padding = new Padding(8);
            pnlNewPassBorder.Size = new Size(1015, 49);
            pnlNewPassBorder.TabIndex = 37;
            // 
            // txtNewPass
            // 
            txtNewPass.BackColor = Color.White;
            txtNewPass.BorderStyle = BorderStyle.None;
            txtNewPass.Dock = DockStyle.Fill;
            txtNewPass.Font = new Font("Segoe UI", 12F);
            txtNewPass.Location = new Point(8, 8);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PlaceholderText = "Mật khẩu mới theo đúng quy định bảo mật";
            txtNewPass.Size = new Size(999, 32);
            txtNewPass.TabIndex = 30;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblNewPass.Location = new Point(40, 98);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(226, 32);
            lblNewPass.TabIndex = 29;
            lblNewPass.Text = "🆕 Mật khẩu mới *";
            // 
            // pnlCurrentPassBorder
            // 
            pnlCurrentPassBorder.BackColor = Color.White;
            pnlCurrentPassBorder.Controls.Add(txtCurrentPass);
            pnlCurrentPassBorder.Location = new Point(40, 45);
            pnlCurrentPassBorder.Margin = new Padding(2);
            pnlCurrentPassBorder.Name = "pnlCurrentPassBorder";
            pnlCurrentPassBorder.Padding = new Padding(8);
            pnlCurrentPassBorder.Size = new Size(1015, 49);
            pnlCurrentPassBorder.TabIndex = 36;
            // 
            // txtCurrentPass
            // 
            txtCurrentPass.BackColor = Color.White;
            txtCurrentPass.BorderStyle = BorderStyle.None;
            txtCurrentPass.Dock = DockStyle.Fill;
            txtCurrentPass.Font = new Font("Segoe UI", 12F);
            txtCurrentPass.Location = new Point(8, 8);
            txtCurrentPass.Name = "txtCurrentPass";
            txtCurrentPass.PlaceholderText = "Nhập mật khẩu hiện tại";
            txtCurrentPass.Size = new Size(999, 32);
            txtCurrentPass.TabIndex = 27;
            txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // lblCurrentPass
            // 
            lblCurrentPass.AutoSize = true;
            lblCurrentPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCurrentPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblCurrentPass.Location = new Point(40, 7);
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
            btnChangePassword.Location = new Point(1300, 20);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(288, 58);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Text = "✎  Đổi mật khẩu";
            btnChangePassword.TextAlign = ContentAlignment.MiddleRight;
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnEdit_Click;
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
            // pnlMedicalProfile
            // 
            pnlMedicalProfile.BackColor = Color.White;
            pnlMedicalProfile.Controls.Add(pnlMedicalActions);
            pnlMedicalProfile.Controls.Add(lblMedicalHistoryRuleHint);
            pnlMedicalProfile.Controls.Add(pnlMedicalHistoryBorder);
            pnlMedicalProfile.Controls.Add(lblMedicalHistory);
            pnlMedicalProfile.Controls.Add(lblBloodTypeRuleHint);
            pnlMedicalProfile.Controls.Add(pnlBloodTypeBorder);
            pnlMedicalProfile.Controls.Add(lblBloodType);
            pnlMedicalProfile.Controls.Add(btnEditMedical);
            pnlMedicalProfile.Controls.Add(lblBHYT);
            pnlMedicalProfile.Controls.Add(pnlBHYTBorder);
            pnlMedicalProfile.Controls.Add(lblMedicalTitle);
            pnlMedicalProfile.Dock = DockStyle.Top;
            pnlMedicalProfile.Location = new Point(40, 750);
            pnlMedicalProfile.Margin = new Padding(0, 0, 0, 30);
            pnlMedicalProfile.Name = "pnlMedicalProfile";
            pnlMedicalProfile.Size = new Size(1610, 560);
            pnlMedicalProfile.TabIndex = 1;
            pnlMedicalProfile.Paint += SectionPanel_Paint;
            // 
            // pnlMedicalActions
            // 
            pnlMedicalActions.Controls.Add(btnCancelMedical);
            pnlMedicalActions.Controls.Add(btnSaveMedical);
            pnlMedicalActions.Location = new Point(34, 480);
            pnlMedicalActions.Name = "pnlMedicalActions";
            pnlMedicalActions.Size = new Size(490, 70);
            pnlMedicalActions.TabIndex = 27;
            pnlMedicalActions.Visible = false;
            // 
            // btnCancelMedical
            // 
            btnCancelMedical.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelMedical.FlatAppearance.BorderSize = 0;
            btnCancelMedical.FlatStyle = FlatStyle.Flat;
            btnCancelMedical.Font = new Font("Segoe UI", 16F);
            btnCancelMedical.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelMedical.Location = new Point(332, 5);
            btnCancelMedical.Name = "btnCancelMedical";
            btnCancelMedical.Size = new Size(150, 60);
            btnCancelMedical.TabIndex = 1;
            btnCancelMedical.Text = "✕  Hủy";
            btnCancelMedical.UseVisualStyleBackColor = false;
            btnCancelMedical.Click += btnCancel_Click;
            btnCancelMedical.Paint += Button_Paint;
            // 
            // btnSaveMedical
            // 
            btnSaveMedical.BackColor = Color.FromArgb(37, 99, 235);
            btnSaveMedical.FlatAppearance.BorderSize = 0;
            btnSaveMedical.FlatStyle = FlatStyle.Flat;
            btnSaveMedical.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnSaveMedical.ForeColor = Color.White;
            btnSaveMedical.Location = new Point(5, 5);
            btnSaveMedical.Name = "btnSaveMedical";
            btnSaveMedical.Size = new Size(322, 60);
            btnSaveMedical.TabIndex = 0;
            btnSaveMedical.Text = "💾  Cập nhật hồ sơ y tế";
            btnSaveMedical.UseVisualStyleBackColor = false;
            btnSaveMedical.Click += btnSave_Click;
            btnSaveMedical.Paint += Button_Paint;
            // 
            // lblMedicalHistoryRuleHint
            // 
            lblMedicalHistoryRuleHint.BackColor = Color.Transparent;
            lblMedicalHistoryRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblMedicalHistoryRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblMedicalHistoryRuleHint.Location = new Point(350, 428);
            lblMedicalHistoryRuleHint.Name = "lblMedicalHistoryRuleHint";
            lblMedicalHistoryRuleHint.Size = new Size(1000, 36);
            lblMedicalHistoryRuleHint.TabIndex = 29;
            lblMedicalHistoryRuleHint.Text = "Tiền sử bệnh: tối đa 2000 ký tự.";
            lblMedicalHistoryRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlMedicalHistoryBorder
            // 
            pnlMedicalHistoryBorder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMedicalHistoryBorder.BackColor = Color.FromArgb(248, 249, 250);
            pnlMedicalHistoryBorder.Controls.Add(txtMedicalHistory);
            pnlMedicalHistoryBorder.Location = new Point(350, 171);
            pnlMedicalHistoryBorder.Margin = new Padding(2);
            pnlMedicalHistoryBorder.Name = "pnlMedicalHistoryBorder";
            pnlMedicalHistoryBorder.Padding = new Padding(8);
            pnlMedicalHistoryBorder.Size = new Size(1219, 252);
            pnlMedicalHistoryBorder.TabIndex = 21;
            // 
            // txtMedicalHistory
            // 
            txtMedicalHistory.BackColor = Color.FromArgb(248, 249, 250);
            txtMedicalHistory.BorderStyle = BorderStyle.None;
            txtMedicalHistory.Dock = DockStyle.Fill;
            txtMedicalHistory.Font = new Font("Segoe UI", 12F);
            txtMedicalHistory.Location = new Point(8, 8);
            txtMedicalHistory.Multiline = true;
            txtMedicalHistory.Name = "txtMedicalHistory";
            txtMedicalHistory.ReadOnly = true;
            txtMedicalHistory.Size = new Size(1203, 236);
            txtMedicalHistory.TabIndex = 21;
            // 
            // lblMedicalHistory
            // 
            lblMedicalHistory.AutoSize = true;
            lblMedicalHistory.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblMedicalHistory.ForeColor = Color.FromArgb(73, 80, 87);
            lblMedicalHistory.Location = new Point(350, 132);
            lblMedicalHistory.Name = "lblMedicalHistory";
            lblMedicalHistory.Size = new Size(154, 32);
            lblMedicalHistory.TabIndex = 20;
            lblMedicalHistory.Text = "Tiền sử bệnh";
            // 
            // lblBloodTypeRuleHint
            // 
            lblBloodTypeRuleHint.BackColor = Color.Transparent;
            lblBloodTypeRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblBloodTypeRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblBloodTypeRuleHint.Location = new Point(350, 130);
            lblBloodTypeRuleHint.Name = "lblBloodTypeRuleHint";
            lblBloodTypeRuleHint.Size = new Size(565, 36);
            lblBloodTypeRuleHint.TabIndex = 28;
            lblBloodTypeRuleHint.Text = "Nhóm máu: A, B, AB hoặc O; có thể kèm dấu + hoặc -.";
            lblBloodTypeRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBloodTypeBorder
            // 
            pnlBloodTypeBorder.BackColor = Color.White;
            pnlBloodTypeBorder.Controls.Add(txtBloodType);
            pnlBloodTypeBorder.Location = new Point(350, 77);
            pnlBloodTypeBorder.Margin = new Padding(2);
            pnlBloodTypeBorder.Name = "pnlBloodTypeBorder";
            pnlBloodTypeBorder.Padding = new Padding(8);
            pnlBloodTypeBorder.Size = new Size(565, 49);
            pnlBloodTypeBorder.TabIndex = 17;
            // 
            // txtBloodType
            // 
            txtBloodType.BackColor = Color.White;
            txtBloodType.BorderStyle = BorderStyle.None;
            txtBloodType.Dock = DockStyle.Fill;
            txtBloodType.Font = new Font("Segoe UI", 12F);
            txtBloodType.Location = new Point(8, 8);
            txtBloodType.Name = "txtBloodType";
            txtBloodType.ReadOnly = true;
            txtBloodType.Size = new Size(549, 32);
            txtBloodType.TabIndex = 17;
            // 
            // lblBloodType
            // 
            lblBloodType.AutoSize = true;
            lblBloodType.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBloodType.ForeColor = Color.FromArgb(73, 80, 87);
            lblBloodType.Location = new Point(350, 38);
            lblBloodType.Name = "lblBloodType";
            lblBloodType.Size = new Size(136, 32);
            lblBloodType.TabIndex = 16;
            lblBloodType.Text = "Nhóm máu";
            // 
            // btnEditMedical
            // 
            btnEditMedical.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditMedical.Cursor = Cursors.Hand;
            btnEditMedical.FlatAppearance.BorderSize = 0;
            btnEditMedical.FlatStyle = FlatStyle.Flat;
            btnEditMedical.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnEditMedical.ForeColor = Color.FromArgb(37, 99, 235);
            btnEditMedical.Location = new Point(1360, 9);
            btnEditMedical.Name = "btnEditMedical";
            btnEditMedical.Size = new Size(228, 58);
            btnEditMedical.TabIndex = 1;
            btnEditMedical.Text = "✎  Chỉnh sửa";
            btnEditMedical.TextAlign = ContentAlignment.MiddleRight;
            btnEditMedical.UseVisualStyleBackColor = true;
            btnEditMedical.Click += btnEdit_Click;
            // 
            // lblBHYT
            // 
            lblBHYT.AutoSize = true;
            lblBHYT.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBHYT.ForeColor = Color.FromArgb(73, 80, 87);
            lblBHYT.Location = new Point(978, 38);
            lblBHYT.Name = "lblBHYT";
            lblBHYT.Size = new Size(151, 32);
            lblBHYT.TabIndex = 16;
            lblBHYT.Text = "Số thẻ BHYT";
            // 
            // pnlBHYTBorder
            // 
            pnlBHYTBorder.BackColor = Color.White;
            pnlBHYTBorder.Controls.Add(txtBHYT);
            pnlBHYTBorder.Location = new Point(978, 77);
            pnlBHYTBorder.Margin = new Padding(2);
            pnlBHYTBorder.Name = "pnlBHYTBorder";
            pnlBHYTBorder.Padding = new Padding(8);
            pnlBHYTBorder.Size = new Size(565, 49);
            pnlBHYTBorder.TabIndex = 17;
            // 
            // txtBHYT
            // 
            txtBHYT.BackColor = Color.White;
            txtBHYT.BorderStyle = BorderStyle.None;
            txtBHYT.Dock = DockStyle.Fill;
            txtBHYT.Font = new Font("Segoe UI", 12F);
            txtBHYT.Location = new Point(8, 8);
            txtBHYT.Name = "txtBHYT";
            txtBHYT.ReadOnly = true;
            txtBHYT.Size = new Size(549, 32);
            txtBHYT.TabIndex = 17;
            // 
            // lblMedicalTitle
            // 
            lblMedicalTitle.AutoSize = true;
            lblMedicalTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMedicalTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblMedicalTitle.Location = new Point(20, 20);
            lblMedicalTitle.Name = "lblMedicalTitle";
            lblMedicalTitle.Size = new Size(226, 45);
            lblMedicalTitle.TabIndex = 0;
            lblMedicalTitle.Text = "🏥 Hồ sơ y tế";
            // 
            // pnlBasicInfo
            // 
            pnlBasicInfo.BackColor = Color.White;
            pnlBasicInfo.Controls.Add(pnlBasicInfoActions);
            pnlBasicInfo.Controls.Add(lblAddressRuleHint);
            pnlBasicInfo.Controls.Add(lblUpload);
            pnlBasicInfo.Controls.Add(lblEmergencyPhoneRuleHint);
            pnlBasicInfo.Controls.Add(pnlEmergencyPhoneBorder);
            pnlBasicInfo.Controls.Add(lblEmergencyPhone);
            pnlBasicInfo.Controls.Add(lblEmergencyContactRuleHint);
            pnlBasicInfo.Controls.Add(pnlEmergencyContactBorder);
            pnlBasicInfo.Controls.Add(lblEmergencyContact);
            pnlBasicInfo.Controls.Add(pnlPatientIDBorder);
            pnlBasicInfo.Controls.Add(lblPatientID);
            pnlBasicInfo.Controls.Add(lblPatientIDRuleHint);
            pnlBasicInfo.Controls.Add(lblCccdRuleHint);
            pnlBasicInfo.Controls.Add(pnlCCCDBorder);
            pnlBasicInfo.Controls.Add(lblCCCD);
            pnlBasicInfo.Controls.Add(lblGenderRuleHint);
            pnlBasicInfo.Controls.Add(pnlGenderBorder);
            pnlBasicInfo.Controls.Add(lblGender);
            pnlBasicInfo.Controls.Add(lblBirthdayRuleHint);
            pnlBasicInfo.Controls.Add(pnlBirthdayBorder);
            pnlBasicInfo.Controls.Add(lblBirthday);
            pnlBasicInfo.Controls.Add(pnlAddressBorder);
            pnlBasicInfo.Controls.Add(lblAddress);
            pnlBasicInfo.Controls.Add(lblPhoneRuleHint);
            pnlBasicInfo.Controls.Add(pnlPhoneBorder);
            pnlBasicInfo.Controls.Add(lblPhone);
            pnlBasicInfo.Controls.Add(lblFullNameRuleHint);
            pnlBasicInfo.Controls.Add(pnlFullNameBorder);
            pnlBasicInfo.Controls.Add(lblFullName);
            pnlBasicInfo.Controls.Add(lblPatientName);
            pnlBasicInfo.Controls.Add(picAvatar);
            pnlBasicInfo.Controls.Add(btnEditBasicInfo);
            pnlBasicInfo.Controls.Add(lblBasicInfoTitle);
            pnlBasicInfo.Dock = DockStyle.Top;
            pnlBasicInfo.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlBasicInfo.Location = new Point(40, 30);
            pnlBasicInfo.Margin = new Padding(0, 0, 0, 30);
            pnlBasicInfo.Name = "pnlBasicInfo";
            pnlBasicInfo.Size = new Size(1610, 720);
            pnlBasicInfo.TabIndex = 0;
            pnlBasicInfo.Paint += SectionPanel_Paint;
            // 
            // pnlBasicInfoActions
            // 
            pnlBasicInfoActions.Controls.Add(btnCancelBasicInfo);
            pnlBasicInfoActions.Controls.Add(btnSaveBasicInfo);
            pnlBasicInfoActions.Location = new Point(34, 625);
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
            btnCancelBasicInfo.Click += btnCancel_Click;
            btnCancelBasicInfo.Paint += Button_Paint;
            // 
            // btnSaveBasicInfo
            // 
            btnSaveBasicInfo.BackColor = Color.FromArgb(37, 99, 235);
            btnSaveBasicInfo.FlatAppearance.BorderSize = 0;
            btnSaveBasicInfo.FlatStyle = FlatStyle.Flat;
            btnSaveBasicInfo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnSaveBasicInfo.ForeColor = Color.White;
            btnSaveBasicInfo.Location = new Point(5, 5);
            btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            btnSaveBasicInfo.Size = new Size(311, 60);
            btnSaveBasicInfo.TabIndex = 0;
            btnSaveBasicInfo.Text = "💾  Lưu thay đổi";
            btnSaveBasicInfo.UseVisualStyleBackColor = false;
            btnSaveBasicInfo.Click += btnSave_Click;
            btnSaveBasicInfo.Paint += Button_Paint;
            // 
            // lblAddressRuleHint
            // 
            lblAddressRuleHint.BackColor = Color.Transparent;
            lblAddressRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblAddressRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblAddressRuleHint.Location = new Point(350, 568);
            lblAddressRuleHint.Name = "lblAddressRuleHint";
            lblAddressRuleHint.Size = new Size(1193, 36);
            lblAddressRuleHint.TabIndex = 45;
            lblAddressRuleHint.Text = "Địa chỉ: 5-255 ký tự, không chứa ký tự điều khiển.";
            lblAddressRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEmergencyPhoneRuleHint
            // 
            lblEmergencyPhoneRuleHint.BackColor = Color.Transparent;
            lblEmergencyPhoneRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblEmergencyPhoneRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblEmergencyPhoneRuleHint.Location = new Point(350, 284);
            lblEmergencyPhoneRuleHint.Name = "lblEmergencyPhoneRuleHint";
            lblEmergencyPhoneRuleHint.Size = new Size(565, 36);
            lblEmergencyPhoneRuleHint.TabIndex = 40;
            lblEmergencyPhoneRuleHint.Text = "SĐT khẩn cấp: nếu nhập thì phải đúng 10 chữ số, bắt đầu bằng 0.";
            lblEmergencyPhoneRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEmergencyPhoneBorder
            // 
            pnlEmergencyPhoneBorder.BackColor = Color.White;
            pnlEmergencyPhoneBorder.Controls.Add(txtEmergencyPhone);
            pnlEmergencyPhoneBorder.Location = new Point(350, 231);
            pnlEmergencyPhoneBorder.Margin = new Padding(2);
            pnlEmergencyPhoneBorder.Name = "pnlEmergencyPhoneBorder";
            pnlEmergencyPhoneBorder.Padding = new Padding(8);
            pnlEmergencyPhoneBorder.Size = new Size(565, 49);
            pnlEmergencyPhoneBorder.TabIndex = 23;
            // 
            // txtEmergencyPhone
            // 
            txtEmergencyPhone.BackColor = Color.White;
            txtEmergencyPhone.BorderStyle = BorderStyle.None;
            txtEmergencyPhone.Dock = DockStyle.Fill;
            txtEmergencyPhone.Font = new Font("Segoe UI", 12F);
            txtEmergencyPhone.Location = new Point(8, 8);
            txtEmergencyPhone.Name = "txtEmergencyPhone";
            txtEmergencyPhone.ReadOnly = true;
            txtEmergencyPhone.Size = new Size(549, 32);
            txtEmergencyPhone.TabIndex = 23;
            // 
            // lblEmergencyPhone
            // 
            lblEmergencyPhone.AutoSize = true;
            lblEmergencyPhone.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEmergencyPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmergencyPhone.Location = new Point(350, 194);
            lblEmergencyPhone.Name = "lblEmergencyPhone";
            lblEmergencyPhone.Size = new Size(243, 32);
            lblEmergencyPhone.TabIndex = 22;
            lblEmergencyPhone.Text = "SĐT liên hệ khẩn cấp";
            // 
            // lblEmergencyContactRuleHint
            // 
            lblEmergencyContactRuleHint.BackColor = Color.Transparent;
            lblEmergencyContactRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblEmergencyContactRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblEmergencyContactRuleHint.Location = new Point(350, 472);
            lblEmergencyContactRuleHint.Name = "lblEmergencyContactRuleHint";
            lblEmergencyContactRuleHint.Size = new Size(565, 36);
            lblEmergencyContactRuleHint.TabIndex = 41;
            lblEmergencyContactRuleHint.Text = "Tên liên hệ khẩn cấp: tối đa 100 ký tự.";
            lblEmergencyContactRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEmergencyContactBorder
            // 
            pnlEmergencyContactBorder.BackColor = Color.White;
            pnlEmergencyContactBorder.Controls.Add(txtEmergencyContact);
            pnlEmergencyContactBorder.Location = new Point(350, 420);
            pnlEmergencyContactBorder.Margin = new Padding(2);
            pnlEmergencyContactBorder.Name = "pnlEmergencyContactBorder";
            pnlEmergencyContactBorder.Padding = new Padding(8);
            pnlEmergencyContactBorder.Size = new Size(565, 49);
            pnlEmergencyContactBorder.TabIndex = 21;
            // 
            // txtEmergencyContact
            // 
            txtEmergencyContact.BackColor = Color.White;
            txtEmergencyContact.BorderStyle = BorderStyle.None;
            txtEmergencyContact.Dock = DockStyle.Fill;
            txtEmergencyContact.Font = new Font("Segoe UI", 12F);
            txtEmergencyContact.Location = new Point(8, 8);
            txtEmergencyContact.Name = "txtEmergencyContact";
            txtEmergencyContact.ReadOnly = true;
            txtEmergencyContact.Size = new Size(549, 32);
            txtEmergencyContact.TabIndex = 21;
            // 
            // lblEmergencyContact
            // 
            lblEmergencyContact.AutoSize = true;
            lblEmergencyContact.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEmergencyContact.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmergencyContact.Location = new Point(350, 383);
            lblEmergencyContact.Name = "lblEmergencyContact";
            lblEmergencyContact.Size = new Size(268, 32);
            lblEmergencyContact.TabIndex = 20;
            lblEmergencyContact.Text = "Người liên hệ khẩn cấp";
            // 
            // pnlPatientIDBorder
            // 
            pnlPatientIDBorder.BackColor = Color.White;
            pnlPatientIDBorder.Controls.Add(txtPatientID);
            pnlPatientIDBorder.Location = new Point(992, 420);
            pnlPatientIDBorder.Margin = new Padding(2);
            pnlPatientIDBorder.Name = "pnlPatientIDBorder";
            pnlPatientIDBorder.Padding = new Padding(8);
            pnlPatientIDBorder.Size = new Size(565, 49);
            pnlPatientIDBorder.TabIndex = 19;
            // 
            // txtPatientID
            // 
            txtPatientID.BackColor = Color.White;
            txtPatientID.BorderStyle = BorderStyle.None;
            txtPatientID.Dock = DockStyle.Fill;
            txtPatientID.Font = new Font("Segoe UI", 12F);
            txtPatientID.Location = new Point(8, 8);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.ReadOnly = true;
            txtPatientID.Size = new Size(549, 32);
            txtPatientID.TabIndex = 19;
            // 
            // lblPatientID
            //
            lblPatientID.AutoSize = true;
            lblPatientID.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPatientID.ForeColor = Color.FromArgb(73, 80, 87);
            lblPatientID.Location = new Point(992, 383);
            lblPatientID.Name = "lblPatientID";
            lblPatientID.Size = new Size(173, 32);
            lblPatientID.TabIndex = 18;
            lblPatientID.Text = "Mã BN";
            //
            // lblPatientIDRuleHint
            //
            lblPatientIDRuleHint.BackColor = Color.Transparent;
            lblPatientIDRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblPatientIDRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPatientIDRuleHint.Location = new Point(992, 472);
            lblPatientIDRuleHint.Name = "lblPatientIDRuleHint";
            lblPatientIDRuleHint.Size = new Size(565, 32);
            lblPatientIDRuleHint.TabIndex = 48;
            lblPatientIDRuleHint.Text = "Mã BN do hệ thống cấp, không thể chỉnh sửa.";
            lblPatientIDRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCccdRuleHint
            // 
            lblCccdRuleHint.BackColor = Color.Transparent;
            lblCccdRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblCccdRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblCccdRuleHint.Location = new Point(992, 376);
            lblCccdRuleHint.Name = "lblCccdRuleHint";
            lblCccdRuleHint.Size = new Size(565, 36);
            lblCccdRuleHint.TabIndex = 42;
            lblCccdRuleHint.Text = "CCCD: đúng 12 chữ số nếu bệnh nhân từ 16 tuổi trở lên.";
            lblCccdRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCCCDBorder
            // 
            pnlCCCDBorder.BackColor = Color.White;
            pnlCCCDBorder.Controls.Add(txtCCCD);
            pnlCCCDBorder.Location = new Point(992, 320);
            pnlCCCDBorder.Margin = new Padding(2);
            pnlCCCDBorder.Name = "pnlCCCDBorder";
            pnlCCCDBorder.Padding = new Padding(8);
            pnlCCCDBorder.Size = new Size(565, 49);
            pnlCCCDBorder.TabIndex = 15;
            // 
            // txtCCCD
            // 
            txtCCCD.BackColor = Color.White;
            txtCCCD.BorderStyle = BorderStyle.None;
            txtCCCD.Dock = DockStyle.Fill;
            txtCCCD.Font = new Font("Segoe UI", 12F);
            txtCCCD.Location = new Point(8, 8);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.ReadOnly = true;
            txtCCCD.Size = new Size(549, 32);
            txtCCCD.TabIndex = 15;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCCCD.ForeColor = Color.FromArgb(73, 80, 87);
            lblCCCD.Location = new Point(992, 283);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(229, 32);
            lblCCCD.TabIndex = 14;
            lblCCCD.Text = "Số CCCD / Hộ chiếu";
            // 
            // lblGenderRuleHint
            // 
            lblGenderRuleHint.BackColor = Color.Transparent;
            lblGenderRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblGenderRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblGenderRuleHint.Location = new Point(350, 380);
            lblGenderRuleHint.Name = "lblGenderRuleHint";
            lblGenderRuleHint.Size = new Size(565, 36);
            lblGenderRuleHint.TabIndex = 43;
            lblGenderRuleHint.Text = "Giới tính: chỉ nhập Nam hoặc Nữ.";
            lblGenderRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlGenderBorder
            // 
            pnlGenderBorder.BackColor = Color.White;
            pnlGenderBorder.Controls.Add(txtGender);
            pnlGenderBorder.Location = new Point(350, 325);
            pnlGenderBorder.Margin = new Padding(2);
            pnlGenderBorder.Name = "pnlGenderBorder";
            pnlGenderBorder.Padding = new Padding(8);
            pnlGenderBorder.Size = new Size(565, 49);
            pnlGenderBorder.TabIndex = 13;
            // 
            // txtGender
            // 
            txtGender.BackColor = Color.White;
            txtGender.BorderStyle = BorderStyle.None;
            txtGender.Dock = DockStyle.Fill;
            txtGender.Font = new Font("Segoe UI", 12F);
            txtGender.Location = new Point(8, 8);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(549, 32);
            txtGender.TabIndex = 13;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(73, 80, 87);
            lblGender.Location = new Point(350, 288);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(108, 32);
            lblGender.TabIndex = 12;
            lblGender.Text = "Giới tính";
            // 
            // lblBirthdayRuleHint
            // 
            lblBirthdayRuleHint.BackColor = Color.Transparent;
            lblBirthdayRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblBirthdayRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblBirthdayRuleHint.Location = new Point(992, 282);
            lblBirthdayRuleHint.Name = "lblBirthdayRuleHint";
            lblBirthdayRuleHint.Size = new Size(565, 36);
            lblBirthdayRuleHint.TabIndex = 44;
            lblBirthdayRuleHint.Text = "Ngày sinh: không ở tương lai; từ 16 tuổi trở lên bắt buộc có CCCD.";
            lblBirthdayRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBirthdayBorder
            //
            pnlBirthdayBorder.BackColor = Color.White;
            pnlBirthdayBorder.Controls.Add(lblBirthdayValue);
            pnlBirthdayBorder.Controls.Add(dtpBirthday);
            pnlBirthdayBorder.Location = new Point(992, 230);
            pnlBirthdayBorder.Margin = new Padding(2);
            pnlBirthdayBorder.Name = "pnlBirthdayBorder";
            pnlBirthdayBorder.Padding = new Padding(12, 6, 12, 6);
            pnlBirthdayBorder.Size = new Size(565, 54);
            pnlBirthdayBorder.TabIndex = 11;
            //
            // lblBirthdayValue
            //
            lblBirthdayValue.BackColor = Color.Transparent;
            lblBirthdayValue.Dock = DockStyle.Fill;
            lblBirthdayValue.Font = new Font("Segoe UI", 12F);
            lblBirthdayValue.ForeColor = Color.FromArgb(33, 37, 41);
            lblBirthdayValue.Location = new Point(12, 6);
            lblBirthdayValue.Name = "lblBirthdayValue";
            lblBirthdayValue.Size = new Size(541, 42);
            lblBirthdayValue.TabIndex = 12;
            lblBirthdayValue.Text = "01 / 01 / 1990";
            lblBirthdayValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpBirthday
            //
            dtpBirthday.CalendarFont = new Font("Segoe UI", 12F);
            dtpBirthday.CustomFormat = "dd / MM / yyyy";
            dtpBirthday.Dock = DockStyle.Fill;
            dtpBirthday.Font = new Font("Segoe UI", 12F);
            dtpBirthday.Format = DateTimePickerFormat.Custom;
            dtpBirthday.Location = new Point(12, 6);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(541, 42);
            dtpBirthday.TabIndex = 11;
            dtpBirthday.Visible = false;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBirthday.ForeColor = Color.FromArgb(73, 80, 87);
            lblBirthday.Location = new Point(992, 192);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(122, 32);
            lblBirthday.TabIndex = 10;
            lblBirthday.Text = "Ngày sinh";
            // 
            // pnlAddressBorder
            // 
            pnlAddressBorder.BackColor = Color.White;
            pnlAddressBorder.Controls.Add(txtAddress);
            pnlAddressBorder.Location = new Point(350, 515);
            pnlAddressBorder.Margin = new Padding(2);
            pnlAddressBorder.Name = "pnlAddressBorder";
            pnlAddressBorder.Padding = new Padding(8);
            pnlAddressBorder.Size = new Size(1193, 49);
            pnlAddressBorder.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.White;
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(8, 8);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(1177, 32);
            txtAddress.TabIndex = 9;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(73, 80, 87);
            lblAddress.Location = new Point(350, 476);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(88, 32);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Địa chỉ";
            // 
            // lblPhoneRuleHint
            // 
            lblPhoneRuleHint.BackColor = Color.Transparent;
            lblPhoneRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblPhoneRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPhoneRuleHint.Location = new Point(992, 188);
            lblPhoneRuleHint.Name = "lblPhoneRuleHint";
            lblPhoneRuleHint.Size = new Size(565, 36);
            lblPhoneRuleHint.TabIndex = 46;
            lblPhoneRuleHint.Text = "SĐT: đúng 10 chữ số, bắt đầu bằng 0 và không trùng tài khoản khác.";
            lblPhoneRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPhoneBorder
            // 
            pnlPhoneBorder.BackColor = Color.White;
            pnlPhoneBorder.Controls.Add(txtPhone);
            pnlPhoneBorder.Location = new Point(992, 135);
            pnlPhoneBorder.Margin = new Padding(2);
            pnlPhoneBorder.Name = "pnlPhoneBorder";
            pnlPhoneBorder.Padding = new Padding(8);
            pnlPhoneBorder.Size = new Size(565, 49);
            pnlPhoneBorder.TabIndex = 7;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.White;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(8, 8);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(549, 32);
            txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblPhone.Location = new Point(992, 98);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(159, 32);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại";
            // 
            // lblFullNameRuleHint
            // 
            lblFullNameRuleHint.BackColor = Color.Transparent;
            lblFullNameRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblFullNameRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblFullNameRuleHint.Location = new Point(350, 188);
            lblFullNameRuleHint.Name = "lblFullNameRuleHint";
            lblFullNameRuleHint.Size = new Size(565, 36);
            lblFullNameRuleHint.TabIndex = 47;
            lblFullNameRuleHint.Text = "Họ tên: 2-100 ký tự, chỉ dùng chữ cái và khoảng trắng.";
            lblFullNameRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFullNameBorder
            // 
            pnlFullNameBorder.BackColor = Color.White;
            pnlFullNameBorder.Controls.Add(txtFullName);
            pnlFullNameBorder.Location = new Point(350, 135);
            pnlFullNameBorder.Margin = new Padding(2);
            pnlFullNameBorder.Name = "pnlFullNameBorder";
            pnlFullNameBorder.Padding = new Padding(8);
            pnlFullNameBorder.Size = new Size(565, 49);
            pnlFullNameBorder.TabIndex = 5;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.White;
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Dock = DockStyle.Fill;
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(8, 8);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(549, 32);
            txtFullName.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(73, 80, 87);
            lblFullName.Location = new Point(350, 98);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(121, 32);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên";
            // 
            // lblPatientName
            // 
            lblPatientName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblPatientName.Location = new Point(25, 390);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(300, 80);
            lblPatientName.TabIndex = 3;
            lblPatientName.Text = "Nguyễn Văn Minh";
            lblPatientName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(241, 243, 245);
            picAvatar.Location = new Point(25, 80);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(300, 307);
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
            btnEditBasicInfo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnEditBasicInfo.ForeColor = Color.FromArgb(37, 99, 235);
            btnEditBasicInfo.Location = new Point(1360, 7);
            btnEditBasicInfo.Name = "btnEditBasicInfo";
            btnEditBasicInfo.Size = new Size(228, 58);
            btnEditBasicInfo.TabIndex = 1;
            btnEditBasicInfo.Text = "✎  Chỉnh sửa";
            btnEditBasicInfo.TextAlign = ContentAlignment.MiddleRight;
            btnEditBasicInfo.UseVisualStyleBackColor = true;
            btnEditBasicInfo.Click += btnEdit_Click;
            // 
            // lblBasicInfoTitle
            // 
            lblBasicInfoTitle.AutoSize = true;
            lblBasicInfoTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBasicInfoTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblBasicInfoTitle.Location = new Point(20, 20);
            lblBasicInfoTitle.Name = "lblBasicInfoTitle";
            lblBasicInfoTitle.Size = new Size(329, 45);
            lblBasicInfoTitle.TabIndex = 0;
            lblBasicInfoTitle.Text = "👤 Thông tin cơ bản";
            // 
            // ucPatient_Profile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucPatient_Profile";
            Size = new Size(1690, 1953);
            pnlMain.ResumeLayout(false);
            pnlSecurity.ResumeLayout(false);
            pnlSecurity.PerformLayout();
            pnlChangePassword.ResumeLayout(false);
            pnlChangePassword.PerformLayout();
            pnlPassActions.ResumeLayout(false);
            pnlConfirmPassBorder.ResumeLayout(false);
            pnlConfirmPassBorder.PerformLayout();
            pnlNewPassBorder.ResumeLayout(false);
            pnlNewPassBorder.PerformLayout();
            pnlCurrentPassBorder.ResumeLayout(false);
            pnlCurrentPassBorder.PerformLayout();
            pnlMedicalProfile.ResumeLayout(false);
            pnlMedicalProfile.PerformLayout();
            pnlMedicalActions.ResumeLayout(false);
            pnlMedicalHistoryBorder.ResumeLayout(false);
            pnlMedicalHistoryBorder.PerformLayout();
            pnlBloodTypeBorder.ResumeLayout(false);
            pnlBloodTypeBorder.PerformLayout();
            pnlBHYTBorder.ResumeLayout(false);
            pnlBHYTBorder.PerformLayout();
            pnlBasicInfo.ResumeLayout(false);
            pnlBasicInfo.PerformLayout();
            pnlBasicInfoActions.ResumeLayout(false);
            pnlEmergencyPhoneBorder.ResumeLayout(false);
            pnlEmergencyPhoneBorder.PerformLayout();
            pnlEmergencyContactBorder.ResumeLayout(false);
            pnlEmergencyContactBorder.PerformLayout();
            pnlPatientIDBorder.ResumeLayout(false);
            pnlPatientIDBorder.PerformLayout();
            pnlCCCDBorder.ResumeLayout(false);
            pnlCCCDBorder.PerformLayout();
            pnlGenderBorder.ResumeLayout(false);
            pnlGenderBorder.PerformLayout();
            pnlBirthdayBorder.ResumeLayout(false);
            pnlAddressBorder.ResumeLayout(false);
            pnlAddressBorder.PerformLayout();
            pnlPhoneBorder.ResumeLayout(false);
            pnlPhoneBorder.PerformLayout();
            pnlFullNameBorder.ResumeLayout(false);
            pnlFullNameBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlBasicInfo;
        private Label lblUpload;
        private Label lblBasicInfoTitle;
        private Button btnEditBasicInfo;
        private PictureBox picAvatar;
        private Label lblPatientName;
        private TextBox txtFullName;
        private Label lblFullName;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtAddress;
        private DateTimePicker dtpBirthday;
        private Label lblBirthdayValue;
        private Label lblBirthday;
        private TextBox txtGender;
        private Label lblGender;
        private TextBox txtCCCD;
        private Label lblCCCD;
        private TextBox txtBHYT;
        private Label lblBHYT;
        private TextBox txtPatientID;
        private Label lblPatientID;
        private TextBox txtEmergencyContact;
        private Label lblEmergencyContact;
        private TextBox txtEmergencyPhone;
        private Label lblEmergencyPhone;
        private Label lblAddress;
        private Panel pnlBasicInfoActions;
        private Button btnSaveBasicInfo;
        private Button btnCancelBasicInfo;
        private Panel pnlFullNameBorder;
        private Panel pnlPhoneBorder;
        private Panel pnlGenderBorder;
        private Panel pnlBirthdayBorder;
        private Panel pnlCCCDBorder;
        private Panel pnlAddressBorder;
        private Panel pnlEmergencyContactBorder;
        private Panel pnlEmergencyPhoneBorder;
        private Panel pnlPatientIDBorder;

        private Panel pnlMedicalProfile;
        private Label lblMedicalTitle;
        private Button btnEditMedical;
        private Panel pnlBloodTypeBorder;
        private TextBox txtBloodType;
        private Label lblBloodType;
        private Panel pnlMedicalHistoryBorder;
        private TextBox txtMedicalHistory;
        private Label lblMedicalHistory;
        private Panel pnlMedicalActions;
        private Button btnSaveMedical;
        private Button btnCancelMedical;
        private Panel pnlBHYTBorder;

        private Panel pnlSecurity;
        private Label lblSecurityTitle;
        private Button btnChangePassword;
        private Label lblSecurityHint;

        private Panel pnlChangePassword;
        private Label lblCurrentPass;
        private Panel pnlCurrentPassBorder;
        private TextBox txtCurrentPass;
        private Label lblNewPass;
        private Panel pnlNewPassBorder;
        private TextBox txtNewPass;
        private Label lblConfirmPass;
        private Panel pnlConfirmPassBorder;
        private TextBox txtConfirmPass;
        private Panel pnlPassActions;
        private Button btnSavePass;
        private Button btnCancelPass;
        private Label lblPasswordRuleHint;
        private Label lblMedicalHistoryRuleHint;
        private Label lblBloodTypeRuleHint;
        private Label lblEmergencyPhoneRuleHint;
        private Label lblEmergencyContactRuleHint;
        private Label lblCccdRuleHint;
        private Label lblGenderRuleHint;
        private Label lblBirthdayRuleHint;
        private Label lblAddressRuleHint;
        private Label lblPhoneRuleHint;
        private Label lblFullNameRuleHint;
        private Label lblPatientIDRuleHint;
    }
}
