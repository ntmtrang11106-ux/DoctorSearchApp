namespace UI_Tier
{
    partial class ucAdminScheduleCard
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
            lblDate = new Label();
            lblTime = new Label();
            label1 = new Label();
            btnStatus = new Button();
            lblDep = new Label();
            flpAdminNames = new FlowLayoutPanel();
            lblAdminDoctor = new Label();
            lblAdminArrow = new Label();
            lblAdminPatient = new Label();
            flpAdminPhones = new FlowLayoutPanel();
            lblAdminDoctorPhone = new Label();
            lblAdminArrowPhone = new Label();
            lblAdminPatientPhone = new Label();
            flpAction = new FlowLayoutPanel();
            btnHide = new Button();
            btnRemove = new Button();
            btnEdit = new Button();
            lblAdminInfo = new Label();
            lblArrow = new Label();
            ttAction = new ToolTip(components);
            flpAdminNames.SuspendLayout();
            flpAdminPhones.SuspendLayout();
            flpAction.SuspendLayout();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.Location = new Point(121, 87);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(180, 45);
            lblDate.TabIndex = 5;
            lblDate.Text = "22/10/2026";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 12F);
            lblTime.Location = new Point(121, 143);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(203, 45);
            lblTime.TabIndex = 6;
            lblTime.Text = "8h30' - 9h45'";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe MDL2 Assets", 27F);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(28, 78);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(100, 100);
            label1.TabIndex = 13;
            label1.Text = "🕓";
            // 
            // btnStatus
            // 
            btnStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStatus.BackColor = Color.PaleGreen;
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStatus.ForeColor = Color.DarkGreen;
            btnStatus.Location = new Point(990, 100);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(229, 60);
            btnStatus.TabIndex = 9;
            btnStatus.Text = "Thành công";
            btnStatus.UseVisualStyleBackColor = false;
            // 
            // lblDep
            // 
            lblDep.AutoSize = true;
            lblDep.BackColor = Color.FromArgb(239, 246, 255);
            lblDep.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDep.ForeColor = Color.FromArgb(37, 99, 235);
            lblDep.Location = new Point(116, 26);
            lblDep.Name = "lblDep";
            lblDep.Padding = new Padding(12, 6, 12, 6);
            lblDep.Size = new Size(212, 52);
            lblDep.TabIndex = 25;
            lblDep.Text = "Chuyên khoa";
            // 
            // flpAdminNames
            // 
            flpAdminNames.AutoSize = true;
            flpAdminNames.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAdminNames.Controls.Add(lblAdminDoctor);
            flpAdminNames.Controls.Add(lblAdminArrow);
            flpAdminNames.Controls.Add(lblAdminPatient);
            flpAdminNames.Location = new Point(410, 85);
            flpAdminNames.Name = "flpAdminNames";
            flpAdminNames.Size = new Size(409, 51);
            flpAdminNames.TabIndex = 27;
            flpAdminNames.WrapContents = false;
            // 
            // lblAdminDoctor
            // 
            lblAdminDoctor.AutoSize = true;
            lblAdminDoctor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAdminDoctor.Location = new Point(0, 0);
            lblAdminDoctor.Margin = new Padding(0);
            lblAdminDoctor.Name = "lblAdminDoctor";
            lblAdminDoctor.Size = new Size(122, 51);
            lblAdminDoctor.TabIndex = 1;
            lblAdminDoctor.Text = "Bác sĩ";
            // 
            // lblAdminArrow
            // 
            lblAdminArrow.AutoSize = true;
            lblAdminArrow.Font = new Font("Segoe UI", 14F);
            lblAdminArrow.ForeColor = Color.Gray;
            lblAdminArrow.Location = new Point(132, 0);
            lblAdminArrow.Margin = new Padding(10, 0, 10, 0);
            lblAdminArrow.Name = "lblAdminArrow";
            lblAdminArrow.Size = new Size(55, 51);
            lblAdminArrow.TabIndex = 20;
            lblAdminArrow.Text = "→";
            // 
            // lblAdminPatient
            // 
            lblAdminPatient.AutoSize = true;
            lblAdminPatient.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAdminPatient.Location = new Point(197, 0);
            lblAdminPatient.Margin = new Padding(0);
            lblAdminPatient.Name = "lblAdminPatient";
            lblAdminPatient.Size = new Size(212, 51);
            lblAdminPatient.TabIndex = 0;
            lblAdminPatient.Text = "Bệnh nhân";
            // 
            // flpAdminPhones
            // 
            flpAdminPhones.AutoSize = true;
            flpAdminPhones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAdminPhones.Controls.Add(lblAdminDoctorPhone);
            flpAdminPhones.Controls.Add(lblAdminArrowPhone);
            flpAdminPhones.Controls.Add(lblAdminPatientPhone);
            flpAdminPhones.Location = new Point(410, 145);
            flpAdminPhones.Name = "flpAdminPhones";
            flpAdminPhones.Size = new Size(448, 45);
            flpAdminPhones.TabIndex = 33;
            flpAdminPhones.WrapContents = false;
            // 
            // lblAdminDoctorPhone
            // 
            lblAdminDoctorPhone.AutoSize = true;
            lblAdminDoctorPhone.Font = new Font("Segoe UI", 12F);
            lblAdminDoctorPhone.Location = new Point(0, 0);
            lblAdminDoctorPhone.Margin = new Padding(0);
            lblAdminDoctorPhone.Name = "lblAdminDoctorPhone";
            lblAdminDoctorPhone.Size = new Size(190, 45);
            lblAdminDoctorPhone.TabIndex = 32;
            lblAdminDoctorPhone.Text = "0000000000";
            // 
            // lblAdminArrowPhone
            // 
            lblAdminArrowPhone.AutoSize = true;
            lblAdminArrowPhone.Font = new Font("Segoe UI", 12F);
            lblAdminArrowPhone.ForeColor = Color.Silver;
            lblAdminArrowPhone.Location = new Point(200, 0);
            lblAdminArrowPhone.Margin = new Padding(10, 0, 10, 0);
            lblAdminArrowPhone.Name = "lblAdminArrowPhone";
            lblAdminArrowPhone.Size = new Size(48, 45);
            lblAdminArrowPhone.TabIndex = 31;
            lblAdminArrowPhone.Text = "→";
            // 
            // lblAdminPatientPhone
            // 
            lblAdminPatientPhone.AutoSize = true;
            lblAdminPatientPhone.Font = new Font("Segoe UI", 12F);
            lblAdminPatientPhone.Location = new Point(258, 0);
            lblAdminPatientPhone.Margin = new Padding(0);
            lblAdminPatientPhone.Name = "lblAdminPatientPhone";
            lblAdminPatientPhone.Size = new Size(190, 45);
            lblAdminPatientPhone.TabIndex = 30;
            lblAdminPatientPhone.Text = "0000000000";
            // 
            // flpAction
            // 
            flpAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpAction.AutoSize = true;
            flpAction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAction.Controls.Add(btnHide);
            flpAction.Controls.Add(btnRemove);
            flpAction.Controls.Add(btnEdit);
            flpAction.Controls.Add(lblAdminInfo);
            flpAction.FlowDirection = FlowDirection.RightToLeft;
            flpAction.Location = new Point(1468, 55);
            flpAction.Name = "flpAction";
            flpAction.Size = new Size(670, 135);
            flpAction.TabIndex = 15;
            flpAction.WrapContents = false;
            // 
            // btnHide
            // 
            btnHide.Anchor = AnchorStyles.None;
            btnHide.BackColor = Color.FromArgb(243, 244, 246);
            btnHide.FlatAppearance.BorderSize = 0;
            btnHide.FlatStyle = FlatStyle.Flat;
            btnHide.Font = new Font("Segoe MDL2 Assets", 20F);
            btnHide.ForeColor = Color.FromArgb(107, 114, 128);
            btnHide.Location = new Point(585, 27);
            btnHide.Margin = new Padding(15, 5, 0, 0);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(85, 85);
            btnHide.TabIndex = 23;
            btnHide.Text = "";
            btnHide.UseVisualStyleBackColor = false;
            btnHide.Click += btnHide_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.BackColor = Color.FromArgb(255, 252, 235);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 20F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(485, 27);
            btnRemove.Margin = new Padding(15, 5, 0, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(85, 85);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "";
            ttAction.SetToolTip(btnRemove, "Xóa lịch làm việc");
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
            btnEdit.Location = new Point(385, 27);
            btnEdit.Margin = new Padding(15, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "";
            ttAction.SetToolTip(btnEdit, "Chỉnh sửa");
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblAdminInfo
            // 
            lblAdminInfo.AutoSize = true;
            lblAdminInfo.Font = new Font("Segoe UI", 12F);
            lblAdminInfo.Location = new Point(0, 0);
            lblAdminInfo.Margin = new Padding(0, 0, 50, 0);
            lblAdminInfo.Name = "lblAdminInfo";
            lblAdminInfo.Size = new Size(320, 135);
            lblAdminInfo.TabIndex = 28;
            lblAdminInfo.Text = "Phòng: N/A\r\nTrạng thái: Còn trống\r\nSố lượng: 0/0";
            // 
            // lblArrow
            // 
            lblArrow.Location = new Point(990, 210);
            lblArrow.Name = "lblArrow";
            lblArrow.Size = new Size(100, 23);
            lblArrow.TabIndex = 34;
            // 
            // ttAction
            // 
            ttAction.AutoPopDelay = 5000;
            ttAction.InitialDelay = 500;
            ttAction.ReshowDelay = 100;
            ttAction.ShowAlways = true;
            // 
            // ucAdminScheduleCard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpAdminPhones);
            Controls.Add(flpAdminNames);
            Controls.Add(lblArrow);
            Controls.Add(lblDep);
            Controls.Add(flpAction);
            Controls.Add(label1);
            Controls.Add(btnStatus);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Name = "ucAdminScheduleCard";
            Padding = new Padding(10);
            Size = new Size(2186, 252);
            Load += ucAdminScheduleCard_Load;
            flpAdminNames.ResumeLayout(false);
            flpAdminNames.PerformLayout();
            flpAdminPhones.ResumeLayout(false);
            flpAdminPhones.PerformLayout();
            flpAction.ResumeLayout(false);
            flpAction.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.Label lblAdminDoctor;
        private System.Windows.Forms.Label lblAdminPatient;
        private System.Windows.Forms.Label lblAdminArrow;
        private System.Windows.Forms.FlowLayoutPanel flpAdminNames;
        private System.Windows.Forms.Label lblAdminPatientPhone;
        private System.Windows.Forms.Label lblAdminArrowPhone;
        private System.Windows.Forms.Label lblAdminDoctorPhone;
        private System.Windows.Forms.FlowLayoutPanel flpAdminPhones;
        private System.Windows.Forms.FlowLayoutPanel flpAction;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblAdminInfo;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.ToolTip ttAction;
    }
}
