﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using OnlineHelpSystem.Models;
using OnlineHelpSystem.Data;

namespace OnlineHelpSystem
{
    // test
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new myDBContext())
            {
                System.Console.WriteLine("Usage");
                System.Console.WriteLine("Insert: s(Student), t(Teacher), c(Course), e(Exercise HelpRequest), a(Assignment HelpRequest)");
                System.Console.WriteLine("Lists: ls(Students), lt(Teachers), lc(Courses), shr(student helpRequests)");
                System.Console.WriteLine("Exit: x");

                while (true)
                {
                    System.Console.WriteLine("Type command");
                    string line = Console.ReadLine();

                    switch (line)
                    {
                        case "s":
                            Student student = CreateStudent(context);
                            context.Students.Add(student);
                            context.SaveChanges();
                            break;
                        case "c":
                            Course course = CreateCourse(context);
                            context.Courses.Add(course);
                            context.SaveChanges();
                            break;

                        case "t":
                            Teacher teacher = CreateTeacher(context);
                            context.Teachers.Add(teacher);
                            context.SaveChanges();
                            break;

                        case "e":
                            Exercise exercise = CreateExeciseHelpRequest(context);
                            context.Exercises.Add(exercise);
                            context.SaveChanges();
                            break;

                        case "a":
                            Assignment assignment = CreateAssignmentHelpRequest(context);
                            context.Assignments.Add(assignment);
                            context.SaveChanges();
                            break;

                        //case "he":
                        //    Exercise exe = CreateExeciseHelpRequest(context);
                        //    context.Exercises.Add(exercise);
                        //    context.SaveChanges();
                        //    break;

                        case "ls":
                            ListAllStudents(context);
                            break;

                        case "lt":
                            ListAllTeachers(context);
                            break;

                        case "lc":
                            ListAllCourses(context);
                            break;
                        case "shr": 
                            ListStudentHelpRequests(context);
                            break;

                        case "x":
                            System.Console.WriteLine("Exiting....");
                            return;
                        default:
                            System.Console.WriteLine("Unknown command");
                            break;
                    }
                }
            }
        }

        //views 

        private static void ListAllStudents(myDBContext context)
            {
                Console.WriteLine("listing all students");
                var students = context.Students.ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Name}: {s.AuId}");
                }
            }

        private static void ListStudentHelpRequests(myDBContext context)
        {
            ListAllStudents(context);
            Console.WriteLine("type which student you are looking for");
            Student student =  findStudent(context);
            var HelpRequests = student.Exercises;
            Console.WriteLine("Listing all students helpRequests");
            foreach (var e in student.Exercises)
            {
                Console.WriteLine($"{e.Course}: {e.Lecture},{e.Number}: {e.HelpWhere}");
            }
        }

        private static void ListAllTeachers(myDBContext context)
        {
            List<Teacher> teachers = context.Teachers
                .Include(t => t.Course).ThenInclude(c => c.Teachers).ToList();

            Console.WriteLine(string.Join(",", teachers));
        }


        private static void ListAllCourses(myDBContext context)
        {
            Console.WriteLine("listing all courses");
            var courses = context.Courses.ToList();
            foreach (var c in courses)
            {
                Console.WriteLine($"{c.Name}: {c.CourseId}");
            }
        }

        //given student print list of all students open help requests
        //private static void ListAllStudentHelpRequests(myDBContext context)
        //{
        //    List<Student> students = context.Students
        //        .Include(s => s.Exercises).ThenInclude(e => e.HelpWhere).ToList();
        //}

        // find student
        private static Student findStudent(myDBContext context)
        {
            Console.WriteLine("Student AuID: ");
            string auid = Console.ReadLine();

            return context.Students.Where(s => s.AuId == auid).Single();
        }

        // find course
        private static Course findCourse(myDBContext context)
        {
            Console.WriteLine("CourseID: ");
            int courseId = int.Parse(Console.ReadLine());
            
            return context.Courses.Where(c => c.CourseId == courseId).Single();
           
        }

        //find teacher
        private static Teacher findTeacher(myDBContext context)
        {
            Console.WriteLine("Teacher AuID: ");
            string auid = Console.ReadLine();

            return context.Teachers.Where(s => s.AuId == auid).Single();
        }

        // find Execise
        private static Exercise findExercise(myDBContext context)
        {
            Console.WriteLine("Lecture: ");
            string lecture = Console.ReadLine();

            Console.WriteLine("Number: ");
            int number = int.Parse(Console.ReadLine()); 

            return context.Exercises.Where(e => e.Lecture == lecture && e.Number == number).Single();
        }

        //find Assignment
        private static Assignment findAssignment(myDBContext context)
        {
            Console.WriteLine("AssignmentNumber: ");
            string assignmentNumber = Console.ReadLine();

            Console.WriteLine("AssignmentID: ");
            int assignmentId = int.Parse(Console.ReadLine()); 

            return context.Assignments.Where(a => a.AssignmentNumber == assignmentNumber && a.AssignmentId == assignmentId).Single();
        }

        //create student
        private static Student CreateStudent(myDBContext context)
        {
            //Course course = findCourse(context); 

            Console.WriteLine("Student Name: ");
            string name = Console.ReadLine(); 

            Console.WriteLine("Student AuID: ");
            string auid = Console.ReadLine();

            Student student = new Student()
            {
                Name = name,
                AuId = auid
            };
            
            student.Exercises = new List<Exercise>();
            student.StudentAssignments = new List<StudentAssignment>();
            student.StudentCourses = new List<StudentCourse>();

            //if (course != null)
            //{ 
            //    student.StudentCourses = new List<StudentCourse>()
            //    {
            //        new StudentCourse()
            //        {
            //            Course = course,
            //            Student = student
            //        }
            //    };
            //}
            return student;
        }

        // create teacher
        private static Teacher CreateTeacher(myDBContext context)
        {
            Course course = findCourse(context); 
            Console.WriteLine("Teacher Name: ");
            string name = Console.ReadLine(); 

            Console.WriteLine("AuID: ");
            string auid = Console.ReadLine();

            Teacher teacher = new Teacher()
            {
                Name = name,
                AuId = auid,
            };

            if (course != null)
            {
                teacher.CourseFkId = course.CourseId;
                return teacher;
            }
            else
            {
                Console.WriteLine("Course does not exists!");
                return null;
            }
        }


        //create course
        private static Course CreateCourse(myDBContext context)
        {
            //Teacher teacher = findTeacher(context); // finder teacher der skal sættes til kurset

            Console.WriteLine("Course title: ");
            string title = Console.ReadLine(); 

            //Console.WriteLine("CourseID: ");
            //int courseId = int.Parse(Console.ReadLine());

            Course course = new Course()
            {
                Name = title,
                //CourseId = courseId
            };
            course.Teachers = new List<Teacher>();
            course.StudentCourses = new List<StudentCourse>(); 
            course.Assignments = new List<Assignment>();
            course.Exercises = new List<Exercise>();


            //if (teacher != null)
            //{
            //    teacher.Course = course;
            //    course.Teachers = new List<Teacher>
            //    {
            //        teacher
            //    };

            //}

            return course;
        }

        //input assignment to couse
        private static Assignment inputAssignment(myDBContext context)
        {
            Course course = new Course(); 
            Course temp = findCourse(context);
            Teacher teacher = new Teacher();

            Console.WriteLine("AssignmentName: ");
            string assignmentName = Console.ReadLine();

            Console.WriteLine("AssignmentNumber: ");
            string assignmentNumber = Console.ReadLine();

            Console.WriteLine("Want a specific teacher? type(y) for yes ");
            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.WriteLine("type teachers auID");
                teacher = findTeacher(context);
            }

            Assignment assignment = new Assignment()
            {
                /*AssignmentId = assignmentId,*/
                AssignmentNumber = assignmentNumber,
                AssignmentName = assignmentName,
                TeacherFKId = teacher.AuId
            };

            if (temp != null)
            {
                course = temp;
            }

            if (course != null)
            {
                course.Assignments = new List<Assignment>();
                course.Assignments.Add(assignment);
                assignment.Course = course;
                context.Assignments.Add(assignment);
            }
            else
            {
                Console.WriteLine("No course and no teacher");
                return null;
            }
            return assignment;
        }

        // input execise to course
        private static Exercise inputExercise(myDBContext context)
        {
            Course course = findCourse(context);
            Teacher teacher = new Teacher();
            Console.WriteLine("Lecture: ");
            string lecture = Console.ReadLine();

            Console.WriteLine("Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Help where?: ");
            string helpWhere = Console.ReadLine();

            Console.WriteLine("Want a specific teacher? type(y) for yes ");
            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.WriteLine("type teachers auID");
                teacher = findTeacher(context);
            }

            Exercise exercise = new Exercise()
            {
                Lecture = lecture,
                Number = number,
                HelpWhere = helpWhere,
                TeacherFKId = teacher.AuId
            };

            if (course != null)
            {
                course.Exercises = new List<Exercise>();
                course.Exercises.Add(exercise);
                context.Exercises.Add(exercise);
            }


            return exercise;
        }


        private static Exercise CreateExeciseHelpRequest(myDBContext context)
        {
            Student student = findStudent(context);
            Exercise exercise = inputExercise(context);

            //Console.WriteLine("Lecture: ");
            //string lecture = Console.ReadLine();

            //Console.WriteLine("Number: ");
            //int number = int.Parse(Console.ReadLine());
            
            //Console.WriteLine("Help where?: ");
            //string helpWhere = Console.ReadLine();

            //Exercise exercise = new Exercise()
            //{
            //    Lecture = lecture,
            //    Number = number,
            //    HelpWhere = helpWhere
            //};

            if (student != null)
            {
                exercise.Student = student;
                student.Exercises = new List<Exercise>();
                student.Exercises.Add(exercise);
            }
            return exercise;
        }


        // create assignmentHelpRequest
        private static Assignment CreateAssignmentHelpRequest(myDBContext context)
        {
            Student student = findStudent(context);
            Assignment assignment = inputAssignment(context);

            //Console.WriteLine("AssignmentName: ");
            //string assignmentName = Console.ReadLine(); 

            //Console.WriteLine("AssignmentNumber: ");
            //string assignmentNumber = Console.ReadLine();

            //Console.WriteLine("AssignmentID: ");
            //int assignmentId = int.Parse(Console.ReadLine());

            //Assignment assignment = new Assignment()
            //{
            //    AssignmentName = assignmentName,
            //    AssignmentNumber = assignmentNumber,
            //    AssignmentId = assignmentId
            //};

            if (student != null)
            {
                assignment.StudentAssignments = new List<StudentAssignment>()
                {
                    new StudentAssignment()
                    {
                        Student = student,
                        Assignment = assignment
                    }
                };
            }

            return assignment;
        }

        private static Teacher HelpWithExecise(myDBContext context)
        {
            // help with execise
            Exercise exercise = findExercise(context);
            Teacher teacher = CreateTeacher(context); 

            if (exercise != null)
            {
                exercise.Teacher = teacher;
                teacher.Exercises.Add(exercise);
            }
            if (exercise == null)
                return null; 
            else
                return exercise.Teacher;
        }

        // help With assigment
        private static Teacher HelpWithAssignment(myDBContext context)
        {
            Assignment assignment = findAssignment(context);
            Teacher teacher = CreateTeacher(context); 

            if (assignment != null)
            {
                assignment.Teacher = teacher;
                teacher.Assignments.Add(assignment);
            }
            if (assignment == null)
                return null; 
            else
                return assignment.Teacher;
        }



    }


       
}
