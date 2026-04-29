using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        // Không dùng shared _context làm field — mỗi method tự quản lý context
        // để đảm bảo Dispose đúng cách và tránh conflict giữa các context.

        // Trong DoctorDAL.cs
        public int GetDoctorIdByUserId(int userId)
        {
            using (var db = new AppDbContext()) // Hoặc cách gọi DB của nhóm
            {
                var doctor = db.Doctors.FirstOrDefault(d => d.UserId == userId);
                return doctor != null ? doctor.Id : 0;
            }
        }
        public List<DoctorDTO> GetAllDoctors()
        {
            return _context.Doctors
                .Include(d => d.User) // Kết nối bảng User (để lấy FullName, Picture)
                .Include(d => d.Department) // Kết nối bảng Department (để lấy tên Chuyên khoa)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .ToList();
        }


        //////////////////////////////////////////////////
        

        public bool UpdateDoctor(DoctorDTO doctor)
        {
            using var context = new AppDbContext();
            try
            {
                // Cập nhật thời gian UpdatedAt trước khi lưu
                doctor.UpdatedAt = DateTime.Now;
                _context.Doctors.Update(doctor);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi UpdateDoctor: " + ex.Message);
                return false;
            }
        }

        public List<DoctorDTO> SearchDoctors(string? keyword, List<string>? departmentNames, string? gender, string? sortType)
        {
            using var context = new AppDbContext();

            var query = context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .AsQueryable();

            // 1. Lọc theo từ khóa (Tên bác sĩ từ bảng User)
            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(d => d.User != null && d.User.FullName.Contains(keyword));

            // 2. Lọc theo giới tính (từ bảng User)
            if (!string.IsNullOrWhiteSpace(gender) && gender != "Tất cả")
                query = query.Where(d => d.User != null && d.User.Gender == gender);

            // 3. Lọc theo danh sách chuyên khoa
            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
                query = query.Where(d => d.Department != null && departmentNames.Contains(d.Department.DepartmentName));

            var result = query.ToList();

            // 4.Tính toán Rating và TotalReviews(Logic nghiệp vụ)
            foreach (var doctor in result)
            {
                var visibleReviews = doctor.Reviews?.Where(r => r.IsVisible && !r.IsDeleted).ToList() ?? new List<ReviewsDTO>();
                doctor.TotalReviews = visibleReviews.Count;
                doctor.AverageRating = visibleReviews.Any() ? Math.Round(visibleReviews.Average(r => r.Rating), 1) : 0;
            }

            return sortType switch
            {
                "Giá khám thấp đến cao" => query.OrderBy(d => d.ConsultationFee ?? decimal.MaxValue),
                "Giá khám cao đến thấp" => query.OrderByDescending(d => d.ConsultationFee ?? 0),
                "Năm kinh nghiệm cao đến thấp" => query.OrderByDescending(d => d.ExperienceYears ?? 0),
                "Rating cao đến thấp" => query.OrderByDescending(d => d.AverageRating),
                _ => query.OrderByDescending(d => d.CreatedAt)
            };

            return query.ToList();
        }
    }
}