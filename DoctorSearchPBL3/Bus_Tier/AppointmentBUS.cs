//using System;
//using System.Collections.Generic;
//using System.Text;
//using DAL_Tier;
//using DTO_Tier;

//namespace BUS_Tier
//{
//    public class AppointmentBUS
//    {
//        private AppointmentDAL dal = new AppointmentDAL();

//        public List<AppointmentsDTO> GetAll()
//        {
//            return dal.GetAllAppointments();
//        }

//        //tạo lịch hẹn mới
//        public bool BookAppointment(AppointmentsDTO app)
//        {
//            // 1. Logic: Kiểm tra nếu các ID quan trọng bị trống thì không cho đặt
//            if (app.PatientId <= 0 || app.DoctorId <= 0 || app.TimeSlotId <= 0)
//                return false;

//            // 2. Gọi DAL thực hiện thêm vào DB
//            return dal.CreateAppointment(app);
//        }

//        public bool AcceptAppointment(int appointmentId)
//        {
//            // Ở đây bạn có thể thêm logic kiểm tra: 
//            // ví dụ: nếu lịch đã bị hủy thì không cho chấp nhận nữa.
//            return dal.UpdateStatusToAccept(appointmentId);
//        }

//        public bool RejectAppointment(int appointmentId)
//        {
//            using (var context = new AppDbContext())
//            {
//                // 1. Tìm lịch hẹn cần từ chối
//                var app = context.Appointments.FirstOrDefault(a => a.Id == appointmentId);
//                if (app == null) return false;

//                // 2. Cập nhật trạng thái Appointments sang 'Đã hủy'
//                app.Status = "Đã hủy";

//                // 3. Tìm TimeSlot liên quan và cập nhật về 'Trống'
//                var slot = context.TimeSlots.FirstOrDefault(s => s.Id == app.TimeSlotId);
//                if (slot != null)
//                {
//                    slot.Status = "Trống";
//                }

//                // Lưu tất cả thay đổi
//                return context.SaveChanges() > 0;
//            }
//        }
//    }
//}


using System;
using System.Collections.Generic;
using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class AppointmentBUS
    {
        // Khởi tạo DAL để điều hướng dữ liệu
        private readonly AppointmentDAL _appointmentDAL = new AppointmentDAL();

        // 1. Lấy tất cả lịch hẹn để đổ lên DataGridView
        public List<AppointmentsDTO> GetAll()
        {
            // DAL đã xử lý Include(Patient, Doctor, TimeSlot) nên ở BUS chỉ cần gọi là xong
            return _appointmentDAL.GetAllAppointments();
        }

        // 2. Tạo lịch hẹn mới (Đặt lịch)
        public bool BookAppointment(AppointmentsDTO app)
        {
            // Kiểm tra nghiệp vụ: Các ID phải hợp lệ
            if (app.PatientId <= 0 || app.DoctorId <= 0 || app.TimeSlotId <= 0)
                return false;

            // Kiểm tra nghiệp vụ: Triệu chứng không được để trống (nvarchar(500) trong SQL)
            //if (string.IsNullOrWhiteSpace(app.Symptoms))
            //    return false;

            // Gọi DAL: DAL sẽ tự động dùng Transaction để vừa tạo App vừa khóa TimeSlot
            return _appointmentDAL.CreateAppointment(app);
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