using DTO_Tier;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucAdminScheduleCard : UserControl
    {
        private TimeSlotsDTO? _currentTimeSlot;

        // --- CÁC SỰ KIỆN KÈM PAYLOAD ĐỂ BẮN NGƯỢC LÊN CHA ---
        public event EventHandler<TimeSlotsDTO>? TimeSlotEditClicked;
        public event EventHandler<TimeSlotsDTO>? TimeSlotRemoveClicked;
        public event EventHandler<TimeSlotsDTO>? TimeSlotHideClicked;

        public ucAdminScheduleCard()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }

        private void ucAdminScheduleCard_Load(object sender, EventArgs e)
        {
            // Thiết lập bo góc mặc định cho các nút bấm thông qua UIHelper
            UIHelper.ApplyRoundedRegion(btnStatus, 10);
            UIHelper.ApplyRoundedRegion(btnRemove, 40);
            UIHelper.ApplyRoundedRegion(btnEdit, 40);
            UIHelper.ApplyRoundedRegion(btnHide, 40);

            // Vẽ viền cho card
            this.Paint += (s, ev) =>
            {
                UIHelper.uc_Paint(this, ev, 40, Color.LightGray, 3);
            };
        }

        // --- CẬP NHẬT TRẠNG THÁI HIỂN THỊ BADGE ---
        private void UpdateStatusStyle(string status)
        {
            btnStatus.Visible = true;
            switch (status)
            {
                case "Open":
                    btnStatus.Text = "Trống";
                    btnStatus.BackColor = Color.LightGray;
                    btnStatus.ForeColor = Color.DarkGray;
                    break;
                case "Pending":
                    btnStatus.Text = "Chờ duyệt";
                    btnStatus.BackColor = Color.Ivory;
                    btnStatus.ForeColor = Color.Goldenrod;
                    break;
                case "Confirmed":
                    btnStatus.Text = "Đã duyệt";
                    btnStatus.BackColor = Color.Honeydew;
                    btnStatus.ForeColor = Color.Green;
                    break;
                case "Cancelled":
                    btnStatus.Text = "Đã hủy";
                    btnStatus.BackColor = Color.MistyRose;
                    btnStatus.ForeColor = Color.IndianRed;
                    break;
                case "Completed":
                    btnStatus.Text = "Thành công";
                    btnStatus.BackColor = Color.Azure;
                    btnStatus.ForeColor = Color.DodgerBlue;
                    break;
                default:
                    btnStatus.Visible = false;
                    break;
            }
        }

        // --- ĐỒNG BỘ HIỂN THỊ NÚT THAO TÁC THEO TRẠNG THÁI KHUNG GIỜ ---
        private void SetupButtons(string status)
        {
            // Admin View luôn hiện các nút quản lý này
            btnEdit.Visible = true;
            btnRemove.Visible = true;
            btnHide.Visible = true;

            // Đồng bộ hóa trạng thái nút Ẩn/Hiện bằng mã Unicode icon
            btnHide.Text = (status == "Hidden") ? "\uED1A" : "\uE890";
            ttAction.SetToolTip(btnHide, (status == "Hidden") ? "Hiện lịch làm việc" : "Ẩn lịch làm việc");
        }

        // --- THIẾT LẬP DỮ LIỆU HIỂN THỊ ---
        public void SetData(TimeSlotsDTO data)
        {
            _currentTimeSlot = data;

            // 1. Điền dữ liệu thời gian
            lblDate.Text = data.WorkDate.ToString("dd/MM/yyyy");
            lblTime.Text = $"{data.StartTime:hh\\:mm} - {data.EndTime:hh\\:mm}";

            // 2. Điền thông tin Chuyên khoa của Bác sĩ
            lblDep.Text = data.Doctor?.Department?.DepartmentName ?? "Chưa cập nhật";
            UIHelper.ApplyRoundedRegion(lblDep, 8);

            // 3. SỬA LỖI LOGIC: Điền thông tin Bác sĩ (Bên trái) | Bệnh nhân đầu tiên trong hàng chờ (Bên phải)
            // Bên trái: Bác sĩ
            lblAdminDoctor.Text = data.Doctor?.User?.FullName ?? "N/A";
            lblAdminDoctorPhone.Text = data.Doctor?.User?.PhoneNumber ?? "N/A";

            // Sắp xếp lấy cuộc hẹn đầu tiên của khung giờ này theo thứ tự ưu tiên trạng thái
            var firstApp = data.Appointments?
                .OrderBy(a => a.Status == "Pending" ? 0 : a.Status == "Confirmed" ? 1 : a.Status == "Completed" ? 2 : 3)
                .FirstOrDefault();

            if (firstApp != null)
            {
                // Bên phải: Bệnh nhân
                lblAdminPatient.Text = firstApp.Patient?.User?.FullName ?? "Bệnh nhân";
                if (data.BookedCount > 1) 
                    lblAdminPatient.Text += $" (+{data.BookedCount - 1})";
                lblAdminPatientPhone.Text = firstApp.Patient?.User?.PhoneNumber ?? "N/A";

                lblAdminArrowPhone.Visible = true;
                lblAdminPatientPhone.Visible = true;
                lblArrow.Visible = true;

                btnStatus.Visible = true;
                UpdateStatusStyle(firstApp.Status); // Hiện trạng thái xử lý của cuộc hẹn đầu tiên
            }
            else
            {
                lblAdminPatient.Text = "Chưa có BN";
                lblAdminPatientPhone.Text = "";
                lblAdminArrowPhone.Visible = false;
                lblAdminPatientPhone.Visible = false;
                lblArrow.Visible = false;
                btnStatus.Visible = false;
            }

            // 4. Điền thông tin hành chính phòng khám
            string statusText = data.IsDeleted 
                ? "Đã xóa" 
                : (data.Status == "Hidden" ? "Đã ẩn" : (data.BookedCount >= data.MaxAppointments ? "Đầy" : "Còn trống"));
            
            lblAdminInfo.Text = $"Phòng: {data.Room?.RoomCode ?? "N/A"}\n" +
                               $"Trạng thái: {statusText}\n" +
                               $"Số lượng: {data.BookedCount}/{data.MaxAppointments}";

            // Thiết lập hiển thị cho các nút
            SetupButtons(data.Status);
        }

        // --- BẮN SỰ KIỆN LÊN CHA KHI CLICK NÚT ---
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_currentTimeSlot != null) TimeSlotEditClicked?.Invoke(this, _currentTimeSlot);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_currentTimeSlot != null) TimeSlotRemoveClicked?.Invoke(this, _currentTimeSlot);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (_currentTimeSlot != null) TimeSlotHideClicked?.Invoke(this, _currentTimeSlot);
        }
    }
}
