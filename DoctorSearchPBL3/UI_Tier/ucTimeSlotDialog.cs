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

        public ucTimeSlotDialog()
        {
            InitializeComponent();
        }

        private void ucTimeSlotCheckbox_Load(object sender, EventArgs e)
        {
            UIHelper.SetDoubleBuffered(this);
            UIHelper.ApplyRoundedRegion(this, 12);
            UIHelper.ApplyRoundedRegion(btnCreate, 8);
            UIHelper.ApplyRoundedRegion(btnCancel, 8);

            this.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 12, Color.FromArgb(226, 232, 240), 1);

            LoadInitialData();
            InitDayPicker();
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
                chk.FlatAppearance.BorderSize = 1;
                chk.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
                UIHelper.ApplyRoundedRegion(chk, 10);
                chk.Cursor = Cursors.Hand;
                chk.BackColor = Color.White;
                chk.ForeColor = Color.FromArgb(100, 116, 139);

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
            dtpWorkDate.Visible = !isRepeat;

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
            TimeSpan startTime = dtpStartTime.Value.TimeOfDay;
            TimeSpan endTime = dtpEndTime.Value.TimeOfDay;
            int maxApp = (int)numMax.Value;

            string result = "";

            if (cbRepeat.Checked)
            {
                List<string> selectedDays = GetCheckedDays();
                DateTime startDate = dtpStartDateRange.Value.Date;
                DateTime endDate = dtpEndDateRange.Value.Date;

                result = _timeSlotsBus.CreateBulkTimeSlots(doctorId, selectedDays, startDate, endDate, startTime, endTime, roomId, maxApp);
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
                    CreatedAt = DateTime.Now
                };
                result = _timeSlotsBus.CreateSingleTimeSlot(newSlot);
            }

            if (result == "Success")
            {
                MessageBox.Show("Tạo lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnCloseModal?.Invoke(this, EventArgs.Empty);
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
