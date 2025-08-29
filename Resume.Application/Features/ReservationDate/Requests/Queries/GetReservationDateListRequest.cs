using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.ReservationDate;

namespace Resume.Application.Features.ReservationDate.Requests.Queries;

public record GetReservationDateListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<ReservationDateViewModel>>
{
}
