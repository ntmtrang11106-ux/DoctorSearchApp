namespace UI_Tier
{
    partial class ucMessageBubble
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
            pnlBubble = new Panel();
            lblText = new Label();
            lblTime = new Label();
            pnlBubble.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBubble
            // 
            pnlBubble.BackColor = Color.FromArgb(243, 244, 246);
            pnlBubble.Controls.Add(lblText);
            pnlBubble.Location = new Point(25, 10);
            pnlBubble.Name = "pnlBubble";
            pnlBubble.Size = new Size(300, 70);
            pnlBubble.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.BackColor = Color.Transparent;
            lblText.Font = new Font("Segoe UI", 16F);
            lblText.ForeColor = Color.FromArgb(17, 24, 39);
            lblText.Location = new Point(20, 15);
            lblText.Name = "lblText";
            lblText.Size = new Size(260, 40);
            lblText.TabIndex = 0;
            lblText.Text = "Nội dung tin nhắn";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 11F);
            lblTime.ForeColor = Color.FromArgb(156, 163, 175);
            lblTime.Location = new Point(30, 85);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(57, 30);
            lblTime.TabIndex = 1;
            lblTime.Text = "09:30";
            // 
            // ucMessageBubble
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblTime);
            Controls.Add(pnlBubble);
            Name = "ucMessageBubble";
            Size = new Size(400, 120);
            pnlBubble.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBubble;
        private Label lblText;
        private Label lblTime;
    }
}
