using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;
using UniversityApp.Models.Exam;

namespace UniversityApp.Services
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public ApplicationContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=University;Username=sominola;Password=root");
            optionsBuilder.UseSqlite("Filename=University.db");
        }
    }
}