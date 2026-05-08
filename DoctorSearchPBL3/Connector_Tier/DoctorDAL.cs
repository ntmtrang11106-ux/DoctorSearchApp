using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using static DAL_Tier.DBHelper;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        public int GetDoctorIdByUserId(int userId)
        {
            using var context = new AppDbContext();
            return context.Doctors
                .Where(d => d.UserId == userId)
                .Select(d => d.Id)
                .FirstOrDefault();
        }

        public List<DoctorDTO> GetAllDoctors()
        {
            using var context = new AppDbContext();

            var doctors = context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .OrderByDescending(d => d.CreatedAt)
                .ToList();

            EnrichReviewStats(doctors);
            return doctors;
        }

        public bool UpdateDoctor(DoctorDTO doctor)
        {
            using var context = new AppDbContext();

            try
            {
                doctor.UpdatedAt = DateTime.Now;
                context.Doctors.Update(doctor);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Loi UpdateDoctor: " + ex.Message);
                return false;
            }
        }

        public List<DoctorDTO> SearchDoctors(
            string? keyword,
            List<string>? departmentNames,
            string? gender,
            string? sortType)
        {
            using var context = new AppDbContext();

            var doctors = context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .ToList();

            if (!string.IsNullOrWhiteSpace(gender) && !string.Equals(gender, "Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                doctors = doctors
                    .Where(d => string.Equals(d.User?.Gender, gender, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
            {
                var selectedDepartments = new HashSet<string>(
                    departmentNames.Where(name => !string.IsNullOrWhiteSpace(name)),
                    StringComparer.OrdinalIgnoreCase);

                doctors = doctors
                    .Where(d => d.Department != null && selectedDepartments.Contains(d.Department.DepartmentName))
                    .ToList();
            }

            EnrichReviewStats(doctors);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var normalizedKeyword = NormalizeForSearch(keyword);

                doctors = doctors
                    .Select(d => new
                    {
                        Doctor = d,
                        Score = CalculateDoctorSearchScore(d, normalizedKeyword)
                    })
                    .Where(x => x.Score > 0)
                    .OrderByDescending(x => x.Score)
                    .ThenByDescending(x => x.Doctor.AverageRating)
                    .ThenByDescending(x => x.Doctor.ExperienceYears ?? 0)
                    .ThenBy(x => x.Doctor.User?.FullName)
                    .Select(x => x.Doctor)
                    .ToList();
            }

            return ApplyDoctorSort(doctors, sortType, keyword);
        }

        private static List<DoctorDTO> ApplyDoctorSort(List<DoctorDTO> doctors, string? sortType, string? keyword)
        {
            return sortType switch
            {
                "Giá khám thấp đến cao" => doctors.OrderBy(d => d.ConsultationFee ?? decimal.MaxValue).ToList(),
                "Giá khám cao đến thấp" => doctors.OrderByDescending(d => d.ConsultationFee ?? 0).ToList(),
                "Năm kinh nghiệm cao đến thấp" => doctors.OrderByDescending(d => d.ExperienceYears ?? 0).ToList(),
                "Rating cao đến thấp" => doctors.OrderByDescending(d => d.AverageRating).ThenByDescending(d => d.TotalReviews).ToList(),
                _ when string.IsNullOrWhiteSpace(keyword) => doctors.OrderByDescending(d => d.CreatedAt).ToList(),
                _ => doctors
                    .OrderByDescending(d => d.AverageRating)
                    .ThenByDescending(d => d.TotalReviews)
                    .ThenBy(d => d.User?.FullName)
                    .ToList()
            };
        }

        private static void EnrichReviewStats(IEnumerable<DoctorDTO> doctors)
        {
            foreach (var doctor in doctors)
            {
                var visibleReviews = doctor.Reviews?
                    .Where(r => r.IsVisible && !r.IsDeleted)
                    .ToList() ?? new List<ReviewsDTO>();

                doctor.TotalReviews = visibleReviews.Count;
                doctor.AverageRating = visibleReviews.Count == 0
                    ? 0
                    : Math.Round(visibleReviews.Average(r => r.Rating), 1);
            }
        }

        private static int CalculateDoctorSearchScore(DoctorDTO doctor, string normalizedKeyword)
        {
            if (string.IsNullOrWhiteSpace(normalizedKeyword))
            {
                return 1;
            }

            var name = NormalizeForSearch(doctor.User?.FullName);
            return ScoreField(name, normalizedKeyword, 120);
        }

        private static int ScoreField(string? fieldValue, string keyword, int baseScore)
        {
            if (string.IsNullOrWhiteSpace(fieldValue) || string.IsNullOrWhiteSpace(keyword))
            {
                return 0;
            }

            if (fieldValue == keyword)
            {
                return baseScore + 40;
            }

            if (fieldValue.StartsWith(keyword, StringComparison.Ordinal))
            {
                return baseScore + 30;
            }

            if (fieldValue.Contains(keyword, StringComparison.Ordinal))
            {
                return baseScore + 20;
            }

            var keywordTokens = keyword.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (keywordTokens.Length == 0)
            {
                return 0;
            }

            var fieldTokens = fieldValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var matchedTokens = keywordTokens.Count(token =>
                fieldTokens.Any(fieldToken =>
                    fieldToken.Contains(token, StringComparison.Ordinal) ||
                    token.Contains(fieldToken, StringComparison.Ordinal)));

            return matchedTokens > 0 ? baseScore + (matchedTokens * 5) : 0;
        }
        private static string NormalizeForSearch(string? text)
        {
            return RemoveDiacritics(text ?? string.Empty).Trim();
        }
    }
}
