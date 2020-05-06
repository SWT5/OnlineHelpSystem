using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Assignment: Object 
    {
        public string AssignmentName { get; set; }
        public string AssignmentNumber { get; set; }
        public int AssignmentId { get; set; }
        public string TeacherFKId { get; set; }
        public int CourseFKId { get; set; }
        //relations
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
        public List<StudentAssignment> StudentAssignments { get; set; }

        public override string ToString()
        {
            return $"[Assignment Name: {AssignmentName}, Assignment Number: {AssignmentNumber}, Assigment Id: {AssignmentId}]";
        }
    }
}
