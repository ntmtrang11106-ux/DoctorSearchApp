using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    /// <summary>
    /// UserControl giao diện quản trị viên: Thêm hoặc Cập nhật Chuyên khoa kèm theo danh sách phòng khám.
    /// </summary>
    public partial class ucAdmin_AddDepartment : UserControl
    {
        // Biểu thức chính quy (Regex) bắt buộc định dạng mã phòng khám (Ví dụ: C1.202)
        // Bắt đầu bằng 1 chữ cái (Khu), theo sau là chữ/số và dấu chấm, kết thúc bằng đúng 3 chữ số (Tầng và Số phòng)
        private static readonly Regex RoomCodePattern = new Regex(@"^[A-Za-z][A-Za-z0-9]*\.[0-9]{3}$", RegexOptions.Compiled);

        private DepartmentDTO _dept; // Đối tượng chuyên khoa hiện tại (null nếu là thêm mới)
        private readonly DepartmentBUS _deptBUS = new DepartmentBUS(); // Đối tượng BUS xử lý nghiệp vụ Chuyên khoa
        private readonly List<string> _roomCodes = new List<string>(); // Danh sách các mã phòng khám tạm thời trên giao diện
        
        // Sự kiện thông báo cho Form cha khi bấm nút Hủy hoặc Đóng
        public event EventHandler OnCancel;
        // Sự kiện thông báo khi thêm/sửa thành công để tải lại danh sách chuyên khoa ở trang quản lý
        public event EventHandler? OnSuccess;

        public ucAdmin_AddDepartment()
        {
            InitializeComponent();
            // Thiết lập bo góc, hiệu ứng kéo thả cửa sổ và bo viền cho các Panel
            SetupUI();
            
            // Thiết lập hiệu ứng chuyển màu sắc (Focus/Blur) cho các ô nhập liệu TextBox
            InitializeInputStyling();
            
            // Cấu hình chống nhấp nháy khi cuộn thanh cuộn của danh sách phòng khám
            UIHelper.SetupScrollableContainer(flpRooms);
            
            // Bật bộ đệm kép đệ quy cho toàn bộ control con hiện có
            UIHelper.SetDoubleBuffered(this);
            
            // Tải lại giao diện danh sách phòng khám và trạng thái nút Thêm phòng khám
            RefreshRoomList();
            UpdateAddRoomButtonState();
        }

        /// <summary>
        /// Ghi đè thông số khởi tạo cửa sổ (CreateParams) để kích hoạt bộ đệm kép cấp độ hệ điều hành.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED: Vẽ tất cả các control con trong bộ đệm trước khi hiển thị, giúp chống nháy hoàn toàn
                return cp;
            }
        }

        /// <summary>
        /// Xử lý sự kiện Paint để vẽ đường viền ngoài (Border) có bo góc cho UserControl.
        /// </summary>
        private void ucAdmin_AddDepartment_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(30, 70, 125), 3);
        }

        /// <summary>
        /// Khởi tạo hiệu ứng tương tác (Placeholder và màu sắc focus) cho các TextBox nhập liệu.
        /// </summary>
        private void InitializeInputStyling()
        {
            // Thiết lập hiệu ứng đổi màu nền và màu viền của Panel bọc ngoài khi người dùng click vào TextBox tương ứng
            UIHelper.SetupInputFocusEffect(txtName, pnlName, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtDesc, pnlDesc, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtRoomInput, pnlRoomInput, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));

            // Đưa nút và Panel lên lớp trên cùng (Z-order) để hiển thị không bị che khuất
            btnAddRoom.BringToFront();
            pnlRoomList.BringToFront();
            
            // Đăng ký sự kiện nhấn ra vùng trống ngoài TextBox để hủy con trỏ focus (Unfocus)
            UIHelper.RegisterClickToUnfocus(this);
        }

        /// <summary>
        /// Thiết lập hình dáng bo góc, viền ngoài và tính năng di chuyển (drag) giao diện cho các Control.
        /// </summary>
        private void SetupUI()
        {
            // Áp dụng bo góc tròn cho các nút bấm và khung danh sách
            UIHelper.ApplyRoundedRegion(btnSave, 12);
            UIHelper.ApplyRoundedRegion(btnCancel, 12);
            UIHelper.ApplyRoundedRegion(btnAddRoom, 12);
            UIHelper.ApplyRoundedRegion(pnlRoomList, 16);

            // Vẽ viền xám mờ tinh tế cho các Panel nhập liệu
            UIHelper.ApplyBorderPanelStyle(pnlName);
            UIHelper.ApplyBorderPanelStyle(pnlDesc);
            UIHelper.ApplyBorderPanelStyle(pnlRoomInput);

            // Cho phép người dùng nhấp chuột trái và kéo lê tiêu đề hoặc vùng trống của UserControl để dịch chuyển vị trí giao diện
            UIHelper.EnableNativeDrag(this, this);
            UIHelper.EnableNativeDrag(lblHeaderTitle, this);
            UIHelper.EnableNativeDrag(label1, this);
        }

        /// Truyền dữ liệu Chuyên khoa từ danh sách Admin để hiển thị lên Form chỉnh sửa (hoặc để trống nếu thêm mới).
        public void SetData(DepartmentDTO dept)
        {
            _dept = dept;
            _roomCodes.Clear();

            // Mở khóa ô nhập liệu phòng khám và thiết lập lại gợi ý định dạng
            txtRoomInput.Enabled = true;
            txtRoomInput.Text = string.Empty;
            btnAddRoom.Visible = true;
            pnlRoomList.Visible = true;
            lblRoomHint.Text = "Định dạng bắt buộc: <Tên khu>.<Tầng><Số phòng>. Ví dụ: C1.202";

            // Kiểm tra xem là chế độ Cập nhật (Edit) hay Thêm mới (Add)
            if (_dept != null)
            {
                lblHeaderTitle.Text = "Cập nhật chuyên khoa";
                btnSave.Text = "Cập nhật";
                txtName.Text = _dept.DepartmentName;
                txtDesc.Text = _dept.Description;

                // Tải danh sách phòng khám thuộc chuyên khoa này từ CSDL thông qua RoomBUS
                RoomBUS roomBUS = new RoomBUS();
                var rooms = roomBUS.GetRoomsByDepartment(_dept.Id);
                if (rooms != null)
                {
                    // Đưa mã phòng khám vào mảng để quản lý trên giao diện tạm thời
                    _roomCodes.AddRange(rooms.Select(r => r.RoomCode));
                }
            }
            else
            {
                // Cấu hình giao diện trống cho chế độ thêm mới chuyên khoa
                lblHeaderTitle.Text = "Thêm chuyên khoa mới";
                btnSave.Text = "Thêm mới";
                txtName.Text = string.Empty;
                txtDesc.Text = string.Empty;
            }

            // Tải lại danh sách phòng khám hiển thị trên UI và cập nhật nút Thêm phòng
            RefreshRoomList();
            UpdateAddRoomButtonState();
        }

        /// <summary>
        /// Kích hoạt khi có thay đổi văn bản nhập mã phòng khám để cập nhật trạng thái hoạt động của nút "+"
        /// </summary>
        private void txtRoomInput_TextChanged(object sender, EventArgs e)
        {
            UpdateAddRoomButtonState();
        }

        /// <summary>
        /// Bắt sự kiện gõ phím Enter trên ô nhập mã phòng khám để thêm nhanh phòng khám mà không cần click chuột.
        /// </summary>
        private void txtRoomInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng bip mặc định của hệ thống khi nhấn Enter trong TextBox đơn dòng
                TryAddRoomFromInput(); // Thực hiện thêm phòng khám
            }
        }

        /// <summary>
        /// Cập nhật trạng thái nút thêm phòng khám: Chỉ bật khi ô nhập mã có nội dung và không bị khóa.
        /// </summary>
        private void UpdateAddRoomButtonState()
        {
            bool enabled = txtRoomInput.Enabled && !string.IsNullOrWhiteSpace(txtRoomInput.Text);
            btnAddRoom.Enabled = enabled;
            // Thay đổi màu sắc nút bấm để phản hồi trực quan (Màu xanh đậm khi hoạt động, xanh nhạt khi bị vô hiệu hóa)
            btnAddRoom.BackColor = enabled ? Color.FromArgb(96, 165, 250) : Color.FromArgb(191, 219, 254);
        }

        /// <summary>
        /// Sự kiện click nút thêm phòng khám "+".
        /// </summary>
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            TryAddRoomFromInput();
        }

        /// <summary>
        /// Thực hiện kiểm tra nghiệp vụ định dạng và trùng lặp mã phòng khám trước khi thêm vào danh sách hiển thị tạm thời.
        /// </summary>
        private void TryAddRoomFromInput()
        {
            string roomCode = txtRoomInput.Text.Trim().ToUpperInvariant();
            if (string.IsNullOrWhiteSpace(roomCode))
            {
                MessageBox.Show("Bạn cần nhập xong mã phòng trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra định dạng Regex (Ví dụ: C1.202)
            if (!IsValidRoomCode(roomCode))
            {
                MessageBox.Show(
                    "Mã phòng không đúng định dạng.\n\nĐịnh dạng hợp lệ: <Tên khu>.<Tầng><Số phòng>\nVí dụ: C1.202",
                    "Sai định dạng phòng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 3. Kiểm tra trùng mã ngay trong danh sách tạm thời hiển thị trên UI
            if (_roomCodes.Contains(roomCode, StringComparer.OrdinalIgnoreCase))
            {
                MessageBox.Show("Phòng này đã có trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm mã phòng khám hợp lệ vào danh sách và xóa trắng ô nhập liệu để nhập phòng tiếp theo
            _roomCodes.Add(roomCode);
            txtRoomInput.Clear();
            
            // Vẽ lại danh sách phòng khám trên UI
            RefreshRoomList();
            UpdateAddRoomButtonState();
            txtRoomInput.Focus(); // Trả lại con trỏ soạn thảo về ô nhập phòng để tiện nhập tiếp
        }

        /// <summary>
        /// Phương thức tĩnh kiểm tra tính hợp lệ của mã phòng khám bằng Regex.
        /// </summary>
        private static bool IsValidRoomCode(string roomCode)
        {
            return RoomCodePattern.IsMatch(roomCode);
        }

        /// <summary>
        /// Thực hiện vẽ lại danh sách phòng khám bằng cách tạo các control Panel động.
        /// </summary>
        private void RefreshRoomList()
        {
            // Tạm dừng tính toán bố cục (Layout) của FlowLayoutPanel để tránh hiện tượng màn hình vẽ lại nhiều lần gây giật lag
            flpRooms.SuspendLayout();
            flpRooms.Controls.Clear();

            // Khởi tạo các item phòng khám dạng thẻ nhỏ
            foreach (string roomCode in _roomCodes)
            {
                flpRooms.Controls.Add(CreateRoomItem(roomCode));
            }

            lblRoomListTitle.Text = $"Danh sách phòng ({_roomCodes.Count})";
            flpRooms.ResumeLayout();
        }

        /// Tạo lập chương trình một thẻ phòng khám động (Room Card Control Panel).
        private Control CreateRoomItem(string roomCode)
        {
            const int cardWidth = 300; // Chiều rộng cố định vừa vặn FlowLayoutPanel
            const int cardHeight = 70; // Chiều cao tối ưu cân đối

            // Tạo Panel bọc ngoài (Card Panel)
            Panel row = new Panel
            {
                Width = cardWidth,
                Height = cardHeight,
                BackColor = Color.White, // Đổi sang nền xám nhạt (Gray 100) để nổi bật trên nền trắng của List
                Margin = new Padding(6, 0, 6, 8),
                Padding = new Padding(12, 0, 8, 0) // Tạo khoảng cách đệm an toàn xung quanh rìa
            };
            UIHelper.ApplyRoundedRegion(row, 8); // Bo góc 8px cho từng thẻ phòng
            
            // Kích hoạt DoubleBuffered cho Panel động này để chống giật nhấp nháy khi người dùng cuộn xem
            UIHelper.SetDoubleBuffered(row);

            // Nhãn hiển thị mã phòng khám
            Label lblText = new Label
            {
                Text = roomCode,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold), // Đổi sang Semibold nhìn rõ nét, hiện đại hơn
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(16, 16), // Tự động căn giữa nhãn theo chiều dọc Card
                AutoSize = true
            };

            // Nút bấm xóa phòng khám khỏi danh sách "×"
            Button btnRemoveRoom = new Button
            {
                Text = "×",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(156, 163, 175), // Màu xám nhẹ mặc định
                Font = new Font("Segoe UI", 16F, FontStyle.Regular),
                Size = new Size(36, 36),
                Dock = DockStyle.Right, // Ép dính hẳn sát lề phải của Card
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Tag = roomCode
            };
            btnRemoveRoom.FlatAppearance.BorderSize = 0;
            btnRemoveRoom.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnRemoveRoom.FlatAppearance.MouseOverBackColor = Color.Transparent;

            // Hiệu ứng Hover đổi màu nút xóa sang đỏ rực để tạo cảm giác phản hồi tốt
            btnRemoveRoom.MouseEnter += (s, e) => btnRemoveRoom.ForeColor = Color.FromArgb(239, 68, 68);
            btnRemoveRoom.MouseLeave += (s, e) => btnRemoveRoom.ForeColor = Color.FromArgb(156, 163, 175);
            btnRemoveRoom.Click += btnRemoveRoom_Click;

            // Thêm các control vào Panel và vẽ đường viền bao quanh Panel
            row.Controls.Add(lblText);
            row.Controls.Add(btnRemoveRoom);
            UIHelper.ApplyBorderPanelStyle(row);

            return row;
        }

        /// <summary>
        /// Xử lý xóa phòng khám khi click vào nút "x" trên thẻ phòng khám.
        /// </summary>
        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string roomCode)
            {
                _roomCodes.RemoveAll(r => string.Equals(r, roomCode, StringComparison.OrdinalIgnoreCase));
                RefreshRoomList();
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút Lưu (Thêm mới / Cập nhật chuyên khoa kèm phòng khám).
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên chuyên khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khởi tạo DTO chuyên khoa mới hoặc lấy lại chuyên khoa hiện tại
            DepartmentDTO dept = _dept ?? new DepartmentDTO();
            dept.DepartmentName = name;
            dept.Description = txtDesc.Text.Trim();
            dept.IsActive = true;
            dept.DisplayOrder = 0;

            // 2. Kiểm tra ràng buộc bắt buộc: Chuyên khoa phải chứa tối thiểu 1 phòng khám
            if (_roomCodes.Count == 0)
            {
                MessageBox.Show("Bạn cần thêm ít nhất một phòng cho chuyên khoa trước khi lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuyển đổi mảng mã phòng thành danh sách đối tượng RoomDTO
            List<RoomDTO> rooms = _roomCodes
                .Select(code => new RoomDTO
                {
                    RoomCode = code,
                    RoomName = $"Phòng {code}",
                    IsActive = true
                })
                .ToList();

            try
            {
                bool success;
                if (_dept == null)
                {
                    // Chế độ THÊM MỚI: Gọi lớp BUS thực hiện thêm mới chuyên khoa kèm phòng
                    success = _deptBUS.AddDepartmentWithRooms(dept, rooms);
                }
                else
                {
                    // Chế độ CẬP NHẬT: Gọi lớp BUS thực hiện đồng bộ sửa đổi chuyên khoa và phòng
                    success = _deptBUS.UpdateDepartmentWithRooms(dept, rooms);
                }

                if (success)
                {
                    MessageBox.Show("Thành công!", "Thông báo");
                    OnSuccess?.Invoke(this, EventArgs.Empty); // Kích hoạt sự kiện báo thành công cho lớp cha
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại. Hãy kiểm tra lại tên khoa hoặc mã phòng có bị trùng không.", "Lỗi");
                }
            }
            catch (ArgumentException ex)
            {
                // Bắt và hiển thị trực quan các ngoại lệ lỗi nghiệp vụ phát sinh từ lớp BUS
                // Ví dụ: Lỗi trùng tên chuyên khoa, hoặc mã phòng khám đang hoạt động tại khoa khác
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại. Lỗi chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý click nút Hủy.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý click nút đóng "x" góc trên bên phải.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }
    }
}