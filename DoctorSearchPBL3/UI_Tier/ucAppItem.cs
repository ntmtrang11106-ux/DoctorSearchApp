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
    public partial class ucAppItem : UserControl
    {
        private int _appointmentId; // Lưu ID để dùng khi bấm nút

        // Khai báo delegate để load lại danh sách sau khi update thành công
        public delegate void OnActionSuccess();
        public OnActionSuccess RefreshData;

        public ucAppItem()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }

        // Trong file UC_AppItem.cs
        public void SetAppItemData(AppointmentsDTO data)
        {
            _appointmentId = data.Id; // Gán ID ở đây

            //nhân 
            lblPatientName.Text = data.Patient?.User?.FullName ?? "N/A";
            lblPhoneNumber.Text = data.Patient?.User?.PhoneNumber ?? "N/A";
            //lblSymptoms.Text = string.IsNullOrEmpty(data.Symptoms) ? "Không có triệu chứng" : data.Symptoms;

            if (data.TimeSlot != null)
            {
                //lblDate.Text = data.TimeSlot.Date.ToString("dd/MM/yyyy");
                lblTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";
            }

            btnStatus.Text = data.Status;

            // 2. Xử lý hiển thị cho trạng thái (Status)
            btnStatus.Text = data.Status;

            // --- QUAN TRỌNG: Cấm nút nếu không phải "Chờ duyệt" ---
            bool isPending = (data.Status == "Chờ duyệt");
            btnAccept.Visible = isPending;
            btnCancel.Visible = isPending;

            // 2. Xử lý màu sắc hiển thị
            if (data.Status == "Đã duyệt" || data.Status == "Hoàn thành")
            {
                btnStatus.BackColor = Color.FromArgb(200, 255, 200); // Xanh nhạt
                btnStatus.ForeColor = Color.Green;
            }
            else if (data.Status == "Chờ duyệt")
            {
                btnStatus.BackColor = Color.FromArgb(255, 240, 200); // Vàng nhạt
                btnStatus.ForeColor = Color.Orange;
            }
            else // Đã hủy hoặc Đã từ chối
            {
                btnStatus.BackColor = Color.FromArgb(255, 200, 200); // Đỏ nhạt
                btnStatus.ForeColor = Color.Red;
            }
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
            // Kiểm tra lớp bảo vệ 2: Nếu trạng thái hiện tại khác Chờ duyệt thì báo lỗi
            if (btnStatus.Text != "Chờ duyệt")
            {
                MessageBox.Show("Lịch hẹn này đã được xử lý, bạn không được phép thay đổi nữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Chấp nhận lịch này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.AcceptAppointment(_appointmentId))
                {
                    // Cập nhật giao diện tại chỗ
                    btnStatus.Text = "Đã duyệt";
                    btnStatus.BackColor = Color.FromArgb(200, 255, 200);
                    btnStatus.ForeColor = Color.Green;

                    // Cấm bấm tiếp
                    btnAccept.Visible = false;
                    btnCancel.Visible = false;

                    MessageBox.Show("Thành công!");
                    RefreshData?.Invoke(); // Load lại toàn bộ list nếu cần
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Kiểm tra lớp bảo vệ 2
            if (btnStatus.Text != "Chờ duyệt")
            {
                MessageBox.Show("Lịch hẹn này đã được xử lý, bạn không được phép thay đổi nữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Từ chối lịch hẹn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                AppointmentBUS bus = new AppointmentBUS();
                if (bus.RejectAppointment(_appointmentId))
                {
                    // Cập nhật giao diện tại chỗ
                    btnStatus.Text = "Đã hủy";
                    btnStatus.BackColor = Color.FromArgb(255, 200, 200);
                    btnStatus.ForeColor = Color.Red;

                    // Cấm bấm tiếp
                    btnAccept.Visible = false;
                    btnCancel.Visible = false;

                    MessageBox.Show("Đã hủy lịch hẹn thành công!");
                    RefreshData?.Invoke();
                }
            }
        }
    }
}
