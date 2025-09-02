using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Domain.IRepository.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    Task<PagedResult<T>> GetAllPagedAsync(int page , int pageSize , CancellationToken cancellationToken = default);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> GetAsync(object id, CancellationToken cancellationToken = default);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}