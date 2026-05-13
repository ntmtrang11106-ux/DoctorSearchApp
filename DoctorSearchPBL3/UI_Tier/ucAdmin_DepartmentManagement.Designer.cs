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
            label1 = new Label();
            flpList = new FlowLayoutPanel();
            pnlPagination = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnAdd);
            pnlHeader.Controls.Add(lblDesc);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1260, 120);
            pnlHeader.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(37, 99, 235);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(850, 30);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(380, 60);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "+  Thêm chuyên khoa mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 11F);
            lblDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblDesc.Location = new Point(5, 65);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(600, 41);
            lblDesc.TabIndex = 1;
            lblDesc.Text = "Thêm, sửa, xóa và quản lý trạng thái hiển thị";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý chuyên khoa";
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(cboStatusFilter);
            pnlFilter.Controls.Add(pnlSearch);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(20, 140);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1260, 80);
            pnlFilter.TabIndex = 1;
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusFilter.Font = new Font("Segoe UI", 12F);
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Items.AddRange(new object[] { "Tất cả trạng thái", "Hiển thị", "Ẩn" });
            cboStatusFilter.Location = new Point(910, 10);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(320, 53);
            cboStatusFilter.TabIndex = 2;
            cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(243, 244, 246);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(label1);
            pnlSearch.Location = new Point(0, 10);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(880, 60);
            pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(243, 244, 246);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(60, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm...";
            txtSearch.Size = new Size(800, 43);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe MDL2 Assets", 15F);
            label1.ForeColor = Color.FromArgb(156, 163, 175);
            label1.Location = new Point(15, 10);
            label1.Name = "label1";
            label1.Size = new Size(57, 40);
            label1.TabIndex = 0;
            label1.Text = "";
            // 
            // flpList
            // 
            flpList.AutoScroll = true;
            flpList.Dock = DockStyle.Fill;
            flpList.Location = new Point(20, 220);
            flpList.Name = "flpList";
            flpList.Size = new Size(1260, 680);
            flpList.TabIndex = 4;
            flpList.Resize += flpList_Resize;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.FromArgb(243, 246, 249);
            pnlPagination.Controls.Add(lblPageInfo);
            pnlPagination.Controls.Add(btnNext);
            pnlPagination.Controls.Add(btnPrev);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(20, 900);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1260, 80);
            pnlPagination.TabIndex = 5;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Dock = DockStyle.Fill;
            lblPageInfo.Font = new Font("Segoe UI", 11F);
            lblPageInfo.ForeColor = Color.FromArgb(17, 24, 39);
            lblPageInfo.Location = new Point(250, 0);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(760, 80);
            lblPageInfo.TabIndex = 2;
            lblPageInfo.Text = "Trang 1 / 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.AutoSize = true;
            btnNext.Dock = DockStyle.Right;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(37, 99, 235);
            btnNext.Location = new Point(1010, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(250, 80);
            btnNext.TabIndex = 1;
            btnNext.Text = "Trang sau >>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.AutoSize = true;
            btnPrev.Dock = DockStyle.Left;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrev.ForeColor = Color.FromArgb(37, 99, 235);
            btnPrev.Location = new Point(0, 0);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(250, 80);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "<< Trang trước";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
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
            Name = "ucAdmin_DepartmentManagement";
            Padding = new Padding(20);
            Size = new Size(1300, 1000);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblDesc;
        private Button btnAdd;
        private Panel pnlFilter;
        private Panel pnlSearch;
        private TextBox txtSearch;
        private Label label1;
        private ComboBox cboStatusFilter;
        private FlowLayoutPanel flpList;
        private Panel pnlPagination;
        private Button btnNext;
        private Button btnPrev;
        private Label lblPageInfo;
    }
}
