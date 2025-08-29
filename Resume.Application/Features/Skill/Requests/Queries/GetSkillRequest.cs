using MediatR;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Features.Skill.Requests.Queries;

public record GetSkillRequest : IRequest<SkillViewModel>
{
    public ulong Id { get; init; }
}
