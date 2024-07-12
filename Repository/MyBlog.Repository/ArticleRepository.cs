using MyBlog.IRepository;
using MyBlog.Model;
using SqlSugar;

namespace MyBlog.Repository;

public class ArticleRepository : BaseRepository<Article>, IArticleRepository
{
    

}
