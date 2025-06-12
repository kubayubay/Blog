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

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
