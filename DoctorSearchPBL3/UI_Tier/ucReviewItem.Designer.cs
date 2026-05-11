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
            lblYourReview = new Label();
            lblEdit = new Label();
            lblDelete = new Label();
            SuspendLayout();
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.LightGray;
            lblAvatar.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            lblName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(100, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(294, 50);
            lblName.TabIndex = 1;
            lblName.Text = "Nguyễn Thị Lan";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRating.ForeColor = Color.Orange;
            lblRating.Location = new Point(100, 70);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(155, 45);
            lblRating.TabIndex = 2;
            lblRating.Text = "★★★★★";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(282, 70);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(182, 45);
            lblDate.TabIndex = 3;
            lblDate.Text = "2026-03-20";
            // 
            // lblComment
            // 
            lblComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblComment.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblComment.ForeColor = Color.FromArgb(64, 64, 64);
            lblComment.Location = new Point(100, 125);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(982, 90);
            lblComment.TabIndex = 4;
            lblComment.Text = "Bác sĩ rất tận tâm và chuyên nghiệp. Giải thích rõ ràng về tình trạng bệnh.";
            // 
            // lblYourReview
            // 
            lblYourReview.AutoSize = true;
            lblYourReview.BackColor = Color.FromArgb(220, 235, 255);
            lblYourReview.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYourReview.ForeColor = Color.FromArgb(20, 100, 255);
            lblYourReview.Location = new Point(410, 25);
            lblYourReview.Name = "lblYourReview";
            lblYourReview.Padding = new Padding(8, 4, 8, 4);
            lblYourReview.Size = new Size(245, 45);
            lblYourReview.TabIndex = 6;
            lblYourReview.Text = "Đánh giá của bạn";
            lblYourReview.Visible = false;
            // 
            // lblEdit
            // 
            lblEdit.BackColor = Color.FromArgb(239, 250, 255);
            lblEdit.Cursor = Cursors.Hand;
            lblEdit.Font = new Font("Segoe MDL2 Assets", 20F);
            lblEdit.ForeColor = Color.FromArgb(37, 99, 235);
            lblEdit.Location = new Point(1098, 20);
            lblEdit.Name = "lblEdit";
            lblEdit.Size = new Size(85, 85);
            lblEdit.TabIndex = 21;
            lblEdit.Text = "";
            lblEdit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDelete
            // 
            lblDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDelete.BackColor = Color.FromArgb(255, 252, 235);
            lblDelete.Cursor = Cursors.Hand;
            lblDelete.Font = new Font("Segoe MDL2 Assets", 20F);
            lblDelete.ForeColor = Color.FromArgb(217, 119, 6);
            lblDelete.Location = new Point(1204, 20);
            lblDelete.Name = "lblDelete";
            lblDelete.Size = new Size(85, 85);
            lblDelete.TabIndex = 22;
            lblDelete.Text = "";
            lblDelete.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucReviewItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblDelete);
            Controls.Add(lblEdit);
            Controls.Add(lblYourReview);
            Controls.Add(panelLine);
            Controls.Add(lblComment);
            Controls.Add(lblDate);
            Controls.Add(lblRating);
            Controls.Add(lblName);
            Controls.Add(lblAvatar);
            Name = "ucReviewItem";
            Size = new Size(1326, 237);
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
        private Label lblYourReview;
        private Label lblDelete;
        private Label lblEdit;
    }
}
