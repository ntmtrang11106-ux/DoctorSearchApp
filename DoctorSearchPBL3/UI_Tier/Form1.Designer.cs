namespace UI_Tier
{
    partial class Form1
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
            flpDoctors = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flpDoctors.SuspendLayout();
            SuspendLayout();
            // 
            // flpDoctors
            // 
            flpDoctors.AutoScroll = true;
            flpDoctors.Controls.Add(flowLayoutPanel1);
            flpDoctors.Location = new Point(30, 30);
            flpDoctors.Name = "flpDoctors";
            flpDoctors.Size = new Size(1911, 814);
            flpDoctors.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(12, 8);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1969, 912);
            Controls.Add(flpDoctors);
            Name = "Form1";
            Text = "Form1";
            flpDoctors.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpDoctors;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
