//using System.Xml.Linq;
//using static System.Net.Mime.MediaTypeNames;

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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            btnLogin = new Button();
            txtSearchBar = new TextBox();
            pnlSearch = new Panel();
            pnlAlert = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            flpFilter = new FlowLayoutPanel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            flpArticles = new FlowLayoutPanel();
            flpDoctors = new FlowLayoutPanel();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlAlert.SuspendLayout();
            flpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogin);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1845, 115);
            panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogin.BackColor = Color.FromArgb(24, 112, 255);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(1531, 23);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(277, 65);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // txtSearchBar
            // 
            txtSearchBar.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchBar.Location = new Point(144, 21);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Tìm bác sĩ, khoa hoặc nội dung...";
            txtSearchBar.Size = new Size(1653, 44);
            txtSearchBar.TabIndex = 1;
            txtSearchBar.TextChanged += txtSearchBar_TextChanged;
            txtSearchBar.KeyDown += txtSearchBar_KeyDown;
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
            pnlAlert.Controls.Add(lblPageStatus);
            pnlAlert.Controls.Add(lblPrev);
            pnlAlert.Controls.Add(lblNext);
            pnlAlert.Location = new Point(0, 229);
            pnlAlert.Name = "pnlAlert";
            pnlAlert.Padding = new Padding(10);
            pnlAlert.Size = new Size(1845, 70);
            pnlAlert.TabIndex = 5;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 11F);
            lblPageStatus.Location = new Point(1379, 14);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.RightToLeft = RightToLeft.No;
            lblPageStatus.Size = new Size(49, 30);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "1/...";
            // 
            // lblPrev
            // 
            lblPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPrev.AutoSize = true;
            lblPrev.Font = new Font("Segoe UI", 11F);
            lblPrev.Location = new Point(1140, 14);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(160, 30);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "Trang trước <<";
            lblPrev.Click += lblPrev_Click;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Font = new Font("Segoe UI", 11F);
            lblNext.Location = new Point(1554, 14);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(141, 30);
            lblNext.TabIndex = 0;
            lblNext.Text = ">> Trang sau";
            lblNext.Click += lblNext_Click;
            // 
            // flpFilter
            // 
            flpFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flpFilter.Location = new Point(144, 91);
            flpFilter.Name = "flpFilter";
            flpFilter.Padding = new Padding(10);
            flpFilter.Size = new Size(1687, 132);
            flpFilter.TabIndex = 3;
            flpFilter.Paint += flowLayoutPanel2_Paint;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 617);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1863, 441);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(flpDoctors);
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1855, 400);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Bác sĩ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flpArticles);
            tabPage2.Location = new Point(4, 37);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1855, 400);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Nội dung";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flpArticles
            // 
            flpArticles.Dock = DockStyle.Fill;
            flpArticles.Location = new Point(3, 3);
            flpArticles.Name = "flpArticles";
            flpArticles.Size = new Size(1849, 394);
            flpArticles.TabIndex = 0;
            // 
            // flpDoctors
            // 
            flpDoctors.Dock = DockStyle.Fill;
            flpDoctors.AutoScroll = true;
            flpDoctors.Location = new Point(3, 3);
            flpDoctors.Name = "flpDoctors";
            flpDoctors.Size = new Size(1849, 394);
            flpDoctors.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.White;
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 115);
            panel3.Name = "panel3";
            panel3.Size = new Size(1845, 212);
            panel3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
            label2.Location = new Point(56, 84);
            label2.Name = "label2";
            label2.Size = new Size(645, 36);
            label2.TabIndex = 1;
            label2.Text = "Đặt lịch khám nhanh chóng, tư vấn chuyên khoa tiện lợi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(43, 12);
            label1.Name = "label1";
            label1.Size = new Size(535, 46);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm bác sĩ và nội dung phù hợp";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmGuest
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1845, 977);
            Controls.Add(panel3);
            Controls.Add(tabControl1);
            Controls.Add(pnlSearch);
            Controls.Add(panel1);
            Cursor = Cursors.SizeAll;
            Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmGuest";
            Text = "DoctorSearch";
            WindowState = FormWindowState.Maximized;
            Load += frmGuest_Load;
            panel1.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlAlert.ResumeLayout(false);
            pnlAlert.PerformLayout();
            flpFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogin;
        private TextBox txtSearchBar;
        private Panel pnlSearch;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flpFilter;
        private Panel pnlAlert;
        private Label lblPrev;
        private Label lblNext;
        private Label lblPageStatus;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private FlowLayoutPanel flpDoctors;
        private FlowLayoutPanel flpArticles;
        private ErrorProvider errorProvider1;
    }
}
