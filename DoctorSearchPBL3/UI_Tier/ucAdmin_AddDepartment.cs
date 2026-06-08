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
            UIHelper.DrawControlBorder(sender, e, 15, Color.Black, 3);
        }

        private void InitializeInputStyling()
        {
            Panel pnlName = SetupInputWrapper(txtName);
            Panel pnlDesc = SetupInputWrapper(txtDesc);
            Panel pnlRoomInput = SetupInputWrapper(txtRoomInput);

            UIHelper.SetupInputFocusEffect(txtName, pnlName, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtDesc, pnlDesc, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtRoomInput, pnlRoomInput, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));

            btnAddRoom.BringToFront();
            pnlRoomList.BringToFront();
            UIHelper.RegisterClickToUnfocus(this);
        }

        private Panel SetupInputWrapper(Control ctrl)
        {
            Panel pnl = new Panel();
            const int padding = 3;
            pnl.Bounds = new Rectangle(ctrl.Left - padding, ctrl.Top - padding, ctrl.Width + (padding * 2), ctrl.Height + (padding * 2));
            pnl.BackColor = Color.White;
            pnl.Name = "pnlWrapper_" + ctrl.Name;

            Controls.Add(pnl);
            ctrl.Parent = pnl;
            ctrl.Location = new Point(padding, padding);
            ctrl.Width = pnl.Width - (padding * 2);
            ctrl.Height = pnl.Height - (padding * 2);

            return pnl;
        }

        private void SetupUI()
        {
            lblHeaderTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label1.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            txtName.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtDesc.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtRoomInput.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            txtName.BorderStyle = BorderStyle.None;
            txtDesc.BorderStyle = BorderStyle.None;
            txtRoomInput.BorderStyle = BorderStyle.None;

            UIHelper.ApplyRoundedRegion(btnSave, 12);
            UIHelper.ApplyRoundedRegion(btnCancel, 12);
            UIHelper.ApplyRoundedRegion(btnAddRoom, 12);
            UIHelper.ApplyRoundedRegion(pnlRoomList, 16);

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
                rbShow.Checked = _dept.IsActive;
                rbHide.Checked = !_dept.IsActive;
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
                rbShow.Checked = true;
                rbHide.Checked = false;
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

        private Control CreateRoomItem(string roomCode)
        {
            Panel row = new Panel
            {
                Width = flpRooms.ClientSize.Width - 25,
                Height = 52,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 10)
            };
            UIHelper.ApplyRoundedRegion(row, 10);

            Label lblIcon = new Label
            {
                Text = "🏥",
                Font = new Font("Segoe UI Emoji", 14F),
                ForeColor = Color.FromArgb(37, 99, 235),
                Location = new Point(14, 9),
                Size = new Size(36, 32)
            };

            Label lblText = new Label
            {
                Text = roomCode,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(60, 12),
                AutoSize = true
            };

            Button btnRemoveRoom = new Button
            {
                Text = "×",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(31, 41, 55),
                Font = new Font("Segoe UI", 16F, FontStyle.Regular),
                Size = new Size(42, 36),
                Location = new Point(row.Width - 54, 8),
                BackColor = Color.White,
                Tag = roomCode
            };
            btnRemoveRoom.FlatAppearance.BorderSize = 0;
            btnRemoveRoom.Click += btnRemoveRoom_Click;

            row.Controls.Add(lblIcon);
            row.Controls.Add(lblText);
            row.Controls.Add(btnRemoveRoom);
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
            dept.IsActive = rbShow.Checked;
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
