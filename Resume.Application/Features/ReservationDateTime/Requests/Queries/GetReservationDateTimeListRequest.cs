using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.ReservationDateTime;
using System.Collections.Generic;

namespace Resume.Application.Features.ReservationDate.Requests.Queries;

public record GetReservationDateTimeListRequest() : IRequest<IReadOnlyList<ReservationDateTimeViewModel>>
{
}
