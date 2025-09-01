using MediatR;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record DeleteReservationDateTimeCommandRequest(long Id) : IRequest<bool>
{
 
}
