using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Skill;
using System.Collections.Generic;

namespace Resume.Application.Features.Skill.Requests.Queries;

public record GetSkillListRequest() : IRequest<IReadOnlyList<SkillViewModel>>
{
}
