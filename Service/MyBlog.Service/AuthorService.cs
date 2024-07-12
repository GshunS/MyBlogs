using MyBlog.IService;
using MyBlog.Model;
using MyBlog.IRepository;

namespace MyBlog.Service;

public class AuthorService:BaseService<Author>, IAuthorService
{
    private readonly IAuthorRepository _iAuthorRepository;
    public AuthorService(IAuthorRepository iAuthorRepository)
    {
        base._IBaseRepository = iAuthorRepository;
        _iAuthorRepository = iAuthorRepository;
    }
}
