using FluentValidation;

namespace Resume.Application.ViewModels.Experience.Validators;

public class CreateExperienceValidator : AbstractValidator<CreateExperienceViewModel>
{
    public CreateExperienceValidator()
    {
      Include(new IExperienceValidator());
    }
}
