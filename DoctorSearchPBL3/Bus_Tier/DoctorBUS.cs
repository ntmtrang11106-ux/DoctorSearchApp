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
            var list = doctorDAL.GetAllDoctors();
            foreach (var d in list)
                CalculateDoctorStats(d);   // Gọi vào đây
            return list;
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

        // Cập nhật thông tin và kiểm tra logic
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

        //    bool success = doctorDAL.UpdateDoctorProfile(userId, cccd, cchn, exp, clinicId, specId, workingTime);
        //    return success ? "Success" : "Lỗi khi cập nhật hồ sơ bác sĩ!";
        //}
        private void CalculateDoctorStats(DoctorDTO doctor)
        {
            if (doctor.Reviews != null && doctor.Reviews.Any())
            {
                // Chỉ lấy những đánh giá được phép hiển thị theo file Word 
                var validReviews = doctor.Reviews.Where(r => r.IsVisible).ToList();

                if (validReviews.Any())
                {
                    doctor.TotalReviews = validReviews.Count;
                    doctor.AverageRating = Math.Round(validReviews.Average(r => r.Rating), 1);
                }
                else
                {
                    doctor.TotalReviews = 0;
                    doctor.AverageRating = 5.0; // Mặc định 5 sao cho chuyên nghiệp
                }
            }
        }
    }
}
