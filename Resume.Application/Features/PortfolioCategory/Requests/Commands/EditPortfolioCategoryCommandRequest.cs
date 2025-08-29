using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record EditPortfolioCategoryCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditPortfolioCategoryViewModel EditPortfolioViewModel { get; init; }
}
