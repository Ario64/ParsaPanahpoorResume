using MediatR;
using Resume.Application.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Queries;

public record GetPortfolioCategoryRequest(long? Id) : IRequest<PortfolioCategoryViewModel>
{
}
