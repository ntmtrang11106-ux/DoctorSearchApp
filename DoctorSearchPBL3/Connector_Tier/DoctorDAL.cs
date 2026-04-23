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

        // 4. QUẢN LÝ DoctorSpecialty và duy trì ExperienceSummary trên Doctor
        public bool AddDoctorSpecialty(DoctorSpecialtyDTO ds)
        {
            try
            {
                _context.DoctorSpecialties.Add(ds);
                _context.SaveChanges();
                RecalculateExperienceSummary(ds.DoctorId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateDoctorSpecialty(DoctorSpecialtyDTO ds)
        {
            try
            {
                _context.DoctorSpecialties.Update(ds);
                _context.SaveChanges();
                RecalculateExperienceSummary(ds.DoctorId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveDoctorSpecialty(int id)
        {
            try
            {
                var ds = _context.DoctorSpecialties.Find(id);
                if (ds == null) return false;
                int doctorId = ds.DoctorId;
                _context.DoctorSpecialties.Remove(ds);
                _context.SaveChanges();
                RecalculateExperienceSummary(doctorId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void RecalculateExperienceSummary(int doctorId)
        {
            var maxExp = _context.DoctorSpecialties
                .Where(ds => ds.DoctorId == doctorId && ds.Experience_Years.HasValue)
                .Select(ds => ds.Experience_Years.Value)
                .DefaultIfEmpty(0)
                .Max();

            var doctor = _context.Doctors.Find(doctorId);
            if (doctor != null)
            {
                doctor.ExperienceSummary = maxExp > 0 ? (int?)maxExp : null;
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
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
                        // Nếu đang lọc theo chuyên khoa cụ thể(s), sắp xếp theo kinh nghiệm của bác sĩ trong
                        // chính chuyên khoa đó (nếu có). Nếu bác sĩ không có kinh nghiệm trong chuyên khoa
                        // đã chọn, fallback về kinh nghiệm lớn nhất của bác sĩ.
                        if (selectedSpecs != null && selectedSpecs.Any() && !selectedSpecs.Contains("Tất cả"))
                        {
                            return result.OrderByDescending(d =>
                                (d.DoctorSpecialties != null && d.DoctorSpecialties.Any(ds => selectedSpecs.Contains(ds.Specialty.SpecialtyName)))
                                    ? d.DoctorSpecialties.Where(ds => selectedSpecs.Contains(ds.Specialty.SpecialtyName)).Max(ds => ds.Experience_Years ?? 0)
                                    : (d.DoctorSpecialties != null && d.DoctorSpecialties.Any() ? d.DoctorSpecialties.Max(ds => ds.Experience_Years ?? 0) : 0)
                            ).ToList();
                        }

                        // Không lọc theo chuyên khoa -> sắp xếp theo kinh nghiệm dài nhất của bác sĩ
                        return result.OrderByDescending(d => d.Experience_Years ?? 0).ToList();
                    case "Đánh giá: Cao đến Thấp":
                        // AverageRating là [NotMapped], nên phải tính toán trước khi sắp xếp
                        return result.OrderByDescending(d => d.AverageRating).ToList();
                    default:
                        return result;
                }
            }
        }

        // Trong DoctorDAL.cs
        public int GetDoctorIdByUserId(int userId)
        {
            using (var db = new AppDbContext()) // Hoặc cách gọi DB của nhóm
            {
                var doctor = db.Doctors.FirstOrDefault(d => d.UserId == userId);
                return doctor != null ? doctor.Id : 0;
            }
        }
    }
}