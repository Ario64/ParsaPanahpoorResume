using Microsoft.EntityFrameworkCore;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

    #region Is Exist

    public async Task<bool> IsExist(long key, CancellationToken cancellationToken = default)
    {
        var entityType = _context.Model.FindEntityType(typeof(T));
        var keyProperty = entityType.FindPrimaryKey().Properties.First();
        var keyName = keyProperty.Name;
        return await _context.Set<T>().AnyAsync(k => EF.Property<long>(k, keyName) == key, cancellationToken);
    }

    #endregion
}