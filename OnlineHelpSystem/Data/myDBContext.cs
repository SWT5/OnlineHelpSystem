using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineHelpSystem.Models;


namespace OnlineHelpSystem.Data
{
    class myDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Database=BookStore2;User ID=SA;Password=SecurePassword1!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Teacher
            modelBuilder.Entity<Teacher>().HasKey(t  => new { t.name});
            modelBuilder.Entity<Teacher>() //One to many Exercises
                .HasMany<Exercise>(t => t.Exercises)
                .WithOne(r => r.Teacher)
                .HasForeignKey(r  =>  r.Teacher.AuId);
            modelBuilder.Entity<Teacher>() // one to many Assigment

            //Course
            modelBuilder.Entity<Course>().HasKey(c => new {c.CourseId});
            modelBuilder.Entity<Course>() //one to many (Teacher)
                .HasMany<Teacher>()
                

        }
    }
}
