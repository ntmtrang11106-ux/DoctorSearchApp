namespace UI_Tier
{
    partial class UCCardDoctor
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
            picDoctor = new PictureBox();
            lblFullName = new Label();
            lblSpecialtyTag = new Label();
            lblEx = new Label();
            lblTotalReviews = new Label();
            pnlContainer = new Panel();
            lblGender = new Label();
            lblSpecialties = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblRating = new Label();
            lblPrice = new Label();
            lblWorkingTime = new Label();
            lblSpecificAdress = new Label();
            lblPhone = new Label();
            ((System.ComponentModel.ISupportInitialize)picDoctor).BeginInit();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // picDoctor
            // 
            picDoctor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picDoctor.BackColor = Color.FromArgb(248, 249, 250);
            picDoctor.Location = new Point(0, 3);
            picDoctor.Name = "picDoctor";
            picDoctor.Size = new Size(626, 349);
            picDoctor.SizeMode = PictureBoxSizeMode.Zoom;
            picDoctor.TabIndex = 0;
            picDoctor.TabStop = false;
            picDoctor.Click += Card_Click;
            // 
            // lblFullName
            // 
            lblFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFullName.Location = new Point(24, 360);
            lblFullName.Margin = new Padding(0, 5, 0, 5);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(398, 50);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "BS. Nguyễn Văn Minh";
            lblFullName.Click += Card_Click;
            // 
            // lblSpecialtyTag
            // 
            lblSpecialtyTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSpecialtyTag.AutoSize = true;
            lblSpecialtyTag.BackColor = Color.FromArgb(24, 112, 255);
            lblSpecialtyTag.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpecialtyTag.ForeColor = SystemColors.ControlLightLight;
            lblSpecialtyTag.Location = new Point(541, 26);
            lblSpecialtyTag.Name = "lblSpecialtyTag";
            lblSpecialtyTag.Padding = new Padding(5, 2, 5, 2);
            lblSpecialtyTag.Size = new Size(93, 36);
            lblSpecialtyTag.TabIndex = 5;
            lblSpecialtyTag.Text = "label1";
            lblSpecialtyTag.Click += Card_Click;
            // 
            // lblEx
            // 
            lblEx.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEx.AutoSize = true;
            lblEx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEx.Location = new Point(97, 820);
            lblEx.Name = "lblEx";
            lblEx.Size = new Size(105, 45);
            lblEx.TabIndex = 16;
            lblEx.Text = "label1";
            lblEx.Click += Card_Click;
            // 
            // lblTotalReviews
            // 
            lblTotalReviews.AutoSize = true;
            lblTotalReviews.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalReviews.Location = new Point(222, 760);
            lblTotalReviews.Name = "lblTotalReviews";
            lblTotalReviews.Size = new Size(105, 45);
            lblTotalReviews.TabIndex = 17;
            lblTotalReviews.Text = "label2";
            lblTotalReviews.Click += Card_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(lblGender);
            pnlContainer.Controls.Add(lblSpecialties);
            pnlContainer.Controls.Add(label7);
            pnlContainer.Controls.Add(label6);
            pnlContainer.Controls.Add(label5);
            pnlContainer.Controls.Add(label4);
            pnlContainer.Controls.Add(label3);
            pnlContainer.Controls.Add(label2);
            pnlContainer.Controls.Add(label1);
            pnlContainer.Controls.Add(lblRating);
            pnlContainer.Controls.Add(picDoctor);
            pnlContainer.Controls.Add(lblPrice);
            pnlContainer.Controls.Add(lblWorkingTime);
            pnlContainer.Controls.Add(lblSpecificAdress);
            pnlContainer.Controls.Add(lblPhone);
            pnlContainer.Controls.Add(lblFullName);
            pnlContainer.Controls.Add(lblTotalReviews);
            pnlContainer.Controls.Add(lblEx);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(13, 13);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(10);
            pnlContainer.Size = new Size(646, 881);
            pnlContainer.TabIndex = 19;
            pnlContainer.Click += Card_Click;
            // 
            // lblGender
            // 
            lblGender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGender.Location = new Point(24, 510);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(141, 45);
            lblGender.TabIndex = 27;
            lblGender.Text = "Gioi tính";
            lblGender.Click += Card_Click;
            // 
            // lblSpecialties
            // 
            lblSpecialties.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSpecialties.AutoSize = true;
            lblSpecialties.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpecialties.ForeColor = Color.FromArgb(37, 99, 235);
            lblSpecialties.Location = new Point(24, 460);
            lblSpecialties.Margin = new Padding(0, 5, 0, 5);
            lblSpecialties.MaximumSize = new Size(600, 0);
            lblSpecialties.Name = "lblSpecialties";
            lblSpecialties.Size = new Size(204, 45);
            lblSpecialties.TabIndex = 26;
            lblSpecialties.Text = "Chuyên khoa";
            lblSpecialties.Click += Card_Click;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe MDL2 Assets", 15F);
            label7.ForeColor = Color.DodgerBlue;
            label7.Location = new Point(24, 820);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(65, 64);
            label7.TabIndex = 25;
            label7.Text = "";
            label7.Click += Card_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe MDL2 Assets", 15F);
            label6.ForeColor = Color.Gold;
            label6.Location = new Point(24, 760);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(65, 64);
            label6.TabIndex = 24;
            label6.Text = "";
            label6.Click += Card_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe MDL2 Assets", 15F);
            label5.ForeColor = Color.DodgerBlue;
            label5.Location = new Point(24, 680);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(65, 47);
            label5.TabIndex = 23;
            label5.Text = "";
            label5.Click += Card_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe MDL2 Assets", 15F);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(24, 620);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(65, 64);
            label4.TabIndex = 22;
            label4.Text = "";
            label4.Click += Card_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe MDL2 Assets", 15F);
            label3.ForeColor = Color.DodgerBlue;
            label3.Location = new Point(24, 560);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 64);
            label3.TabIndex = 21;
            label3.Text = "";
            label3.Click += Card_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = Color.Gray;
            label2.Location = new Point(3, 747);
            label2.Name = "label2";
            label2.Size = new Size(626, 3);
            label2.TabIndex = 20;
            label2.Click += Card_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 692);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 19;
            label1.Click += Card_Click;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRating.ForeColor = Color.DimGray;
            lblRating.Location = new Point(98, 760);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(105, 45);
            lblRating.TabIndex = 9;
            lblRating.Text = "label1";
            lblRating.Click += Card_Click;
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Blue;
            lblPrice.Location = new Point(98, 680);
            lblPrice.Margin = new Padding(0, 5, 0, 5);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(105, 45);
            lblPrice.TabIndex = 15;
            lblPrice.Text = "label1";
            lblPrice.Click += Card_Click;
            // 
            // lblWorkingTime
            // 
            lblWorkingTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWorkingTime.AutoSize = true;
            lblWorkingTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWorkingTime.ForeColor = Color.DimGray;
            lblWorkingTime.Location = new Point(98, 620);
            lblWorkingTime.Margin = new Padding(0, 5, 0, 5);
            lblWorkingTime.Name = "lblWorkingTime";
            lblWorkingTime.Size = new Size(105, 45);
            lblWorkingTime.TabIndex = 4;
            lblWorkingTime.Text = "label4";
            lblWorkingTime.Click += Card_Click;
            // 
            // lblSpecificAdress
            // 
            lblSpecificAdress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSpecificAdress.AutoSize = true;
            lblSpecificAdress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpecificAdress.ForeColor = Color.DimGray;
            lblSpecificAdress.Location = new Point(98, 560);
            lblSpecificAdress.Margin = new Padding(0, 5, 0, 5);
            lblSpecificAdress.Name = "lblSpecificAdress";
            lblSpecificAdress.Size = new Size(105, 45);
            lblSpecificAdress.TabIndex = 3;
            lblSpecificAdress.Text = "label3";
            lblSpecificAdress.Click += Card_Click;
            // 
            // lblPhone
            // 
            lblPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = SystemColors.ControlDarkDark;
            lblPhone.Location = new Point(24, 410);
            lblPhone.Margin = new Padding(0, 5, 0, 5);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(190, 45);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "0766516287";
            lblPhone.Click += Card_Click;
            // 
            // UCCardDoctor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Name = "UCCardDoctor";
            Padding = new Padding(13);
            Size = new Size(672, 907);
            Load += UCCardDoctor_Load;
            ((System.ComponentModel.ISupportInitialize)picDoctor).EndInit();
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picDoctor;
        private Label lblFullName;
        private Label lblHospital;
        private Label lblSpecialtyTag;
        private Label lblEx;
        private Label lblTotalReviews;
        private Panel pnlContainer;
        private Label lblRating;
        private Label lblPrice;
        private Label lblWorkingTime;
        private Label lblSpecificAdress;
        private Label lblPhone;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label7;
        private Label lblSpecialties;
        private Label lblGender;
    }
}
