using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.ReservationDateTime;

public class EditReservationDateTimeViewModel : BaseViewModel<long>
{
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public bool IsReserved { get; set; }
}