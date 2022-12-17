using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Context;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<Enrollment>().HasKey(sc => new { sc.StudentId, sc.CourseId });
        modelBuilder.Entity<Enrollment>()
       .HasOne<Student>(sc => sc.Student)
       .WithMany(s => s.Enrollments)
       .HasForeignKey(sc => sc.StudentId);


       modelBuilder.Entity<Enrollment>()
      .HasOne<Course>(sc => sc.Course)
      .WithMany(s => s.Enrollments)
      .HasForeignKey(sc => sc.CourseId);

}
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    
}