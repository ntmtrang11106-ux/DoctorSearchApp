//using DAL_Tier;
//using DTO_Tier;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Text.RegularExpressions;

//namespace BUS_Tier
//{
//    public class LoginBUS
//    {
//        private LoginDAL _dal = new LoginDAL();

//        // 1. Logic Đăng nhập
//        public string Login(string phone, string pass)
//        {
//            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
//                return "Vui lòng nhập đầy đủ số điện thoại và mật khẩu!";

//            DataTable dt = _dal.CheckLogin(phone, pass);

//            if (dt != null && dt.Rows.Count > 0)
//            {
//                // Trả về vai trò để UI điều hướng (Admin, Doctor, Patient)
//                return dt.Rows[0]["Role"].ToString();
//            }

//            return "Số điện thoại hoặc mật khẩu không chính xác!";
//        }

//        // 2. Logic Đăng ký Bệnh nhân
//        public string RegisterPatient(UserDTO user, string confirmPass, string bhyt)
//        {
//            // Kiểm tra khớp mật khẩu (Mới thêm)
//            if (user.Password != confirmPass)
//                return "Mật khẩu xác nhận không khớp!";

//            // Kiểm tra các thông tin chung
//            string validateMsg = ValidateCommon(user);
//            if (validateMsg != "OK") return validateMsg;

//            // Kiểm tra nghiệp vụ BHYT
//            if (string.IsNullOrWhiteSpace(bhyt))
//                return "Vui lòng nhập mã số Bảo hiểm y tế!";

//            if (!Regex.IsMatch(bhyt, @"^[A-Z]{2}\d{13}$"))
//                return "Mã BHYT không đúng định dạng chuẩn (Ví dụ: TE15100...)!";

//            // Thực hiện lưu dữ liệu
//            int newUserId = _dal.RegisterUserBasic(user);
//            if (newUserId > 0)
//            {
//                bool isDetailSaved = _dal.InsertPatientFull(newUserId, bhyt);
//                if (isDetailSaved) return "Success";

//                _dal.DeleteUser(newUserId); // Rollback
//                return "Lỗi khi lưu thông tin chi tiết bệnh nhân!";
//            }
//            return "Đăng ký tài khoản thất bại!";
//        }

//        // 3. Logic Đăng ký Bác sĩ
//        public string RegisterDoctor(UserDTO user, string confirmPass, string allCertCodes, string allCertImages,
//            string clinicAddr, string clinicName, int? locationId, List<int> specialtyIds)
//        {
//            // --- BƯỚC 1: KIỂM TRA THÔNG TIN CHUNG (SĐT, CCCD, TRỐNG TRƯỜNG) ---
//            string validateMsg = ValidateCommon(user);
//            if (validateMsg != "OK") return validateMsg;

//            if (user.Password != confirmPass) return "Mật khẩu xác nhận không khớp!";

//            // --- BƯỚC 2: KIỂM TRA NGHIỆP VỤ PHÒNG KHÁM ---
//            // Theo ảnh giao diện, textbox nơi công tác là bắt buộc
//            if (string.IsNullOrWhiteSpace(clinicName)) return "Vui lòng nhập nơi công tác hiện tại!";

//            // Nếu địa chỉ truyền xuống rỗng, ta gán giá trị mặc định thay vì để NULL
//            string finalClinicAddr = string.IsNullOrWhiteSpace(clinicAddr) ? "Chưa cập nhật địa chỉ" : clinicAddr;

//            // --- BƯỚC 3: KIỂM TRA DANH SÁCH CHỨNG CHỈ ---
//            if (string.IsNullOrWhiteSpace(allCertCodes))
//                return "Vui lòng nhập ít nhất một mã chứng chỉ!";

//            // Sử dụng StringSplitOptions.None để giữ nguyên số lượng phần tử nếu cần so khớp với mảng ảnh
//            var codesArray = allCertCodes.Split(new[] { ',' }, StringSplitOptions.TrimEntries);
//            var imagesArray = (allCertImages ?? "").Split(new[] { ',' }, StringSplitOptions.TrimEntries);

//            for (int i = 0; i < codesArray.Length; i++)
//            {
//                if (string.IsNullOrWhiteSpace(codesArray[i]))
//                    return $"Mã chứng chỉ hành nghề thứ {i + 1} không được để trống!";

//                // Kiểm tra ảnh: Nếu rỗng hoặc là default.jpg thì yêu cầu tải ảnh thật
//                if (i >= imagesArray.Length || string.IsNullOrWhiteSpace(imagesArray[i]))
//                    return $"Chứng chỉ số {codesArray[i]} chưa được tải hình ảnh minh họa!";
//            }

//            if (specialtyIds == null || specialtyIds.Count == 0)
//                return "Vui lòng chọn ít nhất một chuyên khoa cho bác sĩ!";

//            // --- BƯỚC 4: THỰC THI LƯU DỮ LIỆU ---
//            try
//            {
//                // 1. Tạo User trước (Trả về ID mới)
//                int newUserId = _dal.RegisterUserBasic(user);

//                if (newUserId > 0)
//                {
//                    // Các giá trị mặc định để tránh lỗi NOT NULL trong SQL (Bio, WorkingTime, Price, Exp)
//                    string defaultBio = "Chưa có thông tin giới thiệu.";

