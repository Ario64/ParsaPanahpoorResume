using MediatR;
using Resume.Domain.ViewModels.Information;

namespace Resume.Application.Features.Experience.Requests.Commands;

public record EditInformationCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditInformationViewModel EditInformationViewModel { get; init; }
}
