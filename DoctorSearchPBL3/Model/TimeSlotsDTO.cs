using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{

    [Table("TimeSlots")] // [cite: 34]
    public class TimeSlotsDTO
    {
        [Key]
        public int Id { get; set; } // Mã định danh khung giờ 

        [Required]
        public int DoctorId { get; set; } // Mã bác sĩ chủ quản 

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; } // Ngày thực hiện khám bệnh 

        [Required]
        public TimeSpan StartTime { get; set; } // Giờ bắt đầu (Kiểu TIME trong SQL) 

        [Required]
        public TimeSpan EndTime { get; set; } // Giờ kết thúc 

        [StringLength(20)]
        public string Status { get; set; } = "Trống"; // Trạng thái: Trống, Đã đặt 

        // --- Liên kết ---
        [ForeignKey("DoctorId")]
        public virtual DoctorDTO Doctor { get; set; } //
    }
}