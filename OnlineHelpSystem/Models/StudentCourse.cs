using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class StudentCourse
    {
        public string StudentCourseId { get; set; }

        public int CourseFKId { get; set; }
        public bool Active { get; set; }

        public int Semester { get; set; }

        public Student Student { get; set; }
        public string StudentFKAuId { get; set; }


        public Course Course { get; set; }


    }
}
