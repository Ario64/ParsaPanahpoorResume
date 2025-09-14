using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.PersonSelectedReservation;

public class EditPersonSelectedReservationViewModel : BaseViewModel<long>, IPersonSelectedReservationViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}