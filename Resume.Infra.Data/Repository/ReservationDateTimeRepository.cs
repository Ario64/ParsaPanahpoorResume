using Resume.Domain.Entity;
using Resume.Domain.IRepository.ReservationDateTime;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class ReservationDateTimeRepository :GenericRepository<ReservationDateTime>, IReservationDateTimeRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public ReservationDateTimeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}