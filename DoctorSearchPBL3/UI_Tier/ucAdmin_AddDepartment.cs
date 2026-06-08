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
    public partial class ucAdmin_AddDepartment : UserControl
    {
        private static readonly Regex RoomCodePattern = new Regex(@"^[A-Za-z][A-Za-z0-9]*\.[0-9]{3}$", RegexOptions.Compiled);

        private DepartmentDTO _dept;
        private readonly DepartmentBUS _deptBUS = new DepartmentBUS();
        private readonly List<string> _roomCodes = new List<string>();
        public event EventHandler OnCancel;
        public event EventHandler? OnSuccess;

        public ucAdmin_AddDepartment()
        {
            InitializeComponent();
            Paint += ucAdmin_AddDepartment_Paint;
            Padding = new Padding(3);

            SetupUI();
            InitializeInputStyling();
            UIHelper.SetDoubleBuffered(this);
            RefreshRoomList();
            UpdateAddRoomButtonState();
        }

        private void ucAdmin_AddDepartment_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(30, 70, 125), 3);
        }

        private void InitializeInputStyling()
        {
            UIHelper.SetupInputFocusEffect(txtName, pnlName, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtDesc, pnlDesc, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtRoomInput, pnlRoomInput, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));

            btnAddRoom.BringToFront();
            pnlRoomList.BringToFront();
            UIHelper.RegisterClickToUnfocus(this);
        }

        private void SetupUI()
        {
            UIHelper.ApplyRoundedRegion(btnSave, 12);
            UIHelper.ApplyRoundedRegion(btnCancel, 12);
            UIHelper.ApplyRoundedRegion(btnAddRoom, 12);
            UIHelper.ApplyRoundedRegion(pnlRoomList, 16);

            UIHelper.ApplyBorderPanelStyle(pnlName);
            UIHelper.ApplyBorderPanelStyle(pnlDesc);
            UIHelper.ApplyBorderPanelStyle(pnlRoomInput);

            UIHelper.EnableNativeDrag(this, this);
            UIHelper.EnableNativeDrag(lblHeaderTitle, this);
            UIHelper.EnableNativeDrag(label1, this);
        }

        public void SetData(DepartmentDTO dept)
        {
            _dept = dept;
            _roomCodes.Clear();

            if (_dept != null)
            {
                lblHeaderTitle.Text = "Cập nhật chuyên khoa";
                btnSave.Text = "Cập nhật";
                txtName.Text = _dept.DepartmentName;
                txtDesc.Text = _dept.Description;
                txtRoomInput.Text = "Phòng chỉ được khởi tạo khi tạo chuyên khoa.";
                txtRoomInput.Enabled = false;
                btnAddRoom.Enabled = false;
                btnAddRoom.Visible = false;
                pnlRoomList.Visible = false;
                lblRoomHint.Text = "Muốn thay đổi danh sách phòng, cần cập nhật quy trình quản trị phòng sau.";
            }
            else
            {
                lblHeaderTitle.Text = "Thêm chuyên khoa mới";
                btnSave.Text = "Thêm mới";
                txtRoomInput.Enabled = true;
                txtRoomInput.Text = string.Empty;
                btnAddRoom.Visible = true;
                pnlRoomList.Visible = true;
                lblRoomHint.Text = "Định dạng bắt buộc: <Tên khu>.<Tầng><Số phòng>. Ví dụ: C1.202";
            }

            RefreshRoomList();
            UpdateAddRoomButtonState();
        }

        private void txtRoomInput_TextChanged(object sender, EventArgs e)
        {
            UpdateAddRoomButtonState();
        }

        private void txtRoomInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TryAddRoomFromInput();
            }
        }

        private void UpdateAddRoomButtonState()
        {
            bool enabled = txtRoomInput.Enabled && !string.IsNullOrWhiteSpace(txtRoomInput.Text);
            btnAddRoom.Enabled = enabled;
            btnAddRoom.BackColor = enabled ? Color.FromArgb(96, 165, 250) : Color.FromArgb(191, 219, 254);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            TryAddRoomFromInput();
        }

        private void TryAddRoomFromInput()
        {
            string roomCode = txtRoomInput.Text.Trim().ToUpperInvariant();
            if (string.IsNullOrWhiteSpace(roomCode))
            {
                MessageBox.Show("Bạn cần nhập xong mã phòng trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidRoomCode(roomCode))
            {
                MessageBox.Show(
                    "Mã phòng không đúng định dạng.\n\nĐịnh dạng hợp lệ: <Tên khu>.<Tầng><Số phòng>\nVí dụ: C1.202",
                    "Sai định dạng phòng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_roomCodes.Contains(roomCode, StringComparer.OrdinalIgnoreCase))
            {
                MessageBox.Show("Phòng này đã có trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _roomCodes.Add(roomCode);
            txtRoomInput.Clear();
            RefreshRoomList();
            UpdateAddRoomButtonState();
            txtRoomInput.Focus();
        }

        private static bool IsValidRoomCode(string roomCode)
        {
            return RoomCodePattern.IsMatch(roomCode);
        }

        private void RefreshRoomList()
        {
            flpRooms.SuspendLayout();
            flpRooms.Controls.Clear();

            foreach (string roomCode in _roomCodes)
            {
                flpRooms.Controls.Add(CreateRoomItem(roomCode));
            }

            lblRoomListTitle.Text = $"Danh sách phòng ({_roomCodes.Count})";
            flpRooms.ResumeLayout();
        }

        // --- TỐI ƯU: ĐOẠN KHỞI TẠO ITEM PHÒNG CỐ ĐỊNH SIZE, CÂN ĐỐI UI ---
        private Control CreateRoomItem(string roomCode)
        {
            const int cardWidth = 300; // Cố định bề ngang vừa vặn với layout FlowLayoutPanel
            const int cardHeight = 70; // Hạ độ cao xuống một chút nhìn thanh thoát hơn 60px cũ

            Panel row = new Panel
            {
                Width = cardWidth,
                Height = cardHeight,
                BackColor = Color.White, // Đổi sang nền xám nhạt (Gray 100) để nổi bật trên nền trắng của List
                Margin = new Padding(6, 0, 6, 8),
                Padding = new Padding(12, 0, 8, 0) // Tạo khoảng cách đệm an toàn xung quanh rìa
            };
            UIHelper.ApplyRoundedRegion(row, 8);

            Label lblText = new Label
            {
                Text = roomCode,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold), // Đổi sang Semibold nhìn rõ nét, hiện đại hơn
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(16, 16), // Tự động căn giữa nhãn theo chiều dọc Card
                AutoSize = true
            };

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

            row.Controls.Add(lblText);
            row.Controls.Add(btnRemoveRoom);
            UIHelper.ApplyBorderPanelStyle(row);

            return row;
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string roomCode)
            {
                _roomCodes.RemoveAll(r => string.Equals(r, roomCode, StringComparison.OrdinalIgnoreCase));
                RefreshRoomList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên chuyên khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DepartmentDTO dept = _dept ?? new DepartmentDTO();
            dept.DepartmentName = name;
            dept.Description = txtDesc.Text.Trim();
            dept.IsActive = true;
            dept.DisplayOrder = 0;

            bool success;
            if (_dept == null)
            {
                if (_roomCodes.Count == 0)
                {
                    MessageBox.Show("Bạn cần thêm ít nhất một phòng cho chuyên khoa trước khi lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<RoomDTO> rooms = _roomCodes
                    .Select(code => new RoomDTO
                    {
                        RoomCode = code,
                        RoomName = $"Phòng {code}",
                        IsActive = true
                    })
                    .ToList();

                success = _deptBUS.AddDepartmentWithRooms(dept, rooms);
            }
            else
            {
                success = _deptBUS.UpdateDepartment(dept);
            }

            if (success)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                OnSuccess?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại. Hãy kiểm tra lại tên khoa hoặc mã phòng có bị trùng không.", "Lỗi");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }
    }
}