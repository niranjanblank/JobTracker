using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Draft;

        public DateTime? AppliedDate { get; set; } // nullable

        public DateTime? CreatedAt { get; set; } // nullable
        public DateTime? LastUpdated { get; set; } // nullable

        // navigation properties
        public Job? Job { get; set; }
       
        public virtual ICollection<ApplicationDocument> ApplicationDocuments { get; set; } = new List<ApplicationDocument>();
        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    }
} 