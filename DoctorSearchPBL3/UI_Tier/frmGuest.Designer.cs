namespace UI_Tier
{
    partial class frmGuest
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
            pnlSearch = new Panel();
            pnlAlert = new Panel();
            label3 = new Label();
            label4 = new Label();
            flpFilter = new FlowLayoutPanel();
            btnAll = new Button();
            btnCardiology = new Button();
            btnInternalMedicine = new Button();
            btnSurgery = new Button();
            btnObstetrics = new Button();
            btnDermatology = new Button();
            btnENT = new Button();
            btnOphthalmology = new Button();
            btnPediatrics = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            flpDoctors = new FlowLayoutPanel();
            panel1.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlAlert.SuspendLayout();
            flpFilter.SuspendLayout();
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
            panel1.Size = new Size(1845, 115);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(24, 112, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1531, 23);
            button1.Name = "button1";
            button1.Size = new Size(277, 65);
            button1.TabIndex = 1;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.Paint += btn_Paint;
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
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.Controls.Add(pnlAlert);
            pnlSearch.Controls.Add(flpFilter);
            pnlSearch.Controls.Add(pictureBox2);
            pnlSearch.Controls.Add(pictureBox1);
            pnlSearch.Controls.Add(txtSearchBar);
            pnlSearch.Location = new Point(0, 312);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1845, 299);
            pnlSearch.TabIndex = 2;
            // 
            // pnlAlert
            // 
            pnlAlert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAlert.BackColor = Color.AliceBlue;
            pnlAlert.Controls.Add(label3);
            pnlAlert.Controls.Add(label4);
            pnlAlert.Location = new Point(0, 229);
            pnlAlert.Name = "pnlAlert";
            pnlAlert.Padding = new Padding(10);
            pnlAlert.Size = new Size(1845, 70);
            pnlAlert.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(157, 17);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(978, 47);
            label3.TabIndex = 0;
            label3.Text = "Bạn đang ở chế độ khách. Vui lòng đăng nhập để có thể đặt lịch khám với bác sĩ.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(43, 20);
            label4.Name = "label4";
            label4.Size = new Size(87, 37);
            label4.TabIndex = 1;
            label4.Text = "Lưu ý:";
            // 
            // flpFilter
            // 
            flpFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flpFilter.Controls.Add(btnAll);
            flpFilter.Controls.Add(btnCardiology);
            flpFilter.Controls.Add(btnInternalMedicine);
            flpFilter.Controls.Add(btnSurgery);
            flpFilter.Controls.Add(btnObstetrics);
            flpFilter.Controls.Add(btnDermatology);
            flpFilter.Controls.Add(btnENT);
            flpFilter.Controls.Add(btnOphthalmology);
            flpFilter.Controls.Add(btnPediatrics);
            flpFilter.Location = new Point(144, 91);
            flpFilter.Name = "flpFilter";
            flpFilter.Padding = new Padding(10);
            flpFilter.Size = new Size(1653, 132);
            flpFilter.TabIndex = 3;
            flpFilter.Paint += flowLayoutPanel2_Paint;
            // 
            // btnAll
            // 
            btnAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAll.ForeColor = Color.Black;
            btnAll.Location = new Point(13, 13);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(255, 55);
            btnAll.TabIndex = 0;
            btnAll.Text = "Tất cả";
            btnAll.UseVisualStyleBackColor = true;
            // 
            // btnCardiology
            // 
            btnCardiology.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCardiology.Location = new Point(274, 13);
            btnCardiology.Name = "btnCardiology";
            btnCardiology.Size = new Size(255, 55);
            btnCardiology.TabIndex = 3;
            btnCardiology.Text = "Tim mạch";
            btnCardiology.UseVisualStyleBackColor = true;
            // 
            // btnInternalMedicine
            // 
            btnInternalMedicine.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInternalMedicine.Location = new Point(535, 13);
            btnInternalMedicine.Name = "btnInternalMedicine";
            btnInternalMedicine.Size = new Size(255, 55);
            btnInternalMedicine.TabIndex = 3;
            btnInternalMedicine.Text = "Nội khoa";
            btnInternalMedicine.UseVisualStyleBackColor = true;
            // 
            // btnSurgery
            // 
            btnSurgery.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSurgery.Location = new Point(796, 13);
            btnSurgery.Name = "btnSurgery";
            btnSurgery.Size = new Size(255, 55);
            btnSurgery.TabIndex = 3;
            btnSurgery.Text = "Ngoại khoa";
            btnSurgery.UseVisualStyleBackColor = true;
            // 
            // btnObstetrics
            // 
            btnObstetrics.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnObstetrics.Location = new Point(1057, 13);
            btnObstetrics.Name = "btnObstetrics";
            btnObstetrics.Size = new Size(255, 55);
            btnObstetrics.TabIndex = 3;
            btnObstetrics.Text = "Sản khoa";
            btnObstetrics.UseVisualStyleBackColor = true;
            // 
            // btnDermatology
            // 
            btnDermatology.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDermatology.Location = new Point(1318, 13);
            btnDermatology.Name = "btnDermatology";
            btnDermatology.Size = new Size(255, 55);
            btnDermatology.TabIndex = 3;
            btnDermatology.Text = "Da liễu";
            btnDermatology.UseVisualStyleBackColor = true;
            // 
            // btnENT
            // 
            btnENT.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnENT.Location = new Point(13, 74);
            btnENT.Name = "btnENT";
            btnENT.Size = new Size(255, 55);
            btnENT.TabIndex = 3;
            btnENT.Text = "Tai mũi họng";
            btnENT.UseVisualStyleBackColor = true;
            // 
            // btnOphthalmology
            // 
            btnOphthalmology.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOphthalmology.Location = new Point(274, 74);
            btnOphthalmology.Name = "btnOphthalmology";
            btnOphthalmology.Size = new Size(255, 55);
            btnOphthalmology.TabIndex = 3;
            btnOphthalmology.Text = "Mắt";
            btnOphthalmology.UseVisualStyleBackColor = true;
            // 
            // btnPediatrics
            // 
            btnPediatrics.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPediatrics.Location = new Point(535, 74);
            btnPediatrics.Name = "btnPediatrics";
            btnPediatrics.Size = new Size(255, 55);
            btnPediatrics.TabIndex = 3;
            btnPediatrics.Text = "Nhi khoa";
            btnPediatrics.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.filter;
            pictureBox2.Location = new Point(73, 103);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(65, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(73, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(65, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 115);
            panel3.Name = "panel3";
            panel3.Size = new Size(1845, 220);
            panel3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
            label2.Location = new Point(56, 84);
            label2.Name = "label2";
            label2.Size = new Size(880, 47);
            label2.TabIndex = 1;
            label2.Text = "Đặt lịch khám nhanh chóng, tư vấn chuyên khoa tiện lợi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(43, 12);
            label1.Name = "label1";
            label1.Size = new Size(735, 62);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm bác sĩ phù hợp với bạn";
            // 
            // flpDoctors
            // 
            flpDoctors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpDoctors.AutoScroll = true;
            flpDoctors.Location = new Point(0, 617);
            flpDoctors.Name = "flpDoctors";
            flpDoctors.Size = new Size(1845, 360);
            flpDoctors.TabIndex = 4;
            // 
            // frmGuest
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1845, 977);
            Controls.Add(flpDoctors);
            Controls.Add(panel3);
            Controls.Add(pnlSearch);
            Controls.Add(panel1);
            Cursor = Cursors.SizeAll;
            Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmGuest";
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            Load += frmHome_Load;
            panel1.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlAlert.ResumeLayout(false);
            pnlAlert.PerformLayout();
            flpFilter.ResumeLayout(false);
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
        private Panel pnlSearch;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnSurgery;
        private Button btnInternalMedicine;
        private Button btnDermatology;
        private Button btnAll;
        private Button btnCardiology;
        private Button btnPediatrics;
        private Button btnENT;
        private Button btnObstetrics;
        private Button btnOphthalmology;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flpDoctors;
        private FlowLayoutPanel flpFilter;
        private Panel pnlAlert;
        private Label label3;
        private Label label4;
    }
}