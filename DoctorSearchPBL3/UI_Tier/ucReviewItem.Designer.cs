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
            lblStatus = new Label();
            lblAvatar = new Label();
            lblName = new Label();
            lblRating = new Label();
            lblDate = new Label();
            lblComment = new Label();
            lblYourReview = new Label();
            lblArrow = new Label();
            lblDoctorName = new Label();
            flpAction = new FlowLayoutPanel();
            btnRemove = new Button();
            btnHide = new Button();
            btnEdit = new Button();
            flpAction.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.FromArgb(243, 244, 246);
            lblStatus.Font = new Font("Segoe UI Semibold", 14F);
            lblStatus.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatus.Location = new Point(900, 75);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(10, 4, 10, 4);
            lblStatus.Size = new Size(274, 59);
            lblStatus.TabIndex = 32;
            lblStatus.Text = "Đang hiển thị";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Visible = false;
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(240, 240, 240);
            lblAvatar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            lblName.Location = new Point(100, 15);
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
            lblRating.Location = new Point(100, 65);
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
            lblDate.Location = new Point(261, 65);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(180, 45);
            lblDate.TabIndex = 3;
            lblDate.Text = "20/03/2026";
            // 
            // lblComment
            // 
            lblComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblComment.Font = new Font("Segoe UI", 12F);
            lblComment.ForeColor = Color.FromArgb(40, 40, 40);
            lblComment.Location = new Point(100, 124);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(1188, 90);
            lblComment.TabIndex = 4;
            lblComment.Text = "Bác sĩ rất tận tâm và chuyên nghiệp.";
            // 
            // lblYourReview
            // 
            lblYourReview.AutoSize = true;
            lblYourReview.BackColor = Color.FromArgb(235, 245, 255);
            lblYourReview.Font = new Font("Segoe UI Semibold", 10F);
            lblYourReview.ForeColor = Color.FromArgb(37, 99, 235);
            lblYourReview.Location = new Point(423, 20);
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
            lblArrow.Location = new Point(451, 20);
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
            lblDoctorName.Location = new Point(526, 15);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(262, 50);
            lblDoctorName.TabIndex = 24;
            lblDoctorName.Text = "BS. Trần Thị B";
            lblDoctorName.Visible = false;
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
            flpAction.Location = new Point(973, 20);
            flpAction.Name = "flpAction";
            flpAction.Size = new Size(315, 90);
            flpAction.TabIndex = 31;
            flpAction.WrapContents = false;
            // 
            // btnRemove
            // 
            btnRemove.AccessibleDescription = "Xóa đánh giá";
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.BackColor = Color.FromArgb(255, 252, 235);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 20F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(230, 5);
            btnRemove.Margin = new Padding(20, 5, 0, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(85, 85);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // btnHide
            // 
            btnHide.AccessibleDescription = "Ẩn đánh giá";
            btnHide.Anchor = AnchorStyles.None;
            btnHide.BackColor = Color.FromArgb(243, 244, 246);
            btnHide.FlatAppearance.BorderSize = 0;
            btnHide.FlatStyle = FlatStyle.Flat;
            btnHide.Font = new Font("Segoe MDL2 Assets", 20F);
            btnHide.ForeColor = Color.FromArgb(107, 114, 128);
            btnHide.Location = new Point(125, 5);
            btnHide.Margin = new Padding(20, 5, 0, 0);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(85, 85);
            btnHide.TabIndex = 15;
            btnHide.Text = "";
            btnHide.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.AccessibleDescription = "Chỉnh sửa";
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.FromArgb(239, 246, 255);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 20F);
            btnEdit.ForeColor = Color.FromArgb(37, 99, 235);
            btnEdit.Location = new Point(20, 5);
            btnEdit.Margin = new Padding(20, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // ucReviewItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblStatus);
            Controls.Add(flpAction);
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
            flpAction.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblYourReview;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHide;
        private FlowLayoutPanel flpAction;
        private Button button1;
        private Button button2;
    }
}
