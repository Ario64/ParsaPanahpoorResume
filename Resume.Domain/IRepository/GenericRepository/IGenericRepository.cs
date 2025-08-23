using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.Domain.IRepository.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetAsync(ulong id);
    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}