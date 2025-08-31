using MediatR;

namespace Resume.Application.Features.Message.Requests.Commands;

public record DeleteMessageCommandRequest(ulong Id) : IRequest<bool>
{
 
}
