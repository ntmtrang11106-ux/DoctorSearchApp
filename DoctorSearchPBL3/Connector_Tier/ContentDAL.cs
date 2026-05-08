using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using static DAL_Tier.DBHelper;

namespace DAL_Tier
{
    public class ContentDAL
    {
        public List<ContentDTO> SearchContents(
            string? keyword,
            List<string>? departmentNames,
            string? sortType,
            string? contentType = null)
        {
            using var context = new AppDbContext();

            var query = context.Contents
                .Include(c => c.Department)
                .Include(c => c.AuthorAdmin)
                    .ThenInclude(a => a.User)
                .Where(c => !c.IsDeleted && c.Status == "Published");

            if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
            {
                query = query.Where(c => c.Department != null && departmentNames.Contains(c.Department.DepartmentName));
            }

            if (!string.IsNullOrWhiteSpace(contentType) && !string.Equals(contentType, "Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(c => c.ContentType == contentType);
            }

            var results = query.ToList();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var normalizedKeyword = NormalizeForSearch(keyword);

                results = results
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
                "Mới nhất" => results.OrderByDescending(c => c.PublishedAt ?? c.CreatedAt).ToList(),
                "Xem nhiều nhất" => results.OrderByDescending(c => c.ViewCount).ToList(),
                "Xem ít nhất" => results.OrderBy(c => c.ViewCount).ToList(),
                _ when string.IsNullOrWhiteSpace(keyword) => results.OrderByDescending(c => c.PublishedAt ?? c.CreatedAt).ToList(),
                _ => results
                    .OrderByDescending(c => c.IsPinned)
                    .ThenByDescending(c => c.Priority)
                    .ThenByDescending(c => c.PublishedAt ?? c.CreatedAt)
                    .ToList()
            };
        }

        public List<ContentDTO> GetAllContents()
        {
            using var context = new AppDbContext();

            return context.Contents
                .Include(c => c.Department)
                .Include(c => c.AuthorAdmin)
                    .ThenInclude(a => a.User)
                .Where(c => !c.IsDeleted && c.Status == "Published")
                .OrderByDescending(c => c.IsPinned)
                .ThenByDescending(c => c.Priority)
                .ThenByDescending(c => c.PublishedAt ?? c.CreatedAt)
                .ToList();
        }

        private static int CalculateContentSearchScore(ContentDTO content, string normalizedKeyword)
        {
            if (string.IsNullOrWhiteSpace(normalizedKeyword))
            {
                return 1;
            }

            var title = NormalizeForSearch(content.Title);
            return ScoreField(title, normalizedKeyword, 120);
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
    }
}
