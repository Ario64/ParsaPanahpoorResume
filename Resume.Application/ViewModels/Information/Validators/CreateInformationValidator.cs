using FluentValidation;

namespace Resume.Application.ViewModels.Information.Validators;

public class CreateInformationValidator : AbstractValidator<CreateInformationViewModel>
{
    public CreateInformationValidator()
    {
        Include(new IInformationValidator());
    }
}
