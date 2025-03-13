using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Models
{
    public class ApplicationDocument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        // Navigation Properties(Optional, only if needed in queries)
        public virtual Application? Application { get; set; }
        public virtual Document? Document { get; set; }
    }
}