using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todos.Models;

namespace todos
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=TodoDB;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString)
                          .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo()
                {
                    Id = 1,
                    Name = "Test Todo 1",
                    Content = "Sample todo item 1",
                    CreatedOn = DateTime.Now,
                    IsDone = false,
                    DueBy = DateTime.Now.AddDays(5),
                    Username = "SYSTEM"
                },
                new Todo()
                {
                    Id = 2,
                    Name = "Test Todo 2",
                    Content = "Sample todo item 2",
                    CreatedOn = DateTime.Now,
                    IsDone = false,
                    DueBy = DateTime.Now.AddDays(5),
                    Username = "SYSTEM"
                },
                new Todo()
                {
                    Id = 3,
                    Name = "Test Todo 3",
                    Content = "Sample todo item 3",
                    IsDone = false,
                    CreatedOn = DateTime.Now,
                    DueBy = DateTime.Now.AddDays(5),
                    Username = "SYSTEM"
                }
            ) ; 
        }
    }
}
