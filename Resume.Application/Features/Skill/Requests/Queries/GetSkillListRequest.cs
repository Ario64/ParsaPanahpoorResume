using MediatR;
using Resume.Application.ViewModels.Skill;
using System.Collections.Generic;

namespace Resume.Application.Features.Skill.Requests.Queries;

public record GetSkillListRequest() : IRequest<IReadOnlyList<SkillViewModel>>
{
}
