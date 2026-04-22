using DTO_Tier;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_Tier
{
    public class ArticleDAL
    {
        public List<ArticlesDTO> SearchArticles(string keyword, List<string> selectedSpecs, string sortType)
        {
            using (var context = new AppDbContext())
            {
                // 1. Khởi tạo truy vấn kèm theo bảng nối Chuyên khoa
                var query = context.Articles
                    .Include(a => a.Author)
                    .Include(a => a.ArticleSpecialties)
                        .ThenInclude(aspec => aspec.Specialty)
                    .AsQueryable();

                // 2. Lọc theo từ khóa trong Tiêu đề
                if (!string.IsNullOrEmpty(keyword))
                    query = query.Where(a => a.Title.Contains(keyword));

                // 3. Lọc đa chuyên khoa (N-N)
                if (selectedSpecs != null && selectedSpecs.Any() && !selectedSpecs.Contains("Tất cả"))
                {
                    query = query.Where(a => a.ArticleSpecialties.Any(aspec => selectedSpecs.Contains(aspec.Specialty.SpecialtyName)));
                }

                // 4. Sắp xếp linh hoạt theo ý Trang
                switch (sortType)
                {
                    case "Mới nhất":
                        query = query.OrderByDescending(a => a.CreatedAt);
                        break;
                    case "Xem nhiều nhất":
                        query = query.OrderByDescending(a => a.Views);
                        break;
                    case "Xem ít nhất":
                        query = query.OrderBy(a => a.Views);
                        break;
                    default:
                        query = query.OrderByDescending(a => a.CreatedAt);
                        break;
                }

                return query.ToList();
            }
        }
        // Cách lấy Bài viết kèm tất cả Chuyên khoa bằng EF Core (CodeFirst)
        public List<ArticlesDTO> GetAllArticles()
        {
            using (var context = new AppDbContext())
            {
                return context.Articles
                    .Include(a => a.Author)
                    .Include(a => a.ArticleSpecialties) // Bốc bảng nối
                        .ThenInclude(aspec => aspec.Specialty) // Bốc tên chuyên khoa từ bảng nối đó
                    .ToList();
            }
        }
    }
}
