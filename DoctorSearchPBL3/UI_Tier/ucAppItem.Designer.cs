namespace UI_Tier
{
    partial class ucAppItem
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
            lblPatientName = new Label();
            pictureBox3 = new PictureBox();
            lblPhoneNumber = new Label();
            lblDate = new Label();
            lblTime = new Label();
            lblSymptoms = new Label();
            btnStatus = new Button();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPatientName.Location = new Point(380, 62);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(317, 54);
            lblPatientName.TabIndex = 0;
            lblPatientName.Text = "Nguyễn Văn An";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.clock;
            pictureBox3.Location = new Point(39, 96);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(55, 55);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 11F);
            lblPhoneNumber.Location = new Point(380, 131);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(178, 41);
            lblPhoneNumber.TabIndex = 4;
            lblPhoneNumber.Text = "0000000000";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 11F);
            lblDate.Location = new Point(124, 75);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(170, 41);
            lblDate.TabIndex = 5;
            lblDate.Text = "22/10/2026";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 11F);
            lblTime.Location = new Point(122, 131);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(190, 41);
            lblTime.TabIndex = 6;
            lblTime.Text = "8h30' - 9h45'";
            // 
            // lblSymptoms
            // 
            lblSymptoms.Font = new Font("Segoe UI", 11F);
            lblSymptoms.ImageAlign = ContentAlignment.MiddleLeft;
            lblSymptoms.Location = new Point(851, 96);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(542, 131);
            lblSymptoms.TabIndex = 7;
            lblSymptoms.Text = "Đau ngực, khó thở";
            // 
            // btnStatus
            // 
            btnStatus.BackColor = Color.PaleGreen;
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.Font = new Font("Segoe UI", 12F);
            btnStatus.ForeColor = Color.DarkGreen;
            btnStatus.Location = new Point(1429, 96);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(254, 55);
            btnStatus.TabIndex = 9;
            btnStatus.Text = "Thành công";
            btnStatus.UseVisualStyleBackColor = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.document;
            pictureBox4.Location = new Point(767, 96);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(55, 55);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // ucAppItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnStatus);
            Controls.Add(pictureBox4);
            Controls.Add(lblSymptoms);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblPhoneNumber);
            Controls.Add(pictureBox3);
            Controls.Add(lblPatientName);
            Name = "ucAppItem";
            Size = new Size(2297, 252);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPatientName;
        private PictureBox pictureBox3;
        private Label lblPhoneNumber;
        private Label lblDate;
        private Label lblTime;
        private Label lblSymptoms;
        private Button btnStatus;
        private PictureBox pictureBox4;
    }
}
