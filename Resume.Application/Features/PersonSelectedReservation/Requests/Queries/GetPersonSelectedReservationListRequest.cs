using MediatR;
using Resume.Domain.ViewModels.PersonSelectedReservation;
using System.Collections.Generic;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Queries;

public  record GetPersonSelectedReservationListRequest: IRequest<IReadOnlyList<PersonSelectedReservationViewModel>>
{
 
}
