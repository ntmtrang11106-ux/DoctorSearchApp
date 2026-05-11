namespace UI_Tier
{
    partial class ucPieChart
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
            lblTitle = new System.Windows.Forms.Label();
            pnlPieArea = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(17, 34, 71);
            lblTitle.Location = new System.Drawing.Point(25, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(403, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Phân bổ chuyên khoa";
            // 
            // pnlPieArea
            // 
            pnlPieArea.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlPieArea.Location = new System.Drawing.Point(0, 50);
            pnlPieArea.Name = "pnlPieArea";
            pnlPieArea.Size = new System.Drawing.Size(400, 400);
            pnlPieArea.TabIndex = 1;
            // 
            // ucPieChart
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(pnlPieArea);
            Controls.Add(lblTitle);
            Name = "ucPieChart";
            Size = new System.Drawing.Size(400, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlPieArea;
    }
}
