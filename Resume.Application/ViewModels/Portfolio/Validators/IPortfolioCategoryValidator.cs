using FluentValidation;
using System.IO.Pipelines;

namespace Resume.Application.ViewModels.Portfolio.Validators;

public class IPortfolioCategoryValidator : AbstractValidator<IPortfolioCategoryViewModel>
{
    public IPortfolioCategoryValidator()
    {
        RuleFor(r => r.Title).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .MaximumLength(100)
                             .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Name).NotEmpty()
                            .WithMessage("{PropertyName} را وارد کنید !")
                            .MaximumLength(100)
                            .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Order).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .GreaterThan(0)
                             .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");

    }
}
