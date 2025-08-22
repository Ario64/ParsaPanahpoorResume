using Resume.Domain.Entity.Reservation;
using Resume.Domain.IRepository.PersonSelectedReservation;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class PersonSelectedReservationRepository : GenericRepository<PersonSelectedReservation>, IPersonSelectedReservation
{
    #region ctor

    private readonly AppDbContext _context;

    public PersonSelectedReservationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}