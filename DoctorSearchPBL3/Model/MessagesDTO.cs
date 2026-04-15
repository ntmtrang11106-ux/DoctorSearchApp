using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
   
    [Table("Messages")] // 
    public class MessagesDTO
    {
        [Key]
        public int Id { get; set; } // Mã tin nhắn 

        [Required]
        public int ConversationId { get; set; } // Thuộc đoạn chat nào 

        [Required]
        public int SenderID { get; set; } // ID của người gửi tin (FK từ Users) 

        [Required]
        public string Content { get; set; } // Nội dung tin nhắn 

        // Mình giữ nguyên tên cột "SenAt" như trong Word (có vẻ là SentAt - Ngày gửi)
        public DateTime SentAt { get; set; } = DateTime.Now; // 

        public bool IsRead { get; set; } = false; // 0: chưa đọc, 1: đã xem 

        // --- Liên kết Navigation ---
        [ForeignKey("ConversationId")]
        public virtual ConversationDTO Conversation { get; set; }

        [ForeignKey("SenderID")]
        public virtual UserDTO Sender { get; set; }
    }
}