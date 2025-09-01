using MediatR;

namespace Resume.Application.Features.Message.Requests.Commands;

public record DeleteMessageCommandRequest(long Id) : IRequest<bool>
{
 
}
