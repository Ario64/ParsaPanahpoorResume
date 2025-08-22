using Resume.Domain.IRepository.Portfolio;
using Resume.Domain.Models;
using Resume.Infra.Data.Context;

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


}