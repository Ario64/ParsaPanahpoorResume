using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Queries;

public record GetPortfolioCategoryListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<PortfolioViewModel>>
{
}
