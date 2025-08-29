using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Queries;

public record GetThingIDoListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<ThingIdoViewModel>>
{
}
