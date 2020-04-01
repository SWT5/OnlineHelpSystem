using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineHelpSystem.Models;


namespace OnlineHelpSystem.Data
{
    class myDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Database=BookStore2;User ID=SA;Password=SecurePassword1!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Teacher
            modelBuilder.Entity<Teacher>().HasKey(t  => new { t.AuId});
            modelBuilder.Entity<Teacher>() //One to many Exercises
                .HasMany<Exercise>(t => t.Exercises)
                .WithOne(e => e.Teacher)
                .HasForeignKey(e  => new {e.Lecture, e.Number});
            modelBuilder.Entity<Teacher>()
                .HasMany<Assignment>(t => t.Assignments) //One-to-many
                .WithOne(a => a.Teacher)
                .HasForeignKey(a => a.AssignmentId);

            
            /*  Skal man definer mange til en relationer.
                modelBuilder.Entity<Teacher>() // one to many Assigment
                .HasMany<Course>(t => t.Course)
                .WithOne(c=> c.CourseId)
                .HasForeignKey(c=>c.Teachers.);
                */

            //Course
            modelBuilder.Entity<Course>().HasKey(c => new {c.CourseId});
            modelBuilder.Entity<Course>() //one to many (Teacher)
                .HasMany<Teacher>(c => c.Teachers)
                .WithOne(t => t.Course)
                .HasForeignKey(t => t.AuId);
            modelBuilder.Entity<Course>()
                .HasMany<Assignment>(c => c.Assignments)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.AssignmentId);


            //StudentCourse (many to many) Shadowtabel
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentAuId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.StudentCourseId);

            //Student
            modelBuilder.Entity<Student>().HasKey(s => new {s.AuId});
            modelBuilder.Entity<Student>()
                .HasMany<Exercise>(s => s.Exercises)
                .WithOne(e => e.Student)
                .HasForeignKey(e => new {e.Lecture, e.Number });

            //StudentAssignment
            modelBuilder.Entity<StudentAssignment>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.StudentAssignments)
                .HasForeignKey(sa => sa.StudentAuId);
            modelBuilder.Entity<StudentAssignment>()
                .HasOne(sa => sa.Assignment)
                .WithMany(a => a.StudentAssignments)
                .HasForeignKey(sa => sa.AssignmentId);

            //Assignment
            modelBuilder.Entity<Assignment>().HasKey(a => new {a.AssignmentId});
            
            
            //Exercise
            modelBuilder.Entity<Exercise>().HasKey(e => new {e.Lecture, e.Number});

            //skal mann definere relation fra mange til 1, når man har defineret relation 1 til mange??
            //modelBuilder.Entity<Exercise>()
            //    .HasOne<Student>()
        }
    }
}
