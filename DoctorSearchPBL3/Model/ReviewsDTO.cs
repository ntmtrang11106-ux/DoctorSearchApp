using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    
    [Table("Reviews")] // [cite: 48]
    public class ReviewsDTO
    {
        [Key]
        public int Id { get; set; } // 

        [Required]
        public int AppointmentId { get; set; } // Liên kết tới 1 lần khám 

        public int PatientID { get; set; } // Người thực hiện đánh giá 

        public int DoctorID { get; set; } // Bác sĩ nhận đánh giá 

        [Range(1, 5)]
        public int Rating { get; set; } // Số sao (1-5) 

        public string Comment { get; set; } // Nhận xét 

        public bool IsVisible { get; set; } = true; // 

        public DateTime CreatedAt { get; set; } = DateTime.Now; // 

        // --- Liên kết Navigation ---
        [ForeignKey("AppointmentId")]
        public virtual AppointmentsDTO Appointment { get; set; }

        [ForeignKey("PatientID")]
        public virtual PatientDTO Patient { get; set; }

        [ForeignKey("DoctorID")]
        public virtual DoctorDTO Doctor { get; set; }
    }
}