using FluentValidation;
using Resume.Domain.ViewModels.PersonSelectedReservation;

namespace Resume.Application.ViewModels.PersonSelectedReservation.Validators;

public class DeletePersonSelectedReservationValidator : AbstractValidator<DeletePersonSelectedReservationViewModel>
{
    public DeletePersonSelectedReservationValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
