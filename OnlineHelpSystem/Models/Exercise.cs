using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int Number { get; set; }     // primary key with Lecture
        public string Lecture { get; set; } // primary key with number
        public string HelpWhere { get; set; }
        public int CourseFKId { get; set; }
        public string StudentFKId { get; set; }
        public string TeacherFKId { get; set; }
        public bool IsOpen { get; set; }
        
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

        public override string ToString()
        {
            return $"[Execise Lecture: {Lecture}, ExeciseNumber: {Number}, Help at {HelpWhere}, Execise ID: {ExerciseId}], Reqeust isOpen: {IsOpen}";
        }
    }
}
