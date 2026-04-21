using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Tier
{
    [Table("Article_Specialty")]
    public class ArticleSpecialtyDTO
    {
        public int ArticleId { get; set; }
        public int SpecialtyId { get; set; }

        [ForeignKey("ArticleId")]
        public virtual ArticlesDTO Article { get; set; }

        [ForeignKey("SpecialtyId")]
        public virtual SpecialtyDTO Specialty { get; set; }
    }
}