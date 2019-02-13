using DotNetGram.Data;
using DotNetGram.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace NetGramTests
{
    public class GettersAndSetters
    {
        [Fact]
        public void CanGetPostAuthor()
        {
            Post post = new Post();
            post.Author = "Clari";
            Assert.Equal("Clari", post.Author);
        }
        [Fact]
        public void CanSetPostAuthor()
        {
            Post post = new Post();
            post.Author = "Clari";
            post.Author = "Clarice";
            Assert.Equal("Clarice", post.Author);
        }

        [Fact]
        public void CanGetPostDescription()
        {
            Post post = new Post();
            post.Description = "Here's a message";
            Assert.Equal("Here's a message", post.Description);
        }
        [Fact]
        public void CanSetPostDescription()
        {
            Post post = new Post();
            post.Description = "Here's a message";
            post.Description = "Here's a second message";
            Assert.Equal("Here's a second message", post.Description);
        }

        [Fact]
        public void CanGetPostImage()
        {
            Post post = new Post();
            post.Image = "https://via.placeholder.com/150";
            Assert.Equal("https://via.placeholder.com/150", post.Image);
        }

        [Fact]
        public void CanSetPostImage()
        {
            Post post = new Post();
            post.Image = "https://via.placeholder.com/150";
            post.Image = "https://via.placeholder.com/200";
            Assert.Equal("https://via.placeholder.com/200", post.Image);
        }

    }
}
