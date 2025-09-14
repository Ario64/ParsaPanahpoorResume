using FluentValidation;

namespace Resume.Application.ViewModels.CustomerFeedback.Validators;

public class DeleteCustomerFeedbackValidator : AbstractValidator<DeleteCustomerFeedbackViewModel>
{
    public DeleteCustomerFeedbackValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} را وارد کنید !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} باید بزرگتر از 0 یاشد !");
    }
}
