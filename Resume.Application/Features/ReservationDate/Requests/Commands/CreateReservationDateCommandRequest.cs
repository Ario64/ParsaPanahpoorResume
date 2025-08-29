using MediatR;
using Resume.Domain.ViewModels.ReservationDate;

namespace Resume.Application.Features.ReservationDate.Requests.Commands;

public record CreateReservationDateCommandRequest : IRequest<Unit>
{
    public CreateReservationDateViewModel CreateReservationDateViewModel { get; init; }
}
