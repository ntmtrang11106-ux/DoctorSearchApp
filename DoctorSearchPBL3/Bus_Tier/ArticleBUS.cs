using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class ArticleBUS
    {
        private readonly ContentDAL _contentDAL = new ContentDAL();

        public List<ContentDTO> GetInitialArticles()
        {
            return _contentDAL.GetAllContents();
        }

        public string ValidateArticle(ContentDTO article)
        {
            if (string.IsNullOrEmpty(article.Title)) return "Tiêu đề không được để trống!";
            if (article.Body.Length < 10) return "Nội dung bài viết quá ngắn!";
            return "OK";
        }
    }
}