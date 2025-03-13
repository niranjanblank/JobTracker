using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("DocumentType")]
        public int DocumentTypeId { get; set; }

        public string FileName { get; set; } = string.Empty;

        public string FileUrl { get; set; } = string.Empty;

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        // navigation properties
        public virtual DocumentType? DocumentType { get; set; }
        public virtual ICollection<ApplicationDocument> ApplicationDocuments { get; set; } = new List<ApplicationDocument>();
    }
}