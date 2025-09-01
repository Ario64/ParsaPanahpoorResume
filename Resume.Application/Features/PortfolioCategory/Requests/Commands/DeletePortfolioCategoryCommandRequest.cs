using MediatR;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record DeletePortfolioCategoryCommandRequest(long Id) : IRequest<bool>
{
    
}
