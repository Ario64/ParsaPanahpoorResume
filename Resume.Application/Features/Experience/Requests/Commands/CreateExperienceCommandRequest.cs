using MediatR;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Commands;

public record CreateExperienceCommandRequest : IRequest<Unit>
{
    public CreateExperienceViewModel CreateExperienceViewModel { get; init; }
}
