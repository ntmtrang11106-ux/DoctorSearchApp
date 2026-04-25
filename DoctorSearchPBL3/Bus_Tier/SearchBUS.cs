using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class SearchBUS
    {
        private readonly DoctorDAL _doctorDAL = new DoctorDAL();
        private readonly ArticleDAL _articleDAL = new ArticleDAL();

        public (List<DoctorDTO> doctors, List<ContentDTO> contents) ExecuteIntegratedSearch(
            string? keyword,
            List<string>? departments,
            string? gender,
            string? sortDoctor,
            string? sortContent)
        {
            var doctors = _doctorDAL.SearchDoctors(keyword, departments, gender, sortDoctor);
            var contents = _articleDAL.SearchContents(keyword, departments, sortContent);

            return (doctors, contents);
        }
    }
}
