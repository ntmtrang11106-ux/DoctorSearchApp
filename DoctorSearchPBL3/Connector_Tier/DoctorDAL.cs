using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        // Không dùng shared _context làm field — mỗi method tự quản lý context
        // để đảm bảo Dispose đúng cách và tránh conflict giữa các context.
        private readonly AppDbContext _context = new AppDbContext();

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
                .Include(d => d.Reviews) // Cần Include để tính toán Rating bên dưới
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .AsQueryable();

            // 1. Lọc theo từ khóa
            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(d => d.User != null && d.User.FullName.Contains(keyword));

            // 2. Lọc theo giới tính
            if (!string.IsNullOrWhiteSpace(gender) && gender != "Tất cả")
                query = query.Where(d => d.User != null && d.User.Gender == gender);

            // 3. Lọc theo danh sách chuyên khoa
            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
                query = query.Where(d => d.Department != null && departmentNames.Contains(d.Department.DepartmentName));

            // Chuyển dữ liệu về List để tính toán Rating (Client-side)
            var result = query.ToList();

            // 4. Tính toán Rating và TotalReviews
            foreach (var doctor in result)
            {
                var visibleReviews = doctor.Reviews?.Where(r => r.IsVisible && !r.IsDeleted).ToList() ?? new List<ReviewsDTO>();
                doctor.TotalReviews = visibleReviews.Count;
                doctor.AverageRating = visibleReviews.Any() ? Math.Round(visibleReviews.Average(r => r.Rating), 1) : 0;
            }

            // 5. Sắp xếp trên danh sách đã tính toán 'result'
            return sortType switch
            {
                "Giá khám thấp đến cao" => result.OrderBy(d => d.ConsultationFee ?? decimal.MaxValue).ToList(),
                "Giá khám cao đến thấp" => result.OrderByDescending(d => d.ConsultationFee ?? 0).ToList(),
                "Năm kinh nghiệm cao đến thấp" => result.OrderByDescending(d => d.ExperienceYears ?? 0).ToList(),
                "Rating cao đến thấp" => result.OrderByDescending(d => d.AverageRating).ToList(),
                _ => result.OrderByDescending(d => d.CreatedAt).ToList()
            };
        }

        public List<ReviewsDTO> GetDoctorReviews(int doctorId)
        {
            using var context = new AppDbContext();
            return context.Reviews
                .Include(r => r.Patient)
                    .ThenInclude(p => p.User)
                .Where(r => r.DoctorId == doctorId && r.IsVisible && !r.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
        }
    }
}