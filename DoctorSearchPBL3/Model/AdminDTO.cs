using DTO_Tier;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Admin")] // [cite: 28]
public class AdminDTO
{
    [Key]
    public int Id { get; set; } // 

    [Required]
    public int UserId { get; set; } // 

    [ForeignKey("UserId")]
    public virtual UserDTO User { get; set; }
}