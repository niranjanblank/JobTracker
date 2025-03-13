using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }

        public string Details { get; set; }

        public DateTime? CreatedAt { get; set; } // nullable
        public DateTime? LastUpdated { get; set; } // nullable

    } 