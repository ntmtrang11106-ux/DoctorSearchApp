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
            pnlStats = new System.Windows.Forms.TableLayoutPanel();
            pnlCard1 = new System.Windows.Forms.Panel();
            lblTitle1 = new System.Windows.Forms.Label();
            lblValue1 = new System.Windows.Forms.Label();
            pnlIcon1 = new System.Windows.Forms.Panel();
            lblIcon1 = new System.Windows.Forms.Label();
            pnlCard2 = new System.Windows.Forms.Panel();
            lblTitle2 = new System.Windows.Forms.Label();
            lblValue2 = new System.Windows.Forms.Label();
            pnlIcon2 = new System.Windows.Forms.Panel();
            lblIcon2 = new System.Windows.Forms.Label();
            pnlCard3 = new System.Windows.Forms.Panel();
            lblTitle3 = new System.Windows.Forms.Label();
            lblValue3 = new System.Windows.Forms.Label();
            pnlIcon3 = new System.Windows.Forms.Panel();
            lblIcon3 = new System.Windows.Forms.Label();
            pnlCard4 = new System.Windows.Forms.Panel();
            lblTitle4 = new System.Windows.Forms.Label();
            lblValue4 = new System.Windows.Forms.Label();
            pnlIcon4 = new System.Windows.Forms.Panel();
            lblIcon4 = new System.Windows.Forms.Label();
            pnlHeader = new System.Windows.Forms.Panel();
            lblHeaderTitle = new System.Windows.Forms.Label();
            lblHeaderSubtitle = new System.Windows.Forms.Label();
            btnAddArticle = new System.Windows.Forms.Button();
            ucSearchArticle = new ucPatient_SearchArticle();
            
            
            
            
            
            
            
            
            
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
            pnlStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            pnlStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            pnlStats.Controls.Add(pnlCard1, 0, 0);
            pnlStats.Controls.Add(pnlCard2, 1, 0);
            pnlStats.Controls.Add(pnlCard3, 2, 0);
            pnlStats.Controls.Add(pnlCard4, 3, 0);
            pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            pnlStats.Location = new System.Drawing.Point(40, 90);
            pnlStats.Margin = new System.Windows.Forms.Padding(0);
            pnlStats.Name = "pnlStats";
            pnlStats.RowCount = 1;
            pnlStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            pnlStats.Size = new System.Drawing.Size(1800, 205);
            pnlStats.TabIndex = 0;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = System.Drawing.Color.White;
            pnlCard1.Controls.Add(lblTitle1);
            pnlCard1.Controls.Add(lblValue1);
            pnlCard1.Controls.Add(pnlIcon1);
            pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCard1.Location = new System.Drawing.Point(5, 5);
            pnlCard1.Margin = new System.Windows.Forms.Padding(5);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new System.Drawing.Size(440, 195);
            pnlCard1.TabIndex = 0;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTitle1.ForeColor = System.Drawing.Color.Gray;
            lblTitle1.Location = new System.Drawing.Point(25, 25);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new System.Drawing.Size(176, 37);
            lblTitle1.TabIndex = 0;
            lblTitle1.Text = "Tổng bài viết";
            // 
            // lblValue1
            // 
            lblValue1.AutoSize = true;
            lblValue1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblValue1.ForeColor = System.Drawing.Color.FromArgb(17, 34, 71);
            lblValue1.Location = new System.Drawing.Point(20, 65);
            lblValue1.Name = "lblValue1";
            lblValue1.Size = new System.Drawing.Size(81, 92);
            lblValue1.TabIndex = 1;
            lblValue1.Text = "6";
            // 
            // pnlIcon1
            // 
            pnlIcon1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlIcon1.BackColor = System.Drawing.Color.FromArgb(242, 247, 255);
            pnlIcon1.Controls.Add(lblIcon1);
            pnlIcon1.Location = new System.Drawing.Point(330, 35);
            pnlIcon1.Name = "pnlIcon1";
            pnlIcon1.Size = new System.Drawing.Size(90, 90);
            pnlIcon1.TabIndex = 2;
            // 
            // lblIcon1
            // 
            lblIcon1.Dock = System.Windows.Forms.DockStyle.Fill;
            lblIcon1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 28F);
            lblIcon1.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            lblIcon1.Location = new System.Drawing.Point(0, 0);
            lblIcon1.Name = "lblIcon1";
            lblIcon1.Size = new System.Drawing.Size(90, 90);
            lblIcon1.TabIndex = 0;
            lblIcon1.Text = "📝";
            lblIcon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = System.Drawing.Color.White;
            pnlCard2.Controls.Add(lblTitle2);
            pnlCard2.Controls.Add(lblValue2);
            pnlCard2.Controls.Add(pnlIcon2);
            pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCard2.Location = new System.Drawing.Point(455, 5);
            pnlCard2.Margin = new System.Windows.Forms.Padding(5);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new System.Drawing.Size(440, 195);
            pnlCard2.TabIndex = 1;
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTitle2.ForeColor = System.Drawing.Color.Gray;
            lblTitle2.Location = new System.Drawing.Point(25, 25);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new System.Drawing.Size(155, 37);
            lblTitle2.TabIndex = 0;
            lblTitle2.Text = "Đã xuất bản";
            // 
            // lblValue2
            // 
            lblValue2.AutoSize = true;
            lblValue2.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblValue2.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            lblValue2.Location = new System.Drawing.Point(20, 75);
            lblValue2.Name = "lblValue2";
            lblValue2.Size = new System.Drawing.Size(81, 92);
            lblValue2.TabIndex = 1;
            lblValue2.Text = "4";
            // 
            // pnlIcon2
            // 
            pnlIcon2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlIcon2.BackColor = System.Drawing.Color.FromArgb(231, 255, 243);
            pnlIcon2.Controls.Add(lblIcon2);
            pnlIcon2.Location = new System.Drawing.Point(330, 35);
            pnlIcon2.Name = "pnlIcon2";
            pnlIcon2.Size = new System.Drawing.Size(90, 90);
            pnlIcon2.TabIndex = 2;
            // 
            // lblIcon2
            // 
            lblIcon2.Dock = System.Windows.Forms.DockStyle.Fill;
            lblIcon2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 28F);
            lblIcon2.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            lblIcon2.Location = new System.Drawing.Point(0, 0);
            lblIcon2.Name = "lblIcon2";
            lblIcon2.Size = new System.Drawing.Size(90, 90);
            lblIcon2.TabIndex = 0;
            lblIcon2.Text = "👁️";
            lblIcon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = System.Drawing.Color.White;
            pnlCard3.Controls.Add(lblTitle3);
            pnlCard3.Controls.Add(lblValue3);
            pnlCard3.Controls.Add(pnlIcon3);
            pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCard3.Location = new System.Drawing.Point(905, 5);
            pnlCard3.Margin = new System.Windows.Forms.Padding(5);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new System.Drawing.Size(440, 195);
            pnlCard3.TabIndex = 2;
            // 
            // lblTitle3
            // 
            lblTitle3.AutoSize = true;
            lblTitle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTitle3.ForeColor = System.Drawing.Color.Gray;
            lblTitle3.Location = new System.Drawing.Point(25, 25);
            lblTitle3.Name = "lblTitle3";
            lblTitle3.Size = new System.Drawing.Size(125, 37);
            lblTitle3.TabIndex = 0;
            lblTitle3.Text = "Bản nháp";
            // 
            // lblValue3
            // 
            lblValue3.AutoSize = true;
            lblValue3.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblValue3.ForeColor = System.Drawing.Color.FromArgb(234, 179, 8);
            lblValue3.Location = new System.Drawing.Point(20, 75);
            lblValue3.Name = "lblValue3";
            lblValue3.Size = new System.Drawing.Size(81, 92);
            lblValue3.TabIndex = 1;
            lblValue3.Text = "1";
            // 
            // pnlIcon3
            // 
            pnlIcon3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlIcon3.BackColor = System.Drawing.Color.FromArgb(255, 248, 235);
            pnlIcon3.Controls.Add(lblIcon3);
            pnlIcon3.Location = new System.Drawing.Point(330, 35);
            pnlIcon3.Name = "pnlIcon3";
            pnlIcon3.Size = new System.Drawing.Size(90, 90);
            pnlIcon3.TabIndex = 2;
            // 
            // lblIcon3
            // 
            lblIcon3.Dock = System.Windows.Forms.DockStyle.Fill;
            lblIcon3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 28F);
            lblIcon3.ForeColor = System.Drawing.Color.FromArgb(234, 179, 8);
            lblIcon3.Location = new System.Drawing.Point(0, 0);
            lblIcon3.Name = "lblIcon3";
            lblIcon3.Size = new System.Drawing.Size(90, 90);
            lblIcon3.TabIndex = 0;
            lblIcon3.Text = "📝";
            lblIcon3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = System.Drawing.Color.White;
            pnlCard4.Controls.Add(lblTitle4);
            pnlCard4.Controls.Add(lblValue4);
            pnlCard4.Controls.Add(pnlIcon4);
            pnlCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCard4.Location = new System.Drawing.Point(1355, 5);
            pnlCard4.Margin = new System.Windows.Forms.Padding(5);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new System.Drawing.Size(445, 195);
            pnlCard4.TabIndex = 3;
            // 
            // lblTitle4
            // 
            lblTitle4.AutoSize = true;
            lblTitle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTitle4.ForeColor = System.Drawing.Color.Gray;
            lblTitle4.Location = new System.Drawing.Point(25, 25);
            lblTitle4.Name = "lblTitle4";
            lblTitle4.Size = new System.Drawing.Size(129, 37);
            lblTitle4.TabIndex = 0;
            lblTitle4.Text = "Lượt xem";
            // 
            // lblValue4
            // 
            lblValue4.AutoSize = true;
            lblValue4.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblValue4.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblValue4.Location = new System.Drawing.Point(20, 75);
            lblValue4.Name = "lblValue4";
            lblValue4.Size = new System.Drawing.Size(256, 92);
            lblValue4.TabIndex = 1;
            lblValue4.Text = "14.150";
            // 
            // pnlIcon4
            // 
            pnlIcon4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlIcon4.BackColor = System.Drawing.Color.FromArgb(242, 240, 255);
            pnlIcon4.Controls.Add(lblIcon4);
            pnlIcon4.Location = new System.Drawing.Point(330, 35);
            pnlIcon4.Name = "pnlIcon4";
            pnlIcon4.Size = new System.Drawing.Size(90, 90);
            pnlIcon4.TabIndex = 2;
            // 
            // lblIcon4
            // 
            lblIcon4.Dock = System.Windows.Forms.DockStyle.Fill;
            lblIcon4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 28F);
            lblIcon4.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            lblIcon4.Location = new System.Drawing.Point(0, 0);
            lblIcon4.Name = "lblIcon4";
            lblIcon4.Size = new System.Drawing.Size(90, 90);
            lblIcon4.TabIndex = 0;
            lblIcon4.Text = "👁️";
            lblIcon4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnAddArticle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(40, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1800, 150);
            pnlHeader.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblHeaderTitle.Location = new System.Drawing.Point(0, 25);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(425, 65);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Quản lý bài viết";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.Gray;
            lblHeaderSubtitle.Location = new System.Drawing.Point(5, 90);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(465, 37);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Tạo, chỉnh sửa và quản lý các bài viết y tế";
            // 
            // btnAddArticle
            // 
            btnAddArticle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddArticle.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnAddArticle.FlatAppearance.BorderSize = 0;
            btnAddArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddArticle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnAddArticle.ForeColor = System.Drawing.Color.White;
            btnAddArticle.Location = new System.Drawing.Point(1450, 40);
            btnAddArticle.Name = "btnAddArticle";
            btnAddArticle.Size = new System.Drawing.Size(350, 75);
            btnAddArticle.TabIndex = 2;
            btnAddArticle.Text = "+  Thêm bài viết";
            btnAddArticle.UseVisualStyleBackColor = false;
            // 
            // 
            // ucSearchArticle
            // 
            ucSearchArticle.BackColor = System.Drawing.Color.White;
            ucSearchArticle.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSearchArticle.Location = new System.Drawing.Point(40, 295);
            ucSearchArticle.Name = "ucSearchArticle";
            ucSearchArticle.Size = new System.Drawing.Size(1800, 915);
            ucSearchArticle.TabIndex = 2;
            // 
            // ucAdmin_ArticleManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            Controls.Add(ucSearchArticle);
            Controls.Add(pnlStats);
            Controls.Add(pnlHeader);
            Name = "ucAdmin_ArticleManagement";
            Padding = new System.Windows.Forms.Padding(40, 0, 40, 20);
            Size = new System.Drawing.Size(1880, 1230);
            Load += new System.EventHandler(ucAdmin_ArticleManagement_Load);
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
        private ucPatient_SearchArticle ucSearchArticle;
    }
}
