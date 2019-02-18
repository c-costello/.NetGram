using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetGram.Data;
using DotNetGram.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetGram.Models.Services
{
    public class PostService : IPost
    {
        private readonly PostDbContext _context;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="context">PostDbContext</param>
        public PostService(PostDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Delete post by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task Delete(int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

        }

        /// <summary>
        /// Find post by iD
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task Post</returns>
        public async Task<Post> FindPost(int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            return post;
        }

        /// <summary>
        /// Get a list of all posts
        /// </summary>
        /// <returns>Task List Post</returns>
        public async Task<List<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        /// <summary>
        /// Update a post if exists, else create new post
        /// </summary>
        /// <param name="post">Post</param>
        /// <returns>Task</returns>
        public async Task SaveAsync(Post post)
        {
            if (await _context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID) == null)
            {
                _context.Posts.Add(post);
            }
            else
            {
                _context.Update(post);
            }
            await _context.SaveChangesAsync();
        }
    }
}