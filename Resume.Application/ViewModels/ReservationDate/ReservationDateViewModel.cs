using Resume.Application.ViewModels.Common;
using Resume.Application.ViewModels.ReservationDate;
using System;

namespace Resume.Domain.ViewModels.ReservationDate;

public class ReservationDateViewModel : BaseViewModel<long>, IReservationDateViewModel
{
    public DateTime Date { get; set; }
}