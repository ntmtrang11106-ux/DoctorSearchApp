namespace UI_Tier
{
    partial class ucPatient_Chat
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
            pollTimer = new System.Windows.Forms.Timer(components);
            pnlLeft = new Panel();
            flowConversations = new FlowLayoutPanel();
            pnlSearch = new Panel();
            pnlSearchBox = new Panel();
            lblSearchIcon = new Label();
            txtSearch = new TextBox();
            pnlRight = new Panel();
            pnlChatActive = new Panel();
            flowMessages = new FlowLayoutPanel();
            pnlChatFooter = new Panel();
            btnSend = new Button();
            pnlInputBox = new Panel();
            txtInput = new TextBox();
            btnEmoji = new Button();
            btnAttach = new Button();
            btnImage = new Button();
            pnlChatHeader = new Panel();
            lblHeaderName = new Label();
            lblHeaderAvatar = new Label();
            lblHeaderSpecialty = new Label();
            pnlNoChatSelected = new Panel();
            lblSelectPrompt = new Label();
            btnOptions = new Button();
            pnlSeparator = new Panel();
            pnlLeft.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlSearchBox.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlChatActive.SuspendLayout();
            pnlChatFooter.SuspendLayout();
            pnlInputBox.SuspendLayout();
            pnlChatHeader.SuspendLayout();
            pnlNoChatSelected.SuspendLayout();
            SuspendLayout();
            // 
            // pollTimer
            // 
            pollTimer.Interval = 4000;
            pollTimer.Tick += PollTimer_Tick;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(flowConversations);
            pnlLeft.Controls.Add(pnlSearch);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Margin = new Padding(4);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(910, 768);
            pnlLeft.TabIndex = 0;
            // 
            // flowConversations
            // 
            flowConversations.AutoScroll = true;
            flowConversations.BackColor = Color.White;
            flowConversations.Dock = DockStyle.Fill;
            flowConversations.FlowDirection = FlowDirection.TopDown;
            flowConversations.Location = new Point(0, 102);
            flowConversations.Margin = new Padding(4);
            flowConversations.Name = "flowConversations";
            flowConversations.Padding = new Padding(13, 0, 13, 0);
            flowConversations.Size = new Size(910, 666);
            flowConversations.TabIndex = 1;
            flowConversations.WrapContents = false;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(pnlSearchBox);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Margin = new Padding(4);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(910, 102);
            pnlSearch.TabIndex = 0;
            // 
            // pnlSearchBox
            // 
            pnlSearchBox.BackColor = Color.FromArgb(249, 250, 251);
            pnlSearchBox.Controls.Add(lblSearchIcon);
            pnlSearchBox.Controls.Add(txtSearch);
            pnlSearchBox.Location = new Point(20, 19);
            pnlSearchBox.Margin = new Padding(4);
            pnlSearchBox.Name = "pnlSearchBox";
            pnlSearchBox.Size = new Size(870, 63);
            pnlSearchBox.TabIndex = 0;
            pnlSearchBox.Paint += pnlSearchBox_Paint;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.BackColor = Color.Transparent;
            lblSearchIcon.Font = new Font("Segoe MDL2 Assets", 14F);
            lblSearchIcon.ForeColor = Color.FromArgb(156, 163, 175);
            lblSearchIcon.Location = new Point(13, 10);
            lblSearchIcon.Margin = new Padding(4, 0, 4, 0);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(42, 41);
            lblSearchIcon.TabIndex = 1;
            lblSearchIcon.Text = "";
            lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(249, 250, 251);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 14F);
            txtSearch.Location = new Point(62, 8);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(780, 50);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Tìm kiếm...";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(249, 250, 251);
            pnlRight.Controls.Add(pnlChatActive);
            pnlRight.Controls.Add(pnlNoChatSelected);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(911, 0);
            pnlRight.Margin = new Padding(4);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(649, 768);
            pnlRight.TabIndex = 1;
            // 
            // pnlChatActive
            // 
            pnlChatActive.BackColor = Color.FromArgb(249, 250, 251);
            pnlChatActive.Controls.Add(flowMessages);
            pnlChatActive.Controls.Add(pnlChatFooter);
            pnlChatActive.Controls.Add(pnlChatHeader);
            pnlChatActive.Dock = DockStyle.Fill;
            pnlChatActive.Location = new Point(0, 0);
            pnlChatActive.Margin = new Padding(4);
            pnlChatActive.Name = "pnlChatActive";
            pnlChatActive.Size = new Size(649, 768);
            pnlChatActive.TabIndex = 1;
            pnlChatActive.Visible = false;
            // 
            // flowMessages
            // 
            flowMessages.AutoScroll = true;
            flowMessages.BackColor = Color.FromArgb(248, 249, 250);
            flowMessages.Dock = DockStyle.Fill;
            flowMessages.FlowDirection = FlowDirection.TopDown;
            flowMessages.Location = new Point(0, 154);
            flowMessages.Margin = new Padding(4);
            flowMessages.Name = "flowMessages";
            flowMessages.Padding = new Padding(0, 13, 0, 13);
            flowMessages.Size = new Size(649, 499);
            flowMessages.TabIndex = 2;
            flowMessages.WrapContents = false;
            // 
            // pnlChatFooter
            // 
            pnlChatFooter.BackColor = Color.White;
            pnlChatFooter.Controls.Add(btnSend);
            pnlChatFooter.Controls.Add(pnlInputBox);
            pnlChatFooter.Controls.Add(btnAttach);
            pnlChatFooter.Controls.Add(btnImage);
            pnlChatFooter.Dock = DockStyle.Bottom;
            pnlChatFooter.Location = new Point(0, 653);
            pnlChatFooter.Margin = new Padding(4);
            pnlChatFooter.Name = "pnlChatFooter";
            pnlChatFooter.Size = new Size(649, 115);
            pnlChatFooter.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(0, 98, 255);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe MDL2 Assets", 16F);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(564, 26);
            btnSend.Margin = new Padding(4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(65, 64);
            btnSend.TabIndex = 3;
            btnSend.Text = "";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // pnlInputBox
            // 
            pnlInputBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlInputBox.BackColor = Color.FromArgb(249, 250, 251);
            pnlInputBox.Controls.Add(txtInput);
            pnlInputBox.Controls.Add(btnEmoji);
            pnlInputBox.Location = new Point(125, 26);
            pnlInputBox.Margin = new Padding(4);
            pnlInputBox.Name = "pnlInputBox";
            pnlInputBox.Size = new Size(424, 63);
            pnlInputBox.TabIndex = 2;
            pnlInputBox.Paint += pnlInputBox_Paint;
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BackColor = Color.FromArgb(249, 250, 251);
            txtInput.BorderStyle = BorderStyle.None;
            txtInput.Font = new Font("Segoe UI", 12F);
            txtInput.Location = new Point(16, 10);
            txtInput.Margin = new Padding(4);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(348, 50);
            txtInput.TabIndex = 0;
            txtInput.Text = "Nhập tin nhắn...";
            txtInput.KeyDown += txtInput_KeyDown;
            // 
            // btnEmoji
            // 
            btnEmoji.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEmoji.BackColor = Color.Transparent;
            btnEmoji.FlatAppearance.BorderSize = 0;
            btnEmoji.FlatStyle = FlatStyle.Flat;
            btnEmoji.Font = new Font("Segoe UI", 14F);
            btnEmoji.ForeColor = Color.FromArgb(107, 114, 128);
            btnEmoji.Location = new Point(372, 2);
            btnEmoji.Margin = new Padding(0);
            btnEmoji.Name = "btnEmoji";
            btnEmoji.Size = new Size(50, 55);
            btnEmoji.TabIndex = 1;
            btnEmoji.Text = "🙂";
            btnEmoji.UseVisualStyleBackColor = false;
            btnEmoji.Click += btnEmoji_Click;
            // 
            // btnAttach
            // 
            btnAttach.BackColor = Color.Transparent;
            btnAttach.FlatAppearance.BorderSize = 0;
            btnAttach.FlatStyle = FlatStyle.Flat;
            btnAttach.Font = new Font("Segoe MDL2 Assets", 16F);
            btnAttach.ForeColor = Color.FromArgb(107, 114, 128);
            btnAttach.Location = new Point(15, 26);
            btnAttach.Margin = new Padding(4);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(40, 64);
            btnAttach.TabIndex = 0;
            btnAttach.Text = "";
            btnAttach.UseVisualStyleBackColor = false;
            btnAttach.Click += btnAttach_Click;
            // 
            // btnImage
            // 
            btnImage.BackColor = Color.Transparent;
            btnImage.FlatAppearance.BorderSize = 0;
            btnImage.FlatStyle = FlatStyle.Flat;
            btnImage.Font = new Font("Segoe MDL2 Assets", 16F);
            btnImage.ForeColor = Color.FromArgb(107, 114, 128);
            btnImage.Location = new Point(68, 30);
            btnImage.Margin = new Padding(4);
            btnImage.Name = "btnImage";
            btnImage.Size = new Size(50, 55);
            btnImage.TabIndex = 4;
            btnImage.Text = "";
            btnImage.UseVisualStyleBackColor = false;
            btnImage.Click += btnImage_Click;
            // 
            // pnlChatHeader
            // 
            pnlChatHeader.BackColor = Color.White;
            pnlChatHeader.Controls.Add(lblHeaderName);
            pnlChatHeader.Controls.Add(lblHeaderAvatar);
            pnlChatHeader.Controls.Add(lblHeaderSpecialty);
            pnlChatHeader.Dock = DockStyle.Top;
            pnlChatHeader.Location = new Point(0, 0);
            pnlChatHeader.Margin = new Padding(4);
            pnlChatHeader.Name = "pnlChatHeader";
            pnlChatHeader.Size = new Size(649, 154);
            pnlChatHeader.TabIndex = 0;
            // 
            // lblHeaderName
            // 
            lblHeaderName.AutoSize = true;
            lblHeaderName.Cursor = Cursors.Hand;
            lblHeaderName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderName.ForeColor = Color.FromArgb(17, 24, 39);
            lblHeaderName.Location = new Point(169, 26);
            lblHeaderName.Margin = new Padding(4, 0, 4, 0);
            lblHeaderName.Name = "lblHeaderName";
            lblHeaderName.Size = new Size(314, 59);
            lblHeaderName.TabIndex = 1;
            lblHeaderName.Text = "Nguyễn Văn A";
            lblHeaderName.Click += lblHeaderName_Click;
            // 
            // lblHeaderAvatar
            // 
            lblHeaderAvatar.BackColor = Color.FromArgb(229, 231, 235);
            lblHeaderAvatar.Cursor = Cursors.Hand;
            lblHeaderAvatar.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeaderAvatar.ForeColor = Color.FromArgb(75, 85, 99);
            lblHeaderAvatar.Location = new Point(26, 19);
            lblHeaderAvatar.Margin = new Padding(4, 0, 4, 0);
            lblHeaderAvatar.Name = "lblHeaderAvatar";
            lblHeaderAvatar.Size = new Size(117, 115);
            lblHeaderAvatar.TabIndex = 0;
            lblHeaderAvatar.Text = "N";
            lblHeaderAvatar.TextAlign = ContentAlignment.MiddleCenter;
            lblHeaderAvatar.Click += lblHeaderAvatar_Click;
            // 
            // lblHeaderSpecialty
            // 
            lblHeaderSpecialty.AutoSize = true;
            lblHeaderSpecialty.Font = new Font("Segoe UI", 12F);
            lblHeaderSpecialty.ForeColor = Color.FromArgb(37, 99, 235);
            lblHeaderSpecialty.Location = new Point(169, 85);
            lblHeaderSpecialty.Margin = new Padding(4, 0, 4, 0);
            lblHeaderSpecialty.Name = "lblHeaderSpecialty";
            lblHeaderSpecialty.Size = new Size(204, 45);
            lblHeaderSpecialty.TabIndex = 7;
            lblHeaderSpecialty.Text = "Chuyên khoa";
            // 
            // pnlNoChatSelected
            // 
            pnlNoChatSelected.Controls.Add(lblSelectPrompt);
            pnlNoChatSelected.Dock = DockStyle.Fill;
            pnlNoChatSelected.Location = new Point(0, 0);
            pnlNoChatSelected.Margin = new Padding(4);
            pnlNoChatSelected.Name = "pnlNoChatSelected";
            pnlNoChatSelected.Size = new Size(649, 768);
            pnlNoChatSelected.TabIndex = 0;
            // 
            // lblSelectPrompt
            // 
            lblSelectPrompt.Dock = DockStyle.Fill;
            lblSelectPrompt.Font = new Font("Segoe UI", 16F, FontStyle.Italic);
            lblSelectPrompt.ForeColor = Color.Gray;
            lblSelectPrompt.Location = new Point(0, 0);
            lblSelectPrompt.Margin = new Padding(4, 0, 4, 0);
            lblSelectPrompt.Name = "lblSelectPrompt";
            lblSelectPrompt.Size = new Size(649, 768);
            lblSelectPrompt.TabIndex = 0;
            lblSelectPrompt.Text = "Chọn một cuộc trò chuyện để bắt đầu nhắn tin";
            lblSelectPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOptions
            // 
            btnOptions.Location = new Point(0, 0);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(75, 23);
            btnOptions.TabIndex = 0;
            btnOptions.Visible = false;
            // 
            // pnlSeparator
            // 
            pnlSeparator.BackColor = Color.FromArgb(229, 231, 235);
            pnlSeparator.Dock = DockStyle.Left;
            pnlSeparator.Location = new Point(910, 0);
            pnlSeparator.Margin = new Padding(4);
            pnlSeparator.Name = "pnlSeparator";
            pnlSeparator.Size = new Size(1, 768);
            pnlSeparator.TabIndex = 2;
            // 
            // ucPatient_Chat
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 244, 246);
            Controls.Add(pnlRight);
            Controls.Add(pnlSeparator);
            Controls.Add(pnlLeft);
            Margin = new Padding(4);
            Name = "ucPatient_Chat";
            Size = new Size(1560, 768);
            Load += ucPatient_Chat_Load;
            VisibleChanged += ucPatient_Chat_VisibleChanged;
            pnlLeft.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearchBox.ResumeLayout(false);
            pnlSearchBox.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlChatActive.ResumeLayout(false);
            pnlChatFooter.ResumeLayout(false);
            pnlInputBox.ResumeLayout(false);
            pnlInputBox.PerformLayout();
            pnlChatHeader.ResumeLayout(false);
            pnlChatHeader.PerformLayout();
            pnlNoChatSelected.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Panel pnlSearch;
        private Panel pnlSearchBox;
        private Label lblSearchIcon;
        private TextBox txtSearch;
        private FlowLayoutPanel flowConversations;
        private Panel pnlRight;
        private Panel pnlNoChatSelected;
        private Label lblSelectPrompt;
        private Panel pnlChatActive;
        private FlowLayoutPanel flowMessages;
        private Panel pnlChatFooter;
        private Button btnSend;
        private Panel pnlInputBox;
        private TextBox txtInput;
        private Button btnEmoji;
        private Button btnAttach;
        private Button btnImage;
        private Panel pnlChatHeader;
        private Button btnOptions;
        private Label lblHeaderName;
        private Label lblHeaderAvatar;
        private Label lblHeaderSpecialty;
        private Panel pnlSeparator;
        private System.Windows.Forms.Timer pollTimer;
    }
}
