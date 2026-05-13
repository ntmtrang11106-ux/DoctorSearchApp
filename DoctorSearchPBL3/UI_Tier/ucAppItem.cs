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

        private AppointmentsDTO _currentAppData;

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
                    btnStatus.ForeColor= Color.DarkGray;
                    break;
                case "Pending": // Chờ duyệt
                    btnStatus.Text = "Chờ duyệt";
                    btnStatus.BackColor = Color.LightGoldenrodYellow;
                    btnStatus.ForeColor = Color.Goldenrod;
                    break;
                case "Confirmed": // Đã duyệt
                    btnStatus.Text = "Đã duyệt";
                    btnStatus.BackColor = Color.LightGreen;
                    btnStatus.ForeColor = Color.Green;
                    break;
                case "Cancelled": // Đã hủy
                    btnStatus.Text = "Đã hủy";
                    btnStatus.BackColor = Color.LightCoral;
                    btnStatus.ForeColor = Color.Red;
                    break;
                case "Completed": // Thành công
                    btnStatus.Text = "Thành công";
                    btnStatus.BackColor = Color.Azure;
                    btnStatus.ForeColor = Color.DodgerBlue;
                    break;
            }
        }

        // Thiết lập hiển thị nút dựa trên chế độ và trạng thái
        private void SetupButtons(AppCardMode mode, string status)
        {
            // Dọn dẹp các nút trước khi hiện cái cần thiết
            foreach (Button btn in new Button[] { btnAccept, btnCancel, btnRemove, btnBook, btnRate, btnViewRecord, btnEdit })
            {
                btn.Visible = false;
            }
            // 2. Logic cho Bệnh nhân (PatientView / HistoryView)
            if (mode == AppCardMode.PatientView || mode == AppCardMode.HistoryView)
            {
                if (status == "Pending")
                {
                    btnEdit.Visible = true;
                    btnRemove.Visible = true;
                }
                else if (status == "Confirmed")
                {
                    btnEdit.Visible = false;
                    btnRemove.Visible = false;
                    
                    // Cho phép xem bệnh án nếu đã duyệt
                    // btnViewRecord.Visible = true;
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
                btnStatus.Visible = true;
                
                // Các nút khác ẩn
                btnAccept.Visible = false;
                btnCancel.Visible = false;
                btnBook.Visible = false;
                btnRate.Visible = false;
                btnViewRecord.Visible = false;
            }
        }

        // Thiết lập dữ liệu cho card dựa trên AppointmentsDTO và chế độ hiển thị
        public void SetupCard(AppointmentsDTO data, AppCardMode mode)
        {
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
            }
            else if (mode == AppCardMode.AdminView)
            {
                string pName = data.Patient?.User?.FullName ?? "N/A";
                string dName = data.Doctor?.User?.FullName ?? "N/A";
                lblName.Text = $"{pName} ↔ {dName}";
                lblPhoneNumber.Text = $"P: {data.Patient?.User?.PhoneNumber} | D: {data.Doctor?.User?.PhoneNumber}";
            }
            else
            {
                lblName.Text = data.Patient?.User?.FullName ?? "Bệnh nhân chưa đặt";
                lblPhoneNumber.Text = data.Patient?.User?.PhoneNumber ?? "0000000000";
            }

            label2.Visible = lblSymptoms.Visible = (data.Status != "Open");
            lblSymptoms.Text = data.Reason ?? "N/A";

            // 2. Load giờ giấc (Dùng chung)
            if (data.TimeSlot != null)
            {
                lblDate.Text = data.TimeSlot.WorkDate.ToString("dd/MM/yyyy");
                lblTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";
            }

            // 3. Dịch trạng thái sang tiếng Việt và đổi màu
            if(mode == AppCardMode.DoctorSchedule)
            {
                btnStatus.Visible = false;
                lblName.Visible = lblPhoneNumber.Visible = label2.Visible = lblSymptoms.Visible = false;
            }
            else 
                UpdateStatusStyle(data.Status);
            

            // 4. PHÂN CHIA NÚT BẤM (QUAN TRỌNG NHẤT)
            SetupButtons(mode, data.Status);

            // 5. Ẩn bớt thông tin dư thừa dựa trên cấu hình (Thường dùng trong hồ sơ bác sĩ)
            if (!ShowDoctorInfo)
            {
                lblName.Visible = false;
                lblPhoneNumber.Visible = false;
                label2.Visible = false;
                lblSymptoms.Visible = false;
            }
            else
            {
                lblName.Visible = true;
                lblPhoneNumber.Visible = true;
                label2.Visible = (data.Status != "Open");
                lblSymptoms.Visible = (data.Status != "Open");
            }
        }

        // Thiết lập dữ liệu cho card dựa trên TimeSlotsDTO và chế độ hiển thị (Dành cho DoctorSchedule hoặc AdminView)
        public void SetupCard(TimeSlotsDTO data, AppCardMode mode)
        {
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
            _currentAppData = null;

            // Dùng lại Layout Card (Full Width)
            this.Height = 252; 
            this.Padding = new Padding(20);

            // 1. Cột Bác sĩ & Thời gian (Left)
            label1.Visible = true;
            lblDate.Visible = true;
            lblTime.Visible = true;
            lblPhoneNumber.Visible = true;
            
            // // Khôi phục vị trí chuẩn cho Date/Time
            // label1.Location = new Point(40, 71);
            // lblDate.Location = new Point(130, 75);
            // lblTime.Location = new Point(128, 131);
            
            lblDate.Text = data.WorkDate.ToString("dd/MM/yyyy");
            lblTime.Text = $"{data.StartTime:hh\\:mm} - {data.EndTime:hh\\:mm}";
            
            // Xóa bỏ các label phụ (Location, Khoa) ở cột trái theo yêu cầu
            lblPhoneNumber.Visible = false;
            Label lblDept = this.Controls.Find("lblDeptAdmin", true).FirstOrDefault() as Label;
            if (lblDept != null) lblDept.Visible = false;

            lblName.Visible = true;
            lblName.Text = data.Doctor?.User?.FullName ?? "N/A";
            lblName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblName.Location = new Point(380, 62);
            lblName.AutoSize = true;

            // 2. Cột Phòng & Số lượng (Giữ nguyên bên phải)
            label2.Visible = true;
            label2.Text = "🏠";
            label2.Location = new Point(1000, 75);

            lblSymptoms.Visible = true;
            lblSymptoms.Text = $"Phòng: {data.Room?.RoomName ?? "N/A"}\nSố lượng: {data.BookedCount}/{data.MaxAppointments}";
            lblSymptoms.Font = new Font("Segoe UI", 11F);
            lblSymptoms.Location = new Point(1090, 80);
            lblSymptoms.Size = new Size(300, 100);

            // 3. Cột Trạng thái (Sát lề phải x=1800)
            btnStatus.Visible = true;
            btnStatus.Location = new Point(1800, 80);
            btnStatus.Size = new Size(200, 60);
            
            // Loại bỏ hoàn toàn Badge "Lặp lại" (btnStatus2)
            Button btnStatus2 = this.Controls.Find("btnStatus2", true).FirstOrDefault() as Button;
            if (btnStatus2 != null) btnStatus2.Visible = false;

            if (data.BookedCount >= data.MaxAppointments)
            {
                btnStatus.Text = "Đầy";
                btnStatus.BackColor = Color.FromArgb(220, 53, 69);
            }
            else
            {
                btnStatus.Text = "Còn chỗ";
                btnStatus.BackColor = Color.FromArgb(40, 167, 69);
            }
            btnStatus.ForeColor = Color.White;

            // 4. Thao tác
            flpAction.Visible = true;
            SetupButtons(AppCardMode.AdminView, data.Status);
            
            UIHelper.ApplyRoundedRegion(btnStatus, 30);
            UIHelper.ApplyRoundedRegion(btnEdit, 10);
            UIHelper.ApplyRoundedRegion(btnRemove, 10);
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

            this.Paint += (sender, e) =>
            {
                UIHelper.uc_Paint(this, e, 10, Color.LightGray, 2);
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
            string confirmMsg = (_timeslotId > 0 && _currentAppData == null) 
                ? "Bạn có chắc chắn muốn xóa lịch làm việc này không?" 
                : "Bạn có chắc chắn muốn hủy lịch hẹn này không?";

            if (MessageBox.Show(confirmMsg, "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_timeslotId > 0 && _currentAppData == null)
                {
                    // Case: Admin deleting a Time Slot
                    TimeSlotBUS tsBus = new TimeSlotBUS();
                    if (tsBus.DeleteTimeSlot(_timeslotId))
                    {
                        MessageBox.Show("Đã xóa lịch làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Xóa lịch làm việc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Case: Patient/Doctor/Admin deleting an Appointment
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_currentAppData != null)
            {
                AppointmentEdited?.Invoke(this, _currentAppData);
            }
        }
    }
}
