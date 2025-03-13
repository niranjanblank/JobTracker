using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }

        public string Details { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; } // nullable
        public DateTime? LastUpdated { get; set; } // nullable

    }
}