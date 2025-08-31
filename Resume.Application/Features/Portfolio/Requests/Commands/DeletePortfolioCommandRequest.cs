using MediatR;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record DeletePortfolioCommandRequest(ulong Id) : IRequest<bool>
{
  
}
