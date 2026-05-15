using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucAppItem : UserControl
    {
        private int _appointmentId; // Lưu ID để dùng khi bấm nút
        private int _timeslotId; // Lưu ID để dùng khi bấm nút

        public delegate void OnActionSuccess();
        public OnActionSuccess RefreshData;

        public event EventHandler AppointmentDeleted;
        public event EventHandler<AppointmentsDTO> AppointmentEdited;
        public event EventHandler<int> AdminTimeSlotEdited;

        private AppCardMode _currentMode;
        private AppointmentsDTO _currentAppData;
        private TimeSlotsDTO _currentTimeSlot;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowDoctorInfo { get; set; } = true;

        // Enum để xác định chế độ hiển thị của card, giúp tái sử dụng cho nhiều mục đích khác nhau
        public enum AppCardMode
        {
            PatientView,    // Bệnh nhân xem lịch của mình (Chỉ xem)
            DoctorView,     // Bác sĩ duyệt lịch (Hiện nút Accept/Cancel)
            DoctorSchedule, // Bệnh nhân xem khung giờ trống của bác sĩ (Hiện nút Book/Đặt lịch)
            HistoryView,     // Xem lại lịch cũ (Hiện nút Rate/Đánh giá)
            AdminView       // Admin xem tất cả (Hiện thông tin cả bác sĩ và bệnh nhân)
        }

        public ucAppItem()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }

        // Phương thức để cập nhật giao diện của nút trạng thái dựa trên giá trị status
        private void UpdateStatusStyle(string status)
        {
            switch (status)
            {
                case "Open": // Trống
                    btnStatus.Text = "Trống";
                    btnStatus.BackColor = Color.LightGray;
                    btnStatus.ForeColor = Color.DarkGray;
                    break;
                case "Pending": // Chờ duyệt
                    btnStatus.Text = "Chờ duyệt";
                    btnStatus.BackColor = Color.FromArgb(255, 193, 7); // Vàng Warning
                    btnStatus.ForeColor = Color.Black;
                    break;
                case "Confirmed": // Đã duyệt
                    btnStatus.Text = "Đã duyệt";
                    btnStatus.BackColor = Color.FromArgb(40, 167, 69); // Xanh Success
                    btnStatus.ForeColor = Color.White;
                    break;
                case "Cancelled": // Đã hủy
                    btnStatus.Text = "Đã hủy";
                    btnStatus.BackColor = Color.FromArgb(220, 53, 69); // Đỏ Danger
                    btnStatus.ForeColor = Color.White;
                    break;
                case "Completed": // Thành công
                    btnStatus.Text = "Thành công";
                    btnStatus.BackColor = Color.FromArgb(23, 162, 184); // Xanh Info
                    btnStatus.ForeColor = Color.White;
                    break;
            }
        }

        // Thiết lập hiển thị nút dựa trên chế độ và trạng thái
        private void SetupButtons(AppCardMode mode, string status)
        {
            // Dọn dẹp các nút trước khi hiện cái cần thiết
            foreach (Button btn in new Button[] { btnAccept, btnCancel, btnRemove, btnBook, btnRate, btnViewRecord, btnEdit, btnHide })
            {
                btn.Visible = false;
            }
            // 2. Logic cho Bệnh nhân & Bác sĩ (Giao diện đơn giản)
            if (mode == AppCardMode.PatientView || mode == AppCardMode.HistoryView || mode == AppCardMode.DoctorView)
            {
                btnStatus.Visible = true; // Luôn hiện trạng thái cho bệnh nhân
                lblAdminInfo.Visible = false;
                lblAdminRoomIcon.Visible = false;
                flpAdminNames.Visible = false;
                //lblAdminDate.Visible = false;
                //lblAdminTime.Visible = false;
                //lblAdminClockIcon.Visible = false;
                btnAdminStatus.Visible = false;
                lblAdminPhone.Visible = false;
                flpAdminPhones.Visible = false;
                lblAdminArrowPhone.Visible = false;
                lblAdminPatientPhone.Visible = false;
                lblAdminDoctorPhone.Visible = false;
                
                // Đảm bảo hiện lại các control mặc định của bệnh nhân
                lblName.Visible = true;
                lblPhoneNumber.Visible = true;

                if (status == "Pending")
                {
                    // Nút Sửa chỉ hiện cho Bệnh nhân, Bác sĩ không được sửa lịch của BN
                    btnEdit.Visible = (mode != AppCardMode.DoctorView); 
                    btnRemove.Visible = true;
                }
                else if (status == "Confirmed")
                {
                    btnEdit.Visible = false;
                    btnRemove.Visible = false;
                }
                else if (status == "Completed" || status == "Cancelled")
                {
                    btnEdit.Visible = false;
                    btnRemove.Visible = true; // Cho phép xóa khỏi danh sách hiển thị

                    if (status == "Completed")
                    {
                        btnViewRecord.Visible = true;
                    }
                }
            }

            // 3. Logic cho Bác sĩ (DoctorView)
            if (mode == AppCardMode.DoctorView)
            {
                if (status == "Pending")
                {
                    btnAccept.Visible = true;
                    btnCancel.Visible = true;
                }
                else if (status == "Confirmed")
                {
                    // Đã duyệt -> Không hiện nút nào
                }
                else if (status == "Cancelled")
                {
                    btnRemove.Visible = true; // Hiện nút Xóa
                }
                else if (status == "Completed")
                {
                    btnRemove.Visible = true;    // Hiện nút Xóa
                    btnViewRecord.Visible = true; // Hiện nút Xem bệnh án
                }
            }

            // 5. Logic cho Admin (AdminView)
            if (mode == AppCardMode.AdminView)
            {
                btnRemove.Visible = true; // Admin có quyền xóa bất kỳ lịch nào (hoặc đánh dấu hủy)
                if (status == "Pending")
                {
                    btnAccept.Visible = true;
                    btnCancel.Visible = true;
                }
                if (status == "Completed")
                {
                    btnViewRecord.Visible = true;
                }
            }

            // 4. Logic cho Đặt lịch (DoctorSchedule)
            if (mode == AppCardMode.DoctorSchedule)
            {
                btnBook.Visible = (status == "Open");
            }

            // 5. Logic cho Admin (AdminView)
            if (mode == AppCardMode.AdminView)
            {
                btnEdit.Visible = true;
                btnRemove.Visible = true;
                btnAdminStatus.Visible = true;

                // Nút Ẩn/Hiện đồng bộ phong cách Review (Sử dụng btnHide làm nút Toggle)
                btnHide.Visible = true;
                btnHide.Text = (status == "Hidden") ? "\uED1A" : "\uE890"; 
                ttAction.SetToolTip(btnHide, (status == "Hidden") ? "Hiện lịch hẹn" : "Ẩn lịch hẹn");
                
                // Nút Show cũ không cần nữa

                // Các nút khác luôn ẩn cho Admin
                btnAccept.Visible = false;
                btnCancel.Visible = false;
                btnBook.Visible = false;
                btnRate.Visible = false;
                btnViewRecord.Visible = false;
                // btnStatus.Visible should be controlled by the data-binding logic, not forced here
            }
        }

        // Thiết lập dữ liệu cho card dựa trên AppointmentsDTO và chế độ hiển thị
        public void SetupCard(AppointmentsDTO data, AppCardMode mode)
        {
            _currentMode = mode;
            _currentAppData = data;
            _appointmentId = data.Id;

            // 1. Phân biệt hiển thị Tên
            if (mode == AppCardMode.PatientView || mode == AppCardMode.HistoryView)
            {
                string position = data.Doctor?.Position ?? "BS.";
                string fullName = data.Doctor?.User?.FullName ?? "N/A";

                // Tránh lặp "BS. BS."
                if (!string.IsNullOrEmpty(position) && fullName.StartsWith(position, StringComparison.OrdinalIgnoreCase))
                {
                    lblName.Text = fullName;
                }
                else
                {
                    lblName.Text = $"{position} {fullName}".Trim();
                }

                lblPhoneNumber.Text = data.Doctor?.User?.PhoneNumber ?? "N/A";
                lblPhoneNumber.Visible = true;
                flpAdminPhones.Visible = false;
            }
            else if (mode == AppCardMode.AdminView)
            {
                // Ẩn các control mặc định
                lblName.Visible = false;
                lblPhoneNumber.Visible = false;

                // Hiện các control Admin mới
                lblAdminClockIcon.Visible = true;
                //lblAdminDate.Visible = true;
                //lblAdminTime.Visible = true;
                flpAdminNames.Visible = true;
                lblAdminPhone.Visible = true;
                btnAdminStatus.Visible = true;
                lblDep.Visible = true;

                string pName = data.Patient?.User?.FullName ?? "N/A";
                string dName = data.Doctor?.User?.FullName ?? "N/A";
                lblAdminPatient.Text = pName;
                lblAdminDoctor.Text = dName;

                string pPhone = data.Patient?.User?.PhoneNumber ?? "N/A";
                string dPhone = data.Doctor?.User?.PhoneNumber ?? "N/A";
                lblAdminPatientPhone.Text = pPhone;
                lblAdminDoctorPhone.Text = dPhone;
                flpAdminPhones.Visible = true;
                lblAdminArrowPhone.Visible = true;

                lblDep.Text = data.Doctor?.Department?.DepartmentName ?? "Chưa cập nhật";

                // Status Badge for Appointment - Show Room Capacity as requested
                if (data.TimeSlot != null)
                {
                    if (data.TimeSlot.Status == "Hidden")
                    {
                        btnAdminStatus.Text = "Đã ẩn";
                        btnAdminStatus.BackColor = Color.FromArgb(108, 117, 125); // Gray/Muted
                    }
                    else if (data.TimeSlot.BookedCount >= data.TimeSlot.MaxAppointments)
                    {
                        btnAdminStatus.Text = "Đầy";
                        btnAdminStatus.BackColor = Color.FromArgb(220, 53, 69); // Red
                    }
                    else
                    {
                        btnAdminStatus.Text = "Còn trống";
                        btnAdminStatus.BackColor = Color.FromArgb(40, 167, 69); // Green
                    }
                }
                else
                {
                    btnAdminStatus.Text = "N/A";
                    btnAdminStatus.BackColor = Color.Gray;
                }

                UIHelper.ApplyRoundedRegion(btnAdminStatus, 6);

                if (data.TimeSlot != null)
                {
                    //lblAdminDate.Text = data.TimeSlot.WorkDate.ToString("dd/MM/yyyy");
                    //lblAdminTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";

                    lblAdminRoomIcon.Visible = true;
                    lblAdminInfo.Visible = true;
                    lblAdminInfo.Text = $"Phòng: {data.TimeSlot.Room?.RoomCode ?? "N/A"}\nSố lượng: {data.TimeSlot.BookedCount}/{data.TimeSlot.MaxAppointments}";
                    lblAdminRoomIcon.Text = "🏠";
                }
            }
            else
            {
                lblName.Text = data.Patient?.User?.FullName ?? "Bệnh nhân chưa đặt";
                lblPhoneNumber.Text = data.Patient?.User?.PhoneNumber ?? "0000000000";

                // Luôn ẩn các control Admin ở chế độ non-admin
                flpAdminNames.Visible = false;
                //lblAdminClockIcon.Visible = false;
                //lblAdminDate.Visible = false;
                //lblAdminTime.Visible = false;
                flpAdminPhones.Visible = false;
                lblAdminRoomIcon.Visible = false;
                lblAdminInfo.Visible = false;
                btnAdminStatus.Visible = false;
            }

            // Reason/Symptoms
            bool showSymptoms = (mode != AppCardMode.AdminView); // Admin has high density view, maybe hide symptoms or show differently
            label2.Visible = lblSymptoms.Visible = showSymptoms;
            lblSymptoms.Text = data.Reason ?? "N/A";

            // 2. Load giờ giấc (Dùng chung)
            if (data.TimeSlot != null)
            {
                lblDate.Text = data.TimeSlot.WorkDate.ToString("dd/MM/yyyy");
                lblTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";
            }

            // 3. Dịch trạng thái sang tiếng Việt và đổi màu
            if (mode == AppCardMode.DoctorSchedule)
            {
                btnStatus.Visible = false;
                lblName.Visible = lblPhoneNumber.Visible = label2.Visible = lblSymptoms.Visible = false;
            }
            else
            {
                UpdateStatusStyle(data.Status);
            }

            // Mặc định ẩn lblDep nếu không phải Admin hoặc các view cần thiết
            if (mode != AppCardMode.AdminView) lblDep.Visible = false;


            // 4. PHÂN CHIA NÚT BẤM (QUAN TRỌNG NHẤT)
            SetupButtons(mode, data.Status);

            // 5. Định vị btnStatus và btnAdminStatus ở góc phải/giữa (Căn giữa theo chiều dọc)
            if (btnStatus.Visible) {
                btnStatus.Location = new Point(this.Width - btnStatus.Width - 50, (this.Height - btnStatus.Height) / 2);
            }
            if (btnAdminStatus.Visible) {
                btnAdminStatus.Location = new Point(btnAdminStatus.Location.X, (this.Height - btnAdminStatus.Height) / 2);
            }

            // 5. Điều chỉnh vị trí Status và Action dựa trên ngữ cảnh hiển thị
            if (!ShowDoctorInfo)
            {
                // TRƯỜNG HỢP: Trong Profile bác sĩ (Tối giản)
                lblName.Visible = false;
                lblPhoneNumber.Visible = false;
                label2.Visible = false;
                lblSymptoms.Visible = false;
                flpAction.Visible = false; // Ẩn nút thao tác

                // Đưa Status ra giữa
                if (flpAction.Controls.Contains(btnStatus)) flpAction.Controls.Remove(btnStatus);
                if (!this.Controls.Contains(btnStatus)) this.Controls.Add(btnStatus);

                btnStatus.Visible = true;
                btnStatus.BringToFront();

                // Căn giữa nhãn trạng thái theo chiều ngang và dọc của card
                btnStatus.Location = new Point(
                    (this.Width - btnStatus.Width) / 2,
                    (this.Height - btnStatus.Height) / 2
                );
            }

        }

        // Thiết lập dữ liệu cho card dựa trên TimeSlotsDTO và chế độ hiển thị (Dành cho DoctorSchedule hoặc AdminView)
        public void SetupCard(TimeSlotsDTO data, AppCardMode mode)
        {
            _currentMode = mode;
            if (mode == AppCardMode.AdminView)
            {
                SetupAdminRow(data);
                return;
            }

            if (mode != AppCardMode.DoctorSchedule) return;
            _appointmentId = data.Id;

            label2.Visible = lblSymptoms.Visible = (data.Status != "Open");

            lblDate.Text = data.WorkDate.ToString("dd/MM/yyyy");
            lblTime.Text = $"{data.StartTime:hh\\:mm} - {data.EndTime:hh\\:mm}";

            btnStatus.Visible = false;
            lblName.Visible = lblPhoneNumber.Visible = label2.Visible = lblSymptoms.Visible = false;

            SetupButtons(mode, data.Status);
        }

        private void SetupAdminRow(TimeSlotsDTO data)
        {
            _timeslotId = data.Id;
            _currentTimeSlot = data;
            _currentAppData = null;

            // 1. Ẩn tất cả các control mặc định của Bệnh nhân
            label1.Visible = false;
            lblDate.Visible = false;
            lblTime.Visible = false;
            lblPhoneNumber.Visible = false;
            lblName.Visible = false;
            label2.Visible = false;
            lblSymptoms.Visible = false;
            btnStatus.Visible = false;
            lblDep.Visible = true;

            // 2. Hiện các control đã "vẽ thêm" cho Admin trong Designer
            label1.Visible = true;
            lblDate.Visible = true;
            lblTime.Visible = true;
            flpAdminNames.Visible = true;
            flpAdminPhones.Visible = true;
            lblAdminPhone.Visible = false;
            lblArrow.Visible = false;
            lblAdminRoomIcon.Visible = true;
            lblAdminInfo.Visible = true;
            btnAdminStatus.Visible = true;

            // 3. Đổ dữ liệu vào các control Admin
            lblDate.Text = data.WorkDate.ToString("dd/MM/yyyy");
            lblTime.Text = $"{data.StartTime:hh\\:mm} - {data.EndTime:hh\\:mm}";

            // Xử lý thông tin Bác sĩ (Trái) -> Bệnh nhân (Phải) theo yêu cầu mới
            lblAdminPatient.Text = data.Doctor?.User?.FullName ?? "N/A"; 
            
            var firstApp = data.Appointments?
                .OrderBy(a => a.Status == "Pending" ? 0 : 
                             a.Status == "Confirmed" ? 1 : 
                             a.Status == "Completed" ? 2 : 3)
                .FirstOrDefault();

            if (firstApp != null)
            {
                lblAdminDoctor.Text = firstApp.Patient?.User?.FullName ?? "Bệnh nhân";
                if (data.BookedCount > 1) lblAdminDoctor.Text += $" (+{data.BookedCount - 1})";

                lblAdminPatientPhone.Text = data.Doctor?.User?.PhoneNumber ?? "N/A";
                lblAdminDoctorPhone.Text = firstApp.Patient?.User?.PhoneNumber ?? "N/A";
                
                lblAdminArrowPhone.Visible = true;
                lblAdminDoctorPhone.Visible = true;
                lblArrow.Visible = true;
            }
            else
            {
                lblAdminDoctor.Text = "Chưa có BN";
                lblAdminPatientPhone.Text = data.Doctor?.User?.PhoneNumber ?? "N/A";
                lblAdminArrowPhone.Visible = false;
                lblAdminDoctorPhone.Visible = false;
                lblArrow.Visible = true;
            }

            // Căn chỉnh SĐT BS lệch qua trái để nằm dưới tên BS
            lblAdminPatientPhone.Margin = new Padding(-5, 0, 0, 0); 
            
            lblAdminPatient.Visible = true;
            lblAdminDoctor.Visible = true;
            lblAdminPatientPhone.Visible = true;
            
            flpAdminNames.Visible = true;
            flpAdminPhones.Visible = true;

            lblDep.Text = data.Doctor?.Department?.DepartmentName ?? "Chưa cập nhật";
            UIHelper.ApplyRoundedRegion(lblDep, 8);

            lblAdminInfo.Text = $"Phòng: {data.Room?.RoomCode ?? "N/A"}\nSố lượng: {data.BookedCount}/{data.MaxAppointments}";
            lblAdminRoomIcon.Text = "🏠";

            // 4. Logic cho btnAdminStatus (Ở giữa) - Hiện trạng thái Slot (Trống/Đầy/Ẩn/Xóa)
            if (data.IsDeleted)
            {
                btnAdminStatus.Text = "Đã xóa";
                btnAdminStatus.BackColor = Color.FromArgb(108, 117, 125); // Xám đậm
                btnAdminStatus.ForeColor = Color.White;
            }
            else if (data.Status == "Hidden")
            {
                btnAdminStatus.Text = "Đã ẩn";
                btnAdminStatus.BackColor = Color.FromArgb(108, 117, 125); // Xám đậm (như đã xóa)
                btnAdminStatus.ForeColor = Color.White;
            }
            else if (data.BookedCount >= data.MaxAppointments)
            {
                btnAdminStatus.Text = "Đầy";
                btnAdminStatus.BackColor = Color.FromArgb(220, 53, 69);
                btnAdminStatus.ForeColor = Color.White;
            }
            else
            {
                btnAdminStatus.Text = "Còn trống";
                btnAdminStatus.BackColor = Color.FromArgb(40, 167, 69);
                btnAdminStatus.ForeColor = Color.White;
            }

            // 5. Logic cho btnStatus (Bên phải) - Hiện trạng thái của cuộc hẹn
            if (firstApp != null)
            {
                btnStatus.Visible = true;
                UpdateStatusStyle(firstApp.Status);
            }
            else
            {
                btnStatus.Visible = false; // QUAN TRỌNG: Ẩn nếu không có bệnh nhân
            }

            // 6. Thao tác
            flpAction.Visible = true;
            SetupButtons(AppCardMode.AdminView, data.Status);

            UIHelper.ApplyRoundedRegion(btnAdminStatus, 30);
            UIHelper.ApplyRoundedRegion(btnEdit, 10);
            UIHelper.ApplyRoundedRegion(btnRemove, 10);

            // Định vị các nút trạng thái ở góc phải cho AdminView (Căn giữa dọc)
            if (btnStatus.Visible) {
                btnStatus.Location = new Point(this.Width - btnStatus.Width - 50, (this.Height - btnStatus.Height) / 2);
            }
            if (btnAdminStatus.Visible) {
                btnAdminStatus.Location = new Point(btnAdminStatus.Location.X, (this.Height - btnAdminStatus.Height) / 2);
            }
        }
        private void ucAppItem_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(btnStatus, 10);
            UIHelper.ApplyRoundedRegion(btnAccept, 40);
            UIHelper.ApplyRoundedRegion(btnCancel, 40);
            UIHelper.ApplyRoundedRegion(btnRemove, 40);
            UIHelper.ApplyRoundedRegion(btnEdit, 40);
            UIHelper.ApplyRoundedRegion(btnBook, 40);
            UIHelper.ApplyRoundedRegion(btnRate, 40);
            UIHelper.ApplyRoundedRegion(btnHide, 40);
            UIHelper.ApplyRoundedRegion(btnShow, 40);

            this.Paint += (sender, e) =>
            {
                UIHelper.uc_Paint(this, e, 40, Color.LightGray, 3);
            };
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chấp nhận lịch này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.AcceptAppointment(_appointmentId))
                {
                    // Cập nhật giao diện sang trạng thái mới (Tiếng Việt)
                    btnStatus.Text = "Đã xác nhận";
                    btnStatus.BackColor = Color.FromArgb(200, 255, 200);
                    btnStatus.ForeColor = Color.Green;

                    btnAccept.Visible = false;
                    btnCancel.Visible = false;

                    MessageBox.Show("Thành công!");
                    RefreshData?.Invoke();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Từ chối lịch hẹn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.RejectAppointment(_appointmentId))
                {
                    btnStatus.Text = "Đã hủy";
                    btnStatus.BackColor = Color.FromArgb(255, 200, 200);
                    btnStatus.ForeColor = Color.Red;

                    btnAccept.Visible = false;
                    btnCancel.Visible = false;

                    MessageBox.Show("Đã hủy lịch hẹn thành công!");
                    RefreshData?.Invoke();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Case 1: Admin đang ở chế độ Quản lý lịch hẹn (AdminView)
            if (_currentMode == AppCardMode.AdminView && _currentTimeSlot != null)
            {
                // Kiểm tra xem có ai đã ĐƯỢC DUYỆT (Confirmed) chưa
                if (_currentTimeSlot.Appointments != null && _currentTimeSlot.Appointments.Any(a => a.Status == "Confirmed"))
                {
                    MessageBox.Show("Không thể xóa lịch đã có bệnh nhân được duyệt khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem có ai đang CHỜ DUYỆT (Pending) không
                bool hasPending = _currentTimeSlot.Appointments != null && _currentTimeSlot.Appointments.Any(a => a.Status == "Pending");
                string confirmMsg = hasPending 
                    ? "Lịch này đang có bệnh nhân CHỜ DUYỆT. Nếu xóa, lịch của họ sẽ bị hủy. Bạn có chắc chắn muốn xóa không?" 
                    : "Bạn có chắc chắn muốn xóa lịch làm việc này không?";

                if (MessageBox.Show(confirmMsg, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TimeSlotBUS bus = new TimeSlotBUS();
                    if (bus.DeleteTimeSlot(_timeslotId))
                    {
                        MessageBox.Show("Đã xóa lịch thành công!");
                        RefreshData?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại. Vui lòng thử lại.");
                    }
                }
                return;
            }

            // Case 2: Xóa/Hủy Appointment lẻ (Patient/Doctor/History View)
            string appConfirmMsg = "Bạn có chắc chắn muốn hủy lịch hẹn này không?";
            if (MessageBox.Show(appConfirmMsg, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.DeleteAppointment(_appointmentId))
                {
                    MessageBox.Show("Đã hủy lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppointmentDeleted?.Invoke(this, EventArgs.Empty);
                    RefreshData?.Invoke();
                }
                else
                {
                    MessageBox.Show("Hủy lịch hẹn thất bại. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_currentMode == AppCardMode.AdminView && _timeslotId > 0)
            {
                AdminTimeSlotEdited?.Invoke(this, _timeslotId);
            }
            else if (_currentAppData != null)
            {
                AppointmentEdited?.Invoke(this, _currentAppData);
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (_timeslotId > 0)
            {
                TimeSlotBUS bus = new TimeSlotBUS();
                string result = bus.HideTimeSlot(_timeslotId);

                if (result == "Success")
                {
                    RefreshData?.Invoke();
                }
                else if (result == "ConfirmedExists")
                {
                    MessageBox.Show("Không thể ẩn lịch đã có bệnh nhân được duyệt khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (result == "PendingExists")
                {
                    if (MessageBox.Show("Lịch này đang có bệnh nhân CHỜ DUYỆT. Nếu ẩn, lịch của họ sẽ bị hủy. Bạn có chắc chắn muốn ẩn không?", 
                        "Xác nhận ẩn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (bus.ForceHideTimeSlot(_timeslotId))
                        {
                            RefreshData?.Invoke();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // Chuyển hướng sang btnHide_Click để dùng chung logic toggle
            btnHide_Click(sender, e);
        }

        private void lblAdminDate_Click(object sender, EventArgs e)
        {

        }
    }
}
