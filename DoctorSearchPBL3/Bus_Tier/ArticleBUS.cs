//using DAL_Tier;
//using DTO_Tier;
//using System.Collections.Generic;
//using System.Linq;

//namespace BUS_Tier
//{
//    public class ArticleBUS
//    {
//        private ArticleDAL _articleDAL = new ArticleDAL();

//        // Lấy toàn bộ bài viết để hiện ban đầu (mới mở App)
//        public List<ArticlesDTO> GetInitialArticles()
//        {
//            // Gọi DAL đã có Include Author và Specialties
//            return _articleDAL.GetAllArticles();
//        }

//        // Nếu Trang muốn viết thêm logic kiểm tra nội dung bài viết trước khi hiện
//        public string ValidateArticle(ArticlesDTO article)
//        {
//            if (string.IsNullOrEmpty(article.Title)) return "Tiêu đề không được để trống!";
//            if (article.Content.Length < 10) return "Nội dung bài viết quá ngắn!";
//            return "OK";
//        }
//    }
//}