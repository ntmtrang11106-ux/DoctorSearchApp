namespace UI_Tier
{
    partial class ucBookingDialog
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
            lblTitle = new Label();
            lblSubTitle = new Label();
            btnClose = new Button();
            pnlDoctorInfo = new Panel();
            lblDocDept = new Label();
            lblDocName = new Label();
            picDocAvatar = new PictureBox();
            lblDateTitle = new Label();
            lblDateIcon = new Label();
            dtpDate = new DateTimePicker();
            lblTimeTitle = new Label();
            flpTimeSlots = new FlowLayoutPanel();
            lblReasonTitle = new Label();
            lblReasonIcon = new Label();
            txtReason = new RichTextBox();
            lblCharCount = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pnlHeader.SuspendLayout();
            pnlDoctorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDocAvatar).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 112, 255);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubTitle);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(950, 128);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(47, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(304, 59);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Đặt lịch khám";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSubTitle.ForeColor = Color.FromArgb(219, 234, 254);
            lblSubTitle.Location = new Point(47, 74);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(479, 45);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "Chọn thời gian phù hợp với bạn";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe MDL2 Assets", 14F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(870, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(60, 60);
            btnClose.TabIndex = 0;
            btnClose.Text = "";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnCancel_Click;
            // 
            // pnlDoctorInfo
            // 
            pnlDoctorInfo.BackColor = Color.FromArgb(243, 248, 255);
            pnlDoctorInfo.Controls.Add(lblDocDept);
            pnlDoctorInfo.Controls.Add(lblDocName);
            pnlDoctorInfo.Controls.Add(picDocAvatar);
            pnlDoctorInfo.Dock = DockStyle.Top;
            pnlDoctorInfo.Location = new Point(0, 128);
            pnlDoctorInfo.Name = "pnlDoctorInfo";
            pnlDoctorInfo.Size = new Size(950, 177);
            pnlDoctorInfo.TabIndex = 15;
            // 
            // lblDocDept
            // 
            lblDocDept.AutoSize = true;
            lblDocDept.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDocDept.ForeColor = Color.FromArgb(37, 99, 235);
            lblDocDept.Location = new Point(227, 97);
            lblDocDept.Name = "lblDocDept";
            lblDocDept.Size = new Size(162, 45);
            lblDocDept.TabIndex = 2;
            lblDocDept.Text = "Tim mạch";
            // 
            // lblDocName
            // 
            lblDocName.AutoSize = true;
            lblDocName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDocName.ForeColor = Color.FromArgb(31, 41, 55);
            lblDocName.Location = new Point(227, 36);
            lblDocName.Name = "lblDocName";
            lblDocName.Size = new Size(356, 50);
            lblDocName.TabIndex = 1;
            lblDocName.Text = "BS. Nguyễn Văn An";
            // 
            // picDocAvatar
            // 
            picDocAvatar.Location = new Point(62, 22);
            picDocAvatar.Name = "picDocAvatar";
            picDocAvatar.Size = new Size(140, 140);
            picDocAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picDocAvatar.TabIndex = 0;
            picDocAvatar.TabStop = false;
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDateTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblDateTitle.Location = new Point(104, 325);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(290, 45);
            lblDateTitle.TabIndex = 1;
            lblDateTitle.Text = "Chọn ngày khám *";
            // 
            // lblDateIcon
            // 
            lblDateIcon.AutoSize = true;
            lblDateIcon.Font = new Font("Segoe MDL2 Assets", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblDateIcon.Location = new Point(40, 325);
            lblDateIcon.Name = "lblDateIcon";
            lblDateIcon.Size = new Size(62, 43);
            lblDateIcon.TabIndex = 12;
            lblDateIcon.Text = "";
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "dd/MM/yyyy";
            dtpDate.Font = new Font("Segoe UI", 12F);
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(55, 394);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(833, 50);
            dtpDate.TabIndex = 2;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // lblTimeTitle
            // 
            lblTimeTitle.AutoSize = true;
            lblTimeTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTimeTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblTimeTitle.Location = new Point(106, 474);
            lblTimeTitle.Name = "lblTimeTitle";
            lblTimeTitle.Size = new Size(266, 45);
            lblTimeTitle.TabIndex = 3;
            lblTimeTitle.Text = "Chọn giờ khám *";
            // 
            // flpTimeSlots
            // 
            flpTimeSlots.ForeColor = Color.Gray;
            flpTimeSlots.Location = new Point(55, 546);
            flpTimeSlots.Name = "flpTimeSlots";
            flpTimeSlots.Size = new Size(833, 385);
            flpTimeSlots.TabIndex = 4;
            // 
            // lblReasonTitle
            // 
            lblReasonTitle.AutoSize = true;
            lblReasonTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblReasonTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblReasonTitle.Location = new Point(103, 969);
            lblReasonTitle.Name = "lblReasonTitle";
            lblReasonTitle.Size = new Size(197, 45);
            lblReasonTitle.TabIndex = 6;
            lblReasonTitle.Text = "Lý do khám ";
            // 
            // lblReasonIcon
            // 
            lblReasonIcon.AutoSize = true;
            lblReasonIcon.Font = new Font("Segoe MDL2 Assets", 12F);
            lblReasonIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblReasonIcon.Location = new Point(40, 975);
            lblReasonIcon.Name = "lblReasonIcon";
            lblReasonIcon.Size = new Size(0, 32);
            lblReasonIcon.TabIndex = 14;
            // 
            // txtReason
            // 
            txtReason.BackColor = SystemColors.Window;
            txtReason.BorderStyle = BorderStyle.None;
            txtReason.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReason.ForeColor = Color.Gray;
            txtReason.Location = new Point(55, 1036);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(833, 180);
            txtReason.TabIndex = 7;
            txtReason.Text = "Vui lòng mô tả lý do bạn cần khám bệnh...";
            txtReason.TextChanged += txtReason_TextChanged;
            // 
            // lblCharCount
            // 
            lblCharCount.AutoSize = true;
            lblCharCount.Font = new Font("Segoe UI", 9F);
            lblCharCount.ForeColor = Color.Gray;
            lblCharCount.Location = new Point(47, 1221);
            lblCharCount.Name = "lblCharCount";
            lblCharCount.Size = new Size(135, 32);
            lblCharCount.TabIndex = 8;
            lblCharCount.Text = "0/500 ký tự";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(37, 99, 235);
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(55, 1277);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(591, 65);
            btnConfirm.TabIndex = 10;
            btnConfirm.Text = "Xác nhận đặt lịch";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(243, 244, 246);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(31, 41, 55);
            btnCancel.Location = new Point(686, 1276);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(202, 65);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(294, 972);
            label1.Name = "label1";
            label1.Size = new Size(236, 40);
            label1.TabIndex = 16;
            label1.Text = "(không bắt buộc)";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe MDL2 Assets", 23F);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(29, 456);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(92, 84);
            label2.TabIndex = 17;
            label2.Text = "🕓";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe MDL2 Assets", 23F);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(29, 944);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(80, 91);
            label3.TabIndex = 18;
            label3.Text = "📄";
            // 
            // ucBookingDialog
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblTimeTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pnlDoctorInfo);
            Controls.Add(lblReasonIcon);
            Controls.Add(lblDateIcon);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(lblCharCount);
            Controls.Add(txtReason);
            Controls.Add(lblReasonTitle);
            Controls.Add(flpTimeSlots);
            Controls.Add(dtpDate);
            Controls.Add(lblDateTitle);
            Controls.Add(pnlHeader);
            Name = "ucBookingDialog";
            Size = new Size(950, 1382);
            Load += ucBookingDialog_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlDoctorInfo.ResumeLayout(false);
            pnlDoctorInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDocAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubTitle;
        private Button btnClose;
        private PictureBox picIcon;
        private Panel pnlDoctorInfo;
        private PictureBox picDocAvatar;
        private Label lblDocName;
        private Label lblDocDept;
        private Label lblDateTitle;
        private Label lblDateIcon;
        private DateTimePicker dtpDate;
        private Label lblTimeTitle;
        private FlowLayoutPanel flpTimeSlots;
        private Label lblReasonTitle;
        private Label lblReasonIcon;
        private RichTextBox txtReason;
        private Label lblCharCount;
        private Panel pnlNotice;
        private Label lblNoticeText;
        private Label lblNoticeTitle;
        private PictureBox picNoticeIcon;
        private Button btnConfirm;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
