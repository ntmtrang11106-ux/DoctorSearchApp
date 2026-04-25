using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("User")]
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = null!;

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = null!;

        public DateTime? Dob { get; set; }

        [StringLength(20)]
        public string? Gender { get; set; }

        [StringLength(20)]
        public string? CCCD { get; set; }

        [StringLength(255)]
        public string? Residential_Address { get; set; }

        [StringLength(255)]
        public string? Picture { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
