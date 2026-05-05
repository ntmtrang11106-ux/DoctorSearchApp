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
            lblYourReview = new Label();
            btnEdit = new Button();
            btnDelete = new Button();
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
            lblComment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblComment.Location = new Point(100, 128);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(900, 100);
            lblComment.TabIndex = 4;
            lblComment.Text = "Bác sĩ rất tận tâm và chuyên nghiệp. Giải thích rõ ràng về tình trạng bệnh.";
            // 
            // panelLine
            // 
            panelLine.BackColor = Color.FromArgb(200, 200, 200);
            panelLine.Dock = DockStyle.Bottom;
            panelLine.Location = new Point(0, 251);
            panelLine.Name = "panelLine";
            panelLine.Size = new Size(1195, 2);
            panelLine.TabIndex = 5;
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
            // btnEdit
            // 
            btnEdit.AccessibleDescription = "C";
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.FromArgb(239, 250, 255);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 20F);
            btnEdit.ForeColor = Color.FromArgb(37, 99, 235);
            btnEdit.Location = new Point(974, 25);
            btnEdit.Margin = new Padding(30, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 21;
            btnEdit.Text = "";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.AccessibleDescription = "C";
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.FromArgb(255, 252, 235);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe MDL2 Assets", 20F);
            btnDelete.ForeColor = Color.FromArgb(217, 119, 6);
            btnDelete.Location = new Point(1089, 25);
            btnDelete.Margin = new Padding(30, 5, 0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 85);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // ucReviewItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(lblYourReview);
            Controls.Add(panelLine);
            Controls.Add(lblComment);
            Controls.Add(lblDate);
            Controls.Add(lblRating);
            Controls.Add(lblName);
            Controls.Add(lblAvatar);
            Name = "ucReviewItem";
            Size = new Size(1195, 253);
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
        private Button btnDelete;
        private Button btnEdit;
    }
}
