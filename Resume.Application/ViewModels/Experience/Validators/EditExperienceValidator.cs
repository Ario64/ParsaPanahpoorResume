using FluentValidation;

namespace Resume.Application.ViewModels.Experience.Validators;

public class EditExperienceValidator : AbstractValidator<EditExperienceViewModel>
{
    public EditExperienceValidator()
    {
        Include(new IExperienceValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
