using Microsoft.AspNetCore.Mvc;

namespace BlazorMercadoPagoDemo.Controllers;

[Route("api/notifications")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public NotificationController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpPost]
    public IActionResult PutNotify()
    {
        var strBody = new StreamReader(Request.Body).ReadToEnd();
        var path = Path.Combine(_env.WebRootPath, "files", "notify.txt");
        using var objwrt = new StreamWriter(path, true);
        objwrt.Write(strBody);
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpGet]
    public IActionResult GetNotify()
    {
        var path = Path.Combine(_env.WebRootPath, "files", "notify.txt");
        var objfile = new FileInfo(path);
        string strBody = string.Empty;
        if (objfile.Exists)
        {
            using var objRdr = new StreamReader(path);
            strBody = objRdr.ReadToEnd();
        }
        else
        {
            return Ok("No data");
        }
        return Ok(strBody);
    }
}