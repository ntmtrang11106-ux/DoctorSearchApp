using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class ReviewBUS
    {
        private readonly ReviewDAL _reviewDAL = new ReviewDAL();

        public List<AppointmentsDTO> GetPendingReviewAppointments(int patientId)
        {
            return _reviewDAL.GetCompletedAppointmentsByPatient(patientId);
        }

        public (bool Success, string Message) SubmitReview(
            int appointmentId,
            int patientId,
            int doctorId,
            int rating,
            string? comment)
        {
            var appointment = _reviewDAL.GetCompletedAppointment(appointmentId, patientId);
            if (appointment == null)
            {
                return (false, "Lịch hẹn không hợp lệ hoặc chưa hoàn thành.");
            }

            if (_reviewDAL.IsAlreadyReviewed(patientId, doctorId))
            {
                return (false, "Bạn đã đánh giá bác sĩ này rồi.");
            }

            if (rating < 1 || rating > 5)
            {
                return (false, "Vui lòng chọn số sao từ 1 đến 5.");
            }

            if (!string.IsNullOrEmpty(comment) && comment.Length > 1000)
            {
                return (false, "Nội dung nhận xét không được vượt quá 1000 ký tự.");
            }

            var review = new ReviewsDTO
            {
                PatientId = patientId,
                DoctorId = doctorId,
                Rating = rating,
                Comment = comment?.Trim(),
                IsVisible = true,
                CreatedAt = DateTime.Now
            };

            bool saved = _reviewDAL.SaveReview(review);
            return saved
                ? (true, "Cảm ơn bạn đã gửi phản hồi!")
                : (false, "Gửi đánh giá thất bại, vui lòng thử lại.");
        }

        public (List<ReviewsDTO> Reviews, double AverageRating, int TotalReviews) GetDoctorReviews(int doctorId)
        {
            var reviews = _reviewDAL.GetReviewsByDoctor(doctorId);
            if (reviews.Count == 0)
            {
                return (reviews, 0, 0);
            }

            double avg = Math.Round(reviews.Average(r => r.Rating), 1);
            return (reviews, avg, reviews.Count);
        }
    }
}
