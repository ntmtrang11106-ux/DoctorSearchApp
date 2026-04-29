using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("TimeSlots")]
    public class TimeSlotsDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime WorkDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public int MaxAppointments { get; set; } = 1;

        public int BookedCount { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Open";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual DoctorDTO? Doctor { get; set; }

        [ForeignKey(nameof(RoomId))]
        public virtual RoomDTO? Room { get; set; }

        public virtual ICollection<AppointmentsDTO> Appointments { get; set; } = new List<AppointmentsDTO>();

        public int CreatedByAdminId { get; set; }
        public AdminDTO CreatedByAdmin { get; set; }
    }
}
