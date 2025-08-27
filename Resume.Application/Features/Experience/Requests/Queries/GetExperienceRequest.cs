using MediatR;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Queries;

public record GetExperienceRequest : IRequest<ExperienceViewModel>
{
    public ulong Id { get; set; }
}
