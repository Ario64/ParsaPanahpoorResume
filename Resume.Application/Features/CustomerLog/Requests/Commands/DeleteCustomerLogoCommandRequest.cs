using MediatR;

namespace Resume.Application.Features.CustomerLog.Requests.Commands; 

public class DeleteCustomerLogoCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
