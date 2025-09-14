using FluentValidation;
using Resume.Application.UnitOfWork;

namespace Resume.Application.ViewModels.ReservationDateTime.Validators;

public class EditReservationDateTimeValidator : AbstractValidator<EditReservationDateTimeViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public EditReservationDateTimeValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new IReservationDateTimeValidator(_unitOfWork));

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");

    }
}
