using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Portfolio;
using System.Collections.Generic;

namespace Resume.Domain.ViewModels.Page
{
    public class PortfolioPageViewModel
    {
        public PagedResult<PortfolioViewModel> Portfolios { get; set; }
        public IReadOnlyList<PortfolioCategoryViewModel> PortfolioCategories { get; set; }
    }
}
