using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Doctor_Specialty")]
    public class DoctorSpecialtyDTO
    {
        public int DoctorId { get; set; }
        public int SpecialtyId { get; set; }

        // Navigation Properties để Trang bốc dữ liệu ra dễ dàng
        [ForeignKey("DoctorId")]
        public virtual DoctorDTO Doctor { get; set; }

        [ForeignKey("SpecialtyId")]
        public virtual SpecialtyDTO Specialty { get; set; }
    }
}