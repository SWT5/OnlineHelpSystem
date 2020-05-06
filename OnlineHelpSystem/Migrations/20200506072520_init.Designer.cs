﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineHelpSystem.Data;

namespace OnlineHelpSystem.Migrations
{
    [DbContext(typeof(myDBContext))]
    [Migration("20200506072520_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineHelpSystem.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseFKId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherFKId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("CourseFKId");

                    b.HasIndex("TeacherFKId");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            AssignmentId = 1,
                            AssignmentName = "DAB handin 1",
                            AssignmentNumber = "1",
                            CourseFKId = 111,
                            TeacherFKId = "654321"
                        },
                        new
                        {
                            AssignmentId = 2,
                            AssignmentName = "DAB handin 2",
                            AssignmentNumber = "2",
                            CourseFKId = 111,
                            TeacherFKId = "654321"
                        });
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 111,
                            Name = "DAB"
                        },
                        new
                        {
                            CourseId = 222,
                            Name = "GUI"
                        });
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseFKId")
                        .HasColumnType("int");

                    b.Property<string>("HelpWhere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lecture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("StudentFKId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherFKId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ExerciseId");

                    b.HasIndex("CourseFKId");

                    b.HasIndex("StudentFKId");

                    b.HasIndex("TeacherFKId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            ExerciseId = 1,
                            CourseFKId = 111,
                            HelpWhere = "bord 3",
                            Lecture = "1",
                            Number = 1,
                            StudentFKId = "3",
                            TeacherFKId = "123456"
                        },
                        new
                        {
                            ExerciseId = 2,
                            CourseFKId = 111,
                            HelpWhere = "bord 5",
                            Lecture = "2",
                            Number = 1,
                            StudentFKId = "2",
                            TeacherFKId = "123456"
                        },
                        new
                        {
                            ExerciseId = 3,
                            CourseFKId = 222,
                            HelpWhere = "bord 19",
                            Lecture = "3",
                            Number = 1,
                            StudentFKId = "1",
                            TeacherFKId = "123456"
                        },
                        new
                        {
                            ExerciseId = 4,
                            CourseFKId = 222,
                            HelpWhere = "bord 7",
                            Lecture = "4",
                            Number = 1,
                            StudentFKId = "2",
                            TeacherFKId = "654321"
                        },
                        new
                        {
                            ExerciseId = 5,
                            CourseFKId = 222,
                            HelpWhere = "bord 7",
                            Lecture = "5",
                            Number = 1,
                            StudentFKId = "3",
                            TeacherFKId = "654321"
                        });
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Student", b =>
                {
                    b.Property<string>("AuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            AuId = "1",
                            Name = "Thanh"
                        },
                        new
                        {
                            AuId = "2",
                            Name = "Nikolaj"
                        },
                        new
                        {
                            AuId = "3",
                            Name = "Mads"
                        });
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.StudentAssignment", b =>
                {
                    b.Property<string>("StudentFKAuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AssignmentFKId")
                        .HasColumnType("int");

                    b.Property<int>("StudentAssignmentId")
                        .HasColumnType("int");

                    b.HasKey("StudentFKAuId", "AssignmentFKId");

                    b.HasIndex("AssignmentFKId");

                    b.ToTable("StudentAssignment");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.StudentCourse", b =>
                {
                    b.Property<string>("StudentCourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CourseFKId")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("StudentFKAuId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentCourseId");

                    b.HasIndex("CourseFKId");

                    b.HasIndex("StudentFKAuId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Teacher", b =>
                {
                    b.Property<string>("AuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseFkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuId");

                    b.HasIndex("CourseFkId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            AuId = "123456",
                            CourseFkId = 111,
                            Name = "Jens"
                        },
                        new
                        {
                            AuId = "654321",
                            CourseFkId = 222,
                            Name = "Poul"
                        });
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Assignment", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseFKId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineHelpSystem.Models.Teacher", "Teacher")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherFKId");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Exercise", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Course", "Course")
                        .WithMany("Exercises")
                        .HasForeignKey("CourseFKId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineHelpSystem.Models.Student", "Student")
                        .WithMany("Exercises")
                        .HasForeignKey("StudentFKId");

                    b.HasOne("OnlineHelpSystem.Models.Teacher", "Teacher")
                        .WithMany("Exercises")
                        .HasForeignKey("TeacherFKId");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.StudentAssignment", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Assignment", "Assignment")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AssignmentFKId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineHelpSystem.Models.Student", "Student")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("StudentFKAuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.StudentCourse", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseFKId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineHelpSystem.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentFKAuId");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Teacher", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Course", "Course")
                        .WithMany("Teachers")
                        .HasForeignKey("CourseFkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
