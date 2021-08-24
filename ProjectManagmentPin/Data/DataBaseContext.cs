using Microsoft.EntityFrameworkCore;

namespace ProjectManagmentPin.Data
{
    public class ProjectManagmentContext : DbContext
    {
        public ProjectManagmentContext(DbContextOptions<ProjectManagmentContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }        
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Project>().HasMany(x => x.EmployeeOnProject)
                .WithMany(x => x.AssignedProjects)
                .UsingEntity<EmployeeProject>(
                    x => x.HasOne(x => x.Employee)
                    .WithMany().HasForeignKey(x => x.EmployeeId),
                    x => x.HasOne(x => x.Project)
                   .WithMany().HasForeignKey(x => x.ProjectId));
        }
    }

    public class DataBaseInit
    {

        public static void Initialize(ProjectManagmentContext context)
        {
            context.Database.EnsureCreated();
        }

    }
}
