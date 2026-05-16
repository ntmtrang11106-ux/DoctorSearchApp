using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;
using System.Linq;

namespace BUS_Tier
{
    public class AdminBUS
    {
        private readonly AdminDAL _adminDAL = new AdminDAL();

        public List<UserDTO> GetAllUsers()
        {
            return _adminDAL.GetAllUsers();
        }

        public DoctorDTO GetDoctorByUserId(int userId)
        {
            return _adminDAL.GetDoctorByUserId(userId);
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

        public (UserDTO User, DoctorDTO Doctor, PatientDTO Patient) GetFullUserDetails(int userId, string role)
        {
            return _adminDAL.GetFullUserDetails(userId, role);
        }

        public bool DeleteUser(int userId)
        {
            return _adminDAL.DeleteUser(userId);
        }

        public string GetApproveConfirmMessage(string name) => $"Bạn có chắc chắn muốn phê duyệt bác sĩ {name}? Sau khi phê duyệt, bác sĩ có thể bắt đầu nhận lịch hẹn.";
        public string GetRejectConfirmMessage(string name) => $"Bạn có chắc chắn muốn từ chối hồ sơ của bác sĩ {name}? Hành động này sẽ xóa hồ sơ đăng ký của bác sĩ.";
        public string GetDeleteConfirmMessage(string name) => $"Bạn có chắc chắn muốn xóa vĩnh viễn tài khoản của {name}? Hành động này không thể hoàn tác.";
        public string GetToggleStatusMessage(UserDTO user)
        {
            if (user == null) return "";
            return user.Status == "Active" 
                ? $"Bạn có chắc chắn muốn khóa tài khoản của {user.FullName}? Người dùng sẽ không thể đăng nhập vào hệ thống."
                : $"Bạn có muốn mở khóa tài khoản cho {user.FullName}? Người dùng có thể đăng nhập lại vào hệ thống.";
        }
        public PatientDTO GetPatientByUserId(int userId)
        {
            return _adminDAL.GetPatientByUserId(userId);
        }

        public (int Confirmed, int Pending) GetAppointmentStatistics(int userId, string role)
        {
            return _adminDAL.GetAppointmentStatistics(userId, role);
        }

        public bool BlockUserWithAppointmentHandling(int userId, string role)
        {
            return _adminDAL.BlockUserWithAppointmentHandling(userId, role);
        }

        public bool DeleteUserWithAppointmentHandling(int userId, string role)
        {
            return _adminDAL.DeleteUserWithAppointmentHandling(userId, role);
        }
    }
}
