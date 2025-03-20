using Linkedin_Automation.Database;
using Linkedin_Automation.DTOs;
using Linkedin_Automation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Linkedin_Automation.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class LinkedinAutomationController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LinkedinAutomationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("PostScrapping")]
        public async Task<IActionResult> Create(PostDetailsDto post)
        {
            var existingPost = await _context.PostDetails.FirstOrDefaultAsync(x => x.PostUrl == post.PostUrl);
            if (existingPost != null)
            {
                return NotFound("Post with the same URL already exists.");
            }

            var newPost = new PostDetails {
                PostUrl = post.PostUrl,
                LinkedinProfileName = post.LinkedinProfileName,
                Postcomment = post.Postcomment,
                Status = "pending"
            };

            _context.PostDetails.Add(newPost);
            await _context.SaveChangesAsync();

            return Ok(newPost);
        }

        [HttpGet("GetPost")]
        public async Task<IActionResult> GetAll()
        {
            var postDetails = await _context.PostDetails.Where(x=>x.Status !="done").ToListAsync();
            return Ok(postDetails);
        }

        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> Update(logsDto post)
        {
            var existingPost = await _context.PostDetails.FirstOrDefaultAsync(x => x.PostUrl == post.PostUrl);
            if (existingPost != null)
            {
                existingPost.Status = "done";
                await _context.SaveChangesAsync();
                return Ok("Status updated to 'done'");
            }
            return BadRequest("Post not found.");
        }
        [HttpDelete("DeleteData")]
        public async Task<IActionResult> Delete()
        {
            var allPosts = await _context.PostDetails.ToListAsync();

            if (allPosts.Count == 0)
            {
                return NotFound("No records found to delete.");
            }

            _context.PostDetails.RemoveRange(allPosts);
            await _context.SaveChangesAsync();

            return Ok("All records deleted successfully.");
        }

    }
}
