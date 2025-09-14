using FluentValidation;

namespace Resume.Application.ViewModels.Education.Validators;

public class DeleteEducationValidator : AbstractValidator<DeleteEducationViewModel>
{
    public DeleteEducationValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 یاشد !");
    }
}
