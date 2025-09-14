using FluentValidation;

namespace Resume.Application.ViewModels.PersonSelectedReservation.Validators;

public class EditPersonSelectedReservationValidator : AbstractValidator<EditPersonSelectedReservationViewModel>
{
    public EditPersonSelectedReservationValidator()
    {
        Include(new IPersonSelectedReservationValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
