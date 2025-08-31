using MediatR;

namespace Resume.Application.Features.Skill.Requests.Commands;

public record DeleteSkillCommandRequest(ulong Id) : IRequest<bool>
{
}
