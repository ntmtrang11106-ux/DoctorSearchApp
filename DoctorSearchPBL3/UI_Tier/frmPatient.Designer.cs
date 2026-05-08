namespace UI_Tier
{
    partial class frmPatient
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
            panel7 = new Panel();
            pnlProfile = new Panel();
            label10 = new Label();
            label5 = new Label();
            pnlChat = new Panel();
            label9 = new Label();
            label4 = new Label();
            pnlAppointment = new Panel();
            label8 = new Label();
            label3 = new Label();
            pnlHome = new Panel();
            label1 = new Label();
            label6 = new Label();
            pnlSearchDoc = new Panel();
            label7 = new Label();
            label2 = new Label();
            btnLogout = new Button();
            pnMain = new Panel();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            pnlProfile.SuspendLayout();
            pnlChat.SuspendLayout();
            pnlAppointment.SuspendLayout();
            pnlHome.SuspendLayout();
            pnlSearchDoc.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(btnLogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2118, 115);
            panel1.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel7.Controls.Add(pnlProfile);
            panel7.Controls.Add(pnlChat);
            panel7.Controls.Add(pnlAppointment);
            panel7.Controls.Add(pnlHome);
            panel7.Controls.Add(pnlSearchDoc);
            panel7.Location = new Point(223, 5);
            panel7.Name = "panel7";
            panel7.Size = new Size(1579, 110);
            panel7.TabIndex = 3;
            // 
            // pnlProfile
            // 
            pnlProfile.Controls.Add(label10);
            pnlProfile.Controls.Add(label5);
            pnlProfile.Location = new Point(1281, 25);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(290, 80);
            pnlProfile.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.FlatStyle = FlatStyle.Flat;
            label10.Font = new Font("Segoe UI", 13F);
            label10.ForeColor = SystemColors.ControlDarkDark;
            label10.Location = new Point(122, 13);
            label10.Name = "label10";
            label10.Size = new Size(112, 47);
            label10.TabIndex = 5;
            label10.Text = "Hồ sơ";
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe MDL2 Assets", 17F);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(60, 16);
            label5.Name = "label5";
            label5.Size = new Size(75, 75);
            label5.TabIndex = 4;
            label5.Text = "";
            // 
            // pnlChat
            // 
            pnlChat.Controls.Add(label9);
            pnlChat.Controls.Add(label4);
            pnlChat.Location = new Point(958, 24);
            pnlChat.Name = "pnlChat";
            pnlChat.Size = new Size(290, 80);
            pnlChat.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.FlatStyle = FlatStyle.Flat;
            label9.Font = new Font("Segoe UI", 13F);
            label9.ForeColor = SystemColors.ControlDarkDark;
            label9.Location = new Point(104, 13);
            label9.Name = "label9";
            label9.Size = new Size(154, 47);
            label9.TabIndex = 4;
            label9.Text = "Nhắn tin";
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe MDL2 Assets", 17F);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(42, 16);
            label4.Name = "label4";
            label4.Size = new Size(75, 75);
            label4.TabIndex = 3;
            label4.Text = "";
            // 
            // pnlAppointment
            // 
            pnlAppointment.Controls.Add(label8);
            pnlAppointment.Controls.Add(label3);
            pnlAppointment.Location = new Point(640, 26);
            pnlAppointment.Name = "pnlAppointment";
            pnlAppointment.Size = new Size(290, 80);
            pnlAppointment.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI", 13F);
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(96, 14);
            label8.Name = "label8";
            label8.Size = new Size(148, 47);
            label8.TabIndex = 3;
            label8.Text = "Lịch hẹn";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe MDL2 Assets", 17F);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(34, 15);
            label3.Name = "label3";
            label3.Size = new Size(75, 75);
            label3.TabIndex = 2;
            label3.Text = "";
            // 
            // pnlHome
            // 
            pnlHome.Controls.Add(label1);
            pnlHome.Controls.Add(label6);
            pnlHome.Location = new Point(3, 24);
            pnlHome.Name = "pnlHome";
            pnlHome.Size = new Size(290, 80);
            pnlHome.TabIndex = 5;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe MDL2 Assets", 17F);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(22, 11);
            label1.Name = "label1";
            label1.Size = new Size(75, 75);
            label1.TabIndex = 0;
            label1.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Segoe UI", 13F);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(84, 14);
            label6.Name = "label6";
            label6.Size = new Size(172, 47);
            label6.TabIndex = 1;
            label6.Text = "Trang chủ";
            // 
            // pnlSearchDoc
            // 
            pnlSearchDoc.Controls.Add(label7);
            pnlSearchDoc.Controls.Add(label2);
            pnlSearchDoc.Location = new Point(321, 25);
            pnlSearchDoc.Name = "pnlSearchDoc";
            pnlSearchDoc.Size = new Size(290, 80);
            pnlSearchDoc.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Segoe UI", 13F);
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(83, 16);
            label7.Name = "label7";
            label7.Size = new Size(175, 47);
            label7.TabIndex = 2;
            label7.Text = "Tìm kiếm";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe MDL2 Assets", 17F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(21, 16);
            label2.Name = "label2";
            label2.Size = new Size(75, 75);
            label2.TabIndex = 1;
            label2.Text = "";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(24, 112, 255);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1804, 23);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(277, 65);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnMain
            // 
            pnMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnMain.Location = new Point(0, 115);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(2118, 862);
            pnMain.TabIndex = 2;
            // 
            // frmPatient
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(2118, 977);
            Controls.Add(pnMain);
            Controls.Add(panel1);
            Name = "frmPatient";
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            Load += frmPatient_Load;
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            pnlChat.ResumeLayout(false);
            pnlChat.PerformLayout();
            pnlAppointment.ResumeLayout(false);
            pnlAppointment.PerformLayout();
            pnlHome.ResumeLayout(false);
            pnlHome.PerformLayout();
            pnlSearchDoc.ResumeLayout(false);
            pnlSearchDoc.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private Button btnLogout;
        private Panel pnMain;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel pnlHome;
        private Label label6;
        private Panel pnlAppointment;
        private Label label8;
        private Panel pnlChat;
        private Label label9;
        private Panel pnlProfile;
        private Label label10;
        private Panel pnlSearchDoc;
        private Label label7;
        private Panel panel7;
    }
}
