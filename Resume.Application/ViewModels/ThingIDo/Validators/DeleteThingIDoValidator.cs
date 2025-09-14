using FluentValidation;

namespace Resume.Application.ViewModels.ThingIDo.Validators;

public class DeleteThingIDoValidator : AbstractValidator<DeleteThingIdoViewModel>
{
    public DeleteThingIDoValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
