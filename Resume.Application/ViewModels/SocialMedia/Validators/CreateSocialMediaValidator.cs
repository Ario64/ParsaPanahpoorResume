using FluentValidation;

namespace Resume.Application.ViewModels.SocialMedia.Validators;

public class CreateSocialMediaValidator : AbstractValidator<SocialMediaViewModel>
{
    public CreateSocialMediaValidator()
    {
        Include(new ISocialMediaValidator());
    }
}
