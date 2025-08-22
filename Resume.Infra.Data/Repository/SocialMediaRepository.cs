using Resume.Domain.Entity;
using Resume.Domain.IRepository.SocialMedia;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public SocialMediaRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion


}