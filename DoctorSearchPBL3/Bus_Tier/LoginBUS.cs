using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BUS_Tier
{
    public class LoginBUS
    {
        private LoginDAL _dal = new LoginDAL();

        public string Login(string phone, string pass)
        {
            // 1. Kiểm tra đầu vào cơ bản
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
                return "Vui lòng nhập đầy đủ thông tin!";

            // 2. Gọi tầng DAL để lấy dữ liệu. 
            // Lưu ý: DAL.CheckLogin bây giờ chỉ cần phone và pass.
            DataTable dt = _dal.CheckLogin(phone, pass);

            if (dt != null && dt.Rows.Count > 0)
            {
                // 3. Lấy giá trị của cột "Role" từ dòng đầu tiên tìm thấy
                string userRole = dt.Rows[0]["Role"].ToString();
                return userRole;
            }

            return "Số điện thoại hoặc mật khẩu không chính xác!";
        }

        // 2. Chức năng Đăng ký (Sử dụng các hàm lẻ từ DAL)
        // Thêm các tham số cho Patient và Doctor
        public string Register(string phone, string name, string pass, string confirm, string role,
                              DateTime dob, string gender,
                              string cccd = null, string bhyt = null, string address = null, // Cho Patient
                              string specialty = null, string license = null // Cho Doctor
                              )
        {
            // --- BƯỚC 1: VALIDATION CHUNG ---
            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirm))
                return "Vui lòng nhập đầy đủ các trường!";

            // --- BƯỚC 2: ĐÓNG GÓI USER ---
            UserDTO newUser = new UserDTO { /* ... như cũ ... */ };

            // --- BƯỚC 3: THỰC THI ---
            int newUserId = _dal.RegisterUserBasic(newUser);

            if (newUserId > 0)
            {
                bool isDetailSaved = false;

                if (role == "Patient")
                {
                    // Truyền thêm các thông tin từ giao diện vào
                    isDetailSaved = _dal.InsertPatientFull(newUserId, cccd, bhyt, address);
                }
                else if (role == "Doctor")
                {
                    // Truyền thêm thông tin chuyên ngành
                    isDetailSaved = _dal.InsertDoctorFull(newUserId, specialty, license);
                }

                if (isDetailSaved) return "Success";

                _dal.DeleteUser(newUserId);
                return "Lỗi khởi tạo hồ sơ chi tiết!";
            }
            return "Đăng ký thất bại!";
        }
    }
}


///