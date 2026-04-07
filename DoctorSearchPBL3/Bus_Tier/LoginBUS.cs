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

        public string Register(string phone, string name, string pass, string confirmPass)
        {
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
                return "Vui lòng điền đầy đủ thông tin!";
            if (phone.Length != 10) return "SĐT phải đủ 10 số!";
            if (pass != confirmPass) return "Mật khẩu xác nhận không khớp!";
            if (_dal.IsPhoneExists(phone)) return "SĐT này đã tồn tại!";

            UserDTO newUser = new UserDTO { PhoneNumber = phone, FullName = name, Password = pass };
            return _dal.Register(newUser) ? "Success" : "Lỗi hệ thống khi đăng ký!";
        }
    }
}
