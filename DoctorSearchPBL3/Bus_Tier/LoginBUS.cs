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
        public string RegisterPatient(UserDTO user, string bhyt)
        {
            // Kiểm tra chung (SĐT, Họ tên, Pass, CCCD 12 số)
            string validateMsg = ValidateCommon(user);
            if (validateMsg != "OK") return validateMsg;

            // Kiểm tra mã BHYT theo định dạng ảnh mẫu
            // Định dạng: 2 chữ cái đầu (VD: TE) + 13 chữ số tiếp theo
            if (string.IsNullOrWhiteSpace(bhyt))
                return "Vui lòng nhập mã số Bảo hiểm y tế!";

            if (!Regex.IsMatch(bhyt, @"^[A-Z]{2}\d{13}$"))
                return "Mã BHYT không đúng định dạng chuẩn (Ví dụ: TE15100...)!";

            // Bước 1: Lưu bảng [User]
            int newUserId = _dal.RegisterUserBasic(user);
            if (newUserId > 0)
            {
                // Bước 2: Lưu bảng Patient (Gọi đúng hàm InsertPatientFull vừa sửa ở DAL)
                bool isDetailSaved = _dal.InsertPatientFull(newUserId, bhyt);

                if (isDetailSaved) return "Success";

                // Nếu lỗi bảng con thì xóa bảng cha để tránh rác dữ liệu
                _dal.DeleteUser(newUserId);
                return "Lỗi khi lưu thông tin chi tiết bệnh nhân!";
            }
            return "Đăng ký tài khoản thất bại!";
        }

        // 3. Logic Đăng ký Bác sĩ
        public string RegisterDoctor(UserDTO user, string certImages, string clinicAddr, string clinicName, List<int> specialtyIds)
        {
            // Kiểm tra chung
            string validateMsg = ValidateCommon(user);
            if (validateMsg != "OK") return validateMsg;

            // Kiểm tra nghiệp vụ bác sĩ
            if (specialtyIds == null || specialtyIds.Count == 0)
                return "Vui lòng chọn ít nhất một chuyên khoa!";
            if (string.IsNullOrWhiteSpace(certImages))
                return "Vui lòng cung cấp mã số chứng chỉ hành nghề!";
            if (string.IsNullOrWhiteSpace(clinicName))
                return "Vui lòng nhập tên bệnh viện/phòng khám công tác!";

            // Bước 1: Lưu bảng [User]
            int newUserId = _dal.RegisterUserBasic(user);
            if (newUserId > 0)
            {
                // Bước 2: Lưu bảng Doctor & Chuyên khoa (Hàm InsertDoctorFull đã sửa ở DAL)
                bool isDetailSaved = _dal.InsertDoctorFull(newUserId, certImages, clinicAddr, clinicName, "", specialtyIds);

                if (isDetailSaved) return "Success";

                _dal.DeleteUser(newUserId);
                return "Lỗi khi lưu hồ sơ bác sĩ!";
            }
            return "Đăng ký tài khoản thất bại!";
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