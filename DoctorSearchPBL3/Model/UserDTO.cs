using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
   
    [Table("User")] // Tên bảng theo source [cite: 20]
    public class UserDTO
    {
        [Key]
        public int Id { get; set; } // 

        [Required]
        public string Role { get; set; } // 

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } // 

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } // 

        [Required]
        [StringLength(255)]
        public string Password { get; set; } // 

        [Required]
        public DateTime Dob { get; set; } // 
        public string Gender { get; set; } // 
        public string? CCCD { get; set; } // 

        [StringLength(255)]
        public string Residential_Address { get; set; } // 

        public string Picture { get; set; } // 
        public string Status { get; set; } // 

        public DateTime Created_At { get; set; } = DateTime.Now; // 
    }
}