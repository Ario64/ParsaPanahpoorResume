using MediatR;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record DeleteThingIDoCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
