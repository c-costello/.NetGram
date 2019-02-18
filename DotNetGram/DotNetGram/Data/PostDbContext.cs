using DotNetGram.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetGram.Data
{
    public class PostDbContext : DbContext
    {
        /// <summary>
        /// Configure options, PostDBContext constructor 
        /// </summary>
        /// <param name="options"></param>
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Create seed data, creates database tables
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed Data
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    ID = 1,
                    Image = "https://via.placeholder.com/150",
                    Author = "Clari",
                    Description = "Placeholder One"
                },
                new Post
                {
                    ID = 2,
                    Image = "https://via.placeholder.com/150",
                    Author = "Nate",
                    Description = "Placeholder Two"
                },
                new Post
                {
                    ID = 3,
                    Image = "https://via.placeholder.com/150",
                    Author = "Mike",
                    Description = "Placeholder Three"
                },
                new Post
                {
                    ID = 4,
                    Image = "https://via.placeholder.com/150",
                    Author = "Xia",
                    Description = "Placeholder Four"
                },
                new Post
                {
                    ID = 5,
                    Image = "https://via.placeholder.com/150",
                    Author = "Mike G.",
                    Description = "Placeholder Five"
                }
            );
            }
        

        public DbSet<Post> Posts { get; set; }
    }
}
