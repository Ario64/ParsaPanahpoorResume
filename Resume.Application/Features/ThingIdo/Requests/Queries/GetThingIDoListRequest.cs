using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.ThingIDo;
using System.Collections.Generic;

namespace Resume.Application.Features.ThingIdo.Requests.Queries;

public record GetThingIDoListRequest() : IRequest<IReadOnlyList<ThingIdoViewModel>>
{
}
