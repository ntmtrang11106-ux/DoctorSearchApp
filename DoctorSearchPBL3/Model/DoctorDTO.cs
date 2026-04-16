using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
   
    [Table("Doctor")] // [cite: 26]
    public class DoctorDTO
    {
        [Key]
        public int Id { get; set; } // 

        [Required]
        public int UserId { get; set; } // Kết nối 1-1 với tài khoản User 

        [Required]
        public string CertificateImage { get; set; } // Chứng chỉ hành nghề (Unique trong DB) 

        [Required]
        [StringLength(255)]
        public string ClinicAddress { get; set; } // Địa chỉ chi tiết nơi khám bệnh 

        public string ClinicName { get; set; } // Tên phòng khám 

        // Giữ nguyên lỗi chính tả "Exxperience" theo đúng file Word của bạn
        public int? Experience_Years { get; set; } // Năm kinh nghiệm 

        public string Bio { get; set; } // Tiểu sử giới thiệu ngắn 

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; } // Giá tiền mỗi lượt khám 

        public string WorkingTime { get; set; } // Mô tả giờ làm việc tổng quát 

        public int? LocationId { get; set; } // Liên kết với mã khu vực 

        public int? SpecialtyId { get; set; } // Liên kết với mã chuyên khoa 

        [Required]
        public bool IsApproved { get; set; } = false; // 0: Chờ duyệt, 1: Đã duyệt 

        // --- CÁC THUỘC TÍNH LIÊN KẾT (NAVIGATION PROPERTIES) ---
        // Những dòng này giúp EF Core tự động JOIN các bảng cho bạn

        [ForeignKey("UserId")]
        public virtual UserDTO User { get; set; } // 

        [ForeignKey("LocationId")]
        public virtual LocationDTO Location { get; set; } // 

        [ForeignKey("SpecialtyId")]
        public virtual SpecialtyDTO Specialty { get; set; } //
                                                            //
        [NotMapped]
        public double AverageRating { get; set; } // Sẽ được BUS tính và gán vào

        [NotMapped]
        public int TotalReviews { get; set; } // Sẽ được BUS đếm và gán vào

        public virtual ICollection<ReviewsDTO> Reviews { get; set; } = new List<ReviewsDTO>();
    }
}