using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IWebHostEnvironment _env;
    public ImageController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet]
    public IActionResult GetNoImage()
    {
        string filePath = Path.Combine(_env.ContentRootPath, "Assets", "Images", "Image_Not_Found.png");
        var png = PhysicalFile(filePath, "image/png");
        return png;
    }

    [HttpGet("listing")]
    public IActionResult GetAllImagePaths()
    {
        var path = Path.Combine(_env.ContentRootPath, "Assets", "Images");
        string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Split('/').Last();
        }
        return Ok(files);
    }

    [HttpGet("{image}")]
    public IActionResult GetImage(string image)
    {
        string fileName = image.Split('/').Last().ToLower();
        string filePath = Path.Combine(_env.ContentRootPath, "Assets", "Images", fileName);
        if (System.IO.File.Exists(filePath))
        {
            var png = PhysicalFile(filePath, "image/png");
            return png;
        }
        else
        {
            filePath = Path.Combine(_env.ContentRootPath, "Assets", "Images", "Image_Not_Found.png");
            var png = PhysicalFile(filePath, "image/png");
            return png;
        }

    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public async Task<IActionResult> UploadImage(IFormFile imageFile)
    {
        try
        {
            var imageFolder = Path.Combine(_env.ContentRootPath, "Assets", "Images");
            if (imageFile.Length > 0)
            {
                string fileName = imageFile.FileName.Split('/').Last().ToLower();
                string ext = Path.GetExtension(fileName);
                string[] allowed = [".jpg", ".jpeg", ".png", ".webp"];
                if (!allowed.Contains(ext))
                {
                    return BadRequest("Incorrect file type");
                }
                string imagePath = Path.Combine(imageFolder, fileName);

                using (Stream fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
            }
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("Image was not uploaded. Try again with a different file name.");
        }

    }
}
