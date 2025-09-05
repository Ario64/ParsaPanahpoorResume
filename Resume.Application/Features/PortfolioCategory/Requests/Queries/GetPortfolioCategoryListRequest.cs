using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Portfolio;
using System.Collections.Generic;

namespace Resume.Application.Features.PortfolioCategory.Requests.Queries;

public record GetPortfolioCategoryListRequest() : IRequest<IReadOnlyList<PortfolioCategoryViewModel>>
{
}
