namespace UI_Tier
{
    partial class ucAdmin_AddArticle
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
            label1 = new Label();
            lblHeaderTitle = new Label();
            btnCancelTop = new Button();
            lblTitleLabel = new Label();
            txtTitle = new TextBox();
            lblSummaryLabel = new Label();
            txtSummary = new TextBox();
            lblBodyLabel = new Label();
            rtbBody = new RichTextBox();
            lblTypeLabel = new Label();
            cboType = new ComboBox();
            lblDeptLabel = new Label();
            cboDept = new ComboBox();
            lblStatusLabel = new Label();
            cboStatus = new ComboBox();
            lblPriorityLabel = new Label();
            numPriority = new NumericUpDown();
            chkPinned = new CheckBox();
            lblThumbnailLabel = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            panel29 = new Panel();
            label24 = new Label();
            pnlTitleBorder = new Panel();
            pnlSummaryBorder = new Panel();
            pnlBodyBorder = new Panel();
            pnlTypeBorder = new Panel();
            pnlDeptBorder = new Panel();
            pnlStatusBorder = new Panel();
            pnlPriorityBorder = new Panel();
            pnlMainBackground = new Panel();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPriority).BeginInit();
            panel29.SuspendLayout();
            pnlTitleBorder.SuspendLayout();
            pnlSummaryBorder.SuspendLayout();
            pnlBodyBorder.SuspendLayout();
            pnlTypeBorder.SuspendLayout();
            pnlDeptBorder.SuspendLayout();
            pnlStatusBorder.SuspendLayout();
            pnlPriorityBorder.SuspendLayout();
            pnlMainBackground.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(60, 140, 250);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(btnCancelTop);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(994, 100);
            pnlHeader.TabIndex = 0;
            pnlHeader.MouseDown += panelHeader_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 17);
            label1.Name = "label1";
            label1.Size = new Size(68, 71);
            label1.TabIndex = 3;
            label1.Text = "+";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(100, 25);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(391, 59);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Thêm bài viết mới";
            // 
            // btnCancelTop
            // 
            btnCancelTop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelTop.FlatAppearance.BorderSize = 0;
            btnCancelTop.FlatStyle = FlatStyle.Flat;
            btnCancelTop.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelTop.ForeColor = Color.White;
            btnCancelTop.Location = new Point(924, -2);
            btnCancelTop.Name = "btnCancelTop";
            btnCancelTop.Size = new Size(50, 92);
            btnCancelTop.TabIndex = 2;
            btnCancelTop.Text = "x";
            btnCancelTop.UseVisualStyleBackColor = true;
            btnCancelTop.Click += btnCancel_Click;
            // 
            // lblTitleLabel
            // 
            lblTitleLabel.AutoSize = true;
            lblTitleLabel.BackColor = Color.White;
            lblTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitleLabel.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitleLabel.Location = new Point(40, 121);
            lblTitleLabel.Name = "lblTitleLabel";
            lblTitleLabel.Size = new Size(130, 41);
            lblTitleLabel.TabIndex = 1;
            lblTitleLabel.Text = "Tiêu đề:";
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.None;
            txtTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(10, 14);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(889, 43);
            txtTitle.TabIndex = 0;
            // 
            // lblSummaryLabel
            // 
            lblSummaryLabel.AutoSize = true;
            lblSummaryLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSummaryLabel.ForeColor = Color.FromArgb(64, 64, 64);
            lblSummaryLabel.Location = new Point(40, 247);
            lblSummaryLabel.Name = "lblSummaryLabel";
            lblSummaryLabel.Size = new Size(134, 41);
            lblSummaryLabel.TabIndex = 3;
            lblSummaryLabel.Text = "Tóm tắt:";
            // 
            // txtSummary
            // 
            txtSummary.BorderStyle = BorderStyle.None;
            txtSummary.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSummary.Location = new Point(10, 10);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.Size = new Size(889, 126);
            txtSummary.TabIndex = 0;
            // 
            // lblBodyLabel
            // 
            lblBodyLabel.AutoSize = true;
            lblBodyLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBodyLabel.ForeColor = Color.FromArgb(64, 64, 64);
            lblBodyLabel.Location = new Point(40, 444);
            lblBodyLabel.Name = "lblBodyLabel";
            lblBodyLabel.Size = new Size(154, 40);
            lblBodyLabel.TabIndex = 5;
            lblBodyLabel.Text = "Nội dung:";
            // 
            // rtbBody
            // 
            rtbBody.BorderStyle = BorderStyle.None;
            rtbBody.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbBody.Location = new Point(10, 13);
            rtbBody.Name = "rtbBody";
            rtbBody.Size = new Size(889, 287);
            rtbBody.TabIndex = 0;
            rtbBody.Text = "";
            // 
            // lblTypeLabel
            // 
            lblTypeLabel.AutoSize = true;
            lblTypeLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTypeLabel.ForeColor = Color.FromArgb(64, 64, 64);
            lblTypeLabel.Location = new Point(40, 812);
            lblTypeLabel.Name = "lblTypeLabel";
            lblTypeLabel.Size = new Size(214, 40);
            lblTypeLabel.TabIndex = 7;
            lblTypeLabel.Text = "Loại nội dung:";
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.FlatStyle = FlatStyle.Flat;
            cboType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(12, 8);
            cboType.Name = "cboType";
            cboType.Size = new Size(370, 53);
            cboType.TabIndex = 0;
            // 
            // lblDeptLabel
            // 
            lblDeptLabel.AutoSize = true;
            lblDeptLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeptLabel.ForeColor = Color.FromArgb(64, 64, 64);
            lblDeptLabel.Location = new Point(523, 812);
            lblDeptLabel.Name = "lblDeptLabel";
            lblDeptLabel.Size = new Size(203, 40);
            lblDeptLabel.TabIndex = 9;
            lblDeptLabel.Text = "Chuyên khoa:";
            // 
            // cboDept
            // 
            cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDept.FlatStyle = FlatStyle.Flat;
            cboDept.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboDept.FormattingEnabled = true;
            cboDept.Location = new Point(10, 7);
            cboDept.Name = "cboDept";
            cboDept.Size = new Size(399, 53);
            cboDept.TabIndex = 0;
            // 
            // lblStatusLabel
            // 
            lblStatusLabel.AutoSize = true;
            lblStatusLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusLabel.ForeColor = Color.FromArgb(64, 64, 64);
            lblStatusLabel.Location = new Point(40, 939);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(164, 40);
            lblStatusLabel.TabIndex = 11;
            lblStatusLabel.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FlatStyle = FlatStyle.Flat;
            cboStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(10, 9);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(370, 53);
            cboStatus.TabIndex = 0;
            // 
            // lblPriorityLabel
            // 
            lblPriorityLabel.AutoSize = true;
            lblPriorityLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPriorityLabel.ForeColor = Color.FromArgb(64, 64, 64);
            lblPriorityLabel.Location = new Point(527, 941);
            lblPriorityLabel.Name = "lblPriorityLabel";
            lblPriorityLabel.Size = new Size(127, 40);
            lblPriorityLabel.TabIndex = 13;
            lblPriorityLabel.Text = "Ưu tiên:";
            // 
            // numPriority
            // 
            numPriority.BorderStyle = BorderStyle.None;
            numPriority.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numPriority.Location = new Point(10, 12);
            numPriority.Name = "numPriority";
            numPriority.Size = new Size(137, 46);
            numPriority.TabIndex = 0;
            // 
            // chkPinned
            // 
            chkPinned.AutoSize = true;
            chkPinned.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkPinned.ForeColor = Color.FromArgb(64, 64, 64);
            chkPinned.Location = new Point(743, 995);
            chkPinned.Name = "chkPinned";
            chkPinned.Size = new Size(187, 49);
            chkPinned.TabIndex = 15;
            chkPinned.Text = "Ghim bài";
            chkPinned.UseVisualStyleBackColor = true;
            // 
            // lblThumbnailLabel
            // 
            lblThumbnailLabel.AutoSize = true;
            lblThumbnailLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThumbnailLabel.ForeColor = Color.FromArgb(64, 64, 64);
            lblThumbnailLabel.Location = new Point(40, 1064);
            lblThumbnailLabel.Name = "lblThumbnailLabel";
            lblThumbnailLabel.Size = new Size(149, 40);
            lblThumbnailLabel.TabIndex = 16;
            lblThumbnailLabel.Text = "Hình ảnh:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(563, 1205);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(350, 70);
            btnSave.TabIndex = 19;
            btnSave.Text = "Lưu bài viết";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(71, 85, 105);
            btnCancel.Location = new Point(80, 1205);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(350, 70);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Hủy bỏ";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel29
            // 
            panel29.BackColor = Color.White;
            panel29.Controls.Add(label24);
            panel29.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel29.Location = new Point(40, 1107);
            panel29.Name = "panel29";
            panel29.Size = new Size(912, 73);
            panel29.TabIndex = 24;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = Color.Transparent;
            label24.Font = new Font("Segoe UI", 11F);
            label24.ForeColor = SystemColors.ControlDarkDark;
            label24.Location = new Point(258, 16);
            label24.Name = "label24";
            label24.Size = new Size(374, 41);
            label24.TabIndex = 22;
            label24.Text = "Bấm vào đây để tải ảnh lên";
            // 
            // pnlTitleBorder
            // 
            pnlTitleBorder.BackColor = Color.White;
            pnlTitleBorder.Controls.Add(txtTitle);
            pnlTitleBorder.Location = new Point(40, 166);
            pnlTitleBorder.Name = "pnlTitleBorder";
            pnlTitleBorder.Padding = new Padding(10, 5, 10, 5);
            pnlTitleBorder.Size = new Size(912, 70);
            pnlTitleBorder.TabIndex = 2;
            // 
            // pnlSummaryBorder
            // 
            pnlSummaryBorder.BackColor = Color.White;
            pnlSummaryBorder.Controls.Add(txtSummary);
            pnlSummaryBorder.Location = new Point(40, 292);
            pnlSummaryBorder.Name = "pnlSummaryBorder";
            pnlSummaryBorder.Padding = new Padding(10);
            pnlSummaryBorder.Size = new Size(912, 149);
            pnlSummaryBorder.TabIndex = 4;
            // 
            // pnlBodyBorder
            // 
            pnlBodyBorder.BackColor = Color.White;
            pnlBodyBorder.Controls.Add(rtbBody);
            pnlBodyBorder.Location = new Point(40, 489);
            pnlBodyBorder.Name = "pnlBodyBorder";
            pnlBodyBorder.Padding = new Padding(10);
            pnlBodyBorder.Size = new Size(912, 313);
            pnlBodyBorder.TabIndex = 6;
            // 
            // pnlTypeBorder
            // 
            pnlTypeBorder.BackColor = Color.White;
            pnlTypeBorder.Controls.Add(cboType);
            pnlTypeBorder.Location = new Point(40, 854);
            pnlTypeBorder.Name = "pnlTypeBorder";
            pnlTypeBorder.Padding = new Padding(10, 5, 10, 5);
            pnlTypeBorder.Size = new Size(390, 70);
            pnlTypeBorder.TabIndex = 8;
            // 
            // pnlDeptBorder
            // 
            pnlDeptBorder.BackColor = Color.White;
            pnlDeptBorder.Controls.Add(cboDept);
            pnlDeptBorder.Location = new Point(523, 854);
            pnlDeptBorder.Name = "pnlDeptBorder";
            pnlDeptBorder.Padding = new Padding(10, 5, 10, 5);
            pnlDeptBorder.Size = new Size(422, 70);
            pnlDeptBorder.TabIndex = 10;
            // 
            // pnlStatusBorder
            // 
            pnlStatusBorder.BackColor = Color.White;
            pnlStatusBorder.Controls.Add(cboStatus);
            pnlStatusBorder.Location = new Point(40, 983);
            pnlStatusBorder.Name = "pnlStatusBorder";
            pnlStatusBorder.Padding = new Padding(10, 5, 10, 5);
            pnlStatusBorder.Size = new Size(390, 70);
            pnlStatusBorder.TabIndex = 12;
            // 
            // pnlPriorityBorder
            // 
            pnlPriorityBorder.BackColor = Color.White;
            pnlPriorityBorder.Controls.Add(numPriority);
            pnlPriorityBorder.Location = new Point(523, 983);
            pnlPriorityBorder.Name = "pnlPriorityBorder";
            pnlPriorityBorder.Padding = new Padding(10, 5, 10, 5);
            pnlPriorityBorder.Size = new Size(157, 70);
            pnlPriorityBorder.TabIndex = 14;
            // 
            // pnlMainBackground
            // 
            pnlMainBackground.BackColor = Color.White;
            pnlMainBackground.Controls.Add(panel29);
            pnlMainBackground.Controls.Add(btnCancel);
            pnlMainBackground.Controls.Add(btnSave);
            pnlMainBackground.Controls.Add(lblThumbnailLabel);
            pnlMainBackground.Controls.Add(chkPinned);
            pnlMainBackground.Controls.Add(pnlPriorityBorder);
            pnlMainBackground.Controls.Add(lblPriorityLabel);
            pnlMainBackground.Controls.Add(pnlStatusBorder);
            pnlMainBackground.Controls.Add(lblStatusLabel);
            pnlMainBackground.Controls.Add(pnlDeptBorder);
            pnlMainBackground.Controls.Add(lblDeptLabel);
            pnlMainBackground.Controls.Add(pnlTypeBorder);
            pnlMainBackground.Controls.Add(lblTypeLabel);
            pnlMainBackground.Controls.Add(pnlBodyBorder);
            pnlMainBackground.Controls.Add(lblBodyLabel);
            pnlMainBackground.Controls.Add(pnlSummaryBorder);
            pnlMainBackground.Controls.Add(lblSummaryLabel);
            pnlMainBackground.Controls.Add(pnlTitleBorder);
            pnlMainBackground.Controls.Add(lblTitleLabel);
            pnlMainBackground.Controls.Add(pnlHeader);
            pnlMainBackground.Dock = DockStyle.Fill;
            pnlMainBackground.ForeColor = Color.White;
            pnlMainBackground.Location = new Point(3, 3);
            pnlMainBackground.Name = "pnlMainBackground";
            pnlMainBackground.Size = new Size(994, 1294);
            pnlMainBackground.TabIndex = 0;
            // 
            // ucAdmin_AddArticle
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 70, 125);
            Controls.Add(pnlMainBackground);
            ForeColor = Color.White;
            Name = "ucAdmin_AddArticle";
            Padding = new Padding(3);
            Size = new Size(1000, 1300);
            Load += ucAdmin_AddArticle_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPriority).EndInit();
            panel29.ResumeLayout(false);
            panel29.PerformLayout();
            pnlTitleBorder.ResumeLayout(false);
            pnlTitleBorder.PerformLayout();
            pnlSummaryBorder.ResumeLayout(false);
            pnlSummaryBorder.PerformLayout();
            pnlBodyBorder.ResumeLayout(false);
            pnlTypeBorder.ResumeLayout(false);
            pnlDeptBorder.ResumeLayout(false);
            pnlStatusBorder.ResumeLayout(false);
            pnlPriorityBorder.ResumeLayout(false);
            pnlMainBackground.ResumeLayout(false);
            pnlMainBackground.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnCancelTop;
        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblSummaryLabel;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label lblBodyLabel;
        private System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.Label lblTypeLabel;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblDeptLabel;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblPriorityLabel;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.CheckBox chkPinned;
        private System.Windows.Forms.Label lblThumbnailLabel;
        private System.Windows.Forms.TextBox txtThumbnail;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Panel panel29;
        private Label label24;
        private Panel pnlTitleBorder;
        private Panel pnlSummaryBorder;
        private Panel pnlBodyBorder;
        private Panel pnlTypeBorder;
        private Panel pnlDeptBorder;
        private Panel pnlStatusBorder;
        private Panel pnlPriorityBorder;
        private System.Windows.Forms.Panel pnlMainBackground;
        private Label label1;
    }
}
