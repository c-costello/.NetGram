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
    public class ManageModel : PageModel
    {
        private readonly IPost _post;
        public ManageModel(IPost post)
        {
            _post = post;
        }
        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Post Post { get; set; }




        public async Task OnGet()
        {
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
        }

        public async Task<IActionResult> OnPost()
        {
            var post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();

            post.ID = Post.ID;
            post.Image = Post.Image;
            post.Poster = Post.Poster;
            post.Description = Post.Description;

            await _post.SaveAsync(post);

            return RedirectToPage("Posts/Index", new { id = post.ID });

        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _post.Delete(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}