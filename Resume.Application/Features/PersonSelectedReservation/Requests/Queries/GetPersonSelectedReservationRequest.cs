using MediatR;
using Resume.Application.ViewModels.PersonSelectedReservation;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Queries;

public record GetPersonSelectedReservationRequest(long Id) : IRequest<PersonSelectedReservationViewModel>
{
  
}
