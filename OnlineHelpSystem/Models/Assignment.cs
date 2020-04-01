using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Assignment
    {
        public string AssignmentName { get; set; }
        public string AssignmentNumber { get; set; }
        public int AssignmentId { get; set; }
        //relations
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
        public List<StudentAssignment> StudentAssignments { get; set; }
    }
}
