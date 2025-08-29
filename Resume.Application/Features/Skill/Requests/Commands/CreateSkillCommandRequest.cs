using MediatR;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Features.Skill.Requests.Commands;

public record CreateSocialMediaCommandRequest : IRequest<Unit>
{
    public CreateSkillViewModel CreateSkillViewModel { get; init; }
}
