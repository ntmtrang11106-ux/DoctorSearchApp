using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class DoctorBUS
    {
        private readonly DoctorDAL doctorDAL = new DoctorDAL();

        public List<DoctorDTO> GetListDoctors()
        {
            return doctorDAL.GetAllDoctors();
        }

        public List<DoctorDTO> SearchDoctorsByName(string name)
        {
            return doctorDAL.GetAllDoctors()
                .Where(d => d.User != null && d.User.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public string UpdateDoctorInfo(DoctorDTO doctor)
        {
            if ((doctor.ExperienceYears ?? 0) < 0)
            {
                return "Số năm kinh nghiệm không hợp lệ!";
            }

            if (doctor.User == null || string.IsNullOrWhiteSpace(doctor.User.FullName))
            {
                return "Tên bác sĩ không được để trống!";
            }

            bool result = doctorDAL.UpdateDoctor(doctor);
            return result ? "Cập nhật thành công!" : "Cập nhật thất bại, vui lòng kiểm tra lại!";
        }

        public void CalculateDoctorStats(DoctorDTO doctor)
        {
            if (doctor.Reviews == null || !doctor.Reviews.Any())
            {
                doctor.TotalReviews = 0;
                doctor.AverageRating = 0;
                return;
            }

            var validReviews = doctor.Reviews.Where(r => r.IsVisible && !r.IsDeleted).ToList();
            doctor.TotalReviews = validReviews.Count;
            doctor.AverageRating = validReviews.Any() ? Math.Round(validReviews.Average(r => r.Rating), 1) : 0;
        }
    }
}