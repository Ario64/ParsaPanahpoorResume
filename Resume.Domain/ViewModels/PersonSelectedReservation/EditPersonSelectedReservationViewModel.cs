using Resume.Domain.ViewModels.Common;

namespace Resume.Domain.ViewModels.PersonSelectedReservation;

public class EditPersonSelectedReservationViewModel : BaseViewModel<ulong>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}