using System.Linq.Expressions;
using MyBlog.IRepository;
using MyBlog.IService;
using SqlSugar;

namespace MyBlog.Service;

public class BaseService<T> : IBaseService<T> where T : class, new()
{
    protected IBaseRepository<T> _IBaseRepository;
    public async Task<bool> CreateAsync(T entity)
    {
        return await _IBaseRepository.CreateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _IBaseRepository.DeleteAsync(id);
    }

    public async Task<bool> EditAsync(T entity)
    {
        return await _IBaseRepository.EditAsync(entity);
    }

    public async Task<T> FindAsync(int id)
    {
        return await _IBaseRepository.FindAsync(id);
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> func)
    {
        return await _IBaseRepository.FindAsync(func);
    }


    public async Task<List<T>> QueryAllAsync()
    {
        return await _IBaseRepository.QueryAllAsync();
    }

    public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func)
    {
        return await _IBaseRepository.QueryAsync(func);
    }

    public async Task<List<T>> QueryPagingAsync(int page, int size, RefAsync<int> total)
    {
        return await _IBaseRepository.QueryPagingAsync(page, size, total);
    }

    public async Task<List<T>> QueryPagingAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
    {
        return await _IBaseRepository.QueryPagingAsync(func, page, size, total);
    }

    

}
