using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Task2.Emplo.Models;
using Task2.Emplo.Models.Database;

namespace Task2.Emplo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationPackage> VacationPackages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.VacationPackage)
                .WithMany(t=>t.Employees)
                .HasForeignKey(e => e.VacationPackageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vacation>()
                .HasOne(v => v.Employee)
                .WithMany(e => e.Vacations)
                .HasForeignKey(v => v.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);


            //SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}