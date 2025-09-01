using MediatR;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Queries;

public record GetInformationRequest(long Id) : IRequest<ExperienceViewModel>
{
}
