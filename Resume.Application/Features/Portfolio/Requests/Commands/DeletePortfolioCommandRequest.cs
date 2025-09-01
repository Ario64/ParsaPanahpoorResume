using MediatR;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record DeletePortfolioCommandRequest(long Id) : IRequest<bool>
{
  
}
