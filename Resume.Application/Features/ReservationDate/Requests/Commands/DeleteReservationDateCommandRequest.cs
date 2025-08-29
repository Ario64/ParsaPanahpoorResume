using MediatR;

namespace Resume.Application.Features.ReservationDate.Requests.Commands;

public record DeleteReservationDateCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
