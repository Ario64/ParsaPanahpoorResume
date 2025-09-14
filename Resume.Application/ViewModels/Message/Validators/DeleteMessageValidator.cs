using FluentValidation;

namespace Resume.Application.ViewModels.Message.Validators;

public class DeleteMessageValidator : AbstractValidator<DeleteMessageCommand>
{
    public DeleteMessageValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");
    }
}
