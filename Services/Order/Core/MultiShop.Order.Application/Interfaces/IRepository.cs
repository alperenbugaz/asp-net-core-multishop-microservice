using System.Linq.Expressions;

namespace MultiShop.Order.Core.Application.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
