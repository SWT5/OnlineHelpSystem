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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OnlineHelpSystem;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Teacher
            modelBuilder.Entity<Teacher>().HasKey(t  => new { t.AuId});
            modelBuilder.Entity<Teacher>() //One to many Exercises
                .HasMany<Exercise>(t => t.Exercises)
                .WithOne(e=> e.Teacher)
                .HasForeignKey(e  => new {e.Lecture, e.Number});
            modelBuilder.Entity<Teacher>()
                .HasMany<Assignment>(t => t.Assignments) //One-to-many
                .WithOne(a => a.Teacher)
                .HasForeignKey(a => a.AssignmentId);

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
            modelBuilder.Entity<Course>()
                .HasMany<Exercise>(c => c.Exercises)
                .WithOne(e => e.Course)
                .HasForeignKey(e => new {e.Lecture, e.Number});

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
            modelBuilder.Entity<StudentAssignment>().HasKey(sa => new {sa.StudentAssignmentId});
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
        }

        

    }
}
