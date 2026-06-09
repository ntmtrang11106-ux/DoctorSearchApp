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
            lblPatientPhone = new Label();
            lblReason = new Label();
            pnlReason = new Panel();
            lblStatus = new Label();
            label2 = new Label();
            pnlReason.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(17, 34, 71);
            lblTime.Location = new Point(30, 81);
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
            lblTimeTitle.Location = new Point(30, 41);
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
            lblPatientName.Location = new Point(279, 42);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(269, 50);
            lblPatientName.TabIndex = 2;
            lblPatientName.Text = "Nguyễn Văn A";
            // 
            // lblPatientPhone
            // 
            lblPatientPhone.AutoSize = true;
            lblPatientPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPatientPhone.ForeColor = Color.Gray;
            lblPatientPhone.Location = new Point(279, 97);
            lblPatientPhone.Name = "lblPatientPhone";
            lblPatientPhone.Size = new Size(190, 45);
            lblPatientPhone.TabIndex = 5;
            lblPatientPhone.Text = "0000000000";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReason.ForeColor = Color.DimGray;
            lblReason.Location = new Point(0, 0);
            lblReason.MaximumSize = new Size(350, 0);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(250, 45);
            lblReason.TabIndex = 3;
            lblReason.Text = "Khám tổng quát";
            // 
            // pnlReason
            // 
            pnlReason.AutoScroll = true;
            pnlReason.Controls.Add(lblReason);
            pnlReason.Location = new Point(699, 30);
            pnlReason.Name = "pnlReason";
            pnlReason.Size = new Size(397, 115);
            pnlReason.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.BackColor = Color.FromArgb(235, 252, 245);
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(40, 199, 111);
            lblStatus.Location = new Point(1108, 64);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(220, 50);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Đã xác nhận";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe MDL2 Assets", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(593, 21);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(100, 100);
            label2.TabIndex = 12;
            label2.Text = "📄";
            // 
            // ucAppointmentRow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label2);
            Controls.Add(lblStatus);
            Controls.Add(pnlReason);
            Controls.Add(lblPatientPhone);
            Controls.Add(lblPatientName);
            Controls.Add(lblTimeTitle);
            Controls.Add(lblTime);
            Name = "ucAppointmentRow";
            Size = new Size(1348, 176);
            Load += ucAppointmentRow_Load;
            pnlReason.ResumeLayout(false);
            pnlReason.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTime;
        private Label lblTimeTitle;
        private Label lblPatientName;
        private Label lblPatientPhone;
        private Label lblReason;
        private Panel pnlReason;
        private Label lblStatus;
        private Label label2;
    }
}
