using System;

namespace DTO_Tier
{
    public class DoctorDTO
    {
        // --- THÔNG TIN ĐỊNH DANH ---

        // Khóa ngoại liên kết trực tiếp với bảng Users (Primary Key của bảng Doctors hiện tại)
        public int UserId { get; set; }

        // --- THÔNG TIN CÁ NHÂN (LẤY TỪ BẢNG USERS THÔNG QUA JOIN) ---

        public string FullName { get; set; } = string.Empty;

        // Trạng thái tài khoản (Đã chuyển từ bool sang string: "Hoạt động" hoặc "Không hoạt động")
        public string Status { get; set; } = string.Empty;

        // Đường dẫn ảnh chân dung (Lưu ở bảng Users)
        public string Picture { get; set; }

        // Số định danh cá nhân (Lưu ở bảng Users)
        public string CCCD { get; set; } = string.Empty;

        // Số điện thoại (Nếu cần hiển thị liên hệ - Join từ bảng Users)
        public string PhoneNumber { get; set; } = string.Empty;


        // --- THÔNG TIN CHUYÊN MÔN (BẢNG DOCTORS) ---

        // Chứng chỉ hành nghề (cchn) - Hiện tại đã cho phép NULL trong DB
        public string Cchn { get; set; } = string.Empty;

        public string Workplace { get; set; } = string.Empty;

        public string SpecificAddress { get; set; } = string.Empty;

        public int ExperienceYears { get; set; }

        public string Bio { get; set; } = string.Empty;

        // Giờ làm việc (Cột mới thêm vào theo yêu cầu: "08:00 - 17:00")
        public string WorkingTime { get; set; } = string.Empty;

        // Giá khám (Trong SQL đang để NVARCHAR(50) nên dùng string để linh hoạt, 
        // hoặc dùng decimal nếu bạn muốn tính toán số học)
        public string Price { get; set; } = "0";


        // --- THÔNG TIN LIÊN KẾT (JOIN TỪ BẢNG KHÁC) ---

        // Tên khu vực (Join từ bảng Locations qua LocationId)
        public string LocationName { get; set; } = string.Empty;

        // Tên chuyên khoa (Join từ bảng Specialties qua SpecialtyId)
        public string SpecialtyName { get; set; } = string.Empty;


        // --- THÔNG TIN THỐNG KÊ (SUBQUERY HOẶC TÍNH TOÁN) ---

        // Điểm đánh giá trung bình (Ví dụ: 4.5/5)
        public double AverageRating { get; set; }

        // Tổng số lượt bệnh nhân đã đánh giá
        public int TotalReviews { get; set; }
    }
}