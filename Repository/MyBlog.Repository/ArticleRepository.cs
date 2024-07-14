using System.Linq.Expressions;
using MyBlog.IRepository;
using MyBlog.Model;
using SqlSugar;

namespace MyBlog.Repository;

public class ArticleRepository : BaseRepository<Article>, IArticleRepository
{
    public override async Task<List<Article>> QueryAllAsync()
    {
        return await base.Context.Queryable<Article>()
        .Mapper(c => c.TypeID, c => c.ArticleType, c => c.TypeID.Id)
        .Mapper(c => c.NewAuthorID, c => c.AuthorId, c => c.NewAuthorID.Id)
        .ToListAsync();
    }

    public override async Task<List<Article>> QueryAsync(Expression<Func<Article, bool>> func)
    {
        return await base.Context.Queryable<Article>()
        .Where(func)
        .Mapper(c => c.TypeID, c => c.ArticleType, c => c.TypeID.Id)
        .Mapper(c => c.NewAuthorID, c => c.AuthorId, c => c.NewAuthorID.Id)
        .ToListAsync();
    }

    public override async Task<List<Article>> QueryPagingAsync(Expression<Func<Article, bool>> func, int page, int size, RefAsync<int> total)
    {
        return await base.Context.Queryable<Article>()
        .Where(func)
        .Mapper(c => c.TypeID, c => c.ArticleType, c => c.TypeID.Id)
        .Mapper(c => c.NewAuthorID, c => c.AuthorId, c => c.NewAuthorID.Id)
        .ToPageListAsync(page, size, total);
    }
}
