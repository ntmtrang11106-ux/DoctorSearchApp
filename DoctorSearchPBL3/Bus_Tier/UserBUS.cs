//using DAL_Tier;
//using DTO_Tier; 
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;

//namespace BUS_Tier
//{
//    public class UserBUS
//    {
//        // Khởi tạo DAL - MyDbContext phải được cấu hình trong DAL_Tier
//        private readonly UserDAL _dal = new UserDAL(new AppDbContext());

//        public string Login(string phone, string pass, out int userId, out string msg)
//        {
//            // Khởi tạo giá trị mặc định
//            userId = 0;
//            msg = "";

//            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
//            {
//                msg = "Vui lòng nhập đầy đủ số điện thoại và mật khẩu!";
//                return "";
//            }

//            var user = _dal.CheckLogin(phone, pass);

//            if (user != null)
//            {
//                userId = user.Id; // Trả ID về qua out
//                msg = "Đăng nhập thành công!";
//                return user.Role;     // Trả Role về để UI điều hướng
//            }

//            msg = "Số điện thoại hoặc mật khẩu không chính xác!";
//            return "";
//        }

//        //public string RegisterPatient(UserDTO user, string confirmPass, string province, string district, string bhyt)
//        //{
//        //    // 1. Kiểm tra nghiệp vụ cơ bản và địa chỉ (Truyền thêm tỉnh/huyện)
//        //    string validateMsg = ValidateCommon(user, province, district);
//        //    if (validateMsg != "OK") return validateMsg;

//        //    // 2. Kiểm tra mật khẩu khớp
//        //    if (user.Password != confirmPass)
//        //        return "Mật khẩu xác nhận không khớp!";

//        //    // 3. Kiểm tra mã BHYT (Đặc thù của Bệnh nhân)
//        //    if (string.IsNullOrWhiteSpace(bhyt))
//        //        return "Vui lòng nhập mã số Bảo hiểm y tế!";

//        //    // Regex mẫu cho BHYT (ví dụ 15 ký tự - tùy theo yêu cầu đồ án của bạn)
//        //    if (!Regex.IsMatch(bhyt, @"^[A-Z]{2}\d{13}$"))
//        //        return "Mã số BHYT không đúng định dạng!";

//        //    // 4. Chuẩn hóa dữ liệu trước khi lưu
//        //    user.Residential_Address = $"{district}, {province}";
//        //    user.Created_At = DateTime.Now;
//        //    user.Status = "Active"; // Bệnh nhân thường được kích hoạt ngay không cần duyệt

//        //    // 5. Gọi DAL để thực thi
//        //    try
//        //    {
//        //        int newUserId = _dal.RegisterUserBasic(user);
//        //        if (newUserId > 0)
//        //        {
//        //            bool isDetailSaved = _dal.InsertPatientFull(newUserId, bhyt);
//        //            if (isDetailSaved) return "Success";

//        //            // Rollback thủ công
//        //            _dal.DeleteUser(newUserId);
//        //            return "Lỗi hệ thống khi lưu hồ sơ chi tiết bệnh nhân!";
//        //        }
//        //        return "Số điện thoại này có thể đã tồn tại!";
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return "Lỗi BUS (Hệ thống): " + ex.Message;
//        //    }
//        //}

//        //public string RegisterDoctor(UserDTO user, string confirmPass, string province, string district,
//        // string clinicName, int? locationId, List<DoctorSpecialtyDTO> listCerts)
//        //{
//        //    // 1. Kiểm tra thông tin chung (SĐT, CCCD, Địa chỉ...)
//        //    string validateMsg = ValidateCommon(user, province, district);
//        //    if (validateMsg != "OK") return validateMsg;

//        //    if (user.Password != confirmPass) return "Mật khẩu xác nhận không khớp!";
//        //    if (string.IsNullOrWhiteSpace(clinicName)) return "Vui lòng nhập tên phòng khám!";

//        //    // 2. Kiểm tra chi tiết từng chứng chỉ
//        //    if (listCerts == null || !listCerts.Any())
//        //        return "Bác sĩ phải có ít nhất một chứng chỉ chuyên khoa!";

