using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Content")]
    public class ContentDTO
    {
        [Key]
        public int Id { get; set; }

        public int? DepartmentId { get; set; }

        [Required]
        public int AuthorAdminId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; } = null!;

        [StringLength(500)]
        public string? Summary { get; set; }

        [Required]
        public string Body { get; set; } = null!;

        [StringLength(255)]
        public string? Thumbnail { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentType { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Draft";

        public int Priority { get; set; }

        public bool IsPinned { get; set; }

        public int ViewCount { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual DepartmentDTO? Department { get; set; }

        [ForeignKey(nameof(AuthorAdminId))]
        public virtual AdminDTO? AuthorAdmin { get; set; }
    }
}
