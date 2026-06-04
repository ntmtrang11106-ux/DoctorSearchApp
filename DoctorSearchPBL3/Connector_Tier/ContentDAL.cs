using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using static DAL_Tier.DBHelper;

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

            if (!string.IsNullOrWhiteSpace(status) && !string.Equals(status, "Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(c => c.Status == status);
            }
            else if (string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(c => c.Status == "Published");
            }

            if (!string.IsNullOrWhiteSpace(contentType) && !string.Equals(contentType, "Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(c => c.ContentType == contentType);
            }

            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
            {
                var selectedDepartments = departmentNames
                    .Where(name => !string.IsNullOrWhiteSpace(name))
                    .ToList();

                query = query.Where(c => c.Department != null && selectedDepartments.Contains(c.Department.DepartmentName));
            }

            var result = query.ToList();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var normalizedKeyword = NormalizeForSearch(keyword);

                result = result
                    .Select(content => new
                    {
                        Content = content,
                        Score = CalculateContentSearchScore(content, normalizedKeyword)
                    })
                    .Where(x => x.Score > 0)
                    .OrderByDescending(x => x.Score)
                    .ThenByDescending(x => x.Content.IsPinned)
                    .ThenByDescending(x => x.Content.Priority)
                    .ThenByDescending(x => x.Content.PublishedAt ?? x.Content.CreatedAt)
                    .Select(x => x.Content)
                    .ToList();
            }

            return sortType switch
            {
                "Mới nhất" => result.OrderByDescending(c => c.PublishedAt ?? c.CreatedAt).ToList(),
                "Xem nhiều nhất" => result.OrderByDescending(c => c.ViewCount).ToList(),
                "Xem ít nhất" => result.OrderBy(c => c.ViewCount).ToList(),
                _ when string.IsNullOrWhiteSpace(keyword) => result.OrderByDescending(c => c.PublishedAt ?? c.CreatedAt).ToList(),
                _ => result
                    .OrderByDescending(c => c.IsPinned)
                    .ThenByDescending(c => c.Priority)
                    .ThenByDescending(c => c.PublishedAt ?? c.CreatedAt)
                    .ToList()
            };
        }

        private static int CalculateContentSearchScore(ContentDTO content, string normalizedKeyword)
        {
            if (string.IsNullOrWhiteSpace(normalizedKeyword))
            {
                return 1;
            }

            var title = NormalizeForSearch(content.Title);
            var summary = NormalizeForSearch(content.Summary);

            return ScoreField(title, normalizedKeyword, 120)
                + ScoreField(summary, normalizedKeyword, 40);
        }

        private static int ScoreField(string? fieldValue, string keyword, int baseScore)
        {
            if (string.IsNullOrWhiteSpace(fieldValue) || string.IsNullOrWhiteSpace(keyword))
            {
                return 0;
            }

            if (fieldValue == keyword)
            {
                return baseScore + 40;
            }

            if (fieldValue.StartsWith(keyword, StringComparison.Ordinal))
            {
                return baseScore + 30;
            }

            if (fieldValue.Contains(keyword, StringComparison.Ordinal))
            {
                return baseScore + 20;
            }

            var keywordTokens = keyword.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (keywordTokens.Length == 0)
            {
                return 0;
            }

            var matchedTokens = keywordTokens.Count(token => fieldValue.Contains(token, StringComparison.Ordinal));
            return matchedTokens > 0 ? baseScore + (matchedTokens * 5) : 0;
        }

        private static string NormalizeForSearch(string? text)
        {
            return RemoveDiacritics(text ?? string.Empty).Trim();
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
