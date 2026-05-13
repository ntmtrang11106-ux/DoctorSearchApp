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
            lblArrow = new Label();
            lblDoctorName = new Label();
            btnRemove = new Label();
            btnEdit = new Label();
            btnHide = new Label();
            SuspendLayout();
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(240, 240, 240);
            lblAvatar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.FromArgb(100, 100, 100);
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
            lblName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold);
            lblName.Location = new Point(100, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(294, 50);
            lblName.TabIndex = 1;
            lblName.Text = "Nguyễn Thị Lan";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 11F);
            lblRating.ForeColor = Color.Orange;
            lblRating.Location = new Point(100, 70);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(143, 41);
            lblRating.TabIndex = 2;
            lblRating.Text = "★★★★★";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 11F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(250, 70);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(170, 41);
            lblDate.TabIndex = 3;
            lblDate.Text = "20/03/2026";
            // 
            // lblComment
            // 
            lblComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblComment.Font = new Font("Segoe UI", 12F);
            lblComment.ForeColor = Color.FromArgb(40, 40, 40);
            lblComment.Location = new Point(100, 115);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(1188, 70);
            lblComment.TabIndex = 4;
            lblComment.Text = "Bác sĩ rất tận tâm và chuyên nghiệp.";
            // 
            // lblYourReview
            // 
            lblYourReview.AutoSize = true;
            lblYourReview.BackColor = Color.FromArgb(235, 245, 255);
            lblYourReview.Font = new Font("Segoe UI Semibold", 10F);
            lblYourReview.ForeColor = Color.FromArgb(37, 99, 235);
            lblYourReview.Location = new Point(479, 20);
            lblYourReview.Name = "lblYourReview";
            lblYourReview.Padding = new Padding(8, 4, 8, 4);
            lblYourReview.Size = new Size(245, 45);
            lblYourReview.TabIndex = 6;
            lblYourReview.Text = "Đánh giá của bạn";
            lblYourReview.Visible = false;
            // 
            // lblArrow
            // 
            lblArrow.AutoSize = true;
            lblArrow.BackColor = Color.Transparent;
            lblArrow.Font = new Font("Segoe UI", 12F);
            lblArrow.ForeColor = Color.Silver;
            lblArrow.Location = new Point(452, 24);
            lblArrow.Name = "lblArrow";
            lblArrow.Size = new Size(48, 45);
            lblArrow.TabIndex = 23;
            lblArrow.Text = "→";
            lblArrow.Visible = false;
            // 
            // lblDoctorName
            // 
            lblDoctorName.AutoSize = true;
            lblDoctorName.BackColor = Color.Transparent;
            lblDoctorName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold);
            lblDoctorName.ForeColor = Color.FromArgb(37, 99, 235);
            lblDoctorName.Location = new Point(526, 20);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(262, 50);
            lblDoctorName.TabIndex = 24;
            lblDoctorName.Text = "BS. Trần Thị B";
            lblDoctorName.Visible = false;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.BackColor = Color.FromArgb(255, 248, 241);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 18F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(1225, 20);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(70, 70);
            btnRemove.TabIndex = 28;
            btnRemove.Text = "";
            btnRemove.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.FromArgb(240, 249, 255);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 18F);
            btnEdit.ForeColor = Color.FromArgb(37, 99, 235);
            btnEdit.Location = new Point(1065, 20);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(70, 70);
            btnEdit.TabIndex = 29;
            btnEdit.Text = "";
            btnEdit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHide
            // 
            btnHide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHide.BackColor = Color.FromArgb(249, 250, 251);
            btnHide.Cursor = Cursors.Hand;
            btnHide.Font = new Font("Segoe MDL2 Assets", 18F);
            btnHide.ForeColor = Color.FromArgb(107, 114, 128);
            btnHide.Location = new Point(1145, 20);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(70, 70);
            btnHide.TabIndex = 30;
            btnHide.Text = "";
            btnHide.TextAlign = ContentAlignment.MiddleCenter;
            btnHide.Visible = false;
            // 
            // ucReviewItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnHide);
            Controls.Add(btnEdit);
            Controls.Add(btnRemove);
            Controls.Add(lblDoctorName);
            Controls.Add(lblArrow);
            Controls.Add(lblYourReview);
            Controls.Add(lblComment);
            Controls.Add(lblDate);
            Controls.Add(lblRating);
            Controls.Add(lblName);
            Controls.Add(lblAvatar);
            Name = "ucReviewItem";
            Size = new Size(1308, 220);
            Load += ucReviewItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblYourReview;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label btnRemove;
        private System.Windows.Forms.Label btnEdit;
        private System.Windows.Forms.Label btnHide;
    }
}
