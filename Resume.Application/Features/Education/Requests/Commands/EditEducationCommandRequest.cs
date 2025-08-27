using MediatR;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Features.Education.Requests.Commands;

public record EditEducationCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditEducationViewModel EditEducationViewModel { get; init; }
}
