using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        // Không dùng shared _context làm field — mỗi method tự quản lý context
        // để đảm bảo Dispose đúng cách và tránh conflict giữa các context.

        public List<DoctorDTO> GetAllDoctors()
        {
            using var context = new AppDbContext();
            return context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .ToList();
        }

        public bool UpdateDoctor(DoctorDTO doctor)
        {
            using var context = new AppDbContext();
            try
            {
                context.Doctors.Update(doctor);
                return context.SaveChanges() > 0;
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

            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(d => d.User != null && d.User.FullName.Contains(keyword));

            if (!string.IsNullOrWhiteSpace(gender) && gender != "Tất cả")
                query = query.Where(d => d.User != null && d.User.Gender == gender);

            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
                query = query.Where(d => d.Department != null && departmentNames.Contains(d.Department.DepartmentName));

            query = sortType switch
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