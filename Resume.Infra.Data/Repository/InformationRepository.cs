using Resume.Domain.IRepository.Information;
using Resume.Domain.Models;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class InformationRepository : GenericRepository<Information>, IInformationRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public InformationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}