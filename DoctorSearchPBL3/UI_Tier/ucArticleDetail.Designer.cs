namespace UI_Tier
{
    partial class ucArticleDetail
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
            btnBack = new Button();
            lblTitle = new Label();
            lblSpecialities = new Label();
            lblAuthor = new Label();
            lblDate = new Label();
            lblViews = new Label();
            labelEyeIcon = new Label();
            picThumbnail = new PictureBox();
            txtBody = new RichTextBox();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblViews);
            pnlHeader.Controls.Add(labelEyeIcon);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblAuthor);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSpecialities);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(50, 50);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1190, 260);
            pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe MDL2 Assets", 16F);
            btnBack.Location = new Point(0, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(60, 60);
            btnBack.TabIndex = 0;
            btnBack.Text = "";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(70, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1100, 150);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tiêu đề bài viết chi tiết";
            // 
            // lblSpecialities
            // 
            lblSpecialities.AutoSize = true;
            lblSpecialities.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSpecialities.ForeColor = Color.FromArgb(0, 123, 255);
            lblSpecialities.Location = new Point(75, 155);
            lblSpecialities.Name = "lblSpecialities";
            lblSpecialities.Size = new Size(192, 45);
            lblSpecialities.Text = "Chuyên khoa";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblAuthor.ForeColor = Color.Gray;
            lblAuthor.Location = new Point(75, 205);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(102, 40);
            lblAuthor.Text = "Tác giả";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 11F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(350, 205);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(164, 40);
            lblDate.Text = "22/10/2025";
            // 
            // labelEyeIcon
            // 
            labelEyeIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEyeIcon.AutoSize = true;
            labelEyeIcon.Font = new Font("Segoe MDL2 Assets", 12F);
            labelEyeIcon.ForeColor = Color.Gray;
            labelEyeIcon.Location = new Point(1050, 208);
            labelEyeIcon.Name = "labelEyeIcon";
            labelEyeIcon.Size = new Size(40, 32);
            labelEyeIcon.Text = "";
            // 
            // lblViews
            // 
            lblViews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblViews.AutoSize = true;
            lblViews.Font = new Font("Segoe UI", 11F);
            lblViews.ForeColor = Color.Gray;
            lblViews.Location = new Point(1095, 205);
            lblViews.Name = "lblViews";
            lblViews.Size = new Size(82, 40);
            lblViews.Text = "5600";
            // 
            // picThumbnail
            // 
            picThumbnail.Dock = DockStyle.Top;
            picThumbnail.Location = new Point(50, 310);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(1190, 550);
            picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            picThumbnail.TabIndex = 1;
            picThumbnail.TabStop = false;
            // 
            // txtBody
            // 
            txtBody.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBody.BackColor = Color.White;
            txtBody.BorderStyle = BorderStyle.None;
            txtBody.Font = new Font("Segoe UI", 14F);
            txtBody.ForeColor = Color.FromArgb(50, 50, 50);
            txtBody.Location = new Point(100, 880);
            txtBody.Name = "txtBody";
            txtBody.ReadOnly = true;
            txtBody.ScrollBars = RichTextBoxScrollBars.None;
            txtBody.Size = new Size(1090, 500);
            txtBody.TabIndex = 2;
            txtBody.Text = "";
            // 
            // ucArticleDetail
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(txtBody);
            Controls.Add(picThumbnail);
            Controls.Add(pnlHeader);
            Name = "ucArticleDetail";
            Padding = new Padding(50);
            Size = new Size(1290, 900);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Button btnBack;
        private Label lblTitle;
        private Label lblSpecialities;
        private Label lblAuthor;
        private Label lblDate;
        private Label lblViews;
        private Label labelEyeIcon;
        private PictureBox picThumbnail;
        private RichTextBox txtBody;
    }
}