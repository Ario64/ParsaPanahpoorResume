using FluentValidation;

namespace Resume.Application.ViewModels.SocialMedia.Validators;

public class DeleteSocialMediaValidator : AbstractValidator<DeleteSocialMediaViewModel>
{
    public DeleteSocialMediaValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
