using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HireMeCodeFirst.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<BusinessIndustry> BusinessIndustries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<CompanyLogo> CompanyLogos { get; set; }
        public DbSet<EducationDetail> EducationDetails { get; set; }
        public DbSet<JobApplicationStatus> JobApplicationStatuses { get; set; }
        public DbSet<JobPostAction> JobPostActions { get; set; }
        public DbSet<JobPostActivity> JobPostActivities { get; set; }
        public DbSet<JobPostActivityLog> JobPostActivityLogs { get; set; }
        public DbSet<JobLocation> JobLocations { get; set; }
        public DbSet<JobPostSkillSet> JobPostSkillSets { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<StudentExperience> StudentExperiences { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<StudentSkillSet> StudentSkillSets { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobPosting>()
                .HasRequired(d => d.Company)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>()
                .HasRequired(d => d.UserAccount)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<JobPostActivity>()
                .HasRequired(d => d.UserAccount)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<JobPostActivityLog>()
                .HasRequired(d => d.UserAccount)
                .WithOptional()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}