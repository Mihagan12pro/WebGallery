using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGallery.Models.Statistics
{
    [Table("page_visits")]
    public class Visit
    {
        [Key, Column("visit_id")]
        public int Id { get; set; }

        [Column("visited_page_id")]
        public int? PageKey { get; set; }
      
        [ForeignKey(nameof(PageKey))]
        public Page? Page { get; set; }

        [Column("visit_time")]
        public required TimeOnly Time { get; set; }

        [Column("visit_date")]
        public required DateOnly Date { get; set; }

        [Column("visited_method")]
        public required string? Method { get; set; }

        [Column("user_agent")]
        public string? UserAgent { get; set; }
    }
}
