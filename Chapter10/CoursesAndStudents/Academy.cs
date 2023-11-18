using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace CoursesAndStudents;

public class Academy : DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<Course>? Courses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Academy.db");

        WriteLine($"Using {path} database file.");

        //optionsBuilder.UseSqlite($"Filename={path}");

        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Academy;Integrated Security=true;MultipleActiveResultSets=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //fluent API validation rules
        modelBuilder.Entity<Student>().Property(s => s.LastName).HasMaxLength(30).IsRequired();

        //populate database with sample data
        Student alice = new() { StudentId = 1, FirstName = "Alice", LastName = "Jones" };
        Student bob = new() { StudentId = 2, FirstName = "Bob", LastName = "Smith" };
        Student cecilia = new() { StudentId = 3, FirstName = "Cecilia", LastName = "Ramirez" };

        Course cSharp = new() { CourseId = 1, Title = "C# 10 and .NET 6" };
        Course webDev = new() { CourseId = 2, Title = "Web Development" };
        Course python = new() { CourseId = 3, Title = "Python for beginners" };

        modelBuilder.Entity<Student>().HasData(alice, bob, cecilia);
        modelBuilder.Entity<Course>().HasData(cSharp, webDev, python);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity(e => e.HasData(
                //all students signed up for the c# course
                new { CoursesCourseId = 1, StudentsStudentId = 1 },
                new { CoursesCourseId = 1, StudentsStudentId = 2 },
                new { CoursesCourseId = 1, StudentsStudentId = 3 },

                //only bob signed up for web dev
                new { CoursesCourseId = 2, StudentsStudentId = 2 },

                //only cecilia signed up for python
                new { CoursesCourseId = 3, StudentsStudentId = 3 }
                ));
    }
}
