using FluentValidation;

namespace Resume.Application.ViewModels.Information.Validators;

public class IInformationValidator : AbstractValidator<IInformationViewModel>
{
    public IInformationValidator()
    {
        RuleFor(r => r.Name).MaximumLength(100)
                      .WithMessage("{PropertyName} نباید بیشتر از 100 کاراکتر باشد !");

        RuleFor(r => r.Job).MaximumLength(100)
                           .WithMessage("{PropertyName} نباید بیشتر از 100 کاراکتر باشد !");

        RuleFor(r => r.DateOfBirth).MaximumLength(100)
                                   .WithMessage("{PropertyName} نباید بیشتر از 100 کاراکتر باشد !");

        RuleFor(r => r.Address).MaximumLength(1000)
                               .WithMessage("{PropertyName} نباید بیشتر از 0100 کاراکتر باشد !");

        RuleFor(r => r.Email).MaximumLength(100)
                             .WithMessage("{PropertyName} نباید بیشتر از 100 کاراکتر باشد !");

        RuleFor(r => r.Phone).MaximumLength(100)
                             .WithMessage("{PropertyName} نباید بیشتر از 100 کاراکتر باشد !");

        RuleFor(r => r.ResumeFile).MaximumLength(100)
                             .WithMessage("{PropertyName} نباید بیشتر از 100 کاراکتر باشد !");
    }
}
