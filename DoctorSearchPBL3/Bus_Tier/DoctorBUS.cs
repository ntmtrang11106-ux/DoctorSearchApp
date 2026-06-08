using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
        /// Cập nhật thông tin bác sĩ với các ràng buộc nghiệp vụ.
        /// </summary>
        public string UpdateDoctorInfo(DoctorDTO doctor)
        {
            var errors = CollectDoctorProfileErrors(doctor);
            if (errors.Count > 0) return FormatValidationErrors(errors);

            bool result = doctorDAL.UpdateDoctor(doctor);
            return result ? "Cập nhật thành công!" : "Cập nhật thất bại, vui lòng kiểm tra lại!";
        }

        private List<string> CollectDoctorProfileErrors(DoctorDTO doctor)
        {
            var errors = new List<string>();
            if (doctor == null)
            {
                errors.Add("Dữ liệu bác sĩ không hợp lệ.");
                return errors;
            }

            if (doctor.User == null)
            {
                errors.Add("Thông tin người dùng không hợp lệ.");
                return errors;
            }

            doctor.User.FullName = NormalizeRequired(doctor.User.FullName);
            doctor.User.PhoneNumber = NormalizePhone(doctor.User.PhoneNumber);
            doctor.User.Gender = NormalizeRequired(doctor.User.Gender);
            doctor.User.CCCD = NormalizeRequired(doctor.User.CCCD);
            doctor.User.Residential_Address = NormalizeRequired(doctor.User.Residential_Address);
            doctor.Biography = NormalizeRequired(doctor.Biography);

            if (string.IsNullOrWhiteSpace(doctor.User.FullName))
            {
                errors.Add("Họ tên không được để trống.");
            }
            else
            {
                if (doctor.User.FullName.Length < 2 || doctor.User.FullName.Length > 100)
                    errors.Add("Họ tên phải từ 2 đến 100 ký tự.");
                if (!Regex.IsMatch(doctor.User.FullName, @"^[\p{L}\s'.-]+$"))
                    errors.Add("Họ tên chỉ được chứa chữ cái và khoảng trắng.");
            }

            bool hasValidPhone = false;
            if (string.IsNullOrWhiteSpace(doctor.User.PhoneNumber))
            {
                errors.Add("Số điện thoại không được để trống.");
            }
            else if (!IsValidVietnamesePhone(doctor.User.PhoneNumber))
            {
                errors.Add("Số điện thoại phải gồm đúng 10 chữ số và bắt đầu bằng 0.");
            }
            else
            {
                hasValidPhone = true;
            }

            if (hasValidPhone && userDAL.IsPhoneExists(doctor.User.PhoneNumber, doctor.UserId))
                errors.Add("Số điện thoại này đã được sử dụng bởi người dùng khác.");

            if (doctor.User.Dob == null)
            {
                errors.Add("Ngày sinh không được để trống.");
            }
            else if (doctor.User.Dob.Value.Date > DateTime.Now.Date)
            {
                errors.Add("Ngày sinh không hợp lệ.");
            }
            else
            {
                int age = CalculateAge(doctor.User.Dob.Value);
                if (age < 22) errors.Add("Bác sĩ phải từ 22 tuổi trở lên.");
                if (age > 100) errors.Add("Ngày sinh không hợp lệ.");
            }

            if (string.IsNullOrWhiteSpace(doctor.User.Gender))
                errors.Add("Vui lòng nhập giới tính.");
            else if (!IsValidGender(doctor.User.Gender))
                errors.Add("Giới tính chỉ nhận Nam hoặc Nữ.");

            if (string.IsNullOrWhiteSpace(doctor.User.CCCD))
                errors.Add("Số CCCD không được để trống.");
            else if (!IsValidCCCD(doctor.User.CCCD))
                errors.Add("Số CCCD phải gồm đúng 12 chữ số.");

            if (string.IsNullOrWhiteSpace(doctor.User.Residential_Address))
            {
                errors.Add("Địa chỉ không được để trống.");
            }
            else
            {
                if (doctor.User.Residential_Address.Length < 5 || doctor.User.Residential_Address.Length > 255)
                    errors.Add("Địa chỉ phải từ 5 đến 255 ký tự.");
                if (ContainsControlCharacter(doctor.User.Residential_Address))
                    errors.Add("Địa chỉ chứa ký tự không hợp lệ.");
            }

            if ((doctor.ExperienceYears ?? 0) < 0)
                errors.Add("Số năm kinh nghiệm không thể âm.");
            if ((doctor.ConsultationFee ?? 0) < 0)
                errors.Add("Giá khám không thể âm.");
            if (!string.IsNullOrWhiteSpace(doctor.Biography) && doctor.Biography.Length > 2000)
                errors.Add("Tiểu sử không được vượt quá 2000 ký tự.");

            return errors;
        }

        private static bool IsValidVietnamesePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return Regex.IsMatch(phone, @"^0\d{9}$");
        }

        private static bool IsValidCCCD(string cccd)
        {
            return Regex.IsMatch(cccd, @"^[0-9]{12}$");
        }

        private static bool IsValidGender(string gender)
            => gender == "Nam" || gender == "Nữ";

        private static string NormalizePhone(string? value)
        {
            value = (value ?? "").Trim();
            value = value.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "");

            if (value.StartsWith("+84")) value = "0" + value.Substring(3);
            else if (value.StartsWith("84") && value.Length == 11) value = "0" + value.Substring(2);

            return value;
        }

        private static string NormalizeRequired(string? value)
            => Regex.Replace((value ?? "").Trim(), @"\s+", " ");

        private static bool ContainsControlCharacter(string value)
            => value.Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n' && ch != '\t');

        private static string FormatValidationErrors(List<string> errors)
            => errors.Count == 0 ? "OK" : "Vui lòng kiểm tra lại:\n- " + string.Join("\n- ", errors.Distinct());

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

        public string ApproveDoctor(int doctorId, bool isApproved)
        {
            if (doctorId <= 0) return "ID bác sĩ không hợp lệ!";
            bool result = doctorDAL.ApproveDoctor(doctorId, isApproved);
            return result ? "Success" : "Thao tác thất bại!";
        }

        public List<ReviewsDTO> GetDoctorReviews(int doctorId)
        {
            if (doctorId <= 0) return new List<ReviewsDTO>();
            return doctorDAL.GetDoctorReviews(doctorId);
        }

        public string UploadCertificate(int doctorId, string localFilePath)
        {
            try
            {
                if (!File.Exists(localFilePath))
                    return "File không tồn tại!";

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string certFolder = Path.Combine(baseDir, "Resources", "Certificates");
                if (!Directory.Exists(certFolder))
                    Directory.CreateDirectory(certFolder);

                string fileName = Path.GetFileName(localFilePath);
                string extension = Path.GetExtension(localFilePath);
                string uniqueFileName = $"{DateTime.Now:yyyyMMdd}_{Guid.NewGuid().ToString().Substring(0, 8)}{extension}";
                string destinationPath = Path.Combine(certFolder, uniqueFileName);

                File.Copy(localFilePath, destinationPath, true);

                var certDTO = new DoctorCertificateDTO
                {
                    DoctorId = doctorId,
                    FilePath = Path.Combine("Resources", "Certificates", uniqueFileName),
                    FileName = fileName,
                    UploadedAt = DateTime.Now,
                    IsPrimary = true,
                    IsDeleted = false
                };

                bool result = doctorDAL.ReplaceDoctorCertificate(doctorId, certDTO);
                return result ? "Tải lên thành công!" : "Lưu vào cơ sở dữ liệu thất bại!";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public int GetDoctorCountByDepartmentId(int departmentId)
        {
            if (departmentId <= 0) return 0;
            return doctorDAL.GetDoctorCountByDepartmentId(departmentId);
        }
    }
}
