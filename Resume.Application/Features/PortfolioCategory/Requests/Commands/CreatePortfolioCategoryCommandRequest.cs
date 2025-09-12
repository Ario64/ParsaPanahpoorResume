using MediatR;
using Resume.Application.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record CreatePortfolioCategoryCommandRequest(CreatePortfolioCategoryViewModel CreatePortfolioCategoryViewModel) : IRequest<bool>
{
   
}
