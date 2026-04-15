using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{

    [Table("Location")] // 
    public class LocationDTO
    {
        [Key]
        public int Id { get; set; } // Mã định danh vị trí [cite: 31]

        [Required]
        [StringLength(100)]
        public string LocationName { get; set; } // Tên khu vực [cite: 31]
    }
}