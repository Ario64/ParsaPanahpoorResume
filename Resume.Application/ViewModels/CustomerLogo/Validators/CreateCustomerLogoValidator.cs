using FluentValidation;

namespace Resume.Application.ViewModels.CustomerLogo.Validators;

public class CreateCustomerLogoValidator : AbstractValidator<CreateCustomerLogoViewModel>
{
    public CreateCustomerLogoValidator()
    {
        RuleFor(r => r.Logo).NotEmpty()
                            .WithMessage("{PropertyName} را وارد کنید !");

        RuleFor(r => r.LogoAlt).NotEmpty()
                               .WithMessage("{PropertyName} را وارد کنید !");

        RuleFor(r => r.Link).NotEmpty()
                            .WithMessage("{PropertyName} را وارد کنید !");

        RuleFor(r => r.Order).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .GreaterThan(0)
                             .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !")
                             .LessThan(100)
                             .WithMessage("{PropertyName} باید کمتر از 100 باشد !");
          
    }
}
