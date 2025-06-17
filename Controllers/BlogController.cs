using Blog.Models;
using Blog.DTOs;
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
            var post = _context.Database.SqlQuery<PostUser>(@$"
                SELECT Post.*, [User].[Name]
                FROM Post
                INNER JOIN [User]
                ON Post.UserId = [User].Id
                WHERE Post.Id = {id}
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

    [HttpPost("Post")]
    public IActionResult NewPost(Post post)
    {
        var newPost = new Post
        {
            Title = post.Title,
            IsPublished = post.IsPublished,
            Content = post.Content,
            UserId = 5,
            CreatedAt = DateTime.Now
        };

        _context.Add(newPost);
        _context.SaveChanges();

        /* var rows = _context.Database.ExecuteSql(@$"
            INSERT INTO Post (Content, Title, UserId)
            VALUES ({post.Title}, {post.Content})
        "); */

        return Ok(newPost);
    }

    [HttpPut("Post")]
    public IActionResult UpdatePost(Post post)
    {
        try
        {
            var oldPost = _context.Posts.Single(p => p.Id == post.Id);

            oldPost.Title = post.Title;
            oldPost.Content = post.Content;
            oldPost.IsPublished = post.IsPublished;
            oldPost.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return Ok(oldPost);
        }
        catch (Exception)
        {
            return NotFound($"Could not find post #{post.Id}.");
        }
    }

    [HttpDelete("Post")]
    public IActionResult DeletePost(int id)
    {
        var rows = _context.Database.ExecuteSql(@$"
            DELETE FROM Post
            WHERE Id = {id}
        ");

        if (rows > 0)
            return Ok();
        else
            return NotFound($"Post #{id} was not found.");
    }
}
