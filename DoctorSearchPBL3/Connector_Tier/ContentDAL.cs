using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class ContentDAL
    {
        public List<ContentDTO> SearchContents(string? keyword, List<string>? departmentNames, string? contentType, string? sortType, string? status = null)
        {
            using var context = new AppDbContext();

            var query = context.Contents
                .Include(c => c.Department)
                .Include(c => c.AuthorAdmin)
                    .ThenInclude(a => a.User)
                .Where(c => !c.IsDeleted)
                .AsQueryable();

            // Status filter
            if (!string.IsNullOrWhiteSpace(status) && status != "Tất cả")
            {
                query = query.Where(c => c.Status == status);
            }
            else if (string.IsNullOrWhiteSpace(status))
            {
                // Default behavior for patients (if status not specified)
                query = query.Where(c => c.Status == "Published");
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(c => EF.Functions.Collate(c.Title, "SQL_Latin1_General_CP1_CI_AI").Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(contentType) && contentType != "Tất cả")
            {
                query = query.Where(c => c.ContentType == contentType);
            }

            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
            {
                query = query.Where(c => c.Department != null && departmentNames.Contains(c.Department.DepartmentName));
            }

            query = sortType switch
            {
                "Mới nhất" => query.OrderByDescending(c => c.PublishedAt ?? c.CreatedAt),
                "Xem nhiều nhất" => query.OrderByDescending(c => c.ViewCount),
                "Xem ít nhất" => query.OrderBy(c => c.ViewCount),
                _ => query.OrderByDescending(c => c.PublishedAt ?? c.CreatedAt)
            };

            return query.ToList();
        }
        public List<ContentDTO> GetAllContents()
        {
            // Sử dụng AppDbContext bạn đã cung cấp
            using var context = new AppDbContext();

            return context.Contents
                .Include(c => c.Department)    // Load dữ liệu từ bảng Department
                .Include(c => c.AuthorAdmin)   // Load dữ liệu từ bảng Admin
                    .ThenInclude(a => a.User)  // Load tiếp dữ liệu từ bảng User để lấy FullName
                .Where(c => !c.IsDeleted)      // Lọc các bài chưa bị xóa
                .OrderByDescending(c => c.PublishedAt) // Sắp xếp theo ngày đăng (giống hình mẫu)
                .ToList();
        }

        //Tăng mắt xem
        public async Task<bool> IncrementViewAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                // Tìm bài viết theo ID
                var art = await context.Contents.FindAsync(id);
                if (art != null)
                {
                    art.ViewCount++;
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
        //Thêm bài viết mới
        public bool AddArticle(ContentDTO art)
        {
            using var context = new AppDbContext();
            
            art.CreatedAt = DateTime.Now;
            art.IsDeleted = false;
            art.ViewCount = 0;
            
            if (art.Status == "Published")
            {
                art.PublishedAt = DateTime.Now;
            }

            context.Contents.Add(art);
            return context.SaveChanges() > 0;
        }

        //Cập nhật bài viết
        public bool UpdateArticle(ContentDTO art)
        {
            using var context = new AppDbContext();
            var existing = context.Contents.Find(art.Id);
            if (existing == null) return false;

            existing.Title = art.Title;
            existing.Summary = art.Summary;
            existing.Body = art.Body;
            existing.ContentType = art.ContentType;
            existing.DepartmentId = art.DepartmentId;
            
            // Set PublishedAt if status changes to Published and it wasn't published before
            if (art.Status == "Published" && existing.Status != "Published")
            {
                existing.PublishedAt = DateTime.Now;
            }
            
            existing.Status = art.Status;
            existing.Priority = art.Priority;
            existing.IsPinned = art.IsPinned;
            existing.Thumbnail = art.Thumbnail;
            existing.UpdatedAt = DateTime.Now;

            return context.SaveChanges() > 0;
        }
        public bool DeleteArticle(int id)
        {
            using var context = new AppDbContext();
            var art = context.Contents.Find(id);
            if (art == null) return false;

            art.IsDeleted = true;
            art.DeletedAt = DateTime.Now;
            
            return context.SaveChanges() > 0;
        }
    }
}
