using FluentValidation;

namespace Resume.Application.ViewModels.Skill.Validators;

public class ISkillValidator: AbstractValidator<ISkillViewModel>
{
    public ISkillValidator()
    {
        RuleFor(r => r.Title).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .MaximumLength(100)
                             .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Percent).NotEmpty()
                               .WithMessage("{PropertyName} را وارد کنید !")
                               .MaximumLength(200)
                               .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Order).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !");
    }
}
