using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Queries;

public record GetPortfolioCategoryRequest(long Id) : IRequest<PortfolioCategoryViewModel>
{
}
