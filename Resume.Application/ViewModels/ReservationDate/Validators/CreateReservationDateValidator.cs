using FluentValidation;

namespace Resume.Application.ViewModels.ReservationDate.Validators;

public class CreateReservationDateValidator : AbstractValidator<CreateReservationDateViewModel>
{
    public CreateReservationDateValidator()
    {
        RuleFor(r=>r.Date).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !");
    }
}
