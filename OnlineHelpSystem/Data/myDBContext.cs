using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;



namespace OnlineHelpSystem.Data
{
    class myDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Database=BookStore2;User ID=SA;Password=SecurePassword1!;");
        }

        public DbSet<Teacher> Teacher { get;  set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Teacher
            modelBuilder.Entity<Teacher>().HasKey(a  => new { a.name});
            modelBuilder.Entity<Teacher>() //One to many
                .HasMany<Exercise>(a => a.Exercises)
                .WithOne(r => r.Teacher)
                .HasForeignKey(r  =>  r.name);

        }
    }
}
