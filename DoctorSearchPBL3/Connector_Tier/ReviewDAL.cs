using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class ReviewDAL
    {
        private readonly AppDbContext _context = new AppDbContext();

        public bool Add(ReviewsDTO review)
        {
            try
            {
                _context.Reviews.Add(review);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ReviewDAL.Add: " + ex.Message);
                return false;
            }
        }

        public List<ReviewsDTO> GetReviewsByDoctorId(int doctorId)
        {
            try
            {
                return _context.Reviews
                    .Where(r => r.DoctorId == doctorId && !r.IsDeleted && r.IsVisible)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ReviewDAL.GetReviewsByDoctorId: " + ex.Message);
                return new List<ReviewsDTO>();
            }
        }

        /// <summary>Cập nhật rating và comment của một đánh giá.</summary>
        public bool UpdateReview(int reviewId, int newRating, string newComment)
        {
            try
            {
                var existing = _context.Reviews.Find(reviewId);
                if (existing == null || existing.IsDeleted) return false;

                existing.Rating    = newRating;
                existing.Comment   = newComment;
                existing.UpdatedAt = DateTime.Now;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ReviewDAL.UpdateReview: " + ex.Message);
                return false;
            }
        }

        /// <summary>Xóa mềm (soft-delete) một đánh giá theo Id.</summary>
        public bool DeleteReview(int reviewId)
        {
            try
            {
                var existing = _context.Reviews.Find(reviewId);
                if (existing == null || existing.IsDeleted) return false;

                existing.IsDeleted = true;
                existing.DeletedAt = DateTime.Now;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ReviewDAL.DeleteReview: " + ex.Message);
                return false;
            }
        }
    }
}
