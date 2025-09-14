namespace Resume.Application.ViewModels.ReservationDateTime;

public class ReservationDateTimeListViewModel : IReservationDateTimeViewModel
{
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public bool IsReserved { get; set; }
}