using MediatR;
using Resume.Domain.ViewModels.ReservationDate;

namespace Resume.Application.Features.ReservationDate.Requests.Queries;

public record GetReservationDateTimeRequest : IRequest<ReservationDateViewModel>
{
    public ulong Id { get; init; }
}
