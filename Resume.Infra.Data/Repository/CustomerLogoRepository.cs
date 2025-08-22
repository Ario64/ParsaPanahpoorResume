using Resume.Domain.Entity;
using Resume.Domain.IRepository.CustomerLogo;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class CustomerLogoRepository : GenericRepository<CustomerLogo>, ICustomerLogoRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public CustomerLogoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion


}