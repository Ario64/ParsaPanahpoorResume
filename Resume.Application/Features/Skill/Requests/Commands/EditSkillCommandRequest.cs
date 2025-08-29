using MediatR;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Features.Skill.Requests.Commands;

public record EditSocialMediaCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditSkillViewModel EditSkillViewModel { get; init; }
}
