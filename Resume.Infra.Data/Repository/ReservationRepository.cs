using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Repository;
using Resume.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository;

public class ReservationRepository : IReservationRepository
{
    #region Ctor

    private readonly AppDbContext _context;

    public ReservationRepository(AppDbContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<List<ReservationDate>> GetListOfReservations(CancellationToken cancellationToken)
        => await _context.ReservationDates
                         .Where(p=> !p.IsDelete)
                         .OrderByDescending(p=> p.CreateDate)
                         .ToListAsync();

    public async Task<ReservationDate> GetReservationDate(ulong reservationDateId,
        CancellationToken cancellationToken)
        => await _context.ReservationDates.FindAsync(reservationDateId , cancellationToken);

    public async Task AddReservationDate(ReservationDate reservationDate,
        CancellationToken cancellationToken)
        => await _context.ReservationDates.AddAsync(reservationDate);

    public void Update(ReservationDate reservationDate)
        => _context.ReservationDates.Update(reservationDate);

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
