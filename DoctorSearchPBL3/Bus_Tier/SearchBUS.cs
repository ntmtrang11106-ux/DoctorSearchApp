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
        public (List<DoctorDTO> doctors, List<ArticleDTO> articles) GetIntegratedSearch(string keyword, string spec, string loc)
        {
            var doctors = _doctorDAL.SearchDoctors(keyword, spec, loc);
            var articles = _articleDAL.SearchArticles(keyword);

            return (doctors, articles);
        }
    }
}
