using MediatR;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record EditThingIDoCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditThingIdoViewModel EditThingIdoViewModel { get; init; }
}
