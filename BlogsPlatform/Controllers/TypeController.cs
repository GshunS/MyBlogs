using BlogsPlatform.Utils.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;

namespace BlogsPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TypeController : ControllerBase
{
    private readonly ITypeService _iTypeService;
    public TypeController(ITypeService iTypeService)
    {
        this._iTypeService = iTypeService;
    }

    [HttpGet("Type")]
    public async Task<ActionResult<ApiResult>> GetTypes()
    {
        var data = await _iTypeService.QueryAllAsync();
        if (data.Count == 0)
        {
            return ApiResultHelper.Error("No Results");
        }
        else
        {
            return ApiResultHelper.Success(data);
        }

    }
    [HttpPost("Create")]
    public async Task<ActionResult<ApiResult>> CreateType(string name)
    {
        MyBlog.Model.Type a = new MyBlog.Model.Type
        {
            Name = name
        };

        bool res = await _iTypeService.CreateAsync(a);
        if (!res)
        {
            return ApiResultHelper.Error("create failure, server error");
        }
        return ApiResultHelper.Success(a);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResult>> DeleteType(int id)
    {
        bool res = await _iTypeService.DeleteAsync(id);
        if (!res)
        {
            return ApiResultHelper.Error("delete failure, server error");
        }
        return ApiResultHelper.Success(res);
    }

    [HttpPut("Edit")]
    public async Task<ActionResult<ApiResult>> EditType(int id, string name)
    {
        var articleType = await _iTypeService.FindAsync(id);
        if (articleType == null)
        {
            return ApiResultHelper.Error("The Type doesn't exist");
        }

        articleType.Name = name;

        bool res = await _iTypeService.EditAsync(articleType);
        if (!res)
        {
            return ApiResultHelper.Error("update failure, server error");
        }
        return ApiResultHelper.Success(articleType);
    }


}
