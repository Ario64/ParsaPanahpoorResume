using MediatR;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record DeletePortfolioCategoryCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
