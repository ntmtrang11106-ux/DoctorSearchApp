namespace UI_Tier
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel5 = new Panel();
            picShowPass = new PictureBox();
            txtPassword = new TextBox();
            panel4 = new Panel();
            txtUsername = new TextBox();
            label5 = new Label();
            label4 = new Label();
            btnLogin = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picShowPass).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2008, 1372);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.BackColor = Color.FromArgb(24, 112, 255);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(92, 349);
            panel2.Name = "panel2";
            panel2.Size = new Size(1844, 1011);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(btnLogin);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(900, 16);
            panel3.Name = "panel3";
            panel3.Size = new Size(926, 977);
            panel3.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(picShowPass);
            panel5.Controls.Add(txtPassword);
            panel5.Location = new Point(93, 480);
            panel5.Name = "panel5";
            panel5.Size = new Size(732, 75);
            panel5.TabIndex = 8;
            // 
            // picShowPass
            // 
            picShowPass.Image = Properties.Resources.visible;
            picShowPass.Location = new Point(653, 10);
            picShowPass.Name = "picShowPass";
            picShowPass.Size = new Size(67, 55);
            picShowPass.SizeMode = PictureBoxSizeMode.Zoom;
            picShowPass.TabIndex = 4;
            picShowPass.TabStop = false;
            picShowPass.Click += pictureBox1_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.CausesValidation = false;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(15, 15);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(704, 43);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(txtUsername);
            panel4.Location = new Point(93, 288);
            panel4.Name = "panel4";
            panel4.Size = new Size(732, 75);
            panel4.TabIndex = 7;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.Window;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.CausesValidation = false;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(15, 13);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(704, 43);
            txtUsername.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10.125F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(323, 775);
            label5.Name = "label5";
            label5.Size = new Size(179, 37);
            label5.TabIndex = 6;
            label5.Text = "Đăng ký ngay";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(83, 775);
            label4.Name = "label4";
            label4.Size = new Size(243, 37);
            label4.TabIndex = 5;
            label4.Text = "Chưa có tài khoản?";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top;
            btnLogin.BackColor = Color.FromArgb(24, 112, 255);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(93, 643);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(732, 85);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseCompatibleTextRendering = true;
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(93, 412);
            label3.Name = "label3";
            label3.Size = new Size(153, 45);
            label3.TabIndex = 1;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(93, 217);
            label2.Name = "label2";
            label2.Size = new Size(371, 45);
            label2.TabIndex = 0;
            label2.Text = "Tài khoản / Số điện thoại";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.White;
            label1.Location = new Point(182, 147);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(351, 78);
            label1.TabIndex = 0;
            label1.Text = "Chào mừng";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(2008, 1372);
            Controls.Add(panel1);
            Name = "frmLogin";
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picShowPass).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Label label3;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label5;
        private Label label4;
        private Button btnLogin;
        private Panel panel4;
        private Panel panel5;
        private PictureBox picShowPass;
    }
}