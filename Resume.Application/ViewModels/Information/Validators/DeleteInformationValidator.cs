using FluentValidation;

namespace Resume.Application.ViewModels.Information.Validators;

public class DeleteInformationValidator : AbstractValidator<DeleteInformationViewModel>
{
    public DeleteInformationValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
