using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class ContentDAL
    {
        public List<ContentDTO> SearchContents(string? keyword, List<string>? departmentNames, string? sortType)
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
            using var context = new AppDbContext();

            return context.Contents
                .Include(c => c.Department)
                .Include(c => c.AuthorAdmin)
                    .ThenInclude(a => a.User)
                .Where(c => !c.IsDeleted)
                .ToList();
        }
    }
}
