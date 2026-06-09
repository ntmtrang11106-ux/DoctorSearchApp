namespace UI_Tier
{
    partial class ucUserAppointmentCard
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
            components = new System.ComponentModel.Container();
            lblName = new Label();
            lblPhoneNumber = new Label();
            lblDate = new Label();
            lblTime = new Label();
            lblSymptoms = new Label();
            btnStatus = new Button();
            label2 = new Label();
            label1 = new Label();
            flpAction = new FlowLayoutPanel();
            btnViewRecord = new Button();
            btnRate = new Button();
            btnRemove = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            btnAccept = new Button();
            ttAction = new ToolTip(components);
            flpAction.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblName.Location = new Point(373, 71);
            lblName.Name = "lblName";
            lblName.Size = new Size(349, 51);
            lblName.TabIndex = 0;
            lblName.Text = "Bác sĩ / Bệnh nhân";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 12F);
            lblPhoneNumber.Location = new Point(373, 145);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(190, 45);
            lblPhoneNumber.TabIndex = 4;
            lblPhoneNumber.Text = "0000000000";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.Location = new Point(121, 85);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(180, 45);
            lblDate.TabIndex = 5;
            lblDate.Text = "22/10/2026";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 12F);
            lblTime.Location = new Point(121, 140);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(203, 45);
            lblTime.TabIndex = 6;
            lblTime.Text = "8h30' - 9h45'";
            // 
            // lblSymptoms
            // 
            lblSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSymptoms.ImageAlign = ContentAlignment.MiddleLeft;
            lblSymptoms.Location = new Point(1139, 85);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(553, 131);
            lblSymptoms.TabIndex = 7;
            lblSymptoms.Text = "Lý do khám";
            // 
            // btnStatus
            // 
            btnStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStatus.BackColor = Color.PaleGreen;
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStatus.ForeColor = Color.DarkGreen;
            btnStatus.Location = new Point(1285, 100);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(229, 60);
            btnStatus.TabIndex = 9;
            btnStatus.Text = "Trạng thái";
            btnStatus.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe MDL2 Assets", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(1014, 64);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(100, 100);
            label2.TabIndex = 11;
            label2.Text = "📄";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe MDL2 Assets", 27F);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(28, 77);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(100, 100);
            label1.TabIndex = 13;
            label1.Text = "🕓";
            // 
            // flpAction
            // 
            flpAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpAction.AutoSize = true;
            flpAction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAction.Controls.Add(btnViewRecord);
            flpAction.Controls.Add(btnRate);
            flpAction.Controls.Add(btnRemove);
            flpAction.Controls.Add(btnEdit);
            flpAction.Controls.Add(btnCancel);
            flpAction.Controls.Add(btnAccept);
            flpAction.FlowDirection = FlowDirection.RightToLeft;
            flpAction.Location = new Point(1540, 85);
            flpAction.Name = "flpAction";
            flpAction.Size = new Size(580, 90);
            flpAction.TabIndex = 15;
            flpAction.WrapContents = false;
            // 
            // btnViewRecord
            // 
            btnViewRecord.Anchor = AnchorStyles.None;
            btnViewRecord.BackColor = Color.Azure;
            btnViewRecord.FlatAppearance.BorderSize = 0;
            btnViewRecord.FlatStyle = FlatStyle.Flat;
            btnViewRecord.Font = new Font("Segoe MDL2 Assets", 18F);
            btnViewRecord.ForeColor = Color.DodgerBlue;
            btnViewRecord.Location = new Point(500, 7);
            btnViewRecord.Margin = new Padding(15, 5, 0, 0);
            btnViewRecord.Name = "btnViewRecord";
            btnViewRecord.Size = new Size(80, 80);
            btnViewRecord.TabIndex = 19;
            btnViewRecord.Text = "";
            ttAction.SetToolTip(btnViewRecord, "Kết quả khám");
            btnViewRecord.UseVisualStyleBackColor = false;
            btnViewRecord.Click += btnViewRecord_Click;
            // 
            // btnRate
            // 
            btnRate.Anchor = AnchorStyles.None;
            btnRate.BackColor = Color.LightGoldenrodYellow;
            btnRate.FlatAppearance.BorderSize = 0;
            btnRate.FlatStyle = FlatStyle.Flat;
            btnRate.Font = new Font("Segoe MDL2 Assets", 18F);
            btnRate.ForeColor = Color.Goldenrod;
            btnRate.Location = new Point(405, 7);
            btnRate.Margin = new Padding(15, 5, 0, 0);
            btnRate.Name = "btnRate";
            btnRate.Size = new Size(80, 80);
            btnRate.TabIndex = 18;
            btnRate.Text = "";
            ttAction.SetToolTip(btnRate, "Đánh giá");
            btnRate.UseVisualStyleBackColor = false;
            btnRate.Click += btnRate_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.BackColor = Color.FromArgb(255, 252, 255);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 20F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(305, 5);
            btnRemove.Margin = new Padding(15, 5, 0, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(85, 85);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "";
            ttAction.SetToolTip(btnRemove, "Xóa/Hủy lịch");
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.FromArgb(239, 250, 255);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 20F);
            btnEdit.ForeColor = Color.FromArgb(37, 99, 235);
            btnEdit.Location = new Point(205, 5);
            btnEdit.Margin = new Padding(15, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "";
            ttAction.SetToolTip(btnEdit, "Chỉnh sửa");
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.BackColor = Color.Snow;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe MDL2 Assets", 20F);
            btnCancel.ForeColor = Color.DarkRed;
            btnCancel.Location = new Point(110, 7);
            btnCancel.Margin = new Padding(15, 5, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 80);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "";
            ttAction.SetToolTip(btnCancel, "Từ chối");
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.None;
            btnAccept.BackColor = Color.Honeydew;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe MDL2 Assets", 20F);
            btnAccept.ForeColor = Color.Green;
            btnAccept.Location = new Point(15, 7);
            btnAccept.Margin = new Padding(15, 5, 0, 0);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(80, 80);
            btnAccept.TabIndex = 14;
            btnAccept.Text = "";
            ttAction.SetToolTip(btnAccept, "Chấp nhận");
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // ttAction
            // 
            ttAction.AutoPopDelay = 5000;
            ttAction.InitialDelay = 500;
            ttAction.ReshowDelay = 100;
            ttAction.ShowAlways = true;
            // 
            // ucUserAppointmentCard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpAction);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnStatus);
            Controls.Add(lblSymptoms);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblName);
            Name = "ucUserAppointmentCard";
            Padding = new Padding(10);
            Size = new Size(2186, 252);
            Load += ucUserAppointmentCard_Load;
            flpAction.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSymptoms;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpAction;
        private System.Windows.Forms.Button btnViewRecord;
        private System.Windows.Forms.Button btnRate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ToolTip ttAction;
    }
}
