using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class ReviewDAL
    {
        // 1. Kiểm tra tiền điều kiện: Lịch hẹn phải "Thành công" và chưa được đánh giá
        public AppointmentsDTO GetCompletedAppointment(int appointmentId, int patientId)
        {
            using (var context = new AppDbContext())
            {
                return context.Appointments
                    .Include(a => a.TimeSlot)
                        .ThenInclude(ts => ts.Doctor)
                            .ThenInclude(d => d.User)
                    .Include(a => a.Patient)
                    .FirstOrDefault(a =>
                        a.Id == appointmentId &&
                        a.PatientId == patientId &&
                        a.Status == "Thành công" &&
                        // Chưa có đánh giá nào cho lịch hẹn này
                        !context.Reviews.Any(r => r.AppointmentId == appointmentId));
            }
        }

        // 2. Lấy danh sách lịch hẹn đã hoàn thành của bệnh nhân (chưa đánh giá)
        public List<AppointmentsDTO> GetCompletedAppointmentsByPatient(int patientId)
        {
            using (var context = new AppDbContext())
            {
                // Lấy các appointmentId đã có review rồi
                var reviewedIds = context.Reviews
                    .Select(r => r.AppointmentId)
                    .ToHashSet();

                return context.Appointments
                    .Include(a => a.TimeSlot)
                        .ThenInclude(ts => ts.Doctor)
                            .ThenInclude(d => d.User)
                    .Where(a =>
                        a.PatientId == patientId &&
                        a.Status == "Thành công" &&
                        !reviewedIds.Contains(a.Id))
                    .OrderByDescending(a => a.CreatedAt)
                    .ToList();
            }
        }

        // 3. Lưu đánh giá vào DB và cập nhật AverageRating của bác sĩ
        public bool SaveReview(ReviewsDTO review)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Reviews.Add(review);
                    context.SaveChanges();

                    // Cập nhật ExperienceSummary không liên quan,
                    // nhưng AverageRating là [NotMapped] nên không cần update DB
                    // — BUS sẽ tính khi load danh sách bác sĩ
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        // 4. Lấy tất cả đánh giá của 1 bác sĩ (để hiển thị trên hồ sơ)
        public List<ReviewsDTO> GetReviewsByDoctor(int doctorId)
        {
            using (var context = new AppDbContext())
            {
                return context.Reviews
                    .Include(r => r.Patient)
                        .ThenInclude(p => p.User)
                    .Where(r =>
                        r.DoctorID == doctorId &&
                        r.IsVisible == true)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToList();
            }
        }

        // 5. Kiểm tra lịch hẹn đã được đánh giá chưa
        public bool IsAlreadyReviewed(int appointmentId)
        {
            using (var context = new AppDbContext())
            {
                return context.Reviews.Any(r => r.AppointmentId == appointmentId);
            }
        }
    }
}