using MediatR;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Requests.Queries;

public class GetCustomerFeedbackRequest : IRequest<CustomerFeedbackViewModel>
{
    public ulong Id { get; set; }
}