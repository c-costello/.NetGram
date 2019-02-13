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

        public PostService(PostDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

        }

        public async Task<Post> FindPost(int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            return post;
        }

        public async Task<List<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

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