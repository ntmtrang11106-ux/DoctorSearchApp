using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS_Tier
{
    public class AppointmentBUS
    {
        // Khởi tạo DAL để điều hướng dữ liệu
        private readonly AppointmentDAL _appointmentDAL = new AppointmentDAL();
        private readonly TimeSlotDAL _timeSlotDAL = new TimeSlotDAL();
        // 1. Lấy tất cả lịch hẹn để đổ lên DataGridView
        public List<AppointmentsDTO> GetAll()
        {
            // DAL đã xử lý Include(Patient, Doctor, TimeSlot) nên ở BUS chỉ cần gọi là xong
            return _appointmentDAL.GetAllAppointments();
        }

        // 2. Tạo lịch hẹn mới (Đặt lịch)
        public string CreateRepeatingAppointments(AppointmentsDTO baseApp, List<DateTime> selectedDates)
        {
            // Nghiệp vụ 1: Kiểm tra ngày chọn lặp lại có hợp lệ không
            if (selectedDates != null && selectedDates.Any(d => d.Date < DateTime.Now.Date))
            {
                return "Lỗi: Không thể đặt lịch cho những ngày trong quá khứ!";
            }

            // Nghiệp vụ 2: Kiểm tra logic cơ bản (Phòng hờ UI gửi thiếu dữ liệu)
            if (baseApp.PatientId == 0 || baseApp.DoctorId == 0)
            {
                return "Lỗi: Thông tin bệnh nhân hoặc bác sĩ không hợp lệ!";
            }

            // Nếu không lặp lại
            if (selectedDates == null || !selectedDates.Any())
            {
                return CreateSingleAppointment(baseApp);
            }

            int successCount = 0;
            int duplicateCount = 0;
            int noSlotCount = 0;
            string errorDetails = "";

            foreach (var date in selectedDates)
            {
                try
                {
                    // BƯỚC 1: Tìm TimeSlotId dựa trên DoctorId và Ngày cụ thể
                    // DAL cần viết: GetSlotIdByDateTime(int doctorId, DateTime date)
                    int actualSlotId = _timeSlotDAL.GetSlotIdByDateTime(baseApp.DoctorId, date);

                    if (actualSlotId <= 0)
                    {
                        noSlotCount++;
                        continue;
                    }

                    // BƯỚC 2: Kiểm tra xem slot này đã bị ai khác đặt chưa (IsSlotBooked)
                    if (_appointmentDAL.IsSlotBooked(actualSlotId))
                    {
                        duplicateCount++;
                        continue;
                    }

                    // BƯỚC 3: Tạo DTO mới
                    var newApp = new AppointmentsDTO
                    {
                        PatientId = baseApp.PatientId,
                        DoctorId = baseApp.DoctorId,
                        TimeSlotId = actualSlotId,
                        Symptoms = string.IsNullOrWhiteSpace(baseApp.Symptoms) ? "Chưa cập nhật" : baseApp.Symptoms,
                        Status = "Chờ duyệt", // Mặc định theo quy trình phòng khám
                        CreatedAt = DateTime.Now
                    };

                    // BƯỚC 4: Lưu xuống DAL (DAL sẽ chuyển Status của TimeSlot sang 'Đã đặt')
                    if (_appointmentDAL.CreateAppointment(newApp)) successCount++;
                    else errorDetails += $"{date.ToShortDateString()} (Lỗi hệ thống); ";
                }
                catch (Exception ex)
                {
                    errorDetails += $"{date.ToShortDateString()} ({ex.Message}); ";
                }
            }

            // TỔNG HỢP KẾT QUẢ TRẢ VỀ
            if (successCount == selectedDates.Count && noSlotCount == 0 && duplicateCount == 0)
                return "Success";

            StringBuilder sb = new StringBuilder();
            sb.Append($"Hoàn thành: {successCount}/{selectedDates.Count}. ");
            if (duplicateCount > 0) sb.Append($"Trùng lịch: {duplicateCount}. ");
            if (noSlotCount > 0) sb.Append($"Chưa có giờ: {noSlotCount}. ");
            if (!string.IsNullOrEmpty(errorDetails)) sb.Append($"Chi tiết lỗi: {errorDetails}");

            return sb.ToString();
        }

        private string CreateSingleAppointment(AppointmentsDTO app)
        {
            // Nghiệp vụ: Không đặt lịch ngày hôm qua
            // (Cần lấy thông tin ngày của TimeSlotId từ DAL để check)

            if (_appointmentDAL.IsSlotBooked(app.TimeSlotId))
            {
                return "Lỗi: Khung giờ này đã được đặt lịch trước đó!";
            }

            if (string.IsNullOrWhiteSpace(app.Symptoms))
                app.Symptoms = "Chưa cập nhật";

            bool result = _appointmentDAL.CreateAppointment(app);
            return result ? "Success" : "Lỗi hệ thống DAL khi tạo lịch đơn.";
        }
        // 3. Chấp nhận/Duyệt lịch hẹn (Dùng cho Bác sĩ/Admin)
        public bool AcceptAppointment(int appointmentId)
        {
            if (appointmentId <= 0) return false;

            // Gọi DAL cập nhật Status = 'Đã duyệt'
            return _appointmentDAL.UpdateStatusToAccept(appointmentId);
        }

        // 4. Từ chối/Hủy lịch hẹn
        public bool RejectAppointment(int appointmentId)
        {
            if (appointmentId <= 0) return false;

            // Gọi DAL: DAL sẽ cập nhật Status = 'Đã hủy' và trả TimeSlot về 'Trống'
            return _appointmentDAL.UpdateStatusToReject(appointmentId);
        }
    }
}