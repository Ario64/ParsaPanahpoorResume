using FluentValidation;
using System.IO.Pipelines;

namespace Resume.Application.ViewModels.Education.Validators;

public class CreateEducationValidator : AbstractValidator<CreateEducationViewModel>
{
    public CreateEducationValidator()
    {
        RuleFor(r => r.Title).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .MaximumLength(100)
                             .WithMessage("{PropertyName} نباید بیشتر از 100 کاراکتر باشد !");

        RuleFor(r => r.StartDate).NotEmpty()
                                 .WithMessage("{PropertyName} را وارد کنید !")
                                 .MaximumLength(4)
                                 .WithMessage("{PropertyName نباید بیشتر از 4 کاراکتر باشد !}")
                                 .LessThan(r => r.EndDate)
                                 .WithMessage("{PropertyName} باید کوچکتر از {ComparisonValue} باشد !");

        RuleFor(r => r.EndDate).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .MaximumLength(4)
                             .WithMessage("{PropertyName نباید بیشتر از 4 کاراکتر باشد !}")
                             .GreaterThan(r => r.StartDate)
                             .WithMessage("{PropertyName} باید بزرگتر از {ComparisonValue} شروع باشد !");

        RuleFor(r => r.Description).NotEmpty()
                                   .WithMessage("{PropertyName} را وارد کنید !")
                                   .MaximumLength(1000)
                                   .WithMessage("{PropertyName} بناید بیشتر از 1000 کاراکتر باشد !");

        RuleFor(r => r.Order).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .GreaterThan(0)
                             .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
