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
    }
}
