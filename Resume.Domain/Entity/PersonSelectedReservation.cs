﻿using Resume.Domain.Entity.Common;

namespace Resume.Domain.Entity.Reservation;

public class PersonSelectedReservation : BaseEntity<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }

    public ulong ReservationDateTimeId { get; set; }
    public virtual ReservationDateTime ReservationDateTime { get; set; }
}
