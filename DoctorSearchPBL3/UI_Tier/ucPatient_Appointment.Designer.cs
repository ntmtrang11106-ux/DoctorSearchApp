namespace UI_Tier
{
    partial class ucPatient_Appointment
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
            label4 = new Label();
            label3 = new Label();
            dtpEnd = new DateTimePicker();
            dtpBegin = new DateTimePicker();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            flpFilter = new FlowLayoutPanel();
            btnAll = new Button();
            btnWaitting = new Button();
            btnAccepted = new Button();
            btnCanceled = new Button();
            btnDone = new Button();
            flpAppItem = new FlowLayoutPanel();
            pnlPagination = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            pnlResultContainer = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            flpFilter.SuspendLayout();
            pnlPagination.SuspendLayout();
            pnlResultContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(dtpEnd);
            panel3.Controls.Add(dtpBegin);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(flpFilter);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1845, 332);
            panel3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(860, 166);
            label4.Name = "label4";
            label4.Size = new Size(154, 45);
            label4.TabIndex = 28;
            label4.Text = "Đến ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(144, 166);
            label3.Name = "label3";
            label3.Size = new Size(133, 45);
            label3.TabIndex = 27;
            label3.Text = "Từ ngày";
            // 
            // dtpEnd
            // 
            dtpEnd.CalendarFont = new Font("Segoe UI", 12F);
            dtpEnd.CustomFormat = "  dd / MM / yyyy";
            dtpEnd.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(1045, 166);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(360, 57);
            dtpEnd.TabIndex = 26;
            // 
            // dtpBegin
            // 
            dtpBegin.CalendarFont = new Font("Segoe UI", 12F);
            dtpBegin.CustomFormat = "  dd / MM / yyyy";
            dtpBegin.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpBegin.Format = DateTimePickerFormat.Custom;
            dtpBegin.Location = new Point(294, 166);
            dtpBegin.Name = "dtpBegin";
            dtpBegin.Size = new Size(360, 57);
            dtpBegin.TabIndex = 25;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.filter;
            pictureBox2.Location = new Point(56, 166);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(65, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.875F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 84);
            label2.Name = "label2";
            label2.Size = new Size(724, 50);
            label2.TabIndex = 1;
            label2.Text = "Theo dõi lịch hẹn và kết quả khám sức khỏe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 12);
            label1.Name = "label1";
            label1.Size = new Size(342, 59);
            label1.TabIndex = 0;
            label1.Text = "Lịch hẹn của tôi";
            // 
            // flpFilter
            // 
            flpFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flpFilter.Controls.Add(btnAll);
            flpFilter.Controls.Add(btnWaitting);
            flpFilter.Controls.Add(btnAccepted);
            flpFilter.Controls.Add(btnCanceled);
            flpFilter.Controls.Add(btnDone);
            flpFilter.Location = new Point(144, 249);
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
            // btnWaitting
            // 
            btnWaitting.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWaitting.Location = new Point(274, 13);
            btnWaitting.Name = "btnWaitting";
            btnWaitting.Size = new Size(255, 55);
            btnWaitting.TabIndex = 3;
            btnWaitting.Text = "Chờ duyệt";
            btnWaitting.UseVisualStyleBackColor = true;
            // 
            // btnAccepted
            // 
            btnAccepted.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAccepted.Location = new Point(535, 13);
            btnAccepted.Name = "btnAccepted";
            btnAccepted.Size = new Size(255, 55);
            btnAccepted.TabIndex = 3;
            btnAccepted.Text = "Đã duyệt";
            btnAccepted.UseVisualStyleBackColor = true;
            // 
            // btnCanceled
            // 
            btnCanceled.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCanceled.Location = new Point(796, 13);
            btnCanceled.Name = "btnCanceled";
            btnCanceled.Size = new Size(255, 55);
            btnCanceled.TabIndex = 3;
            btnCanceled.Text = "Đã hủy";
            btnCanceled.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            btnDone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDone.Location = new Point(1057, 13);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(255, 55);
            btnDone.TabIndex = 3;
            btnDone.Text = "Hoàn thành";
            btnDone.UseVisualStyleBackColor = true;
            // 
            // flpAppItem
            // 
            flpAppItem.AutoScroll = true;
            flpAppItem.Dock = DockStyle.Fill;
            flpAppItem.FlowDirection = FlowDirection.TopDown;
            flpAppItem.Location = new Point(20, 10);
            flpAppItem.Margin = new Padding(0);
            flpAppItem.Name = "flpAppItem";
            flpAppItem.Size = new Size(1805, 404);
            flpAppItem.TabIndex = 7;
            flpAppItem.WrapContents = false;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(240, 245, 250);
            pnlPagination.Controls.Add(lblPageStatus);
            pnlPagination.Controls.Add(lblPrev);
            pnlPagination.Controls.Add(lblNext);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(0, 782);
            pnlPagination.Margin = new Padding(5);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1845, 80);
            pnlPagination.TabIndex = 8;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 11F);
            lblPageStatus.Location = new Point(843, 24);
            lblPageStatus.Margin = new Padding(5, 0, 5, 0);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.Size = new Size(159, 41);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "Trang 1 / 1";
            // 
            // lblPrev
            // 
            lblPrev.AutoSize = true;
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblPrev.Location = new Point(60, 24);
            lblPrev.Margin = new Padding(5, 0, 5, 0);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(234, 41);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "<< Trang trước";
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Cursor = Cursors.Hand;
            lblNext.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.Location = new Point(1581, 24);
            lblNext.Margin = new Padding(5, 0, 5, 0);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(204, 41);
            lblNext.TabIndex = 0;
            lblNext.Text = "Trang sau >>";
            // 
            // pnlResultContainer
            // 
            pnlResultContainer.Controls.Add(flpAppItem);
            pnlResultContainer.Dock = DockStyle.Fill;
            pnlResultContainer.Location = new Point(0, 332);
            pnlResultContainer.Margin = new Padding(10);
            pnlResultContainer.Name = "pnlResultContainer";
            pnlResultContainer.Padding = new Padding(5, 5, 5, 10);
            pnlResultContainer.Size = new Size(1845, 450);
            pnlResultContainer.TabIndex = 9;
            // 
            // ucPatient_Appointment
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlResultContainer);
            Controls.Add(pnlPagination);
            Controls.Add(panel3);
            Name = "ucPatient_Appointment";
            Size = new Size(1845, 862);
            Load += ucPatient_Appointment_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            flpFilter.ResumeLayout(false);
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            pnlResultContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel flpFilter;
        private Button btnAll;
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
        private Panel pnlPagination;
        private Panel pnlResultContainer;
    }
}
