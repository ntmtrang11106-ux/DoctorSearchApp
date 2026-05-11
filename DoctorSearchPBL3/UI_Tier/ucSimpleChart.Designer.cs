namespace UI_Tier
{
    partial class ucSimpleChart
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
            lblTitle = new Label();
            pnlChartArea = new Panel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 34, 71);
            lblTitle.Location = new Point(25, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chart Title";
            // 
            // pnlChartArea
            // 
            pnlChartArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChartArea.Location = new Point(0, 59);
            pnlChartArea.Name = "pnlChartArea";
            pnlChartArea.Size = new Size(500, 221);
            pnlChartArea.TabIndex = 1;
            // 
            // ucSimpleChart
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlChartArea);
            Controls.Add(lblTitle);
            Name = "ucSimpleChart";
            Size = new Size(500, 300);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlChartArea;
    }
}
