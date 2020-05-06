using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineHelpSystem.Models;


namespace OnlineHelpSystem.Data
{
    class myDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OnlineHelpSystem45;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //**teacher**

            modelBuilder.Entity<Teacher>().HasKey(t  => new { t.AuId});
            //relation to course
            modelBuilder.Entity<Teacher>()
                .HasOne<Course>(t => t.Course)
                .WithMany(c => c.Teachers)
                .HasForeignKey(t => t.CourseFkId);


            //**Course**
            modelBuilder.Entity<Course>().HasKey(c => new { c.CourseId });


            //**Exercise**
            modelBuilder.Entity<Exercise>().HasKey(e => new {e.ExerciseId });
            //relation to student
            modelBuilder.Entity<Exercise>()
                .HasOne<Student>(e => e.Student)
                .WithMany(s => s.Exercises)
                .HasForeignKey(e => e.StudentFKId);
            //relation to course
            modelBuilder.Entity<Exercise>()
                .HasOne<Course>(e => e.Course)
                .WithMany(c => c.Exercises)
                .HasForeignKey(e => e.CourseFKId);
            //relation to teacher
            modelBuilder.Entity<Exercise>()
                .HasOne<Teacher>(e => e.Teacher)
                .WithMany(t => t.Exercises)
                .HasForeignKey(e => e.TeacherFKId);


            //StudentCourse (many to many) Shadowtabel
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new {sc.StudentCourseId});
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentFKAuId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseFKId);


            //**Student**
            modelBuilder.Entity<Student>().HasKey(s => new {s.AuId});
            

            //**StudentAssignment**
            modelBuilder.Entity<StudentAssignment>().HasKey(sa => new {sa.StudentFKAuId, sa.AssignmentFKId});
            modelBuilder.Entity<StudentAssignment>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.StudentAssignments)
                .HasForeignKey(sa => sa.StudentFKAuId);
            modelBuilder.Entity<StudentAssignment>()
                .HasOne(sa => sa.Assignment)
                .WithMany(a => a.StudentAssignments)
                .HasForeignKey(sa => sa.AssignmentFKId);


            //**Assigment**
            modelBuilder.Entity<Assignment>().HasKey(a => new { a.AssignmentId });
            //relation to Course 
            modelBuilder.Entity<Assignment>()
                .HasOne<Course>(a => a.Course)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.CourseFKId);
            //relation to teacher 
            modelBuilder.Entity<Assignment>()
                .HasOne<Teacher>(a => a.Teacher)
                .WithMany(t => t.Assignments)
                .HasForeignKey(a => a.TeacherFKId);




           //*********************DUMMY DATA***********************
            modelBuilder.Entity<Student>().HasData(
                new Student { AuId = "1", Name = "Thanh" },
                new Student { AuId = "2", Name = "Nikolaj" },
                new Student{AuId= "3", Name="Mads"}
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher {AuId = "123456", Name = "Jens", CourseFkId = 111},
                new Teacher {AuId = "654321", Name = "Poul", CourseFkId = 222}
            );

            modelBuilder.Entity<Course>().HasData(
                new Course {Name = "DAB", CourseId = 111},
                new Course {Name = "GUI", CourseId = 222}
            );

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Lecture = "1", Number = 1, HelpWhere = "bord 3", CourseFKId = 111, StudentFKId = "3", TeacherFKId = "123456", ExerciseId = 1, IsOpen = true},
                new Exercise { Lecture = "2", Number = 1, HelpWhere = "bord 5", CourseFKId = 111, StudentFKId = "2", TeacherFKId = "123456" , ExerciseId = 2, IsOpen = true},
                new Exercise { Lecture = "3", Number = 1, HelpWhere = "bord 19", CourseFKId = 222, StudentFKId = "1", TeacherFKId = "123456", ExerciseId = 3, IsOpen =  true},
                new Exercise { Lecture = "4", Number = 1, HelpWhere = "bord 7", CourseFKId = 222, StudentFKId = "2", TeacherFKId = "654321", ExerciseId = 4, IsOpen = true},
                new Exercise { Lecture = "5", Number = 1, HelpWhere = "bord 7", CourseFKId = 222, StudentFKId = "3", TeacherFKId = "654321", ExerciseId = 5, IsOpen = true},
                new Exercise { Lecture = "5", Number = 2, HelpWhere = "bord 4", CourseFKId = 222, StudentFKId = "3", TeacherFKId = "654321", ExerciseId = 6, IsOpen = false },
                new Exercise { Lecture = "6", Number = 2, HelpWhere = "bord 3", CourseFKId = 222, StudentFKId = "1", TeacherFKId = "654321", ExerciseId = 7, IsOpen = false }
            );


            modelBuilder.Entity<Assignment>().HasData(
                new Assignment
                {
                    AssignmentName = "DAB handin 1", AssignmentId = 1, CourseFKId = 111, AssignmentNumber = "1",
                    TeacherFKId = "654321",
                    IsOpen = true
                },
                new Assignment
                {
                    AssignmentName = "DAB handin 2", AssignmentId = 2, CourseFKId = 111, AssignmentNumber = "2",
                    TeacherFKId = "654321",
                    IsOpen = true
                },
                new Assignment
                {
                    AssignmentName = "DAB handin 3",
                    AssignmentId = 23,
                    CourseFKId = 111,
                    AssignmentNumber = "3",
                    TeacherFKId = "654321",
                    IsOpen = true
                },
                 new Assignment
                 {
                     AssignmentName = "GUI handin 1",
                     AssignmentId = 24,
                     CourseFKId = 222,
                     AssignmentNumber = "1",
                     TeacherFKId = "123456",
                     IsOpen = false
                 },
                  new Assignment
                  {
                      AssignmentName = "DAB genaflevering 2",
                      AssignmentId = 25,
                      CourseFKId = 111,
                      AssignmentNumber = "2",
                      TeacherFKId = "654321",
                      IsOpen = false
                  }
            );
        }

        

    }
}
