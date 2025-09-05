using MediatR;
using Resume.Domain.ViewModels.ReservationDate;
using System.Collections.Generic;

namespace Resume.Application.Features.ReservationDate.Requests.Queries;

public record GetReservationDateListRequest() : IRequest<IReadOnlyList<ReservationDateViewModel>>
{
}
