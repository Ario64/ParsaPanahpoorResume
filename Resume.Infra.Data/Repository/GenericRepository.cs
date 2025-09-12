using Microsoft.EntityFrameworkCore;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        return entities;
    }

    #endregion

    #region First or default

    public async Task<T> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(cancellationToken);
    }

    #endregion

    #region GetAsync

    public async Task<T> GetAsync(object id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<T>().FindAsync(id, cancellationToken);
        return entity;
    }

    #endregion

    #region Add

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
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