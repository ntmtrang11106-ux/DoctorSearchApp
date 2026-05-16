namespace UI_Tier
{
    partial class ucAdmin_DoctorDetail
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
            pnlFooter = new Panel();
            btnSave = new Button();
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
            pnlDivider = new Panel();
            lblProfessionalHeader = new Label();
            tlpProfessional = new TableLayoutPanel();
            pnlDept = new Panel();
            lblLDept = new Label();
            lblVDept = new Label();
            cboEditDept = new ComboBox();
            pnlPosition = new Panel();
            lblLPosition = new Label();
            lblVPosition = new Label();
            txtEditPosition = new TextBox();
            pnlExp = new Panel();
            lblLExp = new Label();
            lblVExp = new Label();
            nudEditExp = new NumericUpDown();
            pnlFee = new Panel();
            lblLFee = new Label();
            lblVFee = new Label();
            nudEditFee = new NumericUpDown();
            pnlBio = new Panel();
            lblLBio = new Label();
            lblVBio = new Label();
            txtEditBio = new TextBox();
            pnlApproval = new Panel();
            lblLApproval = new Label();
            pnlBadgeApproval = new Panel();
            lblVApproval = new Label();
            pnlLicense = new Panel();
            lnkUploadLicense = new LinkLabel();
            lnkViewLicense = new LinkLabel();
            lblLLicense = new Label();
            lblVLicense = new Label();
            txtEditLicense = new TextBox();
            pnlRating = new Panel();
            lblLRating = new Label();
            lblVRating = new Label();
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
            tlpProfessional.SuspendLayout();
            pnlDept.SuspendLayout();
            pnlPosition.SuspendLayout();
            pnlExp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEditExp).BeginInit();
            pnlFee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEditFee).BeginInit();
            pnlBio.SuspendLayout();
            pnlApproval.SuspendLayout();
            pnlBadgeApproval.SuspendLayout();
            pnlLicense.SuspendLayout();
            pnlRating.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnExit);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
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
            btnExit.Click += btnClose_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(49, 110);
            lblSubtitle.Margin = new Padding(5, 0, 5, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(260, 45);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Lê Hoàng Cường";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(50, 30);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(298, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chi tiết Bác sĩ";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(249, 250, 251);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 1080);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1300, 120);
            pnlFooter.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(984, 36);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(144, 64);
            btnSave.TabIndex = 5;
            btnSave.Text = " Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Visible = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(55, 65, 81);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1136, 36);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(144, 64);
            btnClose.TabIndex = 0;
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
            pnlContent.Size = new Size(1300, 980);
            pnlContent.TabIndex = 2;
            // 
            // flpMain
            // 
            flpMain.AutoSize = true;
            flpMain.Controls.Add(lblBasicHeader);
            flpMain.Controls.Add(tlpBasic);
            flpMain.Controls.Add(pnlDivider);
            flpMain.Controls.Add(lblProfessionalHeader);
            flpMain.Controls.Add(tlpProfessional);
            flpMain.Dock = DockStyle.Top;
            flpMain.FlowDirection = FlowDirection.TopDown;
            flpMain.Location = new Point(0, 0);
            flpMain.Margin = new Padding(5, 6, 5, 6);
            flpMain.Name = "flpMain";
            flpMain.Padding = new Padding(100, 30, 100, 60);
            flpMain.Size = new Size(1266, 1765);
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
            tlpBasic.ColumnCount = 3;
            tlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBasic.Controls.Add(pnlName, 0, 0);
            tlpBasic.Controls.Add(pnlRole, 2, 0);
            tlpBasic.Controls.Add(pnlPhone, 0, 1);
            tlpBasic.Controls.Add(pnlDob, 2, 1);
            tlpBasic.Controls.Add(pnlGender, 0, 2);
            tlpBasic.Controls.Add(pnlCCCD, 2, 2);
            tlpBasic.Controls.Add(pnlAddress, 0, 3);
            tlpBasic.Controls.Add(pnlStatus, 0, 4);
            tlpBasic.Controls.Add(pnlCreatedAt, 2, 4);
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
            lblVName.Size = new Size(260, 45);
            lblVName.TabIndex = 1;
            lblVName.Text = "Lê Hoàng Cường";
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
            pnlBadgeRole.BackColor = Color.FromArgb(239, 246, 255);
            pnlBadgeRole.Controls.Add(lblVRole);
            pnlBadgeRole.Location = new Point(7, 54);
            pnlBadgeRole.Margin = new Padding(5, 6, 5, 6);
            pnlBadgeRole.Name = "pnlBadgeRole";
            pnlBadgeRole.Padding = new Padding(10, 5, 10, 5);
            pnlBadgeRole.Size = new Size(125, 55);
            pnlBadgeRole.TabIndex = 1;
            // 
            // lblVRole
            // 
            lblVRole.AutoSize = true;
            lblVRole.Font = new Font("Segoe UI", 12F);
            lblVRole.ForeColor = Color.FromArgb(37, 99, 235);
            lblVRole.Location = new Point(10, 5);
            lblVRole.Margin = new Padding(5, 0, 5, 0);
            lblVRole.Name = "lblVRole";
            lblVRole.Size = new Size(100, 45);
            lblVRole.TabIndex = 0;
            lblVRole.Text = "Bác sĩ";
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
            lblVPhone.Text = "0934567890";
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
            lblVDob.Size = new Size(163, 45);
            lblVDob.TabIndex = 1;
            lblVDob.Text = "5/11/1990";
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
            lblVGender.Size = new Size(88, 45);
            lblVGender.TabIndex = 1;
            lblVGender.Text = "Nam";
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
            lblVCCCD.Size = new Size(224, 45);
            lblVCCCD.TabIndex = 1;
            lblVCCCD.Text = "001090034567";
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
            tlpBasic.SetColumnSpan(pnlAddress, 3);
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
            lblVAddress.Size = new Size(647, 45);
            lblVAddress.TabIndex = 1;
            lblVAddress.Text = "789 Đường Trần Hưng Đạo, Quận 5, TP.HCM";
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
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.Black;
            pnlDivider.Location = new Point(100, 822);
            pnlDivider.Margin = new Padding(0, 40, 0, 20);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(1266, 1);
            pnlDivider.TabIndex = 10;
            // 
            // lblProfessionalHeader
            // 
            lblProfessionalHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProfessionalHeader.ForeColor = Color.FromArgb(17, 24, 39);
            lblProfessionalHeader.Location = new Point(105, 843);
            lblProfessionalHeader.Margin = new Padding(5, 0, 5, 0);
            lblProfessionalHeader.Name = "lblProfessionalHeader";
            lblProfessionalHeader.Size = new Size(1100, 50);
            lblProfessionalHeader.TabIndex = 2;
            lblProfessionalHeader.Text = "Thông tin chuyên môn";
            lblProfessionalHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // tlpProfessional
            // 
            tlpProfessional.AutoSize = true;
            tlpProfessional.ColumnCount = 3;
            tlpProfessional.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpProfessional.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpProfessional.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpProfessional.Controls.Add(pnlDept, 0, 0);
            tlpProfessional.Controls.Add(pnlPosition, 2, 0);
            tlpProfessional.Controls.Add(pnlExp, 2, 1);
            tlpProfessional.Controls.Add(pnlFee, 0, 2);
            tlpProfessional.Controls.Add(pnlBio, 0, 4);
            tlpProfessional.Controls.Add(pnlApproval, 2, 2);
            tlpProfessional.Controls.Add(pnlLicense, 0, 3);
            tlpProfessional.Controls.Add(pnlRating, 0, 1);
            tlpProfessional.Location = new Point(105, 899);
            tlpProfessional.Margin = new Padding(5, 6, 5, 6);
            tlpProfessional.Name = "tlpProfessional";
            tlpProfessional.RowCount = 5;
            tlpProfessional.RowStyles.Add(new RowStyle());
            tlpProfessional.RowStyles.Add(new RowStyle());
            tlpProfessional.RowStyles.Add(new RowStyle());
            tlpProfessional.RowStyles.Add(new RowStyle());
            tlpProfessional.RowStyles.Add(new RowStyle());
            tlpProfessional.Size = new Size(1020, 800);
            tlpProfessional.TabIndex = 3;
            // 
            // pnlDept
            // 
            pnlDept.Controls.Add(lblLDept);
            pnlDept.Controls.Add(lblVDept);
            pnlDept.Controls.Add(cboEditDept);
            pnlDept.Dock = DockStyle.Fill;
            pnlDept.Location = new Point(5, 6);
            pnlDept.Margin = new Padding(5, 6, 5, 6);
            pnlDept.Name = "pnlDept";
            pnlDept.Size = new Size(500, 150);
            pnlDept.TabIndex = 0;
            // 
            // lblLDept
            // 
            lblLDept.AutoSize = true;
            lblLDept.Font = new Font("Segoe UI", 12F);
            lblLDept.ForeColor = Color.FromArgb(107, 114, 128);
            lblLDept.Location = new Point(0, 5);
            lblLDept.Margin = new Padding(5, 0, 5, 0);
            lblLDept.Name = "lblLDept";
            lblLDept.Size = new Size(288, 45);
            lblLDept.TabIndex = 0;
            lblLDept.Text = "Khoa/Chuyên khoa";
            // 
            // lblVDept
            // 
            lblVDept.AutoSize = true;
            lblVDept.Font = new Font("Segoe UI", 12F);
            lblVDept.ForeColor = Color.FromArgb(17, 24, 39);
            lblVDept.Location = new Point(0, 60);
            lblVDept.Margin = new Padding(5, 0, 5, 0);
            lblVDept.Name = "lblVDept";
            lblVDept.Size = new Size(362, 45);
            lblVDept.TabIndex = 1;
            lblVDept.Text = "Chấn thương chỉnh hình";
            // 
            // cboEditDept
            // 
            cboEditDept.FlatStyle = FlatStyle.Flat;
            cboEditDept.Font = new Font("Segoe UI", 12F);
            cboEditDept.Location = new Point(0, 0);
            cboEditDept.Name = "cboEditDept";
            cboEditDept.Size = new Size(121, 55);
            cboEditDept.TabIndex = 0;
            // 
            // pnlPosition
            // 
            pnlPosition.Controls.Add(lblLPosition);
            pnlPosition.Controls.Add(lblVPosition);
            pnlPosition.Controls.Add(txtEditPosition);
            pnlPosition.Dock = DockStyle.Fill;
            pnlPosition.Location = new Point(515, 6);
            pnlPosition.Margin = new Padding(5, 6, 5, 6);
            pnlPosition.Name = "pnlPosition";
            pnlPosition.Size = new Size(500, 150);
            pnlPosition.TabIndex = 1;
            // 
            // lblLPosition
            // 
            lblLPosition.AutoSize = true;
            lblLPosition.Font = new Font("Segoe UI", 12F);
            lblLPosition.ForeColor = Color.FromArgb(107, 114, 128);
            lblLPosition.Location = new Point(0, 5);
            lblLPosition.Margin = new Padding(5, 0, 5, 0);
            lblLPosition.Name = "lblLPosition";
            lblLPosition.Size = new Size(172, 45);
            lblLPosition.TabIndex = 0;
            lblLPosition.Text = "Chức danh";
            // 
            // lblVPosition
            // 
            lblVPosition.AutoSize = true;
            lblVPosition.Font = new Font("Segoe UI", 12F);
            lblVPosition.ForeColor = Color.FromArgb(17, 24, 39);
            lblVPosition.Location = new Point(0, 60);
            lblVPosition.Margin = new Padding(5, 0, 5, 0);
            lblVPosition.Name = "lblVPosition";
            lblVPosition.Size = new Size(100, 45);
            lblVPosition.TabIndex = 1;
            lblVPosition.Text = "Bác sĩ";
            // 
            // txtEditPosition
            // 
            txtEditPosition.BorderStyle = BorderStyle.FixedSingle;
            txtEditPosition.Font = new Font("Segoe UI", 12F);
            txtEditPosition.Location = new Point(0, 0);
            txtEditPosition.Name = "txtEditPosition";
            txtEditPosition.Size = new Size(100, 54);
            txtEditPosition.TabIndex = 0;
            // 
            // pnlExp
            // 
            pnlExp.Controls.Add(lblLExp);
            pnlExp.Controls.Add(lblVExp);
            pnlExp.Controls.Add(nudEditExp);
            pnlExp.Dock = DockStyle.Fill;
            pnlExp.Location = new Point(515, 148);
            pnlExp.Margin = new Padding(5, 6, 5, 6);
            pnlExp.Name = "pnlExp";
            pnlExp.Size = new Size(500, 150);
            pnlExp.TabIndex = 3;
            // 
            // lblLExp
            // 
            lblLExp.AutoSize = true;
            lblLExp.Font = new Font("Segoe UI", 12F);
            lblLExp.ForeColor = Color.FromArgb(107, 114, 128);
            lblLExp.Location = new Point(0, 5);
            lblLExp.Margin = new Padding(5, 0, 5, 0);
            lblLExp.Name = "lblLExp";
            lblLExp.Size = new Size(313, 45);
            lblLExp.TabIndex = 0;
            lblLExp.Text = "Số năm kinh nghiệm";
            // 
            // lblVExp
            // 
            lblVExp.AutoSize = true;
            lblVExp.Font = new Font("Segoe UI", 12F);
            lblVExp.ForeColor = Color.FromArgb(17, 24, 39);
            lblVExp.Location = new Point(0, 60);
            lblVExp.Margin = new Padding(5, 0, 5, 0);
            lblVExp.Name = "lblVExp";
            lblVExp.Size = new Size(108, 45);
            lblVExp.TabIndex = 1;
            lblVExp.Text = "5 năm";
            // 
            // nudEditExp
            // 
            nudEditExp.Font = new Font("Segoe UI", 12F);
            nudEditExp.Location = new Point(0, 0);
            nudEditExp.Name = "nudEditExp";
            nudEditExp.Size = new Size(120, 54);
            nudEditExp.TabIndex = 0;
            nudEditExp.Visible = false;
            // 
            // pnlFee
            // 
            pnlFee.Controls.Add(lblLFee);
            pnlFee.Controls.Add(lblVFee);
            pnlFee.Controls.Add(nudEditFee);
            pnlFee.Dock = DockStyle.Fill;
            pnlFee.Location = new Point(5, 290);
            pnlFee.Margin = new Padding(5, 6, 5, 6);
            pnlFee.Name = "pnlFee";
            pnlFee.Size = new Size(500, 150);
            pnlFee.TabIndex = 4;
            // 
            // lblLFee
            // 
            lblLFee.AutoSize = true;
            lblLFee.Font = new Font("Segoe UI", 12F);
            lblLFee.ForeColor = Color.FromArgb(107, 114, 128);
            lblLFee.Location = new Point(0, 5);
            lblLFee.Margin = new Padding(5, 0, 5, 0);
            lblLFee.Name = "lblLFee";
            lblLFee.Size = new Size(151, 45);
            lblLFee.TabIndex = 0;
            lblLFee.Text = "Phí khám";
            // 
            // lblVFee
            // 
            lblVFee.AutoSize = true;
            lblVFee.Font = new Font("Segoe UI", 12F);
            lblVFee.ForeColor = Color.FromArgb(17, 24, 39);
            lblVFee.Location = new Point(0, 60);
            lblVFee.Margin = new Padding(5, 0, 5, 0);
            lblVFee.Name = "lblVFee";
            lblVFee.Size = new Size(148, 45);
            lblVFee.TabIndex = 1;
            lblVFee.Text = "350.000đ";
            // 
            // nudEditFee
            // 
            nudEditFee.Font = new Font("Segoe UI", 12F);
            nudEditFee.Location = new Point(0, 0);
            nudEditFee.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudEditFee.Name = "nudEditFee";
            nudEditFee.Size = new Size(120, 54);
            nudEditFee.TabIndex = 0;
            nudEditFee.Visible = false;
            // 
            // pnlBio
            // 
            tlpProfessional.SetColumnSpan(pnlBio, 3);
            pnlBio.Controls.Add(lblLBio);
            pnlBio.Controls.Add(lblVBio);
            pnlBio.Controls.Add(txtEditBio);
            pnlBio.Dock = DockStyle.Fill;
            pnlBio.Location = new Point(5, 574);
            pnlBio.Margin = new Padding(5, 6, 5, 6);
            pnlBio.Name = "pnlBio";
            pnlBio.Size = new Size(1010, 220);
            pnlBio.TabIndex = 8;
            // 
            // lblLBio
            // 
            lblLBio.AutoSize = true;
            lblLBio.Font = new Font("Segoe UI", 12F);
            lblLBio.ForeColor = Color.FromArgb(107, 114, 128);
            lblLBio.Location = new Point(0, 5);
            lblLBio.Margin = new Padding(5, 0, 5, 0);
            lblLBio.Name = "lblLBio";
            lblLBio.Size = new Size(122, 45);
            lblLBio.TabIndex = 0;
            lblLBio.Text = "Tiểu sử";
            // 
            // lblVBio
            // 
            lblVBio.AutoSize = true;
            lblVBio.Font = new Font("Segoe UI", 12F);
            lblVBio.ForeColor = Color.FromArgb(17, 24, 39);
            lblVBio.Location = new Point(0, 60);
            lblVBio.Margin = new Padding(5, 0, 5, 0);
            lblVBio.Name = "lblVBio";
            lblVBio.Size = new Size(224, 45);
            lblVBio.TabIndex = 1;
            lblVBio.Text = "Chưa cập nhật";
            // 
            // txtEditBio
            // 
            txtEditBio.BorderStyle = BorderStyle.FixedSingle;
            txtEditBio.Font = new Font("Segoe UI", 12F);
            txtEditBio.Location = new Point(0, 0);
            txtEditBio.Name = "txtEditBio";
            txtEditBio.Size = new Size(100, 54);
            txtEditBio.TabIndex = 0;
            txtEditBio.Visible = false;
            // 
            // pnlApproval
            // 
            pnlApproval.Controls.Add(lblLApproval);
            pnlApproval.Controls.Add(pnlBadgeApproval);
            pnlApproval.Dock = DockStyle.Fill;
            pnlApproval.Location = new Point(515, 290);
            pnlApproval.Margin = new Padding(5, 6, 5, 6);
            pnlApproval.Name = "pnlApproval";
            pnlApproval.Size = new Size(500, 150);
            pnlApproval.TabIndex = 6;
            // 
            // lblLApproval
            // 
            lblLApproval.AutoSize = true;
            lblLApproval.Font = new Font("Segoe UI", 12F);
            lblLApproval.ForeColor = Color.FromArgb(107, 114, 128);
            lblLApproval.Location = new Point(0, 10);
            lblLApproval.Margin = new Padding(5, 0, 5, 0);
            lblLApproval.Name = "lblLApproval";
            lblLApproval.Size = new Size(312, 45);
            lblLApproval.TabIndex = 0;
            lblLApproval.Text = "Trạng thái phê duyệt";
            // 
            // pnlBadgeApproval
            // 
            pnlBadgeApproval.AutoSize = true;
            pnlBadgeApproval.BackColor = Color.FromArgb(254, 252, 232);
            pnlBadgeApproval.Controls.Add(lblVApproval);
            pnlBadgeApproval.Location = new Point(7, 69);
            pnlBadgeApproval.Margin = new Padding(5, 6, 5, 6);
            pnlBadgeApproval.Name = "pnlBadgeApproval";
            pnlBadgeApproval.Padding = new Padding(10, 5, 10, 5);
            pnlBadgeApproval.Size = new Size(191, 55);
            pnlBadgeApproval.TabIndex = 1;
            // 
            // lblVApproval
            // 
            lblVApproval.AutoSize = true;
            lblVApproval.Font = new Font("Segoe UI", 12F);
            lblVApproval.ForeColor = Color.FromArgb(161, 98, 7);
            lblVApproval.Location = new Point(10, 5);
            lblVApproval.Margin = new Padding(5, 0, 5, 0);
            lblVApproval.Name = "lblVApproval";
            lblVApproval.Size = new Size(166, 45);
            lblVApproval.TabIndex = 0;
            lblVApproval.Text = "Chờ duyệt";
            // 
            // pnlLicense
            // 
            tlpProfessional.SetColumnSpan(pnlLicense, 3);
            pnlLicense.Controls.Add(lnkUploadLicense);
            pnlLicense.Controls.Add(lnkViewLicense);
            pnlLicense.Controls.Add(lblLLicense);
            pnlLicense.Controls.Add(lblVLicense);
            pnlLicense.Controls.Add(txtEditLicense);
            pnlLicense.Location = new Point(5, 432);
            pnlLicense.Margin = new Padding(5, 6, 5, 6);
            pnlLicense.Name = "pnlLicense";
            pnlLicense.Size = new Size(1010, 150);
            pnlLicense.TabIndex = 2;
            // 
            // lnkUploadLicense
            // 
            lnkUploadLicense.AutoSize = true;
            lnkUploadLicense.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lnkUploadLicense.Location = new Point(510, 60);
            lnkUploadLicense.Name = "lnkUploadLicense";
            lnkUploadLicense.Size = new Size(220, 32);
            lnkUploadLicense.TabIndex = 3;
            lnkUploadLicense.TabStop = true;
            lnkUploadLicense.Text = "(Tải lên/Cập nhật)";
            // 
            // lnkViewLicense
            // 
            lnkViewLicense.AutoSize = true;
            lnkViewLicense.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lnkViewLicense.Location = new Point(510, 60);
            lnkViewLicense.Name = "lnkViewLicense";
            lnkViewLicense.Size = new Size(143, 37);
            lnkViewLicense.TabIndex = 2;
            lnkViewLicense.TabStop = true;
            lnkViewLicense.Text = "(Xem file)";
            lnkViewLicense.Visible = false;
            // 
            // lblLLicense
            // 
            lblLLicense.AutoSize = true;
            lblLLicense.Font = new Font("Segoe UI", 12F);
            lblLLicense.ForeColor = Color.FromArgb(107, 114, 128);
            lblLLicense.Location = new Point(0, 5);
            lblLLicense.Margin = new Padding(5, 0, 5, 0);
            lblLLicense.Name = "lblLLicense";
            lblLLicense.Size = new Size(364, 45);
            lblLLicense.TabIndex = 0;
            lblLLicense.Text = "Số chứng chỉ hành nghề";
            // 
            // lblVLicense
            // 
            lblVLicense.AutoSize = true;
            lblVLicense.Font = new Font("Segoe UI", 12F);
            lblVLicense.ForeColor = Color.FromArgb(17, 24, 39);
            lblVLicense.Location = new Point(0, 60);
            lblVLicense.Margin = new Padding(5, 0, 5, 0);
            lblVLicense.Name = "lblVLicense";
            lblVLicense.Size = new Size(157, 45);
            lblVLicense.TabIndex = 1;
            lblVLicense.Text = "BS345678";
            // 
            // txtEditLicense
            // 
            txtEditLicense.BorderStyle = BorderStyle.FixedSingle;
            txtEditLicense.Font = new Font("Segoe UI", 12F);
            txtEditLicense.Location = new Point(0, 0);
            txtEditLicense.Name = "txtEditLicense";
            txtEditLicense.Size = new Size(100, 54);
            txtEditLicense.TabIndex = 0;
            txtEditLicense.Visible = false;
            // 
            // pnlRating
            // 
            pnlRating.Controls.Add(lblLRating);
            pnlRating.Controls.Add(lblVRating);
            pnlRating.Dock = DockStyle.Fill;
            pnlRating.Location = new Point(5, 148);
            pnlRating.Margin = new Padding(5, 6, 5, 6);
            pnlRating.Name = "pnlRating";
            pnlRating.Size = new Size(500, 150);
            pnlRating.TabIndex = 7;
            // 
            // lblLRating
            // 
            lblLRating.AutoSize = true;
            lblLRating.Font = new Font("Segoe UI", 12F);
            lblLRating.ForeColor = Color.FromArgb(107, 114, 128);
            lblLRating.Location = new Point(0, 10);
            lblLRating.Margin = new Padding(5, 0, 5, 0);
            lblLRating.Name = "lblLRating";
            lblLRating.Size = new Size(146, 45);
            lblLRating.TabIndex = 0;
            lblLRating.Text = "Đánh giá";
            // 
            // lblVRating
            // 
            lblVRating.AutoSize = true;
            lblVRating.Font = new Font("Segoe UI", 12F);
            lblVRating.ForeColor = Color.FromArgb(17, 24, 39);
            lblVRating.Location = new Point(0, 60);
            lblVRating.Margin = new Padding(5, 0, 5, 0);
            lblVRating.Name = "lblVRating";
            lblVRating.Size = new Size(268, 45);
            lblVRating.TabIndex = 1;
            lblVRating.Text = "Chưa có đánh giá";
            // 
            // ucAdmin_DoctorDetail
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ucAdmin_DoctorDetail";
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
            tlpProfessional.ResumeLayout(false);
            pnlDept.ResumeLayout(false);
            pnlDept.PerformLayout();
            pnlPosition.ResumeLayout(false);
            pnlPosition.PerformLayout();
            pnlExp.ResumeLayout(false);
            pnlExp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEditExp).EndInit();
            pnlFee.ResumeLayout(false);
            pnlFee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEditFee).EndInit();
            pnlBio.ResumeLayout(false);
            pnlBio.PerformLayout();
            pnlApproval.ResumeLayout(false);
            pnlApproval.PerformLayout();
            pnlBadgeApproval.ResumeLayout(false);
            pnlBadgeApproval.PerformLayout();
            pnlLicense.ResumeLayout(false);
            pnlLicense.PerformLayout();
            pnlRating.ResumeLayout(false);
            pnlRating.PerformLayout();
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
        private System.Windows.Forms.Label lblProfessionalHeader;
        private System.Windows.Forms.TableLayoutPanel tlpProfessional;
        private System.Windows.Forms.Panel pnlDept;
        private System.Windows.Forms.Label lblLDept;
        private System.Windows.Forms.Label lblVDept;
        private System.Windows.Forms.Panel pnlPosition;
        private System.Windows.Forms.Label lblLPosition;
        private System.Windows.Forms.Label lblVPosition;
        private System.Windows.Forms.Panel pnlLicense;
        private System.Windows.Forms.Label lblLLicense;
        private System.Windows.Forms.Label lblVLicense;
        private System.Windows.Forms.Panel pnlExp;
        private System.Windows.Forms.Label lblLExp;
        private System.Windows.Forms.Label lblVExp;
        private System.Windows.Forms.Panel pnlFee;
        private System.Windows.Forms.Label lblLFee;
        private System.Windows.Forms.Label lblVFee;
        private System.Windows.Forms.Panel pnlApproval;
        private System.Windows.Forms.Label lblLApproval;
        private System.Windows.Forms.Panel pnlBadgeApproval;
        private System.Windows.Forms.Label lblVApproval;
        private System.Windows.Forms.Panel pnlRating;
        private System.Windows.Forms.Label lblLRating;
        private System.Windows.Forms.Label lblVRating;
        private System.Windows.Forms.Panel pnlBio;
        private System.Windows.Forms.Label lblLBio;
        private System.Windows.Forms.Label lblVBio;
        private System.Windows.Forms.LinkLabel lnkViewLicense;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lnkUploadLicense;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.TextBox txtEditPhone;
        private System.Windows.Forms.DateTimePicker dtpEditDob;
        private System.Windows.Forms.ComboBox cboEditGender;
        private System.Windows.Forms.TextBox txtEditCCCD;
        private System.Windows.Forms.TextBox txtEditAddress;
        private System.Windows.Forms.ComboBox cboEditDept;
        private System.Windows.Forms.TextBox txtEditPosition;
        private System.Windows.Forms.TextBox txtEditLicense;
        private System.Windows.Forms.NumericUpDown nudEditExp;
        private System.Windows.Forms.NumericUpDown nudEditFee;
        private System.Windows.Forms.TextBox txtEditBio;
    }
}
