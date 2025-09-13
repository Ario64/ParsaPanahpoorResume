using FluentValidation;
using Resume.Application.UnitOfWork;

namespace Resume.Application.ViewModels.ReservationDateTime.Validators;

public class CreateReservationDateTimeValidator : AbstractValidator<CreateReservationDateTimeViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateReservationDateTimeValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(r => r.ReservationDateId).NotEmpty()
                                           .WithMessage("{PropertyName} را وارد کنید !")
                                           .GreaterThan(0)
                                           .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !")
                                           .MustAsync(async (id, token) =>
                                           {
                                               var portfilioCategory = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().IsExist(id);
                                               return portfilioCategory;
                                           })
                                           .WithMessage("{PropertyName وجود ندارد !}");

    }
}
