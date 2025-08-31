using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Queries;

public record GetPortfolioRequest(ulong Id) : IRequest<PortfolioViewModel>
{
    
}
