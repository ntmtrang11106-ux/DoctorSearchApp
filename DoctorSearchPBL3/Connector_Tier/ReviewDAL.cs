using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class ReviewDAL
    {
        public AppointmentsDTO? GetCompletedAppointment(int appointmentId, int patientId)
        {
            using var context = new AppDbContext();

            return context.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Include(a => a.Patient)
                .FirstOrDefault(a =>
                    a.Id == appointmentId &&
                    a.PatientId == patientId &&
                    a.Status == "Completed");
        }

        public List<AppointmentsDTO> GetCompletedAppointmentsByPatient(int patientId)
        {
            using var context = new AppDbContext();

            var reviewedDoctorIds = context.Reviews
                .Where(r => r.PatientId == patientId && !r.IsDeleted)
                .Select(r => r.DoctorId)
                .ToHashSet();

            return context.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Where(a =>
                    a.PatientId == patientId &&
                    a.Status == "Completed" &&
                    !reviewedDoctorIds.Contains(a.DoctorId))
                .OrderByDescending(a => a.CreatedAt)
                .ToList();
        }

        public bool SaveReview(ReviewsDTO review)
        {
            using var context = new AppDbContext();
            try
            {
                context.Reviews.Add(review);
                return context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<ReviewsDTO> GetReviewsByDoctor(int doctorId)
        {
            using var context = new AppDbContext();

            return context.Reviews
                .Include(r => r.Patient)
                    .ThenInclude(p => p.User)
                .Where(r => r.DoctorId == doctorId && r.IsVisible && !r.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
        }

        public bool IsAlreadyReviewed(int patientId, int doctorId)
        {
            using var context = new AppDbContext();
            return context.Reviews.Any(r => r.PatientId == patientId && r.DoctorId == doctorId && !r.IsDeleted);
        }
    }
}
