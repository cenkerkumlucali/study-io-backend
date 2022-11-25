namespace Application.Repositories.Services;

public interface IRedisRepository<T>
{
    Task<T> GetAsync(string id);
    
    Task<T> UpdateAsync(T entity);

    Task<bool> DeleteAsync(string id);
}