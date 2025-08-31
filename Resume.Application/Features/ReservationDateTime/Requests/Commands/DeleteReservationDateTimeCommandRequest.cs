using MediatR;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record DeleteReservationDateTimeCommandRequest(ulong Id) : IRequest<bool>
{
 
}
