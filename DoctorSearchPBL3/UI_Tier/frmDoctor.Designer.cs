namespace UI_Tier
{
    partial class frmDoctor
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
            pnlOverview = new Panel();
            lblOverviewText = new Label();
            lblOverviewIcon = new Label();
            pnlAppointment = new Panel();
            lblAppText = new Label();
            lblAppIcon = new Label();
            btnLogout = new Button();
            pnMain = new Panel();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            pnlOverview.SuspendLayout();
            pnlAppointment.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(btnLogout);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2188, 115);
            panel1.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel7.Controls.Add(pnlOverview);
            panel7.Controls.Add(pnlAppointment);
            panel7.Location = new Point(780, 5);
            panel7.Name = "panel7";
            panel7.Size = new Size(628, 110);
            panel7.TabIndex = 3;
            // 
            // pnlOverview
            // 
            pnlOverview.Controls.Add(lblOverviewText);
            pnlOverview.Controls.Add(lblOverviewIcon);
            pnlOverview.Location = new Point(3, 24);
            pnlOverview.Name = "pnlOverview";
            pnlOverview.Size = new Size(290, 80);
            pnlOverview.TabIndex = 5;
            // 
            // lblOverviewText
            // 
            lblOverviewText.AutoSize = true;
            lblOverviewText.BackColor = Color.Transparent;
            lblOverviewText.FlatStyle = FlatStyle.Flat;
            lblOverviewText.Font = new Font("Segoe UI", 13F);
            lblOverviewText.ForeColor = SystemColors.ControlDarkDark;
            lblOverviewText.Location = new Point(84, 14);
            lblOverviewText.Name = "lblOverviewText";
            lblOverviewText.Size = new Size(187, 47);
            lblOverviewText.TabIndex = 1;
            lblOverviewText.Text = "Tổng quan";
            // 
            // lblOverviewIcon
            // 
            lblOverviewIcon.BackColor = Color.Transparent;
            lblOverviewIcon.Font = new Font("Segoe MDL2 Assets", 17F);
            lblOverviewIcon.ForeColor = SystemColors.ControlDarkDark;
            lblOverviewIcon.Location = new Point(22, 11);
            lblOverviewIcon.Name = "lblOverviewIcon";
            lblOverviewIcon.Size = new Size(75, 75);
            lblOverviewIcon.TabIndex = 0;
            lblOverviewIcon.Text = "";
            // 
            // pnlAppointment
            // 
            pnlAppointment.Controls.Add(lblAppText);
            pnlAppointment.Controls.Add(lblAppIcon);
            pnlAppointment.Location = new Point(320, 24);
            pnlAppointment.Name = "pnlAppointment";
            pnlAppointment.Size = new Size(290, 80);
            pnlAppointment.TabIndex = 6;
            // 
            // lblAppText
            // 
            lblAppText.AutoSize = true;
            lblAppText.BackColor = Color.Transparent;
            lblAppText.FlatStyle = FlatStyle.Flat;
            lblAppText.Font = new Font("Segoe UI", 13F);
            lblAppText.ForeColor = SystemColors.ControlDarkDark;
            lblAppText.Location = new Point(96, 14);
            lblAppText.Name = "lblAppText";
            lblAppText.Size = new Size(148, 47);
            lblAppText.TabIndex = 3;
            lblAppText.Text = "Lịch hẹn";
            // 
            // lblAppIcon
            // 
            lblAppIcon.BackColor = Color.Transparent;
            lblAppIcon.Font = new Font("Segoe MDL2 Assets", 17F);
            lblAppIcon.ForeColor = SystemColors.ControlDarkDark;
            lblAppIcon.Location = new Point(34, 15);
            lblAppIcon.Name = "lblAppIcon";
            lblAppIcon.Size = new Size(75, 75);
            lblAppIcon.TabIndex = 2;
            lblAppIcon.Text = "";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(24, 112, 255);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1874, 23);
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
            pnMain.Size = new Size(2188, 862);
            pnMain.TabIndex = 3;
            // 
            // frmDoctor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(2188, 977);
            Controls.Add(pnMain);
            Controls.Add(panel1);
            Name = "frmDoctor";
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            Load += frmDoctor_Load;
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            pnlOverview.ResumeLayout(false);
            pnlOverview.PerformLayout();
            pnlAppointment.ResumeLayout(false);
            pnlAppointment.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogout;
        private Panel pnMain;
        private Panel panel7;
        private Panel pnlOverview;
        private Label lblOverviewText;
        private Label lblOverviewIcon;
        private Panel pnlAppointment;
        private Label lblAppText;
        private Label lblAppIcon;
    }
}