using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class ReviewBUS
    {
        private readonly ReviewDAL _reviewDAL = new ReviewDAL();
        private readonly DoctorDAL _doctorDAL = new DoctorDAL();

        public bool AddReview(ReviewsDTO review)
        {
            if (review == null || review.PatientId <= 0 || review.DoctorId <= 0 || review.Rating <= 0)
                return false;

            bool success = _reviewDAL.Add(review);
            
            if (success)
            {
                // Sau khi thêm review thành công, nên cập nhật lại AverageRating và TotalReviews của Doctor
                UpdateDoctorRating(review.DoctorId);
            }
            
            return success;
        }

        public List<ReviewsDTO> GetReviewsByDoctorId(int doctorId)
        {
            if (doctorId <= 0) return new List<ReviewsDTO>();
            return _reviewDAL.GetReviewsByDoctorId(doctorId);
        }

        /// <summary>Cập nhật nội dung đánh giá (rating, comment). Chỉ cho phép chủ nhân của review.</summary>
        public bool UpdateReview(int reviewId, int newRating, string newComment, int doctorId)
        {
            if (reviewId <= 0 || newRating < 1 || newRating > 5) return false;

            bool success = _reviewDAL.UpdateReview(reviewId, newRating, newComment);
            if (success) UpdateDoctorRating(doctorId);
            return success;
        }

        /// <summary>Xóa mềm một đánh giá. Chỉ cho phép chủ nhân của review.</summary>
        public bool DeleteReview(int reviewId, int doctorId)
        {
            if (reviewId <= 0) return false;

            bool success = _reviewDAL.DeleteReview(reviewId);
            if (success) UpdateDoctorRating(doctorId);
            return success;
        }

        private void UpdateDoctorRating(int doctorId)
        {
            try
            {
                var reviews = _reviewDAL.GetReviewsByDoctorId(doctorId);
                if (reviews.Count > 0)
                {
                    double avg = 0;
                    foreach (var r in reviews) avg += r.Rating;
                    avg = avg / reviews.Count;

                    // Cập nhật vào bảng Doctor (giả sử DoctorDAL có hàm UpdateRating)
                    _doctorDAL.UpdateRating(doctorId, avg, reviews.Count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi UpdateDoctorRating: " + ex.Message);
            }
        }
    }
}
