using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using UniversityAPI.Models;

namespace UniversityAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseId });
            modelBuilder.Entity<CourseTeacher>().HasKey(e => new { e.CourseId,e.TeacherId});

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Enrollment)
                .WithMany()
                .HasForeignKey(m => new { m.StudentId, m.CourseId })
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Attendance>()
                .HasOne(m => m.Enrollment)
                .WithMany()
                .HasForeignKey(a => new { a.StudentId, a.CourseId })
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
