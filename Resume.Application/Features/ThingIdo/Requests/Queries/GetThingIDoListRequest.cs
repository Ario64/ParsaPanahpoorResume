using MediatR;
using Resume.Application.ViewModels.ThingIDo;
using System.Collections.Generic;

namespace Resume.Application.Features.ThingIdo.Requests.Queries;

public record GetThingIDoListRequest() : IRequest<IReadOnlyList<ThingIdoViewModel>>
{
}
