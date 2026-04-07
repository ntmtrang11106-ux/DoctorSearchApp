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

        // Logic tìm kiếm theo tên (Có thể thực hiện lọc ngay tại tầng này)
        public List<DoctorDTO> SearchDoctorsByName(string name)
        {
            return doctorDAL.GetAllDoctors()
                             .Where(d => d.FullName.ToLower().Contains(name.ToLower()))
                             .ToList();
        }

        // Cập nhật thông tin và kiểm tra logic
        public string UpdateProfile(int userId, string cccd, string cchn, string exp, int clinicId, int specId)
        {
            if (string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(cchn))
                return "Vui lòng nhập đầy đủ CCCD và Mã chứng chỉ hành nghề!";

            if (cccd.Length != 12) return "CCCD không hợp lệ!";

            bool success = doctorDAL.UpdateDoctorProfile(userId, cccd, cchn, exp, clinicId, specId);
            return success ? "Success" : "Lỗi khi cập nhật hồ sơ bác sĩ!";
        }
    }
} 

////