using DAL_Tier;
using DTO_Tier; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BUS_Tier
{
    public class LoginBUS
    {
        // Khởi tạo các tầng DAL cần thiết
        private readonly LoginDAL _dal = new LoginDAL();
        private readonly DoctorDAL _doctorDAL = new DoctorDAL();
        private readonly PatientDAL _patientDAL = new PatientDAL();

        public string Login(string phone, string pass, out int actorId, out string message)
        {
            actorId = 0;

            // 1. Kiểm tra tài khoản trong bảng Users (Sử dụng LoginDAL của nhóm)
            // Giả sử hàm CheckLogin trả về đối tượng UserDTO hoặc User model
            var user = _dal.CheckLogin(phone, pass);

            if (user == null)
            {
                message = "Số điện thoại hoặc mật khẩu không đúng!";
                return null;
            }

            // 2. Nếu login đúng, thực hiện ÁNH XẠ (Mapping) ID ngay lập tức
            if (user.Role == "Doctor")
            {
                // Tìm DoctorId thực tế (Số 1) dựa trên UserId (Số 2)
                actorId = _doctorDAL.GetDoctorIdByUserId(user.Id);

                if (actorId <= 0)
                {
                    message = "Lỗi: Tài khoản bác sĩ chưa được tạo hồ sơ chuyên môn!";
                    return null;
                }

                message = "Đăng nhập bác sĩ thành công!";
                return "Doctor";
            }
            else if (user.Role == "Patient")
            {
                // Tìm PatientId thực tế dựa trên UserId
                actorId = _patientDAL.GetPatientIdByUserId(user.Id);

                if (actorId <= 0)
                {
                    message = "Lỗi: Tài khoản bệnh nhân chưa được kích hoạt hồ sơ!";
                    return null;
                }

                message = "Đăng nhập bệnh nhân thành công!";
                return "Patient";
            }

            message = "Tài khoản không có quyền truy cập hệ thống!";
            return null;
        }

        public string RegisterPatient(UserDTO user, string confirmPass, string province, string district, string bhyt)
        {
            // 1. Kiểm tra nghiệp vụ cơ bản và địa chỉ (Truyền thêm tỉnh/huyện)
            string validateMsg = ValidateCommon(user, province, district);
            if (validateMsg != "OK") return validateMsg;

            // 2. Kiểm tra mật khẩu khớp
            if (user.Password != confirmPass)
                return "Mật khẩu xác nhận không khớp!";

            // 3. Kiểm tra mã BHYT (Đặc thù của Bệnh nhân)
            if (string.IsNullOrWhiteSpace(bhyt))
                return "Vui lòng nhập mã số Bảo hiểm y tế!";

            // Regex mẫu cho BHYT (ví dụ 15 ký tự - tùy theo yêu cầu đồ án của bạn)
            if (!Regex.IsMatch(bhyt, @"^[A-Z]{2}\d{13}$"))
                return "Mã số BHYT không đúng định dạng!";

            // 4. Chuẩn hóa dữ liệu trước khi lưu
            user.Residential_Address = $"{district}, {province}";
            user.Created_At = DateTime.Now;
            user.Status = "Active"; // Bệnh nhân thường được kích hoạt ngay không cần duyệt

            // 5. Gọi DAL để thực thi
            try
            {
                int newUserId = _dal.RegisterUserBasic(user);
                if (newUserId > 0)
                {
                    bool isDetailSaved = _dal.InsertPatientFull(newUserId, bhyt);
                    if (isDetailSaved) return "Success";

                    // Rollback thủ công
                    _dal.DeleteUser(newUserId);
                    return "Lỗi hệ thống khi lưu hồ sơ chi tiết bệnh nhân!";
                }
                return "Số điện thoại này có thể đã tồn tại!";
            }
            catch (Exception ex)
            {
                return "Lỗi BUS (Hệ thống): " + ex.Message;
            }
        }

        public string RegisterDoctor(UserDTO user, string confirmPass, string province, string district,
         string clinicName, int? locationId, List<DoctorSpecialtyDTO> listCerts)
        {
            // 1. Kiểm tra thông tin chung (SĐT, CCCD, Địa chỉ...)
            string validateMsg = ValidateCommon(user, province, district);
            if (validateMsg != "OK") return validateMsg;

            if (user.Password != confirmPass) return "Mật khẩu xác nhận không khớp!";
            if (string.IsNullOrWhiteSpace(clinicName)) return "Vui lòng nhập tên phòng khám!";

            // 2. Kiểm tra chi tiết từng chứng chỉ
            if (listCerts == null || !listCerts.Any())
                return "Bác sĩ phải có ít nhất một chứng chỉ chuyên khoa!";

            foreach (var cert in listCerts)
            {
                if (cert.SpecialtyId <= 0)
                    return "Vui lòng chọn chuyên khoa cho tất cả chứng chỉ!";

                if (string.IsNullOrWhiteSpace(cert.CertificateCode))
                    return "Vui lòng nhập đầy đủ mã chứng chỉ hành nghề!";

                if (cert.Experience_Years < 0)
                    return "Năm cấp chứng chỉ không hợp lệ (lớn hơn năm hiện tại)!";

                if (string.IsNullOrWhiteSpace(cert.CertificateImage) || cert.CertificateImage == "default_cert.jpg")
                    return "Vui lòng tải lên hình ảnh minh chứng cho tất cả chứng chỉ!";
            }

            // 3. Chuẩn hóa dữ liệu & Tính toán nghiệp vụ
            user.Residential_Address = $"{district}, {province}";
            user.Created_At = DateTime.Now;
            user.Status = "Pending";

            // Thực hiện cộng dồn thâm niên
            int totalExp = listCerts.Sum(c => c.Experience_Years ?? 0);

            // 4. Gọi DAL để lưu Database
            try
            {
                int newUserId = _dal.RegisterUserBasic(user);
                if (newUserId > 0)
                {
                    // QUAN TRỌNG: Truyền thêm totalExp vào hàm DAL
                    bool isDetailSaved = _dal.InsertDoctorFull(
                        newUserId,
                        user.Residential_Address,
                        clinicName,
                        locationId,
                        listCerts,
                        totalExp // <--- Truyền tổng kinh nghiệm xuống đây
                    );

                    if (isDetailSaved) return "Success";

                    // Rollback thủ công nếu lỗi bước 2
                    _dal.DeleteUser(newUserId);
                    return "Lỗi hệ thống khi lưu hồ sơ chi tiết bác sĩ!";
                }
                return "Số điện thoại này đã tồn tại trong hệ thống!";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống (BUS): " + ex.Message;
            }
        }

        // 4. Hàm kiểm tra hợp lệ chung (Dùng chung cho cả Doctor và Patient)
        private string ValidateCommon(UserDTO user, string province, string district)
        {
            //int age = DateTime.Now.Year - user.Dob.Year;
            int age = CalculateAge(user.Dob);

            if (user.Dob.Date > DateTime.Now.AddYears(-age)) age--;

            if (string.IsNullOrWhiteSpace(user.PhoneNumber) || string.IsNullOrWhiteSpace(user.FullName) ||
                string.IsNullOrWhiteSpace(user.Password) )
                return "Vui lòng điền đầy đủ các thông tin bắt buộc!";

            // 3. KIỂM TRA TỈNH/HUYỆN (Phần bạn vừa nhắc)
            if (string.IsNullOrWhiteSpace(province) || province == "--Chọn Tỉnh/Thành phố--" ||
                string.IsNullOrWhiteSpace(district) || district == "--Chọn Quận/Huyện--")
            {
                return "Vui lòng chọn đầy đủ Tỉnh/Thành phố và Quận/Huyện!";
            }

            // Regex kiểm tra SĐT 10 số
            if (!Regex.IsMatch(user.PhoneNumber, @"^\d{10}$"))
                return "Số điện thoại yêu cầu đúng 10 chữ số!";

            if (age >= 16)
            {
                // Nếu đủ 16 tuổi mà để trống CCCD
                if (string.IsNullOrWhiteSpace(user.CCCD) || user.CCCD == "Chưa cập nhật")
                {
                    return "Công dân từ đủ 16 tuổi yêu cầu phải có mã CCCD!";
                }

                // Kiểm tra định dạng 12 số nếu có nhập
                if (!Regex.IsMatch(user.CCCD, @"^\d{12}$"))
                {
                    return "Mã CCCD yêu cầu đúng 12 chữ số!";
                }
            }
            else
            {
                user.CCCD = "Chưa cập nhật";
            }

            // Kiểm tra SĐT đã tồn tại chưa
            if (_dal.IsPhoneExists(user.PhoneNumber))
                return "Số điện thoại này đã được đăng ký!";

            return "OK";
        }

        public int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
        // Trong LoginBUS.cs
        public int CalculateExperience(int issuedYear)
        {
            int currentYear = DateTime.Now.Year; // Lấy năm hiện tại từ hệ thống, không fix cứng 2026
            if (issuedYear > currentYear || issuedYear <= 0) return 0;
            return currentYear - issuedYear;
        }
    }
}