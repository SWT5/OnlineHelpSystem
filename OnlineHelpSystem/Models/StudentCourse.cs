using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class StudentCourse
    {
        public bool Active { get; set; }

        public int Semester { get; set; }

        public Student student { get; set; }
        public string studentAuId { get; set; }


        public Course course { get; set; }

        public int courseId { get; set; }


    }
}
