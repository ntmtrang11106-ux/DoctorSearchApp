namespace UI_Tier
{
    partial class frmAdmin
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
            btnLogout = new Button();
            pnlTabs = new Panel();
            pnlProfile = new Panel();
            lblIconProfile = new Label();
            lblProfile = new Label();
            pnlUser = new Panel();
            lblIconUser = new Label();
            lblUser = new Label();
            pnlDoctor = new Panel();
            lblIconDoctor = new Label();
            lblDoctor = new Label();
            pnlOverview = new Panel();
            lblIconOverview = new Label();
            lblOverview = new Label();
            pnlLogo = new Panel();
            lblWelcome = new Label();
            pnMain = new Panel();
            pnlHeader.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlProfile.SuspendLayout();
            pnlUser.SuspendLayout();
            pnlDoctor.SuspendLayout();
            pnlOverview.SuspendLayout();
            pnlLogo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Controls.Add(pnlTabs);
            pnlHeader.Controls.Add(pnlLogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(2188, 115);
            pnlHeader.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(24, 112, 255);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1888, 23);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(270, 70);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlTabs
            // 
            pnlTabs.Anchor = AnchorStyles.Top;
            pnlTabs.Controls.Add(pnlProfile);
            pnlTabs.Controls.Add(pnlUser);
            pnlTabs.Controls.Add(pnlDoctor);
            pnlTabs.Controls.Add(pnlOverview);
            pnlTabs.Location = new Point(583, 3);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Size = new Size(1200, 110);
            pnlTabs.TabIndex = 1;
            // 
            // pnlProfile
            // 
            pnlProfile.Controls.Add(lblIconProfile);
            pnlProfile.Controls.Add(lblProfile);
            pnlProfile.Location = new Point(900, 15);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(280, 85);
            pnlProfile.TabIndex = 4;
            // 
            // lblIconProfile
            // 
            lblIconProfile.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconProfile.ForeColor = Color.Gray;
            lblIconProfile.Location = new Point(15, 10);
            lblIconProfile.Name = "lblIconProfile";
            lblIconProfile.Size = new Size(65, 65);
            lblIconProfile.TabIndex = 1;
            lblIconProfile.Text = "";
            lblIconProfile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProfile
            // 
            lblProfile.AutoSize = true;
            lblProfile.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblProfile.ForeColor = Color.Gray;
            lblProfile.Location = new Point(85, 18);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(153, 47);
            lblProfile.TabIndex = 0;
            lblProfile.Text = "Cá nhân";
            // 
            // pnlUser
            // 
            pnlUser.Controls.Add(lblIconUser);
            pnlUser.Controls.Add(lblUser);
            pnlUser.Location = new Point(600, 15);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(280, 85);
            pnlUser.TabIndex = 3;
            // 
            // lblIconUser
            // 
            lblIconUser.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconUser.ForeColor = Color.Gray;
            lblIconUser.Location = new Point(15, 10);
            lblIconUser.Name = "lblIconUser";
            lblIconUser.Size = new Size(65, 65);
            lblIconUser.TabIndex = 1;
            lblIconUser.Text = "";
            lblIconUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblUser.ForeColor = Color.Gray;
            lblUser.Location = new Point(85, 18);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(195, 47);
            lblUser.TabIndex = 0;
            lblUser.Text = "Bệnh nhân";
            // 
            // pnlDoctor
            // 
            pnlDoctor.Controls.Add(lblIconDoctor);
            pnlDoctor.Controls.Add(lblDoctor);
            pnlDoctor.Location = new Point(300, 15);
            pnlDoctor.Name = "pnlDoctor";
            pnlDoctor.Size = new Size(280, 85);
            pnlDoctor.TabIndex = 2;
            // 
            // lblIconDoctor
            // 
            lblIconDoctor.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconDoctor.ForeColor = Color.Gray;
            lblIconDoctor.Location = new Point(15, 10);
            lblIconDoctor.Name = "lblIconDoctor";
            lblIconDoctor.Size = new Size(65, 65);
            lblIconDoctor.TabIndex = 1;
            lblIconDoctor.Text = "";
            lblIconDoctor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDoctor.ForeColor = Color.Gray;
            lblDoctor.Location = new Point(85, 18);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(113, 47);
            lblDoctor.TabIndex = 0;
            lblDoctor.Text = "Bác sĩ";
            // 
            // pnlOverview
            // 
            pnlOverview.Controls.Add(lblIconOverview);
            pnlOverview.Controls.Add(lblOverview);
            pnlOverview.Location = new Point(0, 15);
            pnlOverview.Name = "pnlOverview";
            pnlOverview.Size = new Size(280, 85);
            pnlOverview.TabIndex = 1;
            // 
            // lblIconOverview
            // 
            lblIconOverview.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconOverview.ForeColor = Color.Gray;
            lblIconOverview.Location = new Point(15, 10);
            lblIconOverview.Name = "lblIconOverview";
            lblIconOverview.Size = new Size(65, 65);
            lblIconOverview.TabIndex = 1;
            lblIconOverview.Text = "";
            lblIconOverview.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOverview
            // 
            lblOverview.AutoSize = true;
            lblOverview.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblOverview.ForeColor = Color.Gray;
            lblOverview.Location = new Point(85, 18);
            lblOverview.Name = "lblOverview";
            lblOverview.Size = new Size(198, 47);
            lblOverview.TabIndex = 0;
            lblOverview.Text = "Tổng quan";
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(lblWelcome);
            pnlLogo.Dock = DockStyle.Left;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(555, 115);
            pnlLogo.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Italic);
            lblWelcome.ForeColor = Color.FromArgb(0, 98, 255);
            lblWelcome.Location = new Point(30, 32);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(351, 47);
            lblWelcome.TabIndex = 6;
            lblWelcome.Text = "Chào mừng, Admin!";
            // 
            // pnMain
            // 
            pnMain.BackColor = Color.FromArgb(248, 249, 250);
            pnMain.Dock = DockStyle.Fill;
            pnMain.Location = new Point(0, 115);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(2188, 862);
            pnMain.TabIndex = 1;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2188, 977);
            Controls.Add(pnMain);
            Controls.Add(pnlHeader);
            Name = "frmAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            pnlTabs.ResumeLayout(false);
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            pnlDoctor.ResumeLayout(false);
            pnlDoctor.PerformLayout();
            pnlOverview.ResumeLayout(false);
            pnlOverview.PerformLayout();
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Panel pnlLogo;
        private Panel pnlTabs;
        private Panel pnlOverview;
        private Label lblOverview;
        private Label lblIconOverview;
        private Panel pnlDoctor;
        private Label lblDoctor;
        private Label lblIconDoctor;
        private Panel pnlUser;
        private Label lblUser;
        private Label lblIconUser;
        private Panel pnlProfile;
        private Label lblProfile;
        private Label lblIconProfile;
        private Button btnLogout;
        private Panel pnMain;
        private Label lblWelcome;
    }
}
