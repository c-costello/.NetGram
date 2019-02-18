using DotNetGram.Data;
using DotNetGram.Models;
using DotNetGram.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetGramTests
{
    public class CRUD
    {
        [Fact]
        public async void CanCreatePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("SaveAsync").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                Post post = new Post();
                post.ID = 1;
                post.Author = "Clari";
                post.Description = "A Description";
                post.Image = "xxx";

                PostService postService = new PostService(context);

                await postService.SaveAsync(post);

                var result = await context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID);
                Assert.Equal(post, result);


            }
        }

        [Fact]
        public async void CanFindPost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("FindPost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                Post post = new Post();
                post.ID = 1;
                post.Author = "Clari";
                post.Description = "A Description";
                post.Image = "xxx";

                PostService postService = new PostService(context);

                await postService.SaveAsync(post);

                var result = await postService.FindPost(post.ID);
                Assert.Equal(post, result);


            }
        }

        [Fact]
        public async void CanGetPosts()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("GetPosts").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                Post post = new Post();
                post.ID = 1;
                post.Author = "Clari";
                post.Description = "A Description";
                post.Image = "xxx";

                Post post2 = new Post();
                post2.ID = 2;
                post2.Author = "Nate";
                post2.Description = "Another Description";
                post2.Image = "xxxx";

                PostService postService = new PostService(context);

                await postService.SaveAsync(post);
                await postService.SaveAsync(post2);
                List<Post> posts = new List<Post>();
                posts.Add(post);
                posts.Add(post2);


                var result = await postService.GetPosts();
                Assert.Equal(posts, result);


            }

        }

        [Fact]
        public async void CanEditPost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("UpdatePosts").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                Post post = new Post();
                post.ID = 1;
                post.Author = "Clari";
                post.Description = "A Description";
                post.Image = "xxx";

                PostService postService = new PostService(context);

                await postService.SaveAsync(post);

                post.Author = "Clarice";
                await postService.SaveAsync(post);

                var result = await context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID);
                Assert.Equal(post, result);


            }

        }

        [Fact]
        public async void CanDeletePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("DeletePost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                Post post = new Post();
                post.ID = 1;
                post.Author = "Clari";
                post.Description = "A Description";
                post.Image = "xxx";

                PostService postService = new PostService(context);

                await postService.SaveAsync(post);
                await postService.Delete(post.ID);

                var result = await context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID);
                Assert.Null(result);


            }

        }
    }
}
