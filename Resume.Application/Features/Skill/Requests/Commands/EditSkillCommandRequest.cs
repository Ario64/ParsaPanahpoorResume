using MediatR;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Features.Skill.Requests.Commands;

public record EditSkillCommandRequest(ulong Id, EditSkillViewModel EditSkillViewModel) : IRequest<Unit>
{
  
}
