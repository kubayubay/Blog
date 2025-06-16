using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BlogController : ControllerBase
{
    private readonly ILogger<BlogController> _logger;
    private readonly BlogContext _context;

    public BlogController(ILogger<BlogController> logger, BlogContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("Post")]
    public IActionResult GetPost(int id)
    {
        try
        {
            var post = _context.Database.SqlQuery<Post>(@$"
                SELECT *
                FROM Post
                WHERE Id = {id}
            ").Single();

            return Ok(post);
        }
        catch (Exception)
        {
            return NotFound($"Could not find post #{id}.");
        }

        // var post = _context.Posts.Single(p => p.Id == id);
    }

    [HttpGet("Posts")]
    public IActionResult GetPosts()
    {
        var posts = _context.Database.SqlQuery<Post>(@$"
            SELECT *
            FROM Post
        ");

        return Ok(posts);
    }
}
