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

        public List<ContentDTO> SearchContents(string keyword, List<string> departmentNames, string contentType, string sortType)
        {
            return _contentDAL.SearchContents(keyword, departmentNames, contentType, sortType);
        }

        public string ValidateArticle(ContentDTO article)
        {
            if (string.IsNullOrEmpty(article.Title)) return "Tiêu đề không được để trống!";
            if (article.Body.Length < 10) return "Nội dung bài viết quá ngắn!";
            return "OK";
        }

        public async Task<bool> IncrementViewAsync(int id)
        {
            // Ở đây bạn có thể thêm logic kiểm tra nếu cần
            // Ví dụ: if (id <= 0) return false;

            return await _contentDAL.IncrementViewAsync(id);
        }
    }
}