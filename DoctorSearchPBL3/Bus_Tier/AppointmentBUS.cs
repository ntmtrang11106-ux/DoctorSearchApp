using DAL_Tier;
using DTO_Tier;
using Microsoft.EntityFrameworkCore;
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


        public string BookAppointment(int patientId, int timeSlotId, string reason)
        {
            try
            {
                // 1. Kiểm tra triệu chứng (tối đa 500 ký tự)
                if (!string.IsNullOrEmpty(reason) && reason.Length > 500)
                    return "Triệu chứng không được vượt quá 500 ký tự.";

                // 2. Lấy thông tin qua DAL (Thay vì dùng _context trực tiếp)
                var slot = _timeSlotDAL.GetSlotForBooking(timeSlotId);

                if (slot == null)
                    return "Không tìm thấy lịch khám này.";

                // 3. Kiểm tra logic "Full" dựa trên MaxAppointments
                if (slot.Status == "Full" || slot.BookedCount >= slot.MaxAppointments)
                {
                    return "Lịch khám này đã đủ số lượng người đăng ký (Full).";
                }

                // 4. Chuẩn bị DTO kèm dữ liệu Snapshot
                // Truy xuất thông tin từ các object liên quan có sẵn trong slot
                var appointmentDto = new AppointmentsDTO
                {
                    PatientId = patientId,
                    DoctorId = slot.DoctorId,
                    TimeSlotId = timeSlotId,
                    Reason = reason,
                    // Lấy thông tin từ các bảng liên quan để lưu Snapshot
                    DoctorNameSnapshot = slot.Doctor?.User?.FullName ?? "N/A",
                    DepartmentNameSnapshot = slot.Doctor?.Department?.DepartmentName ?? "N/A",
                    RoomNameSnapshot = slot.Room?.RoomName ?? "N/A",
                    FeeSnapshot = slot.Doctor?.ConsultationFee ?? 0
                };

                // 5. Gọi DAL để thực hiện lưu (bao gồm logic tăng BookedCount và Update Status lên Full)
                bool isSuccess = _appointmentDAL.CreateAppointment(appointmentDto);

                return isSuccess ? "SUCCESS" : "Đặt lịch thất bại (Lịch có thể đã vừa đầy hoặc bị đóng).";
            }
            catch (Exception ex)
            {
                // Ghi log ex ở đây nếu cần
                return "Lỗi hệ thống: " + ex.Message;
            }
        }

        ///////////////////////////////////////
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
            // 1. Kiểm tra trạng thái hiện tại (Logic nghiệp vụ)
            var app = _appointmentDAL.GetById(appointmentId);
            if (app == null || app.Status != "Pending") return false;

            return _appointmentDAL.UpdateStatusToAccept(appointmentId);
        }

        public bool RejectAppointment(int appointmentId)
        {
            // 1. Kiểm tra trạng thái hiện tại
            var app = _appointmentDAL.GetById(appointmentId);
            if (app == null || app.Status != "Pending") return false;

            return _appointmentDAL.UpdateStatusToReject(appointmentId);
        }

        public List<AppointmentsDTO> GetFilteredAppointmentsForPatient(int patientId, int doctorId, DateTime fromDate, DateTime toDate, TimeSpan fromTime, TimeSpan toTime)
        {
            if (patientId <= 0 || doctorId <= 0) return new List<AppointmentsDTO>();
            return _appointmentDAL.GetPatientAppointmentsFiltered(patientId, doctorId, fromDate, toDate, fromTime, toTime);
        }
        public bool UpdateAppointment(int appointmentId, int newTimeSlotId, string newReason)
        {
            return _appointmentDAL.UpdateAppointment(appointmentId, newTimeSlotId, newReason);
        }

        public bool DeleteAppointment(int appointmentId)
        {
            return _appointmentDAL.DeleteAppointment(appointmentId);
        }
    }
}