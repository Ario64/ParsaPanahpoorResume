using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record CreatePortfolioCategoryCommandRequest : IRequest<Unit>
{
    public CreatePortfolioCategoryViewModel CreatePortfolioCategoryViewModel { get; init; }
}
