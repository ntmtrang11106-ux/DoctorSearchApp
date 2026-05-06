namespace UI_Tier
{
    partial class ucAppointmentRow
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
            lblTime = new Label();
            lblTimeTitle = new Label();
            lblPatientName = new Label();
            lblReason = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(17, 34, 71);
            lblTime.Location = new Point(30, 70);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(116, 50);
            lblTime.TabIndex = 0;
            lblTime.Text = "09:00";
            // 
            // lblTimeTitle
            // 
            lblTimeTitle.AutoSize = true;
            lblTimeTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimeTitle.ForeColor = Color.Gray;
            lblTimeTitle.Location = new Point(30, 20);
            lblTimeTitle.Name = "lblTimeTitle";
            lblTimeTitle.Size = new Size(69, 45);
            lblTimeTitle.TabIndex = 1;
            lblTimeTitle.Text = "Giờ";
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPatientName.ForeColor = Color.FromArgb(17, 34, 71);
            lblPatientName.Location = new Point(334, 20);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(269, 50);
            lblPatientName.TabIndex = 2;
            lblPatientName.Text = "Nguyễn Văn A";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReason.ForeColor = Color.Gray;
            lblReason.Location = new Point(334, 75);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(250, 45);
            lblReason.TabIndex = 3;
            lblReason.Text = "Khám tổng quát";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.BackColor = Color.FromArgb(235, 252, 245);
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(40, 199, 111);
            lblStatus.Location = new Point(1073, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(220, 50);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Đã xác nhận";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucAppointmentRow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblStatus);
            Controls.Add(lblReason);
            Controls.Add(lblPatientName);
            Controls.Add(lblTimeTitle);
            Controls.Add(lblTime);
            Name = "ucAppointmentRow";
            Size = new Size(1309, 150);
            Load += ucAppointmentRow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTime;
        private Label lblTimeTitle;
        private Label lblPatientName;
        private Label lblReason;
        private Label lblStatus;
    }
}
