using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DTO_Tier
{
    [Table("DoctorCertificates")]
    public class DoctorCertificateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        // Relative path inside app's resources folder, e.g. "Certificates/20260427_guid_img.jpg"
        [Required]
        [StringLength(255)]
        public string FilePath { get; set; } = null!;

        [StringLength(255)]
        public string? FileName { get; set; }

        // Optional flag if you want a primary certificate image
        public bool IsPrimary { get; set; } = false;

        public DateTime UploadedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(DoctorId))]
        public virtual DoctorDTO? Doctor { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}