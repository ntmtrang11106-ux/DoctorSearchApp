namespace UI_Tier
{
    partial class ucTimeSlotDialog
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
            btnClose = new Button();
            lblTitle = new Label();
            lblDept = new Label();
            cbDept = new ComboBox();
            lblDoctor = new Label();
            cbDoctor = new ComboBox();
            lblDate = new Label();
            dtpWorkDate = new DateTimePicker();
            lblFromTime = new Label();
            dtpStartTime = new DateTimePicker();
            lblToTime = new Label();
            dtpEndTime = new DateTimePicker();
            cbRepeat = new CheckBox();
            pnlRepeatRange = new Panel();
            lblEndDateRange = new Label();
            dtpEndDateRange = new DateTimePicker();
            lblStartDateRange = new Label();
            dtpStartDateRange = new DateTimePicker();
            flpDaySelection = new FlowLayoutPanel();
            lblRoom = new Label();
            cbRoom = new ComboBox();
            lblMaxApp = new Label();
            numMax = new NumericUpDown();
            btnCancel = new Button();
            btnCreate = new Button();
            pnlDeptBorder = new Panel();
            pnlDoctorBorder = new Panel();
            pnlDateBorder = new Panel();
            pnlStartBorder = new Panel();
            pnlEndBorder = new Panel();
            pnlRoomBorder = new Panel();
            pnlMaxBorder = new Panel();
            pnlHeader = new Panel();
            pnlRepeatRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMax).BeginInit();
            pnlDeptBorder.SuspendLayout();
            pnlDoctorBorder.SuspendLayout();
            pnlDateBorder.SuspendLayout();
            pnlStartBorder.SuspendLayout();
            pnlEndBorder.SuspendLayout();
            pnlRoomBorder.SuspendLayout();
            pnlMaxBorder.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 16F);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(986, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(89, 69);
            btnClose.TabIndex = 0;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(45, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(348, 59);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tạo lịch hẹn mới";
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDept.ForeColor = Color.Black;
            lblDept.Location = new Point(45, 117);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(118, 45);
            lblDept.TabIndex = 2;
            lblDept.Text = "Khoa *";
            // 
            // cbDept
            // 
            cbDept.Dock = DockStyle.Fill;
            cbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDept.FlatStyle = FlatStyle.Flat;
            cbDept.Font = new Font("Segoe UI", 12F);
            cbDept.FormattingEnabled = true;
            cbDept.Location = new Point(10, 5);
            cbDept.Name = "cbDept";
            cbDept.Size = new Size(1000, 53);
            cbDept.TabIndex = 0;
            cbDept.SelectedIndexChanged += cbDept_SelectedIndexChanged;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDoctor.ForeColor = Color.Black;
            lblDoctor.Location = new Point(45, 237);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(125, 45);
            lblDoctor.TabIndex = 4;
            lblDoctor.Text = "Bác sĩ *";
            // 
            // cbDoctor
            // 
            cbDoctor.Dock = DockStyle.Fill;
            cbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoctor.FlatStyle = FlatStyle.Flat;
            cbDoctor.Font = new Font("Segoe UI", 12F);
            cbDoctor.FormattingEnabled = true;
            cbDoctor.Location = new Point(10, 5);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(1000, 53);
            cbDoctor.TabIndex = 0;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDate.ForeColor = Color.Black;
            lblDate.Location = new Point(45, 357);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(120, 45);
            lblDate.TabIndex = 6;
            lblDate.Text = "Ngày *";
            // 
            // dtpWorkDate
            // 
            dtpWorkDate.CustomFormat = "dd/MM/yyyy";
            dtpWorkDate.Dock = DockStyle.Fill;
            dtpWorkDate.Font = new Font("Segoe UI", 12F);
            dtpWorkDate.Format = DateTimePickerFormat.Custom;
            dtpWorkDate.Location = new Point(10, 5);
            dtpWorkDate.Name = "dtpWorkDate";
            dtpWorkDate.Size = new Size(1000, 50);
            dtpWorkDate.TabIndex = 0;
            // 
            // lblFromTime
            // 
            lblFromTime.AutoSize = true;
            lblFromTime.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblFromTime.ForeColor = Color.Black;
            lblFromTime.Location = new Point(45, 477);
            lblFromTime.Name = "lblFromTime";
            lblFromTime.Size = new Size(81, 45);
            lblFromTime.TabIndex = 8;
            lblFromTime.Text = "Từ *";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.Dock = DockStyle.Fill;
            dtpStartTime.Font = new Font("Segoe UI", 12F);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(10, 5);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(475, 50);
            dtpStartTime.TabIndex = 0;
            // 
            // lblToTime
            // 
            lblToTime.AutoSize = true;
            lblToTime.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblToTime.ForeColor = Color.Black;
            lblToTime.Location = new Point(570, 477);
            lblToTime.Name = "lblToTime";
            lblToTime.Size = new Size(102, 45);
            lblToTime.TabIndex = 10;
            lblToTime.Text = "Đến *";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm";
            dtpEndTime.Dock = DockStyle.Fill;
            dtpEndTime.Font = new Font("Segoe UI", 12F);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(10, 5);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(475, 50);
            dtpEndTime.TabIndex = 0;
            // 
            // cbRepeat
            // 
            cbRepeat.AutoSize = true;
            cbRepeat.Font = new Font("Segoe UI", 12F);
            cbRepeat.Location = new Point(45, 605);
            cbRepeat.Name = "cbRepeat";
            cbRepeat.Size = new Size(263, 49);
            cbRepeat.TabIndex = 12;
            cbRepeat.Text = "Lịch hẹn lặp lại";
            cbRepeat.UseVisualStyleBackColor = true;
            cbRepeat.CheckedChanged += cbRepeat_CheckedChanged;
            // 
            // pnlRepeatRange
            // 
            pnlRepeatRange.Controls.Add(lblEndDateRange);
            pnlRepeatRange.Controls.Add(dtpEndDateRange);
            pnlRepeatRange.Controls.Add(lblStartDateRange);
            pnlRepeatRange.Controls.Add(dtpStartDateRange);
            pnlRepeatRange.Controls.Add(flpDaySelection);
            pnlRepeatRange.Location = new Point(40, 655);
            pnlRepeatRange.Name = "pnlRepeatRange";
            pnlRepeatRange.Size = new Size(1020, 253);
            pnlRepeatRange.TabIndex = 13;
            pnlRepeatRange.Visible = false;
            // 
            // lblEndDateRange
            // 
            lblEndDateRange.AutoSize = true;
            lblEndDateRange.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEndDateRange.ForeColor = Color.Black;
            lblEndDateRange.Location = new Point(525, 131);
            lblEndDateRange.Name = "lblEndDateRange";
            lblEndDateRange.Size = new Size(159, 45);
            lblEndDateRange.TabIndex = 17;
            lblEndDateRange.Text = "Đến ngày";
            // 
            // dtpEndDateRange
            // 
            dtpEndDateRange.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndDateRange.CustomFormat = "dd/MM/yyyy";
            dtpEndDateRange.Font = new Font("Segoe UI", 11F);
            dtpEndDateRange.Format = DateTimePickerFormat.Custom;
            dtpEndDateRange.Location = new Point(525, 190);
            dtpEndDateRange.Name = "dtpEndDateRange";
            dtpEndDateRange.Size = new Size(475, 47);
            dtpEndDateRange.TabIndex = 16;
            // 
            // lblStartDateRange
            // 
            lblStartDateRange.AutoSize = true;
            lblStartDateRange.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblStartDateRange.ForeColor = Color.Black;
            lblStartDateRange.Location = new Point(20, 131);
            lblStartDateRange.Name = "lblStartDateRange";
            lblStartDateRange.Size = new Size(138, 45);
            lblStartDateRange.TabIndex = 2;
            lblStartDateRange.Text = "Từ ngày";
            // 
            // dtpStartDateRange
            // 
            dtpStartDateRange.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartDateRange.CustomFormat = "dd/MM/yyyy";
            dtpStartDateRange.Font = new Font("Segoe UI", 11F);
            dtpStartDateRange.Format = DateTimePickerFormat.Custom;
            dtpStartDateRange.Location = new Point(20, 190);
            dtpStartDateRange.Name = "dtpStartDateRange";
            dtpStartDateRange.Size = new Size(475, 47);
            dtpStartDateRange.TabIndex = 14;
            // 
            // flpDaySelection
            // 
            flpDaySelection.Location = new Point(0, 10);
            flpDaySelection.Name = "flpDaySelection";
            flpDaySelection.Size = new Size(1020, 110);
            flpDaySelection.TabIndex = 0;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblRoom.ForeColor = Color.Black;
            lblRoom.Location = new Point(45, 927);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(228, 45);
            lblRoom.TabIndex = 14;
            lblRoom.Text = "Phòng khám *";
            // 
            // cbRoom
            // 
            cbRoom.Dock = DockStyle.Fill;
            cbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoom.FlatStyle = FlatStyle.Flat;
            cbRoom.Font = new Font("Segoe UI", 12F);
            cbRoom.FormattingEnabled = true;
            cbRoom.Location = new Point(10, 5);
            cbRoom.Name = "cbRoom";
            cbRoom.Size = new Size(1000, 53);
            cbRoom.TabIndex = 0;
            // 
            // lblMaxApp
            // 
            lblMaxApp.AutoSize = true;
            lblMaxApp.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblMaxApp.ForeColor = Color.Black;
            lblMaxApp.Location = new Point(45, 1047);
            lblMaxApp.Name = "lblMaxApp";
            lblMaxApp.Size = new Size(324, 45);
            lblMaxApp.TabIndex = 16;
            lblMaxApp.Text = "Số lượng đặt tối đa *";
            // 
            // numMax
            // 
            numMax.BorderStyle = BorderStyle.None;
            numMax.Dock = DockStyle.Fill;
            numMax.Font = new Font("Segoe UI", 12F);
            numMax.Location = new Point(10, 5);
            numMax.Name = "numMax";
            numMax.Size = new Size(1000, 46);
            numMax.TabIndex = 0;
            numMax.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(37, 99, 235);
            btnCancel.Location = new Point(625, 1183);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(185, 60);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "HỦY";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(37, 99, 235);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(816, 1183);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(224, 60);
            btnCreate.TabIndex = 19;
            btnCreate.Text = "TẠO MỚI";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnConfirm_Click;
            // 
            // pnlDeptBorder
            // 
            pnlDeptBorder.BackColor = Color.White;
            pnlDeptBorder.Controls.Add(cbDept);
            pnlDeptBorder.Location = new Point(40, 160);
            pnlDeptBorder.Name = "pnlDeptBorder";
            pnlDeptBorder.Padding = new Padding(10, 5, 10, 5);
            pnlDeptBorder.Size = new Size(1020, 65);
            pnlDeptBorder.TabIndex = 3;
            // 
            // pnlDoctorBorder
            // 
            pnlDoctorBorder.BackColor = Color.White;
            pnlDoctorBorder.Controls.Add(cbDoctor);
            pnlDoctorBorder.Location = new Point(40, 280);
            pnlDoctorBorder.Name = "pnlDoctorBorder";
            pnlDoctorBorder.Padding = new Padding(10, 5, 10, 5);
            pnlDoctorBorder.Size = new Size(1020, 65);
            pnlDoctorBorder.TabIndex = 5;
            // 
            // pnlDateBorder
            // 
            pnlDateBorder.BackColor = Color.White;
            pnlDateBorder.Controls.Add(dtpWorkDate);
            pnlDateBorder.Location = new Point(40, 400);
            pnlDateBorder.Name = "pnlDateBorder";
            pnlDateBorder.Padding = new Padding(10, 5, 10, 5);
            pnlDateBorder.Size = new Size(1020, 65);
            pnlDateBorder.TabIndex = 7;
            // 
            // pnlStartBorder
            // 
            pnlStartBorder.BackColor = Color.White;
            pnlStartBorder.Controls.Add(dtpStartTime);
            pnlStartBorder.Location = new Point(40, 520);
            pnlStartBorder.Name = "pnlStartBorder";
            pnlStartBorder.Padding = new Padding(10, 5, 10, 5);
            pnlStartBorder.Size = new Size(495, 65);
            pnlStartBorder.TabIndex = 9;
            // 
            // pnlEndBorder
            // 
            pnlEndBorder.BackColor = Color.White;
            pnlEndBorder.Controls.Add(dtpEndTime);
            pnlEndBorder.Location = new Point(565, 520);
            pnlEndBorder.Name = "pnlEndBorder";
            pnlEndBorder.Padding = new Padding(10, 5, 10, 5);
            pnlEndBorder.Size = new Size(495, 65);
            pnlEndBorder.TabIndex = 11;
            // 
            // pnlRoomBorder
            // 
            pnlRoomBorder.BackColor = Color.White;
            pnlRoomBorder.Controls.Add(cbRoom);
            pnlRoomBorder.Location = new Point(40, 970);
            pnlRoomBorder.Name = "pnlRoomBorder";
            pnlRoomBorder.Padding = new Padding(10, 5, 10, 5);
            pnlRoomBorder.Size = new Size(1020, 65);
            pnlRoomBorder.TabIndex = 15;
            // 
            // pnlMaxBorder
            // 
            pnlMaxBorder.BackColor = Color.White;
            pnlMaxBorder.Controls.Add(numMax);
            pnlMaxBorder.Location = new Point(40, 1090);
            pnlMaxBorder.Name = "pnlMaxBorder";
            pnlMaxBorder.Padding = new Padding(10, 5, 10, 5);
            pnlMaxBorder.Size = new Size(1020, 65);
            pnlMaxBorder.TabIndex = 17;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(5, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(5, 5, 5, 0);
            pnlHeader.Size = new Size(1090, 100);
            pnlHeader.TabIndex = 100;
            // 
            // ucTimeSlotDialog
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnCreate);
            Controls.Add(btnCancel);
            Controls.Add(pnlMaxBorder);
            Controls.Add(lblMaxApp);
            Controls.Add(pnlRoomBorder);
            Controls.Add(lblRoom);
            Controls.Add(pnlRepeatRange);
            Controls.Add(cbRepeat);
            Controls.Add(pnlEndBorder);
            Controls.Add(lblToTime);
            Controls.Add(pnlStartBorder);
            Controls.Add(lblFromTime);
            Controls.Add(pnlDateBorder);
            Controls.Add(lblDate);
            Controls.Add(pnlDoctorBorder);
            Controls.Add(lblDoctor);
            Controls.Add(pnlDeptBorder);
            Controls.Add(lblDept);
            Controls.Add(pnlHeader);
            Name = "ucTimeSlotDialog";
            Padding = new Padding(5);
            Size = new Size(1100, 1258);
            Load += ucTimeSlotCheckbox_Load;
            pnlRepeatRange.ResumeLayout(false);
            pnlRepeatRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMax).EndInit();
            pnlDeptBorder.ResumeLayout(false);
            pnlDoctorBorder.ResumeLayout(false);
            pnlDateBorder.ResumeLayout(false);
            pnlStartBorder.ResumeLayout(false);
            pnlEndBorder.ResumeLayout(false);
            pnlRoomBorder.ResumeLayout(false);
            pnlMaxBorder.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Label lblTitle;
        private Label lblDept;
        private ComboBox cbDept;
        private Label lblDoctor;
        private ComboBox cbDoctor;
        private Label lblDate;
        private DateTimePicker dtpWorkDate;
        private Label lblFromTime;
        private DateTimePicker dtpStartTime;
        private Label lblToTime;
        private DateTimePicker dtpEndTime;
        private CheckBox cbRepeat;
        private Panel pnlRepeatRange;
        private FlowLayoutPanel flpDaySelection;
        private Label lblStartDateRange;
        private DateTimePicker dtpStartDateRange;
        private Label lblEndDateRange;
        private DateTimePicker dtpEndDateRange;
        private Label lblRoom;
        private ComboBox cbRoom;
        private Label lblMaxApp;
        private NumericUpDown numMax;
        private Button btnCancel;
        private Button btnCreate;
        private Panel pnlDeptBorder;
        private Panel pnlDoctorBorder;
        private Panel pnlDateBorder;
        private Panel pnlStartBorder;
        private Panel pnlEndBorder;
        private Panel pnlRoomBorder;
        private Panel pnlMaxBorder;
        private Panel pnlHeader;
    }
}