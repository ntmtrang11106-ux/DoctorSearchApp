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
            cbCapacity = new ComboBox();
            pnlHeader = new Panel();
            flpFilter = new FlowLayoutPanel();
            lblTitle = new Label();
            pnlSearchArea = new Panel();
            label2 = new Label();
            txtSearch = new TextBox();
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
            flpAppItem.SuspendLayout();
            pnlReviewPagination.SuspendLayout();
            pnlResultContainer.SuspendLayout();
            SuspendLayout();
            // 
            // cbCapacity
            // 
            cbCapacity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbCapacity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCapacity.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbCapacity.FormattingEnabled = true;
            cbCapacity.Location = new Point(1475, 116);
            cbCapacity.Name = "cbCapacity";
            cbCapacity.Size = new Size(353, 58);
            cbCapacity.TabIndex = 6;
            cbCapacity.SelectedIndexChanged += cbCapacity_SelectedIndexChanged;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(flpFilter);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(cbCapacity);
            pnlHeader.Controls.Add(pnlSearchArea);
            pnlHeader.Controls.Add(btnCreateSchedule);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1845, 290);
            pnlHeader.TabIndex = 0;
            // 
            // flpFilter
            // 
            flpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpFilter.Location = new Point(27, 200);
            flpFilter.Name = "flpFilter";
            flpFilter.Size = new Size(1783, 70);
            flpFilter.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(27, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(391, 65);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Quản lý lịch hẹn";
            // 
            // pnlSearchArea
            // 
            pnlSearchArea.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearchArea.BackColor = Color.White;
            pnlSearchArea.Controls.Add(label2);
            pnlSearchArea.Controls.Add(txtSearch);
            pnlSearchArea.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlSearchArea.Location = new Point(27, 103);
            pnlSearchArea.Name = "pnlSearchArea";
            pnlSearchArea.Size = new Size(885, 78);
            pnlSearchArea.TabIndex = 3;
            pnlSearchArea.Paint += pnlSearchArea_Paint;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe MDL2 Assets", 17F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(8, 11);
            label2.Name = "label2";
            label2.Size = new Size(75, 75);
            label2.TabIndex = 2;
            label2.Text = "";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(102, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm bác sĩ theo khoa, tên phòng...";
            txtSearch.Size = new Size(780, 50);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnCreateSchedule
            // 
            btnCreateSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateSchedule.BackColor = Color.FromArgb(24, 112, 255);
            btnCreateSchedule.FlatAppearance.BorderSize = 0;
            btnCreateSchedule.FlatStyle = FlatStyle.Flat;
            btnCreateSchedule.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateSchedule.ForeColor = Color.White;
            btnCreateSchedule.Location = new Point(1448, 18);
            btnCreateSchedule.Name = "btnCreateSchedule";
            btnCreateSchedule.Size = new Size(362, 72);
            btnCreateSchedule.TabIndex = 2;
            btnCreateSchedule.Text = "+ Tạo lịch hẹn";
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
            flpAppItem.Size = new Size(1835, 457);
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
            // pnlReviewPagination
            // 
            pnlReviewPagination.BackColor = Color.FromArgb(242, 246, 250);
            pnlReviewPagination.Controls.Add(lblReviewPageStatus);
            pnlReviewPagination.Controls.Add(lblReviewPrevBtn);
            pnlReviewPagination.Controls.Add(lblReviewNext);
            pnlReviewPagination.Dock = DockStyle.Bottom;
            pnlReviewPagination.Location = new Point(5, 482);
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
            // pnlBottomBuffer
            // 
            pnlBottomBuffer.BackColor = Color.White;
            pnlBottomBuffer.Dock = DockStyle.Bottom;
            pnlBottomBuffer.Location = new Point(5, 462);
            pnlBottomBuffer.Name = "pnlBottomBuffer";
            pnlBottomBuffer.Size = new Size(1835, 20);
            pnlBottomBuffer.TabIndex = 6;
            // 
            // pnlResultContainer
            // 
            pnlResultContainer.BackColor = Color.White;
            pnlResultContainer.Controls.Add(flpAppItem);
            pnlResultContainer.Controls.Add(pnlBottomBuffer);
            pnlResultContainer.Controls.Add(pnlReviewPagination);
            pnlResultContainer.Dock = DockStyle.Fill;
            pnlResultContainer.Location = new Point(0, 290);
            pnlResultContainer.Name = "pnlResultContainer";
            pnlResultContainer.Padding = new Padding(5, 5, 5, 10);
            pnlResultContainer.Size = new Size(1845, 572);
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
            flpAppItem.ResumeLayout(false);
            flpAppItem.PerformLayout();
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
        private FlowLayoutPanel flpFilter;
        private Panel pnlBottomBuffer;
        private Panel pnlResultContainer;
        private Label label2;
        private ComboBox cbCapacity;
    }
}
