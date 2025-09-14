using System.ComponentModel.DataAnnotations;

namespace Resume.Application.ViewModels.Portfolio
{
    public interface IPortfolioCategoryViewModel 
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
