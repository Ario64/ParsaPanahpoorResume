using FluentValidation;

namespace Resume.Application.ViewModels.Portfolio.Validators;

public class EditPortfolioCategoryValidator : AbstractValidator<EditPortfolioCategoryViewModel>
{
    public EditPortfolioCategoryValidator()
    {
        Include(new IPortfolioCategoryValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
