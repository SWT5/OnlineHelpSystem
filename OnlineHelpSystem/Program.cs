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
                            Student student = InputAuthor(context);
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


        //insert student
        private static Student inputStudent(myDBContext context)
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine(); 

            Console.WriteLine("AuID: ");
            string auid = Console.ReadLine(); 

            return new Student()
            {

            }
        }

    }


       
}
