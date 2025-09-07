using Resume.Domain.IRepository.GenericRepository;
using Resume.Domain.IRepository.Portfolio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.UnitOfWork;

public interface IUnitOfWork :IDisposable
{
    IGenericRepository<T> GenericRepository<T>() where T : class;
    IPortfolioRepository PortfolioRepository { get; }
    void SaveChanges(); 
    Task SaveChangesAsync(CancellationToken cancellationToken);
}