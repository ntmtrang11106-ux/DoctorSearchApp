namespace UI_Tier
{
    partial class ucDoctor_Appointment
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
            panel3 = new Panel();
            btnAddTimeSlot = new Button();
            label4 = new Label();
            label3 = new Label();
            dtpEnd = new DateTimePicker();
            dtpBegin = new DateTimePicker();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            flpFilter = new FlowLayoutPanel();
            btnAll = new Button();
            btnEmpty = new Button();
            btnWaitting = new Button();
            btnAccepted = new Button();
            btnCanceled = new Button();
            btnDone = new Button();
            pnlAlert = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            flpAppItem = new FlowLayoutPanel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            flpFilter.SuspendLayout();
            pnlAlert.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Controls.Add(btnAddTimeSlot);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(dtpEnd);
            panel3.Controls.Add(dtpBegin);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(flpFilter);
            panel3.Controls.Add(pnlAlert);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1845, 528);
            panel3.TabIndex = 6;
            // 
            // btnAddTimeSlot
            // 
            btnAddTimeSlot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddTimeSlot.BackColor = Color.FromArgb(24, 112, 255);
            btnAddTimeSlot.FlatStyle = FlatStyle.Flat;
            btnAddTimeSlot.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTimeSlot.ForeColor = Color.White;
            btnAddTimeSlot.Location = new Point(1332, 268);
            btnAddTimeSlot.Name = "btnAddTimeSlot";
            btnAddTimeSlot.Size = new Size(418, 70);
            btnAddTimeSlot.TabIndex = 29;
            btnAddTimeSlot.Text = "+ Tạo lịch hẹn mới";
            btnAddTimeSlot.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(865, 290);
            label4.Name = "label4";
            label4.Size = new Size(154, 45);
            label4.TabIndex = 28;
            label4.Text = "Đến ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(144, 284);
            label3.Name = "label3";
            label3.Size = new Size(133, 45);
            label3.TabIndex = 27;
            label3.Text = "Từ ngày";
            // 
            // dtpEnd
            // 
            dtpEnd.CalendarFont = new Font("Segoe UI", 12F);
            dtpEnd.CustomFormat = "  dd / MM / yyyy";
            dtpEnd.Font = new Font("Segoe UI", 12F);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(1052, 284);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(360, 50);
            dtpEnd.TabIndex = 26;
            // 
            // dtpBegin
            // 
            dtpBegin.CalendarFont = new Font("Segoe UI", 12F);
            dtpBegin.CustomFormat = "  dd / MM / yyyy";
            dtpBegin.Font = new Font("Segoe UI", 12F);
            dtpBegin.Format = DateTimePickerFormat.Custom;
            dtpBegin.Location = new Point(295, 284);
            dtpBegin.Name = "dtpBegin";
            dtpBegin.Size = new Size(360, 50);
            dtpBegin.TabIndex = 25;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.filter;
            pictureBox2.Location = new Point(56, 284);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(65, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
            label2.Location = new Point(56, 84);
            label2.Name = "label2";
            label2.Size = new Size(542, 47);
            label2.TabIndex = 1;
            label2.Text = "Tạo và quản lý khung giờ của bạn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(43, 12);
            label1.Name = "label1";
            label1.Size = new Size(474, 62);
            label1.TabIndex = 0;
            label1.Text = "Quản lý lịch làm việc";
            // 
            // flpFilter
            // 
            flpFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flpFilter.Controls.Add(btnAll);
            flpFilter.Controls.Add(btnEmpty);
            flpFilter.Controls.Add(btnWaitting);
            flpFilter.Controls.Add(btnAccepted);
            flpFilter.Controls.Add(btnCanceled);
            flpFilter.Controls.Add(btnDone);
            flpFilter.Location = new Point(144, 356);
            flpFilter.Name = "flpFilter";
            flpFilter.Padding = new Padding(10);
            flpFilter.Size = new Size(1653, 77);
            flpFilter.TabIndex = 7;
            // 
            // btnAll
            // 
            btnAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAll.ForeColor = Color.Black;
            btnAll.Location = new Point(13, 13);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(255, 55);
            btnAll.TabIndex = 0;
            btnAll.Text = "Tất cả";
            btnAll.UseVisualStyleBackColor = true;
            // 
            // btnEmpty
            // 
            btnEmpty.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEmpty.Location = new Point(274, 13);
            btnEmpty.Name = "btnEmpty";
            btnEmpty.Size = new Size(255, 55);
            btnEmpty.TabIndex = 3;
            btnEmpty.Text = "Trống";
            btnEmpty.UseVisualStyleBackColor = true;
            // 
            // btnWaitting
            // 
            btnWaitting.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWaitting.Location = new Point(535, 13);
            btnWaitting.Name = "btnWaitting";
            btnWaitting.Size = new Size(255, 55);
            btnWaitting.TabIndex = 3;
            btnWaitting.Text = "Chờ duyệt";
            btnWaitting.UseVisualStyleBackColor = true;
            // 
            // btnAccepted
            // 
            btnAccepted.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAccepted.Location = new Point(796, 13);
            btnAccepted.Name = "btnAccepted";
            btnAccepted.Size = new Size(255, 55);
            btnAccepted.TabIndex = 3;
            btnAccepted.Text = "Đã duyệt";
            btnAccepted.UseVisualStyleBackColor = true;
            // 
            // btnCanceled
            // 
            btnCanceled.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCanceled.Location = new Point(1057, 13);
            btnCanceled.Name = "btnCanceled";
            btnCanceled.Size = new Size(255, 55);
            btnCanceled.TabIndex = 3;
            btnCanceled.Text = "Đã hủy";
            btnCanceled.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            btnDone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDone.Location = new Point(1318, 13);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(255, 55);
            btnDone.TabIndex = 3;
            btnDone.Text = "Hoàn thành";
            btnDone.UseVisualStyleBackColor = true;
            // 
            // pnlAlert
            // 
            pnlAlert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAlert.BackColor = Color.AliceBlue;
            pnlAlert.Controls.Add(lblPageStatus);
            pnlAlert.Controls.Add(lblPrev);
            pnlAlert.Controls.Add(lblNext);
            pnlAlert.Location = new Point(0, 458);
            pnlAlert.Name = "pnlAlert";
            pnlAlert.Padding = new Padding(10);
            pnlAlert.Size = new Size(1845, 67);
            pnlAlert.TabIndex = 8;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 11F);
            lblPageStatus.Location = new Point(1396, 16);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.RightToLeft = RightToLeft.No;
            lblPageStatus.Size = new Size(67, 41);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "1/...";
            // 
            // lblPrev
            // 
            lblPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPrev.AutoSize = true;
            lblPrev.Font = new Font("Segoe UI", 11F);
            lblPrev.Location = new Point(1157, 16);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(219, 41);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "Trang trước <<";
            lblPrev.Click += lblPrev_Click;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Font = new Font("Segoe UI", 11F);
            lblNext.Location = new Point(1590, 16);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(194, 41);
            lblNext.TabIndex = 0;
            lblNext.Text = ">> Trang sau";
            lblNext.Click += lblNext_Click;
            // 
            // flpAppItem
            // 
            flpAppItem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpAppItem.AutoScroll = true;
            flpAppItem.FlowDirection = FlowDirection.TopDown;
            flpAppItem.Location = new Point(0, 528);
            flpAppItem.Margin = new Padding(0);
            flpAppItem.Name = "flpAppItem";
            flpAppItem.Size = new Size(1845, 334);
            flpAppItem.TabIndex = 7;
            flpAppItem.WrapContents = false;
            // 
            // ucDoctor_Appointment
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpAppItem);
            Controls.Add(panel3);
            Name = "ucDoctor_Appointment";
            Size = new Size(1845, 862);
            Load += ucDoctor_Appointment_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            flpFilter.ResumeLayout(false);
            pnlAlert.ResumeLayout(false);
            pnlAlert.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel flpFilter;
        private Button btnAll;
        private Button btnEmpty;
        private Button btnWaitting;
        private Button btnAccepted;
        private Button btnCanceled;
        private Button btnDone;
        private Panel pnlAlert;
        private Label lblPageStatus;
        private Label lblPrev;
        private Label lblNext;
        private FlowLayoutPanel flpAppItem;
        private DateTimePicker dtpBegin;
        private Label label4;
        private Label label3;
        private DateTimePicker dtpEnd;
        private Button btnAddTimeSlot;
    }
}
