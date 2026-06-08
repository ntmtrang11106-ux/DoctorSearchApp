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
            label4 = new Label();
            rbShow = new RadioButton();
            rbHide = new RadioButton();
            btnSave = new Button();
            btnCancel = new Button();
            btnClose = new Button();
            pnlRoomList.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(30, 70, 125);
            lblHeaderTitle.Location = new Point(40, 40);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(256, 37);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Thêm chuyên khoa mới";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(107, 114, 128);
            label1.Location = new Point(45, 95);
            label1.Name = "label1";
            label1.Size = new Size(444, 31);
            label1.TabIndex = 1;
            label1.Text = "Nhập thông tin để thêm chuyên khoa mới vào hệ thống";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(17, 24, 39);
            label2.Location = new Point(45, 150);
            label2.Name = "label2";
            label2.Size = new Size(55, 28);
            label2.TabIndex = 2;
            label2.Text = "Tên *";
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(45, 195);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nhập tên chuyên khoa";
            txtName.Size = new Size(910, 34);
            txtName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(17, 24, 39);
            label3.Location = new Point(45, 255);
            label3.Name = "label3";
            label3.Size = new Size(61, 28);
            label3.TabIndex = 4;
            label3.Text = "Mô tả";
            // 
            // txtDesc
            // 
            txtDesc.BackColor = Color.White;
            txtDesc.BorderStyle = BorderStyle.FixedSingle;
            txtDesc.Font = new Font("Segoe UI", 12F);
            txtDesc.Location = new Point(45, 300);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.PlaceholderText = "Nhập mô tả (tùy chọn)";
            txtDesc.Size = new Size(910, 130);
            txtDesc.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(17, 24, 39);
            label5.Location = new Point(45, 460);
            label5.Name = "label5";
            label5.Size = new Size(114, 28);
            label5.TabIndex = 6;
            label5.Text = "Phòng khám";
            // 
            // txtRoomInput
            // 
            txtRoomInput.BackColor = Color.White;
            txtRoomInput.BorderStyle = BorderStyle.FixedSingle;
            txtRoomInput.Font = new Font("Segoe UI", 12F);
            txtRoomInput.Location = new Point(45, 505);
            txtRoomInput.Name = "txtRoomInput";
            txtRoomInput.PlaceholderText = "Nhập mã phòng (VD: C1.202)";
            txtRoomInput.Size = new Size(790, 34);
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
            btnAddRoom.Location = new Point(853, 492);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(102, 60);
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
            lblRoomHint.Location = new Point(45, 556);
            lblRoomHint.Name = "lblRoomHint";
            lblRoomHint.Size = new Size(347, 25);
            lblRoomHint.TabIndex = 9;
            lblRoomHint.Text = "Định dạng bắt buộc: <Tên khu>.<Tầng><Số phòng>.";
            // 
            // pnlRoomList
            // 
            pnlRoomList.BackColor = Color.FromArgb(249, 250, 251);
            pnlRoomList.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomList.Controls.Add(flpRooms);
            pnlRoomList.Controls.Add(lblRoomListTitle);
            pnlRoomList.Location = new Point(45, 600);
            pnlRoomList.Name = "pnlRoomList";
            pnlRoomList.Size = new Size(910, 210);
            pnlRoomList.TabIndex = 10;
            // 
            // flpRooms
            // 
            flpRooms.AutoScroll = true;
            flpRooms.FlowDirection = FlowDirection.TopDown;
            flpRooms.Location = new Point(20, 50);
            flpRooms.Name = "flpRooms";
            flpRooms.Size = new Size(868, 140);
            flpRooms.TabIndex = 1;
            flpRooms.WrapContents = false;
            // 
            // lblRoomListTitle
            // 
            lblRoomListTitle.AutoSize = true;
            lblRoomListTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomListTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblRoomListTitle.Location = new Point(18, 15);
            lblRoomListTitle.Name = "lblRoomListTitle";
            lblRoomListTitle.Size = new Size(165, 25);
            lblRoomListTitle.TabIndex = 0;
            lblRoomListTitle.Text = "Danh sách phòng (0)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(17, 24, 39);
            label4.Location = new Point(46, 835);
            label4.Name = "label4";
            label4.Size = new Size(101, 28);
            label4.TabIndex = 11;
            label4.Text = "Trạng thái";
            // 
            // rbShow
            // 
            rbShow.AutoSize = true;
            rbShow.Checked = true;
            rbShow.Font = new Font("Segoe UI", 12F);
            rbShow.Location = new Point(46, 880);
            rbShow.Name = "rbShow";
            rbShow.Size = new Size(101, 32);
            rbShow.TabIndex = 12;
            rbShow.TabStop = true;
            rbShow.Text = "Hiển thị";
            rbShow.UseVisualStyleBackColor = true;
            // 
            // rbHide
            // 
            rbHide.AutoSize = true;
            rbHide.Font = new Font("Segoe UI", 12F);
            rbHide.Location = new Point(190, 880);
            rbHide.Name = "rbHide";
            rbHide.Size = new Size(53, 32);
            rbHide.TabIndex = 13;
            rbHide.Text = "Ẩn";
            rbHide.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(467, 945);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(300, 72);
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
            btnCancel.Location = new Point(784, 945);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(171, 72);
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
            btnClose.Location = new Point(906, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(74, 79);
            btnClose.TabIndex = 16;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlName
            // 
            pnlName.Controls.Add(txtName);
            pnlName.Location = new Point(45, 227);
            pnlName.Name = "pnlName";
            pnlName.Size = new Size(880, 76);
            pnlName.TabIndex = 12;
            // 
            // pnlDesc
            // 
            pnlDesc.Controls.Add(txtDesc);
            pnlDesc.Location = new Point(46, 367);
            pnlDesc.Name = "pnlDesc";
            pnlDesc.Size = new Size(879, 249);
            pnlDesc.TabIndex = 13;
            // 
            // ucAdmin_AddDepartment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlDesc);
            Controls.Add(pnlName);
            Controls.Add(btnClose);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(rbHide);
            Controls.Add(rbShow);
            Controls.Add(label4);
            Controls.Add(pnlRoomList);
            Controls.Add(lblRoomHint);
            Controls.Add(btnAddRoom);
            Controls.Add(txtRoomInput);
            Controls.Add(label5);
            Controls.Add(txtDesc);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblHeaderTitle);
            Name = "ucAdmin_AddDepartment";
            Size = new Size(986, 1040);
            pnlRoomList.ResumeLayout(false);
            pnlRoomList.PerformLayout();
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
        private Label label4;
        private RadioButton rbShow;
        private RadioButton rbHide;
        private Button btnSave;
        private Button btnCancel;
        private Button btnClose;
        private Panel pnlName;
        private Panel pnlDesc;
    }
}
