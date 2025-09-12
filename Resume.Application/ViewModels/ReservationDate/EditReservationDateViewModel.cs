using Resume.Application.ViewModels.Common;
using System;

namespace Resume.Application.ViewModels.ReservationDate;

public class EditReservationDateViewModel : BaseViewModel<long>
{
    public DateTime Date { get; set; }
}