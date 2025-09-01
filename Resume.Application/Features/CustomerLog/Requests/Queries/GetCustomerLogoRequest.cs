using MediatR;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Requests.Queries;

public class GetCustomerLogoRequest : IRequest<CustomerLogoViewModel>
{
    public long Id { get; set; }

    public GetCustomerLogoRequest(long id)
    {
     Id = id;   
    }
}