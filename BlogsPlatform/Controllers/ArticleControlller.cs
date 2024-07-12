using BlogsPlatform.Utils.ApiResult;
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
    public async Task<ActionResult<ApiResult>> GetArticles(){
        var data = await _iAuthorService.QueryAllAsync();
        if (data == null)
        {
            return ApiResultHelper.Error("No Results");
        }
        else
        {
            return ApiResultHelper.Success(data);
        }
        
    }
}
