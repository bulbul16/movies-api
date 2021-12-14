using Microsoft.EntityFrameworkCore;
using movies.domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace movies.data.dbContext
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
