using MediatR;
using Resume.Application.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Queries;

public record GetExperienceRequest(long? Id) : IRequest<ExperienceViewModel>
{
}
