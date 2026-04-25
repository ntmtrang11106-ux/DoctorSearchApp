using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class ReviewBUS
    {
        private readonly ReviewDAL _reviewDAL = new ReviewDAL();

        // 1. Lấy danh sách lịch hẹn đã hoàn thành — chưa đánh giá
        public List<AppointmentsDTO> GetPendingReviewAppointments(int patientId)
        {
            return _reviewDAL.GetCompletedAppointmentsByPatient(patientId);
        }

        // 2. Xử lý gửi đánh giá — validate + lưu
        public (bool Success, string Message) SubmitReview(
            int appointmentId,
            int patientId,
            int doctorId,
            int rating,
            string comment)
        {
            // ── VALIDATE theo đặc tả UC102 ──

            // Tiền điều kiện: lịch hẹn phải hợp lệ
            var appointment = _reviewDAL.GetCompletedAppointment(appointmentId, patientId);
            if (appointment == null)
                return (false, "Lịch hẹn không hợp lệ hoặc chưa hoàn thành.");

            // Kiểm tra đã đánh giá chưa (tránh duplicate)
            if (_reviewDAL.IsAlreadyReviewed(appointmentId))
                return (false, "Bạn đã đánh giá lịch hẹn này rồi.");

            // Luồng 5a: Bắt buộc phải chọn sao
            if (rating < 1 || rating > 5)
                return (false, "Vui lòng chọn số sao từ 1 đến 5.");

            // Validate comment: tối đa 1000 ký tự (theo bảng dữ liệu đầu vào)
            if (!string.IsNullOrEmpty(comment) && comment.Length > 1000)
                return (false, "Nội dung nhận xét không được vượt quá 1000 ký tự.");

            // ── LƯU VÀO DB ──
            var review = new ReviewsDTO
            {
                AppointmentId = appointmentId,
                PatientID = patientId,
                DoctorID = doctorId,
                Rating = rating,
                Comment = comment?.Trim(),
                IsVisible = true,
                CreatedAt = DateTime.Now
            };

            bool saved = _reviewDAL.SaveReview(review);

            return saved
                ? (true, "Cảm ơn bạn đã gửi phản hồi!")   // Luồng 6
                : (false, "Gửi đánh giá thất bại, vui lòng thử lại.");
        }

        // 3. Lấy đánh giá + tính điểm trung bình để hiển thị hồ sơ bác sĩ
        public (List<ReviewsDTO> Reviews, double AverageRating, int TotalReviews)
            GetDoctorReviews(int doctorId)
        {
            var reviews = _reviewDAL.GetReviewsByDoctor(doctorId);

            if (reviews.Count == 0)
                return (reviews, 0, 0);

            double avg = Math.Round(
                reviews.Average(r => r.Rating), 1);

            return (reviews, avg, reviews.Count);
        }
    }
}