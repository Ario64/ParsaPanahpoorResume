using FluentValidation;

namespace Resume.Application.ViewModels.SocialMedia.Validators;

public class ISocialMediaValidator : AbstractValidator<ISocialMediViewModel>
{
    public ISocialMediaValidator()
    {
        RuleFor(r => r.Link).NotEmpty()
                            .WithMessage("{PropertyName} را وارد کنید !")
                            .MaximumLength(1000)
                            .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Icon).NotEmpty()
                            .WithMessage("{PropertyName} را وارد کنید !")
                            .MaximumLength(100)
                            .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Order).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .GreaterThan(0)
                             .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
