using MediatR;
using Resume.Application.ViewModels.Pagination;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Features.Education.Requests.Queries;

public record GetEducationListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<EducationViewModel>>
{
}