//        //    foreach (var cert in listCerts)
//        //    {
//        //        if (cert.SpecialtyId <= 0)
//        //            return "Vui lòng chọn chuyên khoa cho tất cả chứng chỉ!";

//        //        if (string.IsNullOrWhiteSpace(cert.CertificateCode))
//        //            return "Vui lòng nhập đầy đủ mã chứng chỉ hành nghề!";

//        //        if (cert.Experience_Years < 0)
//        //            return "Năm cấp chứng chỉ không hợp lệ (lớn hơn năm hiện tại)!";

//        //        if (string.IsNullOrWhiteSpace(cert.CertificateImage) || cert.CertificateImage == "default_cert.jpg")
//        //            return "Vui lòng tải lên hình ảnh minh chứng cho tất cả chứng chỉ!";
//        //    }

//        //    // 3. Chuẩn hóa dữ liệu & Tính toán nghiệp vụ
//        //    user.Residential_Address = $"{district}, {province}";
//        //    user.Created_At = DateTime.Now;
//        //    user.Status = "Pending";

//        //    // Thực hiện cộng dồn thâm niên
//        //    int totalExp = listCerts.Sum(c => c.Experience_Years ?? 0);

//        //    // 4. Gọi DAL để lưu Database
//        //    try
//        //    {
//        //        int newUserId = _dal.RegisterUserBasic(user);
//        //        if (newUserId > 0)
//        //        {
//        //            // QUAN TRỌNG: Truyền thêm totalExp vào hàm DAL
//        //            bool isDetailSaved = _dal.InsertDoctorFull(
//        //                newUserId,
//        //                user.Residential_Address,
//        //                clinicName,
//        //                locationId,
//        //                listCerts,
//        //                totalExp // <--- Truyền tổng kinh nghiệm xuống đây
//        //            );

//        //            if (isDetailSaved) return "Success";

//        //            // Rollback thủ công nếu lỗi bước 2
//        //            _dal.DeleteUser(newUserId);
//        //            return "Lỗi hệ thống khi lưu hồ sơ chi tiết bác sĩ!";
//        //        }
//        //        return "Số điện thoại này đã tồn tại trong hệ thống!";
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return "Lỗi hệ thống (BUS): " + ex.Message;
//        //    }
//        //}

//        //// 4. Hàm kiểm tra hợp lệ chung (Dùng chung cho cả Doctor và Patient)
//        //private string ValidateCommon(UserDTO user, string province, string district)
//        //{
//        //    //int age = DateTime.Now.Year - user.Dob.Year;
//        //    int age = CalculateAge(user.Dob);

//        //    if (user.Dob.Date > DateTime.Now.AddYears(-age)) age--;

//        //    if (string.IsNullOrWhiteSpace(user.PhoneNumber) || string.IsNullOrWhiteSpace(user.FullName) ||
//        //        string.IsNullOrWhiteSpace(user.Password) )
//        //        return "Vui lòng điền đầy đủ các thông tin bắt buộc!";

//        //    // 3. KIỂM TRA TỈNH/HUYỆN (Phần bạn vừa nhắc)
//        //    if (string.IsNullOrWhiteSpace(province) || province == "--Chọn Tỉnh/Thành phố--" ||
//        //        string.IsNullOrWhiteSpace(district) || district == "--Chọn Quận/Huyện--")
//        //    {
//        //        return "Vui lòng chọn đầy đủ Tỉnh/Thành phố và Quận/Huyện!";
//        //    }

//        //    // Regex kiểm tra SĐT 10 số
//        //    if (!Regex.IsMatch(user.PhoneNumber, @"^\d{10}$"))
//        //        return "Số điện thoại yêu cầu đúng 10 chữ số!";

//        //    if (age >= 16)
//        //    {
//        //        // Nếu đủ 16 tuổi mà để trống CCCD
//        //        if (string.IsNullOrWhiteSpace(user.CCCD) || user.CCCD == "Chưa cập nhật")
//        //        {
//        //            return "Công dân từ đủ 16 tuổi yêu cầu phải có mã CCCD!";
//        //        }

//        //        // Kiểm tra định dạng 12 số nếu có nhập
//        //        if (!Regex.IsMatch(user.CCCD, @"^\d{12}$"))
//        //        {
//        //            return "Mã CCCD yêu cầu đúng 12 chữ số!";
//        //        }
//        //    }
//        //    else
//        //    {
//        //        user.CCCD = "Chưa cập nhật";
//        //    }

