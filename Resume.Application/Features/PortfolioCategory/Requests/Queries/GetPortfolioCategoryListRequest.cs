using MediatR;
using Resume.Application.ViewModels.Portfolio;
using System.Collections.Generic;

namespace Resume.Application.Features.PortfolioCategory.Requests.Queries;

public record GetPortfolioCategoryListRequest() : IRequest<IReadOnlyList<PortfolioCategoryViewModel>>
{
}
