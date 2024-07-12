using MyBlog.IRepository;
using SqlSugar;

namespace MyBlog.Repository;

public class AuthorRepository: BaseRepository<Model.Author>, IAuthorRepository
{

}