//        //    // Kiểm tra SĐT đã tồn tại chưa
//        //    if (_dal.IsPhoneExists(user.PhoneNumber))
//        //        return "Số điện thoại này đã được đăng ký!";

//        //    return "OK";
//        //}

//        public int CalculateAge(DateTime birthDate)
//        {
//            DateTime today = DateTime.Today;
//            int age = today.Year - birthDate.Year;
//            if (birthDate.Date > today.AddYears(-age)) age--;
//            return age;
//        }
//        // Trong LoginBUS.cs
//        public int CalculateExperience(int issuedYear)
//        {
//            int currentYear = DateTime.Now.Year; // Lấy năm hiện tại từ hệ thống, không fix cứng 2026
//            if (issuedYear > currentYear || issuedYear <= 0) return 0;
//            return currentYear - issuedYear;
//        }
//    }
//}



//using DAL_Tier;
//using DTO_Tier; 
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;

//namespace BUS_Tier
//{
//    public class UserBUS
//    {
//        // Khởi tạo DAL - MyDbContext phải được cấu hình trong DAL_Tier
//        private readonly UserDAL _dal = new UserDAL(new AppDbContext());

//        public string Login(string phone, string pass, out int userId, out string msg)
//        {
//            // Khởi tạo giá trị mặc định
//            userId = 0;
//            msg = "";

//            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
//            {
//                msg = "Vui lòng nhập đầy đủ số điện thoại và mật khẩu!";
//                return "";
//            }

//            var user = _dal.CheckLogin(phone, pass);

//            if (user != null)
//            {
//                userId = user.Id; // Trả ID về qua out
//                msg = "Đăng nhập thành công!";
//                return user.Role;     // Trả Role về để UI điều hướng
//            }

//            msg = "Số điện thoại hoặc mật khẩu không chính xác!";
//            return "";
//        }

//        //public string RegisterPatient(UserDTO user, string confirmPass, string province, string district, string bhyt)
//        //{
//        //    // 1. Kiểm tra nghiệp vụ cơ bản và địa chỉ (Truyền thêm tỉnh/huyện)
//        //    string validateMsg = ValidateCommon(user, province, district);
//        //    if (validateMsg != "OK") return validateMsg;

//        //    // 2. Kiểm tra mật khẩu khớp
//        //    if (user.Password != confirmPass)
//        //        return "Mật khẩu xác nhận không khớp!";

//        //    // 3. Kiểm tra mã BHYT (Đặc thù của Bệnh nhân)
//        //    if (string.IsNullOrWhiteSpace(bhyt))
//        //        return "Vui lòng nhập mã số Bảo hiểm y tế!";

//        //    // Regex mẫu cho BHYT (ví dụ 15 ký tự - tùy theo yêu cầu đồ án của bạn)
//        //    if (!Regex.IsMatch(bhyt, @"^[A-Z]{2}\d{13}$"))
//        //        return "Mã số BHYT không đúng định dạng!";

//        //    // 4. Chuẩn hóa dữ liệu trước khi lưu
//        //    user.Residential_Address = $"{district}, {province}";
//        //    user.Created_At = DateTime.Now;
//        //    user.Status = "Active"; // Bệnh nhân thường được kích hoạt ngay không cần duyệt

//        //    // 5. Gọi DAL để thực thi
//        //    try
//        //    {
//        //        int newUserId = _dal.RegisterUserBasic(user);
//        //        if (newUserId > 0)
//        //        {
//        //            bool isDetailSaved = _dal.InsertPatientFull(newUserId, bhyt);
//        //            if (isDetailSaved) return "Success";

//        //            // Rollback thủ công
//        //            _dal.DeleteUser(newUserId);
//        //            return "Lỗi hệ thống khi lưu hồ sơ chi tiết bệnh nhân!";
//        //        }
//        //        return "Số điện thoại này có thể đã tồn tại!";
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return "Lỗi BUS (Hệ thống): " + ex.Message;
//        //    }
//        //}

