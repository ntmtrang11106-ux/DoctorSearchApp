using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Reviews")]
    public class ReviewsDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        public bool IsVisible { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(PatientId))]
        public virtual PatientDTO? Patient { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual DoctorDTO? Doctor { get; set; }
    }
}
