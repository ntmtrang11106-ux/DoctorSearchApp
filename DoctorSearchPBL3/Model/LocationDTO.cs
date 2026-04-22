using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Location")]
    public class LocationDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string LocationName { get; set; }  // Tên Quận/Huyện — "Q. Hải Châu"

        [Required]
        [StringLength(100)]
        public string Province { get; set; }       // Tên Tỉnh — "Đà Nẵng"

        // Ward removed: using Province + LocationName (district) is sufficient
    }
}