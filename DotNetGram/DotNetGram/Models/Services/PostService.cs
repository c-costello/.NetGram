using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetGram.Models.Interfaces;

namespace DotNetGram.Models.Services
{
    public class PostService : IPost
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> FindPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
