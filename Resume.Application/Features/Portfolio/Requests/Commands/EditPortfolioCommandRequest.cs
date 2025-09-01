using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record EditPortfolioCommandRequest(long Id, EditPortfolioViewModel EditPortfolioViewModel) : IRequest<bool>
{
 
}
