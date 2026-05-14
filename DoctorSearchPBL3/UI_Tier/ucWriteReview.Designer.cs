namespace UI_Tier
{
    partial class ucWriteReview
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
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            label1 = new Label();
            flpStars = new FlowLayoutPanel();
            lblStar1 = new Label();
            lblStar2 = new Label();
            lblStar3 = new Label();
            lblStar4 = new Label();
            lblStar5 = new Label();
            lblRatingText = new Label();
            label2 = new Label();
            txtComment = new RichTextBox();
            lblCharCount = new Label();
            panelTip = new Panel();
            lblTip = new Label();
            btnSubmit = new Button();
            btnCancel = new Button();
            pnlDoctorInfo = new Panel();
            pictureBox1 = new PictureBox();
            lblDocDept = new Label();
            label3 = new Label();
            pnlMainBackground = new Panel();
            pnlCommentBorder = new Panel();
            panelHeader.SuspendLayout();
            flpStars.SuspendLayout();
            panelTip.SuspendLayout();
            pnlDoctorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlMainBackground.SuspendLayout();
            pnlCommentBorder.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(794, 72);
            panelHeader.TabIndex = 0;
            panelHeader.Click += Global_Click;
            panelHeader.MouseDown += panelHeader_MouseDown;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(726, 11);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 50);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(13, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(332, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đánh giá bác sĩ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(40, 265);
            label1.Name = "label1";
            label1.Size = new Size(282, 45);
            label1.TabIndex = 2;
            label1.Text = "Mức độ hài lòng *";
            // 
            // flpStars
            // 
            flpStars.Controls.Add(lblStar1);
            flpStars.Controls.Add(lblStar2);
            flpStars.Controls.Add(lblStar3);
            flpStars.Controls.Add(lblStar4);
            flpStars.Controls.Add(lblStar5);
            flpStars.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flpStars.Location = new Point(155, 310);
            flpStars.Name = "flpStars";
            flpStars.Size = new Size(490, 80);
            flpStars.TabIndex = 3;
            // 
            // lblStar1
            // 
            lblStar1.Cursor = Cursors.Hand;
            lblStar1.Font = new Font("Segoe UI", 28F);
            lblStar1.ForeColor = Color.LightGray;
            lblStar1.Location = new Point(3, 0);
            lblStar1.Name = "lblStar1";
            lblStar1.Size = new Size(90, 80);
            lblStar1.TabIndex = 0;
            lblStar1.Text = "★";
            lblStar1.TextAlign = ContentAlignment.MiddleCenter;
            lblStar1.Click += Star_Click;
            lblStar1.MouseEnter += Star_MouseEnter;
            lblStar1.MouseLeave += Star_MouseLeave;
            // 
            // lblStar2
            // 
            lblStar2.Cursor = Cursors.Hand;
            lblStar2.Font = new Font("Segoe UI", 28F);
            lblStar2.ForeColor = Color.LightGray;
            lblStar2.Location = new Point(99, 0);
            lblStar2.Name = "lblStar2";
            lblStar2.Size = new Size(90, 80);
            lblStar2.TabIndex = 1;
            lblStar2.Text = "★";
            lblStar2.TextAlign = ContentAlignment.MiddleCenter;
            lblStar2.Click += Star_Click;
            lblStar2.MouseEnter += Star_MouseEnter;
            lblStar2.MouseLeave += Star_MouseLeave;
            // 
            // lblStar3
            // 
            lblStar3.Cursor = Cursors.Hand;
            lblStar3.Font = new Font("Segoe UI", 28F);
            lblStar3.ForeColor = Color.LightGray;
            lblStar3.Location = new Point(195, 0);
            lblStar3.Name = "lblStar3";
            lblStar3.Size = new Size(90, 80);
            lblStar3.TabIndex = 2;
            lblStar3.Text = "★";
            lblStar3.TextAlign = ContentAlignment.MiddleCenter;
            lblStar3.Click += Star_Click;
            lblStar3.MouseEnter += Star_MouseEnter;
            lblStar3.MouseLeave += Star_MouseLeave;
            // 
            // lblStar4
            // 
            lblStar4.Cursor = Cursors.Hand;
            lblStar4.Font = new Font("Segoe UI", 28F);
            lblStar4.ForeColor = Color.LightGray;
            lblStar4.Location = new Point(291, 0);
            lblStar4.Name = "lblStar4";
            lblStar4.Size = new Size(90, 80);
            lblStar4.TabIndex = 3;
            lblStar4.Text = "★";
            lblStar4.TextAlign = ContentAlignment.MiddleCenter;
            lblStar4.Click += Star_Click;
            lblStar4.MouseEnter += Star_MouseEnter;
            lblStar4.MouseLeave += Star_MouseLeave;
            // 
            // lblStar5
            // 
            lblStar5.Cursor = Cursors.Hand;
            lblStar5.Font = new Font("Segoe UI", 28F);
            lblStar5.ForeColor = Color.LightGray;
            lblStar5.Location = new Point(387, 0);
            lblStar5.Name = "lblStar5";
            lblStar5.Size = new Size(90, 80);
            lblStar5.TabIndex = 4;
            lblStar5.Text = "★";
            lblStar5.TextAlign = ContentAlignment.MiddleCenter;
            lblStar5.Click += Star_Click;
            lblStar5.MouseEnter += Star_MouseEnter;
            lblStar5.MouseLeave += Star_MouseLeave;
            // 
            // lblRatingText
            // 
            lblRatingText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRatingText.ForeColor = Color.Gray;
            lblRatingText.Location = new Point(40, 402);
            lblRatingText.Name = "lblRatingText";
            lblRatingText.Size = new Size(720, 45);
            lblRatingText.TabIndex = 4;
            lblRatingText.Text = "Vui lòng chọn mức độ hài lòng";
            lblRatingText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(40, 457);
            label2.Name = "label2";
            label2.Size = new Size(416, 45);
            label2.TabIndex = 5;
            label2.Text = "Nhận xét (không bắt buộc)";
            // 
            // txtComment
            // 
            txtComment.BorderStyle = BorderStyle.None;
            txtComment.Dock = DockStyle.Fill;
            txtComment.Font = new Font("Segoe UI", 10F);
            txtComment.ForeColor = Color.Gray;
            txtComment.Location = new Point(10, 10);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(700, 230);
            txtComment.TabIndex = 0;
            txtComment.Text = "Chia sẻ trải nghiệm của bạn về bác sĩ...";
            txtComment.TextChanged += txtComment_TextChanged;
            txtComment.Enter += txtComment_Enter;
            txtComment.Leave += txtComment_Leave;
            // 
            // lblCharCount
            // 
            lblCharCount.AutoSize = true;
            lblCharCount.ForeColor = Color.Gray;
            lblCharCount.Location = new Point(40, 765);
            lblCharCount.Name = "lblCharCount";
            lblCharCount.Size = new Size(148, 32);
            lblCharCount.TabIndex = 7;
            lblCharCount.Text = "0/1000 ký tự";
            // 
            // panelTip
            // 
            panelTip.BackColor = Color.FromArgb(239, 246, 255);
            panelTip.Controls.Add(lblTip);
            panelTip.Location = new Point(40, 815);
            panelTip.Name = "panelTip";
            panelTip.Size = new Size(720, 120);
            panelTip.TabIndex = 8;
            // 
            // lblTip
            // 
            lblTip.Dock = DockStyle.Fill;
            lblTip.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTip.ForeColor = Color.FromArgb(30, 58, 138);
            lblTip.Location = new Point(0, 0);
            lblTip.Name = "lblTip";
            lblTip.Padding = new Padding(15);
            lblTip.Size = new Size(720, 120);
            lblTip.TabIndex = 0;
            lblTip.Text = "💡 Lưu ý: Đánh giá của bạn sẽ giúp các bệnh nhân khác có thêm thông tin khi lựa chọn bác sĩ. Vui lòng đánh giá khách quan và trung thực.";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(37, 99, 235);
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Microsoft Sans Serif", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(40, 995);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(496, 60);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Gửi đánh giá";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(241, 245, 249);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(560, 995);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 60);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlDoctorInfo
            // 
            pnlDoctorInfo.BackColor = Color.FromArgb(243, 248, 255);
            pnlDoctorInfo.Controls.Add(pictureBox1);
            pnlDoctorInfo.Controls.Add(lblDocDept);
            pnlDoctorInfo.Controls.Add(label3);
            pnlDoctorInfo.Location = new Point(13, 74);
            pnlDoctorInfo.Name = "pnlDoctorInfo";
            pnlDoctorInfo.Size = new Size(778, 183);
            pnlDoctorInfo.TabIndex = 16;
            pnlDoctorInfo.Click += Global_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(27, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblDocDept
            // 
            lblDocDept.AutoSize = true;
            lblDocDept.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDocDept.ForeColor = Color.FromArgb(37, 99, 235);
            lblDocDept.Location = new Point(212, 85);
            lblDocDept.Name = "lblDocDept";
            lblDocDept.Size = new Size(162, 45);
            lblDocDept.TabIndex = 2;
            lblDocDept.Text = "Tim mạch";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(31, 41, 55);
            label3.Location = new Point(212, 25);
            label3.Name = "label3";
            label3.Size = new Size(368, 42);
            label3.TabIndex = 1;
            label3.Text = "BS. Nguyễn Văn An";
            // 
            // pnlMainBackground
            // 
            pnlMainBackground.BackColor = Color.White;
            pnlMainBackground.Controls.Add(pnlDoctorInfo);
            pnlMainBackground.Controls.Add(btnCancel);
            pnlMainBackground.Controls.Add(btnSubmit);
            pnlMainBackground.Controls.Add(panelTip);
            pnlMainBackground.Controls.Add(lblCharCount);
            pnlMainBackground.Controls.Add(pnlCommentBorder);
            pnlMainBackground.Controls.Add(label2);
            pnlMainBackground.Controls.Add(lblRatingText);
            pnlMainBackground.Controls.Add(flpStars);
            pnlMainBackground.Controls.Add(label1);
            pnlMainBackground.Controls.Add(panelHeader);
            pnlMainBackground.Dock = DockStyle.Fill;
            pnlMainBackground.Location = new Point(3, 3);
            pnlMainBackground.Name = "pnlMainBackground";
            pnlMainBackground.Size = new Size(794, 1094);
            pnlMainBackground.TabIndex = 17;
            pnlMainBackground.Click += Global_Click;
            // 
            // pnlCommentBorder
            // 
            pnlCommentBorder.BackColor = Color.White;
            pnlCommentBorder.Controls.Add(txtComment);
            pnlCommentBorder.Location = new Point(40, 505);
            pnlCommentBorder.Name = "pnlCommentBorder";
            pnlCommentBorder.Padding = new Padding(10);
            pnlCommentBorder.Size = new Size(720, 250);
            pnlCommentBorder.TabIndex = 6;
            // 
            // ucWriteReview
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(pnlMainBackground);
            Name = "ucWriteReview";
            Padding = new Padding(3);
            Size = new Size(800, 1100);
            Load += ucWriteReview_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            flpStars.ResumeLayout(false);
            panelTip.ResumeLayout(false);
            pnlDoctorInfo.ResumeLayout(false);
            pnlDoctorInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlMainBackground.ResumeLayout(false);
            pnlMainBackground.PerformLayout();
            pnlCommentBorder.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle;
        private Button btnClose;
        private Label label1;
        private FlowLayoutPanel flpStars;
        private Label lblStar1;
        private Label lblStar2;
        private Label lblStar3;
        private Label lblStar4;
        private Label lblStar5;
        private Label lblRatingText;
        private Label label2;
        private Label lblCharCount;
        private Panel panelTip;
        private Label lblTip;
        private Button btnSubmit;
        private Button btnCancel;
        private Panel pnlDoctorInfo;
        private Label lblDocDept;
        private Label label3;
        private PictureBox pictureBox1;
        public RichTextBox txtComment;
        private Panel pnlMainBackground;
        private Panel pnlCommentBorder;
    }
}
