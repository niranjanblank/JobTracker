using Microsoft.EntityFrameworkCore;
using JobTracker.Models;

namespace JobTracker.Data
{
    public class JobDbContext: DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }

        // register the user entity 
        public DbSet<User> Users { get; set; }

        // register the company entity
        public DbSet<Company> Companies { get; set; }

        // register the job entity
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many: User -> Jobs (Required)
            modelBuilder.Entity<Job>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a User deletes their Jobs


            // One-to-Many: User -> Companies (Required)
            modelBuilder.Entity<Company>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a User deletes their Companies

            // One-to-Many: Company -> Jobs (Optional)
            modelBuilder.Entity<Job>()
                .HasOne<Company>()
                .WithMany()
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.SetNull); // If Company is deleted, its Jobs' CompanyId becomes NULL

            // Store Enums as Strings
            modelBuilder.Entity<Job>()
                .Property(j => j.JobType)
                .HasConversion<string>();

            modelBuilder.Entity<Job>()
                .Property(j => j.EmploymentType)
                .HasConversion<string>();


            base.OnModelCreating(modelBuilder);
        }
    }
}
