using FluentValidation;

namespace Resume.Application.ViewModels.Education.Validators;

public class EditEducationValidator : AbstractValidator<EditEducationViewModel>
{
    public EditEducationValidator()
    {
        Include(new IEducationValidator());

        RuleFor(r => r.Id).NotEmpty()
                         .WithMessage("{PropertyName} را وارد کنید !")
                         .GreaterThan(0)
                         .WithMessage("{PropertyName} باید بزرگتر از 0 یاشد !");
    }
}
