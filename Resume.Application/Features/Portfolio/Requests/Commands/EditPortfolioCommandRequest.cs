using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record EditPortfolioCategoryCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditPortfolioViewModel EditPortfolioViewModel { get; init; }
}
