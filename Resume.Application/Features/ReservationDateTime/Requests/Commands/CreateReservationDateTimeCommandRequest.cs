using MediatR;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record CreateReservationDateTimeCommandRequest : IRequest<Unit>
{
    public CreateReservationDateTimeViewModel CreateReservationDateTimeViewModel { get; init; }
}
