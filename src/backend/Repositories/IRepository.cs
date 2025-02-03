
// Repositories/IRepository.cs

namespace whoknows_c_sharp.Repositories;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync<TId>(TId id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}