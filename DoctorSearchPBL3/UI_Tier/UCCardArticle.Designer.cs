namespace UI_Tier
{
    partial class UCCardArticle
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            picThumbnail = new PictureBox();
            lblDate = new Label();
            lblViews = new Label();
            lblSummary = new Label();
            lblTitle = new Label();
            pnlContainer = new Panel();
            lblStatus = new Label();
            lblSpecialities = new Label();
            label4 = new Label();
            lblAuthor = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 591);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 19;
            // 
            // picThumbnail
            // 
            picThumbnail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            picThumbnail.BackColor = Color.FromArgb(248, 249, 250);
            picThumbnail.Location = new Point(1, 3);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(592, 521);
            picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            picThumbnail.TabIndex = 0;
            picThumbnail.TabStop = false;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.DimGray;
            lblDate.Location = new Point(617, 412);
            lblDate.Margin = new Padding(0, 5, 0, 5);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(351, 45);
            lblDate.TabIndex = 4;
            lblDate.Text = "Ngày đăng: 22/10/2025";
            // 
            // lblViews
            // 
            lblViews.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblViews.AutoSize = true;
            lblViews.Font = new Font("Segoe UI", 11F);
            lblViews.ForeColor = Color.DimGray;
            lblViews.Location = new Point(1110, 468);
            lblViews.Margin = new Padding(0);
            lblViews.Name = "lblViews";
            lblViews.Size = new Size(100, 40);
            lblViews.TabIndex = 3;
            lblViews.Text = "56920";
            lblViews.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSummary.Font = new Font("Segoe UI", 11F);
            lblSummary.ForeColor = Color.Black;
            lblSummary.Location = new Point(617, 255);
            lblSummary.Margin = new Padding(0, 5, 0, 5);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(602, 127);
            lblSummary.TabIndex = 2;
            lblSummary.Text = "Mọi người nghĩ là không thể đúng không? Đúng là không thể thật :rolf:\r\nNhưng không hẳn là không có nha, mình nghĩ là ngủ bù đủ là được\r\n";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.FlatStyle = FlatStyle.Flat;
            lblTitle.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(617, 15);
            lblTitle.Margin = new Padding(0, 5, 0, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(604, 162);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Cách để ngủ 3 tiếng mỗi ngày vẫn tỉnh táo, tuyệt ghê ha, nhưng mà ai bt đc";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.Transparent;
            pnlContainer.Controls.Add(lblStatus);
            pnlContainer.Controls.Add(lblSpecialities);
            pnlContainer.Controls.Add(lblViews);
            pnlContainer.Controls.Add(label4);
            pnlContainer.Controls.Add(lblAuthor);
            pnlContainer.Controls.Add(label3);
            pnlContainer.Controls.Add(label1);
            pnlContainer.Controls.Add(picThumbnail);
            pnlContainer.Controls.Add(lblDate);
            pnlContainer.Controls.Add(lblSummary);
            pnlContainer.Controls.Add(lblTitle);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(13, 13);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(10);
            pnlContainer.Size = new Size(1238, 522);
            pnlContainer.TabIndex = 21;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(1027, 183);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(8, 4, 8, 4);
            lblStatus.Size = new Size(188, 53);
            lblStatus.TabIndex = 26;
            lblStatus.Text = "Trạng thái";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSpecialities
            // 
            lblSpecialities.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpecialities.ForeColor = Color.DimGray;
            lblSpecialities.Location = new Point(617, 187);
            lblSpecialities.Margin = new Padding(0, 5, 0, 5);
            lblSpecialities.Name = "lblSpecialities";
            lblSpecialities.Size = new Size(334, 58);
            lblSpecialities.TabIndex = 25;
            lblSpecialities.Text = "Chuyên khoa";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe MDL2 Assets", 14F);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(1065, 465);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(45, 45);
            label4.TabIndex = 24;
            label4.Text = "";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAuthor
            // 
            lblAuthor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.ForeColor = Color.DimGray;
            lblAuthor.Location = new Point(617, 467);
            lblAuthor.Margin = new Padding(0, 5, 0, 5);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(291, 45);
            lblAuthor.TabIndex = 23;
            lblAuthor.Text = "Tác giả: Mai Văn Cá";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(266, 584);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 32);
            label3.TabIndex = 22;
            // 
            // UCCardArticle
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Margin = new Padding(4);
            Name = "UCCardArticle";
            Padding = new Padding(13);
            Size = new Size(1264, 548);
            Load += UCCardArticle_Load;
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private PictureBox picThumbnail;
        private Label lblDate;
        private Label lblViews;
        private Label lblSummary;
        private Label lblTitle;
        private Panel pnlContainer;
        private Label lblAuthor;
        private Label label3;
        private Label label4;
        private Label lblSpecialities;
        private Label lblStatus;
    }
}
