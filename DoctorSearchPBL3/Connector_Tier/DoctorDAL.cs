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
            using (var db = new AppDbContext()) 
            {
                var doctor = db.Doctors.FirstOrDefault(d => d.UserId == userId);
                return doctor != null ? doctor.Id : 0;
            }
        }

        public DoctorDTO GetDoctorById(int doctorId)
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
                .Include(d => d.User) // Kết nối bảng User (để lấy FullName, Picture)
                .Include(d => d.Department) // Kết nối bảng Department (để lấy tên Chuyên khoa)
                .Include(d => d.Reviews)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
                .ToList();
        }


        //////////////////////////////////////////////////
        

        public bool UpdateDoctor(DoctorDTO updatedDoctor)
        {
            using var context = new AppDbContext();
            try
            {
                var existingDoctor = context.Doctors
                    .Include(d => d.User)
                    .FirstOrDefault(d => d.Id == updatedDoctor.Id);

                if (existingDoctor == null) return false;

                // 1. Update User info
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

                // 2. Update Doctor info
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
                if (doctor == null) return false;

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
                if (doctor == null) return false;

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
                // Đảm bảo không đính kèm đối tượng Doctor để tránh lỗi conflict context nếu có
                certificate.Doctor = null; 
                context.DoctorCertificates.Add(certificate);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                // Log chi tiết lỗi để debug
                System.Diagnostics.Debug.WriteLine("Lỗi AddDoctorCertificate: " + ex.ToString());
                return false;
            }
        }
        public bool ReplaceDoctorCertificate(int doctorId, DoctorCertificateDTO newCertificate)
        {
            using var context = new AppDbContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                // 1. Mark all existing certificates as deleted
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

                // 2. Add the new one
                newCertificate.Doctor = null; // Avoid attachment issues
                context.DoctorCertificates.Add(newCertificate);

                int result = context.SaveChanges();
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                System.Diagnostics.Debug.WriteLine("Lỗi ReplaceDoctorCertificate: " + ex.ToString());
                return false;
            }
        }
    }
}