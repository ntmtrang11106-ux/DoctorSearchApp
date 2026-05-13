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
            lblViews = new Label();
            labelEyeIcon = new Label();
            lblDate = new Label();
            lblAuthor = new Label();
            btnBack = new Button();
            lblTitle = new Label();
            lblSpecialities = new Label();
            picThumbnail = new PictureBox();
            txtBody = new RichTextBox();
            flpAction = new FlowLayoutPanel();
            btnRemove = new Button();
            btnHide = new Button();
            btnEdit = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            flpAction.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(flpAction);
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
            pnlHeader.Size = new Size(1054, 260);
            pnlHeader.TabIndex = 0;
            // 
            // lblViews
            // 
            lblViews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblViews.AutoSize = true;
            lblViews.Font = new Font("Segoe UI", 11F);
            lblViews.ForeColor = Color.Gray;
            lblViews.Location = new Point(959, 205);
            lblViews.Name = "lblViews";
            lblViews.Size = new Size(82, 41);
            lblViews.TabIndex = 0;
            lblViews.Text = "5600";
            // 
            // labelEyeIcon
            // 
            labelEyeIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEyeIcon.AutoSize = true;
            labelEyeIcon.Font = new Font("Segoe MDL2 Assets", 15F);
            labelEyeIcon.ForeColor = Color.Gray;
            labelEyeIcon.Location = new Point(912, 208);
            labelEyeIcon.Name = "labelEyeIcon";
            labelEyeIcon.Size = new Size(57, 40);
            labelEyeIcon.TabIndex = 1;
            labelEyeIcon.Text = "";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 11F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(678, 205);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(170, 41);
            lblDate.TabIndex = 2;
            lblDate.Text = "22/10/2025";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblAuthor.ForeColor = Color.Gray;
            lblAuthor.Location = new Point(75, 205);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(111, 41);
            lblAuthor.TabIndex = 3;
            lblAuthor.Text = "Tác giả";
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
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(70, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(964, 150);
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
            lblSpecialities.Size = new Size(214, 45);
            lblSpecialities.TabIndex = 4;
            lblSpecialities.Text = "Chuyên khoa";
            // 
            // picThumbnail
            // 
            picThumbnail.Dock = DockStyle.Top;
            picThumbnail.Location = new Point(50, 310);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(1054, 550);
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
            txtBody.Size = new Size(954, 500);
            txtBody.TabIndex = 2;
            txtBody.Text = "";
            // 
            // flpAction
            // 
            flpAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpAction.AutoSize = true;
            flpAction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAction.Controls.Add(btnRemove);
            flpAction.Controls.Add(btnHide);
            flpAction.Controls.Add(btnEdit);
            flpAction.FlowDirection = FlowDirection.RightToLeft;
            flpAction.Location = new Point(700, 85);
            flpAction.Name = "flpAction";
            flpAction.Size = new Size(350, 90);
            flpAction.TabIndex = 16;
            flpAction.WrapContents = false;
            // 
            // btnRemove
            // 
            btnRemove.AccessibleDescription = "Xóa bài viết";
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.BackColor = Color.FromArgb(255, 252, 235);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 20F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(235, 5);
            btnRemove.Margin = new Padding(20, 5, 0, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(85, 85);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // btnHide
            // 
            btnHide.AccessibleDescription = "Ẩn bài viết";
            btnHide.Anchor = AnchorStyles.None;
            btnHide.BackColor = Color.FromArgb(243, 244, 246);
            btnHide.FlatAppearance.BorderSize = 0;
            btnHide.FlatStyle = FlatStyle.Flat;
            btnHide.Font = new Font("Segoe MDL2 Assets", 20F);
            btnHide.ForeColor = Color.FromArgb(75, 85, 99);
            btnHide.Location = new Point(130, 5);
            btnHide.Margin = new Padding(20, 5, 0, 0);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(85, 85);
            btnHide.TabIndex = 21;
            btnHide.Text = "";
            btnHide.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.AccessibleDescription = "Chỉnh sửa bài viết";
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.FromArgb(239, 250, 255);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 20F);
            btnEdit.ForeColor = Color.FromArgb(37, 99, 235);
            btnEdit.Location = new Point(25, 5);
            btnEdit.Margin = new Padding(20, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "";
            btnEdit.UseVisualStyleBackColor = false;
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
            Size = new Size(1154, 900);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
            flpAction.ResumeLayout(false);
            ResumeLayout(false);
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
        private Button btnEdit;
        private Button btnHide;
        private Button btnRemove;
        private FlowLayoutPanel flpAction;
        private Button button1;
        private Button button2;
        private Label lblStatus;
    }
}