using MediatR;

namespace Resume.Application.Features.Skill.Requests.Commands;

public record DeleteSkillCommandRequest(long Id) : IRequest<bool>
{
}
