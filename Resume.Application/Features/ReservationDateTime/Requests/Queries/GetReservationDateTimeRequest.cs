using MediatR;
using Resume.Application.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Queries;

public record GetReservationDateTimeRequest(long Id) : IRequest<ReservationDateTimeViewModel>
{
}
