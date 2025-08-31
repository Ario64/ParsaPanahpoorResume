using MediatR;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record DeletePortfolioCategoryCommandRequest(ulong Id) : IRequest<bool>
{
    
}
