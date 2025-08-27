using MediatR;
using Resume.Domain.ViewModels.Experience;
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Application.Features.Experience.Requests.Queries;

public record GetExperienceListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<ExperienceViewModel>>
{
}
