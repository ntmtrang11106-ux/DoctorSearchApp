using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class ContentBUS
    {
        private readonly ContentDAL _contentDAL = new ContentDAL();

        public List<ContentDTO> GetInitialContents()
        {
            return _contentDAL.GetAllContents();
        }

        public string ValidateContent(ContentDTO content)
        {
            if (string.IsNullOrEmpty(content.Title)) return "Tiêu đề không được để trống!";
            if (content.Body.Length < 10) return "Nội dung quá ngắn!";
            return "OK";
        }

        public List<ContentDTO> SearchContents(
            string? keyword,
            List<string>? departments,
            string? sortType,
            string? contentType = null)
        {
            string? cleanKeyword = string.IsNullOrWhiteSpace(keyword) ? null : keyword.Trim();

            List<string>? filterDepartments = null;
            if (departments != null && departments.Count > 0 && !departments.Contains("Tất cả"))
            {
                filterDepartments = departments;
            }

            string? filterContentType = string.IsNullOrWhiteSpace(contentType) || contentType == "Tất cả"
                ? null
                : contentType.Trim();

            return _contentDAL.SearchContents(cleanKeyword, filterDepartments, sortType, filterContentType);
        }

        public List<ContentDTO> GetInitialArticles() => GetInitialContents();

        public string ValidateArticle(ContentDTO article) => ValidateContent(article);
    }
}
