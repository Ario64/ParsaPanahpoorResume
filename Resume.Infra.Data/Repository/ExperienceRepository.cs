using Resume.Domain.Entity;
using Resume.Domain.IRepository.Experience;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class ExperienceRepository : GenericRepository<Experience>, IExperienceRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public ExperienceRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}
