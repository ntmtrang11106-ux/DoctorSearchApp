namespace UI_Tier
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpDoctors = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlHeader = new Panel();
            btnLogin = new Button();
            txtSearch = new TextBox();
            picLogo = new PictureBox();
            panel2 = new Panel();
            label2 = new Label();
            cboSpecialty = new ComboBox();
            label1 = new Label();
            lblSubTitle = new Label();
            lblTitle = new Label();
            pnlAlert = new Panel();
            label3 = new Label();
            label4 = new Label();
            flpDoctors.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panel2.SuspendLayout();
            pnlAlert.SuspendLayout();
            SuspendLayout();
            // 
            // flpDoctors
            // 
            flpDoctors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpDoctors.AutoScroll = true;
            flpDoctors.Controls.Add(flowLayoutPanel1);
            flpDoctors.Location = new Point(0, 562);
            flpDoctors.Name = "flpDoctors";
            flpDoctors.Size = new Size(1866, 776);
            flpDoctors.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(12, 8);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(btnLogin);
            pnlHeader.Controls.Add(txtSearch);
            pnlHeader.Controls.Add(picLogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1866, 149);
            pnlHeader.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogin.BackColor = Color.FromArgb(24, 119, 242);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(1594, 32);
            btnLogin.Name = "btnLogin";
            btnLogin.Padding = new Padding(10);
            btnLogin.Size = new Size(226, 90);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtSearch.Location = new Point(303, 52);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(407, 39);
            txtSearch.TabIndex = 1;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Left;
            picLogo.Location = new Point(0, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(271, 149);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(cboSpecialty);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblSubTitle);
            panel2.Controls.Add(lblTitle);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 149);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(1866, 289);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(581, 204);
            label2.Name = "label2";
            label2.Size = new Size(78, 32);
            label2.TabIndex = 4;
            label2.Text = "label2";
            // 
            // cboSpecialty
            // 
            cboSpecialty.FormattingEnabled = true;
            cboSpecialty.Location = new Point(223, 204);
            cboSpecialty.Name = "cboSpecialty";
            cboSpecialty.Size = new Size(301, 40);
            cboSpecialty.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 212);
            label1.Name = "label1";
            label1.Size = new Size(160, 32);
            label1.TabIndex = 2;
            label1.Text = "Chuyên khoa:";
            // 
            // lblSubTitle
            // 
            lblSubTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubTitle.ForeColor = Color.DimGray;
            lblSubTitle.Location = new Point(56, 109);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(566, 32);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Đặt lịch khám với các bác sĩ uy tín, chuyên môn cao";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(42, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(553, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tìm bác sĩ chuyên khoa";
            // 
            // pnlAlert
            // 
            pnlAlert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAlert.BackColor = Color.AliceBlue;
            pnlAlert.Controls.Add(label3);
            pnlAlert.Controls.Add(label4);
            pnlAlert.Location = new Point(3, 459);
            pnlAlert.Name = "pnlAlert";
            pnlAlert.Padding = new Padding(10);
            pnlAlert.Size = new Size(1863, 81);
            pnlAlert.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 20);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(889, 42);
            label3.TabIndex = 0;
            label3.Text = "Bạn đang ở chế độ khách. Vui lòng đăng nhập để có thể đặt lịch khám với bác sĩ.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(9, 20);
            label4.Name = "label4";
            label4.Size = new Size(77, 32);
            label4.TabIndex = 1;
            label4.Text = "Lưu ý:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1866, 1338);
            Controls.Add(pnlAlert);
            Controls.Add(panel2);
            Controls.Add(pnlHeader);
            Controls.Add(flpDoctors);
            Name = "Form1";
            WindowState = FormWindowState.Maximized;
            flpDoctors.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlAlert.ResumeLayout(false);
            pnlAlert.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpDoctors;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnlHeader;
        private Panel panel2;
        private Panel pnlAlert;
        private PictureBox picLogo;
        private TextBox txtSearch;
        private Button btnLogin;
        private ComboBox cboSpecialty;
        private Label label1;
        private Label lblSubTitle;
        private Label lblTitle;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
