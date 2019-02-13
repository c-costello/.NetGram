using DotNetGram.Data;
using DotNetGram.Models;
using DotNetGram.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace NetGramTests
{
    public class CRUD
    {
        //[Fact]
        //public async void CanCreatePost()
        //{
        //    DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("SaveAsync").Options;

        //    using (PostDbContext context = new PostDbContext(options))
        //    {
        //        Post post = new Post();
        //        post.ID = 1;
        //        post.Author = "Clari";
        //        post.Description = "A Description";
        //        post.Image = "xxx";

        //        PostService postService = new PostService(context);

        //        await postService.SaveAsync(post);

        //        var result = await context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID);
        //        Assert.Equal(post, result);


        //    }
        //}
    }
}
