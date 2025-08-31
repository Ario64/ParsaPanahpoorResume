using MediatR;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Features.Education.Requests.Queries;

public record GetEducationRequest(ulong Id) : IRequest<EducationViewModel>
{
}
