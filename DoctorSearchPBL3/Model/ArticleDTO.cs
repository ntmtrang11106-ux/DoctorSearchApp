using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_Tier
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public int AdminID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
        public int Views { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
