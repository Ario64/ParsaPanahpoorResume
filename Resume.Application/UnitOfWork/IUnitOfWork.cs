using System;
using System.Threading.Tasks;
using Resume.Domain.IRepository.CustomerFeedback;
using Resume.Domain.IRepository.GenericRepository;

namespace Resume.Application.UnitOfWork;

public interface IUnitOfWork :IDisposable
{
    IGenericRepository<T> GenericRepository<T>() where T : class;
    void SaveChanges(); 
    Task SaveChangesAsync();
}