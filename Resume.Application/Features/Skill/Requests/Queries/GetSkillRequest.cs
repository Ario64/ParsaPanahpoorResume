using MediatR;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Features.Skill.Requests.Queries;

public record GetSkillRequest(long Id) : IRequest<SkillViewModel>
{
    
}
