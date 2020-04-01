using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Teacher
    {
        public string Name { get;  set; }
        public string AuId { get;  set; }

        public List<Exercise> Exercises { get;  set; }

        /*Make prints out*/
    }
}
