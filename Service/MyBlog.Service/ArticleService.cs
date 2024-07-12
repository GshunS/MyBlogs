using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model;

namespace MyBlog.Service;

public class ArticleService:BaseService<Article>, IArticleService
{
    private readonly IArticleRepository _iArticleRepository;
    public ArticleService(IArticleRepository iArticleRepository)
    {
        base._IBaseRepository = iArticleRepository;
        _iArticleRepository = iArticleRepository;
    }
}
