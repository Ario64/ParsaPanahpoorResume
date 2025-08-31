using MediatR;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Features.PortfolioCategory.Requests.Commands;

public record EditPortfolioCategoryCommandRequest : IRequest<bool>
{
    public ulong Id { get; init; }
    public EditPortfolioCategoryViewModel EditPortfolioViewModel { get; init; }

    public EditPortfolioCategoryCommandRequest(ulong id, EditPortfolioCategoryViewModel editPortfolioCategoryViewModel)
    {
        Id = id;    
        EditPortfolioViewModel = editPortfolioCategoryViewModel;    
    }
}
