using MediatR;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record EditReservationDateTimeCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditReservationDateTimeViewModel EditReservationDateTimeViewModel { get; init; }
}
