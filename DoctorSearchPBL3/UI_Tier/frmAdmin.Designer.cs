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
            pnlAdminProfile = new Panel();
            lblIconAdminProfile = new Label();
            lblAdminProfile = new Label();
            pnlProfile = new Panel();
            lblIconProfile = new Label();
            lblProfile = new Label();
            pnlUser = new Panel();
            lblIconUser = new Label();
            lblUser = new Label();
            pnlAppointment = new Panel();
            lblIconAppointment = new Label();
            lblAppointment = new Label();
            pnlArticles = new Panel();
            lblArticles = new Label();
            pnlDoctor = new Panel();
            lblIconDoctor = new Label();
            lblDoctor = new Label();
            pnlOverview = new Panel();
            lblIconOverview = new Label();
            lblOverview = new Label();
            pnlLogo = new Panel();
            lblWelcome = new Label();
            pnMain = new Panel();
            lblIconArticles = new Label();
            pnlHeader.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlAdminProfile.SuspendLayout();
            pnlProfile.SuspendLayout();
            pnlUser.SuspendLayout();
            pnlAppointment.SuspendLayout();
            pnlArticles.SuspendLayout();
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
            pnlHeader.Size = new Size(2884, 115);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(24, 112, 255);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(2612, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(260, 80);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlTabs
            // 
            pnlTabs.Anchor = AnchorStyles.Top;
            pnlTabs.Controls.Add(pnlAdminProfile);
            pnlTabs.Controls.Add(pnlProfile);
            pnlTabs.Controls.Add(pnlUser);
            pnlTabs.Controls.Add(pnlAppointment);
            pnlTabs.Controls.Add(pnlArticles);
            pnlTabs.Controls.Add(pnlDoctor);
            pnlTabs.Controls.Add(pnlOverview);
            pnlTabs.Location = new Point(587, 3);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Size = new Size(2019, 110);
            pnlTabs.TabIndex = 1;
            // 
            // pnlAdminProfile
            // 
            pnlAdminProfile.Controls.Add(lblIconAdminProfile);
            pnlAdminProfile.Controls.Add(lblAdminProfile);
            pnlAdminProfile.Location = new Point(1733, 15);
            pnlAdminProfile.Name = "pnlAdminProfile";
            pnlAdminProfile.Size = new Size(278, 85);
            pnlAdminProfile.TabIndex = 6;
            // 
            // lblIconAdminProfile
            // 
            lblIconAdminProfile.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconAdminProfile.ForeColor = Color.Gray;
            lblIconAdminProfile.Location = new Point(15, 10);
            lblIconAdminProfile.Name = "lblIconAdminProfile";
            lblIconAdminProfile.Size = new Size(65, 65);
            lblIconAdminProfile.TabIndex = 1;
            lblIconAdminProfile.Text = "";
            lblIconAdminProfile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAdminProfile
            // 
            lblAdminProfile.AutoSize = true;
            lblAdminProfile.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblAdminProfile.ForeColor = Color.Gray;
            lblAdminProfile.Location = new Point(85, 18);
            lblAdminProfile.Name = "lblAdminProfile";
            lblAdminProfile.Size = new Size(115, 47);
            lblAdminProfile.TabIndex = 0;
            lblAdminProfile.Text = "Hồ sơ";
            // 
            // pnlProfile
            // 
            pnlProfile.Controls.Add(lblIconProfile);
            pnlProfile.Controls.Add(lblProfile);
            pnlProfile.Location = new Point(1449, 15);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(278, 85);
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
            lblIconProfile.Text = "";
            lblIconProfile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProfile
            // 
            lblProfile.AutoSize = true;
            lblProfile.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblProfile.ForeColor = Color.Gray;
            lblProfile.Location = new Point(85, 18);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(168, 47);
            lblProfile.TabIndex = 0;
            lblProfile.Text = "Đánh giá";
            // 
            // pnlUser
            // 
            pnlUser.Controls.Add(lblIconDoctor);
            pnlUser.Controls.Add(lblUser);
            pnlUser.Location = new Point(1139, 15);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(304, 85);
            pnlUser.TabIndex = 3;
            // 
            // lblIconUser
            // 
            lblIconUser.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconUser.ForeColor = Color.Gray;
            lblIconUser.Location = new Point(17, 10);
            lblIconUser.Name = "lblIconUser";
            lblIconUser.Size = new Size(65, 65);
            lblIconUser.TabIndex = 1;
            lblIconUser.Text = "";
            lblIconUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUser.ForeColor = Color.Gray;
            lblUser.Location = new Point(75, 20);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(214, 45);
            lblUser.TabIndex = 0;
            lblUser.Text = "Chuyên khoa";
            // 
            // pnlAppointment
            // 
            pnlAppointment.Controls.Add(lblIconAppointment);
            pnlAppointment.Controls.Add(lblAppointment);
            pnlAppointment.Location = new Point(855, 15);
            pnlAppointment.Name = "pnlAppointment";
            pnlAppointment.Size = new Size(278, 85);
            pnlAppointment.TabIndex = 7;
            // 
            // lblIconAppointment
            // 
            lblIconAppointment.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconAppointment.ForeColor = Color.Gray;
            lblIconAppointment.Location = new Point(15, 10);
            lblIconAppointment.Name = "lblIconAppointment";
            lblIconAppointment.Size = new Size(65, 65);
            lblIconAppointment.TabIndex = 1;
            lblIconAppointment.Text = "";
            lblIconAppointment.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAppointment
            // 
            lblAppointment.AutoSize = true;
            lblAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAppointment.ForeColor = Color.Gray;
            lblAppointment.Location = new Point(80, 20);
            lblAppointment.Name = "lblAppointment";
            lblAppointment.Size = new Size(143, 45);
            lblAppointment.TabIndex = 0;
            lblAppointment.Text = "Lịch hẹn";
            // 
            // pnlArticles
            // 
            pnlArticles.Controls.Add(lblIconArticles);
            pnlArticles.Controls.Add(lblArticles);
            pnlArticles.Location = new Point(571, 15);
            pnlArticles.Name = "pnlArticles";
            pnlArticles.Size = new Size(278, 85);
            pnlArticles.TabIndex = 5;
            // 
            // lblArticles
            // 
            lblArticles.AutoSize = true;
            lblArticles.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblArticles.ForeColor = Color.Gray;
            lblArticles.Location = new Point(85, 18);
            lblArticles.Name = "lblArticles";
            lblArticles.Size = new Size(143, 47);
            lblArticles.TabIndex = 0;
            lblArticles.Text = "Bài viết";
            // 
            // pnlDoctor
            // 
            pnlDoctor.Controls.Add(lblIconUser);
            pnlDoctor.Controls.Add(lblDoctor);
            pnlDoctor.Location = new Point(287, 15);
            pnlDoctor.Name = "pnlDoctor";
            pnlDoctor.Size = new Size(278, 85);
            pnlDoctor.TabIndex = 2;
            // 
            // lblIconDoctor
            // 
            lblIconDoctor.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconDoctor.ForeColor = Color.Gray;
            lblIconDoctor.Location = new Point(17, 10);
            lblIconDoctor.Name = "lblIconDoctor";
            lblIconDoctor.Size = new Size(65, 65);
            lblIconDoctor.TabIndex = 1;
            lblIconDoctor.Text = "";
            lblIconDoctor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblDoctor.ForeColor = Color.Gray;
            lblDoctor.Location = new Point(75, 20);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(196, 42);
            lblDoctor.TabIndex = 0;
            lblDoctor.Text = "Người dùng";
            // 
            // pnlOverview
            // 
            pnlOverview.Controls.Add(lblIconOverview);
            pnlOverview.Controls.Add(lblOverview);
            pnlOverview.Location = new Point(3, 15);
            pnlOverview.Name = "pnlOverview";
            pnlOverview.Size = new Size(278, 85);
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
            lblOverview.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOverview.ForeColor = Color.Gray;
            lblOverview.Location = new Point(79, 18);
            lblOverview.Name = "lblOverview";
            lblOverview.Size = new Size(182, 45);
            lblOverview.TabIndex = 0;
            lblOverview.Text = "Tổng quan";
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(lblWelcome);
            pnlLogo.Dock = DockStyle.Left;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(581, 115);
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
            pnMain.Size = new Size(2884, 862);
            pnMain.TabIndex = 1;
            // 
            // lblIconArticles
            // 
            lblIconArticles.Font = new Font("Segoe MDL2 Assets", 20F);
            lblIconArticles.ForeColor = Color.Gray;
            lblIconArticles.Location = new Point(17, 0);
            lblIconArticles.Name = "lblIconArticles";
            lblIconArticles.Size = new Size(62, 69);
            lblIconArticles.TabIndex = 1;
            lblIconArticles.Text = "📝";
            lblIconArticles.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2884, 977);
            Controls.Add(pnMain);
            Controls.Add(pnlHeader);
            Name = "frmAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            pnlTabs.ResumeLayout(false);
            pnlAdminProfile.ResumeLayout(false);
            pnlAdminProfile.PerformLayout();
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            pnlAppointment.ResumeLayout(false);
            pnlAppointment.PerformLayout();
            pnlArticles.ResumeLayout(false);
            pnlArticles.PerformLayout();
            pnlDoctor.ResumeLayout(false);
            pnlDoctor.PerformLayout();
            pnlOverview.ResumeLayout(false);
            pnlOverview.PerformLayout();
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Panel pnlOverview;
        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.Label lblIconOverview;
        private System.Windows.Forms.Panel pnlDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblIconDoctor;
        private System.Windows.Forms.Panel pnlArticles;
        private System.Windows.Forms.Label lblArticles;
        private System.Windows.Forms.Label lblIconArticles;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblIconUser;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Label lblIconProfile;
        private System.Windows.Forms.Panel pnlAdminProfile;
        private System.Windows.Forms.Label lblAdminProfile;
        private System.Windows.Forms.Label lblIconAdminProfile;
        private System.Windows.Forms.Panel pnlAppointment;
        private System.Windows.Forms.Label lblAppointment;
        private System.Windows.Forms.Label lblIconAppointment;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Label lblWelcome;
    }
}
