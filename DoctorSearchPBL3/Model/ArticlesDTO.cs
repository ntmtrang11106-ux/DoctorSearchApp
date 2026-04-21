using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    
    [Table("Articles")] // [cite: 46]
    public class ArticlesDTO
    {
        [Key]
        public int Id { get; set; } // 

        [Required]
        public int AdminID { get; set; } // Tác giả bài viết (FK từ Users) 

        [Required]
        [StringLength(255)]
        public string Title { get; set; } // 

        [Required]
        public string Content { get; set; } // 

        public string Thumbnail { get; set; } // Ảnh đại diện bài viết 

        public int Views { get; set; } = 0; // 

        public DateTime CreatedAt { get; set; } = DateTime.Now; // 
        public virtual ICollection<ArticleSpecialtyDTO> ArticleSpecialties { get; set; } = new List<ArticleSpecialtyDTO>();

        // --- Liên kết Navigation ---
        [ForeignKey("AdminID")]
        public virtual UserDTO Author { get; set; }
    }
}