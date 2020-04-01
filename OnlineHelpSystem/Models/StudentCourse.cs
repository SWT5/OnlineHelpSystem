using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public bool Active { get; set; }

        public int Semester { get; set; }

        public Student Student { get; set; }
        public string StudentAuId { get; set; }


        public Course Course { get; set; }

        public int CourseId { get; set; }


    }
}
