using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region ctor

    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Get All Async

    public IQueryable<T> GetAll(CancellationToken cancellationToken = default)
    {
        var entityList = _context.Set<T>().AsNoTracking();
        return entityList;
    }

    #endregion

    #region GetAsync

    public async Task<T> GetAsync(object id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<T>().FindAsync(id, cancellationToken);
        return entity;
    }
  
    #endregion

    #region AddAsync

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    #endregion

    #region Update

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    #endregion

    #region Delete

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    #endregion

}