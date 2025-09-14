using FluentValidation;

namespace Resume.Application.ViewModels.Skill.Validators;

public class CreateSkillValidator : AbstractValidator<CreateSkillViewModel>
{
    public CreateSkillValidator()
    {
        Include(new ISkillValidator());
    }
}
