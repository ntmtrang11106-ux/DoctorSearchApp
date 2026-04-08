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
                // Giả sử trong database bạn đặt tên cột là "Role" hoặc "UserRole"
                string userRole = dt.Rows[0]["Role"].ToString();
                return userRole;
            }

            return "Số điện thoại hoặc mật khẩu không chính xác!";
        }

        // 1. Hàm Đăng ký (Dùng cho Form Register)
        // Cập nhật hàm Register để nhận thêm Ngày sinh và Giới tính cho Bệnh nhân
        //public string Register(string phone, string name, string pass, string confirm, string role, DateTime dob, string gender)
        //{
        //    // 1. Kiểm tra logic cơ bản
        //    if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
        //        return "Vui lòng nhập đầy đủ các trường!";

        //    if (phone.Length != 10) return "Số điện thoại phải có 10 chữ số!";

        //    if (pass != confirm) return "Mật khẩu xác nhận không khớp!";

        //    if (_dal.IsPhoneExists(phone)) return "Số điện thoại này đã được đăng ký!";

        //    // 2. Tạo đối tượng UserDTO
        //    UserDTO newUser = new UserDTO
        //    {
        //        PhoneNumber = phone,
        //        FullName = name,
        //        Password = pass,
        //        Role = role
        //    };

        //    // 3. Thực hiện lưu vào bảng Users và lấy UserId vừa tạo
        //    // (Lưu ý: Hàm RegisterUser ở tầng DAL lúc này phải trả về kiểu int)
        //    int newUserId = _dal.RegisterUser(newUser);

        //    if (newUserId > 0)
        //    {
        //        // 4. Dựa vào Role để lưu vào bảng chi tiết
        //        if (role == "Patient")
        //        {
        //            // Lưu vào bảng Patients
        //            bool isSaved = _dal.InsertPatient(newUserId, dob, gender);
        //            return isSaved ? "Success" : "Lỗi: Không thể khởi tạo dữ liệu Bệnh nhân!";
        //        }
        //        else if (role == "Doctor")
        //        {
        //            // Lưu vào bảng Doctors (Chỉ cần tạo dòng với UserId, các thông tin khác cập nhật sau)
        //            bool isSaved = _dal.InsertDoctor(newUserId);
        //            return isSaved ? "Success" : "Lỗi: Không thể khởi tạo dữ liệu Bác sĩ!";
        //        }
        //        return "Success";
        //    }

        //    return "Đăng ký thất bại, lỗi hệ thống tại bảng Users!";
        //}


        //public string Register(string phone, string name, string pass, string confirm, string role, DateTime dob, string gender)
        //{
        //    // 1. Kiểm tra logic nhập liệu (Validation)
        //    if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(name) ||
        //        string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirm))
        //        return "Vui lòng nhập đầy đủ các trường!";

        //    if (phone.Length != 10)
        //        return "Số điện thoại phải có đúng 10 chữ số!";

        //    if (pass != confirm)
        //        return "Mật khẩu xác nhận không khớp!";

        //    // 2. Kiểm tra sự tồn tại của SĐT (Sử dụng DAL)
        //    if (_dal.IsPhoneExists(phone))
        //        return "Số điện thoại này đã được đăng ký!";

        //    // 3. Đóng gói dữ liệu vào DTO
        //    UserDTO newUser = new UserDTO
        //    {
        //        PhoneNumber = phone,
        //        FullName = name,
        //        Password = pass,
        //        Role = role
        //    };

        //    // 4. Gọi hàm DAL xử lý Giao dịch (Transaction)
        //    // Hàm này sẽ tự động: Thêm vào Users -> Lấy ID -> Thêm vào Patients/Doctors
        //    // Nếu có bất kỳ lỗi nào ở giữa, nó sẽ Rollback (tự xóa) và trả về false.
        //    bool isSuccess = _dal.RegisterFullAccount(newUser, dob, gender);

        //    if (isSuccess)
        //    {
        //        return "Success";
        //    }
        //    else
        //    {
        //        // Vì dùng Transaction nên nếu vào đây, SQL hoàn toàn sạch sẽ, không có dữ liệu rác
        //        return "Đăng ký thất bại: Lỗi hệ thống trong quá trình lưu hồ sơ!";
        //    }
        //}

        // 2. Chức năng Đăng ký (Sử dụng các hàm lẻ từ DAL)
        public string Register(string phone, string name, string pass, string confirm, string role, DateTime dob, string gender)
        {
            // --- BƯỚC 1: KIỂM TRA NHẬP LIỆU (VALIDATION) ---
            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirm))
                return "Vui lòng nhập đầy đủ các trường!";

            if (phone.Length != 10)
                return "Số điện thoại phải có đúng 10 chữ số!";

            if (pass != confirm)
                return "Mật khẩu xác nhận không khớp!";

            if (_dal.IsPhoneExists(phone))
                return "Số điện thoại này đã được đăng ký!";

            // --- BƯỚC 2: ĐÓNG GÓI DỮ LIỆU ---
            // Đưa Dob và Gender vào UserDTO vì DB mới lưu ở bảng Users
            UserDTO newUser = new UserDTO
            {
                PhoneNumber = phone,
                FullName = name,
                Password = pass,
                Role = role,
                Dob = dob,
                Gender = gender,
                Status = true // Mặc định kích hoạt
            };

            // --- BƯỚC 3: THỰC THI LƯU DỮ LIỆU ---

            // 3.1. Lưu vào bảng Users trước để lấy UserId
            int newUserId = _dal.RegisterUserBasic(newUser);

            if (newUserId > 0)
            {
                bool isDetailSaved = false;

                // 3.2. Dựa vào Role để chèn vào bảng con tương ứng
                if (role == "Patient")
                {
                    // Chèn vào bảng Patients (chỉ cần UserId để giữ liên kết)
                    isDetailSaved = _dal.InsertPatientMinimal(newUserId);
                }
                else if (role == "Doctor")
                {
                    // Chèn vào bảng Doctors (chỉ cần UserId để giữ liên kết)
                    isDetailSaved = _dal.InsertDoctorMinimal(newUserId);
                }

                // Kiểm tra kết quả chèn bảng con
                if (isDetailSaved)
                {
                    return "Success";
                }
                else
                {
                    // LỖI: Xóa User vừa tạo để tránh rác
                    _dal.DeleteUser(newUserId); // Bạn cần viết thêm hàm Delete này trong DAL
                    return "Tài khoản đã tạo nhưng lỗi khởi tạo hồ sơ chi tiết!";
                }
            }

            return "Đăng ký thất bại: Lỗi hệ thống tại bảng Users!";
        }
    }
}
