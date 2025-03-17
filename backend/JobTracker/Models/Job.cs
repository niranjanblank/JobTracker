using System.ComponentModel.DataAnnotations;
using  System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace JobTracker.Models
{
	public class Job
	{
		[Key] 
		public int Id { get; set; }

		[ForeignKey("Company")]
		public int? CompanyId { get; set; } // nullable

		[ForeignKey("User")]
		[Required]
		public int UserId { get; set; }

		[Required]
		public string Title { get; set; } = string.Empty;

		public JobType? JobType { get; set; } // nullable

		public EmploymentType? EmploymentType { get; set; } // nullable

		public decimal? Salary { get; set; } // nullable

		public string Description { get; set; } = string.Empty;

		public string? JobLink { get; set; } = string.Empty; // nullable

		public DateTime? PostedDate { get; set; } // nullable

		public DateTime? ClosingDate { get; set; } // nullable

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // navigation properties
        [JsonIgnore]
		public Application? Application { get; set; }

    }
}