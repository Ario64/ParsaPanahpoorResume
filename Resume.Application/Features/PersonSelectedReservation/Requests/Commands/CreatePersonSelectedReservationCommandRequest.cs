using MediatR;
using Resume.Domain.ViewModels.PersonSelectedReservation;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Commands;

public record CreatePersonSelectedReservationCommandRequest : IRequest<bool>
{
    public CreatePersonSelectedReservationViewModel CreatePersonSelectedReservation { get; init; }

    public CreatePersonSelectedReservationCommandRequest(CreatePersonSelectedReservationViewModel createPersonSelectedReservationViewModel)
    {
     CreatePersonSelectedReservation = createPersonSelectedReservationViewModel;
    }
}
