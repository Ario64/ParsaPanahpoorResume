using FluentValidation;

namespace Resume.Application.ViewModels.CustomerLogo.Validators;

public class DeleteCustomerLogoValidator : AbstractValidator<DeleteCustomerLogoViewModel>
{
    public DeleteCustomerLogoValidator()
    {
        RuleFor(RuleFor => RuleFor.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 یاشد !");
    }
}
