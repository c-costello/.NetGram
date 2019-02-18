using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetGram.Models;
using DotNetGram.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DotNetGram.Pages.Posts
{
    public class ManageModel : PageModel
    {
        private readonly IPost _post;

        //Properties
        public Models.Util.Blob BlobImg { get; set; }
        [FromRoute]
        public int? ID { get; set; }
        [BindProperty]
        public Post Post { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="post">IPost</param>
        /// <param name="configuration">IConfiguration</param>
        public ManageModel(IPost post, IConfiguration configuration)
        {
            _post = post;
            //Blob Storage account to be refferenced
            BlobImg = new Models.Util.Blob(configuration);
        }

        /// <summary>
        /// On get, find post by ID, or create new post
        /// </summary>
        /// <returns>Task</returns>
        public async Task OnGet()
        {
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
        }

        /// <summary>
        /// On post, Save Post Async
        /// </summary>
        /// <returns>Task IActionResult</returns>
        public async Task<IActionResult> OnPost()
        {
            var post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();

            post.ID = Post.ID;
            post.Author = Post.Author;
            post.Description = Post.Description;

            if  (Image != null)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    //copy image to file path
                    await Image.CopyToAsync(stream);
                }
                //Get container
                var container = await BlobImg.GetContainer("images");
                //upload image
                await BlobImg.UploadImage(container, Image.FileName, filePath);

                CloudBlob blob = await BlobImg.GetBlob(Image.FileName, container.Name);

                post.Image = blob.Uri.ToString();

            }
            await _post.SaveAsync(post);


            return RedirectToPage("/Posts/Index", new { id = post.ID });

        }

        /// <summary>
        /// Delete post
        /// </summary>
        /// <returns>Task IActionResult</returns>
        public async Task<IActionResult> OnPostDelete()
        {
            await _post.Delete(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}