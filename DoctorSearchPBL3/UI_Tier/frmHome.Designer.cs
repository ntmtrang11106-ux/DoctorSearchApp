namespace UI_Tier
{
    partial class frmHome
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
            button1 = new Button();
            txtSearchBar = new TextBox();
            panel2 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button2 = new Button();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button4 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            flpDoctors = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1845, 98);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(24, 119, 242);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1557, 16);
            button1.Name = "button1";
            button1.Size = new Size(268, 65);
            button1.TabIndex = 1;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtSearchBar
            // 
            txtSearchBar.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchBar.Location = new Point(144, 21);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Tìm kiếm tên bác sĩ ...";
            txtSearchBar.Size = new Size(1653, 57);
            txtSearchBar.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(txtSearchBar);
            panel2.Location = new Point(0, 219);
            panel2.Name = "panel2";
            panel2.Size = new Size(1845, 260);
            panel2.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.Controls.Add(button2);
            flowLayoutPanel2.Controls.Add(button3);
            flowLayoutPanel2.Controls.Add(button5);
            flowLayoutPanel2.Controls.Add(button6);
            flowLayoutPanel2.Controls.Add(button7);
            flowLayoutPanel2.Controls.Add(button4);
            flowLayoutPanel2.Controls.Add(button8);
            flowLayoutPanel2.Controls.Add(button9);
            flowLayoutPanel2.Controls.Add(button10);
            flowLayoutPanel2.Location = new Point(144, 103);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(10);
            flowLayoutPanel2.Size = new Size(1653, 138);
            flowLayoutPanel2.TabIndex = 3;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(13, 13);
            button2.Name = "button2";
            button2.Size = new Size(252, 49);
            button2.TabIndex = 0;
            button2.Text = "Tất cả";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(271, 13);
            button3.Name = "button3";
            button3.Size = new Size(252, 49);
            button3.TabIndex = 3;
            button3.Text = "Tim mạch";
            button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(529, 13);
            button5.Name = "button5";
            button5.Size = new Size(252, 49);
            button5.TabIndex = 3;
            button5.Text = "Nội khoa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(787, 13);
            button6.Name = "button6";
            button6.Size = new Size(252, 49);
            button6.TabIndex = 3;
            button6.Text = "Ngoại khoa";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.Location = new Point(1045, 13);
            button7.Name = "button7";
            button7.Size = new Size(252, 49);
            button7.TabIndex = 3;
            button7.Text = "Sản khoa";
            button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(1303, 13);
            button4.Name = "button4";
            button4.Size = new Size(252, 49);
            button4.TabIndex = 3;
            button4.Text = "Da liễu";
            button4.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(13, 68);
            button8.Name = "button8";
            button8.Size = new Size(252, 54);
            button8.TabIndex = 3;
            button8.Text = "Tai mũi họng";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.Location = new Point(271, 68);
            button9.Name = "button9";
            button9.Size = new Size(252, 49);
            button9.TabIndex = 3;
            button9.Text = "Mắt";
            button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.Location = new Point(529, 68);
            button10.Name = "button10";
            button10.Size = new Size(252, 49);
            button10.TabIndex = 3;
            button10.Text = "Nhi khoa";
            button10.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.filter;
            pictureBox2.Location = new Point(73, 103);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(65, 52);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(73, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(62, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 98);
            panel3.Name = "panel3";
            panel3.Size = new Size(1845, 120);
            panel3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.125F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(60, 65);
            label2.Name = "label2";
            label2.Size = new Size(670, 37);
            label2.TabIndex = 1;
            label2.Text = "Đặt lịch khám nhanh chóng, tư vấn chuyên khoa tiện lợi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 12);
            label1.Name = "label1";
            label1.Size = new Size(587, 50);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm bác sĩ phù hợp với bạn";
            // 
            // flpDoctors
            // 
            flpDoctors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpDoctors.AutoScroll = true;
            flpDoctors.Location = new Point(0, 485);
            flpDoctors.Name = "flpDoctors";
            flpDoctors.Size = new Size(1845, 492);
            flpDoctors.TabIndex = 4;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1845, 977);
            Controls.Add(flpDoctors);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Cursor = Cursors.SizeAll;
            Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmHome";
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            Load += frmHome_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private TextBox txtSearchBar;
        private Panel panel2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button2;
        private Button button3;
        private Button button10;
        private Button button8;
        private Button button7;
        private Button button9;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flpDoctors;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}