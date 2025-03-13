using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Models
{
    public class Interview
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
         
        public string? Interviewer { get; set; }

        public DateTime? ScheduledDate { get; set; } // nullable

        public string? InterviewType { get; set; }
        public string? InterviewLocation { get; set; }
        public string? InterviewLink { get; set; }

        public InterviewProgress Progress { get; set; } = InterviewProgress.Pending;
        public InterviewStatus Status { get; set; } = InterviewStatus.Pending;

        public DateTime? CreatedAt { get; set; } // nullable
        public DateTime? LastUpdated { get; set; } // nullable

        public 
    }
}