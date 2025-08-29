using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record CreatePortfolioCategoryCommandRequest : IRequest<Unit>
{
    public CreatePortfolioViewModel CreatePortfolioViewModel { get; init; }
}
