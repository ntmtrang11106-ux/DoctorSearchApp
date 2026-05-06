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
            HistoryView     // Xem lại lịch cũ (Hiện nút Rate/Đánh giá)
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
            foreach (Button btn in new Button[] { btnAccept, btnCancel, btnRemove, btnBook, btnRate, btnViewRecord })
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
            
            // 4. Logic cho Đặt lịch (DoctorSchedule)
            if (mode == AppCardMode.DoctorSchedule)
            {
                btnBook.Visible = (status == "Open");
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
            else
            {
                lblName.Text = data.Patient?.User?.FullName ?? "Bệnh nhân chưa đặt";
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

        // Thiết lập dữ liệu cho card dựa trên TimeSlotsDTO và chế độ hiển thị (Dành cho DoctorSchedule)
        public void SetupCard(TimeSlotsDTO data, AppCardMode mode)
        {
            if (mode != AppCardMode.DoctorSchedule) return;
            _appointmentId = data.Id;

            label2.Visible = lblSymptoms.Visible = (data.Status != "Open");

            lblDate.Text = data.WorkDate.ToString("dd/MM/yyyy");
            lblTime.Text = $"{data.StartTime:hh\\:mm} - {data.EndTime:hh\\:mm}";

            btnStatus.Visible = false;
            lblName.Visible = lblPhoneNumber.Visible = label2.Visible = lblSymptoms.Visible = false;

            SetupButtons(mode, data.Status);
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
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy lịch hẹn này không?", "Xác nhận hủy", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.DeleteAppointment(_appointmentId))
                {
                    MessageBox.Show("Đã hủy lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppointmentDeleted?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Hủy lịch hẹn thất bại. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
