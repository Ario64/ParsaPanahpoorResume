using FluentValidation;

namespace Resume.Application.ViewModels.Message.Validators;

public class CreateMessageValidator : AbstractValidator<CreateMessageViewModel>
{
    public CreateMessageValidator()
    {
        Include(new IMessageValidator());
    }
}
