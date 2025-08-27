using MediatR;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Commands;

public record EditExperienceCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditExperienceViewModel  EditExperienceViewModel { get; init; }
}
