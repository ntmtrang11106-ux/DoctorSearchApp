namespace UI_Tier
{
    partial class ucAdmin_DepartmentItem
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
            pnlCard = new Panel();
            btnRemove = new Button();
            btnToggleHide = new Button();
            btnEdit = new Button();
            pnlStatusBadge = new Panel();
            lblStatus = new Label();
            pnlCountBadge = new Panel();
            lblCount = new Label();
            lblDesc = new Label();
            lblName = new Label();
            line = new Panel();
            pnlCard.SuspendLayout();
            pnlStatusBadge.SuspendLayout();
            pnlCountBadge.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(btnRemove);
            pnlCard.Controls.Add(btnToggleHide);
            pnlCard.Controls.Add(btnEdit);
            pnlCard.Controls.Add(pnlStatusBadge);
            pnlCard.Controls.Add(pnlCountBadge);
            pnlCard.Controls.Add(lblDesc);
            pnlCard.Controls.Add(lblName);
            pnlCard.Dock = DockStyle.Top;
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(1200, 100);
            pnlCard.TabIndex = 0;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 15F);
            btnRemove.ForeColor = Color.FromArgb(107, 114, 128);
            btnRemove.Location = new Point(1140, 25);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(50, 50);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnToggleHide
            // 
            btnToggleHide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggleHide.FlatAppearance.BorderSize = 0;
            btnToggleHide.FlatStyle = FlatStyle.Flat;
            btnToggleHide.Font = new Font("Segoe MDL2 Assets", 15F);
            btnToggleHide.ForeColor = Color.FromArgb(107, 114, 128);
            btnToggleHide.Location = new Point(1080, 25);
            btnToggleHide.Name = "btnToggleHide";
            btnToggleHide.Size = new Size(50, 50);
            btnToggleHide.TabIndex = 5;
            btnToggleHide.Text = "";
            btnToggleHide.UseVisualStyleBackColor = true;
            btnToggleHide.Click += btnToggleHide_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 15F);
            btnEdit.ForeColor = Color.FromArgb(107, 114, 128);
            btnEdit.Location = new Point(1020, 25);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(50, 50);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // pnlStatusBadge
            // 
            pnlStatusBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlStatusBadge.Controls.Add(lblStatus);
            pnlStatusBadge.Location = new Point(780, 30);
            pnlStatusBadge.Name = "pnlStatusBadge";
            pnlStatusBadge.Size = new Size(120, 40);
            pnlStatusBadge.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(120, 40);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Hiển thị";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCountBadge
            // 
            pnlCountBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlCountBadge.BackColor = Color.FromArgb(239, 246, 255);
            pnlCountBadge.Controls.Add(lblCount);
            pnlCountBadge.Location = new Point(600, 30);
            pnlCountBadge.Name = "pnlCountBadge";
            pnlCountBadge.Size = new Size(150, 40);
            pnlCountBadge.TabIndex = 2;
            // 
            // lblCount
            // 
            lblCount.Dock = DockStyle.Fill;
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCount.ForeColor = Color.FromArgb(37, 99, 235);
            lblCount.Location = new Point(0, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(150, 40);
            lblCount.TabIndex = 0;
            lblCount.Text = "85 bác sĩ";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 10F);
            lblDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblDesc.Location = new Point(250, 32);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(250, 37);
            lblDesc.TabIndex = 1;
            lblDesc.Text = "Chuyên khoa tim mạch";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(17, 24, 39);
            lblName.Location = new Point(20, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(158, 41);
            lblName.TabIndex = 0;
            lblName.Text = "Tim mạch";
            // 
            // line
            // 
            line.BackColor = Color.FromArgb(243, 244, 246);
            line.Dock = DockStyle.Bottom;
            line.Location = new Point(0, 99);
            line.Name = "line";
            line.Size = new Size(1200, 1);
            line.TabIndex = 1;
            // 
            // ucAdmin_DepartmentItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(line);
            Controls.Add(pnlCard);
            Name = "ucAdmin_DepartmentItem";
            Size = new Size(1200, 100);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlStatusBadge.ResumeLayout(false);
            pnlCountBadge.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlCard;
        private Label lblName;
        private Label lblDesc;
        private Panel pnlCountBadge;
        private Label lblCount;
        private Panel pnlStatusBadge;
        private Label lblStatus;
        private Button btnEdit;
        private Button btnToggleHide;
        private Button btnRemove;
        private Panel line;
    }
}
