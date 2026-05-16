using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucTimeSlotDialog : UserControl
    {
        private readonly TimeSlotBUS _timeSlotsBus = new TimeSlotBUS();
        private readonly DepartmentBUS _deptBus = new DepartmentBUS();
        private readonly DoctorBUS _doctorBus = new DoctorBUS();
        private readonly RoomBUS _roomBus = new RoomBUS();

        public event EventHandler OnCloseModal;
        private int _editSlotId = 0;
        private bool _isDragging = false;
        private Point _dragStartPoint;

        public ucTimeSlotDialog()
        {
            InitializeComponent();
        }

        public void SetupEditMode(TimeSlotsDTO data)
        {
            _editSlotId = data.Id;
            lblTitle.Text = "Chỉnh sửa lịch hẹn";
            btnCreate.Text = "CẬP NHẬT";

            // 1. Phải load dữ liệu vào ComboBox trước khi gán SelectedValue
            LoadInitialData();

            // 2. Điền dữ liệu
            cbDept.SelectedValue = data.Doctor?.DepartmentId ?? 0;
            
            // Ép filter doctor theo khoa vừa chọn để cbDoctor có dữ liệu mà chọn
            if (data.Doctor?.DepartmentId != null) {
                var allDoctors = _doctorBus.GetListDoctors();
                cbDoctor.DataSource = allDoctors.Where(d => d.DepartmentId == data.Doctor.DepartmentId).ToList();
            }
            
            cbDoctor.SelectedValue = data.DoctorId;
            dtpWorkDate.Value = data.WorkDate;
            dtpStartTime.Value = DateTime.Today.Add(data.StartTime);
            dtpEndTime.Value = DateTime.Today.Add(data.EndTime);
            cbRoom.SelectedValue = data.RoomId;
            numMax.Value = data.MaxAppointments;

            // Ẩn phần lặp lại khi chỉnh sửa
            cbRepeat.Visible = false;
        }

        private void ucTimeSlotCheckbox_Load(object sender, EventArgs e)
        {
            UIHelper.SetDoubleBuffered(this);
            UIHelper.ApplyRoundedRegion(this, 12);
            UIHelper.ApplyRoundedRegion(btnCreate, 8);
            UIHelper.ApplyRoundedRegion(btnCancel, 8);

            // Gán sự kiện kéo form cho Title thông qua UIHelper (Dùng API mượt hơn)
            UIHelper.EnableNativeDrag(pnlHeader, this);
            UIHelper.EnableNativeDrag(lblTitle, this);

            // 1. Viền đen dày 2 cho form (Giảm độ dày cho tinh tế hơn)
            this.Paint += (s, ev) => {
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.Black, 2)) {
                    var rect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
                    using (var path = UIHelper.GetRoundedPath(rect, 12))
                        ev.Graphics.DrawPath(p, path);
                }
            };

            // Vẽ viền cho Panel Header để tránh bị Dock che mất phần trên
            pnlHeader.Paint += (s, ev) => {
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.Black, 2)) {
                    // Vẽ cung tròn phía trên cho Header (Dày 2px đồng bộ)
                    var rect = new Rectangle(1, 1, this.Width - 3, this.Height + 50); 
                    using (var path = UIHelper.GetRoundedPath(rect, 12))
                        ev.Graphics.DrawPath(p, path);
                }
            };

            // 2. Style Label chữ màu đen và loại bỏ viền mặc định của Input
            foreach (Control c in this.Controls) {
                if (c is Label lbl) lbl.ForeColor = Color.Black;
                if (c is Panel pnl) {
                    foreach (Control pc in pnl.Controls) {
                        if (pc is Label plbl) plbl.ForeColor = Color.Black;
                        
                        // Loại bỏ viền mặc định để viền đen custom hiện lên đẹp hơn
                        if (pc is ComboBox cb) cb.FlatStyle = FlatStyle.Flat;
                        if (pc is DateTimePicker dtp) dtp.Format = DateTimePickerFormat.Custom; // Một số tùy chỉnh cho DateTimePicker
                        if (pc is NumericUpDown num) num.BorderStyle = BorderStyle.None;
                    }
                }
            }
            lblTitle.ForeColor = Color.Black;

            // 3. Register unfocus khi click ra ngoài
            UIHelper.RegisterClickToUnfocus(this, lblTitle);

            // 4. Hiệu ứng Focus cho các ô nhập (Chuẩn 2px Đen / 4px Xanh / Bo góc 8)
            Color focusColor = Color.FromArgb(242, 248, 255);
            Color unfocusColor = Color.White;
            Color highlightColor = Color.FromArgb(37, 99, 235);

            UIHelper.SetupInputFocusEffect(cbDept, pnlDeptBorder, focusColor, unfocusColor, highlightColor);
            UIHelper.SetupInputFocusEffect(cbDoctor, pnlDoctorBorder, focusColor, unfocusColor, highlightColor);
            UIHelper.SetupInputFocusEffect(dtpWorkDate, pnlDateBorder, focusColor, unfocusColor, highlightColor);
            UIHelper.SetupInputFocusEffect(dtpStartTime, pnlStartBorder, focusColor, unfocusColor, highlightColor);
            UIHelper.SetupInputFocusEffect(dtpEndTime, pnlEndBorder, focusColor, unfocusColor, highlightColor);
            UIHelper.SetupInputFocusEffect(cbRoom, pnlRoomBorder, focusColor, unfocusColor, highlightColor);
            UIHelper.SetupInputFocusEffect(numMax, pnlMaxBorder, focusColor, unfocusColor, highlightColor);

            // Bổ sung wrapper và focus cho các ô trong phần lặp lại
            SetupRepeatInputsStyling(focusColor, unfocusColor, highlightColor);

            if (_editSlotId == 0)
            {
                LoadInitialData();
            }
            InitDayPicker();
        }

        private void SetupRepeatInputsStyling(Color focusColor, Color unfocusColor, Color highlightColor)
        {
            // Tự động tạo wrapper cho dtpStartDateRange và dtpEndDateRange nếu chưa có
            DateTimePicker[] datePickers = { dtpStartDateRange, dtpEndDateRange };
            foreach (var dtp in datePickers)
            {
                Panel pnl = new Panel();
                pnl.Size = new Size(dtp.Width + 14, dtp.Height + 14); // Tăng size panel
                pnl.Location = new Point(dtp.Left - 7, dtp.Top - 7);
                pnl.BackColor = Color.White;
                dtp.Parent.Controls.Add(pnl);
                dtp.Parent = pnl;
                dtp.Dock = DockStyle.Fill;
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd/MM/yyyy";
                pnl.Padding = new Padding(12, 10, 12, 8); // Tăng padding
                UIHelper.SetupInputFocusEffect(dtp, pnl, focusColor, unfocusColor, highlightColor);
            }
        }

        private void LoadInitialData()
        {
            // Load Departments
            var depts = _deptBus.GetDepartmentsForUI();
            cbDept.DataSource = depts;
            cbDept.DisplayMember = "DepartmentName";
            cbDept.ValueMember = "Id";
            cbDept.SelectedIndex = -1;

            // Load Rooms
            var rooms = _roomBus.GetRoomsForComboBox();
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "RoomCode";
            cbRoom.ValueMember = "Id";
            cbRoom.SelectedIndex = -1;
        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDept.SelectedValue is int deptId)
            {
                // Filter doctors by selected department
                var allDoctors = _doctorBus.GetListDoctors();
                var filteredDoctors = allDoctors.Where(d => d.DepartmentId == deptId).ToList();

                cbDoctor.DataSource = filteredDoctors;
                cbDoctor.DisplayMember = "FullName";
                cbDoctor.ValueMember = "Id";
                cbDoctor.SelectedIndex = -1;
            }
        }

        private void InitDayPicker()
        {
            string[] days = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            flpDaySelection.Controls.Clear();
            foreach (var day in days)
            {
                CheckBox chk = new CheckBox();
                chk.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                chk.Text = day;
                chk.Appearance = Appearance.Button;
                chk.Size = new Size(110, 80);
                chk.TextAlign = ContentAlignment.MiddleCenter;
                chk.FlatStyle = FlatStyle.Flat;
                chk.FlatAppearance.BorderSize = 2; // Nâng lên 2px cho sắc nét
                chk.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
                UIHelper.ApplyRoundedRegion(chk, 8); // Chuẩn 8px
                chk.Cursor = Cursors.Hand;
                chk.BackColor = Color.White;
                chk.ForeColor = Color.FromArgb(100, 116, 139);

                chk.CheckedChanged += (s, e) =>
                {
                    if (chk.Checked)
                    {
                        chk.BackColor = Color.FromArgb(37, 99, 235); // Xanh chuẩn highlight
                        chk.ForeColor = Color.White;
                        chk.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
                    }
                    else
                    {
                        chk.BackColor = Color.White;
                        chk.ForeColor = Color.FromArgb(100, 116, 139);
                        chk.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
                    }
                };
                flpDaySelection.Controls.Add(chk);
            }
        }

        private void cbRepeat_CheckedChanged(object sender, EventArgs e)
        {
            bool isRepeat = cbRepeat.Checked;
            pnlRepeatRange.Visible = isRepeat;
            lblDate.Visible = !isRepeat;
            pnlDateBorder.Visible = !isRepeat;

            // Adjust height if needed, but the current Size 1280 should be enough
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (cbDept.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn khoa!", "Thông báo"); return; }
            if (cbDoctor.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn bác sĩ!", "Thông báo"); return; }
            if (cbRoom.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn phòng khám!", "Thông báo"); return; }

            int doctorId = (int)cbDoctor.SelectedValue;
            int roomId = (int)cbRoom.SelectedValue;
            TimeSpan startTime = new TimeSpan(dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);
            TimeSpan endTime = new TimeSpan(dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);
            int maxApp = (int)numMax.Value;

            string result = "";

            if (_editSlotId > 0)
            {
                // Kiểm tra nếu có bệnh nhân đang chờ duyệt thì phải hỏi trước
                if (_timeSlotsBus.HasPendingAppointments(_editSlotId))
                {
                    var confirm = MessageBox.Show("Khung giờ này đang có bệnh nhân chờ duyệt. Nếu bạn cập nhật, các lịch hẹn này sẽ bị HỦY tự động. Bạn có chắc chắn muốn tiếp tục?", 
                        "Xác nhận thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.No) return;
                }

                TimeSlotsDTO updateSlot = new TimeSlotsDTO
                {
                    Id = _editSlotId,
                    DoctorId = doctorId,
                    RoomId = roomId,
                    WorkDate = dtpWorkDate.Value.Date,
                    StartTime = startTime,
                    EndTime = endTime,
                    MaxAppointments = maxApp
                };
                result = _timeSlotsBus.UpdateTimeSlot(updateSlot);
            }
            else if (cbRepeat.Checked)
            {
                List<string> selectedDays = GetCheckedDays();
                DateTime startDate = dtpStartDateRange.Value.Date;
                DateTime endDate = dtpEndDateRange.Value.Date;
                int adminId = GlobalAccount.GetProfileId();

                result = _timeSlotsBus.CreateBulkTimeSlots(doctorId, selectedDays, startDate, endDate, startTime, endTime, roomId, maxApp, adminId);
            }
            else
            {
                TimeSlotsDTO newSlot = new TimeSlotsDTO
                {
                    DoctorId = doctorId,
                    RoomId = roomId,
                    WorkDate = dtpWorkDate.Value.Date,
                    StartTime = startTime,
                    EndTime = endTime,
                    MaxAppointments = maxApp,
                    BookedCount = 0,
                    Status = "Open",
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedByAdminId = GlobalAccount.GetProfileId()
                };
                result = _timeSlotsBus.CreateSingleTimeSlot(newSlot);
            }

            if (result == "Success")
            {
                if (_editSlotId > 0)
                {
                    // Nếu là chỉnh sửa, đóng form và load lại ngay lập tức phía sau rồi mới hiện thông báo
                    OnCloseModal?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu là tạo mới, hiện thông báo trước rồi mới đóng form
                    MessageBox.Show("Tạo lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnCloseModal?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<string> GetCheckedDays()
        {
            List<string> days = new List<string>();
            foreach (Control ctrl in flpDaySelection.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    days.Add(chk.Text.Trim().ToUpper());
                }
            }
            return days;
        }

        private void btnCancel_Click(object sender, EventArgs e) => OnCloseModal?.Invoke(this, EventArgs.Empty);
    }
}
