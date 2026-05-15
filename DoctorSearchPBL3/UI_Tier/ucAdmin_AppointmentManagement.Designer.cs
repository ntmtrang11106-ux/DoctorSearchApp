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
            cbStatusFilter = new ComboBox();
            lblTitle = new Label();
            cbDept = new ComboBox();
            pnlSearchArea = new Panel();
            txtSearch = new TextBox();
            picSearch = new PictureBox();
            btnCreateSchedule = new Button();
            flpAppItem = new FlowLayoutPanel();
            lblNoData = new Label();
            pnlReviewPagination = new Panel();
            lblReviewPageStatus = new Label();
            lblReviewPrevBtn = new Label();
            lblReviewNext = new Label();
            pnlBottomBuffer = new Panel();
            pnlResultContainer = new Panel();
            pnlHeader.SuspendLayout();
            pnlSearchArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            flpAppItem.SuspendLayout();
            pnlReviewPagination.SuspendLayout();
            pnlResultContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.WhiteSmoke;
            pnlHeader.Controls.Add(cbStatusFilter);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(cbDept);
            pnlHeader.Controls.Add(pnlSearchArea);
            pnlHeader.Controls.Add(btnCreateSchedule);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1845, 198);
            pnlHeader.TabIndex = 0;
            // 
            // cbStatusFilter
            // 
            cbStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusFilter.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbStatusFilter.FormattingEnabled = true;
            cbStatusFilter.Location = new Point(1124, 124);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.Size = new Size(330, 58);
            cbStatusFilter.TabIndex = 5;
            cbStatusFilter.SelectedIndexChanged += cbStatusFilter_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(27, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(391, 65);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Quản lý lịch hẹn";
            // 
            // cbDept
            // 
            cbDept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDept.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbDept.FormattingEnabled = true;
            cbDept.Location = new Point(1475, 124);
            cbDept.Name = "cbDept";
            cbDept.Size = new Size(353, 58);
            cbDept.TabIndex = 2;
            cbDept.SelectedIndexChanged += cbDept_SelectedIndexChanged;
            // 
            // pnlSearchArea
            // 
            pnlSearchArea.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearchArea.BackColor = Color.White;
            pnlSearchArea.Controls.Add(txtSearch);
            pnlSearchArea.Controls.Add(picSearch);
            pnlSearchArea.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlSearchArea.Location = new Point(27, 81);
            pnlSearchArea.Name = "pnlSearchArea";
            pnlSearchArea.Size = new Size(1063, 90);
            pnlSearchArea.TabIndex = 3;
            pnlSearchArea.Paint += pnlSearchArea_Paint;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(80, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo bác sĩ, khoa, phòng...";
            txtSearch.Size = new Size(958, 50);
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
            btnCreateSchedule.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateSchedule.ForeColor = Color.White;
            btnCreateSchedule.Location = new Point(1448, 5);
            btnCreateSchedule.Name = "btnCreateSchedule";
            btnCreateSchedule.Size = new Size(380, 90);
            btnCreateSchedule.TabIndex = 2;
            btnCreateSchedule.Text = "+ TẠO LỊCH HẸN";
            btnCreateSchedule.UseVisualStyleBackColor = false;
            btnCreateSchedule.Click += btnCreateSchedule_Click;
            // 
            // flpAppItem
            // 
            flpAppItem.AutoScroll = true;
            flpAppItem.BackColor = Color.White;
            flpAppItem.Controls.Add(lblNoData);
            flpAppItem.Dock = DockStyle.Fill;
            flpAppItem.FlowDirection = FlowDirection.TopDown;
            flpAppItem.Location = new Point(5, 5);
            flpAppItem.Name = "flpAppItem";
            flpAppItem.Size = new Size(1835, 649);
            flpAppItem.TabIndex = 2;
            flpAppItem.WrapContents = false;
            // 
            // lblNoData
            // 
            lblNoData.AutoSize = true;
            lblNoData.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            lblNoData.ForeColor = Color.Gray;
            lblNoData.Location = new Point(3, 0);
            lblNoData.Name = "lblNoData";
            lblNoData.Size = new Size(544, 51);
            lblNoData.TabIndex = 7;
            lblNoData.Text = "Không tìm thấy dữ liệu phù hợp";
            lblNoData.Visible = false;
            // 
            // pnlBottomBuffer
            // 
            pnlBottomBuffer.BackColor = Color.White;
            pnlBottomBuffer.Dock = DockStyle.Bottom;
            pnlBottomBuffer.Location = new Point(5, 564);
            pnlBottomBuffer.Name = "pnlBottomBuffer";
            pnlBottomBuffer.Size = new Size(1835, 20);
            pnlBottomBuffer.TabIndex = 6;
            // 
            // pnlReviewPagination
            // 
            pnlReviewPagination.BackColor = Color.FromArgb(242, 246, 250);
            pnlReviewPagination.Controls.Add(lblReviewPageStatus);
            pnlReviewPagination.Controls.Add(lblReviewPrevBtn);
            pnlReviewPagination.Controls.Add(lblReviewNext);
            pnlReviewPagination.Dock = DockStyle.Bottom;
            pnlReviewPagination.Location = new Point(5, 584);
            pnlReviewPagination.Margin = new Padding(5);
            pnlReviewPagination.Name = "pnlReviewPagination";
            pnlReviewPagination.Size = new Size(1835, 80);
            pnlReviewPagination.TabIndex = 5;
            // 
            // lblReviewPageStatus
            // 
            lblReviewPageStatus.Anchor = AnchorStyles.Top;
            lblReviewPageStatus.AutoSize = true;
            lblReviewPageStatus.Font = new Font("Segoe UI", 10.5F);
            lblReviewPageStatus.Location = new Point(843, 20);
            lblReviewPageStatus.Name = "lblReviewPageStatus";
            lblReviewPageStatus.Size = new Size(151, 38);
            lblReviewPageStatus.TabIndex = 2;
            lblReviewPageStatus.Text = "Trang 1 / 1";
            lblReviewPageStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReviewPrevBtn
            // 
            lblReviewPrevBtn.AutoSize = true;
            lblReviewPrevBtn.Cursor = Cursors.Hand;
            lblReviewPrevBtn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblReviewPrevBtn.ForeColor = Color.FromArgb(0, 120, 212);
            lblReviewPrevBtn.Location = new Point(30, 20);
            lblReviewPrevBtn.Name = "lblReviewPrevBtn";
            lblReviewPrevBtn.Size = new Size(219, 38);
            lblReviewPrevBtn.TabIndex = 1;
            lblReviewPrevBtn.Text = "<< Trang trước";
            // 
            // lblReviewNext
            // 
            lblReviewNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblReviewNext.AutoSize = true;
            lblReviewNext.Cursor = Cursors.Hand;
            lblReviewNext.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblReviewNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblReviewNext.Location = new Point(1622, 20);
            lblReviewNext.Name = "lblReviewNext";
            lblReviewNext.Size = new Size(191, 38);
            lblReviewNext.TabIndex = 0;
            lblReviewNext.Text = "Trang sau >>";
            // 
            // pnlResultContainer
            // 
            pnlResultContainer.BackColor = Color.White;
            pnlResultContainer.Controls.Add(flpAppItem);
            pnlResultContainer.Controls.Add(pnlBottomBuffer);
            pnlResultContainer.Controls.Add(pnlReviewPagination);
            pnlResultContainer.Dock = DockStyle.Fill;
            pnlResultContainer.Location = new Point(0, 198);
            pnlResultContainer.Name = "pnlResultContainer";
            pnlResultContainer.Padding = new Padding(5, 5, 5, 10);
            pnlResultContainer.Size = new Size(1845, 664);
            pnlResultContainer.TabIndex = 2;
            // 
            // ucAdmin_AppointmentManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            Controls.Add(pnlResultContainer);
            Controls.Add(pnlHeader);
            Name = "ucAdmin_AppointmentManagement";
            Size = new Size(1845, 862);
            Load += ucAdmin_AppointmentManagement_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearchArea.ResumeLayout(false);
            pnlSearchArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            flpAppItem.ResumeLayout(false);
            flpAppItem.PerformLayout();
            pnlBottomBuffer.ResumeLayout(false);
            pnlReviewPagination.ResumeLayout(false);
            pnlReviewPagination.PerformLayout();
            pnlResultContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnCreateSchedule;
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
        private Label lblTitle;
        private Panel pnlReviewPagination;
        private Label lblReviewPageStatus;
        private Label lblReviewPrevBtn;
        private Label lblReviewNext;
        private Label lblNoData;
        private ComboBox cbStatusFilter;
        private Panel pnlBottomBuffer;
        private Panel pnlResultContainer;
    }
}
