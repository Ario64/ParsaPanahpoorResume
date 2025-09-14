using FluentValidation;

namespace Resume.Application.ViewModels.SocialMedia.Validators
{
    public class EditSocialMediaValidator : AbstractValidator<SocialMediaViewModel>
    {
        public EditSocialMediaValidator()
        {
            Include(new ISocialMediaValidator());

            RuleFor(r => r.Id).NotEmpty()
                              .WithMessage("{PropertyName} را وارد کنید !")
                              .GreaterThan(0)
                              .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
        }
    }
}
