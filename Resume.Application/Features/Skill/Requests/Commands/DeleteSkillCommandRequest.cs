using MediatR;

namespace Resume.Application.Features.Skill.Requests.Commands;

public record DeleteSkillCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
