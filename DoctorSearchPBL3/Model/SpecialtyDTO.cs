using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{

    [Table("Specialtie")] // 
    public class SpecialtyDTO
    {
        [Key]
        public int Id { get; set; } // Mã định danh chuyên khoa [cite: 33]

        [Required]
        [StringLength(100)]
        public string SpecialtyName { get; set; } // Tên chuyên khoa [cite: 33]

        public string Description { get; set; } // Mô tả [cite: 33]
    }
}