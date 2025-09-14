using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.Portfolio
{
    public class EditPortfolioViewModel : BaseViewModel<long>, IPortfolioViewModel
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "لینک")]
        public string Link { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "توضیح تصویر")]
        public string ImageAlt { get; set; }

        [Display(Name = "الویت")]
        public int Order { get; set; }

        [Display(Name = "عنوان دسته بندی")]
        public string PortfolioCategoryName { get; set; }

        [Display(Name = "عنوان دسته بندی")]
        public long PortfolioCategoryId { get; set; }

        [NotMapped]
        public IReadOnlyList<PortfolioCategoryViewModel> PortfolioCategories { get; set; } = new List<PortfolioCategoryViewModel>();

    }
}
