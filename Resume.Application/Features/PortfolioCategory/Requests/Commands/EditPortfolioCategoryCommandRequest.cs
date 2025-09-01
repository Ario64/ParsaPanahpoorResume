using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record EditPortfolioCategoryCommandRequest : IRequest<bool>
{
    public long Id { get; init; }
    public EditPortfolioCategoryViewModel EditPortfolioViewModel { get; init; }

    public EditPortfolioCategoryCommandRequest(long id, EditPortfolioCategoryViewModel editPortfolioCategoryViewModel)
    {
        Id = id;    
        EditPortfolioViewModel = editPortfolioCategoryViewModel;    
    }
}
