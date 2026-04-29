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

        // Khai báo delegate để load lại danh sách sau khi update thành công
        public delegate void OnActionSuccess();
        public OnActionSuccess RefreshData;

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

        // Trong ucAppItem.cs
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

        private void SetupButtons(AppCardMode mode, string status)
        {
            // Dọn dẹp các nút trước khi hiện cái cần thiết
            foreach (Button btn in new Button[] { btnAccept, btnCancel, btnRemove, btnBook, btnRate, btnViewRecord })
            {
                btn.Visible = false;
            }
            btnAccept.Visible = (mode == AppCardMode.DoctorView && status == "Pending");
            btnCancel.Visible = (mode == AppCardMode.DoctorView && status == "Pending");
            //btnRemove.Visible = (mode == AppCardMode.DoctorView && status == "Open"); // tạm k cho hiện vì chỉ admin ms đổi đc
            btnBook.Visible = (mode == AppCardMode.DoctorSchedule && status == "Open");
            btnRate.Visible = (mode == AppCardMode.HistoryView && status == "Completed") || (mode == AppCardMode.DoctorView && status == "Completed");
            btnViewRecord.Visible = (mode == AppCardMode.HistoryView && status == "Completed") || (mode == AppCardMode.DoctorView && status == "Confirmed");
        }
        public void SetupCard(AppointmentsDTO data, AppCardMode mode)
        {
            _appointmentId = data.Id;

            // 1. Phân biệt hiển thị Tên
            if (mode == AppCardMode.PatientView || mode == AppCardMode.HistoryView)
            {
                lblName.Text = "BS. " + (data.Doctor?.User?.FullName ?? "N/A");
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
            UpdateStatusStyle(data.Status);

            // 4. PHÂN CHIA NÚT BẤM (QUAN TRỌNG NHẤT)
            SetupButtons(mode, data.Status);
        }

        private void ucAppItem_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(btnStatus, 10);
            UIHelper.ApplyRoundedRegion(btnAccept, 40);
            UIHelper.ApplyRoundedRegion(btnCancel, 40);
            UIHelper.ApplyRoundedRegion(btnRemove, 40);
            UIHelper.ApplyRoundedRegion(btnBook, 40);
            UIHelper.ApplyRoundedRegion(btnRate, 40);

            this.Paint += (sender, e) =>
            {
                UIHelper.uc_Paint(this, e, 10, Color.LightGray, 2);
            };
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // SỬA TẠI ĐÂY: So sánh đúng với chữ đang hiển thị trên giao diện
            if (btnStatus.Text != "Chờ duyệt")
            {
                MessageBox.Show("Lịch hẹn này đã được xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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
            // SỬA TẠI ĐÂY: So sánh với "Chờ duyệt"
            if (btnStatus.Text != "Chờ duyệt")
            {
                MessageBox.Show("Lịch hẹn này đã được xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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
    }
}
