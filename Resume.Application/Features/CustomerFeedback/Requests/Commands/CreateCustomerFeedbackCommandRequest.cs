using MediatR;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Requests.Commands;

public class CreateCustomerFeedbackCommandRequest : IRequest<ulong>
{
    public CreateCustomerFeedbackViewModel CreateCustomerFeedback { get; set; }
}