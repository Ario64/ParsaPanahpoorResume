using MediatR;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Requests.Queries;

public record GetCustomerFeedbackRequest(long Id) : IRequest<CustomerFeedbackViewModel>
{
}