using System.Net;
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

    [HttpGet("{image}")]
    public IActionResult GetImage(string image)
    {
        string fileName = image.Split('/').Last().ToLower();
        var filePath = Path.Combine(_env.ContentRootPath, "Assets", "Images", fileName);
        return PhysicalFile(filePath, "image/jpeg");
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
