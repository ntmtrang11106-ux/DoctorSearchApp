using System;
using System.Collections.Generic;
using System.Text;

using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    internal class SearchBUS
    {
        private DoctorDAL _doctorDAL = new DoctorDAL();
        private ArticleDAL _articleDAL = new ArticleDAL();

        // Một hàm trả về cả 2 danh sách để Form hiển thị
        public (List<DoctorDTO> doctors, List<ArticlesDTO> articles) ExecuteIntegratedSearch(
    string keyword,
    List<string> specs,
    string loc,
    string gender,
    string sortDoctor,
    string sortArticle)
        {
            // Gọi DAL tìm Bác sĩ
            var doctors = _doctorDAL.SearchDoctors(keyword, specs, loc, gender, sortDoctor);

            // Gọi DAL tìm Bài viết
            var articles = _articleDAL.SearchArticles(keyword, specs, sortArticle);

            return (doctors, articles);
        }
    }
}
