using MediatR;
using Resume.Domain.ViewModels.CustomerLogo;
using System.Collections.Generic;

namespace Resume.Application.Features.CustomerLog.Requests.Queries;

public record GetCustomerLogoListRequest() : IRequest<IReadOnlyList<CustomerLogoViewModel>>
{

}