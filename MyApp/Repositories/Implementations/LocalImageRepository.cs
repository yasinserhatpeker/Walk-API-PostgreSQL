using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models.Entities;
using MyApp.Repositories.Interfaces;

namespace MyApp.Repositories.Implementations;

public class LocalImageRepository : IImageRepository

{

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly NZWalkDbContext _dbContext;

    public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalkDbContext dbContext)
    {
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }
   
    public async Task<Image> Upload(Image image)
    {
        var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", image.FileName, image.FileExtension);
        // Upload image to localpath

        using var stream = new FileStream(localFilePath, FileMode.Create);
        await image.File.CopyToAsync(stream);


        // https://localhost:1234/images/images.jpg

        var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

        image.FilePath = urlFilePath;

        // add images to dbContext
        await _dbContext.Images.AddAsync(image);
        await _dbContext.SaveChangesAsync();

        return image;
       
        
    }
}
