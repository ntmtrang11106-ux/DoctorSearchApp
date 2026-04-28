using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Room")]
    public class RoomDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomCode { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string RoomName { get; set; } = null!;

        [Required]
        public int? DepartmentId { get; set; }

        [StringLength(50)]
        public string? Floor { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<TimeSlotsDTO> TimeSlots { get; set; } = new List<TimeSlotsDTO>();
        [ForeignKey(nameof(DepartmentId))]
        public virtual DepartmentDTO? Department { get; set; }
    }
}
