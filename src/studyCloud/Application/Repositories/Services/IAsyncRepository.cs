using System.Linq.Expressions;
using Application.Abstractions.Services.Paging;
using Application.Persistence.Dynamic;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Repositories.Services;

public interface IAsyncRepository<T> : IQuery<T> where T : BaseEntity
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0, int size = 10, bool enableTracking = true,
        CancellationToken cancellationToken = default);

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0, int size = 10, bool enableTracking = true,
        CancellationToken cancellationToken = default);

    Task<IPaginate<T>> GetListByDynamicAsync(Dynamic dynamic,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0, int size = 10, bool enableTracking = true,
        CancellationToken cancellationToken = default);

    Task<T> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<bool> DeleteRangeAsync(IList<T> entities);
}