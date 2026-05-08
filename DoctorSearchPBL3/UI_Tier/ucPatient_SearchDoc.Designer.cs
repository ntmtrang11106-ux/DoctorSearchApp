namespace UI_Tier
{
    partial class ucPatient_SearchDoc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel3 = new Panel();
            label4 = new Label();
            cboSort = new ComboBox();
            label3 = new Label();
            cboGender = new ComboBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txtSearchBar = new TextBox();
            label2 = new Label();
            label1 = new Label();
            flpFilter = new FlowLayoutPanel();
            pnlAlert = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            flpDoctors = new FlowLayoutPanel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlAlert.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(cboSort);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(cboGender);
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
            panel3.Size = new Size(1200, 420);
            panel3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(500, 310);
            label4.Name = "label4";
            label4.Size = new Size(78, 23);
            label4.TabIndex = 11;
            label4.Text = "Sắp xếp:";
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.Font = new Font("Segoe UI", 10F);
            cboSort.FormattingEnabled = true;
            cboSort.Location = new Point(500, 340);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(250, 31);
            cboSort.TabIndex = 10;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(230, 310);
            label3.Name = "label3";
            label3.Size = new Size(85, 23);
            label3.TabIndex = 9;
            label3.Text = "Giới tính:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(230, 340);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(150, 31);
            cboGender.TabIndex = 8;
            cboGender.SelectedIndexChanged += cboGender_SelectedIndexChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.filter;
            pictureBox2.Location = new Point(50, 240);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(50, 160);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // txtSearchBar
            // 
            txtSearchBar.Font = new Font("Segoe UI", 13F);
            txtSearchBar.Location = new Point(100, 160);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Tìm kiếm tên bác sĩ ...";
            txtSearchBar.Size = new Size(1000, 36);
            txtSearchBar.TabIndex = 5;
            txtSearchBar.TextChanged += btnSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(50, 80);
            label2.Name = "label2";
            label2.Size = new Size(528, 28);
            label2.TabIndex = 1;
            label2.Text = "Đặt lịch khám nhanh chóng, tư vấn chuyên khoa tiện lợi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(40, 20);
            label1.Name = "label1";
            label1.Size = new Size(556, 46);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm bác sĩ phù hợp với bạn";
            // 
            // flpFilter
            // 
            flpFilter.AutoScroll = true;
            flpFilter.Location = new Point(100, 230);
            flpFilter.Name = "flpFilter";
            flpFilter.Padding = new Padding(5);
            flpFilter.Size = new Size(1000, 60);
            flpFilter.TabIndex = 7;
            // 
            // pnlAlert
            // 
            pnlAlert.BackColor = Color.AliceBlue;
            pnlAlert.Controls.Add(lblPageStatus);
            pnlAlert.Controls.Add(lblPrev);
            pnlAlert.Controls.Add(lblNext);
            pnlAlert.Dock = DockStyle.Bottom;
            pnlAlert.Location = new Point(0, 370);
            pnlAlert.Name = "pnlAlert";
            pnlAlert.Size = new Size(1200, 50);
            pnlAlert.TabIndex = 8;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 10F);
            lblPageStatus.Location = new Point(550, 15);
            lblPageStatus.Name = "lblPageStatus";
            lblPageStatus.Size = new Size(47, 23);
            lblPageStatus.TabIndex = 2;
            lblPageStatus.Text = "1/...";
            // 
            // lblPrev
            // 
            lblPrev.AutoSize = true;
            lblPrev.Cursor = Cursors.Hand;
            lblPrev.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblPrev.Location = new Point(50, 15);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(134, 23);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "<< Trang trước";
            lblPrev.Click += lblPrev_Click;
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Cursor = Cursors.Hand;
            lblNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.Location = new Point(1010, 15);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(126, 23);
            lblNext.TabIndex = 0;
            lblNext.Text = "Trang sau >>";
            lblNext.Click += lblNext_Click;
            // 
            // flpDoctors
            // 
            flpDoctors.AutoScroll = true;
            flpDoctors.Dock = DockStyle.Fill;
            flpDoctors.Location = new Point(0, 420);
            flpDoctors.Name = "flpDoctors";
            flpDoctors.Padding = new Padding(30, 10, 30, 10);
            flpDoctors.Size = new Size(1200, 380);
            flpDoctors.TabIndex = 7;
            // 
            // ucPatient_SearchDoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpDoctors);
            Controls.Add(panel3);
            Name = "ucPatient_SearchDoc";
            Size = new Size(1200, 800);
            Load += ucPatient_SearchDoc_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlAlert.ResumeLayout(false);
            pnlAlert.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panel3;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel flpFilter;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox txtSearchBar;
        private FlowLayoutPanel flpDoctors;
        private Panel pnlAlert;
        private Label lblPageStatus;
        private Label lblPrev;
        private Label lblNext;
        private Label label3;
        private ComboBox cboGender;
        private Label label4;
        private ComboBox cboSort;
    }
}
