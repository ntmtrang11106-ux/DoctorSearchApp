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
            lblUpload.Location = new Point(344, 415);
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
            pnlMain.Controls.Add(pnlMedicalProfile);
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
            pnlSecurity.Location = new Point(52, 1922);
            pnlSecurity.Margin = new Padding(0, 0, 0, 38);
            pnlSecurity.Name = "pnlSecurity";
            pnlSecurity.Size = new Size(2059, 667);
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
            pnlChangePassword.Location = new Point(38, 90);
            pnlChangePassword.Margin = new Padding(4);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Size = new Size(1708, 542);
            pnlChangePassword.TabIndex = 3;
            pnlChangePassword.Visible = false;
            // 
            // pnlPassActions
            // 
            pnlPassActions.Controls.Add(btnCancelPass);
            pnlPassActions.Controls.Add(btnSavePass);
            pnlPassActions.Location = new Point(52, 430);
            pnlPassActions.Margin = new Padding(4);
            pnlPassActions.Name = "pnlPassActions";
            pnlPassActions.Size = new Size(618, 90);
            pnlPassActions.TabIndex = 35;
            // 
            // btnCancelPass
            // 
            btnCancelPass.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelPass.FlatAppearance.BorderSize = 0;
            btnCancelPass.FlatStyle = FlatStyle.Flat;
            btnCancelPass.Font = new Font("Segoe UI", 14F);
            btnCancelPass.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelPass.Location = new Point(423, 21);
            btnCancelPass.Margin = new Padding(4);
            btnCancelPass.Name = "btnCancelPass";
            btnCancelPass.Size = new Size(195, 64);
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
            btnSavePass.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnSavePass.ForeColor = Color.White;
            btnSavePass.Location = new Point(6, 21);
            btnSavePass.Margin = new Padding(4);
            btnSavePass.Name = "btnSavePass";
            btnSavePass.Size = new Size(373, 64);
            btnSavePass.TabIndex = 0;
            btnSavePass.Text = "Lưu mật khẩu mới";
            btnSavePass.UseVisualStyleBackColor = false;
            btnSavePass.Click += btnSave_Click;
            btnSavePass.Paint += Button_Paint;
            // 
            // lblPasswordRuleHint
            // 
            lblPasswordRuleHint.BackColor = Color.Transparent;
            lblPasswordRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblPasswordRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPasswordRuleHint.Location = new Point(52, 378);
            lblPasswordRuleHint.Margin = new Padding(0);
            lblPasswordRuleHint.Name = "lblPasswordRuleHint";
            lblPasswordRuleHint.Size = new Size(1320, 40);
            lblPasswordRuleHint.TabIndex = 39;
            lblPasswordRuleHint.Text = "Mật khẩu: 8-64 ký tự, có chữ hoa/thường, số, ký tự đặc biệt; không chứa khoảng trắng, SĐT hoặc họ tên.";
            lblPasswordRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlConfirmPassBorder
            // 
            pnlConfirmPassBorder.BackColor = Color.White;
            pnlConfirmPassBorder.Controls.Add(txtConfirmPass);
            pnlConfirmPassBorder.Location = new Point(52, 312);
            pnlConfirmPassBorder.Name = "pnlConfirmPassBorder";
            pnlConfirmPassBorder.Padding = new Padding(10);
            pnlConfirmPassBorder.Size = new Size(1320, 63);
            pnlConfirmPassBorder.TabIndex = 38;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BackColor = Color.White;
            txtConfirmPass.BorderStyle = BorderStyle.None;
            txtConfirmPass.Dock = DockStyle.Fill;
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.Location = new Point(10, 10);
            txtConfirmPass.Margin = new Padding(4);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderText = "Nhập lại đúng mật khẩu mới";
            txtConfirmPass.Size = new Size(1300, 43);
            txtConfirmPass.TabIndex = 33;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPass.Location = new Point(52, 265);
            lblConfirmPass.Margin = new Padding(4, 0, 4, 0);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(390, 45);
            lblConfirmPass.TabIndex = 32;
            lblConfirmPass.Text = "Xác nhận mật khẩu mới *";
            // 
            // pnlNewPassBorder
            // 
            pnlNewPassBorder.BackColor = Color.White;
            pnlNewPassBorder.Controls.Add(txtNewPass);
            pnlNewPassBorder.Location = new Point(52, 182);
            pnlNewPassBorder.Name = "pnlNewPassBorder";
            pnlNewPassBorder.Padding = new Padding(10);
            pnlNewPassBorder.Size = new Size(1320, 63);
            pnlNewPassBorder.TabIndex = 37;
            // 
            // txtNewPass
            // 
            txtNewPass.BackColor = Color.White;
            txtNewPass.BorderStyle = BorderStyle.None;
            txtNewPass.Dock = DockStyle.Fill;
            txtNewPass.Font = new Font("Segoe UI", 12F);
            txtNewPass.Location = new Point(10, 10);
            txtNewPass.Margin = new Padding(4);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PlaceholderText = "Mật khẩu mới theo đúng quy định bảo mật";
            txtNewPass.Size = new Size(1300, 43);
            txtNewPass.TabIndex = 30;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblNewPass.Location = new Point(52, 133);
            lblNewPass.Margin = new Padding(4, 0, 4, 0);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(248, 45);
            lblNewPass.TabIndex = 29;
            lblNewPass.Text = "Mật khẩu mới *";
            // 
            // pnlCurrentPassBorder
            // 
            pnlCurrentPassBorder.BackColor = Color.White;
            pnlCurrentPassBorder.Controls.Add(txtCurrentPass);
            pnlCurrentPassBorder.Location = new Point(52, 58);
            pnlCurrentPassBorder.Name = "pnlCurrentPassBorder";
            pnlCurrentPassBorder.Padding = new Padding(10);
            pnlCurrentPassBorder.Size = new Size(1320, 63);
            pnlCurrentPassBorder.TabIndex = 36;
            // 
            // txtCurrentPass
            // 
            txtCurrentPass.BackColor = Color.White;
            txtCurrentPass.BorderStyle = BorderStyle.None;
            txtCurrentPass.Dock = DockStyle.Fill;
            txtCurrentPass.Font = new Font("Segoe UI", 12F);
            txtCurrentPass.Location = new Point(10, 10);
            txtCurrentPass.Margin = new Padding(4);
            txtCurrentPass.Name = "txtCurrentPass";
            txtCurrentPass.PlaceholderText = "Nhập mật khẩu hiện tại";
            txtCurrentPass.Size = new Size(1300, 43);
            txtCurrentPass.TabIndex = 27;
            txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // lblCurrentPass
            // 
            lblCurrentPass.AutoSize = true;
            lblCurrentPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCurrentPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblCurrentPass.Location = new Point(52, 9);
            lblCurrentPass.Margin = new Padding(4, 0, 4, 0);
            lblCurrentPass.Name = "lblCurrentPass";
            lblCurrentPass.Size = new Size(301, 45);
            lblCurrentPass.TabIndex = 26;
            lblCurrentPass.Text = "Mật khẩu hiện tại *";
            // 
            // lblSecurityHint
            // 
            lblSecurityHint.AutoSize = true;
            lblSecurityHint.Font = new Font("Segoe UI", 10F);
            lblSecurityHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblSecurityHint.Location = new Point(39, 109);
            lblSecurityHint.Margin = new Padding(4, 0, 4, 0);
            lblSecurityHint.Name = "lblSecurityHint";
            lblSecurityHint.Size = new Size(845, 37);
            lblSecurityHint.TabIndex = 2;
            lblSecurityHint.Text = "Mật khẩu mới cần 8-64 ký tự, có chữ hoa/thường, số và ký tự đặc biệt.";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.FromArgb(37, 99, 235);
            btnChangePassword.Location = new Point(1711, 21);
            btnChangePassword.Margin = new Padding(4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(310, 64);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Text = " Đổi mật khẩu";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnEdit_Click;
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
            pnlMedicalProfile.Location = new Point(52, 1132);
            pnlMedicalProfile.Margin = new Padding(0, 0, 0, 38);
            pnlMedicalProfile.Name = "pnlMedicalProfile";
            pnlMedicalProfile.Size = new Size(2059, 790);
            pnlMedicalProfile.TabIndex = 1;
            pnlMedicalProfile.Paint += SectionPanel_Paint;
            // 
            // pnlMedicalActions
            // 
            pnlMedicalActions.Controls.Add(btnCancelMedical);
            pnlMedicalActions.Controls.Add(btnSaveMedical);
            pnlMedicalActions.Location = new Point(39, 670);
            pnlMedicalActions.Margin = new Padding(4);
            pnlMedicalActions.Name = "pnlMedicalActions";
            pnlMedicalActions.Size = new Size(637, 90);
            pnlMedicalActions.TabIndex = 27;
            pnlMedicalActions.Visible = false;
            // 
            // btnCancelMedical
            // 
            btnCancelMedical.BackColor = Color.FromArgb(241, 245, 249);
            btnCancelMedical.FlatAppearance.BorderSize = 0;
            btnCancelMedical.FlatStyle = FlatStyle.Flat;
            btnCancelMedical.Font = new Font("Segoe UI", 14F);
            btnCancelMedical.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelMedical.Location = new Point(432, 19);
            btnCancelMedical.Margin = new Padding(4);
            btnCancelMedical.Name = "btnCancelMedical";
            btnCancelMedical.Size = new Size(195, 64);
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
            btnSaveMedical.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnSaveMedical.ForeColor = Color.White;
            btnSaveMedical.Location = new Point(6, 19);
            btnSaveMedical.Margin = new Padding(4);
            btnSaveMedical.Name = "btnSaveMedical";
            btnSaveMedical.Size = new Size(388, 64);
            btnSaveMedical.TabIndex = 0;
            btnSaveMedical.Text = "Cập nhật hồ sơ y tế";
            btnSaveMedical.UseVisualStyleBackColor = false;
            btnSaveMedical.Click += btnSave_Click;
            btnSaveMedical.Paint += Button_Paint;
            // 
            // lblMedicalHistoryRuleHint
            // 
            lblMedicalHistoryRuleHint.BackColor = Color.Transparent;
            lblMedicalHistoryRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblMedicalHistoryRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblMedicalHistoryRuleHint.Location = new Point(455, 608);
            lblMedicalHistoryRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblMedicalHistoryRuleHint.Name = "lblMedicalHistoryRuleHint";
            lblMedicalHistoryRuleHint.Size = new Size(1300, 46);
            lblMedicalHistoryRuleHint.TabIndex = 29;
            lblMedicalHistoryRuleHint.Text = "Tiền sử bệnh: tối đa 2000 ký tự.";
            lblMedicalHistoryRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlMedicalHistoryBorder
            // 
            pnlMedicalHistoryBorder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMedicalHistoryBorder.BackColor = Color.FromArgb(248, 249, 250);
            pnlMedicalHistoryBorder.Controls.Add(txtMedicalHistory);
            pnlMedicalHistoryBorder.Location = new Point(455, 279);
            pnlMedicalHistoryBorder.Name = "pnlMedicalHistoryBorder";
            pnlMedicalHistoryBorder.Padding = new Padding(10);
            pnlMedicalHistoryBorder.Size = new Size(1551, 323);
            pnlMedicalHistoryBorder.TabIndex = 21;
            // 
            // txtMedicalHistory
            // 
            txtMedicalHistory.BackColor = Color.FromArgb(248, 249, 250);
            txtMedicalHistory.BorderStyle = BorderStyle.None;
            txtMedicalHistory.Dock = DockStyle.Fill;
            txtMedicalHistory.Font = new Font("Segoe UI", 12F);
            txtMedicalHistory.Location = new Point(10, 10);
            txtMedicalHistory.Margin = new Padding(4);
            txtMedicalHistory.Multiline = true;
            txtMedicalHistory.Name = "txtMedicalHistory";
            txtMedicalHistory.ReadOnly = true;
            txtMedicalHistory.Size = new Size(1531, 303);
            txtMedicalHistory.TabIndex = 21;
            // 
            // lblMedicalHistory
            // 
            lblMedicalHistory.AutoSize = true;
            lblMedicalHistory.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblMedicalHistory.ForeColor = Color.FromArgb(73, 80, 87);
            lblMedicalHistory.Location = new Point(455, 229);
            lblMedicalHistory.Margin = new Padding(4, 0, 4, 0);
            lblMedicalHistory.Name = "lblMedicalHistory";
            lblMedicalHistory.Size = new Size(208, 45);
            lblMedicalHistory.TabIndex = 20;
            lblMedicalHistory.Text = "Tiền sử bệnh";
            // 
            // lblBloodTypeRuleHint
            // 
            lblBloodTypeRuleHint.BackColor = Color.Transparent;
            lblBloodTypeRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblBloodTypeRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblBloodTypeRuleHint.Location = new Point(455, 182);
            lblBloodTypeRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblBloodTypeRuleHint.Name = "lblBloodTypeRuleHint";
            lblBloodTypeRuleHint.Size = new Size(734, 46);
            lblBloodTypeRuleHint.TabIndex = 28;
            lblBloodTypeRuleHint.Text = "Nhóm máu: A, B, AB hoặc O; có thể kèm dấu + hoặc -.";
            lblBloodTypeRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBloodTypeBorder
            // 
            pnlBloodTypeBorder.BackColor = Color.White;
            pnlBloodTypeBorder.Controls.Add(txtBloodType);
            pnlBloodTypeBorder.Location = new Point(455, 124);
            pnlBloodTypeBorder.Name = "pnlBloodTypeBorder";
            pnlBloodTypeBorder.Padding = new Padding(10);
            pnlBloodTypeBorder.Size = new Size(734, 63);
            pnlBloodTypeBorder.TabIndex = 17;
            // 
            // txtBloodType
            // 
            txtBloodType.BackColor = Color.White;
            txtBloodType.BorderStyle = BorderStyle.None;
            txtBloodType.Dock = DockStyle.Fill;
            txtBloodType.Font = new Font("Segoe UI", 12F);
            txtBloodType.Location = new Point(10, 10);
            txtBloodType.Margin = new Padding(4);
            txtBloodType.Name = "txtBloodType";
            txtBloodType.ReadOnly = true;
            txtBloodType.Size = new Size(714, 43);
            txtBloodType.TabIndex = 17;
            // 
            // lblBloodType
            // 
            lblBloodType.AutoSize = true;
            lblBloodType.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBloodType.ForeColor = Color.FromArgb(73, 80, 87);
            lblBloodType.Location = new Point(455, 74);
            lblBloodType.Margin = new Padding(4, 0, 4, 0);
            lblBloodType.Name = "lblBloodType";
            lblBloodType.Size = new Size(184, 45);
            lblBloodType.TabIndex = 16;
            lblBloodType.Text = "Nhóm máu";
            // 
            // btnEditMedical
            // 
            btnEditMedical.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditMedical.Cursor = Cursors.Hand;
            btnEditMedical.FlatAppearance.BorderSize = 0;
            btnEditMedical.FlatStyle = FlatStyle.Flat;
            btnEditMedical.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnEditMedical.ForeColor = Color.FromArgb(37, 99, 235);
            btnEditMedical.Location = new Point(1732, 22);
            btnEditMedical.Margin = new Padding(4);
            btnEditMedical.Name = "btnEditMedical";
            btnEditMedical.Size = new Size(296, 63);
            btnEditMedical.TabIndex = 1;
            btnEditMedical.Text = "Chỉnh sửa";
            btnEditMedical.UseVisualStyleBackColor = true;
            btnEditMedical.Click += btnEdit_Click;
            // 
            // lblBHYT
            // 
            lblBHYT.AutoSize = true;
            lblBHYT.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBHYT.ForeColor = Color.FromArgb(73, 80, 87);
            lblBHYT.Location = new Point(1271, 74);
            lblBHYT.Margin = new Padding(4, 0, 4, 0);
            lblBHYT.Name = "lblBHYT";
            lblBHYT.Size = new Size(202, 45);
            lblBHYT.TabIndex = 16;
            lblBHYT.Text = "Số thẻ BHYT";
            // 
            // pnlBHYTBorder
            // 
            pnlBHYTBorder.BackColor = Color.White;
            pnlBHYTBorder.Controls.Add(txtBHYT);
            pnlBHYTBorder.Location = new Point(1271, 124);
            pnlBHYTBorder.Name = "pnlBHYTBorder";
            pnlBHYTBorder.Padding = new Padding(10);
            pnlBHYTBorder.Size = new Size(734, 63);
            pnlBHYTBorder.TabIndex = 17;
            // 
            // txtBHYT
            // 
            txtBHYT.BackColor = Color.White;
            txtBHYT.BorderStyle = BorderStyle.None;
            txtBHYT.Dock = DockStyle.Fill;
            txtBHYT.Font = new Font("Segoe UI", 12F);
            txtBHYT.Location = new Point(10, 10);
            txtBHYT.Margin = new Padding(4);
            txtBHYT.Name = "txtBHYT";
            txtBHYT.ReadOnly = true;
            txtBHYT.Size = new Size(714, 43);
            txtBHYT.TabIndex = 17;
            // 
            // lblMedicalTitle
            // 
            lblMedicalTitle.AutoSize = true;
            lblMedicalTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMedicalTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblMedicalTitle.Location = new Point(26, 26);
            lblMedicalTitle.Margin = new Padding(4, 0, 4, 0);
            lblMedicalTitle.Name = "lblMedicalTitle";
            lblMedicalTitle.Size = new Size(301, 59);
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
            pnlBasicInfo.Location = new Point(52, 38);
            pnlBasicInfo.Margin = new Padding(0, 0, 0, 38);
            pnlBasicInfo.Name = "pnlBasicInfo";
            pnlBasicInfo.Size = new Size(2059, 1094);
            pnlBasicInfo.TabIndex = 0;
            pnlBasicInfo.Paint += SectionPanel_Paint;
            // 
            // pnlBasicInfoActions
            // 
            pnlBasicInfoActions.Controls.Add(btnCancelBasicInfo);
            pnlBasicInfoActions.Controls.Add(btnSaveBasicInfo);
            pnlBasicInfoActions.Location = new Point(55, 982);
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
            btnCancelBasicInfo.Font = new Font("Segoe UI", 14F);
            btnCancelBasicInfo.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelBasicInfo.Location = new Point(419, 20);
            btnCancelBasicInfo.Margin = new Padding(4);
            btnCancelBasicInfo.Name = "btnCancelBasicInfo";
            btnCancelBasicInfo.Size = new Size(195, 66);
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
            btnSaveBasicInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnSaveBasicInfo.ForeColor = Color.White;
            btnSaveBasicInfo.Location = new Point(6, 20);
            btnSaveBasicInfo.Margin = new Padding(4);
            btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            btnSaveBasicInfo.Size = new Size(341, 63);
            btnSaveBasicInfo.TabIndex = 0;
            btnSaveBasicInfo.Text = "Lưu thay đổi";
            btnSaveBasicInfo.UseVisualStyleBackColor = false;
            btnSaveBasicInfo.Click += btnSave_Click;
            btnSaveBasicInfo.Paint += Button_Paint;
            // 
            // lblAddressRuleHint
            // 
            lblAddressRuleHint.BackColor = Color.Transparent;
            lblAddressRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblAddressRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblAddressRuleHint.Location = new Point(455, 900);
            lblAddressRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblAddressRuleHint.Name = "lblAddressRuleHint";
            lblAddressRuleHint.Size = new Size(1551, 46);
            lblAddressRuleHint.TabIndex = 45;
            lblAddressRuleHint.Text = "Địa chỉ: 5-255 ký tự, không chứa ký tự điều khiển.";
            lblAddressRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEmergencyPhoneRuleHint
            // 
            lblEmergencyPhoneRuleHint.BackColor = Color.Transparent;
            lblEmergencyPhoneRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblEmergencyPhoneRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblEmergencyPhoneRuleHint.Location = new Point(455, 395);
            lblEmergencyPhoneRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblEmergencyPhoneRuleHint.Name = "lblEmergencyPhoneRuleHint";
            lblEmergencyPhoneRuleHint.Size = new Size(734, 46);
            lblEmergencyPhoneRuleHint.TabIndex = 40;
            lblEmergencyPhoneRuleHint.Text = "SĐT khẩn cấp: nếu nhập thì phải đúng 10 chữ số, bắt đầu bằng 0.";
            lblEmergencyPhoneRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEmergencyPhoneBorder
            // 
            pnlEmergencyPhoneBorder.BackColor = Color.White;
            pnlEmergencyPhoneBorder.Controls.Add(txtEmergencyPhone);
            pnlEmergencyPhoneBorder.Location = new Point(455, 335);
            pnlEmergencyPhoneBorder.Name = "pnlEmergencyPhoneBorder";
            pnlEmergencyPhoneBorder.Padding = new Padding(10);
            pnlEmergencyPhoneBorder.Size = new Size(734, 63);
            pnlEmergencyPhoneBorder.TabIndex = 23;
            // 
            // txtEmergencyPhone
            // 
            txtEmergencyPhone.BackColor = Color.White;
            txtEmergencyPhone.BorderStyle = BorderStyle.None;
            txtEmergencyPhone.Dock = DockStyle.Fill;
            txtEmergencyPhone.Font = new Font("Segoe UI", 12F);
            txtEmergencyPhone.Location = new Point(10, 10);
            txtEmergencyPhone.Margin = new Padding(4);
            txtEmergencyPhone.Name = "txtEmergencyPhone";
            txtEmergencyPhone.ReadOnly = true;
            txtEmergencyPhone.Size = new Size(714, 43);
            txtEmergencyPhone.TabIndex = 23;
            // 
            // lblEmergencyPhone
            // 
            lblEmergencyPhone.AutoSize = true;
            lblEmergencyPhone.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEmergencyPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmergencyPhone.Location = new Point(455, 287);
            lblEmergencyPhone.Margin = new Padding(4, 0, 4, 0);
            lblEmergencyPhone.Name = "lblEmergencyPhone";
            lblEmergencyPhone.Size = new Size(325, 45);
            lblEmergencyPhone.TabIndex = 22;
            lblEmergencyPhone.Text = "SĐT liên hệ khẩn cấp";
            // 
            // lblEmergencyContactRuleHint
            // 
            lblEmergencyContactRuleHint.BackColor = Color.Transparent;
            lblEmergencyContactRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblEmergencyContactRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblEmergencyContactRuleHint.Location = new Point(455, 726);
            lblEmergencyContactRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblEmergencyContactRuleHint.Name = "lblEmergencyContactRuleHint";
            lblEmergencyContactRuleHint.Size = new Size(734, 46);
            lblEmergencyContactRuleHint.TabIndex = 41;
            lblEmergencyContactRuleHint.Text = "Tên liên hệ khẩn cấp: tối đa 100 ký tự.";
            lblEmergencyContactRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEmergencyContactBorder
            // 
            pnlEmergencyContactBorder.BackColor = Color.White;
            pnlEmergencyContactBorder.Controls.Add(txtEmergencyContact);
            pnlEmergencyContactBorder.Location = new Point(455, 668);
            pnlEmergencyContactBorder.Name = "pnlEmergencyContactBorder";
            pnlEmergencyContactBorder.Padding = new Padding(10);
            pnlEmergencyContactBorder.Size = new Size(734, 63);
            pnlEmergencyContactBorder.TabIndex = 21;
            // 
            // txtEmergencyContact
            // 
            txtEmergencyContact.BackColor = Color.White;
            txtEmergencyContact.BorderStyle = BorderStyle.None;
            txtEmergencyContact.Dock = DockStyle.Fill;
            txtEmergencyContact.Font = new Font("Segoe UI", 12F);
            txtEmergencyContact.Location = new Point(10, 10);
            txtEmergencyContact.Margin = new Padding(4);
            txtEmergencyContact.Name = "txtEmergencyContact";
            txtEmergencyContact.ReadOnly = true;
            txtEmergencyContact.Size = new Size(714, 43);
            txtEmergencyContact.TabIndex = 21;
            // 
            // lblEmergencyContact
            // 
            lblEmergencyContact.AutoSize = true;
            lblEmergencyContact.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEmergencyContact.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmergencyContact.Location = new Point(455, 620);
            lblEmergencyContact.Margin = new Padding(4, 0, 4, 0);
            lblEmergencyContact.Name = "lblEmergencyContact";
            lblEmergencyContact.Size = new Size(359, 45);
            lblEmergencyContact.TabIndex = 20;
            lblEmergencyContact.Text = "Người liên hệ khẩn cấp";
            // 
            // pnlPatientIDBorder
            // 
            pnlPatientIDBorder.BackColor = Color.White;
            pnlPatientIDBorder.Controls.Add(txtPatientID);
            pnlPatientIDBorder.Location = new Point(1290, 668);
            pnlPatientIDBorder.Name = "pnlPatientIDBorder";
            pnlPatientIDBorder.Padding = new Padding(10);
            pnlPatientIDBorder.Size = new Size(734, 63);
            pnlPatientIDBorder.TabIndex = 19;
            // 
            // txtPatientID
            // 
            txtPatientID.BackColor = Color.White;
            txtPatientID.BorderStyle = BorderStyle.None;
            txtPatientID.Dock = DockStyle.Fill;
            txtPatientID.Font = new Font("Segoe UI", 12F);
            txtPatientID.Location = new Point(10, 10);
            txtPatientID.Margin = new Padding(4);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.ReadOnly = true;
            txtPatientID.Size = new Size(714, 43);
            txtPatientID.TabIndex = 19;
            // 
            // lblPatientID
            // 
            lblPatientID.AutoSize = true;
            lblPatientID.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPatientID.ForeColor = Color.FromArgb(73, 80, 87);
            lblPatientID.Location = new Point(1290, 620);
            lblPatientID.Margin = new Padding(4, 0, 4, 0);
            lblPatientID.Name = "lblPatientID";
            lblPatientID.Size = new Size(233, 45);
            lblPatientID.TabIndex = 18;
            lblPatientID.Text = "Mã bệnh nhân";
            // 
            // lblCccdRuleHint
            // 
            lblCccdRuleHint.BackColor = Color.Transparent;
            lblCccdRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblCccdRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblCccdRuleHint.Location = new Point(1290, 561);
            lblCccdRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblCccdRuleHint.Name = "lblCccdRuleHint";
            lblCccdRuleHint.Size = new Size(734, 46);
            lblCccdRuleHint.TabIndex = 42;
            lblCccdRuleHint.Text = "CCCD: đúng 12 chữ số nếu bệnh nhân từ 16 tuổi trở lên.";
            lblCccdRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCCCDBorder
            // 
            pnlCCCDBorder.BackColor = Color.White;
            pnlCCCDBorder.Controls.Add(txtCCCD);
            pnlCCCDBorder.Location = new Point(1290, 498);
            pnlCCCDBorder.Name = "pnlCCCDBorder";
            pnlCCCDBorder.Padding = new Padding(10);
            pnlCCCDBorder.Size = new Size(734, 63);
            pnlCCCDBorder.TabIndex = 15;
            // 
            // txtCCCD
            // 
            txtCCCD.BackColor = Color.White;
            txtCCCD.BorderStyle = BorderStyle.None;
            txtCCCD.Dock = DockStyle.Fill;
            txtCCCD.Font = new Font("Segoe UI", 12F);
            txtCCCD.Location = new Point(10, 10);
            txtCCCD.Margin = new Padding(4);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.ReadOnly = true;
            txtCCCD.Size = new Size(714, 43);
            txtCCCD.TabIndex = 15;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCCCD.ForeColor = Color.FromArgb(73, 80, 87);
            lblCCCD.Location = new Point(1290, 450);
            lblCCCD.Margin = new Padding(4, 0, 4, 0);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(307, 45);
            lblCCCD.TabIndex = 14;
            lblCCCD.Text = "Số CCCD / Hộ chiếu";
            // 
            // lblGenderRuleHint
            // 
            lblGenderRuleHint.BackColor = Color.Transparent;
            lblGenderRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblGenderRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblGenderRuleHint.Location = new Point(455, 564);
            lblGenderRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblGenderRuleHint.Name = "lblGenderRuleHint";
            lblGenderRuleHint.Size = new Size(734, 46);
            lblGenderRuleHint.TabIndex = 43;
            lblGenderRuleHint.Text = "Giới tính: chỉ nhập Nam hoặc Nữ.";
            lblGenderRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlGenderBorder
            // 
            pnlGenderBorder.BackColor = Color.White;
            pnlGenderBorder.Controls.Add(txtGender);
            pnlGenderBorder.Location = new Point(455, 504);
            pnlGenderBorder.Name = "pnlGenderBorder";
            pnlGenderBorder.Padding = new Padding(10);
            pnlGenderBorder.Size = new Size(734, 63);
            pnlGenderBorder.TabIndex = 13;
            // 
            // txtGender
            // 
            txtGender.BackColor = Color.White;
            txtGender.BorderStyle = BorderStyle.None;
            txtGender.Dock = DockStyle.Fill;
            txtGender.Font = new Font("Segoe UI", 12F);
            txtGender.Location = new Point(10, 10);
            txtGender.Margin = new Padding(4);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(714, 43);
            txtGender.TabIndex = 13;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(73, 80, 87);
            lblGender.Location = new Point(455, 457);
            lblGender.Margin = new Padding(4, 0, 4, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(145, 45);
            lblGender.TabIndex = 12;
            lblGender.Text = "Giới tính";
            // 
            // lblBirthdayRuleHint
            // 
            lblBirthdayRuleHint.BackColor = Color.Transparent;
            lblBirthdayRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblBirthdayRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblBirthdayRuleHint.Location = new Point(1290, 393);
            lblBirthdayRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblBirthdayRuleHint.Name = "lblBirthdayRuleHint";
            lblBirthdayRuleHint.Size = new Size(734, 46);
            lblBirthdayRuleHint.TabIndex = 44;
            lblBirthdayRuleHint.Text = "Ngày sinh: không ở tương lai; từ 16 tuổi trở lên bắt buộc có CCCD.";
            lblBirthdayRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBirthdayBorder
            // 
            pnlBirthdayBorder.BackColor = Color.White;
            pnlBirthdayBorder.Controls.Add(dtpBirthday);
            pnlBirthdayBorder.Location = new Point(1290, 333);
            pnlBirthdayBorder.Name = "pnlBirthdayBorder";
            pnlBirthdayBorder.Padding = new Padding(10, 5, 10, 5);
            pnlBirthdayBorder.Size = new Size(734, 60);
            pnlBirthdayBorder.TabIndex = 11;
            // 
            // dtpBirthday
            // 
            dtpBirthday.CalendarFont = new Font("Segoe UI", 12F);
            dtpBirthday.CustomFormat = "dd / MM / yyyy";
            dtpBirthday.Dock = DockStyle.Fill;
            dtpBirthday.Font = new Font("Segoe UI", 12F);
            dtpBirthday.Format = DateTimePickerFormat.Custom;
            dtpBirthday.Location = new Point(10, 5);
            dtpBirthday.Margin = new Padding(4);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(714, 50);
            dtpBirthday.TabIndex = 11;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBirthday.ForeColor = Color.FromArgb(73, 80, 87);
            lblBirthday.Location = new Point(1290, 285);
            lblBirthday.Margin = new Padding(4, 0, 4, 0);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(166, 45);
            lblBirthday.TabIndex = 10;
            lblBirthday.Text = "Ngày sinh";
            // 
            // pnlAddressBorder
            // 
            pnlAddressBorder.BackColor = Color.White;
            pnlAddressBorder.Controls.Add(txtAddress);
            pnlAddressBorder.Location = new Point(455, 836);
            pnlAddressBorder.Name = "pnlAddressBorder";
            pnlAddressBorder.Padding = new Padding(10);
            pnlAddressBorder.Size = new Size(1551, 63);
            pnlAddressBorder.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.White;
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(10, 10);
            txtAddress.Margin = new Padding(4);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(1531, 43);
            txtAddress.TabIndex = 9;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(73, 80, 87);
            lblAddress.Location = new Point(455, 786);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(119, 45);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Địa chỉ";
            // 
            // lblPhoneRuleHint
            // 
            lblPhoneRuleHint.BackColor = Color.Transparent;
            lblPhoneRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblPhoneRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPhoneRuleHint.Location = new Point(1290, 242);
            lblPhoneRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblPhoneRuleHint.Name = "lblPhoneRuleHint";
            lblPhoneRuleHint.Size = new Size(734, 40);
            lblPhoneRuleHint.TabIndex = 46;
            lblPhoneRuleHint.Text = "SĐT: đúng 10 chữ số, bắt đầu bằng 0 và không trùng tài khoản khác.";
            lblPhoneRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPhoneBorder
            // 
            pnlPhoneBorder.BackColor = Color.White;
            pnlPhoneBorder.Controls.Add(txtPhone);
            pnlPhoneBorder.Location = new Point(1290, 173);
            pnlPhoneBorder.Name = "pnlPhoneBorder";
            pnlPhoneBorder.Padding = new Padding(10);
            pnlPhoneBorder.Size = new Size(734, 63);
            pnlPhoneBorder.TabIndex = 7;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.White;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(10, 10);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(714, 43);
            txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblPhone.Location = new Point(1290, 125);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(212, 45);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại";
            // 
            // lblFullNameRuleHint
            // 
            lblFullNameRuleHint.BackColor = Color.Transparent;
            lblFullNameRuleHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblFullNameRuleHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblFullNameRuleHint.Location = new Point(455, 242);
            lblFullNameRuleHint.Margin = new Padding(4, 0, 4, 0);
            lblFullNameRuleHint.Name = "lblFullNameRuleHint";
            lblFullNameRuleHint.Size = new Size(734, 34);
            lblFullNameRuleHint.TabIndex = 47;
            lblFullNameRuleHint.Text = "Họ tên: 2-100 ký tự, chỉ dùng chữ cái và khoảng trắng.";
            lblFullNameRuleHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFullNameBorder
            // 
            pnlFullNameBorder.BackColor = Color.White;
            pnlFullNameBorder.Controls.Add(txtFullName);
            pnlFullNameBorder.Location = new Point(455, 173);
            pnlFullNameBorder.Name = "pnlFullNameBorder";
            pnlFullNameBorder.Padding = new Padding(10);
            pnlFullNameBorder.Size = new Size(734, 63);
            pnlFullNameBorder.TabIndex = 5;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.White;
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Dock = DockStyle.Fill;
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(10, 10);
            txtFullName.Margin = new Padding(4);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(714, 43);
            txtFullName.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(73, 80, 87);
            lblFullName.Location = new Point(455, 125);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(161, 45);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên";
            // 
            // lblPatientName
            // 
            lblPatientName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblPatientName.Location = new Point(32, 499);
            lblPatientName.Margin = new Padding(4, 0, 4, 0);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(390, 102);
            lblPatientName.TabIndex = 3;
            lblPatientName.Text = "Nguyễn Văn Minh";
            lblPatientName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(241, 243, 245);
            picAvatar.Location = new Point(32, 102);
            picAvatar.Margin = new Padding(4);
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
            btnEditBasicInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnEditBasicInfo.ForeColor = Color.FromArgb(37, 99, 235);
            btnEditBasicInfo.Location = new Point(1732, 29);
            btnEditBasicInfo.Margin = new Padding(4);
            btnEditBasicInfo.Name = "btnEditBasicInfo";
            btnEditBasicInfo.Size = new Size(282, 56);
            btnEditBasicInfo.TabIndex = 1;
            btnEditBasicInfo.Text = "Chỉnh sửa";
            btnEditBasicInfo.UseVisualStyleBackColor = true;
            btnEditBasicInfo.Click += btnEdit_Click;
            // 
            // lblBasicInfoTitle
            // 
            lblBasicInfoTitle.AutoSize = true;
            lblBasicInfoTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBasicInfoTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblBasicInfoTitle.Location = new Point(26, 26);
            lblBasicInfoTitle.Margin = new Padding(4, 0, 4, 0);
            lblBasicInfoTitle.Name = "lblBasicInfoTitle";
            lblBasicInfoTitle.Size = new Size(442, 59);
            lblBasicInfoTitle.TabIndex = 0;
            lblBasicInfoTitle.Text = "👤 Thông tin cơ bản";
            // 
            // ucPatient_Profile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Margin = new Padding(4);
            Name = "ucPatient_Profile";
            Size = new Size(2197, 2500);
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
    }
}
