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
        // Khớp với cột Id trong bảng Doctors
        public int Id { get; set; }

        // Khớp với cột full_name trong bảng Doctors
        public string FullName { get; set; } = string.Empty;

        // Khớp với cột workplace trong bảng Doctors
        public string Workplace { get; set; } = string.Empty;

        // Lấy từ bảng Locations (thông qua LocationId)
        public string LocationName { get; set; } = string.Empty;

        // Lấy từ bảng Specialties (thông qua SpecialtyId)
        public string SpecialtyName { get; set; } = string.Empty;

        // Khớp với cột experience_years trong bảng Doctors
        public int ExperienceYears { get; set; }

        // Các trường tính toán (thường lấy từ bảng Reviews hoặc Appointments)
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }

        // Bạn có thể thêm trường này nếu cần hiển thị tiểu sử tóm tắt
        public string Bio { get; set; } = string.Empty;

        public string SpecificAddress {  get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Status {  get; set; } = string.Empty;

        public string Picture { get; set; } 
    }
}