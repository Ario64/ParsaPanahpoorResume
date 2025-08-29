using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record CreatePortfolioCommandRequest : IRequest<Unit>
{
    public CreatePortfolioViewModel CreatePortfolioViewModel { get; init; }
}
