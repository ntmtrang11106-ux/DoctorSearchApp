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
            btnCancel = new Button();
            lblCertIndex = new Label();
            dtpDOB = new DateTimePicker();
            label10 = new Label();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            cbRepeat = new CheckBox();
            dateTimePicker3 = new DateTimePicker();
            label3 = new Label();
            dateTimePicker4 = new DateTimePicker();
            label4 = new Label();
            flpDay = new FlowLayoutPanel();
            btnConfirm = new Button();
            pnlRepeat = new Panel();
            labRoom = new Label();
            cbRoomCode = new ComboBox();
            lbSoLuong = new Label();
            numMax = new NumericUpDown();
            pnlRepeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMax).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe MDL2 Assets", 15F);
            btnCancel.ForeColor = Color.DarkRed;
            btnCancel.Location = new Point(991, 0);
            btnCancel.Margin = new Padding(0, 5, 70, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(66, 66);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "";
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblCertIndex
            // 
            lblCertIndex.AutoSize = true;
            lblCertIndex.BackColor = Color.Azure;
            lblCertIndex.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
            lblCertIndex.ForeColor = Color.Black;
            lblCertIndex.Location = new Point(7, 8);
            lblCertIndex.Name = "lblCertIndex";
            lblCertIndex.Size = new Size(236, 47);
            lblCertIndex.TabIndex = 39;
            lblCertIndex.Text = "  Lịch hẹn mới";
            // 
            // dtpDOB
            // 
            dtpDOB.CalendarFont = new Font("Segoe UI", 12F);
            dtpDOB.CustomFormat = "  dd / MM / yyyy";
            dtpDOB.Font = new Font("Segoe UI", 12F);
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.Location = new Point(159, 89);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(324, 50);
            dtpDOB.TabIndex = 41;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(49, 90);
            label10.Name = "label10";
            label10.Size = new Size(94, 45);
            label10.TabIndex = 40;
            label10.Text = "Ngày";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(59, 182);
            label1.Name = "label1";
            label1.Size = new Size(56, 45);
            label1.TabIndex = 42;
            label1.Text = "Từ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(590, 181);
            label2.Name = "label2";
            label2.Size = new Size(77, 45);
            label2.TabIndex = 43;
            label2.Text = "Đến";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 12F);
            dateTimePicker1.CustomFormat = "  HH : mm";
            dateTimePicker1.Font = new Font("Segoe UI", 12F);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(159, 177);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(324, 50);
            dateTimePicker1.TabIndex = 44;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarFont = new Font("Segoe UI", 12F);
            dateTimePicker2.CustomFormat = "  HH : mm";
            dateTimePicker2.Font = new Font("Segoe UI", 12F);
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(686, 176);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(324, 50);
            dateTimePicker2.TabIndex = 45;
            // 
            // cbRepeat
            // 
            cbRepeat.AutoSize = true;
            cbRepeat.Font = new Font("Segoe UI", 12F);
            cbRepeat.Location = new Point(49, 268);
            cbRepeat.Name = "cbRepeat";
            cbRepeat.Size = new Size(263, 49);
            cbRepeat.TabIndex = 46;
            cbRepeat.Text = "Lịch hẹn lặp lại";
            cbRepeat.UseVisualStyleBackColor = true;
            cbRepeat.CheckedChanged += cbRepeat_CheckedChanged;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.CalendarFont = new Font("Segoe UI", 12F);
            dateTimePicker3.CustomFormat = "  dd / MM / yyyy";
            dateTimePicker3.Font = new Font("Segoe UI", 12F);
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Location = new Point(132, 145);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(324, 50);
            dateTimePicker3.TabIndex = 48;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(32, 145);
            label3.Name = "label3";
            label3.Size = new Size(56, 45);
            label3.TabIndex = 47;
            label3.Text = "Từ";
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.CalendarFont = new Font("Segoe UI", 12F);
            dateTimePicker4.CustomFormat = "  dd / MM / yyyy";
            dateTimePicker4.Font = new Font("Segoe UI", 12F);
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.Location = new Point(663, 146);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(324, 50);
            dateTimePicker4.TabIndex = 50;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(563, 146);
            label4.Name = "label4";
            label4.Size = new Size(77, 45);
            label4.TabIndex = 49;
            label4.Text = "Đến";
            // 
            // flpDay
            // 
            flpDay.Location = new Point(95, 3);
            flpDay.Name = "flpDay";
            flpDay.Size = new Size(864, 109);
            flpDay.TabIndex = 51;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.DodgerBlue;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(717, 751);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(296, 54);
            btnConfirm.TabIndex = 52;
            btnConfirm.Text = "Tạo lịch hẹn mới";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // pnlRepeat
            // 
            pnlRepeat.Controls.Add(flpDay);
            pnlRepeat.Controls.Add(dateTimePicker3);
            pnlRepeat.Controls.Add(dateTimePicker4);
            pnlRepeat.Controls.Add(label3);
            pnlRepeat.Controls.Add(label4);
            pnlRepeat.Location = new Point(26, 323);
            pnlRepeat.Name = "pnlRepeat";
            pnlRepeat.Size = new Size(1007, 200);
            pnlRepeat.TabIndex = 53;
            // 
            // labRoom
            // 
            labRoom.AutoSize = true;
            labRoom.Location = new Point(45, 602);
            labRoom.Name = "labRoom";
            labRoom.Size = new Size(124, 32);
            labRoom.TabIndex = 54;
            labRoom.Text = "Mã Phòng";
            // 
            // cbRoomCode
            // 
            cbRoomCode.FormattingEnabled = true;
            cbRoomCode.Location = new Point(189, 611);
            cbRoomCode.Name = "cbRoomCode";
            cbRoomCode.Size = new Size(242, 40);
            cbRoomCode.TabIndex = 55;
            // 
            // lbSoLuong
            // 
            lbSoLuong.AutoSize = true;
            lbSoLuong.Location = new Point(45, 683);
            lbSoLuong.Name = "lbSoLuong";
            lbSoLuong.Size = new Size(219, 32);
            lbSoLuong.TabIndex = 56;
            lbSoLuong.Text = "Số lượng đặt tối đa";
            // 
            // numMax
            // 
            numMax.Location = new Point(270, 681);
            numMax.Name = "numMax";
            numMax.Size = new Size(240, 39);
            numMax.TabIndex = 58;
            // 
            // ucTimeSlotDialog
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(numMax);
            Controls.Add(lbSoLuong);
            Controls.Add(cbRoomCode);
            Controls.Add(labRoom);
            Controls.Add(pnlRepeat);
            Controls.Add(btnConfirm);
            Controls.Add(cbRepeat);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpDOB);
            Controls.Add(label10);
            Controls.Add(lblCertIndex);
            Controls.Add(btnCancel);
            Name = "ucTimeSlotDialog";
            Size = new Size(1057, 825);
            Load += ucTimeSlotCheckbox_Load;
            pnlRepeat.ResumeLayout(false);
            pnlRepeat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        public Label lblCertIndex;
        private DateTimePicker dtpDOB;
        private Label label10;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private CheckBox cbRepeat;
        private DateTimePicker dateTimePicker3;
        private Label label3;
        private DateTimePicker dateTimePicker4;
        private Label label4;
        private FlowLayoutPanel flpDay;
        private Button btnConfirm;
        private Panel pnlRepeat;
        private Label labRoom;
        private ComboBox cbRoomCode;
        private Label lbSoLuong;
        private NumericUpDown numMax;
    }
}
