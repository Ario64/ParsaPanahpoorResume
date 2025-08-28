using MediatR;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Commands;

public record DeletePersonSelectedReservationCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
}
