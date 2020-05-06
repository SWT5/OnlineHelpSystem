using System;
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
                while (true)
                {
                    Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
                    System.Console.WriteLine("Type command");
                    System.Console.WriteLine("Usage");
                    System.Console.WriteLine("Create:\t s(Student), t(Teacher), c(Course), e(Exercise HelpRequest), a(Assignment HelpRequest)");
                    System.Console.WriteLine("Lists:\t ls(Students), lt(Teachers), lc(Courses)");
                    System.Console.WriteLine("Find:\t sfr(helpRequests by student), tcfr(help request by teacher/course)");
                    System.Console.WriteLine("print:\t pa (print all help requests)");
                    System.Console.WriteLine("Exit:\t x");
                    Console.WriteLine("|----------------------------------------------------------------------------------------------------|\n");

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

                        case "ls":
                            ListAllStudents(context);
                            break;

                        case "lt":
                            ListAllTeachers(context);
                            break;

                        case "lc":
                            ListAllCourses(context);
                            break;
                        case "tcfr": 
                            View_Teacher_Course_HelpRequests(context);
                            break;
                        case "sfr":
                            View_Students_HelpRequest(context);
                            break;

                        case "x":
                            System.Console.WriteLine("Exiting....");
                            return;
                        case "help":
                            HelpWithExecise(context);
                            break;
                        case "pa":
                            View_Print_all_helprequest(context);
                            break;
                        default:
                            System.Console.WriteLine("Unknown command");
                            break;
                    }
                }
            }
        }

        //Lists
        #region Lists
        //lists

        private static void ListAllStudents(myDBContext context)
            {
                Console.WriteLine("listing all students");
                var students = context.Students.ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"Student name: {s.Name}, AuID: {s.AuId}");
                }
            }

        private static void ListStudentHelpRequests(myDBContext context)
        {
            Console.WriteLine("type which student you are looking for");
            Student student =  findStudent(context);
            var HelpRequests = student.Exercises;
            Console.WriteLine("Listing all students helpRequests");
            foreach (var e in student.Exercises)
            {
                Console.WriteLine($"Course: {e.Course}, Lecture: {e.Lecture}, Exercise Nr: {e.Number}, Location: {e.HelpWhere}");
            }
        }

        private static void ListAllTeachers(myDBContext context)
        {
            Console.WriteLine("listing all teachers");
            var teachers = context.Teachers.ToList();
            foreach (var t in teachers)
            {
                Console.WriteLine($"Teacher name: {t.Name}, AuID: {t.AuId}");
            }

        }


        private static void ListAllCourses(myDBContext context)
        {
            Console.WriteLine("listing all courses");
            var courses = context.Courses.ToList();
            foreach (var c in courses)
            {
                Console.WriteLine($"Course name: {c.Name}, CourseID: {c.CourseId}");
            }
        }

