using Resume.Domain.Entity;
using Resume.Domain.IRepository.ThingIDo;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class ThingIDoRepository : GenericRepository<ThingIDo>, IThingIDoRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public ThingIDoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}