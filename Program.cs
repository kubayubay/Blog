using Microsoft.EntityFrameworkCore;
using Blog.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BlogContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Blog"],
        o => o.UseCompatibilityLevel(120));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
