using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGallery.Models.Statistics
{
    [Table("pages")]
    public class Page
    {
        [Key, Column("page_id")]
        public int Id { get; set; }

        [Required(), Column("page_path")]
        public required string? Path { get; set; }
    }
}
