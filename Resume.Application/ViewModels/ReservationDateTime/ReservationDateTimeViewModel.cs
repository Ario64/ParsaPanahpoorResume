using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.ReservationDateTime;

public class ReservationDateTimeViewModel : BaseViewModel<long>, IReservationDateTimeViewModel
{
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public bool IsReserved { get; set; }
    public long ReservationDateId { get; set; }
}