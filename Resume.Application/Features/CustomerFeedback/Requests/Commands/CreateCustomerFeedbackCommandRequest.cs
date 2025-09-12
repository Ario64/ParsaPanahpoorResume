using MediatR;
using Resume.Application.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Requests.Commands;

public record CreateCustomerFeedbackCommandRequest(CreateCustomerFeedbackViewModel CreateCustomerFeedbackViewModel) : IRequest<bool>
{
   
}