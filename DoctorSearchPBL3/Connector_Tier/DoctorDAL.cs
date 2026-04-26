using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<DoctorDTO> GetAllDoctors()
        {
            return _context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .ToList();
        }

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

        public List<DoctorDTO> SearchDoctors(string? keyword, List<string>? departmentNames, string? gender, string? sortType)
        {
            using var context = new AppDbContext();

            var query = context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(d => d.User != null && d.User.FullName.Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(gender) && gender != "Tất cả")
            {
                query = query.Where(d => d.User != null && d.User.Gender == gender);
            }

            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
            {
                query = query.Where(d => d.Department != null && departmentNames.Contains(d.Department.DepartmentName));
            }

            var result = query.ToList();

            foreach (var doctor in result)
            {
                var visibleReviews = doctor.Reviews?.Where(r => r.IsVisible && !r.IsDeleted).ToList() ?? new List<ReviewsDTO>();
                doctor.TotalReviews = visibleReviews.Count;
                doctor.AverageRating = visibleReviews.Any() ? Math.Round(visibleReviews.Average(r => r.Rating), 1) : 0;
            }

            return sortType switch
            {
                "Giá khám thấp đến cao" => result.OrderBy(d => d.ConsultationFee ?? decimal.MaxValue).ToList(),
                "Giá khám cao đến thấp" => result.OrderByDescending(d => d.ConsultationFee ?? 0).ToList(),
                "Năm kinh nghiệm cao đến thấp" => result.OrderByDescending(d => d.ExperienceYears ?? 0).ToList(),
                "Rating cao đến thấp" => result.OrderByDescending(d => d.AverageRating).ToList(),
                _ => result
            };
        }
    }
}
