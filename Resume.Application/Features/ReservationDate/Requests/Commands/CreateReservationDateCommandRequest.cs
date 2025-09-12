using MediatR;
using Resume.Application.ViewModels.ReservationDate;

namespace Resume.Application.Features.ReservationDate.Requests.Commands;

public record CreateReservationDateTimeCommandRequest(CreateReservationDateViewModel CreateReservationDateViewModel) : IRequest<bool>
{
   
}
