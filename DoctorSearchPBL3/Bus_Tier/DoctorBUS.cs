using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;
using System.Linq; // Cần thêm thư viện này để dùng .Where()
using System;

namespace BUS_Tier
{
    public class DoctorBUS
    {
        DoctorDAL doctorDAL = new DoctorDAL();

        public List<DoctorDTO> GetListDoctors()
        {
            return doctorDAL.GetAllDoctors();
        }

        //// Logic tìm kiếm theo tên
        //public List<DoctorDTO> SearchDoctorsByName(string name)
        //{
        //    // FullName hiện tại nằm trong đối tượng User liên kết
        //    return doctorDAL.GetAllDoctors()
        //                     .Where(d => d.User != null &&
        //                            d.User.FullName.ToLower().Contains(name.ToLower()))
        //                     .ToList();
        //}

        //// Cập nhật thông tin và kiểm tra logic
        //public string UpdateProfile(int userId, string cccd, string cchn, string exp, int clinicId, int specId, string workingTime)
        //{
        //    if (string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(cchn))
        //        return "Vui lòng nhập đầy đủ CCCD và Mã chứng chỉ hành nghề!";
        //    // 1. Sửa tên biến thành Experience_Years theo DTO mới
        //    if (doctor.Experience_Years < 0) return "Số năm kinh nghiệm không hợp lệ!";

        //    // 2. Kiểm tra FullName thông qua đối tượng User
        //    if (doctor.User == null || string.IsNullOrEmpty(doctor.User.FullName))
        //        return "Tên bác sĩ không được để trống!";

        //    if (cccd.Length != 12) return "CCCD không hợp lệ!";

        //    bool result = doctorDAL.UpdateDoctor(doctor);
        //    return result ? "Cập nhật thành công!" : "Cập nhật thất bại, vui lòng kiểm tra lại!";
        //}
    }
} 

