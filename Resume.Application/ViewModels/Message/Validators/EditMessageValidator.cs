using FluentValidation;

namespace Resume.Application.ViewModels.Message.Validators;

public class EditMessageValidator : AbstractValidator<EditMessageViewModel>
{
    public EditMessageValidator()
    {
        Include(new IMessageValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
