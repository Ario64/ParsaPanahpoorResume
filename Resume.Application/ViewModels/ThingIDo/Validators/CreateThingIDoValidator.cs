using FluentValidation;

namespace Resume.Application.ViewModels.ThingIDo.Validators;

public class CreateThingIDoValidator : AbstractValidator<CreateThingIDoViewModel>
{
    public CreateThingIDoValidator()
    {
        Include(new IThingIDoValidator());
    }
}