//        //public string RegisterDoctor(UserDTO user, string confirmPass, string province, string district,
//        // string clinicName, int? locationId, List<DoctorSpecialtyDTO> listCerts)
//        //{
//        //    // 1. Kiểm tra thông tin chung (SĐT, CCCD, Địa chỉ...)
//        //    string validateMsg = ValidateCommon(user, province, district);
//        //    if (validateMsg != "OK") return validateMsg;

//        //    if (user.Password != confirmPass) return "Mật khẩu xác nhận không khớp!";
//        //    if (string.IsNullOrWhiteSpace(clinicName)) return "Vui lòng nhập tên phòng khám!";

//        //    // 2. Kiểm tra chi tiết từng chứng chỉ
//        //    if (listCerts == null || !listCerts.Any())
//        //        return "Bác sĩ phải có ít nhất một chứng chỉ chuyên khoa!";

//        //    foreach (var cert in listCerts)
//        //    {
//        //        if (cert.SpecialtyId <= 0)
//        //            return "Vui lòng chọn chuyên khoa cho tất cả chứng chỉ!";

//        //        if (string.IsNullOrWhiteSpace(cert.CertificateCode))
//        //            return "Vui lòng nhập đầy đủ mã chứng chỉ hành nghề!";

//        //        if (cert.Experience_Years < 0)
//        //            return "Năm cấp chứng chỉ không hợp lệ (lớn hơn năm hiện tại)!";

//        //        if (string.IsNullOrWhiteSpace(cert.CertificateImage) || cert.CertificateImage == "default_cert.jpg")
//        //            return "Vui lòng tải lên hình ảnh minh chứng cho tất cả chứng chỉ!";
//        //    }

//        //    // 3. Chuẩn hóa dữ liệu & Tính toán nghiệp vụ
//        //    user.Residential_Address = $"{district}, {province}";
//        //    user.Created_At = DateTime.Now;
//        //    user.Status = "Pending";

//        //    // Thực hiện cộng dồn thâm niên
//        //    int totalExp = listCerts.Sum(c => c.Experience_Years ?? 0);

//        //    // 4. Gọi DAL để lưu Database
//        //    try
//        //    {
//        //        int newUserId = _dal.RegisterUserBasic(user);
//        //        if (newUserId > 0)
//        //        {
//        //            // QUAN TRỌNG: Truyền thêm totalExp vào hàm DAL
//        //            bool isDetailSaved = _dal.InsertDoctorFull(
//        //                newUserId,
//        //                user.Residential_Address,
//        //                clinicName,
//        //                locationId,
//        //                listCerts,
//        //                totalExp // <--- Truyền tổng kinh nghiệm xuống đây
//        //            );

//        //            if (isDetailSaved) return "Success";

//        //            // Rollback thủ công nếu lỗi bước 2
//        //            _dal.DeleteUser(newUserId);
//        //            return "Lỗi hệ thống khi lưu hồ sơ chi tiết bác sĩ!";
//        //        }
//        //        return "Số điện thoại này đã tồn tại trong hệ thống!";
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return "Lỗi hệ thống (BUS): " + ex.Message;
//        //    }
//        //}

//        //// 4. Hàm kiểm tra hợp lệ chung (Dùng chung cho cả Doctor và Patient)
//        //private string ValidateCommon(UserDTO user, string province, string district)
//        //{
//        //    //int age = DateTime.Now.Year - user.Dob.Year;
//        //    int age = CalculateAge(user.Dob);

//        //    if (user.Dob.Date > DateTime.Now.AddYears(-age)) age--;

//        //    if (string.IsNullOrWhiteSpace(user.PhoneNumber) || string.IsNullOrWhiteSpace(user.FullName) ||
//        //        string.IsNullOrWhiteSpace(user.Password) )
//        //        return "Vui lòng điền đầy đủ các thông tin bắt buộc!";

//        //    // 3. KIỂM TRA TỈNH/HUYỆN (Phần bạn vừa nhắc)
//        //    if (string.IsNullOrWhiteSpace(province) || province == "--Chọn Tỉnh/Thành phố--" ||
//        //        string.IsNullOrWhiteSpace(district) || district == "--Chọn Quận/Huyện--")
//        //    {
//        //        return "Vui lòng chọn đầy đủ Tỉnh/Thành phố và Quận/Huyện!";
//        //    }

