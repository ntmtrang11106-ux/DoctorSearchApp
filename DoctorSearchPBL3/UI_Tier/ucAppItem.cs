using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucAppItem : UserControl
    {
        private int _appointmentId;
        private int _timeslotId;

        public delegate void OnActionSuccess();
        public OnActionSuccess RefreshData;

        public event EventHandler AppointmentDeleted;
        public event EventHandler<AppointmentsDTO> AppointmentEdited;
        public event EventHandler<int> AdminTimeSlotEdited;
        public event EventHandler<int> OnViewPatientsClicked;

        private AppCardMode _currentMode;
        private AppointmentsDTO? _currentAppData;
        private TimeSlotsDTO? _currentTimeSlot;

        private string _searchKeyword = "";
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchKeyword
        {
            get => _searchKeyword;
            set
            {
                if (_searchKeyword != value)
                {
                    _searchKeyword = value;
                    lblAdminDoctor.Invalidate();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowDoctorInfo { get; set; } = true;

        public enum AppCardMode
        {
            PatientView,    // Bệnh nhân xem lịch của mình (Chỉ xem)
            DoctorView,     // Bác sĩ duyệt lịch (Hiện nút Accept/Cancel)
            DoctorSchedule, // Bệnh nhân xem khung giờ trống của bác sĩ (Hiện nút Book)
            HistoryView,    // Xem lại lịch cũ (Hiện nút Rate)
            AdminView       // Admin quản lý tổng hợp
        }

        public ucAppItem()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);

            btnViewPatients.Click += (s, e) => OnViewPatientsClicked?.Invoke(this, _timeslotId);
            
            // Thiết lập bo góc mặc định cho các nút bấm (moved from Load to prevent flicker)
            UIHelper.ApplyRoundedRegion(btnStatus, 10);
            UIHelper.ApplyRoundedRegion(btnAccept, 40);
            UIHelper.ApplyRoundedRegion(btnCancel, 40);
            UIHelper.ApplyRoundedRegion(btnRemove, 40);
            UIHelper.ApplyRoundedRegion(btnEdit, 40);
            UIHelper.ApplyRoundedRegion(btnBook, 40);
            UIHelper.ApplyRoundedRegion(btnRate, 40);
            UIHelper.ApplyRoundedRegion(btnHide, 40);
        }

        private void ucAppItem_Load(object sender, EventArgs e)
        {

            this.Paint += (s, ev) =>
            {
                UIHelper.uc_Paint(this, ev, 40, Color.LightGray, 3);
            };

            lblName.Paint += lblHighlight_Paint;
            lblAdminRoom.Paint += lblHighlight_Paint;
            lblAdminDoctor.Paint += lblHighlight_Paint;
        }

        private void lblHighlight_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Label lbl && !string.IsNullOrWhiteSpace(_searchKeyword))
            {
                UIHelper.DrawHighlightText(e.Graphics, lbl, lbl.Text, _searchKeyword, 
                    lbl.ForeColor, Color.FromArgb(206, 225, 255), Color.FromArgb(0, 98, 255));
            }
        }

        // --- CẬP NHẬT STYLE TRẠNG THÁI CUỘC HẸN ---
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

        // --- QUAN TRỌNG: ĐỒNG BỘ HIỂN THỊ NÚT THEO CHẾ ĐỘ ---
        private void SetupButtons(AppCardMode mode, string status)
        {
            // 1. Ẩn tất cả các nút để dọn dẹp mặt bằng
            foreach (Button btn in new Button[] { btnAccept, btnCancel, btnRemove, btnBook, btnRate, btnViewRecord, btnEdit, btnHide, btnComplete })
            {
                btn.Visible = false;
            }

            // 2. PHÂN NHÁNH LOGIC TUYỆT ĐỐI GIỮA ADMIN VÀ USER THƯỜNG
            if (mode == AppCardMode.AdminView)
            {
                btnEdit.Visible = true;
                // btnRemove và btnHide đã bị yêu cầu ẩn khỏi Admin View
                btnRemove.Visible = false;
                btnHide.Visible = false;

                // Admin View phân hệ quản lý cao độ không dùng các nút tương tác trực tiếp của User lẻ
                return;
            }

            // 3. LOGIC CHO KHÁCH HÀNG / BỆNH NHÂN / BÁC SĨ THƯỜNG

            switch (mode)
            {
                case AppCardMode.PatientView:
                case AppCardMode.HistoryView:
                    if (status == "Pending")
                    {
                        btnEdit.Visible = true;
                        btnRemove.Visible = true; // Hủy lịch hẹn
                    }
                    else if (status == "Completed")
                    {
                        btnViewRecord.Visible = true;
                        btnRate.Visible = true;
                    }
                    else if (status == "Cancelled")
                    {
                        btnRemove.Visible = true; // Xóa log lịch cũ khỏi giao diện hiển thị
                    }
                    break;

                case AppCardMode.DoctorView:
                    if (status == "Pending")
                    {
                        btnAccept.Visible = true;
                        btnCancel.Visible = true;
                    }
                    else if (status == "Confirmed")
                    {
                        btnComplete.Visible = true;
                    }
                    else if (status == "Completed")
                    {
                        btnViewRecord.Visible = true;
                    }
                    break;

                case AppCardMode.DoctorSchedule:
                    btnBook.Visible = (status == "Open");
                    break;
            }
        }

        // --- CHẾ ĐỘ 1: SETUP CARD THEO APPOINTMENTS DTO (Lịch hẹn cụ thể) ---
        public void SetupCard(AppointmentsDTO data, AppCardMode mode)
        {
            _currentMode = mode;
            _currentAppData = data;
            _currentTimeSlot = data.TimeSlot; // Đồng bộ ngược để lấy cấu trúc dữ liệu Slot
            _appointmentId = data.Id;
            _timeslotId = data.TimeSlot?.Id ?? 0;

            // Xử lý ẩn hiện khối thông tin hệ thống của Admin
            bool isAdmin = (mode == AppCardMode.AdminView);
            flpAdminNames.Visible = isAdmin;
            flpAdminPhones.Visible = isAdmin;
            lblAdminInfo.Visible = isAdmin;
            lblDep.Visible = isAdmin;

            lblName.Visible = !isAdmin;
            lblPhoneNumber.Visible = !isAdmin;
            label2.Visible = lblSymptoms.Visible = !isAdmin;

            // 1. Đổ dữ liệu thời gian chung
            if (data.TimeSlot != null)
            {
                lblDate.Text = data.TimeSlot.WorkDate.ToString("dd/MM/yyyy");
                lblTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";
            }

            // 2. Phân chia đổ dữ liệu chi tiết
            if (isAdmin)
            {
                lblAdminDoctor.Text = data.Doctor?.User?.FullName ?? "N/A";
                lblDep.Text = data.Doctor?.Department?.DepartmentName ?? "Chưa cập nhật";

                if (data.TimeSlot != null)
                {
                    lblAdminInfo.Text = $"Phòng: {data.TimeSlot.Room?.RoomCode ?? "N/A"}\n" +
                        $"Trạng thái: {(data.TimeSlot.BookedCount >= data.TimeSlot.MaxAppointments ? "Đầy" : "Còn trống")}\n" +
                        $"Số lượng: {data.TimeSlot.BookedCount}/{data.TimeSlot.MaxAppointments}";
                }

                UpdateStatusStyle(data.Status); // Admin vẫn cần nhìn thấy badge trạng thái xử lý lịch
            }
            else
            {
                // Chế độ dành cho User thông thường
                lblSymptoms.Text = data.Reason ?? "N/A";

                if (mode == AppCardMode.PatientView || mode == AppCardMode.HistoryView)
                {
                    string position = data.Doctor?.Position ?? "BS.";
                    string fullName = data.Doctor?.User?.FullName ?? "N/A";
                    lblName.Text = fullName.StartsWith(position, StringComparison.OrdinalIgnoreCase) ? fullName : $"{position} {fullName}".Trim();
                    lblPhoneNumber.Text = data.Doctor?.User?.PhoneNumber ?? "N/A";
                }
                else // DoctorView
                {
                    if (data.Patient == null || data.Patient.User == null)
                    {
                        lblName.Text = "Chưa có bệnh nhân";
                        lblPhoneNumber.Visible = false;
                        
                        lblSymptoms.Text = "Trống";
                        lblSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
                        lblSymptoms.ForeColor = Color.DarkGray;
                    }
                    else
                    {
                        lblName.Text = data.Patient.User.FullName;
                        lblPhoneNumber.Text = data.Patient.User.PhoneNumber;
                        lblPhoneNumber.Visible = true;
                        
                        //lblSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                        //lblSymptoms.ForeColor = Color.Black;
                    }
                }

                if (mode == AppCardMode.DoctorSchedule)
                {
                    btnStatus.Visible = false;
                    lblName.Visible = lblPhoneNumber.Visible = label2.Visible = lblSymptoms.Visible = false;
                }
                else
                {
                    UpdateStatusStyle(data.Status);
                }
            }

            // Cấu hình hiển thị nút
            SetupButtons(mode, isAdmin ? data.TimeSlot?.Status ?? data.Status : data.Status);

            // Tối ưu hóa UI: Responsive căn giữa vị trí nút trạng thái
            AlignStatusButtons();

            // Xử lý rút gọn giao diện tối giản nếu tắt ShowDoctorInfo
            if (!ShowDoctorInfo && !isAdmin)
            {
                lblName.Visible = lblPhoneNumber.Visible = label2.Visible = lblSymptoms.Visible = false;
                flpAction.Visible = false;

                if (flpAction.Controls.Contains(btnStatus)) flpAction.Controls.Remove(btnStatus);
                if (!this.Controls.Contains(btnStatus)) this.Controls.Add(btnStatus);

                btnStatus.Visible = true;
                btnStatus.BringToFront();
                btnStatus.Location = new Point((this.Width - btnStatus.Width) / 2, (this.Height - btnStatus.Height) / 2);
            }
        }

        // --- CHẾ ĐỘ 2: SETUP CARD THEO TIMESLOTS DTO (Khung giờ tổng quát) ---
        public void SetupCard(TimeSlotsDTO data, AppCardMode mode)
        {
            _currentMode = mode;
            _currentTimeSlot = data;
            _currentAppData = null;
            _timeslotId = data.Id;
            _appointmentId = 0;

            if (mode == AppCardMode.AdminView)
            {
                SetupAdminRow(data);
                return;
            }

            if (mode != AppCardMode.DoctorSchedule) return;

            // Dành cho bệnh nhân xem lịch trống của bác sĩ để đặt chỗ
            lblDate.Text = data.WorkDate.ToString("dd/MM/yyyy");
            lblTime.Text = $"{data.StartTime:hh\\:mm} - {data.EndTime:hh\\:mm}";

            btnStatus.Visible = false;
            lblName.Visible = lblPhoneNumber.Visible = label2.Visible = lblSymptoms.Visible = false;
            flpAdminNames.Visible = flpAdminPhones.Visible = lblAdminInfo.Visible =  false;

            SetupButtons(mode, data.Status);
        }

        // Thiết lập cấu trúc giao diện hàng đặc biệt cho Admin khi truyền vào TimeSlot tổng
        private void SetupAdminRow(TimeSlotsDTO data)
        {
            // Ẩn tất cả các control bệnh nhân/bác sĩ thông thường
            label2.Visible = lblSymptoms.Visible = false;
            lblAdminPhone.Visible = false;

            // Ẩn flpAdminNames và flpAdminPhones vì ta sẽ dùng lblName gốc
            flpAdminNames.Visible = false;
            flpAdminPhones.Visible = false;

            // Hiện đồng loạt các cấu trúc lưới thông tin Admin
            lblDate.Visible = true;
            lblTime.Visible = true;
            lblName.Visible = true;
            lblPhoneNumber.Visible = true;
            pnlAdminInfo.Visible = true;
            lblDep.Visible = true;
            btnViewPatients.Visible = true;

            lblDate.Text = data.WorkDate.ToString("dd/MM/yyyy");
            lblTime.Text = $"{data.StartTime:hh\\:mm} - {data.EndTime:hh\\:mm}";

            // Bên phải là Bác sĩ - Dùng lblName và lblPhoneNumber để hiển thị
            string position = UIHelper.NormalizeDoctorTitle(data.Doctor?.Position);
            string fullName = UIHelper.NormalizeDoctorName(data.Doctor?.User?.FullName);
            
            lblName.Text = string.IsNullOrWhiteSpace(position) ? $"BS. {fullName}" : $"{position} {fullName}";
            lblPhoneNumber.Text = data.Doctor?.User?.PhoneNumber ?? "N/A";

            int pendingCount = data.Appointments?.Count(a => a.Status == "Pending") ?? 0;

            btnViewPatients.Text = $"Xem chi tiết {data.BookedCount} bệnh nhân";
            UIHelper.ApplyRoundedRegion(btnViewPatients, 8);

            // Vị trí đã được căn chuẩn từ Designer

            lblPendingCount.Text = $"{pendingCount} chờ duyệt";
            UIHelper.ApplyRoundedRegion(lblPendingCount, 10);
            
            // Nếu có chờ duyệt thì làm nổi bật màu cam, nếu không thì hiện màu xám nhạt
            if (pendingCount > 0)
            {
                lblPendingCount.BackColor = Color.OldLace;
                lblPendingCount.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblPendingCount.BackColor = Color.FromArgb(245, 245, 245);
                lblPendingCount.ForeColor = Color.Gray;
            }

            lblArrow.Visible = false;
            btnStatus.Visible = false;
            lblPendingCount.Visible = true;

            lblDep.Text = data.Doctor?.Department?.DepartmentName ?? "Chưa cập nhật";
            UIHelper.ApplyRoundedRegion(lblDep, 8);

            string statusText = data.BookedCount >= data.MaxAppointments ? "Đầy" : "Còn trống";
            lblAdminRoom.Text = $"Phòng: {data.Room?.RoomCode ?? "N/A"}";
            lblAdminInfo.Text = $"Trạng thái: {statusText}\nSố lượng: {data.BookedCount}/{data.MaxAppointments}";

            SetupButtons(AppCardMode.AdminView, data.Status);
            AlignStatusButtons();
        }

        private void AlignStatusButtons()
        {
            if (btnStatus.Visible)
            {
                btnStatus.Location = new Point(this.Width - btnStatus.Width - 50, (this.Height - btnStatus.Height) / 2);
            }
        }

        // --- SỰ KIỆN CLICK CÁC NÚT THAO TÁC NGHIỆP VỤ ---
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chấp nhận lịch này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.AcceptAppointment(_appointmentId))
                {
                    MessageBox.Show("Chấp nhận lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData?.Invoke();
                }
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận bệnh nhân đã khám xong và cập nhật trạng thái thành 'Thành công'?", "Hoàn thành ca khám", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.UpdateStatus(_appointmentId, "Completed", "Khám hoàn tất"))
                {
                    MessageBox.Show("Đã cập nhật trạng thái lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Đã từ chối lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData?.Invoke();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // User lẻ tự hủy lịch cuộc hẹn của mình
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy lịch hẹn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.UndoAppointment(_appointmentId))
                {
                    MessageBox.Show("Đã hủy lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppointmentDeleted?.Invoke(this, EventArgs.Empty);
                    RefreshData?.Invoke();
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
            // Chức năng Ẩn đã bị loại bỏ khỏi hệ thống
        }
    }
}