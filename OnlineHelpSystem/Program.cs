using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                System.Console.WriteLine("Insert: a(Author), b(Book), r(Review), p(PriceOffer)");
                System.Console.WriteLine("Query: qb(Books), qa(Authors)");
                System.Console.WriteLine("Exit: x");

                while (true)
                {
                    System.Console.WriteLine("Type command");
                    string line = Console.ReadLine();

                    switch (line)
                    {
                        case "s":
                            Student student = inputStudent(context);
                            context.Students.Add(student);
                            context.SaveChanges();
                            break;
                        case "c":
                            Course course = InputBook();
                            context.Courses.Add(course);
                            context.SaveChanges();
                            break;

                        case "p":
                            Exercise exercise = InputPriceOffer();
                            context.Students.Add();
                            context.SaveChanges();
                            break;

                        case "a":
                            Assignment assignment = InputReview(context);
                            context.Assignments.Add(assignment);
                            context.SaveChanges();
                            break;

                        case "qb":
                            ListBooks(context);
                            break;

                        case "qa":
                            ListAuthors(context);
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
                List<Student> list = context.Students.ToList();
                foreach (var student in list)
                {
                    context.Entry(student).Collection(s => s.StudentCourses);

                    Console.WriteLine(student);
                }
            }

        private static void ListTeahers(myDBContext context)
        {
            List<Teacher> teachers = context.Teachers
                .Include(t => t.Course).ThenInclude(c => c.Teachers).ToList();

            Console.WriteLine(string.Join(",", teachers));
        }

        //given student print list of all students open help requests
        private static void ListAllStudentHelpRequests(myDBContext context)
        {
            List<Student> students = context.Students
                .Include(s => s.Exercises).ThenInclude(e => e.HelpWhere).ToList();
        }

        // find student
        private static Student findStudent(myDBContext context)
        {
            Console.WriteLine("AuID: ");
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
            Console.WriteLine("AuID: ");
            string auid = Console.ReadLine();

            return context.Teachers.Where(s => s.AuId == auid).Single();
        }

        //create student
        private static Student inputStudent(myDBContext context)
        {
            Course course = findCourse(context); 

            Console.WriteLine("Name: ");
            string name = Console.ReadLine(); 

            Console.WriteLine("AuID: ");
            string auid = Console.ReadLine();

            Student student = new Student()
            {
                Name = name,
                AuId = auid
            };

            if (course != null)
            { 
                student.StudentCourses = new List<StudentCourse>()
                {
                    new StudentCourse()
                    {
                        Course = course,
                        Student = student
                    }
                };
            }
            return student;
        }

        // create teacher
        private static Teacher inpuTeacher(myDBContext context)
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine(); 

            Console.WriteLine("AuID: ");
            string auid = Console.ReadLine();

            return new Teacher()
            {
                Name = name,
                AuId = auid
            };
        }


        //create course
        private static Course inputCourse(myDBContext context)
        {
            Teacher teacher = findTeacher(context); // finder teacher der skal sættes til kurset

            Console.WriteLine("title: ");
            string title = Console.ReadLine(); 

            Console.WriteLine("CourseID: ");
            int courseId = int.Parse(Console.ReadLine());

            Course course = new Course()
            {
                Name = title,
                CourseId = courseId
            };

            if (teacher != null)
            {
                course.Teachers = new List<Teacher>()
                {
                    new Teacher()
                    {
                        Course = course
                    }
                };
            }

            return course;
        }

        private static Exercise createHelpRequestExercise(myDBContext context)
        {
            Student student = findStudent(context);

            Console.WriteLine("Lecture: ");
            string lecture = Console.ReadLine();

            Console.WriteLine("Number: ");
            int number = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Help where?: ");
            string helpWhere = Console.ReadLine();

            Exercise exercise = new Exercise()
            {
                Lecture = lecture,
                Number = number,
                HelpWhere = helpWhere
            };

            if (student != null)
            {
                //exercise.Student.Exercises = new List<Exercise>()
                //{
                //    new Exercise()
                //    {
                //        Student = student
                //    }
                //};
                student.Exercises.Add(exercise);
            }
            return exercise;
        }



    }


       
}
