using MediatR;
using Resume.Application.ViewModels.Portfolio;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record CreatePortfolioCommandRequest : IRequest<bool>
{
    public CreatePortfolioViewModel CreatePortfolioViewModel { get; init; }

    public CreatePortfolioCommandRequest(CreatePortfolioViewModel createPortfolioViewModel)
    {
        CreatePortfolioViewModel = createPortfolioViewModel;
    }  
}
