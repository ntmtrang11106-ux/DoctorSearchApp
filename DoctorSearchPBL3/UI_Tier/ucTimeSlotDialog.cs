using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
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
        private bool _isBindingData = false;

        public ucTimeSlotDialog()
        {
            InitializeComponent();
        }

        public void SetupEditMode(TimeSlotsDTO data)
        {
            _editSlotId = data.Id;
            lblTitle.Text = "Chỉnh sửa lịch hẹn";
            btnCreate.Text = "CẬP NHẬT";
            cbRepeat.Visible = false;

            _isBindingData = true;
            LoadInitialData();

            dtpWorkDate.Value = data.WorkDate;
            dtpStartTime.Value = DateTime.Today.Add(data.StartTime);
            dtpEndTime.Value = DateTime.Today.Add(data.EndTime);
            numMax.Value = data.MaxAppointments;

            cbDept.SelectedValue = data.Doctor?.DepartmentId ?? 0;
            LoadDoctorsForDepartment(data.Doctor?.DepartmentId ?? 0, data.DoctorId);
            ReloadAvailableRooms(data.RoomId);
            _isBindingData = false;
        }

        private void ucTimeSlotCheckbox_Load(object sender, EventArgs e)
        {
            UIHelper.SetDoubleBuffered(this);
            UIHelper.ApplyRoundedRegion(this, 12);
            UIHelper.ApplyRoundedRegion(btnCreate, 8);
            UIHelper.ApplyRoundedRegion(btnCancel, 8);

            UIHelper.EnableNativeDrag(pnlHeader, this);
            UIHelper.EnableNativeDrag(lblTitle, this);

            this.Paint += (s, ev) =>
            {
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.Black, 3))
                {
                    var rect = new Rectangle(1, 1, this.Width - 4, this.Height - 4);
                    using (var path = UIHelper.GetRoundedPath(rect, 12))
                    {
                        ev.Graphics.DrawPath(p, path);
                    }
                }
            };

            UIHelper.RegisterClickToUnfocus(this, lblTitle);

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

            SetupRepeatInputsStyling(focusColor, unfocusColor, highlightColor);

            if (_editSlotId == 0)
            {
                LoadInitialData();
            }

            InitDayPicker();
            WireDynamicFilteringEvents();
        }

        private void WireDynamicFilteringEvents()
        {
            dtpWorkDate.ValueChanged += (s, e) => ReloadAvailableRooms();
            dtpStartTime.ValueChanged += (s, e) => ReloadAvailableRooms();
            dtpEndTime.ValueChanged += (s, e) => ReloadAvailableRooms();
        }

        private void SetupRepeatInputsStyling(Color focusColor, Color unfocusColor, Color highlightColor)
        {
            DateTimePicker[] datePickers = { dtpStartDateRange, dtpEndDateRange };
            foreach (var dtp in datePickers)
            {
                Panel pnl = new Panel
                {
                    Size = new Size(dtp.Width + 14, dtp.Height + 14),
                    Location = new Point(dtp.Left - 7, dtp.Top - 7),
                    BackColor = Color.White
                };
                dtp.Parent.Controls.Add(pnl);
                dtp.Parent = pnl;
                dtp.Dock = DockStyle.Fill;
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd/MM/yyyy";
                pnl.Padding = new Padding(12, 10, 12, 8);
                UIHelper.SetupInputFocusEffect(dtp, pnl, focusColor, unfocusColor, highlightColor);
            }
        }

        private void LoadInitialData()
        {
            _isBindingData = true;

            var depts = _deptBus.GetDepartmentsForUI();
            cbDept.DataSource = depts;
            cbDept.DisplayMember = "DepartmentName";
            cbDept.ValueMember = "Id";
            cbDept.SelectedIndex = -1;

            cbDoctor.DataSource = null;
            cbRoom.DataSource = null;

            _isBindingData = false;
        }

        private void LoadDoctorsForDepartment(int departmentId, int? preferredDoctorId = null)
        {
            var doctors = _doctorBus.GetListDoctors()
                .Where(d => d.DepartmentId == departmentId)
                .ToList();

            cbDoctor.DataSource = doctors;
            cbDoctor.DisplayMember = "FullName";
            cbDoctor.ValueMember = "Id";
            cbDoctor.SelectedIndex = -1;

            if (preferredDoctorId.HasValue && doctors.Any(d => d.Id == preferredDoctorId.Value))
            {
                cbDoctor.SelectedValue = preferredDoctorId.Value;
            }
        }

        private void ReloadAvailableRooms(int? preferredRoomId = null)
        {
            if (_isBindingData)
            {
                return;
            }

            if (!(cbDept.SelectedValue is int departmentId) || departmentId <= 0)
            {
                cbRoom.DataSource = null;
                return;
            }

            TimeSpan startTime = new TimeSpan(dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);
            TimeSpan endTime = new TimeSpan(dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);

            List<RoomDTO> rooms = endTime > startTime
                ? _roomBus.GetAvailableRoomsByDepartmentAndTime(departmentId, dtpWorkDate.Value.Date, startTime, endTime, _editSlotId > 0 ? _editSlotId : null)
                : _roomBus.GetRoomsByDepartment(departmentId);

            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "RoomCode";
            cbRoom.ValueMember = "Id";
            cbRoom.SelectedIndex = -1;

            if (preferredRoomId.HasValue && rooms.Any(r => r.Id == preferredRoomId.Value))
            {
                cbRoom.SelectedValue = preferredRoomId.Value;
            }
        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isBindingData)
            {
                return;
            }

            if (cbDept.SelectedValue is int deptId && deptId > 0)
            {
                LoadDoctorsForDepartment(deptId);
                ReloadAvailableRooms();
            }
            else
            {
                cbDoctor.DataSource = null;
                cbRoom.DataSource = null;
            }
        }

        private void InitDayPicker()
        {
            string[] days = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            flpDaySelection.Controls.Clear();
            foreach (var day in days)
            {
                CheckBox chk = new CheckBox
                {
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Text = day,
                    Appearance = Appearance.Button,
                    Size = new Size(110, 80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(100, 116, 139)
                };

                chk.FlatAppearance.BorderSize = 2;
                chk.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
                UIHelper.ApplyRoundedRegion(chk, 8);

                chk.CheckedChanged += (s, e) =>
                {
                    if (chk.Checked)
                    {
                        chk.BackColor = Color.FromArgb(37, 99, 235);
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
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cbDept.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn khoa!", "Thông báo"); return; }
            if (cbDoctor.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn bác sĩ!", "Thông báo"); return; }
            if (cbRoom.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn phòng khám!", "Thông báo"); return; }

            int adminId = GlobalAccount.GetProfileId();
            if (adminId <= 0)
            {
                MessageBox.Show("Không xác định được tài khoản admin hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int doctorId = (int)cbDoctor.SelectedValue;
            int roomId = (int)cbRoom.SelectedValue;
            TimeSpan startTime = new TimeSpan(dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);
            TimeSpan endTime = new TimeSpan(dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);
            int maxApp = (int)numMax.Value;

            string result;

            if (_editSlotId > 0)
            {
                if (_timeSlotsBus.HasPendingAppointments(_editSlotId))
                {
                    var confirm = MessageBox.Show(
                        "Khung giờ này đang có bệnh nhân chờ duyệt. Nếu cập nhật, các lịch chờ duyệt sẽ bị hủy tự động. Bạn có muốn tiếp tục không?",
                        "Xác nhận thay đổi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

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
                    MaxAppointments = maxApp,
                    CreatedByAdminId = adminId
                };
                result = _timeSlotsBus.UpdateTimeSlot(updateSlot, adminId);
            }
            else if (cbRepeat.Checked)
            {
                List<string> selectedDays = GetCheckedDays();
                DateTime startDate = dtpStartDateRange.Value.Date;
                DateTime endDate = dtpEndDateRange.Value.Date;
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
                    CreatedByAdminId = adminId
                };
                result = _timeSlotsBus.CreateSingleTimeSlot(newSlot, adminId);
            }

            if (result == "Success")
            {
                if (_editSlotId > 0)
                {
                    OnCloseModal?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
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
                    days.Add(chk.Text.Trim().ToUpperInvariant());
                }
            }
            return days;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCloseModal?.Invoke(this, EventArgs.Empty);
        }
    }
}
