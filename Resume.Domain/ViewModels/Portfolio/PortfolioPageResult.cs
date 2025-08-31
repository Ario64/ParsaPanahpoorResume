using Resume.Domain.ViewModels.Pagination;
using System.Collections.Generic;

namespace Resume.Domain.ViewModels.Portfolio;

public record PortfolioPageResult : PagedResult<PortfolioViewModel>
{
    public IReadOnlyList<PortfolioCategoryViewModel> CategoryList { get; set; }
}
