using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models;

[Table("Post")]
public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; } = "";
    [StringLength(200)]
    public string Title { get; set; } = "";
    public bool IsPublished { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
