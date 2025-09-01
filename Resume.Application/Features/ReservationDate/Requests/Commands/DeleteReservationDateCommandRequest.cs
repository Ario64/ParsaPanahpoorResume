using MediatR;

namespace Resume.Application.Features.ReservationDate.Requests.Commands;

public record DeleteReservationDateTimeCommandRequest(long Id) : IRequest<bool>
{
  
}
