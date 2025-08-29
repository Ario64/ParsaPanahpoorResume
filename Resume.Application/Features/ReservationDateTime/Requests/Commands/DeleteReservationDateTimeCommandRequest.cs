using MediatR;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record DeleteReservationDateTimeCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
