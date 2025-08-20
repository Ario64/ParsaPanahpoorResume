using Resume.Domain.Entity.Common;
using Resume.Domain.Entity.Reservation;
using System.Collections.Generic;

namespace Resume.Domain.Entity;

public class ReservationDateTime : BaseEntity<ulong>
{
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public bool IsReserved { get; set; }

    public ulong ReservationDateId { get; set; }
    public virtual ReservationDate ReservationDate { get; set; }

    public virtual List<PersonSelectedReservation> PeopleSelectedReservations { get; set; }
}
