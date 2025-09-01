using MediatR;
using Resume.Domain.ViewModels.ReservationDate;

namespace Resume.Application.Features.ReservationDate.Requests.Queries;

public record GetReservationDateRequest(long Id ) : IRequest<ReservationDateViewModel>
{
   
}
