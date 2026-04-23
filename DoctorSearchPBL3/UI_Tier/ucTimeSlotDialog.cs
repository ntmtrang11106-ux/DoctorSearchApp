using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucTimeSlotDialog : UserControl
    {
        // Khởi tạo tầng BUS để xử lý nghiệp vụ
        private readonly TimeSlotBUS _timeSlotBus = new TimeSlotBUS();
        // Biến cục bộ để lưu ID bác sĩ được truyền vào
        private int _currentDoctorId;

        public ucTimeSlotDialog()
        {
            InitializeComponent();
            //this._currentDoctorId = doctorId; // Lưu ID vào đây để dùng cho nút Confirm
        }

        private Color _activeBack = Color.FromArgb(206, 225, 255); // Màu xanh nhạt
        private Color _normalBack = Color.Transparent;
        private Color _activeText = Color.FromArgb(0, 98, 255); // Màu xanh đậm
        private Color _normalText = SystemColors.ControlDarkDark;

        public event EventHandler OnCloseModal;
        private void InitDayPicker()
        {
            // Dùng list để dễ quản lý hoặc lấy từ DB
            string[] days = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            flpDay.Controls.Clear();
            foreach (var day in days)
            {
                CheckBox chk = new CheckBox();
                chk.Font= new Font("Segoe UI", 12);
                chk.Text = day;
                chk.Appearance = Appearance.Button; // Biến CheckBox thành nút bấm
                chk.Size = new Size(100, 100);         // Nút vuông
                chk.TextAlign = ContentAlignment.MiddleCenter;
                chk.FlatStyle = FlatStyle.Flat;
                chk.FlatAppearance.BorderSize = 0;   // Bỏ viền mặc định cho hiện đại
                UIHelper.ApplyRoundedRegion(chk, 20); // Bo tròn nút
                chk.Cursor = Cursors.Hand;

                // Màu sắc mặc định (Chưa chọn)
                chk.BackColor = _normalBack;
                chk.ForeColor = _normalText;

                // Xử lý logic đổi màu khi Click
                chk.CheckedChanged += (s, e) =>
                {
                    if (chk.Checked)
                    {
                        chk.BackColor = _activeBack;
                        chk.ForeColor = _activeText;
                    }
                    else
                    {
                        chk.BackColor = _normalBack;
                        chk.ForeColor = _normalText;
                    }
                };

                // Trick để bo tròn nút (Hệ System Dev)
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, chk.Width, chk.Height);
                chk.Region = new Region(path);

                flpDay.Controls.Add(chk);
            }
        }

        private void ucTimeSlotCheckbox_Load(object sender, EventArgs e)
        {
            UIHelper.SetDoubleBuffered(this);
            UIHelper.ApplyRoundedRegion(this, 10);
            UIHelper.ApplyRoundedRegion(btnConfirm, 10);
            this.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 10, Color.Gray, 2);
            pnlRepeat.Visible = false; // Ẩn phần chọn ngày ban đầu
            InitDayPicker();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 2. Khi bấm nút Cancel, bắn tín hiệu báo cho Form cha biết
            OnCloseModal?.Invoke(this, EventArgs.Empty);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Xử lý lưu database các kiểu ở đây...

            // Sau khi lưu xong, cũng bắn tín hiệu để đóng
            OnCloseModal?.Invoke(this, EventArgs.Empty);

            // --- 1. LẤY ID BÁC SĨ ĐỘNG (NGHIỆP VỤ UI) ---
            // Bây giờ biến _currentDoctorId đã tồn tại và có giá trị
            int doctorIdToSave = this._currentDoctorId;

            // --- 2. KIỂM TRA HÌNH THỨC (VALIDATION) ---
            // Kiểm tra giờ bắt đầu và kết thúc
            TimeSpan startTime = dateTimePicker1.Value.TimeOfDay;
            TimeSpan endTime = dateTimePicker2.Value.TimeOfDay;

            if (startTime >= endTime)
            {
                MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc!", "Thông báo");
                return;
            }

            bool isSuccess = false;

            // --- 3. ĐIỀU HƯỚNG NGHIỆP VỤ SANG TẦNG BUS ---
            if (cbRepeat.Checked)
            {
                // Nghiệp vụ UI: Thu thập các thứ (T2, T3...) được chọn từ flowLayoutPanel
                List<string> selectedDays = new List<string>();
                foreach (Control ctrl in flpDay.Controls)
                {
                    if (ctrl is CheckBox chk && chk.Checked)
                    {
                        selectedDays.Add(chk.Text);
                    }
                }

                if (selectedDays.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thứ để lặp lại!");
                    return;
                }

                // Lấy khoảng ngày lặp lại từ 2 cái DateTimePicker trong pnlRepeat
                DateTime startDate = dateTimePicker1.Value.Date;
                DateTime endDate = dateTimePicker2.Value.Date;

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu lặp lại không được lớn hơn ngày kết thúc!");
                    return;
                }

                // BƯỚC 3: Truyền doctorIdToSave vào hàm BUS
                isSuccess = _timeSlotBus.CreateBulkTimeSlots(
                    doctorIdToSave,
                    selectedDays,
                    dateTimePicker1.Value.Date,
                    dateTimePicker2.Value.Date,
                    startTime,
                    endTime
                );
            }
            else
            {
                TimeSlotsDTO singleSlot = new TimeSlotsDTO
                {
                    DoctorId = doctorIdToSave,
                    Date = dtpDOB.Value.Date,
                    StartTime = startTime,
                    EndTime = endTime,
                    Status = "Trống"
                };
                isSuccess = _timeSlotBus.CreateSingleTimeSlot(singleSlot);
            }

            // --- 4. PHẢN HỒI VÀ KẾT THÚC ---
            if (isSuccess)
            {
                MessageBox.Show("Đã tạo khung giờ khám thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu thành công mới bắn tín hiệu để Form cha đóng Overlay và Refresh data
                OnCloseModal?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Tạo thất bại. Khung giờ này có thể đã tồn tại hoặc bị trùng lịch bác sĩ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbRepeat_CheckedChanged(object sender, EventArgs e)
        {
            // Hiển thị hoặc ẩn phần chọn ngày tùy theo trạng thái của checkbox
            pnlRepeat.Visible = cbRepeat.Checked;
        }
    }
}
