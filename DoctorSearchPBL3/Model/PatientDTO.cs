using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Patient")]
    public class PatientDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [StringLength(50)]
        public string? MedicalCode { get; set; }

        [StringLength(100)]
        public string? EmergencyContactName { get; set; }

        [StringLength(15)]
        public string? EmergencyContactPhone { get; set; }

        [StringLength(50)]
        public string? InsuranceCode { get; set; }

        [StringLength(10)]
        public string? BloodType { get; set; }

        public string? Note { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserDTO? User { get; set; }
    }
}
