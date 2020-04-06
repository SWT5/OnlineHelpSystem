using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineHelpSystem.Data;

namespace OnlineHelpSystem.Models
{
    public class SeedData
    {
        public void Initializer()
        {
            using (var context = new myDBContext())
            {
                var student = new Student() {Name = "Nikolaj", AuId = "2018067"};
                context.Add(student);

                var course = new Course() {Name = "DAB"};
                context.Add(course);

                var teacher = new Teacher() {Name = "Poul Ejner", AuId = "100", Course = course};
                context.Add(teacher);

                var exercise = new Exercise() {Lecture = "1", Number = 1, HelpWhere = "help table 3 - Benjamin"};
                context.Add(exercise);

                var assignment = new Assignment() {AssignmentNumber = "1"};
                context.Add(assignment);

                context.SaveChanges();

            }
        }

        //public void Transaction()
        //{
        //    using (var context = new myDBContext())
        //    {
        //        using (var transaction = context.Database.BeginTransaction())
        //        {
                    
        //        }
        //    }
        //}
    }
}
