namespace UI_Tier
{
    partial class ucAdmin_ArticleManagement
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
            pnlStats = new TableLayoutPanel();
            pnlCard1 = new Panel();
            lblTitle1 = new Label();
            lblValue1 = new Label();
            pnlIcon1 = new Panel();
            lblIcon1 = new Label();
            pnlCard2 = new Panel();
            lblTitle2 = new Label();
            lblValue2 = new Label();
            pnlIcon2 = new Panel();
            lblIcon2 = new Label();
            pnlCard3 = new Panel();
            lblTitle3 = new Label();
            lblValue3 = new Label();
            pnlIcon3 = new Panel();
            lblIcon3 = new Label();
            pnlCard4 = new Panel();
            lblTitle4 = new Label();
            lblValue4 = new Label();
            pnlIcon4 = new Panel();
            lblIcon4 = new Label();
            pnlHeader = new Panel();
            btnAddArticle = new Button();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            ucSearchArticle = new ucGuest_IntegratedSearch();
            pnlStats.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlIcon1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlIcon2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlIcon3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlIcon4.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStats
            // 
            pnlStats.ColumnCount = 4;
            pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.Controls.Add(pnlCard1, 0, 0);
            pnlStats.Controls.Add(pnlCard2, 1, 0);
            pnlStats.Controls.Add(pnlCard3, 2, 0);
            pnlStats.Controls.Add(pnlCard4, 3, 0);
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(40, 122);
            pnlStats.Margin = new Padding(0);
            pnlStats.Name = "pnlStats";
            pnlStats.Padding = new Padding(10);
            pnlStats.RowCount = 1;
            pnlStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStats.Size = new Size(1800, 219);
            pnlStats.TabIndex = 0;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.Controls.Add(lblTitle1);
            pnlCard1.Controls.Add(lblValue1);
            pnlCard1.Controls.Add(pnlIcon1);
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.Location = new Point(15, 15);
            pnlCard1.Margin = new Padding(5);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(435, 189);
            pnlCard1.TabIndex = 0;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Segoe UI", 10F);
            lblTitle1.ForeColor = Color.Gray;
            lblTitle1.Location = new Point(20, 10);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(172, 37);
            lblTitle1.TabIndex = 0;
            lblTitle1.Text = "Tổng bài viết";
            // 
            // lblValue1
            // 
            lblValue1.AutoSize = true;
            lblValue1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue1.ForeColor = Color.FromArgb(17, 34, 71);
            lblValue1.Location = new Point(20, 49);
            lblValue1.Name = "lblValue1";
            lblValue1.Size = new Size(74, 86);
            lblValue1.TabIndex = 1;
            lblValue1.Text = "6";
            // 
            // pnlIcon1
            // 
            pnlIcon1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon1.BackColor = Color.FromArgb(242, 247, 255);
            pnlIcon1.Controls.Add(lblIcon1);
            pnlIcon1.Location = new Point(325, 35);
            pnlIcon1.Name = "pnlIcon1";
            pnlIcon1.Size = new Size(90, 90);
            pnlIcon1.TabIndex = 2;
            // 
            // lblIcon1
            // 
            lblIcon1.Dock = DockStyle.Fill;
            lblIcon1.Font = new Font("Segoe MDL2 Assets", 28F);
            lblIcon1.ForeColor = Color.FromArgb(37, 99, 235);
            lblIcon1.Location = new Point(0, 0);
            lblIcon1.Name = "lblIcon1";
            lblIcon1.Size = new Size(90, 90);
            lblIcon1.TabIndex = 0;
            lblIcon1.Text = "📝";
            lblIcon1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.Controls.Add(lblTitle2);
            pnlCard2.Controls.Add(lblValue2);
            pnlCard2.Controls.Add(pnlIcon2);
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.Location = new Point(460, 15);
            pnlCard2.Margin = new Padding(5);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(435, 189);
            pnlCard2.TabIndex = 1;
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Segoe UI", 10F);
            lblTitle2.ForeColor = Color.Gray;
            lblTitle2.Location = new Point(20, 10);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(159, 37);
            lblTitle2.TabIndex = 0;
            lblTitle2.Text = "Đã xuất bản";
            // 
            // lblValue2
            // 
            lblValue2.AutoSize = true;
            lblValue2.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblValue2.ForeColor = Color.FromArgb(22, 163, 74);
            lblValue2.Location = new Point(20, 44);
            lblValue2.Name = "lblValue2";
            lblValue2.Size = new Size(80, 93);
            lblValue2.TabIndex = 1;
            lblValue2.Text = "4";
            // 
            // pnlIcon2
            // 
            pnlIcon2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon2.BackColor = Color.FromArgb(231, 255, 243);
            pnlIcon2.Controls.Add(lblIcon2);
            pnlIcon2.Location = new Point(325, 35);
            pnlIcon2.Name = "pnlIcon2";
            pnlIcon2.Size = new Size(90, 90);
            pnlIcon2.TabIndex = 2;
            // 
            // lblIcon2
            // 
            lblIcon2.Dock = DockStyle.Fill;
            lblIcon2.Font = new Font("Segoe MDL2 Assets", 28F);
            lblIcon2.ForeColor = Color.FromArgb(22, 163, 74);
            lblIcon2.Location = new Point(0, 0);
            lblIcon2.Name = "lblIcon2";
            lblIcon2.Size = new Size(90, 90);
            lblIcon2.TabIndex = 0;
            lblIcon2.Text = "👁️";
            lblIcon2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.Controls.Add(lblTitle3);
            pnlCard3.Controls.Add(lblValue3);
            pnlCard3.Controls.Add(pnlIcon3);
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.Location = new Point(905, 15);
            pnlCard3.Margin = new Padding(5);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(435, 189);
            pnlCard3.TabIndex = 2;
            // 
            // lblTitle3
            // 
            lblTitle3.AutoSize = true;
            lblTitle3.Font = new Font("Segoe UI", 10F);
            lblTitle3.ForeColor = Color.Gray;
            lblTitle3.Location = new Point(20, 10);
            lblTitle3.Name = "lblTitle3";
            lblTitle3.Size = new Size(128, 37);
            lblTitle3.TabIndex = 0;
            lblTitle3.Text = "Bản nháp";
            // 
            // lblValue3
            // 
            lblValue3.AutoSize = true;
            lblValue3.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblValue3.ForeColor = Color.FromArgb(234, 179, 8);
            lblValue3.Location = new Point(20, 44);
            lblValue3.Name = "lblValue3";
            lblValue3.Size = new Size(80, 93);
            lblValue3.TabIndex = 1;
            lblValue3.Text = "1";
            // 
            // pnlIcon3
            // 
            pnlIcon3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon3.BackColor = Color.FromArgb(255, 248, 235);
            pnlIcon3.Controls.Add(lblIcon3);
            pnlIcon3.Location = new Point(325, 35);
            pnlIcon3.Name = "pnlIcon3";
            pnlIcon3.Size = new Size(90, 90);
            pnlIcon3.TabIndex = 2;
            // 
            // lblIcon3
            // 
            lblIcon3.Dock = DockStyle.Fill;
            lblIcon3.Font = new Font("Segoe MDL2 Assets", 28F);
            lblIcon3.ForeColor = Color.FromArgb(234, 179, 8);
            lblIcon3.Location = new Point(0, 0);
            lblIcon3.Name = "lblIcon3";
            lblIcon3.Size = new Size(90, 90);
            lblIcon3.TabIndex = 0;
            lblIcon3.Text = "📝";
            lblIcon3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.Controls.Add(lblTitle4);
            pnlCard4.Controls.Add(lblValue4);
            pnlCard4.Controls.Add(pnlIcon4);
            pnlCard4.Dock = DockStyle.Fill;
            pnlCard4.Location = new Point(1350, 15);
            pnlCard4.Margin = new Padding(5);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(435, 189);
            pnlCard4.TabIndex = 3;
            // 
            // lblTitle4
            // 
            lblTitle4.AutoSize = true;
            lblTitle4.Font = new Font("Segoe UI", 10F);
            lblTitle4.ForeColor = Color.Gray;
            lblTitle4.Location = new Point(20, 10);
            lblTitle4.Name = "lblTitle4";
            lblTitle4.Size = new Size(127, 37);
            lblTitle4.TabIndex = 0;
            lblTitle4.Text = "Lượt xem";
            // 
            // lblValue4
            // 
            lblValue4.AutoSize = true;
            lblValue4.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblValue4.ForeColor = Color.FromArgb(15, 23, 42);
            lblValue4.Location = new Point(3, 44);
            lblValue4.Name = "lblValue4";
            lblValue4.Size = new Size(259, 93);
            lblValue4.TabIndex = 1;
            lblValue4.Text = "14.150";
            // 
            // pnlIcon4
            // 
            pnlIcon4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIcon4.BackColor = Color.FromArgb(242, 240, 255);
            pnlIcon4.Controls.Add(lblIcon4);
            pnlIcon4.Location = new Point(320, 35);
            pnlIcon4.Name = "pnlIcon4";
            pnlIcon4.Size = new Size(90, 90);
            pnlIcon4.TabIndex = 2;
            // 
            // lblIcon4
            // 
            lblIcon4.Dock = DockStyle.Fill;
            lblIcon4.Font = new Font("Segoe MDL2 Assets", 28F);
            lblIcon4.ForeColor = Color.FromArgb(168, 85, 247);
            lblIcon4.Location = new Point(0, 0);
            lblIcon4.Name = "lblIcon4";
            lblIcon4.Size = new Size(90, 90);
            lblIcon4.TabIndex = 0;
            lblIcon4.Text = "👁️";
            lblIcon4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnAddArticle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(40, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1800, 122);
            pnlHeader.TabIndex = 1;
            // 
            // btnAddArticle
            // 
            btnAddArticle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddArticle.BackColor = Color.FromArgb(37, 99, 235);
            btnAddArticle.FlatAppearance.BorderSize = 0;
            btnAddArticle.FlatStyle = FlatStyle.Flat;
            btnAddArticle.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddArticle.ForeColor = Color.White;
            btnAddArticle.Location = new Point(1435, 27);
            btnAddArticle.Name = "btnAddArticle";
            btnAddArticle.Size = new Size(350, 75);
            btnAddArticle.TabIndex = 2;
            btnAddArticle.Text = "+  Thêm bài viết";
            btnAddArticle.UseVisualStyleBackColor = false;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 10F);
            lblHeaderSubtitle.ForeColor = Color.Gray;
            lblHeaderSubtitle.Location = new Point(15, 65);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(503, 37);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Tạo, chỉnh sửa và quản lý các bài viết y tế";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeaderTitle.Location = new Point(5, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(382, 65);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Quản lý bài viết";
            // 
            // ucSearchArticle
            // 
            ucSearchArticle.BackColor = Color.White;
            ucSearchArticle.Dock = DockStyle.Fill;
            ucSearchArticle.Location = new Point(40, 341);
            ucSearchArticle.Margin = new Padding(5);
            ucSearchArticle.Name = "ucSearchArticle";
            ucSearchArticle.Size = new Size(1800, 869);
            ucSearchArticle.TabIndex = 2;
            // 
            // ucAdmin_ArticleManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(ucSearchArticle);
            Controls.Add(pnlStats);
            Controls.Add(pnlHeader);
            Name = "ucAdmin_ArticleManagement";
            Padding = new Padding(40, 0, 40, 20);
            Size = new Size(1880, 1230);
            Load += ucAdmin_ArticleManagement_Load;
            pnlStats.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlIcon1.ResumeLayout(false);
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlIcon2.ResumeLayout(false);
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlIcon3.ResumeLayout(false);
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            pnlIcon4.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.Panel pnlIcon1;
        private System.Windows.Forms.Label lblIcon1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.Panel pnlIcon2;
        private System.Windows.Forms.Label lblIcon2;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.Panel pnlIcon3;
        private System.Windows.Forms.Label lblIcon3;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblTitle4;
        private System.Windows.Forms.Label lblValue4;
        private System.Windows.Forms.Panel pnlIcon4;
        private System.Windows.Forms.Label lblIcon4;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Button btnAddArticle;
        private ucGuest_IntegratedSearch ucSearchArticle;
    }
}
