using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    
    [Table("MedicalRecords")] // [cite: 44]
    public class MedicalRecordsDTO
    {
        [Key]
        public int Id { get; set; } // 

        [Required]
        public int PatientId { get; set; } // 

        [Required]
        public int DoctorId { get; set; } // 

        [Required]
        public int AppointmentID { get; set; } // Kết nối trực tiếp với cuộc hẹn cụ thể 

        public DateTime Visit_Date { get; set; } = DateTime.Now; // 

        public string Diagnosis { get; set; } // Kết quả chẩn đoán 

        public string Treatment { get; set; } // Phương pháp điều trị 

        // --- Liên kết Navigation ---
        [ForeignKey("PatientId")]
        public virtual PatientDTO Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorDTO Doctor { get; set; }

        [ForeignKey("AppointmentID")]
        public virtual AppointmentsDTO Appointment { get; set; }
    }
}