using FluentValidation;

namespace Resume.Application.ViewModels.Information.Validators;

public class EditInformationValidator : AbstractValidator<EditInformationViewModel>
{
    public EditInformationValidator()
    {
        Include(new IInformationValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
