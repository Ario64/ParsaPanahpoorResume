using Resume.Application.ViewModels.Portfolio;
using System.Collections.Generic;

namespace Resume.Application.ViewModels.Page
{
    public class PortfolioPageViewModel
    {
        public IReadOnlyList<PortfolioViewModel> Portfolios { get; set; }
        public IReadOnlyList<PortfolioCategoryViewModel> PortfolioCategories { get; set; }
    }
}
