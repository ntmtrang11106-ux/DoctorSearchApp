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
            pnlSymptoms = new Panel();
            btnStatus = new Button();
            lblPendingCount = new Label();
            label2 = new Label();
            label1 = new Label();
            btnComplete = new Button();
            btnAccept = new Button();
            flpAction = new FlowLayoutPanel();
            btnViewRecord = new Button();
            btnRate = new Button();
            btnBook = new Button();
            btnHide = new Button();
            btnRemove = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            pnlAdminInfo = new Panel();
            lblAdminRoom = new Label();
            lblAdminInfo = new Label();
            ttAction = new ToolTip(components);
            lblDep = new Label();
            lblAdminDoctor = new Label();
            flpAdminNames = new FlowLayoutPanel();
            btnViewPatients = new Button();
            lblAdminPhone = new Label();
            lblArrow = new Label();
            flpAdminPhones = new FlowLayoutPanel();
            pnlSymptoms.SuspendLayout();
            flpAction.SuspendLayout();
            pnlAdminInfo.SuspendLayout();
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
            lblSymptoms.AutoSize = true;
            lblSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSymptoms.ImageAlign = ContentAlignment.MiddleLeft;
            lblSymptoms.Location = new Point(0, 0);
            lblSymptoms.MaximumSize = new Size(520, 0);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(282, 45);
            lblSymptoms.TabIndex = 7;
            lblSymptoms.Text = "Đau ngực, khó thở";
            // 
            // pnlSymptoms
            // 
            pnlSymptoms.AutoScroll = true;
            pnlSymptoms.Controls.Add(lblSymptoms);
            pnlSymptoms.Location = new Point(1110, 91);
            pnlSymptoms.Name = "pnlSymptoms";
            pnlSymptoms.Size = new Size(553, 131);
            pnlSymptoms.TabIndex = 13;
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
            // lblPendingCount
            // 
            lblPendingCount.BackColor = Color.OldLace;
            lblPendingCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPendingCount.ForeColor = Color.DarkOrange;
            lblPendingCount.Location = new Point(1944, 80);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(229, 60);
            lblPendingCount.TabIndex = 10;
            lblPendingCount.Text = "0 chờ duyệt";
            lblPendingCount.TextAlign = ContentAlignment.MiddleCenter;
            lblPendingCount.Visible = false;
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
            label1.Location = new Point(28, 77);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(100, 100);
            label1.TabIndex = 13;
            label1.Text = "🕓";
            // 
            // btnComplete
            // 
            btnComplete.Anchor = AnchorStyles.None;
            btnComplete.BackColor = Color.Azure;
            btnComplete.FlatAppearance.BorderSize = 0;
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.Font = new Font("Segoe MDL2 Assets", 20F);
            btnComplete.ForeColor = Color.Teal;
            btnComplete.Location = new Point(351, 33);
            btnComplete.Margin = new Padding(25, 5, 0, 0);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(80, 80);
            btnComplete.TabIndex = 20;
            btnComplete.Text = "";
            btnComplete.TextAlign = ContentAlignment.MiddleLeft;
            ttAction.SetToolTip(btnComplete, "Đánh dấu hoàn thành ca khám");
            btnComplete.UseVisualStyleBackColor = false;
            btnComplete.Click += btnComplete_Click;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.None;
            btnAccept.BackColor = Color.Honeydew;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe MDL2 Assets", 20F);
            btnAccept.ForeColor = Color.Green;
            btnAccept.Location = new Point(456, 33);
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
            flpAction.Controls.Add(btnComplete);
            flpAction.Controls.Add(pnlAdminInfo);
            flpAction.FlowDirection = FlowDirection.RightToLeft;
            flpAction.Location = new Point(879, 59);
            flpAction.Name = "flpAction";
            flpAction.Size = new Size(1286, 141);
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
            btnViewRecord.Location = new Point(1206, 33);
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
            btnRate.Location = new Point(1101, 33);
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
            btnBook.Location = new Point(996, 33);
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
            btnHide.Location = new Point(886, 30);
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
            btnRemove.Location = new Point(776, 30);
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
            btnEdit.Location = new Point(666, 30);
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
            btnCancel.Location = new Point(561, 33);
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
            // pnlAdminInfo
            // 
            pnlAdminInfo.AutoSize = true;
            pnlAdminInfo.Controls.Add(lblAdminRoom);
            pnlAdminInfo.Controls.Add(lblAdminInfo);
            pnlAdminInfo.Location = new Point(3, 3);
            pnlAdminInfo.Name = "pnlAdminInfo";
            pnlAdminInfo.Size = new Size(320, 135);
            pnlAdminInfo.TabIndex = 29;
            pnlAdminInfo.Visible = false;
            // 
            // lblAdminRoom
            // 
            lblAdminRoom.AutoSize = true;
            lblAdminRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminRoom.Location = new Point(0, 0);
            lblAdminRoom.Name = "lblAdminRoom";
            lblAdminRoom.Size = new Size(185, 45);
            lblAdminRoom.TabIndex = 0;
            lblAdminRoom.Text = "Phòng: N/A";
            // 
            // lblAdminInfo
            // 
            lblAdminInfo.AutoSize = true;
            lblAdminInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminInfo.Location = new Point(0, 45);
            lblAdminInfo.Margin = new Padding(0);
            lblAdminInfo.Name = "lblAdminInfo";
            lblAdminInfo.Size = new Size(320, 90);
            lblAdminInfo.TabIndex = 1;
            lblAdminInfo.Text = "Trạng thái: Còn trống\r\nSố lượng: 0/0";
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
            lblDep.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDep.ForeColor = Color.FromArgb(37, 99, 235);
            lblDep.Location = new Point(115, 24);
            lblDep.Name = "lblDep";
            lblDep.Padding = new Padding(12, 6, 12, 6);
            lblDep.Size = new Size(212, 52);
            lblDep.TabIndex = 25;
            lblDep.Text = "Chuyên khoa";
            lblDep.Visible = false;
            // 
            // lblAdminDoctor
            // 
            lblAdminDoctor.Location = new Point(0, 0);
            lblAdminDoctor.Name = "lblAdminDoctor";
            lblAdminDoctor.Size = new Size(100, 23);
            lblAdminDoctor.TabIndex = 0;
            // 
            // flpAdminNames
            // 
            flpAdminNames.AutoSize = true;
            flpAdminNames.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAdminNames.Location = new Point(410, 85);
            flpAdminNames.Name = "flpAdminNames";
            flpAdminNames.Size = new Size(0, 0);
            flpAdminNames.TabIndex = 27;
            flpAdminNames.Visible = false;
            flpAdminNames.WrapContents = false;
            // 
            // btnViewPatients
            // 
            btnViewPatients.AutoSize = true;
            btnViewPatients.BackColor = Color.FromArgb(239, 246, 255);
            btnViewPatients.FlatAppearance.BorderSize = 0;
            btnViewPatients.FlatStyle = FlatStyle.Flat;
            btnViewPatients.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewPatients.ForeColor = Color.FromArgb(37, 99, 235);
            btnViewPatients.Location = new Point(905, 85);
            btnViewPatients.Margin = new Padding(0);
            btnViewPatients.Name = "btnViewPatients";
            btnViewPatients.Size = new Size(402, 55);
            btnViewPatients.TabIndex = 36;
            btnViewPatients.Text = "Xem chi tiết 0 bệnh nhân";
            btnViewPatients.UseVisualStyleBackColor = false;
            btnViewPatients.Visible = false;
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
            Controls.Add(lblArrow);
            Controls.Add(lblAdminPhone);
            Controls.Add(lblDep);
            Controls.Add(flpAction);
            Controls.Add(btnViewPatients);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblPendingCount);
            Controls.Add(btnStatus);
            Controls.Add(pnlSymptoms);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblName);
            Name = "ucAppItem";
            Padding = new Padding(10);
            Size = new Size(2186, 252);
            Load += ucAppItem_Load;
            pnlSymptoms.ResumeLayout(false);
            pnlSymptoms.PerformLayout();
            flpAction.ResumeLayout(false);
            flpAction.PerformLayout();
            pnlAdminInfo.ResumeLayout(false);
            pnlAdminInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblPhoneNumber;
        private Label lblDate;
        private Label lblTime;
        private Label lblSymptoms;
        private Panel pnlSymptoms;
        private Button btnStatus;
        private Label lblPendingCount;
        private Label label2;
        private Label label1;
        private Button btnAccept;
        private Button btnComplete;
        private FlowLayoutPanel flpAction;
        private Button btnCancel;
        private Button btnRemove;
        private Button btnEdit;
        private Button btnBook;
        private ToolTip ttAction;
        private Button btnRate;
        private Button btnViewRecord;
        private Label lblDep;
        private Panel pnlAdminInfo;
        private Label lblAdminRoom;
        private Label lblAdminInfo;
        private Label lblAdminDoctor;
        private Label lblAdminDate;
        private Label lblAdminTime;
        private Label lblAdminClockIcon;
        private Button btnHide;
        private Button btnShow;
        private Label lblAdminPhone;
        private Label lblArrow;
        private FlowLayoutPanel flpAdminNames;
        private FlowLayoutPanel flpAdminPhones;
        private Button button1;
        private Button btnViewPatients;
        private Label lblAdminPatient;
        //private Label lblAdminDoctor;
        private Label lblAdminArrow;
        private Label lblAdminPatientPhone;
        private Label lblAdminArrowPhone;
        private Label lblAdminDoctorPhone;
    }
}
