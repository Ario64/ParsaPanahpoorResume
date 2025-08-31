using Resume.Domain.ViewModels.Common;
using System;

namespace Resume.Domain.ViewModels.ReservationDate;

public class ReservationDateViewModel : BaseViewModel<long>
{
    public DateTime Date { get; set; }
}