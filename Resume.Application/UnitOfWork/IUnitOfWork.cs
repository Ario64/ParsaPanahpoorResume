using Resume.Domain.IRepository.CustomerFeedback;
using Resume.Domain.IRepository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.UnitOfWork;

public interface IUnitOfWork :IDisposable
{
    IGenericRepository<T> GenericRepository<T>() where T : class;
    void SaveChanges(); 
    Task SaveChangesAsync(CancellationToken cancellationToken);
}