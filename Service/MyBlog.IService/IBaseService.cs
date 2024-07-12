using System.Linq.Expressions;
using SqlSugar;

namespace MyBlog.IService;

public interface IBaseService<T> where T:class, new()
{
    Task<bool> CreateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> EditAsync(T entity);
    Task<T> FindAsync(int id);

    // query all records
    Task<List<T>> QueryAllAsync();

    // query with conditions
    Task<List<T>> QueryAsync(Expression<Func<T, bool>> func);

    // paging querying
    Task<List<T>> QueryPagingAsync(int page, int size, RefAsync<int> total);

    // paging querying with conditions
    Task<List<T>> QueryPagingAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total);
}
