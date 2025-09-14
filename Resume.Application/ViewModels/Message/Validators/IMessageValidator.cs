using FluentValidation;

namespace Resume.Application.ViewModels.Message.Validators;

public class IMessageValidator : AbstractValidator<IMessageViewModel>
{
    public IMessageValidator()
    {
        RuleFor(r => r.Name).NotEmpty()
                            .WithMessage("{PropertyName} را وارد کنید !")
                            .MaximumLength(100)
                            .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Email).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .MaximumLength(250)
                             .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Text).NotEmpty()
                            .WithMessage("{PropertyName} را وارد کنید !")
                            .MaximumLength(1000)
                            .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");
    }
}
