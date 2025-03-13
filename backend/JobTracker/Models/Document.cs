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

        public string FileName { get; set; }

        public string FileUrl { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        // navigation properties
        public virtual DocumentType? DocumentType { get; set; }
    }
}