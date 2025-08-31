using Resume.Domain.ViewModels.Common;

namespace Resume.Domain.ViewModels.ReservationDateTime;

public class ReservationDateTimeViewModel : BaseViewModel<long>
{
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public bool IsReserved { get; set; }
}