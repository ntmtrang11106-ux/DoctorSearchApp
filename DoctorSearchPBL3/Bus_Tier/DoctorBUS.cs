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
        public string UpdateDoctorInfo(DoctorDTO doctor)
        {
            // Kiểm tra nghiệp vụ (ví dụ: kinh nghiệm không được âm)
            if (doctor.ExperienceYears < 0) return "Số năm kinh nghiệm không hợp lệ!";
            if (string.IsNullOrEmpty(doctor.FullName)) return "Tên bác sĩ không được để trống!";

            bool result = doctorDAL.UpdateDoctor(doctor);
            return result ? "Cập nhật thành công!" : "Cập nhật thất bại, vui lòng kiểm tra lại!";
        }
    }
} 

////