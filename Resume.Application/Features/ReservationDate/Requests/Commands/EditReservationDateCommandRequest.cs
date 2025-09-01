using MediatR;
using Resume.Domain.ViewModels.ReservationDate;

namespace Resume.Application.Features.ReservationDate.Requests.Commands;

public record EditReservationDateTimeCommandRequest : IRequest<bool>
{
    public long Id { get; init; }
    public EditReservationDateViewModel EditReservationDateViewModel { get; init; }

    public EditReservationDateTimeCommandRequest(long id, EditReservationDateViewModel editReservationDateViewModel)
    {
        Id = id;
        EditReservationDateViewModel = editReservationDateViewModel;
    }
}
