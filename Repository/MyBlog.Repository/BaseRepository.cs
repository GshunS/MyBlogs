using System.Linq.Expressions;
using MyBlog.IRepository;
using MyBlog.Model;
using SqlSugar;

namespace MyBlog.Repository;

public class BaseRepository<T> : SimpleClient<T>, IBaseRepository<T> where T : class, new()
{
    public BaseRepository(ISqlSugarClient db)
    {
        base.Context=db;
        // create database
        db.DbMaintenance.CreateDatabase();
        // create tables
        db.CodeFirst.InitTables(
            typeof(Article),
            typeof(Author),
            typeof(Model.Type)
            );
    }
    public async Task<bool> CreateAsync(T entity)
    {
        return await base.InsertAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await base.DeleteByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        return await base.UpdateAsync(entity);
    }

    public async Task<T> FindAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    public async Task<List<T>> QueryAllAsync()
    {
        return await base.GetListAsync();
    }

    public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func)
    {
        return await base.GetListAsync(func);
    }

    public async Task<List<T>> QueryPagingAsync(int page, int size, RefAsync<int> total)
    {
        return await base.Context.Queryable<T>().ToPageListAsync(page, size, total);
    }

    public async Task<List<T>> QueryPagingAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
    {   
        return await base.Context.Queryable<T>()
        .Where(func)
        .ToPageListAsync(page, size, total);
    }

    
}