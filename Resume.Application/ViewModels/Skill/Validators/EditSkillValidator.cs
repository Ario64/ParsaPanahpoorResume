using FluentValidation;

namespace Resume.Application.ViewModels.Skill.Validators;

public class EditSkillValidator : AbstractValidator<EditSkillViewModel>
{
    public EditSkillValidator()
    {
        Include(new ISkillValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
