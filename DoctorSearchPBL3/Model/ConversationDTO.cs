using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
   
    [Table("Conversation")]
    public class ConversationDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        public string? LastMessage { get; set; }

        public DateTime LastActive { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey("PatientID")]
        public virtual PatientDTO? Patient { get; set; }

        [ForeignKey("DoctorID")]
        public virtual DoctorDTO? Doctor { get; set; }

        public virtual ICollection<MessagesDTO> Messages { get; set; } = new List<MessagesDTO>();
    }
}