//                    // 2. Lưu chi tiết Doctor
//                    // Đảm bảo tầng DAL truyền các giá trị mặc định (0 cho Price/Exp) vào câu lệnh INSERT
//                    bool isDetailSaved = _dal.InsertDoctorFull(
//                        newUserId,
//                        allCertCodes,
//                        allCertImages,
//                        finalClinicAddr,
//                        clinicName,
//                        defaultBio,
//                        locationId,
//                        specialtyIds
//                    );

//                    if (isDetailSaved) return "Success";

//                    // Nếu lưu thông tin chi tiết lỗi -> Rollback xóa User để sạch Database
//                    _dal.DeleteUser(newUserId);
//                    return "Lỗi: Không thể lưu hồ sơ chi tiết bác sĩ. Hãy đảm bảo các thông tin chứng chỉ và nơi công tác đã đầy đủ!";
//                }
//                else
//                {
//                    return "Đăng ký tài khoản cơ bản thất bại (Có thể do lỗi kết nối hoặc dữ liệu không hợp lệ)!";
//                }
//            }
//            catch (Exception ex)
//            {
//                // Trả về lỗi chi tiết từ hệ thống để biết chính xác cột nào trong SQL đang bị lỗi
//                return "Lỗi hệ thống: " + ex.Message;
//            }
//        }


//        // 4. Hàm kiểm tra hợp lệ chung (Tối ưu cho 24T_DT1)
//        private string ValidateCommon(UserDTO user)
//        {
//            if (string.IsNullOrWhiteSpace(user.PhoneNumber) || string.IsNullOrWhiteSpace(user.FullName) ||
//                string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.CCCD))
//                return "Vui lòng điền đầy đủ các thông tin bắt buộc!";

//            // Kiểm tra SĐT (Phải là 10 số)
//            if (!Regex.IsMatch(user.PhoneNumber, @"^\d{10}$"))
//                return "Số điện thoại không hợp lệ (yêu cầu đúng 10 chữ số)!";

//            // Kiểm tra CCCD (Phải là 12 số)
//            if (!Regex.IsMatch(user.CCCD, @"^\d{12}$"))
//                return "Mã CCCD không hợp lệ (yêu cầu đúng 12 chữ số)!";

//            // Kiểm tra trùng SĐT
//            if (_dal.IsPhoneExists(user.PhoneNumber))
//                return "Số điện thoại này đã được đăng ký trên hệ thống!";

//            return "OK";
//        }
//    }
//}

using DAL_Tier;
using DTO_Tier; // Đảm bảo namespace này chứa các file trong ảnh của bạn
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
        public string RegisterDoctor(UserDTO user, string confirmPass, string allCertCodes, string allCertImages,
            string clinicAddr, string clinicName, int? locationId, List<int> specialtyIds)
        {
            // Kiểm tra hợp lệ dữ liệu
            string validateMsg = ValidateCommon(user);
            if (validateMsg != "OK") return validateMsg;

            if (user.Password != confirmPass) return "Mật khẩu xác nhận không khớp!";
            if (string.IsNullOrWhiteSpace(clinicName)) return "Vui lòng nhập nơi công tác!";
            if (specialtyIds == null || !specialtyIds.Any()) return "Vui lòng chọn ít nhất một chuyên khoa!";

            try
            {
                // Bước 1: Lưu thông tin User cơ bản
                int newUserId = _dal.RegisterUserBasic(user);

                if (newUserId > 0)
                {
                    // Bước 2: Lưu thông tin Doctor và các bản ghi DoctorSpecialtyDTO
                    bool isDetailSaved = _dal.InsertDoctorFull(
                        newUserId,
                        allCertCodes,
                        allCertImages,
                        clinicAddr,
                        clinicName,
                        "Chưa có giới thiệu", // Bio mặc định
                        locationId,
                        specialtyIds
                    );

                    if (isDetailSaved) return "Success";

                    // Rollback
                    _dal.DeleteUser(newUserId);
                    return "Lỗi lưu hồ sơ bác sĩ!";
                }
                return "Đăng ký tài khoản cơ bản thất bại!";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống: " + ex.Message;
            }
        }

        // 4. Hàm kiểm tra hợp lệ chung (Dùng chung cho cả Doctor và Patient)
        private string ValidateCommon(UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.PhoneNumber) || string.IsNullOrWhiteSpace(user.FullName) ||
                string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.CCCD))
                return "Vui lòng điền đầy đủ các thông tin bắt buộc!";

            // Regex kiểm tra SĐT 10 số
            if (!Regex.IsMatch(user.PhoneNumber, @"^\d{10}$"))
                return "Số điện thoại yêu cầu đúng 10 chữ số!";

            // Regex kiểm tra CCCD 12 số
            if (!Regex.IsMatch(user.CCCD, @"^\d{12}$"))
                return "Mã CCCD yêu cầu đúng 12 chữ số!";

            // Kiểm tra SĐT đã tồn tại chưa
            if (_dal.IsPhoneExists(user.PhoneNumber))
                return "Số điện thoại này đã được đăng ký!";

            return "OK";
        }
    }
}