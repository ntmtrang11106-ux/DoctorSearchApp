namespace UI_Tier
{
    partial class ucAdmin_UserItem
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
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.pnlRoleBadge = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.pnlStatusBadge = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblJoinedDate = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnToggleStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlRoleBadge.SuspendLayout();
            this.pnlStatusBadge.SuspendLayout();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Gainsboro;
            this.picAvatar.Location = new System.Drawing.Point(15, 12);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(50, 50);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFullName.Location = new System.Drawing.Point(80, 12);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(120, 25);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Nguyễn Văn A";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhone.ForeColor = System.Drawing.Color.Gray;
            this.lblPhone.Location = new System.Drawing.Point(80, 40);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(89, 20);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "0987654321";
            // 
            // pnlRoleBadge
            // 
            this.pnlRoleBadge.Controls.Add(this.lblRole);
            this.pnlRoleBadge.Location = new System.Drawing.Point(300, 22);
            this.pnlRoleBadge.Name = "pnlRoleBadge";
            this.pnlRoleBadge.Size = new System.Drawing.Size(80, 30);
            this.pnlRoleBadge.TabIndex = 3;
            // 
            // lblRole
            // 
            this.lblRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(0, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(80, 30);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Doctor";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatusBadge
            // 
            this.pnlStatusBadge.Controls.Add(this.lblStatus);
            this.pnlStatusBadge.Location = new System.Drawing.Point(400, 22);
            this.pnlStatusBadge.Name = "pnlStatusBadge";
            this.pnlStatusBadge.Size = new System.Drawing.Size(80, 30);
            this.pnlStatusBadge.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(80, 30);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Active";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJoinedDate
            // 
            this.lblJoinedDate.AutoSize = true;
            this.lblJoinedDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblJoinedDate.ForeColor = System.Drawing.Color.Gray;
            this.lblJoinedDate.Location = new System.Drawing.Point(520, 27);
            this.lblJoinedDate.Name = "lblJoinedDate";
            this.lblJoinedDate.Size = new System.Drawing.Size(85, 20);
            this.lblJoinedDate.TabIndex = 5;
            this.lblJoinedDate.Text = "20/05/2024";
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(740, 20);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(80, 35);
            this.btnApprove.TabIndex = 6;
            this.btnApprove.Text = "Duyệt";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(79)))));
            this.btnReject.Location = new System.Drawing.Point(830, 20);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(80, 35);
            this.btnReject.TabIndex = 7;
            this.btnReject.Text = "Từ chối";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnToggleStatus
            // 
            this.btnToggleStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleStatus.BackColor = System.Drawing.Color.White;
            this.btnToggleStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnToggleStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnToggleStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnToggleStatus.Location = new System.Drawing.Point(820, 20);
            this.btnToggleStatus.Name = "btnToggleStatus";
            this.btnToggleStatus.Size = new System.Drawing.Size(90, 35);
            this.btnToggleStatus.TabIndex = 8;
            this.btnToggleStatus.Text = "Chặn";
            this.btnToggleStatus.UseVisualStyleBackColor = false;
            this.btnToggleStatus.Click += new System.EventHandler(this.btnToggleStatus_Click);
            // 
            // ucAdmin_UserItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnToggleStatus);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lblJoinedDate);
            this.Controls.Add(this.pnlStatusBadge);
            this.Controls.Add(this.pnlRoleBadge);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.picAvatar);
            this.Name = "ucAdmin_UserItem";
            this.Size = new System.Drawing.Size(930, 75);
            this.Load += new System.EventHandler(this.ucAdmin_UserItem_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucAdmin_UserItem_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlRoleBadge.ResumeLayout(false);
            this.pnlStatusBadge.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Panel pnlRoleBadge;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel pnlStatusBadge;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblJoinedDate;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnToggleStatus;
    }
}
