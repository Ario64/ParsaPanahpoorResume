using MediatR;
using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Application.Features.Information.Requests.Queries;

public record GetInformationListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<InformationViewModel>>
{
}
