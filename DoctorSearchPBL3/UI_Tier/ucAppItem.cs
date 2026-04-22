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
            lblSymptoms.Text = string.IsNullOrEmpty(data.Symptoms) ? "Không có triệu chứng" : data.Symptoms;

            //if (data.TimeSlot != null)
            //{
            //    lblDate.Text = data.TimeSlot.Date.ToString("dd/MM/yyyy");
            //    // Format TimeSpan thành dạng HH'h':mm (Ví dụ: 08h:30)
            //    lblTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";
            //}
            //else
            //{
            //    lblDate.Text = "Chưa xác định";
            //    lblTime.Text = "--:--";
            //}
            //btnStatus.Text = data.Status ?? "Chờ duyệt";

            if (data.TimeSlot != null)
            {
                lblDate.Text = data.TimeSlot.Date.ToString("dd/MM/yyyy");
                lblTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";
            }

            btnStatus.Text = data.Status;

            //// Xử lý ẩn hiện nút: Chỉ hiện nút Chấp nhận/Từ chối nếu đang ở trạng thái "Chờ duyệt"
            //bool isPending = data.Status == "Chờ duyệt";
            //btnAccept.Visible = isPending;
            //btnCancel.Visible = isPending; // Nút Từ chối


            // 2. Xử lý hiển thị cho trạng thái (Status)
            btnStatus.Text = data.Status;

            // 3. Tùy biến màu sắc dựa trên trạng thái cho "xịn"
            //if (data.Status == "Hoàn thành")
            //{
            //    btnStatus.BackColor = Color.FromArgb(200, 255, 200); // Màu xanh nhạt
            //    btnStatus.ForeColor = Color.Green;
            //}
            //else if (data.Status == "Chờ duyệt")
            //{
            //    btnStatus.BackColor = Color.FromArgb(255, 240, 200); // Màu vàng nhạt
            //    btnStatus.ForeColor = Color.Orange;
            //}
            //else // Trạng thái "Đã hủy" hoặc khác
            //{
            //    btnStatus.BackColor = Color.FromArgb(255, 200, 200); // Màu đỏ nhạt
            //    btnStatus.ForeColor = Color.Red;
            //}

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

        //private void btnAccept_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Chấp nhận lịch này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        AppointmentBUS bus = new AppointmentBUS();
        //        if (bus.AcceptAppointment(_appointmentId))
        //        {
        //            // --- ĐOẠN QUAN TRỌNG: Cập nhật UI tại chỗ ---
        //            btnStatus.Text = "Đã duyệt";
        //            btnStatus.BackColor = Color.FromArgb(255, 200, 200); // Màu hồng nhạt như trong ảnh bc9ca2 bạn gửi
        //            btnStatus.ForeColor = Color.Red;

        //            // Ẩn các nút Chấp nhận/Từ chối đi vì đã duyệt rồi
        //            btnAccept.Visible = false;
        //            btnCancel.Visible = false;

        //            MessageBox.Show("Thành công!");
        //        }
        //    }
        //}

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    // 1. Hỏi xác nhận để tránh bấm nhầm
        //    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn từ chối lịch hẹn này không?",
        //                                        "Xác nhận từ chối",
        //                                        MessageBoxButtons.YesNo,
        //                                        MessageBoxIcon.Warning);

        //    if (result == DialogResult.Yes)
        //    {
        //        AppointmentBUS bus = new AppointmentBUS();

        //        // 2. Gọi xuống tầng BUS (hàm này sẽ gọi DAL để Update Status và giải phóng TimeSlot)
        //        if (bus.RejectAppointment(_appointmentId))
        //        {
        //            // 3. Cập nhật UI tại chỗ cho chuyên nghiệp
        //            btnStatus.Text = "Đã hủy";

        //            // Set màu đỏ/hồng nhạt cho trạng thái bị hủy
        //            btnStatus.BackColor = Color.FromArgb(255, 230, 230); // Màu nền đỏ cực nhạt
        //            btnStatus.ForeColor = Color.Red;

        //            // 4. Ẩn các nút thao tác đi vì lịch đã đóng
        //            btnAccept.Visible = false;
        //            btnCancel.Visible = false;

        //            MessageBox.Show("Đã từ chối lịch hẹn và giải phóng khung giờ thành công!", "Thông báo");

        //            // 5. Gọi delegate để Form cha load lại danh sách nếu cần (đảm bảo đồng bộ)
        //            RefreshData?.Invoke();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác này.", "Lỗi");
        //        }
        //    }
        //}

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
