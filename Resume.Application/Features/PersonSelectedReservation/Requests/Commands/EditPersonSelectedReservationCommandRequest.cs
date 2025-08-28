using MediatR;
using Resume.Domain.ViewModels.PersonSelectedReservation;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Commands;

public record EditPersonSelectedReservationCommandRequest  : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditPersonSelectedReservationViewModel  EditPersonSelectedReservationViewModel { get; init; }
}
