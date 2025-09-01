using MediatR;
using Resume.Domain.ViewModels.ReservationDate;

namespace Resume.Application.Features.ReservationDate.Requests.Commands;

public record CreateReservationDateTimeCommandRequest(CreateReservationDateViewModel CreateReservationDateViewModel) : IRequest<bool>
{
   
}
