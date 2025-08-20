using System;
using Resume.Domain.Entity.Common;

namespace Resume.Domain.ViewModels.ReservationDate;

public class EditReservationDateViewModel : BaseEntity<ulong>
{
    public DateTime Date { get; set; }
}