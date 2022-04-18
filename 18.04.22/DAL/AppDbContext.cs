using _18._04._22.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _18._04._22.DAL
{
    internal class AppDbContext:DbContext
    {
        public DbSet <Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Blog;Trusted_Connection=True;");
        }
    }
}
