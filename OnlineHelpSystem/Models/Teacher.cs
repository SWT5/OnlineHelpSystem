using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Teacher
    {
        public string name { get;  set; }
        public string AuId { get;  set; }


        /*Relationerne*/
        public List<Assignment> Assignments { get; set; }
        public List<Exercise> Exercises { get;  set; }
        public Course Course { get; set; }


        /*Make prints out*/
        public override string ToString()
        {
            var Assigments = "";
            if (Assigments!=null)
            {
                Assigments = string.Join(";", Assigments);
            }
            var Exercises = "";
            if (Exercises!=null)
            {
                Exercises = string.Join(";", Exercises);
            }

            return string.Format("Teacher ({0},{1},{2},{3})", name, AuId, Exercises, Assigments);
        }
    }
}
