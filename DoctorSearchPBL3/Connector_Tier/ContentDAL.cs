using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class ContentDAL
    {
        public List<ContentDTO> SearchContents(string? keyword, List<string>? departmentNames, string? contentType, string? sortType)
        {
            using var context = new AppDbContext();

            var query = context.Contents
                .Include(c => c.Department)
                .Include(c => c.AuthorAdmin)
                    .ThenInclude(a => a.User)
                .Where(c => !c.IsDeleted && c.Status == "Published")
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(c => c.Title.Contains(keyword));
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
    }
}
