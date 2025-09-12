using MediatR;
using Resume.Application.ViewModels.CustomerFeedback;
using System.Collections.Generic;

namespace Resume.Application.Features.CustomerFeedback.Requests.Queries;

public record GetCustomerFeedbackListRequest() : IRequest<IReadOnlyList<CustomerFeedbackViewModel>>
{

}