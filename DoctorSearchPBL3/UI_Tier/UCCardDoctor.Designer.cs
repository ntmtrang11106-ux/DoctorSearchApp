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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            btnBook = new Button();
            lblEx = new Label();
            lblTotalReviews = new Label();
            pnlContainer = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox5 = new PictureBox();
            lblRating = new Label();
            lblPrice = new Label();
            lblWorkingTime = new Label();
            lblSpecificAdress = new Label();
            lblWorkPlace = new Label();
            ((System.ComponentModel.ISupportInitialize)picDoctor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // picDoctor
            // 
            picDoctor.BackColor = Color.FromArgb(248, 249, 250);
            picDoctor.Location = new Point(0, 3);
            picDoctor.Name = "picDoctor";
            picDoctor.Size = new Size(650, 350);
            picDoctor.SizeMode = PictureBoxSizeMode.Zoom;
            picDoctor.TabIndex = 0;
            picDoctor.TabStop = false;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblFullName.Location = new Point(25, 373);
            lblFullName.Margin = new Padding(0, 5, 0, 5);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(146, 54);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Label1";
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
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.location;
            pictureBox1.Location = new Point(40, 489);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.clock;
            pictureBox2.Location = new Point(42, 553);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.star;
            pictureBox3.Location = new Point(43, 694);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.sun;
            pictureBox4.Location = new Point(42, 752);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(45, 45);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // btnBook
            // 
            btnBook.BackColor = Color.FromArgb(24, 112, 255);
            btnBook.Dock = DockStyle.Bottom;
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.FlatStyle = FlatStyle.Flat;
            btnBook.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBook.ForeColor = Color.White;
            btnBook.Location = new Point(10, 830);
            btnBook.Name = "btnBook";
            btnBook.Padding = new Padding(5, 3, 5, 3);
            btnBook.Size = new Size(650, 60);
            btnBook.TabIndex = 14;
            btnBook.Text = "Đăng nhập để đặt lịch";
            btnBook.UseVisualStyleBackColor = false;
            // 
            // lblEx
            // 
            lblEx.AutoSize = true;
            lblEx.Font = new Font("Segoe UI", 10F);
            lblEx.Location = new Point(97, 757);
            lblEx.Name = "lblEx";
            lblEx.Size = new Size(90, 37);
            lblEx.TabIndex = 16;
            lblEx.Text = "label1";
            // 
            // lblTotalReviews
            // 
            lblTotalReviews.AutoSize = true;
            lblTotalReviews.Location = new Point(189, 703);
            lblTotalReviews.Name = "lblTotalReviews";
            lblTotalReviews.Size = new Size(78, 32);
            lblTotalReviews.TabIndex = 17;
            lblTotalReviews.Text = "label2";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(label2);
            pnlContainer.Controls.Add(label1);
            pnlContainer.Controls.Add(pictureBox5);
            pnlContainer.Controls.Add(lblRating);
            pnlContainer.Controls.Add(picDoctor);
            pnlContainer.Controls.Add(lblPrice);
            pnlContainer.Controls.Add(pictureBox3);
            pnlContainer.Controls.Add(lblWorkingTime);
            pnlContainer.Controls.Add(lblSpecificAdress);
            pnlContainer.Controls.Add(lblWorkPlace);
            pnlContainer.Controls.Add(lblFullName);
            pnlContainer.Controls.Add(pictureBox4);
            pnlContainer.Controls.Add(lblTotalReviews);
            pnlContainer.Controls.Add(lblEx);
            pnlContainer.Controls.Add(pictureBox2);
            pnlContainer.Controls.Add(pictureBox1);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(10, 10);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(10);
            pnlContainer.Size = new Size(650, 880);
            pnlContainer.TabIndex = 19;
            // 
            // label2
            // 
            label2.BackColor = Color.Gray;
            label2.Location = new Point(10, 669);
            label2.Name = "label2";
            label2.Size = new Size(650, 2);
            label2.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 615);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 19;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.coin;
            pictureBox5.Location = new Point(42, 612);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(40, 40);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 18;
            pictureBox5.TabStop = false;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 11F);
            lblRating.ForeColor = Color.DimGray;
            lblRating.Location = new Point(99, 698);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(97, 41);
            lblRating.TabIndex = 9;
            lblRating.Text = "label1";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F);
            lblPrice.ForeColor = Color.Blue;
            lblPrice.Location = new Point(99, 612);
            lblPrice.Margin = new Padding(0, 5, 0, 5);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(90, 37);
            lblPrice.TabIndex = 15;
            lblPrice.Text = "label1";
            // 
            // lblWorkingTime
            // 
            lblWorkingTime.AutoSize = true;
            lblWorkingTime.Font = new Font("Segoe UI", 10F);
            lblWorkingTime.ForeColor = Color.DimGray;
            lblWorkingTime.Location = new Point(99, 553);
            lblWorkingTime.Margin = new Padding(0, 5, 0, 5);
            lblWorkingTime.Name = "lblWorkingTime";
            lblWorkingTime.Size = new Size(90, 37);
            lblWorkingTime.TabIndex = 4;
            lblWorkingTime.Text = "label4";
            // 
            // lblSpecificAdress
            // 
            lblSpecificAdress.AutoSize = true;
            lblSpecificAdress.Font = new Font("Segoe UI", 10F);
            lblSpecificAdress.ForeColor = Color.DimGray;
            lblSpecificAdress.Location = new Point(99, 497);
            lblSpecificAdress.Margin = new Padding(0, 5, 0, 5);
            lblSpecificAdress.Name = "lblSpecificAdress";
            lblSpecificAdress.Size = new Size(90, 37);
            lblSpecificAdress.TabIndex = 3;
            lblSpecificAdress.Text = "label3";
            // 
            // lblWorkPlace
            // 
            lblWorkPlace.AutoSize = true;
            lblWorkPlace.Font = new Font("Segoe UI", 11F);
            lblWorkPlace.ForeColor = Color.FromArgb(37, 99, 235);
            lblWorkPlace.Location = new Point(25, 431);
            lblWorkPlace.Margin = new Padding(0, 5, 0, 5);
            lblWorkPlace.Name = "lblWorkPlace";
            lblWorkPlace.Size = new Size(97, 41);
            lblWorkPlace.TabIndex = 2;
            lblWorkPlace.Text = "label2";
            // 
            // UCCardDoctor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSpecialtyTag);
            Controls.Add(btnBook);
            Controls.Add(pnlContainer);
            Name = "UCCardDoctor";
            Padding = new Padding(10);
            Size = new Size(670, 900);
            Paint += UCCardDoctor_Paint;
            ((System.ComponentModel.ISupportInitialize)picDoctor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDoctor;
        private Label lblFullName;
        private Label lblHospital;
        private Label lblSpecialtyTag;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button btnBook;
        private Label lblEx;
        private Label lblTotalReviews;
        private Panel pnlContainer;
        private Label lblRating;
        private Label lblPrice;
        private Label lblWorkingTime;
        private Label lblSpecificAdress;
        private Label lblWorkPlace;
        private PictureBox pictureBox5;
        private Label label1;
        private Label label2;
    }
}
