using FluentValidation;

namespace Resume.Application.ViewModels.ReservationDate.Validators;

public class CreateReservationDateValidator : AbstractValidator<CreateReservationDateViewModel>
{
    public CreateReservationDateValidator()
    {
       Include(new IReservationDateValidator());
    }
}
