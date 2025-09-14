using FluentValidation;
using Resume.Application.UnitOfWork;

namespace Resume.Application.ViewModels.ReservationDateTime.Validators;

public class CreateReservationDateTimeValidator : AbstractValidator<CreateReservationDateTimeViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateReservationDateTimeValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new IReservationDateTimeValidator(_unitOfWork));
    }
}
