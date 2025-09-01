using MediatR;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Features.Skill.Requests.Commands;

public record EditSkillCommandRequest(long Id, EditSkillViewModel EditSkillViewModel) : IRequest<bool>
{
  
}
