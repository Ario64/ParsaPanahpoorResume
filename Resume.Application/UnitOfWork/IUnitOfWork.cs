using Resume.Application.Interface;
using Resume.Application.Interfaces;
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
    IEducationReadRepository EducationReadRepository { get; }
    IMessageReadRepository MessageReadRepository { get; }
    void SaveChanges(); 
    Task SaveChangesAsync(CancellationToken cancellationToken);
}