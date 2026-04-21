using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Doctor_Specialty")]
    public class DoctorSpecialtyDTO
    {
        [Key]
        public int Id { get; set; }

        public int DoctorId { get; set; }
        public int SpecialtyId { get; set; }

        [StringLength(255)]
        public string CertificateImage { get; set; } // Chứng chỉ hành nghề cho chuyên khoa cụ thể

        [StringLength(100)]
        public string CertificateCode { get; set; } // Mã chứng chỉ (nếu cần)

        public int? Experience_Years { get; set; } // Kinh nghiệm liên quan tới chuyên khoa này

        // Navigation Properties để Trang bốc dữ liệu ra dễ dàng
        [ForeignKey("DoctorId")]
        public virtual DoctorDTO Doctor { get; set; }

        [ForeignKey("SpecialtyId")]
        public virtual SpecialtyDTO Specialty { get; set; }
    }
}