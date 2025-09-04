using MediatR;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Requests.Queries;

public record GetCustomerLogoListRequest() : IRequest<IReadOnlyList<CustomerLogoViewModel>>
{

}