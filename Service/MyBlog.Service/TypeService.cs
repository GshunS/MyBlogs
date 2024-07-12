using MyBlog.IService;
using MyBlog.IRepository;
namespace MyBlog.Service;

public class TypeService:BaseService<Model.Type>, ITypeService
{
    private readonly ITypeRepository _iTypeRepository;
    public TypeService(ITypeRepository iTypeRepository)
    {
        base._IBaseRepository = iTypeRepository;
        _iTypeRepository = iTypeRepository;
    }
}
