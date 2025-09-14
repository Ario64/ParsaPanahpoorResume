using FluentValidation;

namespace Resume.Application.ViewModels.CustomerLogo.Validators;

public class EditCustomerLogoValidator: AbstractValidator<EditCustomerLogoViewModel>
{
    public EditCustomerLogoValidator()
    {
        Include(new ICustomerLogoValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 یاشد !");
    }
}
