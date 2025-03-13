using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Models
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; } // nullable
        public DateTime? LastUpdated { get; set; } // nullable
    }
}