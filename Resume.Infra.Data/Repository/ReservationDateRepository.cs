using Resume.Domain.Entity;
using Resume.Domain.IRepository.ReservationDate;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class ReservationDateRepository : GenericRepository<ReservationDate>, IReservationDateRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public ReservationDateRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}