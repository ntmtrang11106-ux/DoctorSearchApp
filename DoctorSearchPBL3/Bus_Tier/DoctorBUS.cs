using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class DoctorBUS
    {
        private readonly DoctorDAL doctorDAL = new DoctorDAL();

        /// <summary>
        /// Lấy toàn bộ danh sách bác sĩ đã được lọc (Active, Approved, Not Deleted)
        /// </summary>
        public List<DoctorDTO> GetListDoctors()
        {
            try
            {
                var list = doctorDAL.GetAllDoctors();
                if (list == null) return new List<DoctorDTO>();
                var validatedList = list.Where(d => d.User != null).ToList();
                return validatedList;
            }
            catch (Exception)
            {
                return new List<DoctorDTO>();
            }
        }

        /// <summary>
        /// Logic tìm kiếm bác sĩ kết hợp lọc và sắp xếp
        /// </summary>
        public List<DoctorDTO> SearchDoctors(string keyword, List<string> selectedDepts, string gender, string sortType)
        {
            string cleanKeyword = string.IsNullOrWhiteSpace(keyword) ? null : keyword.Trim();
            List<string> filterDepts = null;
            if (selectedDepts != null && selectedDepts.Count > 0 && !selectedDepts.Contains("Tất cả"))
            {
                filterDepts = selectedDepts;
            }
            string filterGender = (gender == "Tất cả") ? null : gender;
            return doctorDAL.SearchDoctors(cleanKeyword, filterDepts, filterGender, sortType);
        }

        public int GetDoctorIdByUserId(int userId)
        {
            return doctorDAL.GetDoctorIdByUserId(userId);
        }

        public DoctorDTO GetDoctorById(int doctorId)
        {
            if (doctorId <= 0) return null;
            return doctorDAL.GetDoctorById(doctorId);
        }

        public List<AppointmentsDTO> GetTodayAppointments(int doctorId)
        {
            if (doctorId <= 0) return new List<AppointmentsDTO>();
            return doctorDAL.GetTodayAppointments(doctorId);
        }

        public int GetTotalPatientsCount(int doctorId)
        {
            if (doctorId <= 0) return 0;
            return doctorDAL.GetTotalPatientsCount(doctorId);
        }

        public int GetPendingAppointmentsCount(int doctorId)
        {
            if (doctorId <= 0) return 0;
            return doctorDAL.GetPendingAppointmentsCount(doctorId);
        }

        /// <summary>
        /// Cập nhật thông tin bác sĩ với các ràng buộc nghiệp vụ (Validation)
        /// </summary>
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

        public List<ReviewsDTO> GetDoctorReviews(int doctorId)
        {
            if (doctorId <= 0) return new List<ReviewsDTO>();
            return doctorDAL.GetDoctorReviews(doctorId);
        }
    }
}