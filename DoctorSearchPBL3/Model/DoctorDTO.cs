using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Doctor")]
    public class DoctorDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [StringLength(100)]
        public string? Position { get; set; }

        [StringLength(100)]
        public string? LicenseNumber { get; set; }

        public string? Biography { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ConsultationFee { get; set; }

        public int? ExperienceYears { get; set; }

        public bool IsApproved { get; set; }

        public bool IsActive { get; set; } = true;

        [Column(TypeName = "date")]
        public DateTime? JoinDate { get; set; }

        public string? NotesInternal { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int? DeletedBy { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserDTO? User { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual DepartmentDTO? Department { get; set; }

        public virtual ICollection<TimeSlotsDTO> TimeSlots { get; set; } = new List<TimeSlotsDTO>();

        public virtual ICollection<AppointmentsDTO> Appointments { get; set; } = new List<AppointmentsDTO>();

        public virtual ICollection<ReviewsDTO> Reviews { get; set; } = new List<ReviewsDTO>();

        [NotMapped]
        public double AverageRating { get; set; }

        [NotMapped]
        public int TotalReviews { get; set; }

        // Certificates: 1 doctor -> many certificate files
        public virtual ICollection<DoctorCertificateDTO> Certificates { get; set; } = new List<DoctorCertificateDTO>();
    }
}
