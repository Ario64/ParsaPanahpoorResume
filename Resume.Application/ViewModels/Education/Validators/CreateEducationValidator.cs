using FluentValidation;

namespace Resume.Application.ViewModels.Education.Validators;

public class CreateEducationValidator : AbstractValidator<CreateEducationViewModel>
{
    public CreateEducationValidator()
    {
        Include(new IEducationValidator());
    }
}
