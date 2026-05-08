using DAL_Tier;
using DTO_Tier;
using System;
using System.Security.Cryptography;

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
            catch (Exception ex)
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

            var user = _userDAL.GetUserForLogin(phone);

            if (user != null && SecurityHelper.VerifyPassword(pass, user.Password))
            {
                userId = user.Id;
                fullName = user.FullName;

                if (user.Role == "Doctor")
                {
                    var doctor = _context.Doctors.FirstOrDefault(d => d.UserId == user.Id);
                    if (doctor != null) profileId = doctor.Id;
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
            // 1. Kiểm tra dữ liệu chung (Họ tên, SĐT, Pass...)
            string validation = ValidateCommonUser(user, confirmPass);
            if (validation != "OK") return validation;

            if (string.IsNullOrWhiteSpace(insuranceCode)) return "Vui lòng nhập mã số Bảo hiểm y tế!";

            // Sử dụng SecurityHelper để băm trước khi lưu
            user.Password = SecurityHelper.HashPassword(user.Password);

            // 2. Gọi DAL lưu thông tin
            bool isSuccess = _userDAL.RegisterPatient(user, insuranceCode);
            return isSuccess ? "Success" : "Lỗi hệ thống khi đăng ký Bệnh nhân.";
        }

        /// <summary>
        /// Đăng ký cho Bác sĩ (Thêm trường clinicName từ giao diện)
        /// </summary>
        public string RegisterDoctor(UserDTO user, string confirmPass, int deptId, int exp, string position, string licenseNumber)
        {
            string validation = ValidateCommonUser(user, confirmPass);
            if (validation != "OK") return validation;

            if (string.IsNullOrWhiteSpace(position)) return "Vui lòng nhập chức danh nghề nghiệp";

            //if (string.IsNullOrWhiteSpace(deptId.ToString())) return "Vui lòng chọn chuyên khoa cho bác sĩ.";
            if (deptId <= 0) return "Vui lòng chọn chuyên khoa cho bác sĩ.";

            if (string.IsNullOrWhiteSpace(exp.ToString())) return "Vui lòng nhập năm cấp chứng chỉ.";

            if (string.IsNullOrWhiteSpace(licenseNumber.ToString())) return "Vui lòng nhập mã giấy phép hành nghề.";

            // Sử dụng SecurityHelper để băm trước khi lưu
            user.Password = SecurityHelper.HashPassword(user.Password);

            // Truyền xuống DAL (đã bỏ fee)
            bool isSuccess = _userDAL.RegisterDoctor(user, deptId, exp, position, licenseNumber);
            return isSuccess ? "Success" : "Lỗi hệ thống khi đăng ký Bác sĩ.";
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của các trường chung
        /// </summary>
        private string ValidateCommonUser(UserDTO user, string confirmPass)
        {
            if (string.IsNullOrWhiteSpace(user.FullName)) return "Họ và tên không được để trống.";
            if (string.IsNullOrWhiteSpace(user.PhoneNumber)) return "Số điện thoại không được để trống.";
            if (user.PhoneNumber.Length < 10) return "Số điện thoại phải có ít nhất 10 số.";

            if (user.Dob > DateTime.Now) return "Ngày sinh không hợp lệ.";
            if (user.Dob == null)
            {
                return "Ngày sinh không được để trống.";
            }

            int age = CalculateAge(user.Dob.Value);

            if (age >= 16)
            {
                if (string.IsNullOrWhiteSpace(user.CCCD))
                    return "Người dùng từ 16 tuổi trở lên bắt buộc phải nhập CCCD.";

                if (user.CCCD.Length != 12)
                    return "Số CCCD phải bao gồm đúng 12 chữ số.";
            }

            if (string.IsNullOrWhiteSpace(user.Gender))
                return "Vui lòng chọn giới tính.";

            if (string.IsNullOrWhiteSpace(user.Residential_Address))
                return "Địa chỉ không được để trống.";

            //if (string.IsNullOrWhiteSpace(user.Password)) return "Mật khẩu không được để trống.";
            //if (string.IsNullOrWhiteSpace(confirmPass)) return "Vui lòng xác nhận mật khẩu.";
            //if (user.Password != confirmPass) return "Mật khẩu nhập lại không khớp.";

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(user.Password))
                return "Mật khẩu không được để trống.";

            if (string.IsNullOrWhiteSpace(confirmPass))
                return "Vui lòng xác nhận mật khẩu.";

            // So sánh 2 chuỗi chưa băm
            if (user.Password != confirmPass)
                return "Mật khẩu nhập lại không khớp.";

            // Kiểm tra xem số điện thoại đã tồn tại chưa
            if (_userDAL.IsPhoneExists(user.PhoneNumber))
                return "Số điện thoại này đã tồn tại trên hệ thống.";

            return "OK";

        }

        public int CalculateAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) age--;
            return age;
        }

        public string ChangePassword(int userId, string currentPass, string newPass)
        {
            if (userId <= 0) return "ID người dùng không hợp lệ.";
            if (string.IsNullOrWhiteSpace(currentPass)) return "Vui lòng nhập mật khẩu hiện tại.";
            if (string.IsNullOrWhiteSpace(newPass) || newPass.Length < 6) return "Mật khẩu mới phải có ít nhất 6 ký tự.";

            var user = _context.Users.Find(userId);
            if (user == null) return "Người dùng không tồn tại.";

            if (!SecurityHelper.VerifyPassword(currentPass, user.Password))
                return "Mật khẩu hiện tại không chính xác.";

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

        public bool UpdateUser(UserDTO user)
        {
            if (user == null || user.Id <= 0) return false;
            return _userDAL.UpdateUser(user);
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