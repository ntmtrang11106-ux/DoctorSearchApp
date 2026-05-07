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
            pnlMain = new Panel();
            pnlSecurity = new Panel();
            pnlPassActions = new Panel();
            btnCancelPass = new Button();
            btnSavePass = new Button();
            pnlChangePassword = new Panel();
            txtConfirmPass = new TextBox();
            lblConfirmPass = new Label();
            txtNewPass = new TextBox();
            lblNewPass = new Label();
            txtCurrentPass = new TextBox();
            lblCurrentPass = new Label();
            lblSecurityHint = new Label();
            btnChangePassword = new Button();
            lblSecurityTitle = new Label();
            pnlMedicalProfile = new Panel();
            pnlMedicalActions = new Panel();
            btnCancelMedical = new Button();
            btnSaveMedical = new Button();
            txtMedicalHistory = new TextBox();
            lblMedicalHistory = new Label();
            txtBloodType = new TextBox();
            lblBloodType = new Label();
            btnEditMedical = new Button();
            lblBHYT = new Label();
            txtBHYT = new TextBox();
            lblMedicalTitle = new Label();
            pnlBasicInfo = new Panel();
            pnlBasicInfoActions = new Panel();
            btnCancelBasicInfo = new Button();
            btnSaveBasicInfo = new Button();
            txtEmergencyPhone = new TextBox();
            lblEmergencyPhone = new Label();
            txtEmergencyContact = new TextBox();
            lblEmergencyContact = new Label();
            txtPatientID = new TextBox();
            lblPatientID = new Label();
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
            lblPatientName = new Label();
            picAvatar = new PictureBox();
            btnEditBasicInfo = new Button();
            lblBasicInfoTitle = new Label();
            pnlMain.SuspendLayout();
            pnlSecurity.SuspendLayout();
            pnlPassActions.SuspendLayout();
            pnlChangePassword.SuspendLayout();
            pnlMedicalProfile.SuspendLayout();
            pnlMedicalActions.SuspendLayout();
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
            pnlSecurity.Location = new Point(52, 1516);
            pnlSecurity.Margin = new Padding(0, 0, 0, 38);
            pnlSecurity.Name = "pnlSecurity";
            pnlSecurity.Size = new Size(2093, 579);
            pnlSecurity.TabIndex = 2;
            pnlSecurity.Paint += SectionPanel_Paint;
            // 
            // pnlPassActions
            // 
            pnlPassActions.Controls.Add(btnCancelPass);
            pnlPassActions.Controls.Add(btnSavePass);
            pnlPassActions.Location = new Point(52, 373);
            pnlPassActions.Margin = new Padding(4);
            pnlPassActions.Name = "pnlPassActions";
            pnlPassActions.Size = new Size(585, 77);
            pnlPassActions.TabIndex = 35;
            // 
            // btnCancelPass
            // 
            btnCancelPass.BackColor = Color.FromArgb(241, 243, 245);
            btnCancelPass.FlatAppearance.BorderSize = 0;
            btnCancelPass.FlatStyle = FlatStyle.Flat;
            btnCancelPass.Font = new Font("Segoe UI", 11F);
            btnCancelPass.ForeColor = Color.FromArgb(73, 80, 87);
            btnCancelPass.Location = new Point(312, 6);
            btnCancelPass.Margin = new Padding(4);
            btnCancelPass.Name = "btnCancelPass";
            btnCancelPass.Size = new Size(156, 64);
            btnCancelPass.TabIndex = 1;
            btnCancelPass.Text = "✕  Hủy";
            btnCancelPass.UseVisualStyleBackColor = false;
            btnCancelPass.Click += btnCancel_Click;
            btnCancelPass.Paint += Button_Paint;
            // 
            // btnSavePass
            // 
            btnSavePass.BackColor = Color.FromArgb(0, 120, 215);
            btnSavePass.FlatAppearance.BorderSize = 0;
            btnSavePass.FlatStyle = FlatStyle.Flat;
            btnSavePass.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSavePass.ForeColor = Color.White;
            btnSavePass.Location = new Point(6, 6);
            btnSavePass.Margin = new Padding(4);
            btnSavePass.Name = "btnSavePass";
            btnSavePass.Size = new Size(286, 64);
            btnSavePass.TabIndex = 0;
            btnSavePass.Text = "💾  Lưu mật khẩu mới";
            btnSavePass.UseVisualStyleBackColor = false;
            btnSavePass.Click += btnSave_Click;
            btnSavePass.Paint += Button_Paint;
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
            pnlChangePassword.Margin = new Padding(4);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Size = new Size(1373, 462);
            pnlChangePassword.TabIndex = 3;
            pnlChangePassword.Visible = false;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BackColor = Color.White;
            txtConfirmPass.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.Location = new Point(52, 288);
            txtConfirmPass.Margin = new Padding(4);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderText = "Nhập lại mật khẩu mới";
            txtConfirmPass.Size = new Size(1320, 50);
            txtConfirmPass.TabIndex = 33;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPass.Location = new Point(52, 247);
            lblConfirmPass.Margin = new Padding(4, 0, 4, 0);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(371, 37);
            lblConfirmPass.TabIndex = 32;
            lblConfirmPass.Text = "✅ Xác nhận mật khẩu mới *";
            // 
            // txtNewPass
            // 
            txtNewPass.BackColor = Color.White;
            txtNewPass.BorderStyle = BorderStyle.FixedSingle;
            txtNewPass.Font = new Font("Segoe UI", 12F);
            txtNewPass.Location = new Point(52, 174);
            txtNewPass.Margin = new Padding(4);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PlaceholderText = "Nhập mật khẩu mới (tối thiểu 6 ký tự)";
            txtNewPass.Size = new Size(1320, 50);
            txtNewPass.TabIndex = 30;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblNewPass.Location = new Point(52, 123);
            lblNewPass.Margin = new Padding(4, 0, 4, 0);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(252, 37);
            lblNewPass.TabIndex = 29;
            lblNewPass.Text = "🆕 Mật khẩu mới *";
            // 
            // txtCurrentPass
            // 
            txtCurrentPass.BackColor = Color.White;
            txtCurrentPass.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPass.Font = new Font("Segoe UI", 12F);
            txtCurrentPass.Location = new Point(52, 57);
            txtCurrentPass.Margin = new Padding(4);
            txtCurrentPass.Name = "txtCurrentPass";
            txtCurrentPass.PlaceholderText = "Nhập mật khẩu hiện tại";
            txtCurrentPass.Size = new Size(1320, 50);
            txtCurrentPass.TabIndex = 27;
            txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // lblCurrentPass
            // 
            lblCurrentPass.AutoSize = true;
            lblCurrentPass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCurrentPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblCurrentPass.Location = new Point(52, 13);
            lblCurrentPass.Margin = new Padding(4, 0, 4, 0);
            lblCurrentPass.Name = "lblCurrentPass";
            lblCurrentPass.Size = new Size(295, 37);
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
            btnChangePassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.FromArgb(0, 105, 217);
            btnChangePassword.Location = new Point(1768, 13);
            btnChangePassword.Margin = new Padding(4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(321, 51);
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
            pnlMedicalProfile.Controls.Add(txtMedicalHistory);
            pnlMedicalProfile.Controls.Add(lblMedicalHistory);
            pnlMedicalProfile.Controls.Add(txtBloodType);
            pnlMedicalProfile.Controls.Add(lblBloodType);
            pnlMedicalProfile.Controls.Add(btnEditMedical);
            pnlMedicalProfile.Controls.Add(lblBHYT);
            pnlMedicalProfile.Controls.Add(txtBHYT);
            pnlMedicalProfile.Controls.Add(lblMedicalTitle);
            pnlMedicalProfile.Dock = DockStyle.Top;
            pnlMedicalProfile.Location = new Point(52, 868);
            pnlMedicalProfile.Margin = new Padding(0, 0, 0, 38);
            pnlMedicalProfile.Name = "pnlMedicalProfile";
            pnlMedicalProfile.Size = new Size(2093, 648);
            pnlMedicalProfile.TabIndex = 1;
            pnlMedicalProfile.Paint += SectionPanel_Paint;
            // 
            // pnlMedicalActions
            // 
            pnlMedicalActions.Controls.Add(btnCancelMedical);
            pnlMedicalActions.Controls.Add(btnSaveMedical);
            pnlMedicalActions.Location = new Point(44, 558);
            pnlMedicalActions.Margin = new Padding(4);
            pnlMedicalActions.Name = "pnlMedicalActions";
            pnlMedicalActions.Size = new Size(566, 77);
            pnlMedicalActions.TabIndex = 27;
            pnlMedicalActions.Visible = false;
            // 
            // btnCancelMedical
            // 
            btnCancelMedical.BackColor = Color.FromArgb(241, 243, 245);
            btnCancelMedical.FlatAppearance.BorderSize = 0;
            btnCancelMedical.FlatStyle = FlatStyle.Flat;
            btnCancelMedical.Font = new Font("Segoe UI", 11F);
            btnCancelMedical.ForeColor = Color.FromArgb(73, 80, 87);
            btnCancelMedical.Location = new Point(378, 6);
            btnCancelMedical.Margin = new Padding(4);
            btnCancelMedical.Name = "btnCancelMedical";
            btnCancelMedical.Size = new Size(156, 64);
            btnCancelMedical.TabIndex = 1;
            btnCancelMedical.Text = "✕  Hủy";
            btnCancelMedical.UseVisualStyleBackColor = false;
            btnCancelMedical.Click += btnCancel_Click;
            btnCancelMedical.Paint += Button_Paint;
            // 
            // btnSaveMedical
            // 
            btnSaveMedical.BackColor = Color.FromArgb(0, 120, 215);
            btnSaveMedical.FlatAppearance.BorderSize = 0;
            btnSaveMedical.FlatStyle = FlatStyle.Flat;
            btnSaveMedical.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSaveMedical.ForeColor = Color.White;
            btnSaveMedical.Location = new Point(6, 6);
            btnSaveMedical.Margin = new Padding(4);
            btnSaveMedical.Name = "btnSaveMedical";
            btnSaveMedical.Size = new Size(357, 64);
            btnSaveMedical.TabIndex = 0;
            btnSaveMedical.Text = "💾  Cập nhật hồ sơ y tế";
            btnSaveMedical.UseVisualStyleBackColor = false;
            btnSaveMedical.Click += btnSave_Click;
            btnSaveMedical.Paint += Button_Paint;
            // 
            // txtMedicalHistory
            // 
            txtMedicalHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMedicalHistory.BackColor = Color.FromArgb(248, 249, 250);
            txtMedicalHistory.BorderStyle = BorderStyle.FixedSingle;
            txtMedicalHistory.Font = new Font("Segoe UI", 12F);
            txtMedicalHistory.Location = new Point(455, 219);
            txtMedicalHistory.Margin = new Padding(4);
            txtMedicalHistory.Multiline = true;
            txtMedicalHistory.Name = "txtMedicalHistory";
            txtMedicalHistory.ReadOnly = true;
            txtMedicalHistory.Size = new Size(1585, 322);
            txtMedicalHistory.TabIndex = 21;
            // 
            // lblMedicalHistory
            // 
            lblMedicalHistory.AutoSize = true;
            lblMedicalHistory.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblMedicalHistory.ForeColor = Color.FromArgb(73, 80, 87);
            lblMedicalHistory.Location = new Point(455, 169);
            lblMedicalHistory.Margin = new Padding(4, 0, 4, 0);
            lblMedicalHistory.Name = "lblMedicalHistory";
            lblMedicalHistory.Size = new Size(174, 37);
            lblMedicalHistory.TabIndex = 20;
            lblMedicalHistory.Text = "Tiền sử bệnh";
            // 
            // txtBloodType
            // 
            txtBloodType.Font = new Font("Segoe UI", 12F);
            txtBloodType.Location = new Point(455, 98);
            txtBloodType.Margin = new Padding(4);
            txtBloodType.Name = "txtBloodType";
            txtBloodType.ReadOnly = true;
            txtBloodType.Size = new Size(735, 50);
            txtBloodType.TabIndex = 17;
            // 
            // lblBloodType
            // 
            lblBloodType.AutoSize = true;
            lblBloodType.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBloodType.ForeColor = Color.FromArgb(73, 80, 87);
            lblBloodType.Location = new Point(455, 48);
            lblBloodType.Margin = new Padding(4, 0, 4, 0);
            lblBloodType.Name = "lblBloodType";
            lblBloodType.Size = new Size(155, 37);
            lblBloodType.TabIndex = 16;
            lblBloodType.Text = "Nhóm máu";
            // 
            // btnEditMedical
            // 
            btnEditMedical.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditMedical.Cursor = Cursors.Hand;
            btnEditMedical.FlatAppearance.BorderSize = 0;
            btnEditMedical.FlatStyle = FlatStyle.Flat;
            btnEditMedical.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEditMedical.ForeColor = Color.FromArgb(0, 105, 217);
            btnEditMedical.Location = new Point(1856, 16);
            btnEditMedical.Margin = new Padding(4);
            btnEditMedical.Name = "btnEditMedical";
            btnEditMedical.Size = new Size(233, 51);
            btnEditMedical.TabIndex = 1;
            btnEditMedical.Text = "✎  Chỉnh sửa";
            btnEditMedical.TextAlign = ContentAlignment.MiddleRight;
            btnEditMedical.UseVisualStyleBackColor = true;
            btnEditMedical.Click += btnEdit_Click;
            // 
            // lblBHYT
            // 
            lblBHYT.AutoSize = true;
            lblBHYT.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBHYT.ForeColor = Color.FromArgb(73, 80, 87);
            lblBHYT.Location = new Point(1271, 48);
            lblBHYT.Margin = new Padding(4, 0, 4, 0);
            lblBHYT.Name = "lblBHYT";
            lblBHYT.Size = new Size(170, 37);
            lblBHYT.TabIndex = 16;
            lblBHYT.Text = "Số thẻ BHYT";
            // 
            // txtBHYT
            // 
            txtBHYT.Font = new Font("Segoe UI", 12F);
            txtBHYT.Location = new Point(1271, 98);
            txtBHYT.Margin = new Padding(4);
            txtBHYT.Name = "txtBHYT";
            txtBHYT.ReadOnly = true;
            txtBHYT.Size = new Size(735, 50);
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
            pnlBasicInfo.Controls.Add(txtEmergencyPhone);
            pnlBasicInfo.Controls.Add(lblEmergencyPhone);
            pnlBasicInfo.Controls.Add(txtEmergencyContact);
            pnlBasicInfo.Controls.Add(lblEmergencyContact);
            pnlBasicInfo.Controls.Add(txtPatientID);
            pnlBasicInfo.Controls.Add(lblPatientID);
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
            pnlBasicInfo.Controls.Add(lblPatientName);
            pnlBasicInfo.Controls.Add(picAvatar);
            pnlBasicInfo.Controls.Add(btnEditBasicInfo);
            pnlBasicInfo.Controls.Add(lblBasicInfoTitle);
            pnlBasicInfo.Dock = DockStyle.Top;
            pnlBasicInfo.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlBasicInfo.Location = new Point(52, 38);
            pnlBasicInfo.Margin = new Padding(0, 0, 0, 38);
            pnlBasicInfo.Name = "pnlBasicInfo";
            pnlBasicInfo.Size = new Size(2093, 830);
            pnlBasicInfo.TabIndex = 0;
            pnlBasicInfo.Paint += SectionPanel_Paint;
            // 
            // pnlBasicInfoActions
            // 
            pnlBasicInfoActions.Controls.Add(btnCancelBasicInfo);
            pnlBasicInfoActions.Controls.Add(btnSaveBasicInfo);
            pnlBasicInfoActions.Location = new Point(44, 731);
            pnlBasicInfoActions.Margin = new Padding(4);
            pnlBasicInfoActions.Name = "pnlBasicInfoActions";
            pnlBasicInfoActions.Size = new Size(475, 77);
            pnlBasicInfoActions.TabIndex = 26;
            pnlBasicInfoActions.Visible = false;
            // 
            // btnCancelBasicInfo
            // 
            btnCancelBasicInfo.BackColor = Color.FromArgb(241, 243, 245);
            btnCancelBasicInfo.FlatAppearance.BorderSize = 0;
            btnCancelBasicInfo.FlatStyle = FlatStyle.Flat;
            btnCancelBasicInfo.Font = new Font("Segoe UI", 11F);
            btnCancelBasicInfo.ForeColor = Color.FromArgb(73, 80, 87);
            btnCancelBasicInfo.Location = new Point(304, 9);
            btnCancelBasicInfo.Margin = new Padding(4);
            btnCancelBasicInfo.Name = "btnCancelBasicInfo";
            btnCancelBasicInfo.Size = new Size(156, 64);
            btnCancelBasicInfo.TabIndex = 1;
            btnCancelBasicInfo.Text = "✕  Hủy";
            btnCancelBasicInfo.UseVisualStyleBackColor = false;
            btnCancelBasicInfo.Click += btnCancel_Click;
            btnCancelBasicInfo.Paint += Button_Paint;
            // 
            // btnSaveBasicInfo
            // 
            btnSaveBasicInfo.BackColor = Color.FromArgb(0, 120, 215);
            btnSaveBasicInfo.FlatAppearance.BorderSize = 0;
            btnSaveBasicInfo.FlatStyle = FlatStyle.Flat;
            btnSaveBasicInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSaveBasicInfo.ForeColor = Color.White;
            btnSaveBasicInfo.Location = new Point(6, 6);
            btnSaveBasicInfo.Margin = new Padding(4);
            btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            btnSaveBasicInfo.Size = new Size(277, 64);
            btnSaveBasicInfo.TabIndex = 0;
            btnSaveBasicInfo.Text = "💾  Lưu thay đổi";
            btnSaveBasicInfo.UseVisualStyleBackColor = false;
            btnSaveBasicInfo.Click += btnSave_Click;
            btnSaveBasicInfo.Paint += Button_Paint;
            // 
            // txtEmergencyPhone
            // 
            txtEmergencyPhone.Font = new Font("Segoe UI", 12F);
            txtEmergencyPhone.Location = new Point(455, 296);
            txtEmergencyPhone.Margin = new Padding(4);
            txtEmergencyPhone.Name = "txtEmergencyPhone";
            txtEmergencyPhone.ReadOnly = true;
            txtEmergencyPhone.Size = new Size(735, 50);
            txtEmergencyPhone.TabIndex = 23;
            // 
            // lblEmergencyPhone
            // 
            lblEmergencyPhone.AutoSize = true;
            lblEmergencyPhone.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEmergencyPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmergencyPhone.Location = new Point(455, 250);
            lblEmergencyPhone.Margin = new Padding(4, 0, 4, 0);
            lblEmergencyPhone.Name = "lblEmergencyPhone";
            lblEmergencyPhone.Size = new Size(271, 37);
            lblEmergencyPhone.TabIndex = 22;
            lblEmergencyPhone.Text = "SĐT liên hệ khẩn cấp";
            // 
            // txtEmergencyContact
            // 
            txtEmergencyContact.Font = new Font("Segoe UI", 12F);
            txtEmergencyContact.Location = new Point(455, 538);
            txtEmergencyContact.Margin = new Padding(4);
            txtEmergencyContact.Name = "txtEmergencyContact";
            txtEmergencyContact.ReadOnly = true;
            txtEmergencyContact.Size = new Size(735, 50);
            txtEmergencyContact.TabIndex = 21;
            // 
            // lblEmergencyContact
            // 
            lblEmergencyContact.AutoSize = true;
            lblEmergencyContact.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEmergencyContact.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmergencyContact.Location = new Point(455, 493);
            lblEmergencyContact.Margin = new Padding(4, 0, 4, 0);
            lblEmergencyContact.Name = "lblEmergencyContact";
            lblEmergencyContact.Size = new Size(300, 37);
            lblEmergencyContact.TabIndex = 20;
            lblEmergencyContact.Text = "Người liên hệ khẩn cấp";
            // 
            // txtPatientID
            // 
            txtPatientID.Font = new Font("Segoe UI", 12F);
            txtPatientID.Location = new Point(1271, 538);
            txtPatientID.Margin = new Padding(4);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.ReadOnly = true;
            txtPatientID.Size = new Size(735, 50);
            txtPatientID.TabIndex = 19;
            // 
            // lblPatientID
            // 
            lblPatientID.AutoSize = true;
            lblPatientID.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPatientID.ForeColor = Color.FromArgb(73, 80, 87);
            lblPatientID.Location = new Point(1271, 493);
            lblPatientID.Margin = new Padding(4, 0, 4, 0);
            lblPatientID.Name = "lblPatientID";
            lblPatientID.Size = new Size(194, 37);
            lblPatientID.TabIndex = 18;
            lblPatientID.Text = "Mã bệnh nhân";
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Segoe UI", 12F);
            txtCCCD.Location = new Point(1271, 416);
            txtCCCD.Margin = new Padding(4);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.ReadOnly = true;
            txtCCCD.Size = new Size(735, 50);
            txtCCCD.TabIndex = 15;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCCCD.ForeColor = Color.FromArgb(73, 80, 87);
            lblCCCD.Location = new Point(1271, 366);
            lblCCCD.Margin = new Padding(4, 0, 4, 0);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(257, 37);
            lblCCCD.TabIndex = 14;
            lblCCCD.Text = "Số CCCD / Hộ chiếu";
            // 
            // txtGender
            // 
            txtGender.Font = new Font("Segoe UI", 12F);
            txtGender.Location = new Point(455, 416);
            txtGender.Margin = new Padding(4);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(735, 50);
            txtGender.TabIndex = 13;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(73, 80, 87);
            lblGender.Location = new Point(455, 371);
            lblGender.Margin = new Padding(4, 0, 4, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(123, 37);
            lblGender.TabIndex = 12;
            lblGender.Text = "Giới tính";
            // 
            // dtpBirthday
            // 
            dtpBirthday.CalendarFont = new Font("Segoe UI", 12F);
            dtpBirthday.CustomFormat = "dd / MM / yyyy";
            dtpBirthday.Font = new Font("Segoe UI", 12F);
            dtpBirthday.Format = DateTimePickerFormat.Custom;
            dtpBirthday.Location = new Point(1271, 294);
            dtpBirthday.Margin = new Padding(4);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(735, 50);
            dtpBirthday.TabIndex = 11;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBirthday.ForeColor = Color.FromArgb(73, 80, 87);
            lblBirthday.Location = new Point(1271, 250);
            lblBirthday.Margin = new Padding(4, 0, 4, 0);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(140, 37);
            lblBirthday.TabIndex = 10;
            lblBirthday.Text = "Ngày sinh";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(455, 659);
            txtAddress.Margin = new Padding(4);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(1551, 50);
            txtAddress.TabIndex = 9;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(73, 80, 87);
            lblAddress.Location = new Point(455, 609);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 37);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(1271, 173);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(735, 50);
            txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblPhone.Location = new Point(1271, 128);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(178, 37);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(455, 173);
            txtFullName.Margin = new Padding(4);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(735, 50);
            txtFullName.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(73, 80, 87);
            lblFullName.Location = new Point(455, 128);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(135, 37);
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
            btnEditBasicInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEditBasicInfo.ForeColor = Color.FromArgb(0, 105, 217);
            btnEditBasicInfo.Location = new Point(1796, 19);
            btnEditBasicInfo.Margin = new Padding(4);
            btnEditBasicInfo.Name = "btnEditBasicInfo";
            btnEditBasicInfo.Size = new Size(297, 100);
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
            pnlPassActions.ResumeLayout(false);
            pnlChangePassword.ResumeLayout(false);
            pnlChangePassword.PerformLayout();
            pnlMedicalProfile.ResumeLayout(false);
            pnlMedicalProfile.PerformLayout();
            pnlMedicalActions.ResumeLayout(false);
            pnlBasicInfo.ResumeLayout(false);
            pnlBasicInfo.PerformLayout();
            pnlBasicInfoActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlBasicInfo;
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

        private Panel pnlMedicalProfile;
        private Label lblMedicalTitle;
        private Button btnEditMedical;
        private TextBox txtBloodType;
        private Label lblBloodType;
        private TextBox txtMedicalHistory;
        private Label lblMedicalHistory;
        private Panel pnlMedicalActions;
        private Button btnSaveMedical;
        private Button btnCancelMedical;

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
    }
}
