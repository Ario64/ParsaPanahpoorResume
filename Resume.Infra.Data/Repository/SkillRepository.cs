using Resume.Domain.IRepository.Skill;
using Resume.Domain.Models;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class SkillRepository : GenericRepository<Skill>, ISkillRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public SkillRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}