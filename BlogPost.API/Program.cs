using BlogPost.API.Repository.Implementation;
using BlogPost.API.Repository.Interface;
using BlogPostSystem;  
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogPostDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogPostConnectionStrings")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Added Repository 
builder.Services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();

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
