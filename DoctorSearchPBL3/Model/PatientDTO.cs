using DTO_Tier;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Patient")] // [cite: 22]
public class PatientDTO
{
    [Key]
    public int Id { get; set; } // 

    [Required]
    public int UserId { get; set; } // FK sang User 

    public string BHYT { get; set; } // 
    public string Blood_Type { get; set; } // 
    public string Medical_History { get; set; } // 

    [ForeignKey("UserId")]
    public virtual UserDTO User { get; set; }
}