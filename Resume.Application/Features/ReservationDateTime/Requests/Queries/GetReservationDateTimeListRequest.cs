using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.Skill.Requests.Queries;

public record GetSkillListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<ReservationDateTimeViewModel>>
{
}
