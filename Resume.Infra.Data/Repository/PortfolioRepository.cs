using Microsoft.EntityFrameworkCore;
using Resume.Domain.Entity;
using Resume.Domain.IRepository.Portfolio;
using Resume.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository;

public class PortfolioRepository : GenericRepository<Portfolio> , IPortfolioRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public PortfolioRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public async Task<IReadOnlyList<Portfolio>> GatAllPortfolioAsync(CancellationToken cancellationToken)
    {
       var portfolios = await  _context.Portfolios.Include(i=>i.PortfolioCategory)
                                                  .ToListAsync();
        return portfolios;
    }


}