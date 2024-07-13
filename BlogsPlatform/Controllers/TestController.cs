using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogsPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("NoAuthorize")]
    public string NoAuthorize()
    {
        return "NoAuthorize";
    }
    [Authorize]
    [HttpGet("Authorize")]
    public string Authorize()
    {
        return "Authorize";
    }
}
