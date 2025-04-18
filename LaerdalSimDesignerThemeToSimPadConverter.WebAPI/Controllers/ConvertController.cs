using Microsoft.AspNetCore.Mvc;

namespace LaerdalSimDesignerThemeToSimPadConverter.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConvertController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ConvertSimDesignerToSimPadTheme(
        [FromServices] ThxToThmConverter converter)
    {
        var filename = Request.Headers.FirstOrDefault(x => x.Key.ToLower() == "x-filename").Value.ToString();
        string themeName;
        if (!string.IsNullOrWhiteSpace(filename))
        {
            var extension = Path.GetExtension(filename);
            if (extension.ToLower() != ".thx")
                return BadRequest("This doesn't seem to be a SimDesigner theme file. It should have a .thx-ending");
            themeName = Path.GetFileNameWithoutExtension(filename);
        }
        else
        {
            themeName = "SimPadTheme";
        }

        var outputFileName = $"{themeName}.thm";
        using var inputStream = new MemoryStream();
        await Request.Body.CopyToAsync(inputStream);
        try
        {
            var outputStream = converter.ConvertAndWrite(inputStream, themeName);
            return File(outputStream, "application/octet-stream", outputFileName);
        }
        catch (Exception)
        {
            return BadRequest("Invalid .thx file or bug in converter");
        }
    }

}