using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resume.Application.ViewModels.Portfolio;

public interface IPortfolioViewModel
{
    public string Title { get; set; }

    public string Link { get; set; }

    public string Image { get; set; }

    public string ImageAlt { get; set; }

    public int Order { get; set; }

    public string PortfolioCategoryName { get; set; }

    public long PortfolioCategoryId { get; set; }

    [NotMapped]
    public IReadOnlyList<PortfolioCategoryViewModel> PortfolioCategories { get; set; } 
}
