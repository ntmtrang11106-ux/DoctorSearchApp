namespace UI_Tier
{
    partial class frmRegister
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
            panel8 = new Panel();
            label5 = new Label();
            label4 = new Label();
            panel7 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            flowLayoutPanel1 = new FlowLayoutPanel();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label13 = new Label();
            panel10 = new Panel();
            textBox5 = new TextBox();
            label12 = new Label();
            panel9 = new Panel();
            textBox4 = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            panel6 = new Panel();
            textBox1 = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            txtUsername = new TextBox();
            label7 = new Label();
            label8 = new Label();
            btnLogin = new Button();
            label1 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2033, 1504);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.BackColor = Color.FromArgb(24, 112, 255);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 263);
            panel2.Name = "panel2";
            panel2.Size = new Size(2009, 1154);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(16, 22);
            panel3.Name = "panel3";
            panel3.Size = new Size(1979, 1116);
            panel3.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.Controls.Add(label5);
            panel8.Controls.Add(label4);
            panel8.Location = new Point(990, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(989, 125);
            panel8.TabIndex = 26;
            panel8.MouseClick += panel8_MouseClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label5.Location = new Point(400, 15);
            label5.Name = "label5";
            label5.Size = new Size(211, 47);
            label5.TabIndex = 2;
            label5.Text = "Tôi là Bác sĩ";
            label5.MouseClick += panel8_MouseClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            label4.Location = new Point(96, 62);
            label4.Name = "label4";
            label4.Size = new Size(816, 41);
            label4.TabIndex = 3;
            label4.Text = "Cung cấp dịch vụ khám chữa bệnh, theo dõi hồ sơ bệnh án, ...";
            label4.MouseClick += panel8_MouseClick;
            // 
            // panel7
            // 
            panel7.Controls.Add(label3);
            panel7.Controls.Add(label2);
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(989, 125);
            panel7.TabIndex = 25;
            panel7.MouseClick += panel7_MouseClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            label3.Location = new Point(183, 62);
            label3.Name = "label3";
            label3.Size = new Size(653, 41);
            label3.TabIndex = 1;
            label3.Text = "Tìm kiếm Bác sĩ, đặt lịch hẹn, theo dõi sức khỏe...";
            label3.MouseClick += panel7_MouseClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.Location = new Point(363, 15);
            label2.Name = "label2";
            label2.Size = new Size(293, 47);
            label2.TabIndex = 0;
            label2.Text = "Tôi là Bệnh nhân";
            label2.MouseClick += panel7_MouseClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(dateTimePicker1);
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(panel10);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(panel9);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(btnLogin);
            panel4.Location = new Point(0, 125);
            panel4.Name = "panel4";
            panel4.Size = new Size(1979, 991);
            panel4.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 12F);
            dateTimePicker1.CustomFormat = "  dd / MM / yyyy";
            dateTimePicker1.Font = new Font("Segoe UI", 12F);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(135, 510);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(732, 50);
            dateTimePicker1.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radioButton1);
            flowLayoutPanel1.Controls.Add(radioButton2);
            flowLayoutPanel1.Location = new Point(225, 704);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(473, 60);
            flowLayoutPanel1.TabIndex = 23;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 12F);
            radioButton1.Location = new Point(3, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(119, 49);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Nam";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 12F);
            radioButton2.Location = new Point(375, 3);
            radioButton2.Margin = new Padding(250, 3, 3, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(94, 49);
            radioButton2.TabIndex = 24;
            radioButton2.TabStop = true;
            radioButton2.Text = "Nữ";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(1102, 244);
            label13.Name = "label13";
            label13.Size = new Size(279, 45);
            label13.TabIndex = 21;
            label13.Text = "Nhập lại mật khẩu";
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(textBox5);
            panel10.Location = new Point(1111, 292);
            panel10.Name = "panel10";
            panel10.Size = new Size(732, 75);
            panel10.TabIndex = 22;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.CausesValidation = false;
            textBox5.Font = new Font("Segoe UI", 12F);
            textBox5.Location = new Point(15, 13);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(704, 43);
            textBox5.TabIndex = 2;
            textBox5.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(1102, 49);
            label12.Name = "label12";
            label12.Size = new Size(153, 45);
            label12.TabIndex = 19;
            label12.Text = "Mật khẩu";
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(textBox4);
            panel9.Location = new Point(1111, 97);
            panel9.Name = "panel9";
            panel9.Size = new Size(732, 75);
            panel9.TabIndex = 20;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.CausesValidation = false;
            textBox4.Font = new Font("Segoe UI", 12F);
            textBox4.Location = new Point(15, 13);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(704, 43);
            textBox4.TabIndex = 2;
            textBox4.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(126, 647);
            label11.Name = "label11";
            label11.Size = new Size(141, 45);
            label11.TabIndex = 17;
            label11.Text = "Giới tính";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(126, 445);
            label10.Name = "label10";
            label10.Size = new Size(161, 45);
            label10.TabIndex = 15;
            label10.Text = "Ngày sinh";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(126, 244);
            label9.Name = "label9";
            label9.Size = new Size(208, 45);
            label9.TabIndex = 13;
            label9.Text = "Số điện thoại";
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(textBox1);
            panel6.Location = new Point(135, 292);
            panel6.Name = "panel6";
            panel6.Size = new Size(732, 75);
            panel6.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.CausesValidation = false;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(15, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(704, 43);
            textBox1.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(126, 49);
            label6.Name = "label6";
            label6.Size = new Size(157, 45);
            label6.TabIndex = 8;
            label6.Text = "Họ và tên";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(txtUsername);
            panel5.Location = new Point(135, 97);
            panel5.Name = "panel5";
            panel5.Size = new Size(732, 75);
            panel5.TabIndex = 12;
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
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10.125F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Blue;
            label7.Location = new Point(1359, 907);
            label7.Name = "label7";
            label7.Size = new Size(148, 37);
            label7.TabIndex = 11;
            label7.Text = "Đăng nhập";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(1139, 907);
            label8.Name = "label8";
            label8.Size = new Size(214, 37);
            label8.TabIndex = 10;
            label8.Text = "Đã có tài khoản?";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top;
            btnLogin.BackColor = Color.FromArgb(24, 112, 255);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(1139, 797);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(732, 85);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Đăng ký";
            btnLogin.UseCompatibleTextRendering = true;
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1086, 147);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(351, 78);
            label1.TabIndex = 0;
            label1.Text = "Chào mừng";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmRegister
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(2033, 1504);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmRegister";
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel4;
        private Label label6;
        private Panel panel5;
        private TextBox txtUsername;
        private Label label7;
        private Label label8;
        private Button btnLogin;
        private Label label13;
        private Panel panel10;
        private TextBox textBox5;
        private Label label12;
        private Panel panel9;
        private TextBox textBox4;
        private Label label11;
        private Label label10;
        private Label label9;
        private Panel panel6;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Panel panel8;
        private Panel panel7;
    }
}