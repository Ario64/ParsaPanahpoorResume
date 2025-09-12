using MediatR;
using Resume.Domain.ViewModels.Experience;
using System.Collections.Generic;

namespace Resume.Application.Features.Experience.Requests.Queries;

public record GetExperienceListRequest() : IRequest<IReadOnlyList<ExperienceViewModel>>
{
}
