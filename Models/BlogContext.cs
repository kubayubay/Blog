using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<User> Users { get; set; }
}
