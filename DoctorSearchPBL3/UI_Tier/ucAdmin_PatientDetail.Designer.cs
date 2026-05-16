namespace UI_Tier
{
    partial class ucAdmin_PatientDetail
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
            pnlHeader = new Panel();
            btnExit = new Button();
            lblSubtitle = new Label();
            lblTitle = new Label();
            lblVNotes = new Label();
            pnlDivider = new Panel();
            btnSave = new Button();
            pnlFooter = new Panel();
            btnClose = new Button();
            pnlContent = new Panel();
            flpMain = new FlowLayoutPanel();
            lblBasicHeader = new Label();
            tlpBasic = new TableLayoutPanel();
            pnlName = new Panel();
            lblLName = new Label();
            lblVName = new Label();
            txtEditName = new TextBox();
            pnlRole = new Panel();
            lblLRole = new Label();
            pnlBadgeRole = new Panel();
            lblVRole = new Label();
            pnlPhone = new Panel();
            lblLPhone = new Label();
            lblVPhone = new Label();
            txtEditPhone = new TextBox();
            pnlDob = new Panel();
            lblLDob = new Label();
            lblVDob = new Label();
            dtpEditDob = new DateTimePicker();
            pnlGender = new Panel();
            lblLGender = new Label();
            lblVGender = new Label();
            cboEditGender = new ComboBox();
            pnlCCCD = new Panel();
            lblLCCCD = new Label();
            lblVCCCD = new Label();
            txtEditCCCD = new TextBox();
            pnlAddress = new Panel();
            lblLAddress = new Label();
            lblVAddress = new Label();
            txtEditAddress = new TextBox();
            pnlStatus = new Panel();
            lblLStatus = new Label();
            pnlBadgeStatus = new Panel();
            lblVStatus = new Label();
            pnlCreatedAt = new Panel();
            lblLCreatedAt = new Label();
            lblVCreatedAt = new Label();
            lblMedicalHeader = new Label();
            tlpMedical = new TableLayoutPanel();
            pnlMedCode = new Panel();
            lblLMedCode = new Label();
            lblVMedCode = new Label();
            pnlInsCode = new Panel();
            lblLInsCode = new Label();
            lblVInsCode = new Label();
            txtEditInsCode = new TextBox();
            pnlEmerName = new Panel();
            lblLEmerName = new Label();
            lblVEmerName = new Label();
            txtEditEmerName = new TextBox();
            pnlEmerPhone = new Panel();
            lblLEmerPhone = new Label();
            lblVEmerPhone = new Label();
            txtEditEmerPhone = new TextBox();
            pnlNotes = new Panel();
            lblLNotes = new Label();
            pnlNotesContainer = new Panel();
            txtEditNotes = new TextBox();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlContent.SuspendLayout();
            flpMain.SuspendLayout();
            tlpBasic.SuspendLayout();
            pnlName.SuspendLayout();
            pnlRole.SuspendLayout();
            pnlBadgeRole.SuspendLayout();
            pnlPhone.SuspendLayout();
            pnlDob.SuspendLayout();
            pnlGender.SuspendLayout();
            pnlCCCD.SuspendLayout();
            pnlAddress.SuspendLayout();
            pnlStatus.SuspendLayout();
            pnlBadgeStatus.SuspendLayout();
            pnlCreatedAt.SuspendLayout();
            tlpMedical.SuspendLayout();
            pnlMedCode.SuspendLayout();
            pnlInsCode.SuspendLayout();
            pnlEmerName.SuspendLayout();
            pnlEmerPhone.SuspendLayout();
            pnlNotes.SuspendLayout();
            pnlNotesContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnExit);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(5, 6, 5, 6);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1300, 100);
            pnlHeader.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnExit.ForeColor = Color.Red;
            btnExit.Location = new Point(1200, 10);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(50, 50);
            btnExit.TabIndex = 2;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(50, 90);
            lblSubtitle.Margin = new Padding(5, 0, 5, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(187, 41);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Trần Thị Bình";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(50, 25);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(399, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chi tiết Bệnh nhân";
            // 
            // lblVNotes
            // 
            lblVNotes.BackColor = Color.White;
            lblVNotes.Dock = DockStyle.Fill;
            lblVNotes.Font = new Font("Segoe UI", 12F);
            lblVNotes.ForeColor = Color.FromArgb(55, 65, 81);
            lblVNotes.Location = new Point(15, 10);
            lblVNotes.Margin = new Padding(5, 0, 5, 0);
            lblVNotes.Name = "lblVNotes";
            lblVNotes.Size = new Size(980, 50);
            lblVNotes.TabIndex = 0;
            lblVNotes.Text = "Tiền sử bệnh tim";
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.Black;
            pnlDivider.Location = new Point(100, 822);
            pnlDivider.Margin = new Padding(0, 40, 0, 20);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(1266, 1);
            pnlDivider.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(953, 28);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(144, 64);
            btnSave.TabIndex = 5;
            btnSave.Text = " Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Visible = false;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(249, 250, 251);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 1070);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1300, 130);
            pnlFooter.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(55, 65, 81);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1105, 28);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(169, 64);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.Controls.Add(flpMain);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 100);
            pnlContent.Margin = new Padding(5, 6, 5, 6);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1300, 970);
            pnlContent.TabIndex = 2;
            // 
            // flpMain
            // 
            flpMain.AutoSize = true;
            flpMain.Controls.Add(lblBasicHeader);
            flpMain.Controls.Add(tlpBasic);
            flpMain.Controls.Add(pnlDivider);
            flpMain.Controls.Add(lblMedicalHeader);
            flpMain.Controls.Add(tlpMedical);
            flpMain.Dock = DockStyle.Top;
            flpMain.FlowDirection = FlowDirection.TopDown;
            flpMain.Location = new Point(0, 0);
            flpMain.Margin = new Padding(5, 6, 5, 6);
            flpMain.Name = "flpMain";
            flpMain.Padding = new Padding(100, 30, 100, 60);
            flpMain.Size = new Size(1266, 1391);
            flpMain.TabIndex = 0;
            flpMain.WrapContents = false;
            // 
            // lblBasicHeader
            // 
            lblBasicHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBasicHeader.ForeColor = Color.FromArgb(17, 24, 39);
            lblBasicHeader.Location = new Point(105, 30);
            lblBasicHeader.Margin = new Padding(5, 0, 5, 0);
            lblBasicHeader.Name = "lblBasicHeader";
            lblBasicHeader.Size = new Size(1100, 50);
            lblBasicHeader.TabIndex = 0;
            lblBasicHeader.Text = "Thông tin cơ bản";
            lblBasicHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // tlpBasic
            // 
            tlpBasic.AutoSize = true;
            tlpBasic.ColumnCount = 2;
            tlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBasic.Controls.Add(pnlName, 0, 0);
            tlpBasic.Controls.Add(pnlRole, 1, 0);
            tlpBasic.Controls.Add(pnlPhone, 0, 1);
            tlpBasic.Controls.Add(pnlDob, 1, 1);
            tlpBasic.Controls.Add(pnlGender, 0, 2);
            tlpBasic.Controls.Add(pnlCCCD, 1, 2);
            tlpBasic.Controls.Add(pnlAddress, 0, 3);
            tlpBasic.Controls.Add(pnlStatus, 0, 4);
            tlpBasic.Controls.Add(pnlCreatedAt, 1, 4);
            tlpBasic.Location = new Point(105, 86);
            tlpBasic.Margin = new Padding(5, 6, 5, 6);
            tlpBasic.Name = "tlpBasic";
            tlpBasic.RowCount = 5;
            tlpBasic.RowStyles.Add(new RowStyle());
            tlpBasic.RowStyles.Add(new RowStyle());
            tlpBasic.RowStyles.Add(new RowStyle());
            tlpBasic.RowStyles.Add(new RowStyle());
            tlpBasic.RowStyles.Add(new RowStyle());
            tlpBasic.Size = new Size(1020, 690);
            tlpBasic.TabIndex = 1;
            // 
            // pnlName
            // 
            pnlName.Controls.Add(lblLName);
            pnlName.Controls.Add(lblVName);
            pnlName.Controls.Add(txtEditName);
            pnlName.Dock = DockStyle.Fill;
            pnlName.Location = new Point(5, 6);
            pnlName.Margin = new Padding(5, 6, 5, 6);
            pnlName.Name = "pnlName";
            pnlName.Size = new Size(500, 150);
            pnlName.TabIndex = 0;
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.Font = new Font("Segoe UI", 12F);
            lblLName.ForeColor = Color.FromArgb(107, 114, 128);
            lblLName.Location = new Point(0, 5);
            lblLName.Margin = new Padding(5, 0, 5, 0);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(157, 45);
            lblLName.TabIndex = 0;
            lblLName.Text = "Họ và tên";
            // 
            // lblVName
            // 
            lblVName.AutoSize = true;
            lblVName.Font = new Font("Segoe UI", 12F);
            lblVName.ForeColor = Color.FromArgb(17, 24, 39);
            lblVName.Location = new Point(0, 60);
            lblVName.Margin = new Padding(5, 0, 5, 0);
            lblVName.Name = "lblVName";
            lblVName.Size = new Size(202, 45);
            lblVName.TabIndex = 1;
            lblVName.Text = "Trần Thị Bình";
            // 
            // txtEditName
            // 
            txtEditName.BorderStyle = BorderStyle.FixedSingle;
            txtEditName.Font = new Font("Segoe UI", 12F);
            txtEditName.Location = new Point(0, 0);
            txtEditName.Name = "txtEditName";
            txtEditName.Size = new Size(100, 54);
            txtEditName.TabIndex = 0;
            // 
            // pnlRole
            // 
            pnlRole.Controls.Add(lblLRole);
            pnlRole.Controls.Add(pnlBadgeRole);
            pnlRole.Dock = DockStyle.Fill;
            pnlRole.Location = new Point(515, 6);
            pnlRole.Margin = new Padding(5, 6, 5, 6);
            pnlRole.Name = "pnlRole";
            pnlRole.Size = new Size(500, 150);
            pnlRole.TabIndex = 1;
            // 
            // lblLRole
            // 
            lblLRole.AutoSize = true;
            lblLRole.Font = new Font("Segoe UI", 12F);
            lblLRole.ForeColor = Color.FromArgb(107, 114, 128);
            lblLRole.Location = new Point(0, 10);
            lblLRole.Margin = new Padding(5, 0, 5, 0);
            lblLRole.Name = "lblLRole";
            lblLRole.Size = new Size(112, 45);
            lblLRole.TabIndex = 0;
            lblLRole.Text = "Vai trò";
            // 
            // pnlBadgeRole
            // 
            pnlBadgeRole.AutoSize = true;
            pnlBadgeRole.BackColor = Color.FromArgb(220, 252, 231);
            pnlBadgeRole.Controls.Add(lblVRole);
            pnlBadgeRole.Location = new Point(5, 54);
            pnlBadgeRole.Margin = new Padding(5, 6, 5, 6);
            pnlBadgeRole.Name = "pnlBadgeRole";
            pnlBadgeRole.Padding = new Padding(10, 5, 10, 5);
            pnlBadgeRole.Size = new Size(195, 55);
            pnlBadgeRole.TabIndex = 1;
            // 
            // lblVRole
            // 
            lblVRole.AutoSize = true;
            lblVRole.Font = new Font("Segoe UI", 12F);
            lblVRole.ForeColor = Color.FromArgb(22, 163, 74);
            lblVRole.Location = new Point(10, 5);
            lblVRole.Margin = new Padding(5, 0, 5, 0);
            lblVRole.Name = "lblVRole";
            lblVRole.Size = new Size(170, 45);
            lblVRole.TabIndex = 0;
            lblVRole.Text = "Bệnh nhân";
            // 
            // pnlPhone
            // 
            pnlPhone.Controls.Add(lblLPhone);
            pnlPhone.Controls.Add(lblVPhone);
            pnlPhone.Controls.Add(txtEditPhone);
            pnlPhone.Dock = DockStyle.Fill;
            pnlPhone.Location = new Point(5, 148);
            pnlPhone.Margin = new Padding(5, 6, 5, 6);
            pnlPhone.Name = "pnlPhone";
            pnlPhone.Size = new Size(500, 150);
            pnlPhone.TabIndex = 2;
            // 
            // lblLPhone
            // 
            lblLPhone.AutoSize = true;
            lblLPhone.Font = new Font("Segoe UI", 12F);
            lblLPhone.ForeColor = Color.FromArgb(107, 114, 128);
            lblLPhone.Location = new Point(0, 5);
            lblLPhone.Margin = new Padding(5, 0, 5, 0);
            lblLPhone.Name = "lblLPhone";
            lblLPhone.Size = new Size(208, 45);
            lblLPhone.TabIndex = 0;
            lblLPhone.Text = "Số điện thoại";
            // 
            // lblVPhone
            // 
            lblVPhone.AutoSize = true;
            lblVPhone.Font = new Font("Segoe UI", 12F);
            lblVPhone.ForeColor = Color.FromArgb(17, 24, 39);
            lblVPhone.Location = new Point(0, 60);
            lblVPhone.Margin = new Padding(5, 0, 5, 0);
            lblVPhone.Name = "lblVPhone";
            lblVPhone.Size = new Size(190, 45);
            lblVPhone.TabIndex = 1;
            lblVPhone.Text = "0766516287";
            // 
            // txtEditPhone
            // 
            txtEditPhone.BorderStyle = BorderStyle.FixedSingle;
            txtEditPhone.Font = new Font("Segoe UI", 12F);
            txtEditPhone.Location = new Point(0, 0);
            txtEditPhone.Name = "txtEditPhone";
            txtEditPhone.Size = new Size(100, 54);
            txtEditPhone.TabIndex = 0;
            // 
            // pnlDob
            // 
            pnlDob.Controls.Add(lblLDob);
            pnlDob.Controls.Add(lblVDob);
            pnlDob.Controls.Add(dtpEditDob);
            pnlDob.Dock = DockStyle.Fill;
            pnlDob.Location = new Point(515, 148);
            pnlDob.Margin = new Padding(5, 6, 5, 6);
            pnlDob.Name = "pnlDob";
            pnlDob.Size = new Size(500, 150);
            pnlDob.TabIndex = 3;
            // 
            // lblLDob
            // 
            lblLDob.AutoSize = true;
            lblLDob.Font = new Font("Segoe UI", 12F);
            lblLDob.ForeColor = Color.FromArgb(107, 114, 128);
            lblLDob.Location = new Point(0, 5);
            lblLDob.Margin = new Padding(5, 0, 5, 0);
            lblLDob.Name = "lblLDob";
            lblLDob.Size = new Size(161, 45);
            lblLDob.TabIndex = 0;
            lblLDob.Text = "Ngày sinh";
            // 
            // lblVDob
            // 
            lblVDob.AutoSize = true;
            lblVDob.Font = new Font("Segoe UI", 12F);
            lblVDob.ForeColor = Color.FromArgb(17, 24, 39);
            lblVDob.Location = new Point(0, 60);
            lblVDob.Margin = new Padding(5, 0, 5, 0);
            lblVDob.Name = "lblVDob";
            lblVDob.Size = new Size(180, 45);
            lblVDob.TabIndex = 1;
            lblVDob.Text = "08/12/2025";
            // 
            // dtpEditDob
            // 
            dtpEditDob.Font = new Font("Segoe UI", 12F);
            dtpEditDob.Location = new Point(0, 0);
            dtpEditDob.Name = "dtpEditDob";
            dtpEditDob.Size = new Size(200, 54);
            dtpEditDob.TabIndex = 0;
            // 
            // pnlGender
            // 
            pnlGender.Controls.Add(lblLGender);
            pnlGender.Controls.Add(lblVGender);
            pnlGender.Controls.Add(cboEditGender);
            pnlGender.Dock = DockStyle.Fill;
            pnlGender.Location = new Point(5, 290);
            pnlGender.Margin = new Padding(5, 6, 5, 6);
            pnlGender.Name = "pnlGender";
            pnlGender.Size = new Size(500, 150);
            pnlGender.TabIndex = 4;
            // 
            // lblLGender
            // 
            lblLGender.AutoSize = true;
            lblLGender.Font = new Font("Segoe UI", 12F);
            lblLGender.ForeColor = Color.FromArgb(107, 114, 128);
            lblLGender.Location = new Point(0, 5);
            lblLGender.Margin = new Padding(5, 0, 5, 0);
            lblLGender.Name = "lblLGender";
            lblLGender.Size = new Size(141, 45);
            lblLGender.TabIndex = 0;
            lblLGender.Text = "Giới tính";
            // 
            // lblVGender
            // 
            lblVGender.AutoSize = true;
            lblVGender.Font = new Font("Segoe UI", 12F);
            lblVGender.ForeColor = Color.FromArgb(17, 24, 39);
            lblVGender.Location = new Point(0, 60);
            lblVGender.Margin = new Padding(5, 0, 5, 0);
            lblVGender.Name = "lblVGender";
            lblVGender.Size = new Size(63, 45);
            lblVGender.TabIndex = 1;
            lblVGender.Text = "Nữ";
            // 
            // cboEditGender
            // 
            cboEditGender.FlatStyle = FlatStyle.Flat;
            cboEditGender.Font = new Font("Segoe UI", 12F);
            cboEditGender.Location = new Point(0, 0);
            cboEditGender.Name = "cboEditGender";
            cboEditGender.Size = new Size(121, 55);
            cboEditGender.TabIndex = 0;
            // 
            // pnlCCCD
            // 
            pnlCCCD.Controls.Add(lblLCCCD);
            pnlCCCD.Controls.Add(lblVCCCD);
            pnlCCCD.Controls.Add(txtEditCCCD);
            pnlCCCD.Dock = DockStyle.Fill;
            pnlCCCD.Location = new Point(515, 290);
            pnlCCCD.Margin = new Padding(5, 6, 5, 6);
            pnlCCCD.Name = "pnlCCCD";
            pnlCCCD.Size = new Size(500, 150);
            pnlCCCD.TabIndex = 5;
            // 
            // lblLCCCD
            // 
            lblLCCCD.AutoSize = true;
            lblLCCCD.Font = new Font("Segoe UI", 12F);
            lblLCCCD.ForeColor = Color.FromArgb(107, 114, 128);
            lblLCCCD.Location = new Point(0, 5);
            lblLCCCD.Margin = new Padding(5, 0, 5, 0);
            lblLCCCD.Name = "lblLCCCD";
            lblLCCCD.Size = new Size(100, 45);
            lblLCCCD.TabIndex = 0;
            lblLCCCD.Text = "CCCD";
            // 
            // lblVCCCD
            // 
            lblVCCCD.AutoSize = true;
            lblVCCCD.Font = new Font("Segoe UI", 12F);
            lblVCCCD.ForeColor = Color.FromArgb(17, 24, 39);
            lblVCCCD.Location = new Point(0, 60);
            lblVCCCD.Margin = new Padding(5, 0, 5, 0);
            lblVCCCD.Name = "lblVCCCD";
            lblVCCCD.Size = new Size(77, 45);
            lblVCCCD.TabIndex = 1;
            lblVCCCD.Text = "N/A";
            // 
            // txtEditCCCD
            // 
            txtEditCCCD.BorderStyle = BorderStyle.FixedSingle;
            txtEditCCCD.Font = new Font("Segoe UI", 12F);
            txtEditCCCD.Location = new Point(0, 0);
            txtEditCCCD.Name = "txtEditCCCD";
            txtEditCCCD.Size = new Size(100, 54);
            txtEditCCCD.TabIndex = 0;
            // 
            // pnlAddress
            // 
            tlpBasic.SetColumnSpan(pnlAddress, 2);
            pnlAddress.Controls.Add(lblLAddress);
            pnlAddress.Controls.Add(lblVAddress);
            pnlAddress.Controls.Add(txtEditAddress);
            pnlAddress.Dock = DockStyle.Fill;
            pnlAddress.Location = new Point(5, 432);
            pnlAddress.Margin = new Padding(5, 6, 5, 6);
            pnlAddress.Name = "pnlAddress";
            pnlAddress.Size = new Size(1010, 150);
            pnlAddress.TabIndex = 6;
            // 
            // lblLAddress
            // 
            lblLAddress.AutoSize = true;
            lblLAddress.Font = new Font("Segoe UI", 12F);
            lblLAddress.ForeColor = Color.FromArgb(107, 114, 128);
            lblLAddress.Location = new Point(0, 5);
            lblLAddress.Margin = new Padding(5, 0, 5, 0);
            lblLAddress.Name = "lblLAddress";
            lblLAddress.Size = new Size(278, 45);
            lblLAddress.TabIndex = 0;
            lblLAddress.Text = "Địa chỉ thường trú";
            // 
            // lblVAddress
            // 
            lblVAddress.AutoSize = true;
            lblVAddress.Font = new Font("Segoe UI", 12F);
            lblVAddress.ForeColor = Color.FromArgb(17, 24, 39);
            lblVAddress.Location = new Point(0, 60);
            lblVAddress.Margin = new Padding(5, 0, 5, 0);
            lblVAddress.Name = "lblVAddress";
            lblVAddress.Size = new Size(308, 45);
            lblVAddress.TabIndex = 1;
            lblVAddress.Text = "Liên Chiểu, Đà Nẵng";
            // 
            // txtEditAddress
            // 
            txtEditAddress.BorderStyle = BorderStyle.FixedSingle;
            txtEditAddress.Font = new Font("Segoe UI", 12F);
            txtEditAddress.Location = new Point(0, 0);
            txtEditAddress.Name = "txtEditAddress";
            txtEditAddress.Size = new Size(100, 54);
            txtEditAddress.TabIndex = 0;
            // 
            // pnlStatus
            // 
            pnlStatus.Controls.Add(lblLStatus);
            pnlStatus.Controls.Add(pnlBadgeStatus);
            pnlStatus.Dock = DockStyle.Fill;
            pnlStatus.Location = new Point(5, 574);
            pnlStatus.Margin = new Padding(5, 6, 5, 6);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(500, 110);
            pnlStatus.TabIndex = 7;
            // 
            // lblLStatus
            // 
            lblLStatus.AutoSize = true;
            lblLStatus.Font = new Font("Segoe UI", 12F);
            lblLStatus.ForeColor = Color.FromArgb(107, 114, 128);
            lblLStatus.Location = new Point(0, 10);
            lblLStatus.Margin = new Padding(5, 0, 5, 0);
            lblLStatus.Name = "lblLStatus";
            lblLStatus.Size = new Size(300, 45);
            lblLStatus.TabIndex = 0;
            lblLStatus.Text = "Trạng thái tài khoản";
            // 
            // pnlBadgeStatus
            // 
            pnlBadgeStatus.AutoSize = true;
            pnlBadgeStatus.BackColor = Color.FromArgb(220, 252, 231);
            pnlBadgeStatus.Controls.Add(lblVStatus);
            pnlBadgeStatus.Location = new Point(0, 55);
            pnlBadgeStatus.Margin = new Padding(5, 6, 5, 6);
            pnlBadgeStatus.Name = "pnlBadgeStatus";
            pnlBadgeStatus.Padding = new Padding(10, 5, 10, 5);
            pnlBadgeStatus.Size = new Size(198, 55);
            pnlBadgeStatus.TabIndex = 1;
            // 
            // lblVStatus
            // 
            lblVStatus.AutoSize = true;
            lblVStatus.Font = new Font("Segoe UI", 12F);
            lblVStatus.ForeColor = Color.FromArgb(22, 163, 74);
            lblVStatus.Location = new Point(10, 5);
            lblVStatus.Margin = new Padding(5, 0, 5, 0);
            lblVStatus.Name = "lblVStatus";
            lblVStatus.Size = new Size(173, 45);
            lblVStatus.TabIndex = 0;
            lblVStatus.Text = "Hoạt động";
            // 
            // pnlCreatedAt
            // 
            pnlCreatedAt.Controls.Add(lblLCreatedAt);
            pnlCreatedAt.Controls.Add(lblVCreatedAt);
            pnlCreatedAt.Dock = DockStyle.Fill;
            pnlCreatedAt.Location = new Point(515, 574);
            pnlCreatedAt.Margin = new Padding(5, 6, 5, 6);
            pnlCreatedAt.Name = "pnlCreatedAt";
            pnlCreatedAt.Size = new Size(500, 110);
            pnlCreatedAt.TabIndex = 8;
            // 
            // lblLCreatedAt
            // 
            lblLCreatedAt.AutoSize = true;
            lblLCreatedAt.Font = new Font("Segoe UI", 12F);
            lblLCreatedAt.ForeColor = Color.FromArgb(107, 114, 128);
            lblLCreatedAt.Location = new Point(0, 10);
            lblLCreatedAt.Margin = new Padding(5, 0, 5, 0);
            lblLCreatedAt.Name = "lblLCreatedAt";
            lblLCreatedAt.Size = new Size(289, 45);
            lblLCreatedAt.TabIndex = 0;
            lblLCreatedAt.Text = "Ngày tạo tài khoản";
            // 
            // lblVCreatedAt
            // 
            lblVCreatedAt.AutoSize = true;
            lblVCreatedAt.Font = new Font("Segoe UI", 12F);
            lblVCreatedAt.ForeColor = Color.FromArgb(17, 24, 39);
            lblVCreatedAt.Location = new Point(0, 60);
            lblVCreatedAt.Margin = new Padding(5, 0, 5, 0);
            lblVCreatedAt.Name = "lblVCreatedAt";
            lblVCreatedAt.Size = new Size(271, 45);
            lblVCreatedAt.TabIndex = 1;
            lblVCreatedAt.Text = "10:15:00 9/5/2026";
            // 
            // lblMedicalHeader
            // 
            lblMedicalHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMedicalHeader.ForeColor = Color.FromArgb(17, 24, 39);
            lblMedicalHeader.Location = new Point(105, 843);
            lblMedicalHeader.Margin = new Padding(5, 0, 5, 0);
            lblMedicalHeader.Name = "lblMedicalHeader";
            lblMedicalHeader.Size = new Size(1100, 50);
            lblMedicalHeader.TabIndex = 2;
            lblMedicalHeader.Text = "Thông tin y tế";
            lblMedicalHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // tlpMedical
            // 
            tlpMedical.AutoSize = true;
            tlpMedical.ColumnCount = 2;
            tlpMedical.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMedical.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMedical.Controls.Add(pnlMedCode, 0, 0);
            tlpMedical.Controls.Add(pnlInsCode, 1, 0);
            tlpMedical.Controls.Add(pnlEmerName, 0, 1);
            tlpMedical.Controls.Add(pnlEmerPhone, 1, 1);
            tlpMedical.Controls.Add(pnlNotes, 0, 3);
            tlpMedical.Location = new Point(105, 899);
            tlpMedical.Margin = new Padding(5, 6, 5, 6);
            tlpMedical.Name = "tlpMedical";
            tlpMedical.RowCount = 4;
            tlpMedical.RowStyles.Add(new RowStyle());
            tlpMedical.RowStyles.Add(new RowStyle());
            tlpMedical.RowStyles.Add(new RowStyle());
            tlpMedical.RowStyles.Add(new RowStyle());
            tlpMedical.Size = new Size(1020, 426);
            tlpMedical.TabIndex = 3;
            // 
            // pnlMedCode
            // 
            pnlMedCode.Controls.Add(lblLMedCode);
            pnlMedCode.Controls.Add(lblVMedCode);
            pnlMedCode.Dock = DockStyle.Fill;
            pnlMedCode.Location = new Point(5, 6);
            pnlMedCode.Margin = new Padding(5, 6, 5, 6);
            pnlMedCode.Name = "pnlMedCode";
            pnlMedCode.Size = new Size(500, 150);
            pnlMedCode.TabIndex = 0;
            // 
            // lblLMedCode
            // 
            lblLMedCode.AutoSize = true;
            lblLMedCode.Font = new Font("Segoe UI", 12F);
            lblLMedCode.ForeColor = Color.FromArgb(107, 114, 128);
            lblLMedCode.Location = new Point(0, 10);
            lblLMedCode.Margin = new Padding(5, 0, 5, 0);
            lblLMedCode.Name = "lblLMedCode";
            lblLMedCode.Size = new Size(225, 45);
            lblLMedCode.TabIndex = 0;
            lblLMedCode.Text = "Mã bệnh nhân";
            // 
            // lblVMedCode
            // 
            lblVMedCode.AutoSize = true;
            lblVMedCode.Font = new Font("Segoe UI", 12F);
            lblVMedCode.ForeColor = Color.FromArgb(17, 24, 39);
            lblVMedCode.Location = new Point(0, 40);
            lblVMedCode.Margin = new Padding(5, 0, 5, 0);
            lblVMedCode.Name = "lblVMedCode";
            lblVMedCode.Size = new Size(164, 45);
            lblVMedCode.TabIndex = 1;
            lblVMedCode.Text = "BN002345";
            // 
            // pnlInsCode
            // 
            pnlInsCode.Controls.Add(lblLInsCode);
            pnlInsCode.Controls.Add(lblVInsCode);
            pnlInsCode.Controls.Add(txtEditInsCode);
            pnlInsCode.Dock = DockStyle.Fill;
            pnlInsCode.Location = new Point(515, 6);
            pnlInsCode.Margin = new Padding(5, 6, 5, 6);
            pnlInsCode.Name = "pnlInsCode";
            pnlInsCode.Size = new Size(500, 150);
            pnlInsCode.TabIndex = 1;
            // 
            // lblLInsCode
            // 
            lblLInsCode.AutoSize = true;
            lblLInsCode.Font = new Font("Segoe UI", 12F);
            lblLInsCode.ForeColor = Color.FromArgb(107, 114, 128);
            lblLInsCode.Location = new Point(0, 5);
            lblLInsCode.Margin = new Padding(5, 0, 5, 0);
            lblLInsCode.Name = "lblLInsCode";
            lblLInsCode.Size = new Size(269, 45);
            lblLInsCode.TabIndex = 0;
            lblLInsCode.Text = "Mã bảo hiểm y tế";
            // 
            // lblVInsCode
            // 
            lblVInsCode.AutoSize = true;
            lblVInsCode.Font = new Font("Segoe UI", 12F);
            lblVInsCode.ForeColor = Color.FromArgb(17, 24, 39);
            lblVInsCode.Location = new Point(0, 60);
            lblVInsCode.Margin = new Padding(5, 0, 5, 0);
            lblVInsCode.Name = "lblVInsCode";
            lblVInsCode.Size = new Size(233, 45);
            lblVInsCode.TabIndex = 1;
            lblVInsCode.Text = "BHYT00234567";
            // 
            // txtEditInsCode
            // 
            txtEditInsCode.BorderStyle = BorderStyle.FixedSingle;
            txtEditInsCode.Font = new Font("Segoe UI", 12F);
            txtEditInsCode.Location = new Point(0, 0);
            txtEditInsCode.Name = "txtEditInsCode";
            txtEditInsCode.Size = new Size(100, 54);
            txtEditInsCode.TabIndex = 0;
            // 
            // pnlEmerName
            // 
            pnlEmerName.Controls.Add(lblLEmerName);
            pnlEmerName.Controls.Add(lblVEmerName);
            pnlEmerName.Controls.Add(txtEditEmerName);
            pnlEmerName.Dock = DockStyle.Fill;
            pnlEmerName.Location = new Point(5, 148);
            pnlEmerName.Margin = new Padding(5, 6, 5, 6);
            pnlEmerName.Name = "pnlEmerName";
            pnlEmerName.Size = new Size(500, 150);
            pnlEmerName.TabIndex = 2;
            // 
            // lblLEmerName
            // 
            lblLEmerName.AutoSize = true;
            lblLEmerName.Font = new Font("Segoe UI", 12F);
            lblLEmerName.ForeColor = Color.FromArgb(107, 114, 128);
            lblLEmerName.Location = new Point(0, 5);
            lblLEmerName.Margin = new Padding(5, 0, 5, 0);
            lblLEmerName.Name = "lblLEmerName";
            lblLEmerName.Size = new Size(290, 45);
            lblLEmerName.TabIndex = 0;
            lblLEmerName.Text = "Người liên hệ khẩn";
            // 
            // lblVEmerName
            // 
            lblVEmerName.AutoSize = true;
            lblVEmerName.Font = new Font("Segoe UI", 12F);
            lblVEmerName.ForeColor = Color.FromArgb(17, 24, 39);
            lblVEmerName.Location = new Point(0, 60);
            lblVEmerName.Margin = new Padding(5, 0, 5, 0);
            lblVEmerName.Name = "lblVEmerName";
            lblVEmerName.Size = new Size(193, 45);
            lblVEmerName.TabIndex = 1;
            lblVEmerName.Text = "Trần Thị Mai";
            // 
            // txtEditEmerName
            // 
            txtEditEmerName.BorderStyle = BorderStyle.FixedSingle;
            txtEditEmerName.Font = new Font("Segoe UI", 12F);
            txtEditEmerName.Location = new Point(0, 0);
            txtEditEmerName.Name = "txtEditEmerName";
            txtEditEmerName.Size = new Size(100, 54);
            txtEditEmerName.TabIndex = 0;
            // 
            // pnlEmerPhone
            // 
            pnlEmerPhone.Controls.Add(lblLEmerPhone);
            pnlEmerPhone.Controls.Add(lblVEmerPhone);
            pnlEmerPhone.Controls.Add(txtEditEmerPhone);
            pnlEmerPhone.Dock = DockStyle.Fill;
            pnlEmerPhone.Location = new Point(515, 148);
            pnlEmerPhone.Margin = new Padding(5, 6, 5, 6);
            pnlEmerPhone.Name = "pnlEmerPhone";
            pnlEmerPhone.Size = new Size(500, 150);
            pnlEmerPhone.TabIndex = 3;
            // 
            // lblLEmerPhone
            // 
            lblLEmerPhone.AutoSize = true;
            lblLEmerPhone.Font = new Font("Segoe UI", 12F);
            lblLEmerPhone.ForeColor = Color.FromArgb(107, 114, 128);
            lblLEmerPhone.Location = new Point(0, 5);
            lblLEmerPhone.Margin = new Padding(5, 0, 5, 0);
            lblLEmerPhone.Name = "lblLEmerPhone";
            lblLEmerPhone.Size = new Size(257, 45);
            lblLEmerPhone.TabIndex = 0;
            lblLEmerPhone.Text = "SĐT liên hệ khẩn";
            // 
            // lblVEmerPhone
            // 
            lblVEmerPhone.AutoSize = true;
            lblVEmerPhone.Font = new Font("Segoe UI", 12F);
            lblVEmerPhone.ForeColor = Color.FromArgb(17, 24, 39);
            lblVEmerPhone.Location = new Point(0, 60);
            lblVEmerPhone.Margin = new Padding(5, 0, 5, 0);
            lblVEmerPhone.Name = "lblVEmerPhone";
            lblVEmerPhone.Size = new Size(190, 45);
            lblVEmerPhone.TabIndex = 1;
            lblVEmerPhone.Text = "0902345678";
            // 
            // txtEditEmerPhone
            // 
            txtEditEmerPhone.BorderStyle = BorderStyle.FixedSingle;
            txtEditEmerPhone.Font = new Font("Segoe UI", 12F);
            txtEditEmerPhone.Location = new Point(0, 0);
            txtEditEmerPhone.Name = "txtEditEmerPhone";
            txtEditEmerPhone.Size = new Size(100, 54);
            txtEditEmerPhone.TabIndex = 0;
            // 
            // pnlNotes
            // 
            tlpMedical.SetColumnSpan(pnlNotes, 2);
            pnlNotes.Controls.Add(lblLNotes);
            pnlNotes.Controls.Add(pnlNotesContainer);
            pnlNotes.Dock = DockStyle.Fill;
            pnlNotes.Location = new Point(5, 290);
            pnlNotes.Margin = new Padding(5, 6, 5, 6);
            pnlNotes.Name = "pnlNotes";
            pnlNotes.Size = new Size(1010, 200);
            pnlNotes.TabIndex = 4;
            // 
            // lblLNotes
            // 
            lblLNotes.AutoSize = true;
            lblLNotes.Font = new Font("Segoe UI", 12F);
            lblLNotes.ForeColor = Color.FromArgb(107, 114, 128);
            lblLNotes.Location = new Point(0, 10);
            lblLNotes.Margin = new Padding(5, 0, 5, 0);
            lblLNotes.Name = "lblLNotes";
            lblLNotes.Size = new Size(128, 45);
            lblLNotes.TabIndex = 0;
            lblLNotes.Text = "Ghi chú";
            // 
            // pnlNotesContainer
            // 
            pnlNotesContainer.BackColor = Color.Transparent;
            pnlNotesContainer.Controls.Add(lblVNotes);
            pnlNotesContainer.Controls.Add(txtEditNotes);
            pnlNotesContainer.Location = new Point(0, 54);
            pnlNotesContainer.Margin = new Padding(5, 6, 5, 6);
            pnlNotesContainer.Name = "pnlNotesContainer";
            pnlNotesContainer.Padding = new Padding(0, 10, 0, 10);
            pnlNotesContainer.Size = new Size(1010, 130);
            pnlNotesContainer.TabIndex = 1;
            // 
            // txtEditNotes
            // 
            txtEditNotes.BorderStyle = BorderStyle.FixedSingle;
            txtEditNotes.Font = new Font("Segoe UI", 12F);
            txtEditNotes.Location = new Point(0, 0);
            txtEditNotes.Name = "txtEditNotes";
            txtEditNotes.Size = new Size(100, 54);
            txtEditNotes.TabIndex = 0;
            // 
            // ucAdmin_PatientDetail
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ucAdmin_PatientDetail";
            Size = new Size(1300, 1200);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            flpMain.ResumeLayout(false);
            flpMain.PerformLayout();
            tlpBasic.ResumeLayout(false);
            pnlName.ResumeLayout(false);
            pnlName.PerformLayout();
            pnlRole.ResumeLayout(false);
            pnlRole.PerformLayout();
            pnlBadgeRole.ResumeLayout(false);
            pnlBadgeRole.PerformLayout();
            pnlPhone.ResumeLayout(false);
            pnlPhone.PerformLayout();
            pnlDob.ResumeLayout(false);
            pnlDob.PerformLayout();
            pnlGender.ResumeLayout(false);
            pnlGender.PerformLayout();
            pnlCCCD.ResumeLayout(false);
            pnlCCCD.PerformLayout();
            pnlAddress.ResumeLayout(false);
            pnlAddress.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            pnlBadgeStatus.ResumeLayout(false);
            pnlBadgeStatus.PerformLayout();
            pnlCreatedAt.ResumeLayout(false);
            pnlCreatedAt.PerformLayout();
            tlpMedical.ResumeLayout(false);
            pnlMedCode.ResumeLayout(false);
            pnlMedCode.PerformLayout();
            pnlInsCode.ResumeLayout(false);
            pnlInsCode.PerformLayout();
            pnlEmerName.ResumeLayout(false);
            pnlEmerName.PerformLayout();
            pnlEmerPhone.ResumeLayout(false);
            pnlEmerPhone.PerformLayout();
            pnlNotes.ResumeLayout(false);
            pnlNotes.PerformLayout();
            pnlNotesContainer.ResumeLayout(false);
            pnlNotesContainer.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Label lblBasicHeader;
        private System.Windows.Forms.TableLayoutPanel tlpBasic;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblVName;
        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.Label lblLRole;
        private System.Windows.Forms.Panel pnlBadgeRole;
        private System.Windows.Forms.Label lblVRole;
        private System.Windows.Forms.Panel pnlPhone;
        private System.Windows.Forms.Label lblLPhone;
        private System.Windows.Forms.Label lblVPhone;
        private System.Windows.Forms.Panel pnlDob;
        private System.Windows.Forms.Label lblLDob;
        private System.Windows.Forms.Label lblVDob;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.Label lblLGender;
        private System.Windows.Forms.Label lblVGender;
        private System.Windows.Forms.Panel pnlCCCD;
        private System.Windows.Forms.Label lblLCCCD;
        private System.Windows.Forms.Label lblVCCCD;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.Label lblLAddress;
        private System.Windows.Forms.Label lblVAddress;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblLStatus;
        private System.Windows.Forms.Panel pnlBadgeStatus;
        private System.Windows.Forms.Label lblVStatus;
        private System.Windows.Forms.Panel pnlCreatedAt;
        private System.Windows.Forms.Label lblLCreatedAt;
        private System.Windows.Forms.Label lblVCreatedAt;
        private System.Windows.Forms.Label lblMedicalHeader;
        private System.Windows.Forms.TableLayoutPanel tlpMedical;
        private System.Windows.Forms.Panel pnlMedCode;
        private System.Windows.Forms.Label lblLMedCode;
        private System.Windows.Forms.Label lblVMedCode;
        private System.Windows.Forms.Panel pnlInsCode;
        private System.Windows.Forms.Label lblLInsCode;
        private System.Windows.Forms.Label lblVInsCode;
        private System.Windows.Forms.Panel pnlEmerName;
        private System.Windows.Forms.Label lblLEmerName;
        private System.Windows.Forms.Label lblVEmerName;
        private System.Windows.Forms.Panel pnlEmerPhone;
        private System.Windows.Forms.Label lblLEmerPhone;
        private System.Windows.Forms.Label lblVEmerPhone;
        private System.Windows.Forms.Panel pnlNotes;
        private System.Windows.Forms.Label lblLNotes;
        private System.Windows.Forms.Panel pnlNotesContainer;
        private System.Windows.Forms.Label lblVNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.TextBox txtEditPhone;
        private System.Windows.Forms.DateTimePicker dtpEditDob;
        private System.Windows.Forms.ComboBox cboEditGender;
        private System.Windows.Forms.TextBox txtEditCCCD;
        private System.Windows.Forms.TextBox txtEditAddress;
        private System.Windows.Forms.TextBox txtEditInsCode;
        private System.Windows.Forms.TextBox txtEditEmerName;
        private System.Windows.Forms.TextBox txtEditEmerPhone;
        private System.Windows.Forms.TextBox txtEditNotes;
        private System.Windows.Forms.Panel pnlDivider;
    }
}
