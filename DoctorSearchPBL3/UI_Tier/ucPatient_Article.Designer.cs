namespace UI_Tier
{
    partial class ucPatient_Article
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
            flpArticle = new FlowLayoutPanel();
            pnlAlert = new Panel();
            lblPageStatus = new Label();
            lblPrev = new Label();
            lblNext = new Label();
            pnlAlert.SuspendLayout();
            SuspendLayout();
            // 
            // flpArticle
            // 
            flpArticle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpArticle.Location = new Point(0, 0);
            flpArticle.Name = "flpArticle";
            flpArticle.Size = new Size(1845, 794);
            flpArticle.TabIndex = 0;
            // 
            // pnlAlert
            // 
            pnlAlert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAlert.BackColor = Color.AliceBlue;
            pnlAlert.Controls.Add(lblPageStatus);
            pnlAlert.Controls.Add(lblPrev);
            pnlAlert.Controls.Add(lblNext);
            pnlAlert.Location = new Point(-1, 794);
            pnlAlert.Name = "pnlAlert";
            pnlAlert.Padding = new Padding(10);
            pnlAlert.Size = new Size(1845, 67);
            pnlAlert.TabIndex = 9;
            // 
            // lblPageStatus
            // 
            lblPageStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPageStatus.AutoSize = true;
            lblPageStatus.Font = new Font("Segoe UI", 11F);
            lblPageStatus.Location = new Point(1400, 16);
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
            lblPrev.Location = new Point(1181, 16);
            lblPrev.Name = "lblPrev";
            lblPrev.Size = new Size(219, 41);
            lblPrev.TabIndex = 1;
            lblPrev.Text = "Trang trước <<";
            // 
            // lblNext
            // 
            lblNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNext.AutoSize = true;
            lblNext.Font = new Font("Segoe UI", 11F);
            lblNext.Location = new Point(1615, 16);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(194, 41);
            lblNext.TabIndex = 0;
            lblNext.Text = ">> Trang sau";
            // 
            // ucPatient_Article
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(pnlAlert);
            Controls.Add(flpArticle);
            Name = "ucPatient_Article";
            Size = new Size(1845, 862);
            Load += ucPatient_Article_Load;
            pnlAlert.ResumeLayout(false);
            pnlAlert.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpArticle;
        private Panel pnlAlert;
        private Label lblPageStatus;
        private Label lblPrev;
        private Label lblNext;
    }
}
