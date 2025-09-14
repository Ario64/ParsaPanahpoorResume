using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resume.Application.UnitOfWork;

namespace Resume.Application.ViewModels.Portfolio.Validators;

public class EditPortfolioValidator : AbstractValidator<EditPortfolioViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditPortfolioValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new IPortfolioValidator(_unitOfWork));

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
