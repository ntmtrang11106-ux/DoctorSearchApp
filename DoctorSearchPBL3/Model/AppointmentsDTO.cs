using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Appointments")]
    public class AppointmentsDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int TimeSlotId { get; set; }

        [StringLength(500)]
        public string? Reason { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        public string? Note { get; set; }

        [StringLength(100)]
        public string? DoctorNameSnapshot { get; set; }

        [StringLength(100)]
        public string? DepartmentNameSnapshot { get; set; }

        [StringLength(100)]
        public string? RoomNameSnapshot { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? FeeSnapshot { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(PatientId))]
        public virtual PatientDTO? Patient { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual DoctorDTO? Doctor { get; set; }

        [ForeignKey(nameof(TimeSlotId))]
        public virtual TimeSlotsDTO? TimeSlot { get; set; }
    }
}
