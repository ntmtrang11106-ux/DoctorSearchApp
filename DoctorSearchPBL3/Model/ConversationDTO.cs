using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
   
    [Table("Conversation")] // 
    public class ConversationDTO
    {
        [Key]
        public int Id { get; set; } // Mã cuộc chat 

        [Required]
        public int PatientID { get; set; } // Liên kết đến bệnh nhân 

        [Required]
        public int DoctorID { get; set; } // Liên kết tới bác sĩ 

        [Required]
        public string LastMessage { get; set; } // Nội dung tin nhắn cuối cùng 

        public DateTime LastActive { get; set; } = DateTime.Now; // Thời điểm tương tác cuối 

        // --- Liên kết Navigation ---
        [ForeignKey("PatientID")]
        public virtual PatientDTO Patient { get; set; }

        [ForeignKey("DoctorID")]
        public virtual DoctorDTO Doctor { get; set; }
    }
}