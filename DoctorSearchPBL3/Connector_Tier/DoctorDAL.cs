using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        private readonly AppDbContext _context = new AppDbContext();

        // 1. Lấy danh sách bác sĩ kèm theo TẤT CẢ chuyên khoa (N-N)
        public List<DoctorDTO> GetAllDoctors()
        {
            return _context.Doctors
                .Include(d => d.User)        // Bốc thông tin User
                .Include(d => d.Location)    // Bốc thông tin khu vực
                .Include(d => d.DoctorSpecialties) // Bốc bảng nối N-N
                    .ThenInclude(ds => ds.Specialty) // Bốc tên chuyên khoa từ bảng nối
                .Where(d => d.IsApproved)    // Chỉ lấy bác sĩ đã duyệt
                .ToList();
        }

        // 2. Cập nhật thông tin (Dùng EF Core cực gọn)
        public bool UpdateDoctor(DoctorDTO doctor)
        {
            try
            {
                _context.Doctors.Update(doctor);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        // 3. Tìm kiếm và Lọc (Xử lý Đa chuyên khoa và Sắp xếp Sao)
        public List<DoctorDTO> SearchDoctors(string keyword, List<string> selectedSpecs, string loc, string gender, string sortType)
        {
            using (var context = new AppDbContext())
            {
                var query = context.Doctors
                    .Include(d => d.User)
                    .Include(d => d.Location)
                    .Include(d => d.DoctorSpecialties)
                        .ThenInclude(ds => ds.Specialty)
                    .AsQueryable();

                // 1. Tìm kiếm tổng hợp: Tên OR Phòng khám OR Địa chỉ
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(d => d.User.FullName.Contains(keyword)
                                          || d.ClinicName.Contains(keyword)
                                          || d.ClinicAddress.Contains(keyword));
                }

                // 2. Lọc theo các tiêu chí khác
                if (!string.IsNullOrEmpty(loc) && loc != "Tất cả khu vực")
                    query = query.Where(d => d.Location.LocationName == loc);

                if (!string.IsNullOrEmpty(gender) && gender != "Tất cả")
                    query = query.Where(d => d.User.Gender == gender);

                // 3. Lọc chuyên khoa N-N
                if (selectedSpecs != null && selectedSpecs.Any() && !selectedSpecs.Contains("Tất cả"))
                {
                    query = query.Where(d => d.DoctorSpecialties.Any(ds => selectedSpecs.Contains(ds.Specialty.SpecialtyName)));
                }

                // 4. Sắp xếp theo Kinh nghiệm/Sao (Lưu ý: Sắp xếp sau ToList() nếu dùng thuộc tính NotMapped)
                var result = query.ToList();

                switch (sortType)
                {
                    case "Kinh nghiệm: Nhiều đến Ít":
                        return result.OrderByDescending(d => d.Experience_Years).ToList();
                    case "Đánh giá: Cao đến Thấp":
                        // AverageRating là [NotMapped], nên phải tính toán trước khi sắp xếp
                        return result.OrderByDescending(d => d.AverageRating).ToList();
                    default:
                        return result;
                }
            }
        }
    }
}