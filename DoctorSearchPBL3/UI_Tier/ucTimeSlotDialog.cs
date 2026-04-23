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
        private readonly TimeSlotBUS _timeSlotsBus = new TimeSlotBUS();

        public ucTimeSlotDialog()
        {
            InitializeComponent();
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
            int currentDoctorId = GlobalAccount.GetCurrentId();
            if (currentDoctorId <= 0)
            {
                MessageBox.Show("Phiên đăng nhập hết hạn, vui lòng thử lại!", "Thông báo");
                return;
            }

            // LẤY GIỜ: Từ 2 ô chọn giờ phía trên
            TimeSpan startTime = new TimeSpan(dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, 0);
            TimeSpan endTime = new TimeSpan(dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, 0);

            if (endTime <= startTime)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn giờ bắt đầu!", "Thông báo");
                return;
            }

            string result = "";

            if (cbRepeat.Checked)
            {
                List<string> selectedDays = GetCheckedDays();
                if (selectedDays.Count == 0)
                {
                    MessageBox.Show("Hãy chọn ít nhất một thứ để lặp lại!", "Thông báo");
                    return;
                }

                // --- SỬA TẠI ĐÂY ---
                // Giả sử 2 ô ngày ở dưới của bạn tên là dtpRepeatStart và dtpRepeatEnd
                // Bạn hãy thay tên đúng với tên bạn đặt trong Designer nhé!
                DateTime startDay = dateTimePicker3.Value.Date;
                DateTime endDay = dateTimePicker4.Value.Date;

                result = _timeSlotsBus.CreateBulkTimeSlots(currentDoctorId, selectedDays, startDay, endDay, startTime, endTime);
            }
            else
            {
                result = _timeSlotsBus.CreateSingleTimeSlot(new TimeSlotsDTO
                {
                    DoctorId = currentDoctorId,
                    Date = dtpDOB.Value.Date,
                    StartTime = startTime,
                    EndTime = endTime,
                    Status = "Trống"
                });
            }

            // Hiển thị thông báo (giữ nguyên)
            if (result == "Success" || result.Contains("Thành công") || result.Contains("Đã tạo"))
            {
                MessageBox.Show(result == "Success" ? "Cài đặt khung giờ thành công!" : result, "Thành công");
                OnCloseModal?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show(result, "Thông báo");
            }
        }

        private List<string> GetCheckedDays()
        {
            List<string> days = new List<string>();
            foreach (Control ctrl in flpDay.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    // Thêm .Trim() để chắc chắn không có khoảng trắng thừa
                    days.Add(chk.Text.Trim().ToUpper());
                }
            }
            return days;
        }

        private void cbRepeat_CheckedChanged(object sender, EventArgs e)
        {
            bool isRepeat = cbRepeat.Checked;

            // 1. Hiển thị panel lặp lại (Chứa Từ ngày... Đến ngày... của riêng nó)
            pnlRepeat.Visible = isRepeat;

            // 2. Ẩn hoặc Vô hiệu hóa cái "Ngày" đơn lẻ bên trên để tránh lấy nhầm
            // Giả sử cái Label và DateTimePicker ngày đơn lẻ của bạn tên là lblSingleDate và dtpDOB
            label10.Visible = !isRepeat;
            dtpDOB.Visible = !isRepeat;
        }
    }
}
