using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    public class Exercise
    {
        public int Number { get; set; }
        public string Lecture { get; set; }
        public string HelpWhere { get; set; }
        public Teacher Teacher;
    }
}
