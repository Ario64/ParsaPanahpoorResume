using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Queries;

public record GetReservationDateRequest : IRequest<PortfolioCategoryViewModel>
{
    public ulong Id { get; init; }
}
