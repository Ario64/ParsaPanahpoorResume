using Resume.Domain.ViewModels.Portfolio;
using System.Collections.Generic;

namespace Resume.Domain.ViewModels.Page
{
    public class PortfolioPageViewModel
    {
        public IReadOnlyList<PortfolioViewModel> Portfolios { get; set; }
        public IReadOnlyList<PortfolioCategoryViewModel> PortfolioCategories { get; set; }
    }
}
