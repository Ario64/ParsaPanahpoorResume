using Resume.Application.ViewModels.Pagination;
using System.Collections.Generic;

namespace Resume.Application.ViewModels.Portfolio;

public record PortfolioPageResult : PagedResult<PortfolioViewModel>
{
    public IReadOnlyList<PortfolioCategoryViewModel> CategoryList { get; set; }
}
