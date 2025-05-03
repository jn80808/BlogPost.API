using BlogPost.API.Data;
using BlogPost.API.Repositories;
using BlogPost.API.Repository.Implementation;
using BlogPost.API.Repository.Interface;
using BlogPostSystem;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogPostDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("BlogPostConnectionStrings")));

builder.Services.AddDbContext<AuthDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("BlogPostConnectionStrings")));



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

//Added Repository 
builder.Services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();


builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("beantea")
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();



//Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});

app.MapControllers();
app.Run();
