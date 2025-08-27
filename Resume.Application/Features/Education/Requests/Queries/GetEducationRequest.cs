using MediatR;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Features.Education.Requests.Queries;

public record GetEducationRequest : IRequest<EducationViewModel>
{
    public ulong Id { get; init; }
}
