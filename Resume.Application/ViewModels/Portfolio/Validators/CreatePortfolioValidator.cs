using FluentValidation;
using Resume.Application.UnitOfWork;

namespace Resume.Application.ViewModels.Portfolio.Validators;

public class CreatePortfolioValidator : AbstractValidator<CreatePortfolioViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePortfolioValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new IPortfolioValidator(_unitOfWork));
    }
}
