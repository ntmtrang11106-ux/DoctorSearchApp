using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class SearchBUS
    {
        private readonly DoctorDAL _doctorDAL = new DoctorDAL();
        private readonly ContentDAL _articleDAL = new ContentDAL();

        public (List<DoctorDTO> doctors, List<ContentDTO> contents) ExecuteIntegratedSearch(
            string? keyword,
            List<string>? departments,
            string? gender,
            string? contentType,
            string? sortDoctor,
            string? sortContent)
        {
            var doctors = _doctorDAL.SearchDoctors(keyword, departments, gender, sortDoctor);
            var contents = _articleDAL.SearchContents(keyword, departments, contentType, sortContent);

            return (doctors, contents);
        }
    }
}
