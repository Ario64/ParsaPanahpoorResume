using MediatR;

namespace Resume.Application.Features.CustomerLog.Requests.Commands; 

public record DeleteCustomerLogoCommandRequest(long id) : IRequest<bool>
{
    
}
