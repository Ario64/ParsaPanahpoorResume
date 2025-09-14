using FluentValidation;
using Resume.Application.ViewModels.PersonSelectedReservation.Validators;

namespace Resume.Application.ViewModels.PersonSelectedReservation.Validator;

public class CreatePersonSelectedReservationValidator : AbstractValidator<CreatePersonSelectedReservationViewModel>
{
    public CreatePersonSelectedReservationValidator()
    {
        Include(new IPersonSelectedReservationValidator());
    }
}
