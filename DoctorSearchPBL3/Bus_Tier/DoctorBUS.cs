using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class DoctorBUS
    {
        DoctorDAL doctorDAL = new DoctorDAL();

        public List<DoctorDTO> GetListDoctors()
        {
            return doctorDAL.GetAllDoctors();
        }
    }

    //public class DoctorBUS
    //{
    //    private DoctorDAL _dal = new DoctorDAL();

    //    public List<DoctorDTO> GetListDoctor()
    //    {
    //        return _dal.GetAllDoctors();
    //    }
    //}
} 