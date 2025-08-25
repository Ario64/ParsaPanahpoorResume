using MediatR;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Requests.Queries;

public class GetCustomerLogoRequest : IRequest<CustomerLogoViewModel>
{
    public ulong Id { get; set; }
}