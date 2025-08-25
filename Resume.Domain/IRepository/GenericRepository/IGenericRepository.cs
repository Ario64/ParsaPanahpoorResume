using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Domain.IRepository.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll(CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> GetAsync(object id, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
}