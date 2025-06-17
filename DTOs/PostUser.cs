using Blog.Models;

namespace Blog.DTOs;

public class PostUser : Post
{
    public string Name { get; set; } = "";
}