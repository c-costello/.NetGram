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
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    ID = 1,
                    Image = "https://via.placeholder.com/150",
                    Poster = "Clari",
                    Description = "Placeholder One"
                },
                new Post
                {
                    ID = 2,
                    Image = "https://via.placeholder.com/150",
                    Poster = "Nate",
                    Description = "Placeholder Two"
                },
                new Post
                {
                    ID = 3,
                    Image = "https://via.placeholder.com/150",
                    Poster = "Mike",
                    Description = "Placeholder Three"
                },
                new Post
                {
                    ID = 4,
                    Image = "https://via.placeholder.com/150",
                    Poster = "Xia",
                    Description = "Placeholder Four"
                },
                new Post
                {
                    ID = 5,
                    Image = "https://via.placeholder.com/150",
                    Poster = "Mike G.",
                    Description = "Placeholder Five"
                }
            );
            }
        

        public DbSet<Post> Posts { get; set; }
    }
}
