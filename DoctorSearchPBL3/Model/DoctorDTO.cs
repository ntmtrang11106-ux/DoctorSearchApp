//namespace DTO_Tier
//{
//    public class DoctorDTO
//    {
//        public int Id { get; set; }
//        public string full_name { get; set; }
//        public string Workplace { get; set; }
//        public string LocationName { get; set; }
//        public string SpecialtyName { get; set; }
//        public int ExperienceYears { get; set; }
//        public double AvgRating { get; set; }
//        public int TotalReviews { get; set; }
//    }
//}

namespace DTO_Tier
{
    public class DoctorDTO
    {
        // --- THÔNG TIN ĐỊNH DANH ---

        // Khớp với cột Id (Primary Key) trong bảng Doctors
        public int Id { get; set; }

        // Khớp với cột UserId (Foreign Key) để liên kết với bảng Users
        public int UserId { get; set; }


        // --- THÔNG TIN LẤY TỪ BẢNG USERS (JOIN) ---

        // Lấy từ cột FullName trong bảng Users
        public string FullName { get; set; } = string.Empty;

        // Lấy từ cột Status trong bảng Users (Dùng string để dễ hiển thị lên UI)
        public string Status { get; set; } = string.Empty;


        // --- THÔNG TIN CHUYÊN MÔN (BẢNG DOCTORS) ---

        // Khớp với cột cchn (Chứng chỉ hành nghề) - NOT NULL
        public string Cchn { get; set; } = string.Empty;

        // Khớp với cột workplace
        public string Workplace { get; set; } = string.Empty;

        // Khớp với cột SpecificAddress
        public string SpecificAddress { get; set; } = string.Empty;

        // Khớp với cột experience_years
        public int ExperienceYears { get; set; }

        // Khớp với cột bio (Tiểu sử)
        public string Bio { get; set; } = string.Empty;

        // Khớp với cột Picture (Đường dẫn ảnh)
        public string Picture { get; set; } = "default.png";

        // Khớp với cột Price (Kiểu Decimal cho tiền tệ) - NOT NULL
        public decimal Price { get; set; }


        // --- THÔNG TIN LIÊN KẾT BẢNG KHÁC (JOIN) ---

        // Lấy từ bảng Locations (thông qua LocationId)
        public string LocationName { get; set; } = string.Empty;

        // Lấy từ bảng Specialties (thông qua SpecialtyId)
        public string SpecialtyName { get; set; } = string.Empty;


        // --- THÔNG TIN TÍNH TOÁN (SUBQUERY) ---

        // Trung bình cộng Rating từ bảng Reviews
        public double AverageRating { get; set; }

        // Tổng số lượt đánh giá từ bảng Reviews
        public int TotalReviews { get; set; }
    }
}