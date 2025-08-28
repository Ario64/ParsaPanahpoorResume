using MediatR;

namespace Resume.Application.Features.Message.Requests.Commands;

public record DeleteMessageCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
