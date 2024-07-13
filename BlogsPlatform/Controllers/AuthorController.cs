using BlogsPlatform.Utils._MD5;
using BlogsPlatform.Utils.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;

namespace BlogsPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _iAuthorService;
    public AuthorController(IAuthorService iAuthorService)
    {
        this._iAuthorService = iAuthorService;

    }

    [HttpGet("Author")]
    public async Task<ActionResult<ApiResult>> GetAuthor()
    {
        var authors = await _iAuthorService.QueryAllAsync();
        if (authors.Count == 0)
        {
            return ApiResultHelper.Error("No Result");
        }
        return ApiResultHelper.Success(authors);
    }

    [HttpPost("CreateAuthor")]
    public async Task<ActionResult<ApiResult>> CreateAuthor(string name, string accountNumber, string password)
    {
        var res = await _iAuthorService.FindAsync(c => c.AccountNumber == accountNumber);
        if (res != null)
        {
            return ApiResultHelper.Error("user already existed");
        }
        Author author = new Author
        {
            Name = name,
            AccountNumber = accountNumber,
            // Encrypt password
            Password = MD5Helper.MD5Encrypt32(password)
        };
        var status = await _iAuthorService.CreateAsync(author);
        if (!status)
        {
            return ApiResultHelper.Error("Create failure");
        }
        return ApiResultHelper.Success(author);
    }

    // [HttpDelete("DeleteAuthor")]
    // public async Task<ActionResult<ApiResult>> DeleteAuthor(int id)
    // {
    //     var res = await _iAuthorService.DeleteAsync(id);
    //     if(!res){
    //         return ApiResultHelper.Error("Delete Failure");
    //     }
    //     return ApiResultHelper.Success(res);
    // }

    // [HttpPut("Update")]
    // public async Task<ActionResult<ApiResult>> UpdateAuthorName(string name){
    //     int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
    //     return ApiResultHelper.Error("-------------");
    // }
}
