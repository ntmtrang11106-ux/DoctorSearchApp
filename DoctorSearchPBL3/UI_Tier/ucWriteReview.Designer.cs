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
            panelDoctor = new Panel();
            lblDept = new Label();
            lblDocName = new Label();
            picDoc = new PictureBox();
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
            panelHeader.SuspendLayout();
            panelDoctor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDoc).BeginInit();
            flpStars.SuspendLayout();
            panelTip.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 80);
            panelHeader.TabIndex = 0;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe MDL2 Assets", 12F);
            btnClose.Location = new Point(730, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 50);
            btnClose.TabIndex = 1;
            btnClose.Text = "";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(295, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đánh giá bác sĩ";
            // 
            // panelDoctor
            // 
            panelDoctor.BackColor = Color.FromArgb(248, 250, 252);
            panelDoctor.Controls.Add(lblDept);
            panelDoctor.Controls.Add(lblDocName);
            panelDoctor.Controls.Add(picDoc);
            panelDoctor.Location = new Point(40, 100);
            panelDoctor.Name = "panelDoctor";
            panelDoctor.Size = new Size(720, 140);
            panelDoctor.TabIndex = 1;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.ForeColor = Color.DodgerBlue;
            lblDept.Location = new Point(140, 80);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(116, 32);
            lblDept.TabIndex = 2;
            lblDept.Text = "Tim mạch";
            // 
            // lblDocName
            // 
            lblDocName.AutoSize = true;
            lblDocName.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblDocName.Location = new Point(140, 30);
            lblDocName.Name = "lblDocName";
            lblDocName.Size = new Size(286, 41);
            lblDocName.TabIndex = 1;
            lblDocName.Text = "BS. Nguyễn Văn An";
            // 
            // picDoc
            // 
            picDoc.Location = new Point(20, 20);
            picDoc.Name = "picDoc";
            picDoc.Size = new Size(100, 100);
            picDoc.SizeMode = PictureBoxSizeMode.Zoom;
            picDoc.TabIndex = 0;
            picDoc.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label1.Location = new Point(40, 260);
            label1.Name = "label1";
            label1.Size = new Size(215, 37);
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
            lblRatingText.Font = new Font("Segoe UI", 9F);
            lblRatingText.ForeColor = Color.Gray;
            lblRatingText.Location = new Point(40, 395);
            lblRatingText.Name = "lblRatingText";
            lblRatingText.Size = new Size(720, 32);
            lblRatingText.TabIndex = 4;
            lblRatingText.Text = "Vui lòng chọn mức độ hài lòng";
            lblRatingText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label2.Location = new Point(40, 440);
            label2.Name = "label2";
            label2.Size = new Size(297, 37);
            label2.TabIndex = 5;
            label2.Text = "Nhận xét (không bắt buộc)";
            // 
            // txtComment
            // 
            txtComment.BorderStyle = BorderStyle.None;
            txtComment.Font = new Font("Segoe UI", 10F);
            txtComment.ForeColor = Color.Gray;
            txtComment.Location = new Point(40, 490);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(720, 250);
            txtComment.TabIndex = 6;
            txtComment.Text = "Chia sẻ trải nghiệm của bạn về bác sĩ...";
            txtComment.TextChanged += txtComment_TextChanged;
            txtComment.Enter += txtComment_Enter;
            txtComment.Leave += txtComment_Leave;
            // 
            // lblCharCount
            // 
            lblCharCount.AutoSize = true;
            lblCharCount.ForeColor = Color.Gray;
            lblCharCount.Location = new Point(40, 750);
            lblCharCount.Name = "lblCharCount";
            lblCharCount.Size = new Size(141, 32);
            lblCharCount.TabIndex = 7;
            lblCharCount.Text = "0/1000 ký tự";
            // 
            // panelTip
            // 
            panelTip.BackColor = Color.FromArgb(239, 246, 255);
            panelTip.Controls.Add(lblTip);
            panelTip.Location = new Point(40, 800);
            panelTip.Name = "panelTip";
            panelTip.Size = new Size(720, 120);
            panelTip.TabIndex = 8;
            // 
            // lblTip
            // 
            lblTip.Dock = DockStyle.Fill;
            lblTip.Font = new Font("Segoe UI", 9F);
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
            btnSubmit.Font = new Font("Segoe UI Bold", 11F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(40, 980);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(540, 60);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Gửi đánh giá";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(241, 245, 249);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Bold", 11F, FontStyle.Bold);
            btnCancel.Location = new Point(620, 980);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 60);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ucWriteReview
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(panelTip);
            Controls.Add(lblCharCount);
            Controls.Add(txtComment);
            Controls.Add(label2);
            Controls.Add(lblRatingText);
            Controls.Add(flpStars);
            Controls.Add(label1);
            Controls.Add(panelDoctor);
            Controls.Add(panelHeader);
            Name = "ucWriteReview";
            Size = new Size(800, 1100);
            Load += ucWriteReview_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelDoctor.ResumeLayout(false);
            panelDoctor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDoc).EndInit();
            flpStars.ResumeLayout(false);
            panelTip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelHeader;
        private Label lblTitle;
        private Button btnClose;
        private Panel panelDoctor;
        private PictureBox picDoc;
        private Label lblDocName;
        private Label lblDept;
        private Label label1;
        private FlowLayoutPanel flpStars;
        private Label lblStar1;
        private Label lblStar2;
        private Label lblStar3;
        private Label lblStar4;
        private Label lblStar5;
        private Label lblRatingText;
        private Label label2;
        private RichTextBox txtComment;
        private Label lblCharCount;
        private Panel panelTip;
        private Label lblTip;
        private Button btnSubmit;
        private Button btnCancel;
    }
}
