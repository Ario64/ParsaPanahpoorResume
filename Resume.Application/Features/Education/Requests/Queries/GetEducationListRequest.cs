using MediatR;
using Resume.Domain.ViewModels.Education;
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Application.Features.Education.Requests.Queries;

public record GetEducationListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<EducationViewModel>>
{
}
