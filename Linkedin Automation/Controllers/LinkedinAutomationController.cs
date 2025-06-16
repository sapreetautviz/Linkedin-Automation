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

        [HttpPost("insertPostUrlOrComment")]
        public async Task<IActionResult> Create(PostRequestDto post)
        {
            var postUrl = await _context.PostRequests.FirstOrDefaultAsync(x=>x.PostUrl == post.PostUrl);

            if (postUrl != null)
            {
                return NotFound("Post with the same URL already exists.");
            }

            var newPost = new PostRequest
            {
                PostUrl = post.PostUrl,
                PostComment = post.PostComment,
                Status = "done"
            };

            _context.PostRequests.Add(newPost);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetPostUrlOrComment")]
        public async Task<IActionResult> GetAllPost()
        {
            var postDetails = await _context.PostRequests.ToListAsync();
            if (postDetails.Count == 0)
            {
                return NotFound("No records PostUrl Or Comments");
            }

            var response = postDetails.Select(post => new PostResponseDto
            {
                PostUrl = post.PostUrl
            }).ToList();

            return Ok(response);
        }

        [HttpPost("Insert-keyword")]
        public async Task<IActionResult> Insert(KeywordDto keyword)
        {
            var postKeyword = await _context.PostKeywords.FirstOrDefaultAsync(x=>x.Keyword == keyword.Keyword);

            if (postKeyword != null)
            {
                return NotFound("Keyword already exists.");
            }

            var newKeyword = new PostKeyword
            { 
                Keyword = keyword.Keyword,
                limit = keyword.Limit
            };
            await _context.AddAsync(newKeyword);
            await _context.SaveChangesAsync();
            return Ok(newKeyword);
        }

        [HttpGet("Get-Keyword")]
        public async Task<IActionResult> GetKeyword()
        {
            var keyword = await _context.PostKeywords.ToListAsync();
            if (keyword == null)
            {
                return NotFound("No records Keyword");
            }
            var response = keyword.Select(key => new KeywordDto
            {
                Keyword = key.Keyword,
                Limit = key.limit
            }).ToList();
            return Ok(response);
        }

        [HttpDelete("Delete-keyword")]
        public async Task<IActionResult> DeleteKeyword()
        {
            var allKeyword = await _context.PostKeywords.ToListAsync();

            if (allKeyword.Count == 0)
            {
                return NotFound("No records found to delete.");
            }

            _context.PostKeywords.RemoveRange(allKeyword);
            await _context.SaveChangesAsync();

            return Ok("All records deleted successfully.");
        }
    }
}
