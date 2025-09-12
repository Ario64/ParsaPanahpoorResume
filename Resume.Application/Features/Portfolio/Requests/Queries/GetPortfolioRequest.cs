using MediatR;
using Resume.Application.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Queries;

public record GetPortfolioRequest(long? Id) : IRequest<PortfolioViewModel>
{
    
}
