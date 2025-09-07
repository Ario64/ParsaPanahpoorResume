using Resume.Domain.IRepository.GenericRepository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Domain.IRepository.Portfolio;

public interface IPortfolioRepository : IGenericRepository<Entity.Portfolio>
{
    Task<IReadOnlyList<Resume.Domain.Entity.Portfolio>> GatAllPortfolioAsync(CancellationToken cancellationToken);
}