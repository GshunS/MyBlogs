using BlogsPlatform.Utils.ApiResult;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using MyBlog.Model.DTO;

namespace BlogsPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ArticleController : ControllerBase
{
    private IArticleService _iArticleService;
    public ArticleController(IArticleService iArticleService)
    {
        this._iArticleService = iArticleService;
    }

    [HttpGet("Articles")]
    public async Task<ActionResult<ApiResult>> GetArticles([FromServices] IMapper iMapper)
    {
        int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
        var data = await _iArticleService.QueryAsync(c => c.AuthorId == id);
        if (data == null)
        {
            return ApiResultHelper.Error("No Results");
        }
        
        List<ArticleDTO> articleList = new();
        foreach(Article a in data){
            ArticleDTO articleDTO = iMapper.Map<ArticleDTO>(a);
            articleList.Add(articleDTO);
        }

        return ApiResultHelper.Success(articleList);

    }
    [HttpPost("Create")]
    public async Task<ActionResult<ApiResult>> CreateArticle(string title, string content, int typeId)
    {
        Article a = new Article
        {
            Title = title,
            Content = content,
            ArticleType = typeId,
            AuthorId = Convert.ToInt32(this.User.FindFirst("Id").Value),
            createdTime = DateTime.Now,
            LikeCount = 0,
            ViewAmount = 0
        };
        bool res = await _iArticleService.CreateAsync(a);
        if (!res)
        {
            return ApiResultHelper.Error("create failure, server error");
        }
        return ApiResultHelper.Success(a);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResult>> DeleteArticle(int id)
    {
        bool res = await _iArticleService.DeleteAsync(id);
        if (!res)
        {
            return ApiResultHelper.Error("delete failure, server error");
        }
        return ApiResultHelper.Success(res);
    }

    [HttpPut("Edit")]
    public async Task<ActionResult<ApiResult>> EditArticle(int id, string title, string content, int typeId)
    {
        var article = await _iArticleService.FindAsync(id);
        if (article == null)
        {
            return ApiResultHelper.Error("The Article doesn't exist");
        }


        article.Title = title;
        article.Content = content;
        article.ArticleType = typeId;

        bool res = await _iArticleService.EditAsync(article);
        if (!res)
        {
            return ApiResultHelper.Error("update failure, server error");
        }
        return ApiResultHelper.Success(article);
    }
}
