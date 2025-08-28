using MediatR;
using Resume.Domain.ViewModels.PersonSelectedReservation;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Commands;

public record CreatePersonSelectedReservationCommandRequest : IRequest<Unit>
{
    public CreatePersonSelectedReservationViewModel CreatePersonSelectedReservation { get; set; }
}
