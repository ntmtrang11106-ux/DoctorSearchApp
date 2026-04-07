using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bus_Tier
{
    public class LoginBUS
    {
        private LoginDAL _dal = new LoginDAL();

        public string Login(string phone, string pass, string role)
        {
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
                return "Vui lòng nhập đầy đủ thông tin!";

            DataTable dt = _dal.CheckLogin(phone, pass, role);
            if (dt != null && dt.Rows.Count > 0) return "Success";

            return "Số điện thoại hoặc mật khẩu không chính xác!";
        }

        // 1. Hàm Đăng ký (Dùng cho Form Register)
        // Cập nhật hàm Register để nhận thêm Ngày sinh và Giới tính cho Bệnh nhân
        public string Register(string phone, string name, string pass, string confirm, string role, DateTime dob, string gender)
        {
            // 1. Kiểm tra logic cơ bản
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
                return "Vui lòng nhập đầy đủ các trường!";

            if (phone.Length != 10) return "Số điện thoại phải có 10 chữ số!";

            if (pass != confirm) return "Mật khẩu xác nhận không khớp!";

            if (_dal.IsPhoneExists(phone)) return "Số điện thoại này đã được đăng ký!";

            // 2. Tạo đối tượng UserDTO
            UserDTO newUser = new UserDTO
            {
                PhoneNumber = phone,
                FullName = name,
                Password = pass,
                Role = role
            };

            // 3. Thực hiện lưu vào bảng Users và lấy UserId vừa tạo
            // (Lưu ý: Hàm RegisterUser ở tầng DAL lúc này phải trả về kiểu int)
            int newUserId = _dal.RegisterUser(newUser);

            if (newUserId > 0)
            {
                // 4. Dựa vào Role để lưu vào bảng chi tiết
                if (role == "Patient")
                {
                    // Lưu vào bảng Patients
                    bool isSaved = _dal.InsertPatient(newUserId, dob, gender);
                    return isSaved ? "Success" : "Lỗi: Không thể khởi tạo dữ liệu Bệnh nhân!";
                }
                else if (role == "Doctor")
                {
                    // Lưu vào bảng Doctors (Chỉ cần tạo dòng với UserId, các thông tin khác cập nhật sau)
                    bool isSaved = _dal.InsertDoctor(newUserId);
                    return isSaved ? "Success" : "Lỗi: Không thể khởi tạo dữ liệu Bác sĩ!";
                }
                return "Success";
            }

            return "Đăng ký thất bại, lỗi hệ thống tại bảng Users!";
        }
    }
}
