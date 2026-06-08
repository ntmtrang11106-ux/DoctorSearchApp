using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BUS_Tier
{
    public class UserBUS
    {
        private readonly UserDAL _userDAL = new UserDAL();
        private readonly AppDbContext _context = new AppDbContext();
        private readonly DoctorDAL _doctorDAL = new DoctorDAL();
        private readonly PatientDAL _patientDAL = new PatientDAL();

        /// Hàm này sẽ lấy đúng ID của vai trò tương ứng dựa trên UserId và Role
        /// <summary>
        /// Hàm này sẽ lấy đúng ID định danh của vai trò tương ứng (DoctorId/PatientId) từ UserId
        /// </summary>
        public int GetProfileIdByRole(int userId, string role)
        {
            // 1. Kiểm tra đầu vào cơ bản
            if (userId <= 0 || string.IsNullOrEmpty(role)) return 0;

            try
            {
                switch (role)
                {
                    case "Doctor":
                        // Sử dụng biến đã khai báo ở trên để tiết kiệm bộ nhớ
                        return _doctorDAL.GetDoctorIdByUserId(userId);

                    case "Patient":
                        return _patientDAL.GetPatientIdByUserId(userId);

                    case "Admin":
                        // Đối với Admin, nếu bảng Admin có ID riêng thì gọi DAL của Admin
                        // return _adminDAL.GetAdminIdByUserId(userId);

                        // Nếu không có bảng Admin riêng, thường Admin dùng luôn UserId
                        return userId;

                    default:
                        return 0;
                }
            }
            catch
            {
                // Log lỗi nếu cần thiết
                return 0;
            }
        }
        //public string Login(string phone, string pass, out int loggedInId, out string msg)
        //{
        //    loggedInId = 0;
        //    msg = "";

        //    // 1. Gọi DAL xác thực tài khoản User
        //    var user = _userDAL.CheckLogin(phone, pass);

        //    if (user != null)
        //    {
        //        // 2. Dựa vào Role để lấy đúng ID của vai trò đó
        //        if (user.Role == "Doctor")
        //        {
        //            // Tìm trong bảng Doctor xem ai có UserId này
        //            var doctor = _context.Doctors.FirstOrDefault(d => d.UserId == user.Id);
        //            if (doctor != null)
        //            {
        //                loggedInId = doctor.Id; // Đây mới là DoctorId (ví dụ: 1)
        //            }
        //        }
        //        else if (user.Role == "Patient")
        //        {
        //            // Tìm trong bảng Patient xem ai có UserId này
        //            var patient = _context.Patients.FirstOrDefault(p => p.UserId == user.Id);
        //            if (patient != null)
        //            {
        //                loggedInId = patient.Id; // Đây là PatientId
        //            }
        //        }
        //        else // Role Admin hoặc trường hợp khác
        //        {
        //            loggedInId = user.Id;
        //        }

        //        // Kiểm tra nếu tìm thấy ID vai trò
        //        if (loggedInId > 0)
        //        {
        //            msg = "Đăng nhập thành công!";
        //            return user.Role;
        //        }
        //        else
        //        {
        //            msg = "Tài khoản chưa được cấu hình vai trò chi tiết!";
        //            return "";
        //        }
        //    }

        //    msg = "Số điện thoại hoặc mật khẩu không chính xác!";
        //    return "";
        //}

        public string Login(string phone, string pass, out int userId, out int profileId, out string fullName, out string msg)
        {
            userId = 0;
            profileId = 0;
            fullName = "";
            msg = "";

            string rawPhone = NormalizeRequired(phone);
            string normalizedPhone = NormalizePhone(rawPhone);
            pass ??= "";

            string loginValidation = ValidateLoginInput(rawPhone, pass);
            if (loginValidation != "OK")
            {
                msg = loginValidation;
                return "";
            }

            var user = GetUserForLoginByCandidates(rawPhone, normalizedPhone);

            if (user != null && SecurityHelper.VerifyPassword(pass, user.Password))
            {
                if (!string.Equals(user.Status, "Active", StringComparison.OrdinalIgnoreCase))
                {
                    msg = user.Status == "Blocked"
                        ? "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên để được hỗ trợ."
                        : "Tài khoản chưa ở trạng thái hoạt động.";
                    return "";
                }
                if (user.Status == "Deleted" || user.IsDeleted)
                {
                    msg = "Tài khoản của bạn đã bị xóa khỏi hệ thống.";
                    return "";
                }

                userId = user.Id;
                fullName = user.FullName;

                if (user.Role == "Doctor")
                {
                    var doctor = _context.Doctors.FirstOrDefault(d => d.UserId == user.Id);
                    if (doctor != null)
                    {
                        if (!doctor.IsApproved)
                        {
                            msg = "Tài khoản bác sĩ của bạn đang chờ quản trị viên phê duyệt. Vui lòng quay lại sau!";
                            return "";
                        }
                        profileId = doctor.Id;
                    }
                }
                else if (user.Role == "Patient")
                {
                    var patient = _context.Patients.FirstOrDefault(p => p.UserId == user.Id);
                    if (patient != null) profileId = patient.Id;
                }
                else
                {
                    profileId = user.Id;
                }

                if (profileId > 0)
                {
                    msg = "Đăng nhập thành công!";
                    return user.Role;
                }
                else
                {
                    msg = "Tài khoản chưa được cấu hình vai trò chi tiết!";
                    return "";
                }
            }

            msg = "Số điện thoại hoặc mật khẩu không chính xác!";
            return "";
        }

        /// <summary>
        /// Đăng ký cho Bệnh nhân
        /// </summary>
        public string RegisterPatient(UserDTO user, string confirmPass, string insuranceCode)
        {
            List<string> errors = CollectCommonUserErrors(user, confirmPass, minAge: 0);

            string? normalizedInsuranceCode = NormalizeNullable(insuranceCode);
            if (string.IsNullOrWhiteSpace(normalizedInsuranceCode))
            {
                errors.Add("Vui lòng nhập mã số Bảo hiểm y tế.");
            }
            else if (!IsSafeCode(normalizedInsuranceCode, 6, 50))
            {
                errors.Add("Mã số Bảo hiểm y tế chỉ được chứa chữ, số, dấu gạch ngang hoặc dấu gạch chéo và tối đa 50 ký tự.");
            }

            if (errors.Count > 0) return FormatValidationErrors(errors);

            // Sử dụng SecurityHelper để băm trước khi lưu
            user.Password = SecurityHelper.HashPassword(user.Password);

            // 2. Gọi DAL lưu thông tin
            bool isSuccess = _userDAL.RegisterPatient(user, normalizedInsuranceCode);
            return isSuccess ? "Success" : "Lỗi hệ thống khi đăng ký Bệnh nhân.";
        }

        /// <summary>
        /// Đăng ký cho Bác sĩ (Thêm trường clinicName từ giao diện)
        /// </summary>
        public string RegisterDoctor(UserDTO user, string confirmPass, int deptId, int exp, string position, string licenseNumber, out int doctorId)
        {
            doctorId = 0;
            List<string> errors = CollectCommonUserErrors(user, confirmPass, minAge: 18);

            position = NormalizeRequired(position);
            licenseNumber = NormalizeRequired(licenseNumber).ToUpperInvariant();

            if (string.IsNullOrWhiteSpace(position)) errors.Add("Vui lòng nhập chức danh nghề nghiệp.");
            else if (position.Length > 100) errors.Add("Chức danh nghề nghiệp không được vượt quá 100 ký tự.");

            if (deptId <= 0) errors.Add("Vui lòng chọn chuyên khoa cho bác sĩ.");
            if (exp < 0 || exp > 60) errors.Add("Năm kinh nghiệm không hợp lệ.");

            if (string.IsNullOrWhiteSpace(licenseNumber))
            {
                errors.Add("Vui lòng nhập mã giấy phép hành nghề.");
            }
            else
            {
                if (!IsValidMedicalLicenseNumber(licenseNumber))
                    errors.Add("Mã CCHN/GPHN phải theo dạng 000001/HCM-CCHN hoặc 000001/BYT-GPHN: 6-7 chữ số, '/', mã cơ quan cấp, '-', CCHN/GPHN.");
                else if (_context.Doctors.Any(d => d.LicenseNumber != null && d.LicenseNumber.ToUpper() == licenseNumber && !d.IsDeleted))
                    errors.Add("Mã CCHN/GPHN này đã tồn tại trên hệ thống.");
            }

            if (errors.Count > 0) return FormatValidationErrors(errors);

            user.Password = SecurityHelper.HashPassword(user.Password);

            doctorId = _userDAL.RegisterDoctor(user, deptId, exp, position, licenseNumber);
            return doctorId > 0 ? "Success" : "Lỗi hệ thống khi đăng ký Bác sĩ.";
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của các trường chung
        /// </summary>
        private string ValidateCommonUser(UserDTO user, string confirmPass, int minAge, int? excludeUserId = null)
            => FormatValidationErrors(CollectCommonUserErrors(user, confirmPass, minAge, excludeUserId));

        private List<string> CollectCommonUserErrors(UserDTO user, string confirmPass, int minAge, int? excludeUserId = null)
        {
            var errors = new List<string>();

            if (user == null)
            {
                errors.Add("Dữ liệu người dùng không hợp lệ.");
                return errors;
            }

            NormalizeUser(user);
            confirmPass ??= "";

            if (string.IsNullOrWhiteSpace(user.FullName)) errors.Add("Họ và tên không được để trống.");
            else
            {
                if (user.FullName.Length < 2 || user.FullName.Length > 100)
                    errors.Add("Họ và tên phải từ 2 đến 100 ký tự.");
                if (!Regex.IsMatch(user.FullName, @"^[\p{L}\s'.-]+$"))
                    errors.Add("Họ và tên chỉ được chứa chữ cái và khoảng trắng.");
            }

            bool hasValidPhone = false;
            if (string.IsNullOrWhiteSpace(user.PhoneNumber)) errors.Add("Số điện thoại không được để trống.");
            else if (!IsValidPhone(user.PhoneNumber)) errors.Add("Số điện thoại phải gồm đúng 10 chữ số và bắt đầu bằng 0.");
            else hasValidPhone = true;

            if (user.Dob == null)
            {
                errors.Add("Ngày sinh không được để trống.");
            }
            else if (user.Dob.Value.Date > DateTime.Now.Date)
            {
                errors.Add("Ngày sinh không hợp lệ.");
            }
            else
            {
                int age = CalculateAge(user.Dob.Value);
                if (age < minAge)
                    errors.Add(minAge == 18 ? "Người dùng phải từ 18 tuổi trở lên." : "Ngày sinh không hợp lệ.");

                if (age >= 16)
                {
                    if (string.IsNullOrWhiteSpace(user.CCCD))
                        errors.Add("Người dùng từ 16 tuổi trở lên bắt buộc phải nhập CCCD.");
                    else if (!IsValidCccd(user.CCCD))
                        errors.Add("Số CCCD phải gồm đúng 12 chữ số.");
                }
            }

            if (string.IsNullOrWhiteSpace(user.Gender)) errors.Add("Vui lòng chọn giới tính.");
            else if (!IsValidGender(user.Gender)) errors.Add("Giới tính không hợp lệ.");

            if (string.IsNullOrWhiteSpace(user.Residential_Address)) errors.Add("Địa chỉ không được để trống.");
            else
            {
                if (user.Residential_Address.Length < 5 || user.Residential_Address.Length > 255)
                    errors.Add("Địa chỉ phải từ 5 đến 255 ký tự.");
                if (ContainsControlCharacter(user.Residential_Address))
                    errors.Add("Địa chỉ chứa ký tự không hợp lệ.");
            }

            if (string.IsNullOrWhiteSpace(user.Password)) errors.Add("Mật khẩu không được để trống.");
            if (string.IsNullOrWhiteSpace(confirmPass)) errors.Add("Vui lòng xác nhận mật khẩu.");
            if (!string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(confirmPass) && user.Password != confirmPass)
                errors.Add("Mật khẩu nhập lại không khớp.");

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                AddPasswordStrengthErrors(errors, user.Password, user.PhoneNumber, user.FullName);
            }

            if (hasValidPhone)
            {
                bool phoneExists = excludeUserId.HasValue
                ? _userDAL.IsPhoneExists(user.PhoneNumber, excludeUserId.Value)
                : _userDAL.IsPhoneExists(user.PhoneNumber);

                if (phoneExists)
                    errors.Add("Số điện thoại này đã tồn tại trên hệ thống.");
            }

            return errors;
        }

        public int CalculateAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) age--;
            return age;
        }

        public string ChangePassword(int userId, string currentPass, string newPass, string confirmPass)
        {
            var errors = new List<string>();

            if (userId <= 0) errors.Add("ID người dùng không hợp lệ.");
            if (string.IsNullOrWhiteSpace(currentPass)) errors.Add("Vui lòng nhập mật khẩu hiện tại.");
            if (string.IsNullOrWhiteSpace(newPass)) errors.Add("Mật khẩu mới không được để trống.");
            if (string.IsNullOrWhiteSpace(confirmPass)) errors.Add("Vui lòng xác nhận mật khẩu mới.");
            if (!string.IsNullOrWhiteSpace(newPass) && !string.IsNullOrWhiteSpace(confirmPass) && newPass != confirmPass)
                errors.Add("Mật khẩu xác nhận không khớp.");
            if (!string.IsNullOrWhiteSpace(newPass))
                AddPasswordStrengthErrors(errors, newPass, "", "");

            if (errors.Count > 0) return FormatValidationErrors(errors);

            var user = _context.Users.Find(userId);
            if (user == null) return "Người dùng không tồn tại.";
            if (!string.Equals(user.Status, "Active", StringComparison.OrdinalIgnoreCase) || user.IsDeleted)
                return "Tài khoản không ở trạng thái được phép đổi mật khẩu.";

            if (!SecurityHelper.VerifyPassword(currentPass, user.Password))
                return "Mật khẩu hiện tại không chính xác.";

            if (SecurityHelper.VerifyPassword(newPass, user.Password))
                return "Mật khẩu mới không được trùng mật khẩu hiện tại.";

            errors.Clear();
            AddPasswordStrengthErrors(errors, newPass, user.PhoneNumber, user.FullName);
            if (errors.Count > 0) return FormatValidationErrors(errors);

            string newHashedPass = SecurityHelper.HashPassword(newPass);
            bool success = _userDAL.ChangePassword(userId, newHashedPass);

            return success ? "Success" : "Lỗi hệ thống khi đổi mật khẩu.";
        }

        public string UpdateAvatar(int userId, string imagePath)
        {
            if (userId <= 0) return "ID người dùng không hợp lệ.";
            if (string.IsNullOrWhiteSpace(imagePath)) return "Đường dẫn ảnh không hợp lệ.";

            bool success = _userDAL.UpdateAvatar(userId, imagePath);
            return success ? "Success" : "Lỗi hệ thống khi cập nhật ảnh đại diện.";
        }

        public string UpdateAdminProfile(UserDTO user)
        {
            if (user == null || user.Id <= 0) return "Dữ liệu người dùng không hợp lệ.";

            string validation = ValidateCommonUserForUpdate(user, minAge: 18);
            if (validation != "OK") return validation;

            bool success = _userDAL.UpdateUser(user);
            return success ? "Success" : "Lỗi hệ thống khi cập nhật hồ sơ.";
        }

        public bool UpdateUser(UserDTO user)
        {
            if (user == null || user.Id <= 0) return false;

            string validation = ValidateCommonUserForUpdate(user, minAge: 0);
            if (validation != "OK") return false;

            return _userDAL.UpdateUser(user);
        }

        public UserDTO? GetUserById(int userId)
        {
            if (userId <= 0) return null;
            return _userDAL.GetUserById(userId);
        }

        private string ValidateCommonUserForUpdate(UserDTO user, int minAge)
        {
            string originalPassword = user.Password;
            user.Password = "Aa@123456";

            string validation = ValidateCommonUser(user, user.Password, minAge, user.Id);
            user.Password = originalPassword;

            return validation;
        }

        private static string ValidateLoginInput(string phone, string password)
        {
            if (string.IsNullOrWhiteSpace(phone)) return "Số điện thoại không được để trống.";
            if (phone.Length > 30 || ContainsControlCharacter(phone)) return "Số điện thoại không hợp lệ.";
            if (string.IsNullOrWhiteSpace(password)) return "Mật khẩu không được để trống.";
            if (password.Length > 255) return "Mật khẩu không hợp lệ.";
            return "OK";
        }

        private UserDTO? GetUserForLoginByCandidates(params string[] phoneValues)
        {
            foreach (string candidate in BuildLoginPhoneCandidates(phoneValues))
            {
                UserDTO? user = _userDAL.GetUserForLogin(candidate);
                if (user != null) return user;
            }

            return null;
        }

        private static List<string> BuildLoginPhoneCandidates(params string[] phoneValues)
        {
            var candidates = new List<string>();

            void AddCandidate(string? value)
            {
                value = NormalizeRequired(value);
                if (string.IsNullOrWhiteSpace(value) || value.Length > 30) return;

                if (!candidates.Contains(value, StringComparer.OrdinalIgnoreCase))
                {
                    candidates.Add(value);
                }
            }

            foreach (string value in phoneValues)
            {
                AddCandidate(value);

                string normalized = NormalizePhone(value);
                AddCandidate(normalized);

                if (normalized.StartsWith("0") && normalized.Length > 1)
                {
                    AddCandidate("+84" + normalized.Substring(1));
                    AddCandidate("84" + normalized.Substring(1));
                }
            }

            return candidates;
        }

        private static string ValidatePasswordStrength(string password, string phone, string fullName)
        {
            var errors = new List<string>();
            AddPasswordStrengthErrors(errors, password, phone, fullName);
            return FormatValidationErrors(errors);
        }

        private static void AddPasswordStrengthErrors(List<string> errors, string password, string phone, string fullName)
        {
            if (password.Length < 8 || password.Length > 64)
                errors.Add("Mật khẩu phải từ 8 đến 64 ký tự.");
            if (password.Any(char.IsWhiteSpace))
                errors.Add("Mật khẩu không được chứa khoảng trắng.");
            if (!password.Any(char.IsUpper))
                errors.Add("Mật khẩu phải có ít nhất 1 chữ hoa.");
            if (!password.Any(char.IsLower))
                errors.Add("Mật khẩu phải có ít nhất 1 chữ thường.");
            if (!password.Any(char.IsDigit))
                errors.Add("Mật khẩu phải có ít nhất 1 chữ số.");
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                errors.Add("Mật khẩu phải có ít nhất 1 ký tự đặc biệt.");

            if (!string.IsNullOrWhiteSpace(phone) && password.Contains(phone, StringComparison.OrdinalIgnoreCase))
                errors.Add("Mật khẩu không được chứa số điện thoại.");

            string compactName = Regex.Replace(fullName ?? "", @"\s+", "");
            if (compactName.Length >= 4 && password.Contains(compactName, StringComparison.OrdinalIgnoreCase))
                errors.Add("Mật khẩu không được chứa họ tên.");
        }

        private static void NormalizeUser(UserDTO user)
        {
            user.FullName = NormalizeRequired(user.FullName);
            user.PhoneNumber = NormalizePhone(user.PhoneNumber);
            user.Gender = NormalizeNullable(user.Gender);
            user.CCCD = NormalizeNullable(user.CCCD);
            user.Residential_Address = NormalizeRequired(user.Residential_Address);
        }

        private static string NormalizePhone(string? value)
        {
            value = (value ?? "").Trim();
            value = value.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "");

            if (value.StartsWith("+84"))
            {
                value = "0" + value.Substring(3);
            }
            else if (value.StartsWith("84") && value.Length == 11)
            {
                value = "0" + value.Substring(2);
            }

            return value;
        }

        private static string NormalizeRequired(string? value)
            => Regex.Replace((value ?? "").Trim(), @"\s+", " ");

        private static string? NormalizeNullable(string? value)
        {
            string normalized = NormalizeRequired(value);
            return string.IsNullOrWhiteSpace(normalized) ? null : normalized;
        }

        private static bool IsValidPhone(string phone)
            => Regex.IsMatch(phone, @"^0\d{9}$");

        private static bool IsValidCccd(string cccd)
            => Regex.IsMatch(cccd, @"^\d{12}$");

        private static bool IsValidGender(string gender)
            => gender == "Nam" || gender == "Nữ";

        private static bool IsSafeCode(string value, int minLength, int maxLength)
            => value.Length >= minLength
            && value.Length <= maxLength
            && Regex.IsMatch(value, @"^[A-Za-z0-9/-]+$");

        private static bool IsValidMedicalLicenseNumber(string value)
            => Regex.IsMatch(value, @"^\d{6,7}/[\p{L}0-9]{2,10}-(CCHN|GPHN)$", RegexOptions.IgnoreCase);

        private static bool ContainsControlCharacter(string value)
            => value.Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n' && ch != '\t');

        private static string FormatValidationErrors(List<string> errors)
        {
            if (errors.Count == 0) return "OK";

            return "Vui lòng kiểm tra lại:\n- " + string.Join("\n- ", errors.Distinct());
        }

        public static class SecurityHelper
        {
            private const int SaltSize = 16; // 128 bit
            private const int KeySize = 32;  // 256 bit
            private const int Iterations = 10000; // Số vòng lặp để làm chậm tấn công brute-force
            private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

            public static string HashPassword(string password)
            {
                // 1. Tạo Salt ngẫu nhiên
                byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

                // 2. Tạo Hash từ password và salt
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithm))
                {
                    byte[] hash = pbkdf2.GetBytes(KeySize);

                    // 3. Gộp Salt và Hash thành một mảng byte duy nhất
                    byte[] combinedBytes = new byte[SaltSize + KeySize];
                    Array.Copy(salt, 0, combinedBytes, 0, SaltSize);
                    Array.Copy(hash, 0, combinedBytes, SaltSize, KeySize);

                    // 4. Chuyển sang chuỗi Base64 để lưu vào SQL
                    return Convert.ToBase64String(combinedBytes);
                }
            }

            public static bool VerifyPassword(string password, string storedHash)
            {
                try
                {
                    // 1. Giải mã chuỗi Base64 từ DB
                    byte[] combinedBytes = Convert.FromBase64String(storedHash);

                    // 2. Tách Salt ra khỏi chuỗi
                    byte[] salt = new byte[SaltSize];
                    Array.Copy(combinedBytes, 0, salt, 0, SaltSize);

                    // 3. Tách Hash cũ ra để so sánh
                    byte[] hash = new byte[KeySize];
                    Array.Copy(combinedBytes, SaltSize, hash, 0, KeySize);

                    // 4. Băm mật khẩu người dùng vừa nhập với Salt đã lấy được
                    using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithm))
                    {
                        byte[] newHash = pbkdf2.GetBytes(KeySize);

                        // 5. So sánh từng byte một (dùng CryptographicOperations để chống Side-channel attack)
                        return CryptographicOperations.FixedTimeEquals(hash, newHash);
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
