namespace UI_Tier
{
    partial class ucReviewItem
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
            lblAvatar = new Label();
            lblName = new Label();
            lblRating = new Label();
            lblDate = new Label();
            lblComment = new Label();
            panelLine = new Panel();
            SuspendLayout();
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.LightGray;
            lblAvatar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.DimGray;
            lblAvatar.Location = new Point(20, 20);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(60, 60);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "N";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.Location = new Point(100, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(230, 37);
            lblName.TabIndex = 1;
            lblName.Text = "Nguyễn Thị Lan";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 10F);
            lblRating.ForeColor = Color.Orange;
            lblRating.Location = new Point(100, 60);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(118, 37);
            lblRating.TabIndex = 2;
            lblRating.Text = "★★★★★";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(230, 63);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(135, 32);
            lblDate.TabIndex = 3;
            lblDate.Text = "2026-03-20";
            // 
            // lblComment
            // 
            lblComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblComment.Font = new Font("Segoe UI", 10F);
            lblComment.Location = new Point(100, 110);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(850, 80);
            lblComment.TabIndex = 4;
            lblComment.Text = "Bác sĩ rất tận tâm và chuyên nghiệp. Giải thích rõ ràng về tình trạng bệnh.";
            // 
            // panelLine
            // 
            panelLine.BackColor = Color.FromArgb(240, 240, 240);
            panelLine.Dock = DockStyle.Bottom;
            panelLine.Location = new Point(0, 208);
            panelLine.Name = "panelLine";
            panelLine.Size = new Size(1000, 2);
            panelLine.TabIndex = 5;
            // 
            // ucReviewItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelLine);
            Controls.Add(lblComment);
            Controls.Add(lblDate);
            Controls.Add(lblRating);
            Controls.Add(lblName);
            Controls.Add(lblAvatar);
            Name = "ucReviewItem";
            Size = new Size(1000, 210);
            Load += ucReviewItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblAvatar;
        private Label lblName;
        private Label lblRating;
        private Label lblDate;
        private Label lblComment;
        private Panel panelLine;
    }
}
