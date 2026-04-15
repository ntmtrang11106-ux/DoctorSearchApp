using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{

    [Table("CallLogs")] // [cite: 42]
    public class CallLogsDTO
    {
        [Key]
        public int Id { get; set; } // 

        [Required]
        public int CallerID { get; set; } // ID người thực hiện cuộc gọi 

        [Required]
        public int ReceiverID { get; set; } // ID người nhận cuộc gọi 

        [Required]
        public DateTime StartTime { get; set; } // Thời điểm bắt đầu 

        [Required]
        public DateTime EndTime { get; set; } // Thời điểm kết thúc 

        public int Duration { get; set; } = 0; // Thời lượng tính bằng giây 

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // Missed, Completed, Declined 

        // --- Liên kết Navigation ---
        [ForeignKey("CallerID")]
        public virtual UserDTO Caller { get; set; }

        [ForeignKey("ReceiverID")]
        public virtual UserDTO Receiver { get; set; }
    }
}