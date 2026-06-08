namespace UI_Tier
{
    partial class ucAdmin_AddDepartment
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
            lblHeaderTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtDesc = new TextBox();
            label4 = new Label();
            rbShow = new RadioButton();
            rbHide = new RadioButton();
            btnSave = new Button();
            btnCancel = new Button();
            btnClose = new Button();
            pnlName = new Panel();
            pnlDesc = new Panel();
            pnlName.SuspendLayout();
            pnlDesc.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(30, 70, 125);
            lblHeaderTitle.Location = new Point(40, 40);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(496, 59);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Thêm chuyên khoa mới";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(45, 110);
            label1.Name = "label1";
            label1.Size = new Size(789, 45);
            label1.TabIndex = 1;
            label1.Text = "Nhập thông tin để thêm chuyên khoa mới vào hệ thống";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(50, 179);
            label2.Name = "label2";
            label2.Size = new Size(270, 45);
            label2.TabIndex = 2;
            label2.Text = "Tên chuyên khoa";
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(12, 12);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nhập tên chuyên khoa";
            txtName.Size = new Size(859, 50);
            txtName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(53, 319);
            label3.Name = "label3";
            label3.Size = new Size(109, 45);
            label3.TabIndex = 4;
            label3.Text = "Mô tả";
            // 
            // txtDesc
            // 
            txtDesc.BackColor = Color.White;
            txtDesc.BorderStyle = BorderStyle.FixedSingle;
            txtDesc.Font = new Font("Segoe UI", 12F);
            txtDesc.Location = new Point(17, 11);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.PlaceholderText = "Nhập mô tả (tùy chọn)";
            txtDesc.Size = new Size(853, 226);
            txtDesc.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(203, 652);
            label4.Name = "label4";
            label4.Size = new Size(172, 45);
            label4.TabIndex = 6;
            label4.Text = "Trạng thái";
            // 
            // rbShow
            // 
            rbShow.AutoSize = true;
            rbShow.Checked = true;
            rbShow.Font = new Font("Segoe UI", 12F);
            rbShow.Location = new Point(467, 648);
            rbShow.Name = "rbShow";
            rbShow.Size = new Size(163, 49);
            rbShow.TabIndex = 7;
            rbShow.TabStop = true;
            rbShow.Text = "Hiển thị";
            rbShow.UseVisualStyleBackColor = true;
            // 
            // rbHide
            // 
            rbHide.AutoSize = true;
            rbHide.Font = new Font("Segoe UI", 12F);
            rbHide.Location = new Point(688, 648);
            rbHide.Name = "rbHide";
            rbHide.Size = new Size(90, 49);
            rbHide.TabIndex = 8;
            rbHide.Text = "Ẩn";
            rbHide.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(463, 734);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(300, 72);
            btnSave.TabIndex = 9;
            btnSave.Text = "Thêm mới";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(107, 114, 128);
            btnCancel.Location = new Point(780, 734);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(171, 72);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(107, 114, 128);
            btnClose.Location = new Point(906, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(74, 79);
            btnClose.TabIndex = 11;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlName
            // 
            pnlName.Controls.Add(txtName);
            pnlName.Location = new Point(45, 227);
            pnlName.Name = "pnlName";
            pnlName.Size = new Size(880, 76);
            pnlName.TabIndex = 12;
            // 
            // pnlDesc
            // 
            pnlDesc.Controls.Add(txtDesc);
            pnlDesc.Location = new Point(46, 367);
            pnlDesc.Name = "pnlDesc";
            pnlDesc.Size = new Size(879, 249);
            pnlDesc.TabIndex = 13;
            // 
            // ucAdmin_AddDepartment
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlDesc);
            Controls.Add(pnlName);
            Controls.Add(btnClose);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(rbHide);
            Controls.Add(rbShow);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblHeaderTitle);
            Name = "ucAdmin_AddDepartment";
            Size = new Size(986, 836);
            pnlName.ResumeLayout(false);
            pnlName.PerformLayout();
            pnlDesc.ResumeLayout(false);
            pnlDesc.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblHeaderTitle;
        private Label label1;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private TextBox txtDesc;
        private Label label4;
        private RadioButton rbShow;
        private RadioButton rbHide;
        private Button btnSave;
        private Button btnCancel;
        private Button btnClose;
        private Panel pnlName;
        private Panel pnlDesc;
    }
}
