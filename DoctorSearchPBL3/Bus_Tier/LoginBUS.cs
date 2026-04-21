using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace BUS_Tier
{
    public class LoginBUS
    {
        private LoginDAL _dal = new LoginDAL();

        // 1. Logic Đăng nhập
        public string Login(string phone, string pass)
        {
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
                return "Vui lòng nhập đầy đủ số điện thoại và mật khẩu!";

            DataTable dt = _dal.CheckLogin(phone, pass);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Trả về vai trò để UI điều hướng (Admin, Doctor, Patient)
                return dt.Rows[0]["Role"].ToString();
            }

            return "Số điện thoại hoặc mật khẩu không chính xác!";
        }

        // 2. Logic Đăng ký Bệnh nhân
        public string RegisterPatient(UserDTO user, string confirmPass, string bhyt)
        {
            // Kiểm tra khớp mật khẩu (Mới thêm)
            if (user.Password != confirmPass)
                return "Mật khẩu xác nhận không khớp!";

            // Kiểm tra các thông tin chung
            string validateMsg = ValidateCommon(user);
            if (validateMsg != "OK") return validateMsg;

            // Kiểm tra nghiệp vụ BHYT
            if (string.IsNullOrWhiteSpace(bhyt))
                return "Vui lòng nhập mã số Bảo hiểm y tế!";

            if (!Regex.IsMatch(bhyt, @"^[A-Z]{2}\d{13}$"))
                return "Mã BHYT không đúng định dạng chuẩn (Ví dụ: TE15100...)!";

            // Thực hiện lưu dữ liệu
            int newUserId = _dal.RegisterUserBasic(user);
            if (newUserId > 0)
            {
                bool isDetailSaved = _dal.InsertPatientFull(newUserId, bhyt);
                if (isDetailSaved) return "Success";

                _dal.DeleteUser(newUserId); // Rollback
                return "Lỗi khi lưu thông tin chi tiết bệnh nhân!";
            }
            return "Đăng ký tài khoản thất bại!";
        }

        // 3. Logic Đăng ký Bác sĩ
        public string RegisterDoctor(UserDTO user, string confirmPass, string allCertCodes, string allCertImages,
                            string clinicAddr, string clinicName, int? locationId, List<int> specialtyIds)
        {
            // 1. Kiểm tra mật khẩu khớp
            if (user.Password != confirmPass) return "Mật khẩu xác nhận không khớp!";

            // 2. Kiểm tra nghiệp vụ bác sĩ
            if (string.IsNullOrWhiteSpace(allCertCodes))
                return "Vui lòng nhập ít nhất một mã chứng chỉ!";

            if (string.IsNullOrWhiteSpace(allCertImages))
                return "Vui lòng tải lên hình ảnh chứng chỉ!";

            if (specialtyIds == null || specialtyIds.Count == 0)
                return "Vui lòng chọn ít nhất một chuyên khoa!";

            // 3. Thực hiện lưu dữ liệu
            int newUserId = _dal.RegisterUserBasic(user);
            if (newUserId > 0)
            {
                // Truyền chuỗi đã gộp (cách nhau bởi dấu phẩy) xuống DAL
                bool isDetailSaved = _dal.InsertDoctorFull(newUserId, allCertCodes, allCertImages, clinicAddr, clinicName, "", locationId, specialtyIds);

                if (isDetailSaved) return "Success";

                // Nếu thất bại ở bước lưu chi tiết, thực hiện Rollback xóa User
                _dal.DeleteUser(newUserId);
                return "Lỗi khi lưu hồ sơ chi tiết bác sĩ!";
            }
            return "Đăng ký tài khoản bác sĩ thất bại!";
        }

        // 4. Hàm kiểm tra hợp lệ chung (Tối ưu cho 24T_DT1)
        private string ValidateCommon(UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.PhoneNumber) || string.IsNullOrWhiteSpace(user.FullName) ||
                string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.CCCD))
                return "Vui lòng điền đầy đủ các thông tin bắt buộc!";

            // Kiểm tra SĐT (Phải là 10 số)
            if (!Regex.IsMatch(user.PhoneNumber, @"^\d{10}$"))
                return "Số điện thoại không hợp lệ (yêu cầu đúng 10 chữ số)!";

            // Kiểm tra CCCD (Phải là 12 số)
            if (!Regex.IsMatch(user.CCCD, @"^\d{12}$"))
                return "Mã CCCD không hợp lệ (yêu cầu đúng 12 chữ số)!";

            // Kiểm tra trùng SĐT
            if (_dal.IsPhoneExists(user.PhoneNumber))
                return "Số điện thoại này đã được đăng ký trên hệ thống!";

            return "OK";
        }
    }
}