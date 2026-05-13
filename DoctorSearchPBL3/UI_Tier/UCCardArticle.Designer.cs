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
            lblSpecialities = new Label();
            label4 = new Label();
            lblAuthor = new Label();
            label3 = new Label();
            lblStatus = new Label();
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
            picThumbnail.BackColor = Color.FromArgb(248, 249, 250);
            picThumbnail.Location = new Point(1, 3);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(592, 506);
            picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            picThumbnail.TabIndex = 0;
            picThumbnail.TabStop = false;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.ForeColor = Color.DimGray;
            lblDate.Location = new Point(619, 408);
            lblDate.Margin = new Padding(0, 5, 0, 5);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(303, 37);
            lblDate.TabIndex = 4;
            lblDate.Text = "Ngày đăng: 22/10/2025";
            // 
            // lblViews
            // 
            lblViews.AutoSize = true;
            lblViews.Font = new Font("Segoe UI", 10F);
            lblViews.ForeColor = Color.DimGray;
            lblViews.Location = new Point(1178, 454);
            lblViews.Margin = new Padding(0, 5, 0, 5);
            lblViews.Name = "lblViews";
            lblViews.Size = new Size(92, 37);
            lblViews.TabIndex = 3;
            lblViews.Text = "56920";
            // 
            // lblSummary
            // 
            lblSummary.Font = new Font("Segoe UI", 11F);
            lblSummary.ForeColor = Color.Black;
            lblSummary.Location = new Point(619, 271);
            lblSummary.Margin = new Padding(0, 5, 0, 5);
            lblSummary.MaximumSize = new Size(666, 0);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(662, 127);
            lblSummary.TabIndex = 2;
            lblSummary.Text = "Mọi người nghĩ là không thể đúng không? Đúng là không thể thật :rolf:\r\nNhưng không hẳn là không có nha, mình nghĩ là ngủ bù đủ là được\r\n";
            // 
            // lblTitle
            // 
            lblTitle.FlatStyle = FlatStyle.Flat;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.Location = new Point(617, 31);
            lblTitle.Margin = new Padding(0, 5, 0, 5);
            lblTitle.MaximumSize = new Size(666, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(664, 162);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Cách để ngủ 3 tiếng mỗi ngày vẫn tỉnh táo, tuyệt ghê ha, nhưng mà ai bt đc";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
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
            pnlContainer.Size = new Size(1298, 507);
            pnlContainer.TabIndex = 21;
            // 
            // lblSpecialities
            // 
            lblSpecialities.Font = new Font("Segoe UI", 10F);
            lblSpecialities.ForeColor = Color.DimGray;
            lblSpecialities.Location = new Point(629, 203);
            lblSpecialities.Margin = new Padding(0, 5, 0, 5);
            lblSpecialities.Name = "lblSpecialities";
            lblSpecialities.Size = new Size(400, 58);
            lblSpecialities.TabIndex = 25;
            lblSpecialities.Text = "Chuyên khoa";
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe MDL2 Assets", 15F);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(1121, 454);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(65, 64);
            label4.TabIndex = 24;
            label4.Text = "";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 10F);
            lblAuthor.ForeColor = Color.DimGray;
            lblAuthor.Location = new Point(619, 455);
            lblAuthor.Margin = new Padding(0, 5, 0, 5);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(245, 37);
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
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(1050, 203);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(8, 4, 8, 4);
            lblStatus.Size = new Size(130, 40);
            lblStatus.TabIndex = 26;
            lblStatus.Text = "Trạng thái";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UCCardArticle
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Margin = new Padding(4);
            Name = "UCCardArticle";
            Padding = new Padding(13);
            Size = new Size(1324, 533);
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
