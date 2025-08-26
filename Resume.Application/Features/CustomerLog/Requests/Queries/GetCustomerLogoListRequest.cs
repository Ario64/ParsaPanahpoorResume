using System.Collections.Generic;
using MediatR;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Application.Features.CustomerLog.Requests.Queries;

public record GetCustomerLogoListRequest(int pageId = 1, int pageSize = 10) : IRequest<PagedResult<CustomerLogoViewModel>>
{

}