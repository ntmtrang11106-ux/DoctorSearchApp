namespace UI_Tier
{
    partial class ucPatient_SearchDoc
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
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txtSearchBar = new TextBox();
            label2 = new Label();
            label1 = new Label();
            flpFilter = new FlowLayoutPanel();
            btnCardiology = new Button();
            btnInternalMedicine = new Button();
            btnSurgery = new Button();
            btnObstetrics = new Button();
            btnDermatology = new Button();
            btnENT = new Button();
            btnOphthalmology = new Button();
            btnPediatrics = new Button();
            pnlAlert = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            flpDoctors = new FlowLayoutPanel();
            btnAll = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flpFilter.SuspendLayout();
            pnlAlert.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(txtSearchBar);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(flpFilter);
            panel3.Controls.Add(pnlAlert);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1845, 569);
            panel3.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.filter;
            pictureBox2.Location = new Point(73, 314);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(65, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(73, 232);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(65, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // txtSearchBar
            // 
            txtSearchBar.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchBar.Location = new Point(144, 232);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Tìm kiếm tên bác sĩ ...";
            txtSearchBar.Size = new Size(1653, 57);
            txtSearchBar.TabIndex = 5;
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
            flpFilter.Location = new Point(144, 314);
            flpFilter.Name = "flpFilter";
            flpFilter.Padding = new Padding(10);
            flpFilter.Size = new Size(1653, 132);
            flpFilter.TabIndex = 7;
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
            // pnlAlert
            // 
            pnlAlert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAlert.BackColor = Color.AliceBlue;
            pnlAlert.Controls.Add(lblPageStatus);
            pnlAlert.Controls.Add(lblPrev);
            pnlAlert.Controls.Add(lblNext);
            pnlAlert.Location = new Point(0, 501);
            pnlAlert.Name = "pnlAlert";
            pnlAlert.Padding = new Padding(10);
            pnlAlert.Size = new Size(1845, 67);
            pnlAlert.TabIndex = 8;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 11F);
            lblPageStatus.Location = new Point(1396, 16);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.RightToLeft = RightToLeft.No;
            lblPageStatus.Size = new Size(67, 41);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "1/...";
            // 
            // lblPrev
            // 
            lblPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPrev.AutoSize = true;
            lblPrev.Font = new Font("Segoe UI", 11F);
            lblPrev.Location = new Point(1157, 16);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(219, 41);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "Trang trước <<";
            lblPrev.Click += lblPrev_Click;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Font = new Font("Segoe UI", 11F);
            lblNext.Location = new Point(1590, 16);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(194, 41);
            lblNext.TabIndex = 0;
            lblNext.Text = ">> Trang sau";
            lblNext.Click += lblNext_Click;
            // 
            // flpDoctors
            // 
            flpDoctors.AutoScroll = true;
            flpDoctors.Dock = DockStyle.Fill;
            flpDoctors.Location = new Point(0, 569);
            flpDoctors.Name = "flpDoctors";
            flpDoctors.Size = new Size(1845, 293);
            flpDoctors.TabIndex = 7;
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
            // ucPatient_SearchDoc
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpDoctors);
            Controls.Add(panel3);
            Name = "ucPatient_SearchDoc";
            Size = new Size(1845, 862);
            Load += ucPatient_SearchDoc_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flpFilter.ResumeLayout(false);
            pnlAlert.ResumeLayout(false);
            pnlAlert.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel flpFilter;
        private Button btnCardiology;
        private Button btnInternalMedicine;
        private Button btnSurgery;
        private Button btnObstetrics;
        private Button btnDermatology;
        private Button btnENT;
        private Button btnOphthalmology;
        private Button btnPediatrics;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox txtSearchBar;
        private FlowLayoutPanel flpDoctors;
        private Panel pnlAlert;
        private Label lblPageStatus;
        private Label lblPrev;
        private Label lblNext;
        private Button btnAll;
    }
}
