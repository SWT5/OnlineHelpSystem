using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Course
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int Semester { get; set; }

        //relationships
        public List<StudentCourse> StudentCourses { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Exercise> Exercises { get; set; }

    }
}
