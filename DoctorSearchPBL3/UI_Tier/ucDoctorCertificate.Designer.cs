namespace UI_Tier
{
    partial class ucDoctorCertificate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel14 = new Panel();
            comboBox3 = new ComboBox();
            label17 = new Label();
            panel22 = new Panel();
            label18 = new Label();
            panel23 = new Panel();
            textBox6 = new TextBox();
            panel25 = new Panel();
            comboBox4 = new ComboBox();
            label21 = new Label();
            panel26 = new Panel();
            panel29 = new Panel();
            label24 = new Label();
            label22 = new Label();
            btnCancel = new Button();
            lblCertIndex = new Label();
            panel14.SuspendLayout();
            panel22.SuspendLayout();
            panel23.SuspendLayout();
            panel25.SuspendLayout();
            panel26.SuspendLayout();
            panel29.SuspendLayout();
            SuspendLayout();
            // 
            // panel14
            // 
            panel14.Controls.Add(comboBox3);
            panel14.Controls.Add(label17);
            panel14.Location = new Point(46, 69);
            panel14.Name = "panel14";
            panel14.Size = new Size(788, 143);
            panel14.TabIndex = 34;
            // 
            // comboBox3
            // 
            comboBox3.Font = new Font("Segoe UI", 11F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(12, 69);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(732, 48);
            comboBox3.TabIndex = 22;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 11F);
            label17.ForeColor = SystemColors.ControlText;
            label17.Location = new Point(3, 8);
            label17.Name = "label17";
            label17.Size = new Size(192, 41);
            label17.TabIndex = 21;
            label17.Text = "Chuyên khoa";
            // 
            // panel22
            // 
            panel22.Controls.Add(label18);
            panel22.Controls.Add(panel23);
            panel22.Location = new Point(46, 218);
            panel22.Name = "panel22";
            panel22.Size = new Size(788, 151);
            panel22.TabIndex = 35;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 11F);
            label18.Location = new Point(3, 8);
            label18.Name = "label18";
            label18.Size = new Size(353, 41);
            label18.TabIndex = 21;
            label18.Text = "Mã Chứng chỉ hành nghề";
            // 
            // panel23
            // 
            panel23.BackColor = Color.White;
            panel23.BorderStyle = BorderStyle.FixedSingle;
            panel23.Controls.Add(textBox6);
            panel23.Location = new Point(12, 56);
            panel23.Name = "panel23";
            panel23.Size = new Size(732, 75);
            panel23.TabIndex = 22;
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.CausesValidation = false;
            textBox6.Font = new Font("Segoe UI", 11F);
            textBox6.Location = new Point(15, 13);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(704, 40);
            textBox6.TabIndex = 2;
            // 
            // panel25
            // 
            panel25.Controls.Add(comboBox4);
            panel25.Controls.Add(label21);
            panel25.Location = new Point(46, 375);
            panel25.Name = "panel25";
            panel25.Size = new Size(788, 151);
            panel25.TabIndex = 36;
            // 
            // comboBox4
            // 
            comboBox4.Font = new Font("Segoe UI", 11F);
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(12, 69);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(732, 48);
            comboBox4.TabIndex = 22;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 11F);
            label21.ForeColor = SystemColors.ControlText;
            label21.Location = new Point(3, 8);
            label21.Name = "label21";
            label21.Size = new Size(274, 41);
            label21.TabIndex = 21;
            label21.Text = "Năm cấp chứng chỉ";
            // 
            // panel26
            // 
            panel26.Controls.Add(panel29);
            panel26.Controls.Add(label22);
            panel26.Location = new Point(46, 532);
            panel26.Name = "panel26";
            panel26.Size = new Size(788, 151);
            panel26.TabIndex = 37;
            // 
            // panel29
            // 
            panel29.BackColor = Color.White;
            panel29.BorderStyle = BorderStyle.FixedSingle;
            panel29.Controls.Add(label24);
            panel29.Location = new Point(107, 56);
            panel29.Name = "panel29";
            panel29.Size = new Size(564, 73);
            panel29.TabIndex = 23;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 11F);
            label24.ForeColor = SystemColors.ControlDarkDark;
            label24.Location = new Point(62, 14);
            label24.Name = "label24";
            label24.Size = new Size(374, 41);
            label24.TabIndex = 22;
            label24.Text = "Bấm vào đây để tải ảnh lên";
            label24.Click += label24_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 11F);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(3, 8);
            label22.Name = "label22";
            label22.Size = new Size(275, 41);
            label22.TabIndex = 21;
            label22.Text = "Hình ảnh chứng chỉ";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe MDL2 Assets", 15F);
            btnCancel.ForeColor = Color.DarkRed;
            btnCancel.Location = new Point(783, 0);
            btnCancel.Margin = new Padding(0, 5, 70, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(66, 66);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "";
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblCertIndex
            // 
            lblCertIndex.AutoSize = true;
            lblCertIndex.BackColor = Color.Azure;
            lblCertIndex.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCertIndex.ForeColor = Color.Black;
            lblCertIndex.Location = new Point(0, 0);
            lblCertIndex.Name = "lblCertIndex";
            lblCertIndex.Size = new Size(187, 45);
            lblCertIndex.TabIndex = 38;
            lblCertIndex.Text = "Chứng chỉ 1";
            // 
            // ucDoctorCertificate
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblCertIndex);
            Controls.Add(btnCancel);
            Controls.Add(panel14);
            Controls.Add(panel22);
            Controls.Add(panel25);
            Controls.Add(panel26);
            Name = "ucDoctorCertificate";
            Size = new Size(849, 706);
            Load += ucDoctorCertificate_Load;
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel22.ResumeLayout(false);
            panel22.PerformLayout();
            panel23.ResumeLayout(false);
            panel23.PerformLayout();
            panel25.ResumeLayout(false);
            panel25.PerformLayout();
            panel26.ResumeLayout(false);
            panel26.PerformLayout();
            panel29.ResumeLayout(false);
            panel29.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel14;
        private ComboBox comboBox3;
        private Label label17;
        private Panel panel22;
        private Label label18;
        private Panel panel23;
        private TextBox textBox6;
        private Panel panel25;
        private ComboBox comboBox4;
        private Label label21;
        private Panel panel26;
        private Panel panel29;
        private Label label24;
        private Label label22;
        private Button btnCancel;
        public Label lblCertIndex;
    }
}
