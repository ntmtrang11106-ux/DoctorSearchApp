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
        public ucAppItem()
        {
            InitializeComponent();

            UIHelper.ApplyRoundedRegion(btnStatus, 10);
        }

        // Trong file UC_AppItem.cs
        public void SetAppItemData(AppointmentsDTO data)
        {
            // 1. Đổ dữ liệu cơ bản vào các Label
            // Lưu ý: Thay lblName, lblPhone... bằng đúng "Name" ông đặt cho các Control nhé
            //lblPatientName.Text = data.PatientName;
            //lblPhoneNumber.Text = data.PhoneNumber;
            //lblSymptoms.Text = data.Symptoms;
            //lblDate.Text = data.AppointmentDate;
            //lblTime.Text = data.TimeRange;


            //nhân 
            lblPatientName.Text = data.Patient?.User?.FullName ?? "N/A";
            lblPhoneNumber.Text = data.Patient?.User?.PhoneNumber ?? "N/A";
            lblSymptoms.Text = string.IsNullOrEmpty(data.Symptoms) ? "Không có triệu chứng" : data.Symptoms;
            if (data.TimeSlot != null)
            {
                lblDate.Text = data.TimeSlot.Date.ToString("dd/MM/yyyy");
                // Format TimeSpan thành dạng HH'h':mm (Ví dụ: 08h:30)
                lblTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";
            }
            else
            {
                lblDate.Text = "Chưa xác định";
                lblTime.Text = "--:--";
            }
            btnStatus.Text = data.Status ?? "Chờ duyệt";
            //
            

            // 2. Xử lý hiển thị cho trạng thái (Status)
            btnStatus.Text = data.Status;

            // 3. Tùy biến màu sắc dựa trên trạng thái cho "xịn"
            if (data.Status == "Thành công")
            {
                btnStatus.BackColor = Color.FromArgb(200, 255, 200); // Màu xanh nhạt
                btnStatus.ForeColor = Color.Green;
            }
            else if (data.Status == "Chờ duyệt")
            {
                btnStatus.BackColor = Color.FromArgb(255, 240, 200); // Màu vàng nhạt
                btnStatus.ForeColor = Color.Orange;
            }
            else // Trạng thái "Đã hủy" hoặc khác
            {
                btnStatus.BackColor = Color.FromArgb(255, 200, 200); // Màu đỏ nhạt
                btnStatus.ForeColor = Color.Red;
            }
        }
    }
}
