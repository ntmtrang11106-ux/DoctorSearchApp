using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class ContentBUS
    {
        private readonly ContentDAL _contentDAL = new ContentDAL();

        public List<ContentDTO> GetInitialArticles()
        {
            return _contentDAL.GetAllContents();
        }

        public List<ContentDTO> SearchContents(string keyword, List<string> departmentNames, string contentType, string sortType, string status = null)
        {
            return _contentDAL.SearchContents(keyword, departmentNames, contentType, sortType, status);
        }

        public string ValidateArticle(ContentDTO article)
        {
            if (string.IsNullOrWhiteSpace(article.Title)) return "Tiêu đề không được để trống!";
            if (article.Title.Length < 5) return "Tiêu đề phải có ít nhất 5 ký tự!";
            if (string.IsNullOrWhiteSpace(article.Summary)) return "Tóm tắt không được để trống!";
            if (string.IsNullOrWhiteSpace(article.Body) || article.Body.Length < 10) return "Nội dung bài viết quá ngắn!";
            if (string.IsNullOrEmpty(article.ContentType)) return "Vui lòng chọn loại nội dung!";
            
            return "OK";
        }

        public async Task<bool> IncrementViewAsync(int id)
        {
            // Ở đây bạn có thể thêm logic kiểm tra nếu cần
            // Ví dụ: if (id <= 0) return false;

            return await _contentDAL.IncrementViewAsync(id);
        }

        public (int total, int published, int draft, int totalViews) GetArticleStats()
        {
            var all = _contentDAL.GetAllContents();
            int total = all.Count;
            int published = all.Count(c => c.Status == "Published");
            int draft = all.Count(c => c.Status == "Draft");
            int totalViews = all.Sum(c => c.ViewCount);
            return (total, published, draft, totalViews);
        }
        public bool AddArticle(ContentDTO art)
        {
            string v = ValidateArticle(art);
            if (v != "OK") return false;
            return _contentDAL.AddArticle(art);
        }

        public bool UpdateArticle(ContentDTO art)
        {
            string v = ValidateArticle(art);
            if (v != "OK") return false;
            return _contentDAL.UpdateArticle(art);
        }
        public bool DeleteArticle(int id)
        {
            return _contentDAL.DeleteArticle(id);
        }
    }
}