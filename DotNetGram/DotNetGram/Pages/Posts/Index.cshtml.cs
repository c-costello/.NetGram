using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetGram.Models;
using DotNetGram.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetGram.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly IPost _post;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="post"></param>
        public IndexModel(IPost post)
        {
            _post = post;
        }

        //Properties
        [FromRoute]
        public int ID { get; set; }
        public Post Post { get; set; }

        /// <summary>
        /// On Get, Get list of all posts
        /// </summary>
        /// <returns>Task</returns>
        public async Task OnGet()
        {
            Post = await _post.FindPost(ID);
        }
    }
}