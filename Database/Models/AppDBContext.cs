using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Deadline> Deadlines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=studypartner;Trusted_Connection=true;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Subjects)
                .WithMany(s => s.Users)
                .UsingEntity(j => j.ToTable("UserSubjects"));

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Courses) // One Subject has many Courses
                .WithOne(c => c.Subject) // Each Course belongs to one Subject
                .HasForeignKey(c => c.SubjectId); // Foreign key constraint on Course

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Deadlines) // One Subject has many Courses
                .WithOne(c => c.Subject) // Each Course belongs to one Subject
                .HasForeignKey(c => c.SubjectId); // Foreign key constraint on Course

            base.OnModelCreating(modelBuilder);
        }
    }
}
