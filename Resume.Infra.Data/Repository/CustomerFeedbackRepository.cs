using Resume.Domain.Entity;
using Resume.Domain.IRepository.CustomerFeedback;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class CustomerFeedbackRepository : GenericRepository<CustomerFeedback>, ICustomerFeedbackRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public CustomerFeedbackRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion


}