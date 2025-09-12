using MediatR;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Queries;

public record GetExperienceRequest(long? Id) : IRequest<ExperienceViewModel>
{
}
