using MediatR;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Queries;

public record GetReservationDateTimeRequest(ulong Id) : IRequest<ReservationDateTimeViewModel>
{
}
