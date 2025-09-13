using FluentValidation;

namespace Resume.Application.ViewModels.CustomerFeedback.Validators;

public class EditCustomerFeedbackValidator : AbstractValidator<EditCustomerFeedbackViewModel>
{
    public EditCustomerFeedbackValidator()
    {
        RuleFor(r => r.Name).NotEmpty()
                      .WithMessage("{PropertyName} را وارد کنید !")
                      .MaximumLength(100)
                      .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} باشد !");

        RuleFor(r => r.Description).NotEmpty()
                                   .WithMessage("{PropertyName} را پر کنید !")
                                   .MaximumLength(1000)
                                   .WithMessage("{PropertyName} نباید بیشتر از {MaxLength} باشد !");

        RuleFor(r => r.Order).GreaterThan(0)
                             .WithMessage("{PropertyName} نباید کمتر از 0 باشد !")
                             .LessThan(100)
                             .WithMessage("{PropertyName} نباید بیشتر از 100 باشد !");
    }
}
