using FluentValidation;

namespace Resume.Application.ViewModels.ReservationDate.Validators;

public class IReservationDateValidator : AbstractValidator<IReservationDateViewModel>
{
    public IReservationDateValidator()
    {
        RuleFor(r => r.Date).NotEmpty()
                            .WithMessage("{PropertyName} را وارد کنید !");
    }
}