#endregion

        //views 

        #region views

        private static void View_Teacher_Course_HelpRequests(myDBContext context)
        {
            Console.WriteLine("Find help request with teacherId and courseId");
            string teacherId = findTeacher(context).AuId;
            int courseId = findCourse(context).CourseId;

            Console.WriteLine("Helps with: ");
            var exercises = context.Exercises.Where(e => e.TeacherFKId == teacherId && courseId == e.CourseFKId && e.IsOpen == true)
                .Select(e => new {e.ExerciseId, e.Lecture, e.Number, e.HelpWhere}).ToList();
            foreach (var e in exercises)
            {
                Console.WriteLine(e);
            }
            
            var assignments = context.Assignments.Where(a => a.TeacherFKId == teacherId && courseId == a.CourseFKId && a.IsOpen == true)
                .Select(a => new { a.AssignmentName, a.AssignmentNumber, a.AssignmentId}).ToList();
            foreach (var s in assignments)
            {
                Console.WriteLine(s);
            }
        }

        private static void View_Students_HelpRequest(myDBContext context)
        {

            Console.WriteLine("Find help request by students");
            string studentId = findStudent(context).AuId;


            Console.WriteLine("Needs help with: ");
            var exercises = context.Exercises.Where(e => e.StudentFKId == studentId && e.IsOpen == true)
                .Select(e => new { e.ExerciseId, e.Lecture, e.Number, e.HelpWhere, e.IsOpen }).ToList();
            foreach (var e in exercises)
            {
                Console.WriteLine(e);
            }


            var studentsInShadowTabel = context.Students
                .Include(s => s.StudentAssignments).ThenInclude(row => row.Assignment)
                .First(s => s.AuId == studentId );

            foreach (var s in studentsInShadowTabel.StudentAssignments)
            {
                if (s.Assignment.IsOpen == true)
                    Console.WriteLine(s.Assignment.ToString());
            }
        }

        private static void View_Print_all_helprequest(myDBContext context)
        {
            var courses = context.Courses.ToList();

            foreach (var c in courses)
            {
                Console.WriteLine(c.Name);
                var assignments = context.Assignments.Where(a => a.CourseFKId == c.CourseId);
                var exercises = context.Exercises.Where(e => e.CourseFKId == c.CourseId);

                foreach (var a in assignments)
                {
                    Console.WriteLine(a.ToString());
                }

                foreach (var e in exercises)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }





        #endregion

        //find
        #region Find methods
        // find student
        private static Student findStudent(myDBContext context)
        {
            ListAllStudents(context);
            Console.WriteLine("Choose student AuID: ");
            string auid = Console.ReadLine();

            return context.Students.Where(s => s.AuId == auid).Single();
        }

        // find course
        private static Course findCourse(myDBContext context)
        {
            ListAllCourses(context);
            Console.WriteLine("Choose CourseID: ");
            int courseId = int.Parse(Console.ReadLine());
            
            return context.Courses.Where(c => c.CourseId == courseId).Single();
           
        }

        //find teacher
        private static Teacher findTeacher(myDBContext context)
        {
            ListAllTeachers(context);
            Console.WriteLine("Choose Teacher AuID: ");
            string auid = Console.ReadLine();

            return context.Teachers.Where(s => s.AuId == auid).Single();
        }

        // find Execise
        private static Exercise findExercise(myDBContext context)
        {
            ListStudentHelpRequests(context);
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

        #endregion

        //create 
        #region Create methods
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

            return student;
        }

        // create teacher
        private static Teacher CreateTeacher(myDBContext context)
        {
            Course course = new Course();
            Console.WriteLine("Teacher Name: ");
            string name = Console.ReadLine(); 

            Console.WriteLine("AuID: ");
            string auid = Console.ReadLine();

            Console.WriteLine("Assign teacher to a course? type(y) for yes ");
            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.WriteLine("type CourseID");
                course = findCourse(context);
            }

            Teacher teacher = new Teacher()
            {
                Name = name,
                AuId = auid,
                Course = course
            };

            course.Teachers = new List<Teacher>();
            course.Teachers.Add(teacher);
            context.Teachers.Add(teacher);
            return teacher;
            
            
        }


        //create course
        private static Course CreateCourse(myDBContext context)
        {
            //Teacher teacher = findTeacher(context); // finder teacher der skal sættes til kurset

            Console.WriteLine("Course title: ");
            string title = Console.ReadLine(); 

            Course course = new Course()
            {
                Name = title,
                //CourseId = courseId
            };
            course.Teachers = new List<Teacher>();
            course.StudentCourses = new List<StudentCourse>(); 
            course.Assignments = new List<Assignment>();
            course.Exercises = new List<Exercise>();


           

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
                AssignmentNumber = assignmentNumber,
                AssignmentName = assignmentName,
                TeacherFKId = teacher.AuId,
                IsOpen = true
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
                TeacherFKId = teacher.AuId,
                IsOpen = true
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
                        Assignment = assignment,
                    }
                };
            }

            return assignment;
        }

        #endregion


        #region other things
        private static Teacher HelpWithExecise(myDBContext context)
        {
            // help with execise
            Exercise exercise = findExercise(context);
            Teacher teacher = CreateTeacher(context);

            if (exercise != null)
            {
                exercise.Teacher = teacher;
                teacher.Exercises.Add(exercise);
                exercise.IsOpen = false;
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

        #endregion



    }



}
