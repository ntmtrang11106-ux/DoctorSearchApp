using System;
using System.Collections.Generic;
using System.Text;
using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class AppointmentBUS
    {
        private AppointmentDAL dal = new AppointmentDAL();

        public List<AppointmentsDTO> GetAll()
        {
            return dal.GetAllAppointments();
        }

        //tạo lịch hẹn mới
        public bool BookAppointment(AppointmentsDTO app)
        {
            // 1. Logic: Kiểm tra nếu các ID quan trọng bị trống thì không cho đặt
            if (app.PatientId <= 0 || app.DoctorId <= 0 || app.TimeSlotId <= 0)
                return false;

            // 2. Gọi DAL thực hiện thêm vào DB
            return dal.CreateAppointment(app);
        }

        public bool AcceptAppointment(int appointmentId)
        {
            // Ở đây bạn có thể thêm logic kiểm tra: 
            // ví dụ: nếu lịch đã bị hủy thì không cho chấp nhận nữa.
            return dal.UpdateStatusToAccept(appointmentId);
        }

        public bool RejectAppointment(int appointmentId)
        {
            using (var context = new AppDbContext())
            {
                // 1. Tìm lịch hẹn cần từ chối
                var app = context.Appointments.FirstOrDefault(a => a.Id == appointmentId);
                if (app == null) return false;

                // 2. Cập nhật trạng thái Appointments sang 'Đã từ chối'
                app.Status = "Đã hủy";

                // 3. Tìm TimeSlot liên quan và cập nhật về 'Trống'
                var slot = context.TimeSlots.FirstOrDefault(s => s.Id == app.TimeSlotId);
                if (slot != null)
                {
                    slot.Status = "Trống";
                }

                // Lưu tất cả thay đổi
                return context.SaveChanges() > 0;
            }
        }
    }
}
