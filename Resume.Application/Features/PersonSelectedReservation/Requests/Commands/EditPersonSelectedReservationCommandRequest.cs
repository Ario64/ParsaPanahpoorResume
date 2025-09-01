using MediatR;
using Resume.Domain.ViewModels.PersonSelectedReservation;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Commands;

public record EditPersonSelectedReservationCommandRequest  : IRequest<bool>
{
    public long Id { get; init; }
    public EditPersonSelectedReservationViewModel  EditPersonSelectedReservationViewModel { get; init; }

    public EditPersonSelectedReservationCommandRequest(long id, EditPersonSelectedReservationViewModel editPersonSelectedReservationViewModel)
    {
        Id = id;
        EditPersonSelectedReservationViewModel = editPersonSelectedReservationViewModel;    
    }
}
