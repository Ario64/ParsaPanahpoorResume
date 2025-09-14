using FluentValidation;

namespace Resume.Application.ViewModels.CustomerLogo.Validators;

public class CreateCustomerLogoValidator : AbstractValidator<CreateCustomerLogoViewModel>
{
    public CreateCustomerLogoValidator()
    {
        Include(new ICustomerLogoValidator());
    }
}
