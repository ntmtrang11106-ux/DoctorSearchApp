using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
   
    [Table("Messages")]
    public class MessagesDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ConversationId { get; set; }

        [Required]
        public int SenderID { get; set; }

        public string? Content { get; set; }

        [Required]
        [StringLength(30)]
        public string MessageType { get; set; } = "Text";

        [StringLength(255)]
        public string? AttachmentPath { get; set; }

        [StringLength(255)]
        public string? AttachmentName { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;

        public DateTime? ReadAt { get; set; }

        public DateTime? EditedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey("ConversationId")]
        public virtual ConversationDTO? Conversation { get; set; }

        [ForeignKey("SenderID")]
        public virtual UserDTO? Sender { get; set; }
    }
}
