using MediatR;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Commands;

public record DeletePersonSelectedReservationCommandRequest(long Id) : IRequest<bool>
{
   
}
