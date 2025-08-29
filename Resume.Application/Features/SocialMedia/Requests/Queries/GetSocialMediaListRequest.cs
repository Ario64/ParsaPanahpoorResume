using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Features.SocialMedia.Requests.Queries;

public record GetThingIDoListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<SkillViewModel>>
{
}
