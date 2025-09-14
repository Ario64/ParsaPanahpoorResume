using FluentValidation;

namespace Resume.Application.ViewModels.Portfolio.Validators;

public class CreatePortfolioCategoryValidator : AbstractValidator<CreatePortfolioCategoryViewModel>
{
    public CreatePortfolioCategoryValidator()
    {
        Include(new IPortfolioCategoryValidator());
    }
}
