using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BlogController : ControllerBase
{
    private readonly ILogger<BlogController> _logger;

    public BlogController(ILogger<BlogController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Post")]
    public IActionResult GetPost()
    {
        return Ok("Nothing here!!!!!");
    }
}
