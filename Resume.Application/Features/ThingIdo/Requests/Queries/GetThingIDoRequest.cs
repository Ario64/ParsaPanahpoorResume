using MediatR;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Queries;

public record GetThingIDoRequest : IRequest<ThingIdoViewModel>
{
    public ulong Id { get; init; }
}
