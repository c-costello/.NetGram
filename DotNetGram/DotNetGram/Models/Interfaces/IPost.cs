using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetGram.Models.Interfaces
{
    public interface IPost
    {
        //Save
        Task SaveAsync(Post post);

        //Delete
        Task Delete(int id);

        //Find
        Task<Post> FindPost(int id);

        //GetAll
        Task<List<Post>> GetPosts();
    }
}
