using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS_Tier
{
    public class AppointmentBUS
    {
        private readonly AppointmentDAL _appointmentDAL = new AppointmentDAL();
        private readonly TimeSlotDAL _timeSlotDAL = new TimeSlotDAL();

        public List<AppointmentsDTO> GetAll()
        {
            return _appointmentDAL.GetAllAppointments();
        }

        public string CreateRepeatingAppointments(AppointmentsDTO baseApp, List<DateTime> selectedDates)
        {
            // 1. Kiểm tra ngày trong quá khứ
            if (selectedDates != null && selectedDates.Any(d => d.Date < DateTime.Now.Date))
            {
                return "Lỗi: Không thể đặt lịch cho những ngày trong quá khứ!";
            }

            if (baseApp.PatientId == 0 || baseApp.DoctorId == 0)
            {
                return "Lỗi: Thông tin bệnh nhân hoặc bác sĩ không hợp lệ!";
            }

            // Nếu chỉ đặt 1 ngày đơn lẻ
            if (selectedDates == null || !selectedDates.Any())
            {
                return CreateSingleAppointment(baseApp);
            }

            int successCount = 0;
            int duplicateCount = 0;
            int noSlotCount = 0;
            StringBuilder errorDetails = new StringBuilder();

            foreach (var date in selectedDates)
            {
                // BƯỚC 1: Tìm ID khung giờ dựa trên WorkDate (Khớp SQL)
                // Lưu ý: Nếu 1 ngày bác sĩ có nhiều khung giờ, cần truyền thêm StartTime/EndTime để lọc
                int actualSlotId = _timeSlotDAL.GetSlotIdByDateTime(baseApp.DoctorId, date);

                if (actualSlotId <= 0)
                {
                    noSlotCount++;
                    continue;
                }

                // BƯỚC 2: Tạo DTO và lưu
                var newApp = new AppointmentsDTO
                {
                    PatientId = baseApp.PatientId,
                    DoctorId = baseApp.DoctorId,
                    TimeSlotId = actualSlotId,
                    Reason = string.IsNullOrWhiteSpace(baseApp.Reason) ? "Khám tổng quát" : baseApp.Reason,
                    Status = "Pending", // Khớp DEFAULT trong SQL
                    CreatedAt = DateTime.Now
                };

                // Bước 3: Gọi DAL (DAL đã lo việc check Status 'Open' và chuyển sang 'Booked')
                if (_appointmentDAL.CreateAppointment(newApp)) successCount++;
                else errorDetails.Append($"{date.ToShortDateString()} (Lỗi hệ thống); ");
            }

            if (successCount == selectedDates.Count && noSlotCount == 0) return "Success";

            StringBuilder res = new StringBuilder();
            res.Append($"Hoàn thành: {successCount}/{selectedDates.Count}. ");
            if (noSlotCount > 0) res.Append($"Không tìm thấy khung giờ trống: {noSlotCount}. ");
            if (errorDetails.Length > 0) res.Append($"Lỗi: {errorDetails}");

            return res.ToString();
        }

        private string CreateSingleAppointment(AppointmentsDTO app)
        {
            // Tầng DAL của chúng ta đã có check slot.Status != "Open" nên ở đây gọi thẳng
            bool result = _appointmentDAL.CreateAppointment(app);
            return result ? "Success" : "Lỗi: Khung giờ đã bị đặt hoặc không tồn tại.";
        }

        public bool AcceptAppointment(int appointmentId)
        {
            return _appointmentDAL.UpdateStatusToAccept(appointmentId);
        }

        public bool RejectAppointment(int appointmentId)
        {
            return _appointmentDAL.UpdateStatusToReject(appointmentId);
        }
    }
}