using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Queries;

public record GetPortfolioListRequest(int page, int pageSize) : IRequest<PortfolioPageResult>
{
}
