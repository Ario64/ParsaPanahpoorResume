using System;
using Resume.Domain.Entity.Common;

namespace Resume.Domain.ViewModels.ReservationDate;

public class EditReservationDateViewModel : BaseEntity<long>
{
    public DateTime Date { get; set; }
}