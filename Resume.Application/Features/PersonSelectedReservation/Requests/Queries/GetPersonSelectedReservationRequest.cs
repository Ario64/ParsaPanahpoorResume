using MediatR;
using Resume.Domain.ViewModels.PersonSelectedReservation;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Queries;

public record GetPersonSelectedReservationRequest : IRequest<PersonSelectedReservationViewModel>
{
    public ulong Id { get; init; }
}
