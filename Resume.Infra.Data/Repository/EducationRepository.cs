using Resume.Domain.IRepository.Education;
using Resume.Domain.Entity;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class EducationRepository : GenericRepository<Education>, IEducationRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public EducationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}