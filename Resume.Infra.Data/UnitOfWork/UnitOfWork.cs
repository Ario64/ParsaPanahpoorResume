using Resume.Application.UnitOfWork;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Infra.Data.Context;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Resume.Infra.Data.Repository;

namespace Resume.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    #region ctor

    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    #endregion

    private readonly ConcurrentDictionary<Type, object> _repositories = new();

    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        return (IGenericRepository<T>)_repositories.GetOrAdd(typeof(T), _= new GenericRepository<T>(_context));
    }

    #region Save Changes

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    #endregion

    #region Dispose

    public void Dispose()
    {
        _context.Dispose();
    }

    #endregion
}