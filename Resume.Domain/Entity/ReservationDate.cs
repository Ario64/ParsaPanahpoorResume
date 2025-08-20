using Resume.Domain.Entity.Common;
using Resume.Domain.Entity.Reservation;
using System;
using System.Collections.Generic;

namespace Resume.Domain.Entity;

public class ReservationDate : BaseEntity<ulong>
{
    public DateTime Date { get; set; }

    public virtual List<ReservationDateTime> ReservationDateTimes { get; set; } = new();
}
