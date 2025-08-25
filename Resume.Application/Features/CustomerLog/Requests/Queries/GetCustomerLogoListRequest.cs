using System.Collections.Generic;
using MediatR;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Requests.Queries;

public record GetCustomerLogoListRequest(int pageId = 1, int pageSize = 5) : IRequest<List<CustomerLogoViewModel>>
{
    
}