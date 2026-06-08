namespace UI_Tier
{
    partial class ucAdmin_AddDepartment
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
            lblHeaderTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtDesc = new TextBox();
            label5 = new Label();
            txtRoomInput = new TextBox();
            btnAddRoom = new Button();
            lblRoomHint = new Label();
            pnlRoomList = new Panel();
            flpRooms = new FlowLayoutPanel();
            lblRoomListTitle = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            btnClose = new Button();
            pnlName = new Panel();
            pnlDesc = new Panel();
            pnlRoomInput = new Panel();
            pnlRoomList.SuspendLayout();
            pnlName.SuspendLayout();
            pnlDesc.SuspendLayout();
            pnlRoomInput.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(30, 70, 125);
            lblHeaderTitle.Location = new Point(65, 64);
            lblHeaderTitle.Margin = new Padding(5, 0, 5, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(496, 59);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Thêm chuyên khoa mới";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.875F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(107, 114, 128);
            label1.Location = new Point(73, 147);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(917, 50);
            label1.TabIndex = 1;
            label1.Text = "Nhập thông tin để thêm chuyên khoa mới vào hệ thống";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(17, 24, 39);
            label2.Location = new Point(73, 240);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 45);
            label2.TabIndex = 2;
            label2.Text = "Tên *";
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(19, 16);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nhập tên chuyên khoa";
            txtName.Size = new Size(1399, 43);
            txtName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(17, 24, 39);
            label3.Location = new Point(73, 402);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(109, 45);
            label3.TabIndex = 4;
            label3.Text = "Mô tả";
            // 
            // txtDesc
            // 
            txtDesc.BackColor = Color.White;
            txtDesc.BorderStyle = BorderStyle.None;
            txtDesc.Font = new Font("Segoe UI", 12F);
            txtDesc.Location = new Point(19, 10);
            txtDesc.Margin = new Padding(5);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.PlaceholderText = "Nhập mô tả (tùy chọn)";
            txtDesc.Size = new Size(1399, 246);
            txtDesc.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(17, 24, 39);
            label5.Location = new Point(73, 736);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(210, 45);
            label5.TabIndex = 6;
            label5.Text = "Phòng khám";
            // 
            // txtRoomInput
            // 
            txtRoomInput.BackColor = Color.White;
            txtRoomInput.BorderStyle = BorderStyle.None;
            txtRoomInput.Font = new Font("Segoe UI", 12F);
            txtRoomInput.Location = new Point(19, 12);
            txtRoomInput.Margin = new Padding(5);
            txtRoomInput.Name = "txtRoomInput";
            txtRoomInput.PlaceholderText = "Nhập mã phòng (VD: C1.202)";
            txtRoomInput.Size = new Size(1260, 43);
            txtRoomInput.TabIndex = 7;
            txtRoomInput.TextChanged += txtRoomInput_TextChanged;
            txtRoomInput.KeyDown += txtRoomInput_KeyDown;
            // 
            // btnAddRoom
            // 
            btnAddRoom.BackColor = Color.FromArgb(147, 197, 253);
            btnAddRoom.Enabled = false;
            btnAddRoom.FlatAppearance.BorderSize = 0;
            btnAddRoom.FlatStyle = FlatStyle.Flat;
            btnAddRoom.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddRoom.ForeColor = Color.White;
            btnAddRoom.Location = new Point(1419, 795);
            btnAddRoom.Margin = new Padding(5);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(82, 75);
            btnAddRoom.TabIndex = 8;
            btnAddRoom.Text = "+";
            btnAddRoom.UseVisualStyleBackColor = false;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // lblRoomHint
            // 
            lblRoomHint.AutoSize = true;
            lblRoomHint.Font = new Font("Segoe UI", 10.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRoomHint.ForeColor = Color.FromArgb(107, 114, 128);
            lblRoomHint.Location = new Point(73, 890);
            lblRoomHint.Margin = new Padding(5, 0, 5, 0);
            lblRoomHint.Name = "lblRoomHint";
            lblRoomHint.Size = new Size(672, 38);
            lblRoomHint.TabIndex = 9;
            lblRoomHint.Text = "Định dạng bắt buộc: <Tên khu>.<Tầng><Số phòng>.";
            // 
            // pnlRoomList
            // 
            pnlRoomList.BackColor = Color.Azure;
            pnlRoomList.Controls.Add(flpRooms);
            pnlRoomList.Controls.Add(lblRoomListTitle);
            pnlRoomList.Location = new Point(73, 960);
            pnlRoomList.Margin = new Padding(5);
            pnlRoomList.Name = "pnlRoomList";
            pnlRoomList.Size = new Size(1449, 519);
            pnlRoomList.TabIndex = 10;
            // 
            // flpRooms
            // 
            flpRooms.AutoScroll = true;
            flpRooms.FlowDirection = FlowDirection.TopDown;
            flpRooms.Location = new Point(32, 80);
            flpRooms.Margin = new Padding(5);
            flpRooms.Name = "flpRooms";
            flpRooms.Size = new Size(1383, 409);
            flpRooms.TabIndex = 1;
            flpRooms.WrapContents = false;
            // 
            // lblRoomListTitle
            // 
            lblRoomListTitle.AutoSize = true;
            lblRoomListTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomListTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblRoomListTitle.Location = new Point(29, 24);
            lblRoomListTitle.Margin = new Padding(5, 0, 5, 0);
            lblRoomListTitle.Name = "lblRoomListTitle";
            lblRoomListTitle.Size = new Size(308, 41);
            lblRoomListTitle.TabIndex = 0;
            lblRoomListTitle.Text = "Danh sách phòng (0)";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(880, 1516);
            btnSave.Margin = new Padding(5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(366, 92);
            btnSave.TabIndex = 14;
            btnSave.Text = "Thêm mới";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(107, 114, 128);
            btnCancel.Location = new Point(1270, 1516);
            btnCancel.Margin = new Padding(5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(278, 92);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(107, 114, 128);
            btnClose.Location = new Point(1472, 32);
            btnClose.Margin = new Padding(5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 126);
            btnClose.TabIndex = 16;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlName
            // 
            pnlName.Controls.Add(txtName);
            pnlName.Location = new Point(84, 301);
            pnlName.Name = "pnlName";
            pnlName.Size = new Size(1438, 75);
            pnlName.TabIndex = 17;
            // 
            // pnlDesc
            // 
            pnlDesc.Controls.Add(txtDesc);
            pnlDesc.Location = new Point(84, 452);
            pnlDesc.Name = "pnlDesc";
            pnlDesc.Size = new Size(1438, 271);
            pnlDesc.TabIndex = 18;
            // 
            // pnlRoomInput
            // 
            pnlRoomInput.Controls.Add(txtRoomInput);
            pnlRoomInput.Location = new Point(84, 795);
            pnlRoomInput.Name = "pnlRoomInput";
            pnlRoomInput.Size = new Size(1300, 75);
            pnlRoomInput.TabIndex = 19;
            // 
            // ucAdmin_AddDepartment
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlRoomInput);
            Controls.Add(pnlDesc);
            Controls.Add(pnlName);
            Controls.Add(btnClose);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(pnlRoomList);
            Controls.Add(lblRoomHint);
            Controls.Add(btnAddRoom);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblHeaderTitle);
            ForeColor = Color.White;
            Margin = new Padding(5);
            Name = "ucAdmin_AddDepartment";
            Size = new Size(1602, 1634);
            pnlRoomList.ResumeLayout(false);
            pnlRoomList.PerformLayout();
            pnlName.ResumeLayout(false);
            pnlName.PerformLayout();
            pnlDesc.ResumeLayout(false);
            pnlDesc.PerformLayout();
            pnlRoomInput.ResumeLayout(false);
            pnlRoomInput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblHeaderTitle;
        private Label label1;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private TextBox txtDesc;
        private Label label5;
        private TextBox txtRoomInput;
        private Button btnAddRoom;
        private Label lblRoomHint;
        private Panel pnlRoomList;
        private FlowLayoutPanel flpRooms;
        private Label lblRoomListTitle;
        private Button btnSave;
        private Button btnCancel;
        private Button btnClose;
        private Panel pnlName;
        private Panel pnlDesc;
        private Panel pnlRoomInput;
    }
}
