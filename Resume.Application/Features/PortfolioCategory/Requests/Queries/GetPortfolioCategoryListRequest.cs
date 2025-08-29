using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Queries;

public record GetReservationDateListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<PortfolioCategoryViewModel>>
{
}
