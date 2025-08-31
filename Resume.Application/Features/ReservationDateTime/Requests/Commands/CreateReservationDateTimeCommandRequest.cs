using MediatR;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record CreateReservationDateTimeCommandRequest : IRequest<bool>
{
    public CreateReservationDateTimeViewModel CreateReservationDateTimeViewModel { get; init; } 

    public CreateReservationDateTimeCommandRequest(CreateReservationDateTimeViewModel createReservationDateTimeViewModel)
    {
        CreateReservationDateTimeViewModel = createReservationDateTimeViewModel;
    }
}
