using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using static DAL_Tier.DBHelper;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        private readonly AppDbContext _context = new AppDbContext();

        public int GetDoctorIdByUserId(int userId)
        {
            using var db = new AppDbContext();
            var doctor = db.Doctors.FirstOrDefault(d => d.UserId == userId);
            return doctor != null ? doctor.Id : 0;
        }

        public DoctorDTO? GetDoctorById(int doctorId)
        {
            using var context = new AppDbContext();
            return context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Reviews)
                .Include(d => d.Certificates)
                .FirstOrDefault(d => d.Id == doctorId);
        }

        public List<AppointmentsDTO> GetTodayAppointments(int doctorId)
        {
            using var context = new AppDbContext();
            DateTime today = DateTime.Today;
            return context.Appointments
                .Include(a => a.Patient).ThenInclude(p => p.User)
                .Include(a => a.TimeSlot)
                .Where(a => a.DoctorId == doctorId && a.TimeSlot.WorkDate == today)
                .OrderBy(a => a.TimeSlot.StartTime)
                .ToList();
        }

        public int GetTotalPatientsCount(int doctorId)
        {
            using var context = new AppDbContext();
            return context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .Select(a => a.PatientId)
                .Distinct()
                .Count();
        }

        public int GetPendingAppointmentsCount(int doctorId)
        {
            using var context = new AppDbContext();
            return context.Appointments
                .Where(a => a.DoctorId == doctorId && a.Status == "Pending")
                .Count();
        }

        public List<DoctorDTO> GetAllDoctors()
        {
            return _context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .ToList();
        }

        public bool UpdateDoctor(DoctorDTO updatedDoctor)
        {
            using var context = new AppDbContext();
            try
            {
                var existingDoctor = context.Doctors
                    .Include(d => d.User)
                    .FirstOrDefault(d => d.Id == updatedDoctor.Id);

                if (existingDoctor == null)
                {
                    return false;
                }

                if (existingDoctor.User != null && updatedDoctor.User != null)
                {
                    existingDoctor.User.FullName = updatedDoctor.User.FullName;
                    existingDoctor.User.PhoneNumber = updatedDoctor.User.PhoneNumber;
                    existingDoctor.User.Dob = updatedDoctor.User.Dob;
                    existingDoctor.User.Gender = updatedDoctor.User.Gender;
                    existingDoctor.User.CCCD = updatedDoctor.User.CCCD;
                    existingDoctor.User.Residential_Address = updatedDoctor.User.Residential_Address;
                    existingDoctor.User.Picture = updatedDoctor.User.Picture;
                    existingDoctor.User.UpdatedAt = DateTime.Now;
                }

                existingDoctor.Position = updatedDoctor.Position;
                existingDoctor.ExperienceYears = updatedDoctor.ExperienceYears;
                existingDoctor.ConsultationFee = updatedDoctor.ConsultationFee;
                existingDoctor.Biography = updatedDoctor.Biography;
                existingDoctor.LicenseNumber = updatedDoctor.LicenseNumber;
                existingDoctor.DepartmentId = updatedDoctor.DepartmentId;
                existingDoctor.UpdatedAt = DateTime.Now;

                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi UpdateDoctor: " + ex.Message);
                return false;
            }
        }

        public bool UpdateRating(int doctorId, double avgRating, int totalReviews)
        {
            using var context = new AppDbContext();
            try
            {
                var doctor = context.Doctors.Find(doctorId);
                if (doctor == null)
                {
                    return false;
                }

                doctor.AverageRating = avgRating;
                doctor.TotalReviews = totalReviews;
                doctor.UpdatedAt = DateTime.Now;

                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi UpdateRating: " + ex.Message);
                return false;
            }
        }

        public bool ApproveDoctor(int doctorId, bool isApproved)
        {
            using var context = new AppDbContext();
            try
            {
                var doctor = context.Doctors.Find(doctorId);
                if (doctor == null)
                {
                    return false;
                }

                doctor.IsApproved = isApproved;
                doctor.UpdatedAt = DateTime.Now;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi ApproveDoctor: " + ex.Message);
                return false;
            }
        }

        public List<DoctorDTO> SearchDoctors(string? keyword, List<string>? departmentNames, string? gender, string? sortType)
        {
            using var context = new AppDbContext();

            var result = context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .ToList();

            if (!string.IsNullOrWhiteSpace(gender) &&
                !string.Equals(gender, "Tất cả", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(gender, "Tất cả giới tính", StringComparison.OrdinalIgnoreCase))
            {
                result = result
                    .Where(d => string.Equals(d.User?.Gender, gender, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
            {
                var selectedDepartments = new HashSet<string>(
                    departmentNames.Where(name => !string.IsNullOrWhiteSpace(name)),
                    StringComparer.OrdinalIgnoreCase);

                result = result
                    .Where(d => d.Department != null && selectedDepartments.Contains(d.Department.DepartmentName))
                    .ToList();
            }

            EnrichReviewStats(result);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var normalizedKeyword = NormalizeForSearch(keyword);

                result = result
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

            return ApplyDoctorSort(result, sortType, keyword);
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
                    fieldToken.Contains(token, StringComparison.Ordinal) 
                    // || token.Contains(fieldToken, StringComparison.Ordinal)
                    ));

            return matchedTokens > 0 ? baseScore + (matchedTokens * 5) : 0;
        }

        private static string NormalizeForSearch(string? text)
        {
            return RemoveDiacritics(text ?? string.Empty).Trim();
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

        public List<DoctorCertificateDTO> GetCertificatesByDoctorId(int doctorId)
        {
            using var context = new AppDbContext();
            return context.DoctorCertificates
                .Where(c => c.DoctorId == doctorId && !c.IsDeleted)
                .ToList();
        }

        public bool AddDoctorCertificate(DoctorCertificateDTO certificate)
        {
            using var context = new AppDbContext();
            try
            {
                certificate.Doctor = null;
                context.DoctorCertificates.Add(certificate);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi AddDoctorCertificate: " + ex);
                return false;
            }
        }

        public bool ReplaceDoctorCertificate(int doctorId, DoctorCertificateDTO newCertificate)
        {
            using var context = new AppDbContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var existingCerts = context.DoctorCertificates
                    .Where(c => c.DoctorId == doctorId && !c.IsDeleted)
                    .ToList();

                foreach (var cert in existingCerts)
                {
                    cert.IsDeleted = true;
                    cert.DeletedAt = DateTime.Now;
                    cert.IsPrimary = false;
                    context.Entry(cert).State = EntityState.Modified;
                }

                newCertificate.Doctor = null;
                context.DoctorCertificates.Add(newCertificate);

                int result = context.SaveChanges();
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                System.Diagnostics.Debug.WriteLine("Lỗi ReplaceDoctorCertificate: " + ex);
                return false;
            }
        }

        public int GetDoctorCountByDepartmentId(int departmentId, bool includeDeleted = false)
        {
            using var context = new AppDbContext();
            return context.Doctors.Count(doc =>
                doc.DepartmentId == departmentId &&
                (includeDeleted || (!doc.IsDeleted && doc.IsActive && doc.IsApproved)));
        }
    }
}
