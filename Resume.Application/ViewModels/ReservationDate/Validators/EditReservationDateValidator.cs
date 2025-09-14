using FluentValidation;

namespace Resume.Application.ViewModels.ReservationDate.Validators;

public class EditReservationDateValidator : AbstractValidator<EditReservationDateViewModel>
{
    public EditReservationDateValidator()
    {
        Include(new IReservationDateValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