//        //    // Regex kiểm tra SĐT 10 số
//        //    if (!Regex.IsMatch(user.PhoneNumber, @"^\d{10}$"))
//        //        return "Số điện thoại yêu cầu đúng 10 chữ số!";

//        //    if (age >= 16)
//        //    {
//        //        // Nếu đủ 16 tuổi mà để trống CCCD
//        //        if (string.IsNullOrWhiteSpace(user.CCCD) || user.CCCD == "Chưa cập nhật")
//        //        {
//        //            return "Công dân từ đủ 16 tuổi yêu cầu phải có mã CCCD!";
//        //        }

//        //        // Kiểm tra định dạng 12 số nếu có nhập
//        //        if (!Regex.IsMatch(user.CCCD, @"^\d{12}$"))
//        //        {
//        //            return "Mã CCCD yêu cầu đúng 12 chữ số!";
//        //        }
//        //    }
//        //    else
//        //    {
//        //        user.CCCD = "Chưa cập nhật";
//        //    }

//        //    // Kiểm tra SĐT đã tồn tại chưa
//        //    if (_dal.IsPhoneExists(user.PhoneNumber))
//        //        return "Số điện thoại này đã được đăng ký!";

//        //    return "OK";
//        //}

//        public int CalculateAge(DateTime birthDate)
//        {
//            DateTime today = DateTime.Today;
//            int age = today.Year - birthDate.Year;
//            if (birthDate.Date > today.AddYears(-age)) age--;
//            return age;
//        }
//        // Trong LoginBUS.cs
//        public int CalculateExperience(int issuedYear)
//        {
//            int currentYear = DateTime.Now.Year; // Lấy năm hiện tại từ hệ thống, không fix cứng 2026
//            if (issuedYear > currentYear || issuedYear <= 0) return 0;
//            return currentYear - issuedYear;
//        }
//    }
//}



using DAL_Tier;
using DTO_Tier;
using System;

namespace BUS_Tier
{
    public class UserBUS
    {
        private readonly UserDAL _userDAL = new UserDAL();
        private readonly AppDbContext _context = new AppDbContext();

        //public string Login(string phone, string pass, out int userId, out string msg)
        //{
        //    userId = 0;
        //    msg = "";

        //    // Gọi DAL lấy nguyên đối tượng User
        //    var user = _userDAL.CheckLogin(phone, pass);

        //    if (user != null)
        //    {
        //        // Lấy ID ở đây nề!
        //        userId = user.Id;
        //        msg = "Đăng nhập thành công!";
        //        return user.Role; // Trả về "Doctor" hoặc "Patient"
        //    }

        //    msg = "Số điện thoại hoặc mật khẩu không chính xác!";
        //    return "";
        //}

        public string Login(string phone, string pass, out int loggedInId, out string msg)
        {
            loggedInId = 0;
            msg = "";

            // 1. Gọi DAL xác thực tài khoản User
            var user = _userDAL.CheckLogin(phone, pass);

            if (user != null)
            {
                // 2. Dựa vào Role để lấy đúng ID của vai trò đó
                if (user.Role == "Doctor")
                {
                    // Tìm trong bảng Doctor xem ai có UserId này
                    var doctor = _context.Doctors.FirstOrDefault(d => d.UserId == user.Id);
                    if (doctor != null)
                    {
                        loggedInId = doctor.Id; // Đây mới là DoctorId (ví dụ: 1)
                    }
                }
                else if (user.Role == "Patient")
                {
                    // Tìm trong bảng Patient xem ai có UserId này
                    var patient = _context.Patients.FirstOrDefault(p => p.UserId == user.Id);
                    if (patient != null)
                    {
                        loggedInId = patient.Id; // Đây là PatientId
                    }
                }
                else // Role Admin hoặc trường hợp khác
                {
                    loggedInId = user.Id;
                }

                // Kiểm tra nếu tìm thấy ID vai trò
                if (loggedInId > 0)
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

            if (string.IsNullOrWhiteSpace(user.Password)) return "Mật khẩu không được để trống.";
            if (string.IsNullOrWhiteSpace(confirmPass)) return "Vui lòng xác nhận mật khẩu.";
            if (user.Password != confirmPass) return "Mật khẩu nhập lại không khớp.";

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
    }
}