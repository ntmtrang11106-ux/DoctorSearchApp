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
            lblStatus = new Label();
            lblCount = new Label();
            flpAction = new FlowLayoutPanel();
            btnRemove = new Button();
            btnToggleHide = new Button();
            btnEdit = new Button();
            lblDesc = new Label();
            lblName = new Label();
            line = new Panel();
            pnlCard.SuspendLayout();
            flpAction.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblStatus);
            pnlCard.Controls.Add(lblCount);
            pnlCard.Controls.Add(flpAction);
            pnlCard.Controls.Add(lblDesc);
            pnlCard.Controls.Add(lblName);
            pnlCard.Dock = DockStyle.Top;
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(1794, 183);
            pnlCard.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.Font = new Font("Segoe UI", 13F);
            lblStatus.Location = new Point(1172, 64);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(189, 59);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Hiển thị";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCount
            // 
            lblCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCount.ForeColor = Color.FromArgb(37, 99, 235);
            lblCount.Location = new Point(729, 68);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(165, 50);
            lblCount.TabIndex = 0;
            lblCount.Text = "85 bác sĩ";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpAction
            // 
            flpAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpAction.AutoSize = true;
            flpAction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAction.Controls.Add(btnRemove);
            flpAction.Controls.Add(btnToggleHide);
            flpAction.Controls.Add(btnEdit);
            flpAction.FlowDirection = FlowDirection.RightToLeft;
            flpAction.Location = new Point(1403, 48);
            flpAction.Name = "flpAction";
            flpAction.Size = new Size(315, 90);
            flpAction.TabIndex = 17;
            flpAction.WrapContents = false;
            // 
            // btnRemove
            // 
            btnRemove.AccessibleDescription = "Xóa bài viết";
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.BackColor = Color.FromArgb(255, 252, 235);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 20F);
            btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
            btnRemove.Location = new Point(230, 5);
            btnRemove.Margin = new Padding(20, 5, 0, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(85, 85);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnToggleHide
            // 
            btnToggleHide.AccessibleDescription = "Ẩn bài viết";
            btnToggleHide.Anchor = AnchorStyles.None;
            btnToggleHide.BackColor = Color.FromArgb(243, 244, 246);
            btnToggleHide.FlatAppearance.BorderSize = 0;
            btnToggleHide.FlatStyle = FlatStyle.Flat;
            btnToggleHide.Font = new Font("Segoe MDL2 Assets", 20F);
            btnToggleHide.ForeColor = Color.FromArgb(75, 85, 99);
            btnToggleHide.Location = new Point(125, 5);
            btnToggleHide.Margin = new Padding(20, 5, 0, 0);
            btnToggleHide.Name = "btnToggleHide";
            btnToggleHide.Size = new Size(85, 85);
            btnToggleHide.TabIndex = 21;
            btnToggleHide.Text = "";
            btnToggleHide.UseVisualStyleBackColor = false;
            btnToggleHide.Click += btnToggleHide_Click;
            // 
            // btnEdit
            // 
            btnEdit.AccessibleDescription = "Chỉnh sửa bài viết";
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.FromArgb(239, 250, 255);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 20F);
            btnEdit.ForeColor = Color.FromArgb(37, 99, 235);
            btnEdit.Location = new Point(20, 5);
            btnEdit.Margin = new Padding(20, 5, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 85);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblDesc.Location = new Point(348, 71);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(346, 45);
            lblDesc.TabIndex = 1;
            lblDesc.Text = "Chuyên khoa tim mạch";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(17, 24, 39);
            lblName.Location = new Point(67, 68);
            lblName.Name = "lblName";
            lblName.Size = new Size(193, 50);
            lblName.TabIndex = 0;
            lblName.Text = "Tim mạch";
            // 
            // line
            // 
            line.BackColor = Color.FromArgb(243, 244, 246);
            line.Dock = DockStyle.Bottom;
            line.Location = new Point(0, 182);
            line.Name = "line";
            line.Size = new Size(1794, 1);
            line.TabIndex = 1;
            // 
            // ucAdmin_DepartmentItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(line);
            Controls.Add(pnlCard);
            Margin = new Padding(20);
            Name = "ucAdmin_DepartmentItem";
            Size = new Size(1794, 183);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            flpAction.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlCard;
        private Label lblName;
        private Label lblDesc;
        private Label lblCount;
        private Label lblStatus;
        private Button btnEdit;
        private Button btnToggleHide;
        private Button btnRemove;
        private Panel line;
        private FlowLayoutPanel flpAction;
    }
}
