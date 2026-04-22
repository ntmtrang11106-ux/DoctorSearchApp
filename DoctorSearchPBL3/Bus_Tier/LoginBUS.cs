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
        // Khởi tạo DAL - MyDbContext phải được cấu hình trong DAL_Tier
        private readonly LoginDAL _dal = new LoginDAL(new AppDbContext());

        // 1. Logic Đăng nhập
        public string Login(string phone, string pass)
        {
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
                return "Vui lòng nhập đầy đủ số điện thoại và mật khẩu!";

            // Trả về đối tượng UserDTO từ EF
            var user = _dal.CheckLogin(phone, pass);

            if (user != null)
            {
                // Trả về Role (Admin, Doctor, Patient) để UI điều hướng
                return user.Role;
            }

            return "Số điện thoại hoặc mật khẩu không chính xác!";
        }

        // 2. Logic Đăng ký Bệnh nhân
        public string RegisterPatient(UserDTO user, string confirmPass, string bhyt)
        {
            if (user.Password != confirmPass)
                return "Mật khẩu xác nhận không khớp!";

            // Kiểm tra các ràng buộc chung (SĐT, CCCD...)
            string validateMsg = ValidateCommon(user);
            if (validateMsg != "OK") return validateMsg;

            if (string.IsNullOrWhiteSpace(bhyt))
                return "Vui lòng nhập mã số Bảo hiểm y tế!";

            // Thực hiện lưu qua DAL
            int newUserId = _dal.RegisterUserBasic(user);
            if (newUserId > 0)
            {
                bool isDetailSaved = _dal.InsertPatientFull(newUserId, bhyt);
                if (isDetailSaved) return "Success";

                // Nếu lưu bảng Patient lỗi thì xóa User vừa tạo (Rollback thủ công)
                _dal.DeleteUser(newUserId);
                return "Lỗi khi lưu thông tin chi tiết bệnh nhân!";
            }
            return "Đăng ký tài khoản thất bại!";
        }

        // 3. Logic Đăng ký Bác sĩ
        public string RegisterDoctor(UserDTO user, string confirmPass, string province, string district,
                             string clinicName, int? locationId, List<DoctorSpecialtyDTO> listCerts)
        {
            // --- BƯỚC 1: Kiểm tra hợp lệ ---
            string validateMsg = ValidateCommon(user);
            if (validateMsg != "OK") return validateMsg;

            if (user.Password != confirmPass) return "Mật khẩu xác nhận không khớp!";
            if (string.IsNullOrWhiteSpace(clinicName)) return "Vui lòng nhập tên phòng khám!";

            // Lọc: Chỉ lấy những chứng chỉ có nhập mã (CertificateCode) hợp lệ
            var validCerts = listCerts?.Where(c => !string.IsNullOrWhiteSpace(c.CertificateCode)).ToList();

            if (validCerts == null || !validCerts.Any())
                return "Bác sĩ phải có ít nhất một chứng chỉ chuyên khoa hợp lệ!";

            if (string.IsNullOrWhiteSpace(province) || string.IsNullOrWhiteSpace(district))
                return "Vui lòng chọn đầy đủ địa chỉ!";

            // --- BƯỚC 2: Xử lý nghiệp vụ ---
            user.Residential_Address = $"{district}, {province}";
            user.Created_At = DateTime.Now;

            try
            {
                // Bước 1: Lưu User cơ bản
                int newUserId = _dal.RegisterUserBasic(user);

                if (newUserId > 0)
                {
                    // Bước 2: Lưu Doctor (DAL sẽ tự tính Max Experience_Years để lưu vào ExperienceSummary)
                    bool isDetailSaved = _dal.InsertDoctorFull(
                        newUserId,
                        user.Residential_Address,
                        clinicName,
                        locationId,
                        validCerts // Dùng danh sách đã lọc sạch
                    );

                    if (isDetailSaved) return "Success";

                    // Xóa User nếu lưu hồ sơ chi tiết lỗi để tránh rác DB
                    _dal.DeleteUser(newUserId);
                    return "Lỗi hệ thống khi lưu hồ sơ bác sĩ!";
                }
                return "Đăng ký tài khoản thất bại (Số điện thoại có thể đã tồn tại)!";
            }
            catch (Exception ex)
            {
                return "Lỗi BUS: " + ex.Message;
            }
        }

        // 4. Hàm kiểm tra hợp lệ chung (Dùng chung cho cả Doctor và Patient)
        private string ValidateCommon(UserDTO user)
        {
            int age = DateTime.Now.Year - user.Dob.Year;
            if (user.Dob.Date > DateTime.Now.AddYears(-age)) age--;

            if (string.IsNullOrWhiteSpace(user.PhoneNumber) || string.IsNullOrWhiteSpace(user.FullName) ||
                string.IsNullOrWhiteSpace(user.Password) )
                return "Vui lòng điền đầy đủ các thông tin bắt buộc!";

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
    }
}