using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class AdminBUS
    {
        private readonly AdminDAL _adminDAL = new AdminDAL();

        public List<UserDTO> GetAllUsers()
        {
            return _adminDAL.GetAllUsers();
        }

        public List<DoctorDTO> GetPendingDoctors()
        {
            return _adminDAL.GetPendingDoctors();
        }

        public bool ApproveDoctor(int doctorId)
        {
            return _adminDAL.ApproveDoctor(doctorId);
        }

        public bool RejectDoctor(int doctorId)
        {
            return _adminDAL.RejectDoctor(doctorId);
        }

        public bool UpdateUserStatus(int userId, string status)
        {
            return _adminDAL.UpdateUserStatus(userId, status);
        }

        public List<UserDTO> SearchUsers(string keyword, string role)
        {
            return _adminDAL.SearchUsers(keyword, role);
        }
    }
}
