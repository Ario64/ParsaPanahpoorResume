using FluentValidation;

namespace Resume.Application.ViewModels.Skill.Validators;

public class DeleteSkillValidator : AbstractValidator<DeleteSkillViewModel>
{
    public DeleteSkillValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
