using DAL_Tier;
using DTO_Tier;

namespace BUS_Tier
{
    public class DoctorBUS
    {
        private readonly DoctorDAL doctorDAL = new DoctorDAL();
        private readonly UserDAL userDAL = new UserDAL();

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
            if (doctor == null) return "Dữ liệu không hợp lệ!";
            if (doctor.User == null) return "Thông tin người dùng không hợp lệ!";

            // 1. Kiểm tra Họ tên
            if (string.IsNullOrWhiteSpace(doctor.User.FullName))
                return "Họ tên không được để trống!";

            // 2. Kiểm tra Số điện thoại (Phải là số VN hợp lệ)
            if (string.IsNullOrWhiteSpace(doctor.User.PhoneNumber))
                return "Số điện thoại không được để trống!";
            if (!IsValidVietnamesePhone(doctor.User.PhoneNumber))
                return "Số điện thoại không đủ 10 chữ số!";
            
            // 2b. Kiểm tra trùng SĐT
            if (userDAL.IsPhoneExists(doctor.User.PhoneNumber, doctor.UserId))
                return "Số điện thoại này đã được sử dụng bởi người dùng khác!";

            // 4. Kiểm tra Tuổi (Bác sĩ thường phải từ 22 tuổi trở lên sau khi tốt nghiệp)
            if (doctor.User.Dob.HasValue)
            {
                int age = CalculateAge(doctor.User.Dob.Value);
                if (age < 22) return "Bác sĩ phải từ 22 tuổi trở lên!";
                if (age > 100) return "Ngày sinh không hợp lệ!";
            }

            // 3. Kiểm tra CCCD (Bắt buộc và phải đủ 12 số)
            if (string.IsNullOrWhiteSpace(doctor.User.CCCD))
                return "Số CCCD không được để trống!";
            if (!IsValidCCCD(doctor.User.CCCD))
                return "Số CCCD không hợp lệ (phải nhập đúng 12 chữ số)!";

            

            // 5. Kiểm tra Kinh nghiệm và Giá khám
            if ((doctor.ExperienceYears ?? 0) < 0)
                return "Số năm kinh nghiệm không thể âm!";
            if ((doctor.ConsultationFee ?? 0) < 0)
                return "Giá khám không thể âm!";

            bool result = doctorDAL.UpdateDoctor(doctor);
            return result ? "Cập nhật thành công!" : "Cập nhật thất bại, vui lòng kiểm tra lại!";
        }

        private bool IsValidVietnamesePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^(0[3|5|7|8|9])[0-9]{8}$");
        }

        private bool IsValidCCCD(string cccd)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^[0-9]{12}$");
        }

        private int CalculateAge(DateTime dob)
        {
            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
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