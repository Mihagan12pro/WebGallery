using System.ComponentModel.DataAnnotations.Schema;

namespace WebGallery.Models.Statistics
{
    [Table("page_visits")]
    public class Visit
    {
        public Page? Page { get; set; }

        [Column("visit_time")]
        public TimeOnly Time { get; set; }

        [Column("visit_date")]
        public DateOnly Date { get; set; }

        [Column("request_method")]
        public string? Method { get; set; }
    }
}
