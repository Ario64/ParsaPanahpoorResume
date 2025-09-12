using MediatR;
using Resume.Application.ViewModels.ReservationDateTime;
using System.Collections.Generic;

namespace Resume.Application.Features.ReservationDate.Requests.Queries;

public record GetReservationDateTimeListRequest() : IRequest<IReadOnlyList<ReservationDateTimeViewModel>>
{
}
