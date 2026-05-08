using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class SearchBUS
    {
        private readonly DoctorDAL _doctorDAL = new DoctorDAL();
        private readonly ContentDAL _contentDAL = new ContentDAL();

        public (List<DoctorDTO> doctors, List<ContentDTO> contents) ExecuteIntegratedSearch(
            string? keyword,
            List<string>? departments,
            string? gender,
            string? sortDoctor,
            string? sortContent)
        {
            var doctors = _doctorDAL.SearchDoctors(keyword, departments, gender, sortDoctor);
            var contents = _contentDAL.SearchContents(keyword, departments, sortContent);

            return (doctors, contents);
        }

        public List<DoctorDTO> ExecuteDoctorOnlySearch(
            string? keyword,
            List<string>? departments,
            string? gender,
            string? sortDoctor)
        {
            return _doctorDAL.SearchDoctors(keyword, departments, gender, sortDoctor);
        }

        public List<ContentDTO> ExecuteContentOnlySearch(
            string? keyword,
            List<string>? departments,
            string? sortContent,
            string? contentType = null)
        {
            return _contentDAL.SearchContents(keyword, departments, sortContent, contentType);
        }
    }
}
