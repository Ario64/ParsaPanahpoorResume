using MediatR;
using Resume.Application.ViewModels.Portfolio;
using System.Collections.Generic;

namespace Resume.Application.Features.Portfolio.Requests.Queries;

public record GetPortfolioListRequest() : IRequest<IReadOnlyList<PortfolioViewModel>>
{
}
