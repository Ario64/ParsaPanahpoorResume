using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record CreateReservationDateCommandRequest : IRequest<Unit>
{
    public CreatePortfolioCategoryViewModel CreatePortfolioCategoryViewModel { get; init; }
}
