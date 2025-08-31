using MediatR;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Features.Skill.Requests.Commands;

public record CreateSkillCommandRequest(CreateSkillViewModel CreateSkillViewModel) : IRequest<bool>
{
}
