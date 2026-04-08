//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DTO_Tier
//{
//    public class UserDTO
//    {
//        public int UserId { get; set; }
//        public string PhoneNumber { get; set; }
//        public string Password { get; set; }
//        public string FullName { get; set; }
//        public string Role { get; set; } // 'Admin', 'Doctor', 'Patient'
//        public bool Status { get; set; }
//    }
//}


using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_Tier
{
    public class UserDTO
    {
        // Khóa chính đã đồng bộ là UserId
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        // Vai trò người dùng: 'Admin', 'Doctor', 'Patient'
        public string Role { get; set; }

        // Trạng thái hoạt động (True: Active, False: Locked)
        public bool Status { get; set; }

        // --- CÁC TRƯỜNG MỚI BỔ SUNG TỪ DB CHUẨN HÓA V2.0 ---

        // Ngày sinh (Nullable vì trong DB chúng ta để Allow Null)
        public DateTime? Dob { get; set; }

        // Giới tính (Nam, Nữ, Khác)
        public string Gender { get; set; }

        // Số Căn cước công dân
        public string CCCD { get; set; }

        // Đường dẫn ảnh chân dung hoặc chuỗi Base64
        public string Picture { get; set; }
    }
}