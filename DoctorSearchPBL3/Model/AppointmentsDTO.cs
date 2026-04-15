using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{

    [Table("Appointments")] // [cite: 36]
    public class AppointmentsDTO
    {
        [Key]
        public int Id { get; set; } // Mã định danh lịch hẹn 

        [Required]
        public int PatientId { get; set; } // Mã bệnh nhân đặt lịch 

        [Required]
        public int DoctorId { get; set; } // Mã bác sĩ được đặt lịch 

        [Required]
        public int TimeSlotId { get; set; } // Mã khung giờ được chọn 

        [StringLength(500)]
        public string Symptoms { get; set; } // Triệu chứng bệnh nhân nhập 

        [StringLength(20)]
        public string Status { get; set; } = "Chờ duyệt"; // Trạng thái: Chờ duyệt, Thành công... 

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Thời điểm ghi nhận lịch đặt 

        // --- Liên kết Navigation ---
        [ForeignKey("PatientId")]
        public virtual PatientDTO Patient { get; set; } //

        [ForeignKey("DoctorId")]
        public virtual DoctorDTO Doctor { get; set; } //

        [ForeignKey("TimeSlotId")]
        public virtual TimeSlotsDTO TimeSlot { get; set; } //
    }
}