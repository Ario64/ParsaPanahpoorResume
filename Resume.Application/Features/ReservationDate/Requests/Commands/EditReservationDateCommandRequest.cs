using MediatR;
using Resume.Domain.ViewModels.ReservationDate;

namespace Resume.Application.Features.ReservationDate.Requests.Commands;

public record EditReservationDateTimeCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditReservationDateViewModel EditReservationDateViewModel { get; init; }
}
