namespace UI_Tier
{
    partial class frmGuest
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
            panel1 = new Panel();
            btnLogin = new Button();
            pnlMainContainer = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(242, 246, 250);
            panel1.Controls.Add(btnLogin);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1950, 128);
            panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogin.BackColor = Color.FromArgb(0, 120, 212);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(1658, 24);
            btnLogin.Margin = new Padding(5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(260, 80);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Location = new Point(0, 128);
            pnlMainContainer.Margin = new Padding(5);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Size = new Size(1950, 1322);
            pnlMainContainer.TabIndex = 1;
            // 
            // frmGuest
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1950, 1450);
            Controls.Add(pnlMainContainer);
            Controls.Add(panel1);
            Margin = new Padding(5);
            Name = "frmGuest";
            Text = "DoctorSearch - Guest";
            WindowState = FormWindowState.Maximized;
            Load += frmGuest_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panel1;
        private Button btnLogin;
        private Panel pnlMainContainer;
    }
}