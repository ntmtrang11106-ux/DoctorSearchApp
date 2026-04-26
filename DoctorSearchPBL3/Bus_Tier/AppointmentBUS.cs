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
    }
}
