namespace UI_Tier
{
    partial class ucAppItem
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
            components = new System.ComponentModel.Container();
            lblPatientName = new Label();
            lblPhoneNumber = new Label();
            lblDate = new Label();
            lblTime = new Label();
            lblSymptoms = new Label();
            btnStatus = new Button();
            label2 = new Label();
            label1 = new Label();
            btnAccept = new Button();
            flpAction = new FlowLayoutPanel();
            btnRate = new Button();
            btnBook = new Button();
            btnRemove = new Button();
            btnCancel = new Button();
            ttAction = new ToolTip(components);
            flpAction.SuspendLayout();
            SuspendLayout();
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPatientName.Location = new Point(380, 62);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(317, 54);
            lblPatientName.TabIndex = 0;
            lblPatientName.Text = "Nguyễn Văn An";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 11F);
            lblPhoneNumber.Location = new Point(380, 131);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(178, 41);
            lblPhoneNumber.TabIndex = 4;
            lblPhoneNumber.Text = "0000000000";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 11F);
            lblDate.Location = new Point(124, 75);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(170, 41);
            lblDate.TabIndex = 5;
            lblDate.Text = "22/10/2026";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 11F);
            lblTime.Location = new Point(122, 131);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(190, 41);
            lblTime.TabIndex = 6;
            lblTime.Text = "8h30' - 9h45'";
            // 
            // lblSymptoms
            // 
            lblSymptoms.Font = new Font("Segoe UI", 11F);
            lblSymptoms.ImageAlign = ContentAlignment.MiddleLeft;
            lblSymptoms.Location = new Point(957, 80);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(553, 131);
            lblSymptoms.TabIndex = 7;
            lblSymptoms.Text = "Đau ngực, khó thở";
            // 
            // btnStatus
            // 
            btnStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStatus.BackColor = Color.PaleGreen;
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.Font = new Font("Segoe UI", 12F);
            btnStatus.ForeColor = Color.DarkGreen;
            btnStatus.Location = new Point(1139, 96);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(254, 55);
            btnStatus.TabIndex = 9;
            btnStatus.Text = "Thành công";
            btnStatus.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe MDL2 Assets", 27F);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(859, 68);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(100, 100);
            label2.TabIndex = 11;
            label2.Text = "📄";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe MDL2 Assets", 27F);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(28, 71);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(100, 100);
            label1.TabIndex = 13;
            label1.Text = "🕓";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.None;
            btnAccept.BackColor = Color.Honeydew;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe MDL2 Assets", 20F);
            btnAccept.ForeColor = Color.Green;
            btnAccept.Location = new Point(8, 5);
            btnAccept.Margin = new Padding(70, 5, 0, 0);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(80, 80);
            btnAccept.TabIndex = 14;
            btnAccept.Text = "";
            btnAccept.TextAlign = ContentAlignment.MiddleLeft;
            ttAction.SetToolTip(btnAccept, "Chấp nhận");
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // flpAction
            // 
            flpAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpAction.Controls.Add(btnRate);
            flpAction.Controls.Add(btnBook);
            flpAction.Controls.Add(btnRemove);
            flpAction.Controls.Add(btnCancel);
            flpAction.Controls.Add(btnAccept);
            flpAction.FlowDirection = FlowDirection.RightToLeft;
            flpAction.Location = new Point(1549, 75);
            flpAction.Name = "flpAction";
            flpAction.Size = new Size(688, 100);
            flpAction.TabIndex = 15;
            flpAction.WrapContents = false;
            // 
            // btnRate
            // 
            btnRate.Anchor = AnchorStyles.None;
            btnRate.BackColor = Color.LightGoldenrodYellow;
            btnRate.FlatAppearance.BorderSize = 0;
            btnRate.FlatStyle = FlatStyle.Flat;
            btnRate.Font = new Font("Segoe MDL2 Assets", 18F);
            btnRate.ForeColor = Color.Goldenrod;
            btnRate.Location = new Point(608, 5);
            btnRate.Margin = new Padding(70, 5, 0, 0);
            btnRate.Name = "btnRate";
            btnRate.Size = new Size(80, 80);
            btnRate.TabIndex = 18;
            btnRate.Text = "";
            btnRate.TextAlign = ContentAlignment.MiddleRight;
            ttAction.SetToolTip(btnRate, "Đặt lịch ngay");
            btnRate.UseVisualStyleBackColor = false;
            // 
            // btnBook
            // 
            btnBook.Anchor = AnchorStyles.None;
            btnBook.BackColor = Color.Azure;
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.FlatStyle = FlatStyle.Flat;
            btnBook.Font = new Font("Segoe MDL2 Assets", 18F);
            btnBook.ForeColor = Color.DodgerBlue;
            btnBook.Location = new Point(458, 5);
            btnBook.Margin = new Padding(70, 5, 0, 0);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(80, 80);
            btnBook.TabIndex = 17;
            btnBook.Text = "";
            btnBook.TextAlign = ContentAlignment.MiddleRight;
            ttAction.SetToolTip(btnBook, "Đặt lịch ngay");
            btnBook.UseVisualStyleBackColor = false;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.BackColor = Color.LightGoldenrodYellow;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe MDL2 Assets", 18F);
            btnRemove.ForeColor = Color.Goldenrod;
            btnRemove.Location = new Point(308, 5);
            btnRemove.Margin = new Padding(70, 5, 0, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(80, 80);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "";
            btnRemove.TextAlign = ContentAlignment.MiddleRight;
            ttAction.SetToolTip(btnRemove, "Xóa lịch hẹn");
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.BackColor = Color.Snow;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe MDL2 Assets", 20F);
            btnCancel.ForeColor = Color.DarkRed;
            btnCancel.Location = new Point(158, 5);
            btnCancel.Margin = new Padding(70, 5, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 80);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "";
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            ttAction.SetToolTip(btnCancel, "Từ chối");
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ttAction
            // 
            ttAction.AutoPopDelay = 5000;
            ttAction.InitialDelay = 500;
            ttAction.ReshowDelay = 100;
            ttAction.ShowAlways = true;
            // 
            // ucAppItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpAction);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnStatus);
            Controls.Add(lblSymptoms);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblPatientName);
            Name = "ucAppItem";
            Size = new Size(2297, 252);
            Load += ucAppItem_Load;
            flpAction.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPatientName;
        private Label lblPhoneNumber;
        private Label lblDate;
        private Label lblTime;
        private Label lblSymptoms;
        private Button btnStatus;
        private Label label2;
        private Label label1;
        private Button btnAccept;
        private FlowLayoutPanel flpAction;
        private Button btnCancel;
        private Button btnRemove;
        private Button btnBook;
        private ToolTip ttAction;
        private Button btnRate;
    }
}
