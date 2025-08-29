using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Queries;

public record GetReservationDateTimeListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<ReservationDateTimeViewModel>>
{
}
