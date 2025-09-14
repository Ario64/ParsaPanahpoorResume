using FluentValidation;

namespace Resume.Application.ViewModels.Portfolio.Validators;

public class DeletePortfolioCategoryValidator : AbstractValidator<DeletePortfolioCategoryViewModel>
{
    public DeletePortfolioCategoryValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                  .WithMessage("{PropertyName} را وارد کنید !")
                  .GreaterThan(0)
                  .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
