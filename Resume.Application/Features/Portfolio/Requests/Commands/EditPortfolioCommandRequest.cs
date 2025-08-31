using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record EditPortfolioCommandRequest(ulong Id, EditPortfolioViewModel EditPortfolioViewModel) : IRequest<bool>
{
 
}
