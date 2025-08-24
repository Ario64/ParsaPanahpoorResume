using Resume.Domain.Entity.Reservation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Resume.Domain.Repository;

public interface IReservationRepository
{
    Task<List<ReservationDate>> GetListOfReservations(
        CancellationToken cancellationToken);

    Task<ReservationDate> Get(ulong reservationDateId,
        CancellationToken cancellationToken);

    Task<ReservationDate> AddAsync(ReservationDate reservationDate,
        CancellationToken cancellationToken);

    public void Update(
        ReservationDate reservationDate);
}
