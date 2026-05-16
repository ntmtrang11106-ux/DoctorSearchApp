namespace UI_Tier
{
    partial class ucAdmin_DepartmentManagement
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

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnAdd = new Button();
            lblDesc = new Label();
            lblTitle = new Label();
            pnlFilter = new Panel();
            cboStatusFilter = new ComboBox();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            lblSearchIcon = new Label();
            flpList = new FlowLayoutPanel();
            pnlPagination = new Panel();
            lblNext = new Label();
            lblPrev = new Label();
            lblPageStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.WhiteSmoke;
            pnlHeader.Controls.Add(btnAdd);
            pnlHeader.Controls.Add(lblDesc);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(5, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1290, 120);
            pnlHeader.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(37, 99, 235);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(774, 29);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(486, 70);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "+  Thêm chuyên khoa mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblDesc.Location = new Point(5, 65);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(744, 50);
            lblDesc.TabIndex = 1;
            lblDesc.Text = "Thêm, sửa, xóa và quản lý trạng thái hiển thị";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(448, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý chuyên khoa";
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(cboStatusFilter);
            pnlFilter.Controls.Add(pnlSearch);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(5, 125);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1290, 95);
            pnlFilter.TabIndex = 1;
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusFilter.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Items.AddRange(new object[] { "Tất cả trạng thái", "Hiển thị", "Ẩn" });
            cboStatusFilter.Location = new Point(928, 10);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(320, 58);
            cboStatusFilter.TabIndex = 2;
            cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(243, 244, 246);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearchIcon);
            pnlSearch.Location = new Point(0, 10);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(15, 12, 15, 12);
            pnlSearch.Size = new Size(880, 70);
            pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(243, 244, 246);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 14F);
            txtSearch.Location = new Point(70, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(800, 50);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.AutoSize = true;
            lblSearchIcon.Font = new Font("Segoe MDL2 Assets", 16F);
            lblSearchIcon.ForeColor = Color.FromArgb(156, 163, 175);
            lblSearchIcon.Location = new Point(15, 13);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(62, 43);
            lblSearchIcon.TabIndex = 0;
            lblSearchIcon.Text = "";
            // 
            // flpList
            // 
            flpList.AutoScroll = true;
            flpList.Dock = DockStyle.Fill;
            flpList.Location = new Point(5, 220);
            flpList.Margin = new Padding(10);
            flpList.Name = "flpList";
            flpList.Padding = new Padding(10);
            flpList.Size = new Size(1290, 700);
            flpList.TabIndex = 4;
            flpList.Resize += flpList_Resize;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(242, 246, 250);
            pnlPagination.Controls.Add(lblNext);
            pnlPagination.Controls.Add(lblPrev);
            pnlPagination.Controls.Add(lblPageStatus);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(5, 920);
            pnlPagination.Margin = new Padding(5);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1290, 80);
            pnlPagination.TabIndex = 5;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Cursor = Cursors.Hand;
            lblNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.Location = new Point(1075, 24);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(185, 37);
            lblNext.TabIndex = 0;
            lblNext.Text = "Trang sau >>";
            // 
            // lblPrev
            // 
            lblPrev.AutoSize = true;
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblPrev.Location = new Point(24, 24);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(212, 37);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "<< Trang trước";
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.None;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 10F);
            lblPageStatus.Location = new Point(574, 24);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.Size = new Size(145, 37);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "Trang 1 / 1";
            lblPageStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucAdmin_DepartmentManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpList);
            Controls.Add(pnlPagination);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Margin = new Padding(10);
            Name = "ucAdmin_DepartmentManagement";
            Padding = new Padding(5, 5, 5, 0);
            Size = new Size(1300, 1000);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblDesc;
        private Button btnAdd;
        private Panel pnlFilter;
        private Panel pnlSearch;
        private TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private ComboBox cboStatusFilter;
        private FlowLayoutPanel flpList;
        private Panel pnlPagination;
        private Button btnNext;
        private Button btnPrev;
        private Label lblPageInfo;
        private Label lblNext;
        private Label lblPrev;
        private Label lblPageStatus;
    }
}
