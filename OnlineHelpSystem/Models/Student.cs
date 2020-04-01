using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Student
    {
        public string Name { get; set; }
        [Key]
        public string AuId { get; set; }

        //relations
        public List<Exercise> Exercises { get; set; }
        public List<Course> Courses { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
