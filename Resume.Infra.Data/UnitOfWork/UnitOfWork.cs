using Resume.Application.Interface;
using Resume.Application.Interfaces;
using Resume.Application.UnitOfWork;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Domain.IRepository.Portfolio;
using Resume.Infra.Data.Context;
using Resume.Infra.Data.Repository;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

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

    //generic repository
    private readonly ConcurrentDictionary<Type, object> _repositories = new();
    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        return (IGenericRepository<T>)_repositories.GetOrAdd(typeof(T), _ = new GenericRepository<T>(_context));
    }

    //portfolio repository
    private IPortfolioRepository _portfolioRepository;
    public IPortfolioRepository PortfolioRepository
    {
        get
        {
            if (_portfolioRepository == null)
            {
                _portfolioRepository = new PortfolioRepository(_context);
            }
            return _portfolioRepository;
        }
    }

    //education repository with partitioning
    private IEducationReadRepository _educationReadRepository;
    public IEducationReadRepository EducationReadRepository
    {
        get
        {
            if (_educationReadRepository == null)
            {
                _educationReadRepository = new EducationReadRepository(_context);
            }

            return _educationReadRepository;
        }
    }

    //message repository with partitioning
    private IMessageReadRepository _messageReadRepository;
    public IMessageReadRepository MessageReadRepository 
        => _messageReadRepository ??= new MessageReadRepository(_context);

    #region Save Changes

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Dispose

    public void Dispose()
    {
        _context.Dispose();
    }

    #endregion

}