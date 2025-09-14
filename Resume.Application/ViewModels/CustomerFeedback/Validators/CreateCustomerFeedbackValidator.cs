using FluentValidation;

namespace Resume.Application.ViewModels.CustomerFeedback.Validators;

public class CreateCustomerFeedbackValidator : AbstractValidator<CreateCustomerFeedbackViewModel>
{
    public CreateCustomerFeedbackValidator()
    {
        Include(new CustomerFeedbackValidator());
    }
}
