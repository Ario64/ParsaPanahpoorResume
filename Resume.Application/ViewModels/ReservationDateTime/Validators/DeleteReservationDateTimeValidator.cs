using FluentValidation;

namespace Resume.Application.ViewModels.ReservationDateTime.Validators;

public class DeleteReservationDateTimeValidator : AbstractValidator<DeleteReservationDateTimeCommand>
{
    public DeleteReservationDateTimeValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
