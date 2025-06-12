using Microsoft.EntityFrameworkCore;
using Blog.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BlogContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Blog"],
        o => o.UseCompatibilityLevel(120));
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
