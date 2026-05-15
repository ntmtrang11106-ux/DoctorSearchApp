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
            components = new System.ComponentModel.Container();
            lblName = new Label();
            lblPhoneNumber = new Label();
            lblDate = new Label();
            lblTime = new Label();
            lblSymptoms = new Label();
            btnStatus = new Button();
            label2 = new Label();
            label1 = new Label();
            btnAccept = new Button();
            flpAction = new FlowLayoutPanel();
            btnViewRecord = new Button();
            btnRate = new Button();
            btnBook = new Button();
            btnHide = new Button();
            btnRemove = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            ttAction = new ToolTip(components);
            lblDep = new Label();
            lblAdminInfo = new Label();
            lblAdminRoomIcon = new Label();
            btnAdminStatus = new Button();
            lblAdminPatient = new Label();
            lblAdminDoctor = new Label();
            lblAdminArrow = new Label();
            flpAdminNames = new FlowLayoutPanel();
            lblAdminPatientPhone = new Label();
            lblAdminArrowPhone = new Label();
            lblAdminDoctorPhone = new Label();
            lblAdminPhone = new Label();
            lblArrow = new Label();
            flpAdminPhones = new FlowLayoutPanel();
            flpAction.SuspendLayout();
            flpAdminNames.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblName.Location = new Point(373, 71);
            lblName.Name = "lblName";
            lblName.Size = new Size(249, 51);
            lblName.TabIndex = 0;
            lblName.Text = "Bệnh nhân A";
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
            lblDate.Location = new Point(121, 91);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(180, 45);
            lblDate.TabIndex = 5;
            lblDate.Text = "22/10/2026";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 12F);
            lblTime.Location = new Point(121, 145);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(203, 45);
            lblTime.TabIndex = 6;
            lblTime.Text = "8h30' - 9h45'";
            // 
            // lblSymptoms
            // 
            lblSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSymptoms.ImageAlign = ContentAlignment.MiddleLeft;
            lblSymptoms.Location = new Point(1110, 91);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(553, 131);
            lblSymptoms.TabIndex = 7;
            lblSymptoms.Text = "Đau ngực, khó thở";
            // 
            // btnStatus
            // 
            btnStatus.BackColor = Color.PaleGreen;
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStatus.ForeColor = Color.DarkGreen;
            btnStatus.Location = new Point(1944, 80);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(229, 60);
            btnStatus.TabIndex = 9;
            btnStatus.Text = "Thành công";
            btnStatus.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe MDL2 Assets", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(985, 70);
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
            label1.Location = new Point(28, 71);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(100, 100);
            label1.TabIndex = 13;
            label1.Text = "🕓";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.None;
            btnAccept.BackColor = Color.Honeydew;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe MDL2 Assets", 20F);
            btnAccept.ForeColor = Color.Green;
            btnAccept.Location = new Point(70, 7);
            btnAccept.Margin = new Padding(25, 5, 0, 0);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(80, 80);
            btnAccept.TabIndex = 14;
            btnAccept.Text = "";
            btnAccept.TextAlign = ContentAlignment.MiddleLeft;
            ttAction.SetToolTip(btnAccept, "Chấp nhận");
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // flpAction
            // 
            flpAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpAction.AutoSize = true;
            flpAction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAction.Controls.Add(btnViewRecord);
            flpAction.Controls.Add(btnRate);
            flpAction.Controls.Add(btnBook);
            flpAction.Controls.Add(btnHide);
            flpAction.Controls.Add(btnRemove);
            flpAction.Controls.Add(btnEdit);
            flpAction.Controls.Add(btnCancel);
            flpAction.Controls.Add(btnAccept);
            flpAction.FlowDirection = FlowDirection.RightToLeft;
            flpAction.Location = new Point(1088, 80);
            flpAction.Name = "flpAction";
            flpAction.Size = new Size(1085, 90);
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
            btnViewRecord.Location = new Point(1005, 7);
            btnViewRecord.Margin = new Padding(25, 5, 0, 0);
            btnViewRecord.Name = "btnViewRecord";
            btnViewRecord.Size = new Size(80, 80);
            btnViewRecord.TabIndex = 19;
            btnViewRecord.Text = "";
            btnViewRecord.TextAlign = ContentAlignment.MiddleRight;
            ttAction.SetToolTip(btnViewRecord, "Kết quả khám");
            btnViewRecord.UseVisualStyleBackColor = false;
            // 
            // btnRate
            // 
            btnRate.Anchor = AnchorStyles.None;
            btnRate.BackColor = Color.LightGoldenrodYellow;
            btnRate.FlatAppearance.BorderSize = 0;
            btnRate.FlatStyle = FlatStyle.Flat;
            btnRate.Font = new Font("Segoe MDL2 Assets", 18F);
            btnRate.ForeColor = Color.Goldenrod;
            btnRate.Location = new Point(855, 7);
            btnRate.Margin = new Padding(25, 5, 0, 0);
            btnRate.Name = "btnRate";
            btnRate.Size = new Size(80, 80);
            btnRate.TabIndex = 18;
            btnRate.Text = "";
            btnRate.TextAlign = ContentAlignment.MiddleRight;
            ttAction.SetToolTip(btnRate, "Đánh giá");
            btnRate.UseVisualStyleBackColor = false;
            // 
            // btnBook
            // 
            btnBook.Anchor = AnchorStyles.None;
            btnBook.BackColor = Color.Azure;
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.FlatStyle = FlatStyle.Flat;
            btnBook.Font = new Font("Segoe MDL2 Assets", 18F);
            btnBook.ForeColor = Color.DodgerBlue;
            btnBook.Location = new Point(705, 7);
            btnBook.Margin = new Padding(25, 5, 0, 0);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(80, 80);
            btnBook.TabIndex = 17;
            btnBook.Text = "";
            btnBook.TextAlign = ContentAlignment.MiddleRight;
            ttAction.SetToolTip(btnBook, "Đặt lịch ngay");
            btnBook.UseVisualStyleBackColor = false;
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
            btnHide.Location = new Point(550, 5);
            btnHide.Margin = new Padding(25, 5, 0, 0);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(85, 85);
            btnHide.TabIndex = 23;
            btnHide.Text = "";
            btnHide.UseVisualStyleBackColor = false;
            btnHide.Click += btnHide_Click;
            // 
            // btnRemove
            // 
            btnRemove.AccessibleDescription = "C";
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.BackColor = Color.FromArgb(255, 252, 235);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 20F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(445, 5);
            btnRemove.Margin = new Padding(25, 5, 0, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(85, 85);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "";
            ttAction.SetToolTip(btnRemove, "Xóa lịch hẹn");
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
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
            btnEdit.Location = new Point(330, 5);
            btnEdit.Margin = new Padding(25, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "";
            ttAction.SetToolTip(btnEdit, "Chỉnh sửa lịch hẹn");
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
            btnCancel.Location = new Point(220, 7);
            btnCancel.Margin = new Padding(25, 5, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 80);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "";
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            ttAction.SetToolTip(btnCancel, "Từ chối");
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ttAction
            // 
            ttAction.AutoPopDelay = 5000;
            ttAction.InitialDelay = 500;
            ttAction.ReshowDelay = 100;
            ttAction.ShowAlways = true;
            // 
            // lblDep
            // 
            lblDep.AutoSize = true;
            lblDep.BackColor = Color.FromArgb(239, 246, 255);
            lblDep.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDep.ForeColor = Color.FromArgb(37, 99, 235);
            lblDep.Location = new Point(121, 34);
            lblDep.Name = "lblDep";
            lblDep.Padding = new Padding(12, 6, 12, 6);
            lblDep.Size = new Size(238, 57);
            lblDep.TabIndex = 25;
            lblDep.Text = "Chuyên khoa";
            lblDep.Visible = false;
            // 
            // lblAdminInfo
            // 
            lblAdminInfo.AutoSize = true;
            lblAdminInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminInfo.Location = new Point(1216, 85);
            lblAdminInfo.Name = "lblAdminInfo";
            lblAdminInfo.Size = new Size(210, 90);
            lblAdminInfo.TabIndex = 28;
            lblAdminInfo.Text = "Phòng: N/A\nSố lượng: 0/0";
            lblAdminInfo.Visible = false;
            // 
            // lblAdminRoomIcon
            // 
            lblAdminRoomIcon.Font = new Font("Segoe UI Emoji", 24F);
            lblAdminRoomIcon.ForeColor = Color.DimGray;
            lblAdminRoomIcon.Location = new Point(1110, 75);
            lblAdminRoomIcon.Name = "lblAdminRoomIcon";
            lblAdminRoomIcon.Size = new Size(100, 100);
            lblAdminRoomIcon.TabIndex = 27;
            lblAdminRoomIcon.Text = "🏠";
            lblAdminRoomIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblAdminRoomIcon.Visible = false;
            // 
            // btnAdminStatus
            // 
            btnAdminStatus.BackColor = Color.FromArgb(40, 167, 69);
            btnAdminStatus.FlatAppearance.BorderSize = 0;
            btnAdminStatus.FlatStyle = FlatStyle.Flat;
            btnAdminStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdminStatus.ForeColor = Color.White;
            btnAdminStatus.Location = new Point(1550, 80);
            btnAdminStatus.Name = "btnAdminStatus";
            btnAdminStatus.Size = new Size(204, 63);
            btnAdminStatus.TabIndex = 29;
            btnAdminStatus.Text = "Trạng thái";
            btnAdminStatus.UseVisualStyleBackColor = false;
            btnAdminStatus.Visible = false;
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
            flpAdminNames.Visible = false;
            flpAdminNames.WrapContents = false;
            // 
            // lblAdminPatientPhone
            // 
            lblAdminPatientPhone.AutoSize = true;
            lblAdminPatientPhone.Font = new Font("Segoe UI", 12F);
            lblAdminPatientPhone.Location = new Point(697, 145);
            lblAdminPatientPhone.Margin = new Padding(0);
            lblAdminPatientPhone.Name = "lblAdminPatientPhone";
            lblAdminPatientPhone.Size = new Size(190, 45);
            lblAdminPatientPhone.TabIndex = 30;
            lblAdminPatientPhone.Text = "0000000000";
            // 
            // lblAdminArrowPhone
            // 
            lblAdminArrowPhone.AutoSize = true;
            lblAdminArrowPhone.Font = new Font("Segoe UI", 12F);
            lblAdminArrowPhone.ForeColor = Color.Silver;
            lblAdminArrowPhone.Location = new Point(639, 145);
            lblAdminArrowPhone.Margin = new Padding(10, 0, 10, 0);
            lblAdminArrowPhone.Name = "lblAdminArrowPhone";
            lblAdminArrowPhone.Size = new Size(48, 45);
            lblAdminArrowPhone.TabIndex = 31;
            lblAdminArrowPhone.Text = "→";
            // 
            // lblAdminDoctorPhone
            // 
            lblAdminDoctorPhone.AutoSize = true;
            lblAdminDoctorPhone.Font = new Font("Segoe UI", 12F);
            lblAdminDoctorPhone.Location = new Point(410, 145);
            lblAdminDoctorPhone.Margin = new Padding(0);
            lblAdminDoctorPhone.Name = "lblAdminDoctorPhone";
            lblAdminDoctorPhone.Size = new Size(190, 45);
            lblAdminDoctorPhone.TabIndex = 32;
            lblAdminDoctorPhone.Text = "0000000000";
            // 
            // lblAdminPhone
            // 
            lblAdminPhone.Location = new Point(0, 0);
            lblAdminPhone.Name = "lblAdminPhone";
            lblAdminPhone.Size = new Size(100, 23);
            lblAdminPhone.TabIndex = 35;
            // 
            // lblArrow
            // 
            lblArrow.Location = new Point(990, 210);
            lblArrow.Name = "lblArrow";
            lblArrow.Size = new Size(100, 23);
            lblArrow.TabIndex = 34;
            // 
            // flpAdminPhones
            // 
            flpAdminPhones.AutoSize = true;
            flpAdminPhones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAdminPhones.Location = new Point(410, 210);
            flpAdminPhones.Name = "flpAdminPhones";
            flpAdminPhones.Size = new Size(0, 0);
            flpAdminPhones.TabIndex = 33;
            flpAdminPhones.Visible = false;
            flpAdminPhones.WrapContents = false;
            // 
            // ucAppItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpAdminPhones);
            Controls.Add(flpAdminNames);
            Controls.Add(btnAdminStatus);
            Controls.Add(lblArrow);
            Controls.Add(lblAdminPhone);
            Controls.Add(lblAdminPatientPhone);
            Controls.Add(lblAdminArrowPhone);
            Controls.Add(lblAdminDoctorPhone);
            Controls.Add(lblAdminRoomIcon);
            Controls.Add(lblAdminInfo);
            Controls.Add(lblDep);
            Controls.Add(flpAction);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnStatus);
            Controls.Add(lblSymptoms);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblName);
            Name = "ucAppItem";
            Padding = new Padding(10);
            Size = new Size(2186, 252);
            Load += ucAppItem_Load;
            flpAction.ResumeLayout(false);
            flpAdminNames.ResumeLayout(false);
            flpAdminNames.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblPhoneNumber;
        private Label lblDate;
        private Label lblTime;
        private Label lblSymptoms;
        private Button btnStatus;
        private Label label2;
        private Label label1;
        private Button btnAccept;
        private FlowLayoutPanel flpAction;
        private Button btnCancel;
        private Button btnRemove;
        private Button btnEdit;
        private Button btnBook;
        private ToolTip ttAction;
        private Button btnRate;
        private Button btnViewRecord;
        private Label lblDep;
        private Label lblAdminInfo;
        private Label lblAdminRoomIcon;
        private Label lblAdminPatient;
        private Label lblAdminDoctor;
        private Label lblAdminArrow;
        private Label lblAdminPatientPhone;
        private Label lblAdminArrowPhone;
        private Label lblAdminDoctorPhone;
        private Label lblAdminDate;
        private Label lblAdminTime;
        private Label lblAdminClockIcon;
        private Button btnAdminStatus;
        private Button btnHide;
        private Button btnShow;
        private Label lblAdminPhone;
        private Label lblArrow;
        private FlowLayoutPanel flpAdminNames;
        private FlowLayoutPanel flpAdminPhones;
        private Button button1;
    }
}
