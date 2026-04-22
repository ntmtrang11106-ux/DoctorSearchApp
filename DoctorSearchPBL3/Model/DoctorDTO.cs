using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DTO_Tier
{
   
    [Table("Doctor")] // [cite: 26]
    public class DoctorDTO
    {
        [Key]
        public int Id { get; set; } // 

        [Required]
        // 1. Đảm bảo 1 User chỉ có 1 hồ sơ Bác sĩ
        public int UserId { get; set; }


        [Required]
        [StringLength(255)]
        public string ClinicAddress { get; set; } // Địa chỉ chi tiết nơi khám bệnh 

        public string ClinicName { get; set; } // Tên phòng khám 

        // Thông tin chứng chỉ và kinh nghiệm theo từng chuyên khoa
        // đã được tách vào bảng trung gian DoctorSpecialtyDTO để hỗ trợ
        // 1 bác sĩ có nhiều chứng chỉ / nhiều chuyên khoa.

        public string Bio { get; set; } // Tiểu sử giới thiệu ngắn 

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; } // Giá tiền mỗi lượt khám 

        public string WorkingTime { get; set; } // Mô tả giờ làm việc tổng quát 

        public int? LocationId { get; set; } // Liên kết với mã khu vực 


        [Required]
        public bool IsApproved { get; set; } = false; // 0: Chờ duyệt, 1: Đã duyệt 

        // --- CÁC THUỘC TÍNH LIÊN KẾT (NAVIGATION PROPERTIES) ---
        // Những dòng này giúp EF Core tự động JOIN các bảng cho bạn

        [ForeignKey("UserId")]
        public virtual UserDTO User { get; set; } // 

        [ForeignKey("LocationId")]
        public virtual LocationDTO Location { get; set; } // 

        // Đây chính là "chìa khóa" để giải quyết quan hệ Nhiều-Nhiều
        public virtual ICollection<DoctorSpecialtyDTO> DoctorSpecialties { get; set; } = new List<DoctorSpecialtyDTO>();
        //
        [NotMapped]
        public double AverageRating { get; set; } // Sẽ được BUS tính và gán vào

        [NotMapped]
        public int TotalReviews { get; set; } // Sẽ được BUS đếm và gán vào

        public virtual ICollection<ReviewsDTO> Reviews { get; set; } = new List<ReviewsDTO>();

        // --- Compatibility / convenience properties ---
        // Giữ lại để tương thích với UI/BUS hiện tại. Thực tế các thông tin này
        // có thể nằm trong DoctorSpecialtyDTO nếu chuyên khoa khác nhau có giá trị khác nhau.
        [NotMapped]
        public int? Experience_Years
        {
            get
            {
                if (DoctorSpecialties != null && DoctorSpecialties.Any())
                    return DoctorSpecialties.Max(ds => ds.Experience_Years);
                return null;
            }
            set { /* setter tồn tại để hỗ trợ seeding hoặc binding */ }
        }

        [NotMapped]
        public string CertificateImage { get; set; }

        [NotMapped]
        public SpecialtyDTO Specialty => DoctorSpecialties?.FirstOrDefault()?.Specialty;

        // Stored summary to optimize sorting/filtering by experience across specialties
        public int? ExperienceSummary { get; set; }
    }
}