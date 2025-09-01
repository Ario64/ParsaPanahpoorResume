using MediatR;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record EditReservationDateTimeCommandRequest : IRequest<bool>
{
    public long Id { get; init; }
    public EditReservationDateTimeViewModel EditReservationDateTimeViewModel { get; init; }

    public EditReservationDateTimeCommandRequest(long id, EditReservationDateTimeViewModel editReservationDateTimeViewModel)
    {
        Id = id;
        EditReservationDateTimeViewModel = editReservationDateTimeViewModel;
    }
}
