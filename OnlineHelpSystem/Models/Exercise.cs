using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Exercise
    {
        public int Number { get; set; }     // primary key with Lecture
        public string Lecture { get; set; } // primary key with number
        public string HelpWhere { get; set; }
        public Teacher Teacher;
        public Student Student;
        public Course Course;
    }
}
