namespace UI_Tier
{
    partial class ucAdmin_AppointmentManagement
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            pnlSearchArea = new Panel();
            cbDept = new ComboBox();
            txtSearch = new TextBox();
            picSearch = new PictureBox();
            btnCreateSchedule = new Button();
            pnlTableHead = new Panel();
            lblHeadActions = new Label();
            lblHeadStatus = new Label();
            lblHeadCapacity = new Label();
            lblHeadRoom = new Label();
            lblHeadTime = new Label();
            lblHeadDate = new Label();
            lblHeadDept = new Label();
            lblHeadDoctor = new Label();
            pnlPagination = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            flpAppItem = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlSearchArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            pnlTableHead.SuspendLayout();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(248, 249, 250);
            pnlHeader.Controls.Add(pnlSearchArea);
            pnlHeader.Controls.Add(btnCreateSchedule);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1845, 140);
            pnlHeader.TabIndex = 0;
            // 
            // pnlSearchArea
            // 
            pnlSearchArea.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearchArea.BackColor = Color.White;
            pnlSearchArea.Controls.Add(cbDept);
            pnlSearchArea.Controls.Add(txtSearch);
            pnlSearchArea.Controls.Add(picSearch);
            pnlSearchArea.Location = new Point(40, 25);
            pnlSearchArea.Name = "pnlSearchArea";
            pnlSearchArea.Size = new Size(1350, 90);
            pnlSearchArea.TabIndex = 3;
            pnlSearchArea.Paint += pnlSearchArea_Paint;
            // 
            // cbDept
            // 
            cbDept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDept.FlatStyle = FlatStyle.Flat;
            cbDept.Font = new Font("Segoe UI", 12F);
            cbDept.FormattingEnabled = true;
            cbDept.Location = new Point(1020, 20);
            cbDept.Name = "cbDept";
            cbDept.Size = new Size(300, 53);
            cbDept.TabIndex = 2;
            cbDept.SelectedIndexChanged += cbDept_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 13F);
            txtSearch.Location = new Point(80, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo bác sĩ, khoa, phòng...";
            txtSearch.Size = new Size(920, 47);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // picSearch
            // 
            picSearch.Image = Properties.Resources.search;
            picSearch.Location = new Point(25, 25);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(40, 40);
            picSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picSearch.TabIndex = 0;
            picSearch.TabStop = false;
            // 
            // btnCreateSchedule
            // 
            btnCreateSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateSchedule.BackColor = Color.FromArgb(24, 112, 255);
            btnCreateSchedule.FlatAppearance.BorderSize = 0;
            btnCreateSchedule.FlatStyle = FlatStyle.Flat;
            btnCreateSchedule.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCreateSchedule.ForeColor = Color.White;
            btnCreateSchedule.Location = new Point(1415, 25);
            btnCreateSchedule.Name = "btnCreateSchedule";
            btnCreateSchedule.Size = new Size(380, 90);
            btnCreateSchedule.TabIndex = 2;
            btnCreateSchedule.Text = "+ TẠO LỊCH HẸN";
            btnCreateSchedule.UseVisualStyleBackColor = false;
            btnCreateSchedule.Click += btnCreateSchedule_Click;
            // 
            // pnlTableHead
            // 
            pnlTableHead.BackColor = Color.White;
            pnlTableHead.Controls.Add(lblHeadActions);
            pnlTableHead.Controls.Add(lblHeadStatus);
            pnlTableHead.Controls.Add(lblHeadCapacity);
            pnlTableHead.Controls.Add(lblHeadRoom);
            pnlTableHead.Controls.Add(lblHeadTime);
            pnlTableHead.Controls.Add(lblHeadDate);
            pnlTableHead.Controls.Add(lblHeadDept);
            pnlTableHead.Controls.Add(lblHeadDoctor);
            pnlTableHead.Dock = DockStyle.Top;
            pnlTableHead.Location = new Point(0, 140);
            pnlTableHead.Name = "pnlTableHead";
            pnlTableHead.Size = new Size(1845, 80);
            pnlTableHead.TabIndex = 3;
            pnlTableHead.Paint += pnlTableHead_Paint;
            // 
            // lblHeadActions
            // 
            lblHeadActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHeadActions.AutoSize = true;
            lblHeadActions.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeadActions.Location = new Point(1650, 18);
            lblHeadActions.Name = "lblHeadActions";
            lblHeadActions.Size = new Size(149, 45);
            lblHeadActions.TabIndex = 7;
            lblHeadActions.Text = "Thao tác";
            // 
            // lblHeadStatus
            // 
            lblHeadStatus.AutoSize = true;
            lblHeadStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeadStatus.Location = new Point(1400, 18);
            lblHeadStatus.Name = "lblHeadStatus";
            lblHeadStatus.Size = new Size(170, 45);
            lblHeadStatus.TabIndex = 6;
            lblHeadStatus.Text = "Trạng thái";
            // 
            // lblHeadCapacity
            // 
            lblHeadCapacity.AutoSize = true;
            lblHeadCapacity.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeadCapacity.Location = new Point(1200, 18);
            lblHeadCapacity.Name = "lblHeadCapacity";
            lblHeadCapacity.Size = new Size(153, 45);
            lblHeadCapacity.TabIndex = 5;
            lblHeadCapacity.Text = "Số lượng";
            // 
            // lblHeadRoom
            // 
            lblHeadRoom.AutoSize = true;
            lblHeadRoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeadRoom.Location = new Point(1000, 18);
            lblHeadRoom.Name = "lblHeadRoom";
            lblHeadRoom.Size = new Size(117, 45);
            lblHeadRoom.TabIndex = 4;
            lblHeadRoom.Text = "Phòng";
            // 
            // lblHeadTime
            // 
            lblHeadTime.AutoSize = true;
            lblHeadTime.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeadTime.Location = new Point(780, 18);
            lblHeadTime.Name = "lblHeadTime";
            lblHeadTime.Size = new Size(72, 45);
            lblHeadTime.TabIndex = 3;
            lblHeadTime.Text = "Giờ";
            // 
            // lblHeadDate
            // 
            lblHeadDate.AutoSize = true;
            lblHeadDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeadDate.Location = new Point(580, 18);
            lblHeadDate.Name = "lblHeadDate";
            lblHeadDate.Size = new Size(100, 45);
            lblHeadDate.TabIndex = 2;
            lblHeadDate.Text = "Ngày";
            // 
            // lblHeadDept
            // 
            lblHeadDept.AutoSize = true;
            lblHeadDept.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeadDept.Location = new Point(320, 18);
            lblHeadDept.Name = "lblHeadDept";
            lblHeadDept.Size = new Size(96, 45);
            lblHeadDept.TabIndex = 1;
            lblHeadDept.Text = "Khoa";
            // 
            // lblHeadDoctor
            // 
            lblHeadDoctor.AutoSize = true;
            lblHeadDoctor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeadDoctor.Location = new Point(50, 18);
            lblHeadDoctor.Name = "lblHeadDoctor";
            lblHeadDoctor.Size = new Size(112, 45);
            lblHeadDoctor.TabIndex = 0;
            lblHeadDoctor.Text = "Bác sĩ";
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(242, 247, 255);
            pnlPagination.Controls.Add(lblPageStatus);
            pnlPagination.Controls.Add(lblPrev);
            pnlPagination.Controls.Add(lblNext);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(0, 792);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1845, 70);
            pnlPagination.TabIndex = 1;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblPageStatus.ForeColor = Color.FromArgb(0, 98, 255);
            lblPageStatus.Location = new Point(870, 15);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.Size = new Size(67, 41);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "1 / 1";
            // 
            // lblPrev
            // 
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(100, 116, 139);
            lblPrev.Location = new Point(50, 15);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(250, 40);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "<< Trang trước";
            lblPrev.Click += lblPrev_Click;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.Cursor = Cursors.Hand;
            lblNext.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblNext.ForeColor = Color.FromArgb(100, 116, 139);
            lblNext.Location = new Point(1545, 15);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(250, 40);
            lblNext.TabIndex = 0;
            lblNext.Text = "Trang sau >>";
            lblNext.TextAlign = ContentAlignment.TopRight;
            lblNext.Click += lblNext_Click;
            // 
            // flpAppItem
            // 
            flpAppItem.AutoScroll = true;
            flpAppItem.BackColor = Color.White;
            flpAppItem.Dock = DockStyle.Fill;
            flpAppItem.FlowDirection = FlowDirection.TopDown;
            flpAppItem.Location = new Point(0, 220);
            flpAppItem.Name = "flpAppItem";
            flpAppItem.Padding = new Padding(0, 0, 0, 20);
            flpAppItem.Size = new Size(1845, 572);
            flpAppItem.TabIndex = 2;
            flpAppItem.WrapContents = false;
            // 
            // ucAdmin_AppointmentManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            Controls.Add(flpAppItem);
            Controls.Add(pnlTableHead);
            Controls.Add(pnlPagination);
            Controls.Add(pnlHeader);
            Name = "ucAdmin_AppointmentManagement";
            Size = new Size(1845, 862);
            Load += ucAdmin_AppointmentManagement_Load;
            pnlHeader.ResumeLayout(false);
            pnlSearchArea.ResumeLayout(false);
            pnlSearchArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            pnlTableHead.ResumeLayout(false);
            pnlTableHead.PerformLayout();
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnCreateSchedule;
        private Panel pnlPagination;
        private Label lblPageStatus;
        private Label lblPrev;
        private Label lblNext;
        private FlowLayoutPanel flpAppItem;
        private Panel pnlSearchArea;
        private TextBox txtSearch;
        private PictureBox picSearch;
        private ComboBox cbDept;
        private Panel pnlTableHead;
        private Label lblHeadDoctor;
        private Label lblHeadDept;
        private Label lblHeadDate;
        private Label lblHeadTime;
        private Label lblHeadRoom;
        private Label lblHeadCapacity;
        private Label lblHeadStatus;
        private Label lblHeadActions;
    }
}
