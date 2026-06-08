namespace UI_Tier
{
    partial class ucConversationItem
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
            lblAvatar = new Label();
            lblName = new Label();
            lblLastMessage = new Label();
            lblTime = new Label();
            lblUnread = new Label();
            pnlOnlineDot = new Panel();
            SuspendLayout();
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(229, 231, 235);
            lblAvatar.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.FromArgb(75, 85, 99);
            lblAvatar.Location = new Point(15, 15);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(90, 90);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "A";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(31, 41, 55);
            lblName.Location = new Point(120, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(205, 45);
            lblName.TabIndex = 1;
            lblName.Text = "Nguyễn Văn A";
            // 
            // lblLastMessage
            // 
            lblLastMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLastMessage.Font = new Font("Segoe UI", 12F);
            lblLastMessage.ForeColor = Color.FromArgb(107, 114, 128);
            lblLastMessage.Location = new Point(120, 68);
            lblLastMessage.Name = "lblLastMessage";
            lblLastMessage.Size = new Size(470, 35);
            lblLastMessage.TabIndex = 2;
            lblLastMessage.Text = "Cảm ơn bác sĩ...";
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.Font = new Font("Segoe UI", 10F);
            lblTime.ForeColor = Color.FromArgb(156, 163, 175);
            lblTime.Location = new Point(505, 24);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(140, 30);
            lblTime.TabIndex = 3;
            lblTime.Text = "10 phút trước";
            lblTime.TextAlign = ContentAlignment.TopRight;
            // 
            // lblUnread
            // 
            lblUnread.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUnread.BackColor = Color.FromArgb(0, 98, 255);
            lblUnread.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnread.ForeColor = Color.White;
            lblUnread.Location = new Point(615, 68);
            lblUnread.Name = "lblUnread";
            lblUnread.Size = new Size(30, 30);
            lblUnread.TabIndex = 4;
            lblUnread.Text = "2";
            lblUnread.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOnlineDot
            // 
            pnlOnlineDot.BackColor = Color.FromArgb(34, 197, 94);
            pnlOnlineDot.Location = new Point(81, 81);
            pnlOnlineDot.Name = "pnlOnlineDot";
            pnlOnlineDot.Size = new Size(24, 24);
            pnlOnlineDot.TabIndex = 5;
            // 
            // ucConversationItem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlOnlineDot);
            Controls.Add(lblUnread);
            Controls.Add(lblTime);
            Controls.Add(lblLastMessage);
            Controls.Add(lblName);
            Controls.Add(lblAvatar);
            Name = "ucConversationItem";
            Size = new Size(660, 120);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAvatar;
        private Label lblName;
        private Label lblLastMessage;
        private Label lblTime;
        private Label lblUnread;
        private Panel pnlOnlineDot;
    }
}
