using System.Collections.Generic;
using MediatR;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Requests.Queries;

public class GetCustomerFeedbackListRequest : IRequest<List<CustomerFeedbackViewModel>>
{
    
}