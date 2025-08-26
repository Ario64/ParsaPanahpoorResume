using MediatR;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Application.Features.CustomerFeedback.Requests.Queries;

public record GetCustomerFeedbackListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<CustomerFeedbackViewModel>>
{

}