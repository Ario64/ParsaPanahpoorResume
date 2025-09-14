using FluentValidation;

namespace Resume.Application.ViewModels.ThingIDo.Validators;

public class IThingIDoValidator : AbstractValidator<IThingIDoViewModel>
{
    public IThingIDoValidator()
    {
        RuleFor(r => r.Title).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .MaximumLength(100)
                             .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Icon).MaximumLength(50)
                            .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.Description).NotEmpty()
                                   .WithMessage("{PropertyName} را وارد کنید !")
                                   .MaximumLength(1000)
                                   .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد !");

        RuleFor(r => r.ColumnLg).NotEmpty()
                                .WithMessage("{PropertyName} را وارد کنید !");

        RuleFor(r => r.Order).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .GreaterThan(0)
                             .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
