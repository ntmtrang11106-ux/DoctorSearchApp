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
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            label1 = new Label();
            cboStatusFilter = new ComboBox();
            pnlTableHeaders = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            flpList = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlTableHeaders.SuspendLayout();
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
            btnAdd.Location = new Point(1020, 30);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(220, 60);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "+  Thêm mới";
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
            lblDesc.Size = new Size(571, 41);
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
            lblTitle.Size = new Size(475, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý chuyên khoa";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(243, 244, 246);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(label1);
            pnlSearch.Location = new Point(20, 150);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(950, 60);
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
            txtSearch.Size = new Size(870, 43);
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
            label1.Size = new Size(40, 40);
            label1.TabIndex = 0;
            label1.Text = "";
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusFilter.Font = new Font("Segoe UI", 12F);
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Items.AddRange(new object[] { "Tất cả trạng thái", "Hiển thị", "Ẩn" });
            cboStatusFilter.Location = new Point(990, 150);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(290, 53);
            cboStatusFilter.TabIndex = 2;
            // 
            // pnlTableHeaders
            // 
            pnlTableHeaders.BackColor = Color.FromArgb(249, 250, 251);
            pnlTableHeaders.Controls.Add(label6);
            pnlTableHeaders.Controls.Add(label5);
            pnlTableHeaders.Controls.Add(label4);
            pnlTableHeaders.Controls.Add(label3);
            pnlTableHeaders.Controls.Add(label2);
            pnlTableHeaders.Location = new Point(20, 240);
            pnlTableHeaders.Name = "pnlTableHeaders";
            pnlTableHeaders.Size = new Size(1260, 60);
            pnlTableHeaders.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(17, 24, 39);
            label6.Location = new Point(1050, 15);
            label6.Name = "label6";
            label6.Size = new Size(155, 37);
            label6.TabIndex = 4;
            label6.Text = "Hành động";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(17, 24, 39);
            label5.Location = new Point(780, 15);
            label5.Name = "label5";
            label5.Size = new Size(147, 37);
            label5.TabIndex = 3;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(17, 24, 39);
            label4.Location = new Point(600, 15);
            label4.Name = "label4";
            label4.Size = new Size(130, 37);
            label4.TabIndex = 2;
            label4.Text = "Số lượng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(17, 24, 39);
            label3.Location = new Point(250, 15);
            label3.Name = "label3";
            label3.Size = new Size(91, 37);
            label3.TabIndex = 1;
            label3.Text = "Mô tả";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(17, 24, 39);
            label2.Location = new Point(20, 15);
            label2.Name = "label2";
            label2.Size = new Size(62, 37);
            label2.TabIndex = 0;
            label2.Text = "Tên";
            // 
            // flpList
            // 
            flpList.AutoScroll = true;
            flpList.Dock = DockStyle.Bottom;
            flpList.Location = new Point(20, 300);
            flpList.Name = "flpList";
            flpList.Size = new Size(1260, 680);
            flpList.TabIndex = 4;
            // 
            // ucAdmin_DepartmentManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpList);
            Controls.Add(pnlTableHeaders);
            Controls.Add(cboStatusFilter);
            Controls.Add(pnlSearch);
            Controls.Add(pnlHeader);
            Name = "ucAdmin_DepartmentManagement";
            Padding = new Padding(20);
            Size = new Size(1300, 1000);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlTableHeaders.ResumeLayout(false);
            pnlTableHeaders.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblDesc;
        private Button btnAdd;
        private Panel pnlSearch;
        private TextBox txtSearch;
        private Label label1;
        private ComboBox cboStatusFilter;
        private Panel pnlTableHeaders;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private FlowLayoutPanel flpList;
    }
}
