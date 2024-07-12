using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;

namespace BlogsPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleControlller : ControllerBase
{
    private IAuthorService _iAuthorService;
    public ArticleControlller(IAuthorService iAuthorService)
    {
        this._iAuthorService = iAuthorService;
    }

    [HttpGet("Articles")]
    public async Task<ActionResult> GetArticles(){
        var data = await _iAuthorService.QueryAllAsync();
        return Ok(data);
    }
}
